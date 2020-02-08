using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.UI
{
    class TabPageClosable : TabPage
    {
        public Document Document { get; set; }

        public TabPageClosable(string text, Document document) : base(text)
        {
            Document = document;
        }

        public TabPageClosable(string text) : base(text)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString("x", Font, Brushes.Black, new PointF(e.ClipRectangle.Right - 5, Location.Y));
        }
    }
}
