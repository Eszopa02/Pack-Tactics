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

namespace FronkonGames.LUTs.Cyberpunk
{
  ///------------------------------------------------------------------------------------------------------------------
  /// <summary>
  /// 
  /// 🕹️ Documentation: https://fronkongames.github.io/store/luts/
  /// 📄 Demo:          https://fronkongames.github.io/demos-luts/cyberpunk/
  /// 📧 Support:       fronkongames@gmail.com
  /// ❤️ More assets:   https://assetstore.unity.com/publishers/62716
  /// 
  /// 💡 Do you want to report an error? Please, send the log file along with the mail.
  /// 
  /// ❤️ Leave a review if you found this asset useful, thanks! ❤️
  /// 
  /// </summary>
  /// <remarks> Only available for Universal Render Pipeline. </remarks>
  ///------------------------------------------------------------------------------------------------------------------
  [DisallowMultipleRendererFeature(Constants.Asset.Name)]
  public sealed partial class Cyberpunk : ScriptableRendererFeature
  {
    // MUST be named "settings" (lowercase) to be shown in the Render Features inspector.
    public Settings settings = new();

    private RenderPass renderPass;

    private Material material;

    public override void Create() => renderPass ??= new RenderPass(settings);

    /// <summary> Injects one or multiple ScriptableRenderPass in the renderer. Called every frame once per camera. </summary>
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
      if (renderingData.cameraData.cameraType == CameraType.Preview || renderingData.cameraData.cameraType == CameraType.Reflection)
        return;

      if (SystemInfo.supports3DTextures == true)
      {
        renderPass.renderPassEvent = settings.whenToInsert;

        if (material == null)
        {
          string shaderPath = $"Shaders/{Constants.Asset.ShaderName}_URP";
          Shader shader = Resources.Load<Shader>(shaderPath);
          if (shader != null)
          {
            if (shader.isSupported == true)
              material = new Material(shader);
            else
              Log.Warning($"'{shaderPath}.shader' not supported");
          }
          else
            Log.Error($"Shader '{shaderPath}' not found");
        }

        renderPass.material = material;
        renderer.EnqueuePass(renderPass);
      }
      else
        Log.Error("Hardware does not support 3D textures, effect disabled");
    }

    protected override void Dispose(bool disposing) => CoreUtils.Destroy(material);
  }
}
