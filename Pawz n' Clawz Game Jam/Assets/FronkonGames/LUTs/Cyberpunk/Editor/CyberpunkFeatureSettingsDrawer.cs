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
using UnityEditor;
using static FronkonGames.LUTs.Cyberpunk.Inspector;

namespace FronkonGames.LUTs.Cyberpunk.Editor
{
  /// <summary> Cyberpunk inspector. </summary>
  [CustomPropertyDrawer(typeof(Cyberpunk.Settings))]
  public class CyberpunkFeatureSettingsDrawer : Drawer
  {
    private Cyberpunk.Settings settings;

    private bool showColorFoldout = true;

    protected override void ResetValues() => settings?.ResetDefaultValues();

    protected override void InspectorGUI()
    {
      settings ??= GetSettings<Cyberpunk.Settings>();

      /////////////////////////////////////////////////
      // Common.
      /////////////////////////////////////////////////
      settings.intensity = Slider("Intensity", "Controls the intensity of the effect [0, 1]. Default 0.", settings.intensity, 0.0f, 1.0f, 1.0f);

      /////////////////////////////////////////////////
      // Cyberpunk.
      /////////////////////////////////////////////////
      Separator();

      settings.mode = (Cyberpunk.Modes)EnumPopup("Mode", "MOdo calidad o rendimi.", settings.mode, Cyberpunk.Modes.Quality);

      settings.profile = ObjectField("Profile", "", settings.profile);

      /////////////////////////////////////////////////
      // Color grading.
      /////////////////////////////////////////////////
      Separator();

      settings.enableColorGrading = ToggleFoldout("Color grading", settings.enableColorGrading, ref showColorFoldout);
      if (showColorFoldout == true)
      {
        IndentLevel++;

        GUI.enabled = settings.enableColorGrading;

        settings.exposure = FloatField("Exposure", "Post exposure. Default 0.", settings.exposure, 0.0f);
        settings.contrast = Slider("Contrast", "Contrast [-100, 100]. Default 0.", settings.contrast, -100.0f, 100.0f, 0.0f);
        settings.tint = ColorField("Tint", "Color filter.", settings.tint, false, true, Color.white);
        settings.hue = Slider("Hue", "The color wheel [-180, 180]. Default 0.", settings.hue, -180.0f, 180.0f, 0.0f);
        settings.saturation = Slider("Saturation", "Intensity of a colors [-100, 100]. Default 0.", settings.saturation, -100.0f, 100.0f, 0.0f);
        settings.tonemap = (Cyberpunk.Tonemappers)EnumPopup("Tonemap", "Tonemap operator. Default None.", settings.tonemap, Cyberpunk.Tonemappers.None);

        Label("White balance");
        IndentLevel++;
        settings.whiteTemperature = Slider("Temperature", "Adjust the perceived temperature, making the image cooler or warmer [-100, 100]. Default 0.", settings.whiteTemperature, -100.0f, 100.0f, 0.0f);
        settings.whiteTint = Slider("Tint", "Temperature-shifted color [-100, 100]. Default 0.", settings.whiteTint, -100.0f, 100.0f, 0.0f);
        IndentLevel--;

        Label("Split toning");
        IndentLevel++;
        settings.splitToningShadows = ColorField("Shadows", "Tint shadows.", settings.splitToningShadows, Color.gray);
        settings.splitToningHighlights = ColorField("Highlights", "Tint highlights.", settings.splitToningHighlights, Color.gray);
        settings.splitToningBalance = Slider("Balance", "Split toning balance [-100, 100]. Default 0.", settings.splitToningBalance, -100.0f, 100.0f, 0.0f);
        IndentLevel--;

        Label("Channel mixer");
        IndentLevel++;
        settings.channelMixerRed = Vector3Field("Red", "Swap color for red channel.", settings.channelMixerRed, Vector3.right);
        settings.channelMixerGreen = Vector3Field("Green", "Swap color for green channel.", settings.channelMixerGreen, Vector3.up);
        settings.channelMixerBlue = Vector3Field("Blue", "Swap color for blue channel.", settings.channelMixerBlue, Vector3.forward);
        IndentLevel--;

        Label("Shadows Midtones Highlights");
        IndentLevel++;
        settings.shadows = ColorField("Shadows", "Shadows color adjust.", settings.shadows, false, true, Color.white);
        MinMaxSlider(" ", "Shadows range [0, 2]. Default [0 - 0.3].", ref settings.shadowsStart, ref settings.shadowsEnd, 0.0f, 2.0f, 0.0f, 0.3f);
        settings.midtones = ColorField("Midtones", "Midtone color adjust.", settings.midtones, false, true, Color.white);
        settings.highlights = ColorField("Highlights", "Highlights color adjust.", settings.highlights, false, true, Color.white);
        MinMaxSlider(" ", "Highlights range [0, 2]. Default [0.55 - 1].", ref settings.highlightsStart, ref settings.highLightsEnd, 0.0f, 2.0f, 0.55f, 1.0f);
        IndentLevel--;

        GUI.enabled = true;

        IndentLevel--;
      }

      /////////////////////////////////////////////////
      // Advanced.
      /////////////////////////////////////////////////
      Separator();

      if (Foldout("Advanced") == true)
      {
        IndentLevel++;

#if !UNITY_6000_0_OR_NEWER
        settings.filterMode = (FilterMode)EnumPopup("Filter mode", "Filter mode. Default Bilinear.", settings.filterMode, FilterMode.Bilinear);
#endif
        settings.affectSceneView = Toggle("Affect the Scene View?", "Does it affect the Scene View?", settings.affectSceneView);
        settings.whenToInsert = (UnityEngine.Rendering.Universal.RenderPassEvent)EnumPopup("RenderPass event",
          "Render pass injection. Default BeforeRenderingPostProcessing.",
          settings.whenToInsert,
          UnityEngine.Rendering.Universal.RenderPassEvent.BeforeRenderingPostProcessing);
#if !UNITY_6000_0_OR_NEWER
        settings.enableProfiling = Toggle("Enable profiling", "Enable render pass profiling", settings.enableProfiling);
#endif

        IndentLevel--;
      }
    }
  }
}
