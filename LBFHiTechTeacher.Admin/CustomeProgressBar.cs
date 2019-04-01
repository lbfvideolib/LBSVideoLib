using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Admin
{
    public class CustomeProgressBar : ProgressBar
    {
        private SolidBrush brush = null;

        public CustomeProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // None... Helps control the flicker.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (brush == null || brush.Color != this.ForeColor)
                brush = new SolidBrush(this.ForeColor);

            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}
