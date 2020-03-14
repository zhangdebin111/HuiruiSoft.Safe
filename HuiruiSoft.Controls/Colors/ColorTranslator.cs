
namespace HuiruiSoft.Drawing
{
     public static class ColorTranslator
	{
          /// <summary>将 HTML 颜色表示形式翻译成 GDI+ Color 结构。</summary>
          /// <param name="htmlColor">要翻译的 Html 颜色的字符串表示形式。</param>
          /// <returns>表示已翻译的 HTML 颜色的 Color 结构。</returns>
          /// <remarks>此方法将 HTML 颜色名称的字符串表示形式（如 Blue 或 Red）翻译成 GDI+ <b>Color</b> 结构。</remarks>
          public static System.Drawing.Color FromHtml(string htmlColor)
          {
               return System.Drawing.ColorTranslator.FromHtml(htmlColor);
          }

          /// <summary>将 HTML 颜色表示形式翻译成 GDI+ Color 结构。</summary>
          /// <param name="color">要翻译的 Windows 颜色。</param>
          /// <returns>表示已翻译的 Windows 颜色的 Color 结构。</returns>
          public static System.Drawing.Color FromWin32(int color)
          {
               return System.Drawing.ColorTranslator.FromWin32(color);
          }

          /// <summary>将指定的 Color 结构翻译成字符串表示形式。</summary>
          /// <param name="color">要翻译的 Color 结构。</param>
          /// <returns>翻译成字符串表示形式的结果。</returns>
          public static string ConvertToString(System.Drawing.Color color)
          {
               string tmpConvertTo = null;
               if(color.IsNamedColor)
               {
                    tmpConvertTo = color.Name;
               }
               else
               {
                    tmpConvertTo = string.Format("RGB:{0}:{1}:{2}:{3}", new object[4] { color.A, color.R, color.G, color.B });
               }

               return System.Drawing.ColorTranslator.ToHtml(color);
          }

          /// <summary>将指定的 Color 结构翻译成 HTML 字符串颜色表示形式。</summary>
          /// <param name="color">要翻译的 Color 结构。</param>
          /// <returns>表示 HTML 颜色的字符串。</returns>
          public static string ToHtml(System.Drawing.Color color)
          {
               return System.Drawing.ColorTranslator.ToHtml(color);
          }

          /// <summary>将指定的 Color 结构翻译成 Windows 颜色。</summary>
          /// <param name="color">要翻译的 Color 结构。</param>
          /// <returns>Windows 颜色值。</returns>
          public static int ToWin32(System.Drawing.Color color)
          {
               return System.Drawing.ColorTranslator.ToWin32(color);
          }

          /// <summary>将指定的 Color 结构翻译成 OLE 颜色。</summary>
          /// <param name="color">要翻译的 Color 结构。</param>
          /// <returns>OLE 颜色值。</returns>
          public static int ToOle(System.Drawing.Color color)
          {
               return System.Drawing.ColorTranslator.ToOle(color);
          }

          /// <summary>将 HTML 颜色表示形式翻译成 OLE 颜色。</summary>
          /// <param name="htmlColor"></param>
          /// <param name="defaultColor"></param>
          /// <returns>uint,返回一个32位无符号整数型值。</returns>
          // [System.CLSCompliant(false)]
          public static uint ToOleColor(string htmlColor)
          {
               var tmpOleColor = (uint)ToWin32(System.Drawing.ColorTranslator.FromHtml(htmlColor));
               return (tmpOleColor);
          }

          public static System.Drawing.Color GetCombinedColor(System.Drawing.Color sourceColor1, System.Drawing.Color sourceColor2, int alpha)
          {
               var tmpSrcColor1 = System.Drawing.Color.FromArgb(255, sourceColor1);
               var tmpSrcColor2 = System.Drawing.Color.FromArgb(255, sourceColor2);

               var tmpNewColorR = (byte)(tmpSrcColor1.R * alpha / 255 + tmpSrcColor2.R * ((float)(255 - alpha) / 255));
               var tmpNewColorG = (byte)(tmpSrcColor1.G * alpha / 255 + tmpSrcColor2.G * ((float)(255 - alpha) / 255));
               var tmpNewColorB = (byte)(tmpSrcColor1.B * alpha / 255 + tmpSrcColor2.B * ((float)(255 - alpha) / 255));

               return System.Drawing.Color.FromArgb(255, tmpNewColorR, tmpNewColorG, tmpNewColorB);
          }

