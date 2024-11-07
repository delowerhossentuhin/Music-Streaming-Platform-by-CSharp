using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace ProjectSpotify_CLONE
{

    public class CircularPanel : Panel
    {
        private Color borderColor = Color.Black; // Default border color
        public int DisplayNumber { get; set; } = 0; // Default digit to display

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate(); // Refresh the control to update the border color
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the circular border
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawEllipse(pen, 1, 1, this.Width - 3, this.Height - 3);
            }

            // Draw the digit inside
            using (Font font = new Font("Arial", 16, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                string text = DisplayNumber.ToString();
                SizeF textSize = e.Graphics.MeasureString(text, font);
                e.Graphics.DrawString(
                    text,
                    font,
                    brush,
                    (this.Width - textSize.Width) / 2,
                    (this.Height - textSize.Height) / 2
                );
            }
        }

        // Override the OnResize method to make the panel circular
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Width = this.Height; // Keep the width and height equal to maintain a circle
        }
    }

}
