using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    public class CustomeThumbControl : Panel
    {
        Action<object, EventArgs> _clickDeligate;
        PictureBox pict = new PictureBox();
        Label lbl = new Label();
        Panel pnlSpace = new Panel();
        Panel pnlLbl = new Panel();
        public VideoInfo ThumbnailInformation { get; set; }

        public CustomeThumbControl(Action<object, EventArgs> clickDeligate)
        {
            _clickDeligate = clickDeligate;
            pict.Click += Pict_Click;
        }

        public CustomeThumbControl()
        {
        }

        private void Pict_Click(object sender, EventArgs e)
        {
            _clickDeligate(this, e);
        }


        public string ThumbUrl
        {
            get; set;
        }

        public string ThumbName
        {
            get; set;
        }

        public string VideoUrl
        {
            get; set;
        }

        public Int32 LabelWidth
        {
            get; set;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //lbl.Dock = DockStyle.Bottom;
            //lbl.Text = ThumbName;
            ////lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            //lbl.ForeColor = System.Drawing.Color.Red;
            //lbl.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            //lbl.Height = 20;
            //this.Controls.Add(lbl);
            //this.Controls.SetChildIndex(lbl, 1);

            //pnlSpace.Dock = DockStyle.Bottom;
            //pnlSpace.Height = 50;
            //this.Controls.Add(pnlSpace);
            ////this.Controls.SetChildIndex(pnlSpace, 2);


            pict.Dock = DockStyle.Fill;
            if (string.IsNullOrEmpty(ThumbUrl))
            {
                pict.Image = PlayImage;
            }
            else
            {
                pict.Image = new ImageEx(ThumbUrl).Image;
            }
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            //pict.lay = ImageLayout.Zoom;
            //pict.Image = PlayImage;
            this.Controls.Add(pict);
            //this.Controls.SetChildIndex(lbl, 0);

            pnlSpace.Height = 8;
            pnlSpace.Dock = DockStyle.Bottom;
            //this.Controls.Add(pnlSpace);

            lbl.Dock = DockStyle.Bottom;
            lbl.Text = ThumbName;
            //lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            //lbl.Height = 30;
            //lbl.Width = 300;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.MaximumSize = new Size(LabelWidth, 40);
            lbl.MinimumSize = new Size(LabelWidth, 40);
            lbl.Height = 40;
            lbl.AutoSize = true;
            lbl.AutoEllipsis = true;


            pnlLbl.Controls.Add(lbl);
            pnlLbl.AutoSize = true;
            pnlLbl.Dock = DockStyle.Bottom;
            this.Controls.Add(pnlLbl);

            //pict.Dock = DockStyle.Fill;
            //this.Controls.SetChildIndex(lbl, 1);
        }

        private Image PlayImage
        {
            get
            {
                string base64string = "iVBORw0KGgoAAAANSUhEUgAAAJ8AAABxCAYAAADLVXESAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAI2SURBVHhe7d29joxhHIdhx6RxDgqnIM5AnIA4ASqJoKemplZraZWW+FjExyuvjGTIX3Z37M7dXFfySya7M1Pd2Sf7TDHnXp+/sJjte6tzt+/c/fUA9uV3c+Jj78RHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxDc4uHhp+XDv/vL1xcvNTzgL4htsf0POm8tXlo8PHi7fDw42v+W0iG+wHd/23l69tnx+9mz5cfhp80z+h/gGU3h/bz2Wvzx/vnkFuxDfYIrtX3Ms7058gymy42w9lj89eepYPibxDaawTrr3N2/5a3gE8Q2mmE6y9Sh2TXM08Q2moI67w0ePN+/CUcQ3mKI6au+u33DMnpD4BlNc/9r6aYgrl92IbzBFNm29YvGf7e7EN5hC2956pfLt1avNs9mV+AZTcOvWI3a9x+N0iG8whbfe2zliT5f4BtvRubM7O+Ib/A7Pnd3ZEt/And1+iI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPzB/xme17y7IsPwHW/9F1tTVGnQAAAABJRU5ErkJggg==";
                byte[] base64byte = Convert.FromBase64String(base64string);
                MemoryStream base64stream = new MemoryStream(base64byte);
                return Image.FromStream(base64stream);
            }
        }

        public void DisposeChilds()
        {
            this.pict.Click -= Pict_Click;
            if (this.pict.Image != null)
                this.pict.Image.Dispose();
            this.pict.Dispose();
            this.Controls.Clear();
        }

        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //    _clickDeligate(this, e);
        //}

    }

    public class ImageEx
    {
        public Image Image
        {
            get; set;
        }
        public string Filename
        {
            get; set;
        }

        public ImageEx(string filename)
        {
            this.Image = Image.FromFile(filename);
            this.Filename = filename;
        }
    }

}
