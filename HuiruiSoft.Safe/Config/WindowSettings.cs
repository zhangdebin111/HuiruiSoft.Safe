namespace HuiruiSoft.Safe.Configuration
{
     public sealed class WindowSettings
     {
          public int X
          {
               get; set;
          }


          public int Y
          {
               get; set;
          }


          public int Width { get; set; } = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * 85 / 100;


          public int Height { get; set; } = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * 85 / 100;

          public decimal SplitPosition { get; set; } = 15;

          [System.Xml.Serialization.XmlElement()]
          public bool TopMost
          {
               get; set;
          }


          [System.Xml.Serialization.XmlElement()]
          public bool Minimized
          {
               get; set;
          }


          [System.Xml.Serialization.XmlElement()]
          public bool Maximized
          {
               get; set;
          }

          [System.Xml.Serialization.XmlElement()]
          public bool ActionTraySingleClick { get; set; } = false;

          [System.Xml.Serialization.XmlElement()]
          public bool MinimizeWindowToTray { get; set; } = false;

          [System.Xml.Serialization.XmlElement()]
          public bool MinimizeAtCloseButton { get; set; } = false;
     }
}