          public static bool IsTransparent(System.Drawing.Color color)
          {
               return (color.A == System.Drawing.Color.Transparent.A && color.R == System.Drawing.Color.Transparent.R && color.G == System.Drawing.Color.Transparent.G && color.B == System.Drawing.Color.Transparent.B);
          }

          public static System.Drawing.Color ConvertToColor(object color)
          {
               return ConvertToColor(color, System.Drawing.Color.Empty);
          }

          public static System.Drawing.Color ConvertToColor(object color, System.Drawing.Color defaultColor)
          {
               if(color is System.Drawing.Color)
               {
                    defaultColor = (System.Drawing.Color)color;
               }
               else if(color is int)
               {
                    defaultColor = System.Drawing.Color.FromArgb((int)color);
               }

               return defaultColor;
          }

		/// <summary>将指定的色调、饱和度、亮度所表示的颜色值翻译成 Color 结构。</summary>
          /// <param name="hue">要转换成 Color 结构的色调，以度为单位。在 HSBCOLOR 颜色空间内，色调以度来测量，范围从 0.0 到 360.0。</param>
		/// <param name="saturation">要转换成 Color 结构的饱和度，饱和度的范围从 0.0 到 1.0，其中 0.0 为灰度，1.0 表示最饱和。</param>
		/// <param name="luminance">要转换成 Color 结构的亮度值， 亮度的范围从 0.0 到 1.0，其中 0.0 表示黑色，1.0 表示白色。</param>
		/// <returns>表示已翻译的 HSBCOLOR 颜色的 Color 结构。</returns>
          public  static System.Drawing.Color FromHSB(float hue, float saturation, float luminance)
		{
			float R, G, B = 0;

			if(saturation == 0.0)
			{
				R = G = B = luminance * 255.0F;
			}
			else
			{
				float rm1, rm2;
         
				if(luminance <= 0.5f)
				{
					rm2 = luminance * ( 1 + saturation);
				}
				else
				{
					rm2 = 1 + (1 - luminance)*(saturation - 1);
				}

				rm1 = 2.0f * luminance - rm2;

				R  = ToRGB1(rm1, rm2, hue + 120.0f);
				G  = ToRGB1(rm1, rm2, hue);
				B  = ToRGB1(rm1, rm2, hue - 120.0f);
			}

			int tmpColorR = (int)(R), tmpColorG = (int)(G), tmpColorB = (int)(B);

			if(tmpColorR<0)    tmpColorR = 0;
			if(tmpColorG<0)    tmpColorG = 0;
			if(tmpColorB<0)    tmpColorB = 0;
			if(tmpColorR>255)  tmpColorR = 255;
			if(tmpColorG>255)  tmpColorG = 255;
			if(tmpColorB>255)  tmpColorB = 255;

			return System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB);
		}

		private static int ToRGB1(float rm1, float rm2, float rh)
		{
			if(rh > 360.0f)
			{
				rh -= 360.0f;
			}
			else if(rh < 0.0f)
			{
				rh += 360.0f;
			}

			switch((int)rh/60)
			{
				case 0:
					rm1 = rm1 + (rm2 - rm1) * rh / 60.0f; 
					break;

				case 1:
				case 2:
					rm1 = rm2;
					break;

				case 3:
					rm1 = rm1 + (rm2 - rm1) * (240.0f - rh) / 60.0f;
					break;
			}

			return (int)(rm1 * 255);
		}

