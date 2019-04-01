using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    class myButton : Panel
    {
        public string ButtonName { get; set; }

        public myButton()
        {
            this.Size = new Size(200, 200); // this is just to set size to default button size change as needed
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // makes a border around button          
        }
        private Image buttonImage
        {
            get
            {
                string base64string = "iVBORw0KGgoAAAANSUhEUgAAAJ8AAABxCAYAAADLVXESAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAI2SURBVHhe7d29joxhHIdhx6RxDgqnIM5AnIA4ASqJoKemplZraZWW+FjExyuvjGTIX3Z37M7dXFfySya7M1Pd2Sf7TDHnXp+/sJjte6tzt+/c/fUA9uV3c+Jj78RHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxEdGfGTER0Z8ZMRHRnxkxDc4uHhp+XDv/vL1xcvNTzgL4htsf0POm8tXlo8PHi7fDw42v+W0iG+wHd/23l69tnx+9mz5cfhp80z+h/gGU3h/bz2Wvzx/vnkFuxDfYIrtX3Ms7058gymy42w9lj89eepYPibxDaawTrr3N2/5a3gE8Q2mmE6y9Sh2TXM08Q2moI67w0ePN+/CUcQ3mKI6au+u33DMnpD4BlNc/9r6aYgrl92IbzBFNm29YvGf7e7EN5hC2956pfLt1avNs9mV+AZTcOvWI3a9x+N0iG8whbfe2zliT5f4BtvRubM7O+Ib/A7Pnd3ZEt/And1+iI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPjPjIiI+M+MiIj4z4yIiPzB/xme17y7IsPwHW/9F1tTVGnQAAAABJRU5ErkJggg==";
                byte[] base64byte = Convert.FromBase64String(base64string);
                MemoryStream base64stream = new MemoryStream(base64byte);
                return Image.FromStream(base64stream);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            // do mousedown events
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // do mouseup events
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawButtonImage(e);
            DrawButtonText(e);
        }
        private void DrawButtonText(PaintEventArgs e)
        {
            e.Graphics.DrawString(ButtonName, this.Font, Brushes.Black, new PointF(65, 10));
        }
        private void DrawButtonImage(PaintEventArgs e)
        {
            e.Graphics.DrawImage(buttonImage, 0, 0, 200, 200);
        }
    }
}
