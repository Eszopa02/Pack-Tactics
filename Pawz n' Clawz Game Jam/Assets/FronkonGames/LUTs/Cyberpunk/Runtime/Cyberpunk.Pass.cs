////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Martin Bustos @FronkonGames <fronkongames@gmail.com>. All rights reserved.
//
// THIS FILE CAN NOT BE HOSTED IN PUBLIC REPOSITORIES.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
#if UNITY_6000_0_OR_NEWER
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
#endif

namespace FronkonGames.LUTs.Cyberpunk
{
  ///------------------------------------------------------------------------------------------------------------------
  /// <summary> Render Pass. </summary>
  /// <remarks> Only available for Universal Render Pipeline. </remarks>
  ///------------------------------------------------------------------------------------------------------------------
  public sealed partial class Cyberpunk
  {
    [DisallowMultipleRendererFeature]
    private sealed class RenderPass : ScriptableRenderPass
    {
      // Internal use only.
      internal Material material { get; set; }

      private readonly Settings settings;

#if UNITY_6000_0_OR_NEWER
#else
      private RenderTargetIdentifier colorBuffer;
      private RenderTextureDescriptor renderTextureDescriptor;

      private readonly int renderTextureHandle0 = Shader.PropertyToID($"{Constants.Asset.AssemblyName}.RTH0");

      private const string CommandBufferName = Constants.Asset.AssemblyName;

      private ProfilingScope profilingScope;
      private readonly ProfilingSampler profilingSamples = new(Constants.Asset.AssemblyName);
#endif

      private static class ShaderIDs
      {
        internal static readonly int Intensity = Shader.PropertyToID("_Intensity");

        internal static readonly int LUTTexture = Shader.PropertyToID("_LUTTex");
        internal static readonly int LUTParams = Shader.PropertyToID("_LUTParams");

        internal static readonly int Exposure = Shader.PropertyToID("_Exposure");
        internal static readonly int Contrast = Shader.PropertyToID("_Contrast");
        internal static readonly int Tint = Shader.PropertyToID("_Tint");
        internal static readonly int Hue = Shader.PropertyToID("_Hue");
        internal static readonly int Saturation = Shader.PropertyToID("_Saturation");
        internal static readonly int WhiteBalance = Shader.PropertyToID("_WhiteBalance");
        internal static readonly int SplitToningShadows = Shader.PropertyToID("_SplitToningShadows");
        internal static readonly int SplitToningHighlights = Shader.PropertyToID("_SplitToningHighlights");
        internal static readonly int ChannelMixerRed = Shader.PropertyToID("_ChannelMixerRed");
        internal static readonly int ChannelMixerGreen = Shader.PropertyToID("_ChannelMixerGreen");
        internal static readonly int ChannelMixerBlue = Shader.PropertyToID("_ChannelMixerBlue");
        internal static readonly int Shadows = Shader.PropertyToID("_Shadows");
        internal static readonly int Midtones = Shader.PropertyToID("_Midtones");
        internal static readonly int Highlights = Shader.PropertyToID("_Highlights");
        internal static readonly int ShadowsStart = Shader.PropertyToID("_ShadowsStart");
        internal static readonly int ShadowsEnd = Shader.PropertyToID("_ShadowsEnd");
        internal static readonly int HighlightsStart = Shader.PropertyToID("_HighlightsStart");
        internal static readonly int HighlightsEnd = Shader.PropertyToID("_HighlightsEnd");
      }

      private static class Keywords
      {
        internal static readonly string ColorGrading = "_USE_COLOR_GRADING";
        internal static readonly string TonemapNeutral = "_TONEMAP_NEUTRAL";
        internal static readonly string TonemapACES = "_TONEMAP_ACES";
        internal static readonly string TonemapReinhard = "_TONEMAP_REINHARD";
      }

      /// <summary> Render pass constructor. </summary>
      public RenderPass(Settings settings) : base()
      {
        this.settings = settings;
#if UNITY_6000_0_OR_NEWER
        profilingSampler = new ProfilingSampler(Constants.Asset.AssemblyName);
#endif
      }

      /// <summary> Destroy the render pass. </summary>
      ~RenderPass() => material = null;

