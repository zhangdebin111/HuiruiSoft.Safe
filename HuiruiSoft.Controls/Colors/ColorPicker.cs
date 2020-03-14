
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HuiruiSoft.UI.Controls
{
     public class ColorPicker : System.Windows.Forms.Control
     {
          private const int BorderMargin = 2;
          private Color currentColor = System.Drawing.Color.Empty;
          private Rectangle sketchBounds = System.Drawing.Rectangle.Empty;

          /// <summary>每当此控件的 Color 属性更改时发生。</summary>
          [Browsable(true), Category("数据"), Description("每当此控件的 Color 属性更改时发生。")]
          public event ColorChangedEventHandler ColorChanged;

          /// <summary>返回或设置 Color 值。</summary>
          [Browsable(true), Category("数据"), DefaultValue(typeof(System.Drawing.Color), "White"), Description("返回或设置 Color 值。")]
          public System.Drawing.Color Color
          {
               get
               {
                    return this.currentColor;
               }

               set
               {
                    if (!this.currentColor.Equals(value))
                    {
                         this.currentColor = value;
                         this.RaiseColorChangedEvent();
                         this.Refresh();
                    }
               }
          }

          public ColorPicker()
          {
               base.TabStop = true;

               base.SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.UserMouse |
                    ControlStyles.Selectable |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.DoubleBuffer |
                    ControlStyles.StandardClick |
                    ControlStyles.StandardDoubleClick |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.SupportsTransparentBackColor, true);

               const int MinimumWidth = 20 + 2 * BorderMargin, MinimumHeight = 15 + 2 * BorderMargin;
               this.MinimumSize = new Size(MinimumWidth, MinimumHeight);
          }

          protected override void OnCreateControl()
          {
               base.OnCreateControl();
               this.ReLayoutControls();
          }

          private void RaiseColorChangedEvent()
          {
               this.OnColorChanged(new ColorChangedEventArgs(this.currentColor));
          }

          protected virtual void OnColorChanged(ColorChangedEventArgs args)
          {
               this.ColorChanged?.Invoke(this, args);
          }

          protected override void OnClick(System.EventArgs args)
          {
               base.OnClick(args);

               var tmpColorDialog = new formColorDialog();
               tmpColorDialog.Color = this.currentColor;
               if (tmpColorDialog.ShowDialog() == DialogResult.OK)
               {
                    this.Color = tmpColorDialog.Color;
               }
          }

          protected override void OnSizeChanged(System.EventArgs args)
          {
               base.OnSizeChanged(args);
               this.ReLayoutControls();
          }

          private void ReLayoutControls()
          {
               this.sketchBounds = new System.Drawing.Rectangle(BorderMargin, BorderMargin, this.Size.Width - 2 * BorderMargin, this.Size.Height - 2 * BorderMargin);
               this.Refresh();
          }

          protected override void OnPaint(PaintEventArgs args)
          {
               base.OnPaint(args);

               args.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
               args.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

               using (var tmpDrawPen = new Pen(Color.White))
               {
                    using (var tmpSolidBrush = new SolidBrush(this.currentColor != Color.Empty ? this.currentColor : SystemColors.Control))
                    {
                         Point[] tmpDrawPoints;

                         tmpDrawPoints = new Point[6]
                         {
                              new Point(this.sketchBounds.X     + 3, this.sketchBounds.Y      + 3),
                              new Point(this.sketchBounds.Right - 3, this.sketchBounds.Y      + 3),
                              new Point(this.sketchBounds.Right - 3, this.sketchBounds.Bottom - 7),
                              new Point(this.sketchBounds.Right - 9, this.sketchBounds.Bottom - 7),
                              new Point(this.sketchBounds.Right - 9, this.sketchBounds.Bottom - 3),
                              new Point(this.sketchBounds.X     + 3, this.sketchBounds.Bottom - 3)
                         };
                         args.Graphics.FillPolygon(tmpSolidBrush, tmpDrawPoints);


                         tmpDrawPen.Color = Color.FromArgb(113, 111, 100);
                         tmpDrawPoints = new Point[3]
                         {
                              new Point(this.sketchBounds.X     + 2, this.sketchBounds.Bottom - 4),
                              new Point(this.sketchBounds.X     + 2, this.sketchBounds.Y      + 2),
                              new Point(this.sketchBounds.Right - 3, this.sketchBounds.Y      + 2)
                         };
                         args.Graphics.DrawLines(tmpDrawPen, tmpDrawPoints);

                         tmpDrawPen.Color = Color.White;
                         tmpDrawPoints = new Point[5]
                         {
                              new Point(this.sketchBounds.X     + 2, this.sketchBounds.Bottom - 3),
                              new Point(this.sketchBounds.Right - 9, this.sketchBounds.Bottom - 3),
                              new Point(this.sketchBounds.Right - 9, this.sketchBounds.Bottom - 7),
                              new Point(this.sketchBounds.Right - 3, this.sketchBounds.Bottom - 7),
                              new Point(this.sketchBounds.Right - 3, this.sketchBounds.Y      + 2)
                         };
                         args.Graphics.DrawLines(tmpDrawPen, tmpDrawPoints);

                         tmpDrawPen.Color = SystemColors.WindowText;
                         var tmpPointStart = new Point(this.sketchBounds.Right - 7, this.sketchBounds.Bottom - 5);
                         var tmpPointEndOf = new Point(this.sketchBounds.Right - 3, this.sketchBounds.Bottom - 5);
                         args.Graphics.DrawLine(tmpDrawPen, tmpPointStart, tmpPointEndOf);

                         tmpPointStart.Offset(1, 1);
                         tmpPointEndOf.Offset(-1, 1);
                         args.Graphics.DrawLine(tmpDrawPen, tmpPointStart, tmpPointEndOf);

                         tmpPointStart = new Point(this.sketchBounds.Right - 5, this.sketchBounds.Bottom - 4);
                         tmpPointEndOf = new Point(this.sketchBounds.Right - 5, this.sketchBounds.Bottom - 3);
                         args.Graphics.DrawLine(tmpDrawPen, tmpPointStart, tmpPointEndOf);

                         tmpDrawPen.Color = Color.White;
                         tmpDrawPoints = new Point[3]
                         {
                              new Point(this.sketchBounds.X,         this.sketchBounds.Bottom - 1),
                              new Point(this.sketchBounds.X,         this.sketchBounds.Y),
                              new Point(this.sketchBounds.Right - 1, this.sketchBounds.Y )
                         };
                         args.Graphics.DrawLines(tmpDrawPen, tmpDrawPoints);

                         tmpDrawPen.Color = Color.FromArgb(113, 111, 100);
                         tmpDrawPoints = new Point[3]
                         {
                              new Point(this.sketchBounds.X,         this.sketchBounds.Bottom - 1),
                              new Point(this.sketchBounds.Right - 1, this.sketchBounds.Bottom - 1),
                              new Point(this.sketchBounds.Right - 1, this.sketchBounds.Y )
                         };
                         args.Graphics.DrawLines(tmpDrawPen, tmpDrawPoints);
                    }
               }
          }
     }
}