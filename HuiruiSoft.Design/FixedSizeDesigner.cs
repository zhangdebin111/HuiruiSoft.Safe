
using System.Windows.Forms.Design;

namespace HuiruiSoft.UI.Controls.Design
{
     internal class FixedSizeDesigner : ControlDesigner
     {
          public override SelectionRules SelectionRules
          {
               get
               {
                    var tmpSelectionRules = SelectionRules.Visible;

                    if(((SelectionRules.None | SelectionRules.Locked) & base.SelectionRules) != SelectionRules.None)
                    {
                         return (tmpSelectionRules | SelectionRules.None | SelectionRules.Locked);
                    }
                    else
                    {
                         return (tmpSelectionRules | SelectionRules.Moveable);
                    }
               }
          }
     }
}