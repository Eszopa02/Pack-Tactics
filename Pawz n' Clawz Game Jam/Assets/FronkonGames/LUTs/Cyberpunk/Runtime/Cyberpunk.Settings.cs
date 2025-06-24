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
using System;
using UnityEngine;
using UnityEngine.Search;
using UnityEngine.Rendering.Universal;

namespace FronkonGames.LUTs.Cyberpunk
{
  ///------------------------------------------------------------------------------------------------------------------
  /// <summary> Settings. </summary>
  /// <remarks> Only available for Universal Render Pipeline. </remarks>
  ///------------------------------------------------------------------------------------------------------------------
  public sealed partial class Cyberpunk
  {
    /// <summary> Settings. </summary>
    [Serializable]
    public sealed class Settings
    {
      public Settings() => ResetDefaultValues();

      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      #region Common settings.

      /// <summary> Controls the intensity of the effect [0, 1]. Default 1. </summary>
      /// <remarks> An effect with Intensity equal to 0 will not be executed. </remarks>
      public float intensity = 1.0f;

      #endregion
      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      #region Cyberpunk settings.

      /// <summary> Quality or performance mode. </summary>
      public Modes mode = Modes.Quality;

      /// <summary> LUT profile. </summary>
      [SearchContext("Cyberpunk")]
      public Profile profile;

      #endregion
      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      #region Color grading (must have 'enableColorGrading' set to true).

      /// <summary> Activates the color settings. Default false. </summary>
      public bool enableColorGrading = false;

      /// <summary> Tonemap operator. Default None. </summary>
      public Tonemappers tonemap = Tonemappers.None;

      /// <summary> Post exposure. Default 0. </summary>
      public float exposure = 0.0f;

      /// <summary> Contrast [-100, 100]. Default 0. </summary>
      public float contrast = 0.0f;

      /// <summary> Color filter. </summary>
      public Color tint = Color.white;

      /// <summary> The color wheel [-180, 180]. Default 0. </summary>
      public float hue = 0.0f;

      /// <summary> Intensity of a colors [-100, 100]. Default 0. </summary>
      public float saturation = 0.0f;

      /// <summary> Adjust the perceived temperature, making the image cooler or warmer [-100, 100]. Default 0. </summary>
      public float whiteTemperature = 0.0f;

      /// <summary> Temperature-shifted color [-100, 100]. Default 0. </summary>
      public float whiteTint = 0.0f;

      /// <summary> Tint shadows. </summary>
      public Color splitToningShadows = Color.gray;

      /// <summary> Tint highlights. </summary>
      public Color splitToningHighlights = Color.gray;

      /// <summary> Split toning balance [-100, 100]. Default 0. </summary>
      public float splitToningBalance = 0.0f;

      /// <summary> Swap color for red channel. </summary>
      public Vector3 channelMixerRed = Vector3.right;

      /// <summary> Swap color for green channel. </summary>
      public Vector3 channelMixerGreen = Vector3.up;

      /// <summary> Swap color for blue channel. </summary>
      public Vector3 channelMixerBlue = Vector3.forward;

      /// <summary> Shadow color adjust. </summary>
      public Color shadows = Color.white;

      /// <summary> Midtone color adjust. </summary>
      public Color midtones = Color.white;

      /// <summary> Highlights color adjust. </summary>
      public Color highlights = Color.white;

      /// <summary> Shadow range start [0, 2]. Default 0. </summary>
      public float shadowsStart = 0.0f;

      /// <summary> Shadow range end [0, 2]. Default 0.3. </summary>
      public float shadowsEnd = 0.3f;

      /// <summary> Highlights range start [0, 2]. Default 0.55. </summary>
      public float highlightsStart = 0.55f;

      /// <summary> Highlights range end [0, 2]. Default 1. </summary>
      public float highLightsEnd = 1.0f;

      #endregion
      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      #region Advanced settings.
      /// <summary> Does it affect the Scene View? </summary>
      public bool affectSceneView = false;

#if !UNITY_6000_0_OR_NEWER
      /// <summary> Enable render pass profiling. </summary>
      public bool enableProfiling = false;

      /// <summary> Filter mode. Default Bilinear. </summary>
      public FilterMode filterMode = FilterMode.Bilinear;
#endif

      /// <summary> Render pass injection. Default BeforeRenderingPostProcessing. </summary>
      public RenderPassEvent whenToInsert = RenderPassEvent.BeforeRenderingPostProcessing;
      #endregion
      /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      /// <summary> Reset to default values. </summary>
      public void ResetDefaultValues()
      {
        intensity = 1.0f;

        mode = Modes.Quality;

        tonemap = Tonemappers.None;
        exposure = 0.0f;
        contrast = 1.0f;
        tint = Color.white;
        hue = 0.0f;
        saturation = 1.0f;
        whiteTemperature = 0.0f;
        whiteTint = 0.0f;
        splitToningShadows = Color.gray;
        splitToningHighlights = Color.gray;
        splitToningBalance = 0.0f;
        channelMixerRed = Vector3.right;
        channelMixerGreen = Vector3.up;
        channelMixerBlue = Vector3.forward;
        shadows = midtones = highlights = Color.white;
        shadowsStart = 0.0f;
        shadowsEnd = 0.3f;
        highlightsStart = 0.55f;
        highLightsEnd = 1.0f;


        affectSceneView = false;
#if !UNITY_6000_0_OR_NEWER
        enableProfiling = false;
        filterMode = FilterMode.Bilinear;
#endif
        whenToInsert = RenderPassEvent.BeforeRenderingPostProcessing;
      }
    }
  }
}
