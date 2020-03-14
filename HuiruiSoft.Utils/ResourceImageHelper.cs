
using System.Drawing;
using System.Windows.Forms;

namespace HuiruiSoft.Utils
{
     public static class ResourceStreamHelper
     {
          public static System.IO.Stream GetStream(string name, System.Type type)
          {
               return GetStream(GetResourceName(type, name), type.Assembly);
          }

          public static System.IO.Stream GetStream(string name, System.Reflection.Assembly assembly)
          {
               return assembly.GetManifestResourceStream(name);
          }

          public static string GetResourceName(System.Type baseType, string name)
          {
               return string.Format("{0}.{1}", baseType.Namespace, name);
          }

          public static byte[] GetBytes(string name, System.Reflection.Assembly assembly)
          {
               using (var stream = GetStream(name, assembly))
               {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    return bytes;
               }
          }
     }


     public static partial class ResourceImageHelper
     {
          public static Cursor CreateCursorFromResource(string name, System.Reflection.Assembly assembly)
          {
               var tmpResourceStream = assembly.GetManifestResourceStream(name);
               return new Cursor(tmpResourceStream);
          }

          public static ImageList CreateImageListFromResource(string name, System.Reflection.Assembly assembly, Size size)
          {
               return CreateImageListFromResource(name, assembly, size, Color.Magenta);
          }

          public static ImageList CreateImageListFromResource(string name, System.Reflection.Assembly assembly, Size size, Color transparent)
          {
               return CreateImageListFromResource(name, assembly, size, transparent, ColorDepth.Depth8Bit);
          }

          public static ImageList CreateImageListFromResource(string name, System.Reflection.Assembly assembly, Size size, Color transparent, ColorDepth depth)
          {
               if (transparent == Color.Empty)
               {
                    transparent = Color.Magenta;
               }

               var images = new ImageList();
               images.ColorDepth = depth;
               images.ImageSize = size.IsEmpty ? new Size(16, 16) : size;

               FillImageListFromResource(images, name, assembly, transparent);

               return images;
          }

          public static void FillImageListFromResource(ImageList images, string name, System.Type type)
          {
               FillImageListFromResource(images, ResourceStreamHelper.GetResourceName(type, name), type.Assembly);
          }

          public static void FillImageListFromResource(ImageList images, string name, System.Reflection.Assembly assembly)
          {
               FillImageListFromResource(images, name, assembly, images.TransparentColor);
          }

          public static void FillImageListFromResource(ImageList images, string name, System.Reflection.Assembly assembly, Color transparent)
          {
               var image = CreateBitmapFromResource(name, assembly);
               image.MakeTransparent(transparent);
               images.Images.AddStrip(image);
          }

          public static Bitmap CreateBitmapFromResource(string name, System.Type type)
          {
               return CreateBitmapFromResource(ResourceStreamHelper.GetResourceName(type, name), type.Assembly);
          }

          public static Bitmap CreateBitmapFromResource(string name, System.Reflection.Assembly assembly)
          {
               var image = CreateImageFromResource(name, assembly);
               return image == null ? null : (Bitmap)image;
          }

          public static Icon CreateIconFromResource(string name, System.Type type)
          {
               return CreateIconFromResource(ResourceStreamHelper.GetResourceName(type, name), type.Assembly);
          }

          public static Icon CreateIconFromResource(string name, System.Reflection.Assembly assembly)
          {
               var tmpResourceStream = assembly.GetManifestResourceStream(name);
               return tmpResourceStream == null ? null : new Icon(tmpResourceStream);
          }

          public static Icon CreateIconFromResourceEx(string name, System.Reflection.Assembly assembly)
          {
               var tmpResourceStream = FindResourceStream(name, assembly);
               return tmpResourceStream == null ? null : new Icon(tmpResourceStream);
          }

          public static Image CreateImageFromResource(string name, System.Type type)
          {
               return CreateImageFromResource(ResourceStreamHelper.GetResourceName(type, name), type.Assembly);
          }

          public static Image CreateImageFromResource(string name, System.Reflection.Assembly assembly)
          {
               var tmpResourceStream = assembly.GetManifestResourceStream(name);
               return tmpResourceStream == null ? null : Image.FromStream(tmpResourceStream);
          }

          public static Image CreateImageFromResourceEx(string name, System.Reflection.Assembly assembly)
          {
               var tmpResourceStream = FindResourceStream(name, assembly);
               return tmpResourceStream == null ? null : Image.FromStream(tmpResourceStream);
          }

          public static System.IO.Stream FindResourceStream(string name, System.Reflection.Assembly assembly)
          {
               return assembly.GetManifestResourceStream(FindResourceName(name, assembly));
          }

          public static string FindResourceName(string name, System.Reflection.Assembly assembly)
          {
               string[] tmpResourceNames = assembly.GetManifestResourceNames();
               if (System.Array.IndexOf(tmpResourceNames, name) >= 0)
               {
                    return name;
               }

               string[] tmpNameParts = name.Split('.');
               if (tmpNameParts.Length < 2)
               {
                    return null;
               }

               var tmpResourceName = tmpNameParts.GetValue(tmpNameParts.Length - 2) + "." + tmpNameParts.GetValue(tmpNameParts.Length - 1);
               return System.Array.IndexOf(tmpResourceNames, tmpResourceName) < 0 ? null : tmpResourceName;
          }
     }
}