      private void UpdateMaterial()
      {
        material.shaderKeywords = null;
        material.SetFloat(ShaderIDs.Intensity, settings.intensity);

        Texture3D texture3D = settings.mode == Modes.Quality ? settings.profile.quality : settings.profile.performance;
        material.SetVector(ShaderIDs.LUTParams, new Vector2(1.0f / texture3D.width, texture3D.width - 1.0f));
        material.SetTexture(ShaderIDs.LUTTexture, texture3D);

        if (settings.enableColorGrading == true)
        {
          material.EnableKeyword(Keywords.ColorGrading);

          switch (settings.tonemap)
          {
            case Tonemappers.Neutral: material.EnableKeyword(Keywords.TonemapNeutral); break;
            case Tonemappers.ACES: material.EnableKeyword(Keywords.TonemapACES); break;
            case Tonemappers.Reinhard: material.EnableKeyword(Keywords.TonemapReinhard); break;
          }

          material.SetFloat(ShaderIDs.Exposure, Mathf.Pow(2.0f, settings.exposure));
          material.SetFloat(ShaderIDs.Contrast, settings.contrast * 0.01f + 1.0f);
          material.SetColor(ShaderIDs.Tint, settings.tint);
          material.SetFloat(ShaderIDs.Hue, settings.hue * (1.0f / 360.0f));
          material.SetFloat(ShaderIDs.Saturation, settings.saturation * 0.01f + 1.0f);

          material.SetVector(ShaderIDs.WhiteBalance, ColorUtils.ColorBalanceToLMSCoeffs(settings.whiteTemperature, settings.whiteTint));

          Color splitColor = settings.splitToningShadows;
          splitColor.a = settings.splitToningBalance * 0.01f;
          material.SetColor(ShaderIDs.SplitToningShadows, splitColor);
          material.SetColor(ShaderIDs.SplitToningHighlights, settings.splitToningHighlights);

          material.SetVector(ShaderIDs.ChannelMixerRed, settings.channelMixerRed);
          material.SetVector(ShaderIDs.ChannelMixerGreen, settings.channelMixerGreen);
          material.SetVector(ShaderIDs.ChannelMixerBlue, settings.channelMixerBlue);

          material.SetColor(ShaderIDs.Shadows, settings.shadows.linear);
          material.SetFloat(ShaderIDs.ShadowsStart, settings.shadowsStart);
          material.SetFloat(ShaderIDs.ShadowsEnd, settings.shadowsEnd);
          material.SetColor(ShaderIDs.Midtones, settings.midtones.linear);
          material.SetColor(ShaderIDs.Highlights, settings.highlights.linear);
          material.SetFloat(ShaderIDs.HighlightsStart, settings.highlightsStart);
          material.SetFloat(ShaderIDs.HighlightsEnd, settings.highLightsEnd);
        }
      }

#if UNITY_6000_0_OR_NEWER
      /// <inheritdoc/>
      public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
      {
        if (material == null || settings.intensity <= 0.0f || settings.profile == null)
          return;

        UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
        if (resourceData.isActiveTargetBackBuffer == true)
          return;

        UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
        if (cameraData.camera.cameraType == CameraType.SceneView && settings.affectSceneView == false || cameraData.postProcessEnabled == false)
          return;

        TextureHandle source = resourceData.activeColorTexture;
        TextureHandle destination = renderGraph.CreateTexture(source.GetDescriptor(renderGraph));

        UpdateMaterial();

        RenderGraphUtils.BlitMaterialParameters pass = new(source, destination, material, 0);
        renderGraph.AddBlitPass(pass, $"{Constants.Asset.AssemblyName}.Pass");

        resourceData.cameraColor = destination;
      }
#elif UNITY_2022_3_OR_NEWER
      /// <inheritdoc/>
      public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
      {
        renderTextureDescriptor = renderingData.cameraData.cameraTargetDescriptor;
        renderTextureDescriptor.depthBufferBits = 0;

        colorBuffer = renderingData.cameraData.renderer.cameraColorTargetHandle;
        cmd.GetTemporaryRT(renderTextureHandle0, renderTextureDescriptor, settings.filterMode);
      }

      /// <inheritdoc/>
      public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
      {
        if (material == null ||
            renderingData.postProcessingEnabled == false ||
            settings.intensity <= 0.0f ||
            settings.profile == null ||
            settings.affectSceneView == false && renderingData.cameraData.isSceneViewCamera == true)
          return;

        CommandBuffer cmd = CommandBufferPool.Get(CommandBufferName);

        if (settings.enableProfiling == true)
          profilingScope = new ProfilingScope(cmd, profilingSamples);

        UpdateMaterial();

        cmd.Blit(colorBuffer, renderTextureHandle0, material);
        cmd.Blit(renderTextureHandle0, colorBuffer);

        cmd.ReleaseTemporaryRT(renderTextureHandle0);

        if (settings.enableProfiling == true)
          profilingScope.Dispose();

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
      }

      public override void OnCameraCleanup(CommandBuffer cmd) => cmd.ReleaseTemporaryRT(renderTextureHandle0);
#else
      #error Unsupported Unity version. Please update to a newer version of Unity.
#endif
    }
  }
}