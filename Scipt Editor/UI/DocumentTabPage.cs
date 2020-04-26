using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.UI
{
    public partial class DocumentTabPage : TabPage
    {
        public DocumentTabPage(string text, Document document) : base(text)
        {
        }

        public DocumentTabPage(string text) : base(text)
        {
            InitializeComponent();
        }

        public Document Document
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}
