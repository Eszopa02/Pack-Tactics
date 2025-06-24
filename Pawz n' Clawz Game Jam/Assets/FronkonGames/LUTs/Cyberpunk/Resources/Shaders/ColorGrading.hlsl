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
#ifndef COLOR_GRADING
#define COLOR_GRADING

float _Exposure;
float _Contrast;
float3 _Tint;
float _Hue;
float _Saturation;

float3 _WhiteBalance;

float4 _SplitToningShadows;
float4 _SplitToningHighlights;

float3 _ChannelMixerRed;
float3 _ChannelMixerGreen;
float3 _ChannelMixerBlue;

float3 _Shadows;
float3 _Midtones;
float3 _Highlights;
float _ShadowsStart;
float _ShadowsEnd;
float _HighlightsStart;
float _HighlightsEnd;

float3 ColorGrading(float3 pixel)
{
  // Exposure.
  pixel *= _Exposure;

  // White balance.
  pixel = LinearToLMS(pixel);
	pixel *= _WhiteBalance;
	pixel = LMSToLinear(pixel);

  // Constrast.
#if _TONEMAP_ACES
  pixel = ACES_to_ACEScc(unity_to_ACES(pixel));
  pixel = (pixel - ACEScc_MIDGRAY) * _Contrast + ACEScc_MIDGRAY;
  pixel = ACES_to_ACEScg(ACEScc_to_ACES(pixel));
#else
  pixel = LinearToLogC(pixel);
  pixel = (pixel - ACEScc_MIDGRAY) * _Contrast + ACEScc_MIDGRAY;
  pixel = LogCToLinear(pixel);
#endif

  // Tint.
  pixel *= _Tint;

  pixel = max(pixel, 0.0);

  // Split toning.
  pixel = PositivePow(pixel, 1.0 / 2.2);
	float t = saturate(
#if _TONEMAP_ACES
      AcesLuminance(pixel)
#else
      Luminance(pixel)
#endif
      + _SplitToningShadows.a);
	float3 shadows = lerp(0.5, _SplitToningShadows.rgb, 1.0 - t);
	float3 highlights = lerp(0.5, _SplitToningHighlights.rgb, t);
	pixel = SoftLight(pixel, shadows);
	pixel = SoftLight(pixel, highlights);
	pixel = PositivePow(pixel, 2.2);

  // Channel mixer.
	pixel = mul(float3x3(_ChannelMixerRed, _ChannelMixerGreen, _ChannelMixerBlue), pixel);

  pixel = max(pixel, 0.0);

  // Shadows midtones/highlights.
	float luminance =
#if _TONEMAP_ACES
    AcesLuminance(pixel);
#else
    Luminance(pixel);
#endif
	float shadowsWeight = 1.0 - smoothstep(_ShadowsStart, _ShadowsEnd, luminance);
	float highlightsWeight = smoothstep(_HighlightsStart, _HighlightsEnd, luminance);
	float midtonesWeight = 1.0 - shadowsWeight - highlightsWeight;
	pixel = pixel * _Shadows * shadowsWeight +
          pixel * _Midtones * midtonesWeight +
		      pixel * _Highlights * highlightsWeight;

  // Hue shift.
  pixel = RgbToHsv(pixel);
	pixel.x = RotateHue(pixel.x + _Hue, 0.0, 1.0);
	pixel = HsvToRgb(pixel);

  // Saturation.
  luminance =
#if _TONEMAP_ACES
    AcesLuminance(pixel);
#else
    Luminance(pixel);
#endif
	pixel = (pixel - luminance) * _Saturation + luminance;

  pixel = max(
#if _TONEMAP_ACES
    ACEScg_to_ACES(pixel),
#else
    pixel,
#endif
    0.0);
    
  // Tonemapping.
#if _TONEMAP_ACES
  pixel = AcesTonemap(pixel);
#elif _TONEMAP_NEUTRAL
  pixel = NeutralTonemap(pixel);
#elif _TONEMAP_REINHARD
  pixel /= pixel + 1.0;
#endif

  return pixel;
}

#endif