          public static HSBCOLOR RGBToHSB(System.Drawing.Color color)
          {
               var tmpHSBColor = new HSBCOLOR( );

               int tmpMaximum, tmpMinimum;

               if(color.R > color.G)
               {
                    tmpMaximum = color.R; tmpMinimum = color.G;
               }
               else
               {
                    tmpMaximum = color.G; tmpMinimum = color.R;
               }

               if(color.B > tmpMaximum)
               {
                    tmpMaximum = color.B;
               }
               else if(color.B < tmpMinimum)
               {
                    tmpMinimum = color.B;
               }

               int tmpDifference = tmpMaximum - tmpMinimum;

               tmpHSBColor.Brightness = (double)tmpMaximum / 255;

               if(tmpMaximum == 0)
               {
                    tmpHSBColor.Saturation = 0;
               }
               else
               {
                    tmpHSBColor.Saturation = (double)tmpDifference / tmpMaximum;
               }

               double q;
               if(tmpDifference == 0)
               {
                    q = 0;
               }
               else
               {
                    q = (double)60 / tmpDifference;
               }

               if(tmpMaximum == color.R)
               {
                    if(color.G >= color.B)
                    {
                         tmpHSBColor.Hue = q * (color.G - color.B) / 360;
                    }
                    else
                    {
                         tmpHSBColor.Hue = (360 + q * (color.G - color.B)) / 360;
                    }
               }
               else if(tmpMaximum == color.G)
               {
                    tmpHSBColor.Hue = (120 + q * (color.B - color.R)) / 360;
               }
               else if(tmpMaximum == color.B)
               {
                    tmpHSBColor.Hue = (240 + q * (color.R - color.G)) / 360;
               }
               else
               {
                    tmpHSBColor.Hue = 0.0;
               }

               return tmpHSBColor;
          }


