using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.UI
{
    public partial class CloseButton : Button
    {
        public CloseButton()
        {
            InitializeComponent();
            TabStop = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Red;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Font stringFont = new Font("Arial", Font.Size, FontStyle.Bold);
            SizeF stringSize = pe.Graphics.MeasureString("x", stringFont);
            pe.Graphics.DrawString("x", stringFont, Brushes.White, new PointF((Width/2 - stringSize.Width/2), -2));
        }
    }
}
