
using System.Windows.Forms;
using System.ComponentModel;

namespace HuiruiSoft.UI.Controls
{
     [ToolboxItem(false)]
     public class ColorEditTabControlBase : TabControl
     {
          public ColorEditTabControlBase( )
          {
               base.TabStop = false;
               this.TabPages.AddRange(new TabPage[ ] { new TabPage( ), new TabPage( ), new TabPage( ) });
          }

          protected internal virtual void ProcessTabKey(KeyEventArgs args)
          {
               this.OnKeyDown(new KeyEventArgs(args.KeyData | Keys.Control));
          }

          protected internal virtual void SelectPageByCaption(string caption)
          {
               for(int index = 0; index < this.TabPages.Count; index++)
               {
                    if(this.TabPages[index].Text == caption)
                    {
                         this.SelectedTab = this.TabPages[index];
                         return;
                    }
               }
          }
     }
}