          public static System.Drawing.Color HSBToRGB(HSBCOLOR hsbColor)
          {
               int tmpColorR = 0, tmpColorG = 0, tmpColorB = 0;

               int tmpMaximum = HuiruiSoft.Drawing.ColorTranslator.Round(hsbColor.Brightness * 255);
               int tmpMinimum = HuiruiSoft.Drawing.ColorTranslator.Round((1.0 - hsbColor.Saturation) * (hsbColor.Brightness/1.0) * 255);

               var tmpMargin = (double)(tmpMaximum - tmpMinimum)/255;

               if(hsbColor.Hue >= 0 && hsbColor.Hue <= (double)1/6)
               {
                    tmpColorR = tmpMaximum;
                    tmpColorG = HuiruiSoft.Drawing.ColorTranslator.Round(((hsbColor.Hue - 0) * tmpMargin) * 1530 + tmpMinimum);
                    tmpColorB = tmpMinimum;
               }
               else if(hsbColor.Hue <= (double)1/3)
               {
                    tmpColorR = HuiruiSoft.Drawing.ColorTranslator.Round(-((hsbColor.Hue - (double)1/6) * tmpMargin) * 1530 + tmpMaximum);
                    tmpColorG = tmpMaximum;
                    tmpColorB = tmpMinimum;
               }
               else if(hsbColor.Hue <= 0.5)
               {
                    tmpColorR = tmpMinimum;
                    tmpColorG = tmpMaximum;
                    tmpColorB = HuiruiSoft.Drawing.ColorTranslator.Round(((hsbColor.Hue - (double)1/3) * tmpMargin) * 1530 + tmpMinimum);
               }
               else if(hsbColor.Hue <= (double)2/3)
               {
                    tmpColorR = tmpMinimum;
                    tmpColorG = HuiruiSoft.Drawing.ColorTranslator.Round(-((hsbColor.Hue - 0.5) * tmpMargin) * 1530 + tmpMaximum);
                    tmpColorB = tmpMaximum;
               }
               else if(hsbColor.Hue <= (double)5/6)
               {
                    tmpColorR = HuiruiSoft.Drawing.ColorTranslator.Round(((hsbColor.Hue - (double)2/3) * tmpMargin) * 1530 + tmpMinimum);
                    tmpColorG = tmpMinimum;
                    tmpColorB = tmpMaximum;
               }
               else if(hsbColor.Hue <= 1.0)
               {
                    tmpColorR = tmpMaximum;
                    tmpColorG = tmpMinimum;
                    tmpColorB = HuiruiSoft.Drawing.ColorTranslator.Round(-((hsbColor.Hue - (double)5 / 6) * tmpMargin) * 1530 + tmpMaximum);
               }

               return System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB);
          }


          public static HSLCOLOR RGBToHSL(System.Drawing.Color color)
          {
               var tmpHSBColor = new HSLCOLOR( );

               return tmpHSBColor;
          }

          public static System.Drawing.Color HSLToRGB(HSLCOLOR hslColor)
          {
               int tmpColorR = 0, tmpColorG = 0, tmpColorB = 0;

               return System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB);
          }


          public static YUVCOLOR RGBtoYUV(RGBColor rgbColor)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBtoYUV((System.Drawing.Color)rgbColor);
          }

          public static YUVCOLOR RGBtoYUV(System.Drawing.Color color)
          {
               var tmpYUVColor = new YUVCOLOR( );

               // normalizes red/green/blue values
               double tempColorR = (double)color.R / 255.0;
               double tempColorG = (double)color.G / 255.0;
               double tempColorB = (double)color.B / 255.0;

               // converts
               tmpYUVColor.Y = +0.2990000000000000000 * tempColorR + 0.5870000000000000000 * tempColorG + 0.1140000000000000000 * tempColorB;
               tmpYUVColor.U = -0.1471376975169300226 * tempColorR - 0.2888623024830699774 * tempColorG + 0.4360000000000000000 * tempColorB;
               tmpYUVColor.V = +0.6150000000000000000 * tempColorR - 0.5149857346647646220 * tempColorG - 0.1000142653352353780 * tempColorB;

               return tmpYUVColor;
          }


          public static System.Drawing.Color YUVtoRGB(YUVCOLOR color)
          {
               int tmpRGBColorR = System.Convert.ToInt32((color.Y + 1.1398373983739837400 * color.V) * 255);
               int tmpRGBColorG = System.Convert.ToInt32((color.Y - 0.3946517043589703515 * color.U - 0.5805986066674976801 * color.V) * 255);
               int tmpRGBColorB = System.Convert.ToInt32((color.Y + 2.0321100917431192660 * color.U) * 255);

               return System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, tmpRGBColorB);
          }


          public static CMYKCOLOR RGBToCMYK(HuiruiSoft.Drawing.RGBColor rgbColor)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK((System.Drawing.Color)rgbColor);
          }


          public static CMYKCOLOR RGBToCMYK(System.Drawing.Color color)
          {
               double tmpCMYKColorC = (double)(255 - color.R) / 255;
               double tmpCMYKColorM = (double)(255 - color.G) / 255;
               double tmpCMYKColorY = (double)(255 - color.B) / 255;

               double tempMinimum = (double)System.Math.Min(tmpCMYKColorC, System.Math.Min(tmpCMYKColorM, tmpCMYKColorY));
               if(tempMinimum == 1.0)
               {
                    return new CMYKCOLOR(0, 0, 0, 1);
               }
               else
               {
                    return new CMYKCOLOR((tmpCMYKColorC - tempMinimum) / (1 - tempMinimum), (tmpCMYKColorM - tempMinimum) / (1 - tempMinimum), (tmpCMYKColorY - tempMinimum) / (1 - tempMinimum), tempMinimum);
               }
          }


          public static System.Drawing.Color CMYKToRGB(CMYKCOLOR cmykColor)
          {
               var tmpRGBColorR = System.Convert.ToInt32((1 - cmykColor.Cyan)    * (1 - cmykColor.Black) * 255);
               var tmpRGBColorG = System.Convert.ToInt32((1 - cmykColor.Magenta) * (1 - cmykColor.Black) * 255);
               var tmpRGBColorB = System.Convert.ToInt32((1 - cmykColor.Yellow)  * (1 - cmykColor.Black) * 255);

               return System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, tmpRGBColorB);
          }




          public static System.Drawing.Color FromCIELab(double cIEL, double cIEa, double cIEb)
          {
               const double ref_X = 95.044998168945313;
               const double ref_Y = 100.000;
               const double ref_Z = 108.89199829101562;

               double var_Y   = (cIEL + 16.0) / 116.0;
               double var_X   = cIEa / 500.0 + var_Y;
               double var_Z   = var_Y - cIEb / 200.0;

               double tmpVarY = System.Math.Pow(var_Y, 3);
               double tmpVarX = System.Math.Pow(var_X, 3);
               double tmpVarZ = System.Math.Pow(var_Z, 3);
               var_Y = (tmpVarY > 0.008856) ? tmpVarY : (var_Y - (double)16/116) / 7.787;
               var_X = (tmpVarX > 0.008856) ? tmpVarX : (var_X - (double)16/116) / 7.787;
               var_Z = (tmpVarZ > 0.008856) ? tmpVarZ : (var_Z - (double)16/116) / 7.787;

               var_X = ref_X * var_X / 100;        //ref_X =  95.047  Observer= 2°, Illuminant= D65
               var_Y = ref_Y * var_Y / 100;        //ref_Y = 100.000
               var_Z = ref_Z * var_Z / 100;        //ref_Z = 108.883

               double var_R = var_X * +3.2406 + var_Y * -1.5372 + var_Z * -0.4986;
               double var_G = var_X * -0.9689 + var_Y * +1.8758 + var_Z * +0.0415;
               double var_B = var_X * +0.0557 + var_Y * -0.2040 + var_Z * +1.0570;

               var_R = (var_R <= 0.0031308) ? 12.92 * var_R : 1.055 * (System.Math.Pow(var_R, 0.4166666667) - 0.055);
               var_G = (var_G <= 0.0031308) ? 12.92 * var_G : 1.055 * (System.Math.Pow(var_G, 0.4166666667) - 0.055);
               var_B = (var_B <= 0.0031308) ? 12.92 * var_B : 1.055 * (System.Math.Pow(var_B, 0.4166666667) - 0.055);

               int tmpColorR = (int)(var_R * 255), tmpColorG = (int)(var_G * 255), tmpColorB = (int)(var_B * 255);

               if(tmpColorR < 0)   tmpColorR = 0;
               if(tmpColorG < 0)   tmpColorG = 0;
               if(tmpColorB < 0)   tmpColorB = 0;
               if(tmpColorR > 255) tmpColorR = 255;
               if(tmpColorG > 255) tmpColorG = 255;
               if(tmpColorB > 255) tmpColorB = 255;

               return (System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB));
          }

          public static System.Drawing.Color CIELabToColor(CIELabColor labColor)
          {
               const double ref_X = 95.044998168945313;
               const double ref_Y = 100.000;
               const double ref_Z = 108.89199829101562;

               double var_Y   = (labColor.L + 16.0) / 116.0;
               double var_X   = labColor.A / 500.0 + var_Y;
               double var_Z   = var_Y - labColor.B / 200.0;

               double tmpVarY = System.Math.Pow(var_Y, 3);
               double tmpVarX = System.Math.Pow(var_X, 3);
               double tmpVarZ = System.Math.Pow(var_Z, 3);
               var_Y = (tmpVarY > 0.008856) ? tmpVarY : (var_Y - (double)16/116) / 7.787;
               var_X = (tmpVarX > 0.008856) ? tmpVarX : (var_X - (double)16/116) / 7.787;
               var_Z = (tmpVarZ > 0.008856) ? tmpVarZ : (var_Z - (double)16/116) / 7.787;

               var_X = ref_X * var_X / 100;        //ref_X =  95.047  Observer= 2°, Illuminant= D65
               var_Y = ref_Y * var_Y / 100;        //ref_Y = 100.000
               var_Z = ref_Z * var_Z / 100;        //ref_Z = 108.883

               double var_R = var_X * +3.2406 + var_Y * -1.5372 + var_Z * -0.4986;
               double var_G = var_X * -0.9689 + var_Y * +1.8758 + var_Z * +0.0415;
               double var_B = var_X * +0.0557 + var_Y * -0.2040 + var_Z * +1.0570;

               var_R = (var_R <= 0.0031308) ? 12.92 * var_R : 1.055 * (System.Math.Pow(var_R, 0.4166666667) - 0.055);
               var_G = (var_G <= 0.0031308) ? 12.92 * var_G : 1.055 * (System.Math.Pow(var_G, 0.4166666667) - 0.055);
               var_B = (var_B <= 0.0031308) ? 12.92 * var_B : 1.055 * (System.Math.Pow(var_B, 0.4166666667) - 0.055);

               int tmpColorR = (int)(var_R * 255), tmpColorG = (int)(var_G * 255), tmpColorB = (int)(var_B * 255);

               if(tmpColorR < 0)   tmpColorR = 0;
               if(tmpColorG < 0)   tmpColorG = 0;
               if(tmpColorB < 0)   tmpColorB = 0;
               if(tmpColorR > 255) tmpColorR = 255;
               if(tmpColorG > 255) tmpColorG = 255;
               if(tmpColorB > 255) tmpColorB = 255;

               return (System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB));
          }

          public static CIELabColor RGBToCIELab(System.Drawing.Color color)
          {
               const double ref_X = 95.044998168945313;
               const double ref_Y = 100.000;
               const double ref_Z = 108.89199829101562;

               var tmpLabColor = new CIELabColor( );

               var tmpColorR = (double)color.R/255;
               var tmpColorG = (double)color.G/255;
               var tmpColorB = (double)color.B/255;

               tmpColorR = (tmpColorR <= 0.04045) ? tmpColorR/12.92 : System.Math.Pow((tmpColorR + 0.055)/1.055, 2.4);
               tmpColorG = (tmpColorG <= 0.04045) ? tmpColorG/12.92 : System.Math.Pow((tmpColorG + 0.055)/1.055, 2.4);
               tmpColorB = (tmpColorB <= 0.04045) ? tmpColorB/12.92 : System.Math.Pow((tmpColorB + 0.055)/1.055, 2.4);

               tmpColorR *= 100;
               tmpColorG *= 100;
               tmpColorB *= 100;

               var tmpColorX = (tmpColorR * 0.4124240 + tmpColorG * 0.357579 + tmpColorB * 0.1804640) / ref_X; //Observer = 2°, Illuminant = D65
               var tmpColorY = (tmpColorR * 0.2126560 + tmpColorG * 0.715158 + tmpColorB * 0.0721856) / ref_Y;
               var tmpColorZ = (tmpColorR * 0.0193324 + tmpColorG * 0.119193 + tmpColorB * 0.9504440) / ref_Z;

               tmpColorX = (tmpColorX > 0.008856) ? System.Math.Pow(tmpColorX, (double)1/3) : 7.787 * tmpColorX + (double)16/116;
               tmpColorY = (tmpColorY > 0.008856) ? System.Math.Pow(tmpColorY, (double)1/3) : 7.787 * tmpColorY + (double)16/116;
               tmpColorZ = (tmpColorZ > 0.008856) ? System.Math.Pow(tmpColorZ, (double)1/3) : 7.787 * tmpColorZ + (double)16/116;

               tmpLabColor.L = (int)(tmpColorY * 116.0 - 16);
               tmpLabColor.A = (int)((tmpColorX - tmpColorY) * 500.0);
               tmpLabColor.B = (int)((tmpColorY - tmpColorZ) * 200.0);

               return tmpLabColor;
          }

          internal static int Round(double value)
          {
               int tmpRoundValue = (int)value;

               if((int)(value * 100) % 100 >= 50)
               {
                    tmpRoundValue += 1;
               }

               return tmpRoundValue;
          }

          internal static int CheckColor(int number)
          {
               return HuiruiSoft.Drawing.ColorTranslator.GetBetween(number, 0, 255);
          }

          internal static double CheckColor(double number)
          {
               return HuiruiSoft.Drawing.ColorTranslator.GetBetween(number, 0, 1);
          }

          internal static int GetBetween(int number, int minimum, int maximum)
          {
               return System.Math.Max(System.Math.Min(number, maximum), minimum);
          }

          internal static double GetBetween(double value, double minimum, double maximum)
          {
               return System.Math.Max(System.Math.Min(value, maximum), minimum);
          }
	}
}