using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Common
{
   public class LBFCheckBoxList : CheckedListBox
    {

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            DrawItemEventArgs e2 =
                new DrawItemEventArgs
                (
                    e.Graphics,
                    e.Font,
                    new Rectangle(e.Bounds.Location, e.Bounds.Size),
                    e.Index,
                    e.State,
                    e.ForeColor,
                    this.CheckedIndices.Contains(e.Index) ? Color.FromArgb(236, 50, 55) : SystemColors.Window
                );

            base.OnDrawItem(e2);
        }
    }

}
