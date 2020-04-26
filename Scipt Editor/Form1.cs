using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scipt_Editor.Editor;
using Scipt_Editor.UI;

namespace Scipt_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EditorManager.Instance.TabControl = tabControl1;
            fontSelector.Items.AddRange(new object[] { "Arial", "Calibri", "Times New Roman", "Consolas", "Monotype" });
            fontSelector.SelectedIndex = 0;
            fontSizeSelector.Items.AddRange(new object[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36 });
            fontSizeSelector.SelectedIndex = 0;

            tabControl1.Selected += TabControl1OnSelected;
            tabControl1.ControlAdded += TabControl1OnControlAdded;
            fontSizeSelector.SelectedIndexChanged += FontSizeSelectorOnSelectedIndexChanged;
            fontSelector.SelectedIndexChanged += FontSelectorOnSelectedIndexChanged;
        }

        private void FontSelectorOnSelectedIndexChanged(object sender, EventArgs e)
        {
            EditorManager.Instance.UpdateFont(fontSelector.SelectedText, (int)fontSizeSelector.SelectedItem);
        }

        private void FontSizeSelectorOnSelectedIndexChanged(object sender, EventArgs e)
        {
            EditorManager.Instance.UpdateFont(fontSelector.SelectedText, (int) fontSizeSelector.SelectedItem);
        }

        private void TabControl1OnControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is DocumentTabPage tab && EditorManager.Instance.CurrentDocument == null)
            {
                EditorManager.Instance.CurrentDocument = tab.Document;
            }
        }

        private void TabControl1OnSelected(object sender, TabControlEventArgs e)
        {
            EditorManager.Instance.CurrentDocument = ((DocumentTabPage) e.TabPage).Document;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.CreateNewDocument();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.OpenDocument();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((DocumentTabPage) tabControl1.SelectedTab)?.Document?.Save();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
             EditorManager.Instance.OpenDocument();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            ((DocumentTabPage)tabControl1.SelectedTab)?.Document?.Save();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.SaveAs();
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.SaveAs();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            Shortcuts.HandleShortcut(e.KeyData);
        }


        private void newFileButton_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.CreateNewDocument();
        }

        ~Form1()
        {
            tabControl1.Selected -= TabControl1OnSelected;
            tabControl1.ControlAdded -= TabControl1OnControlAdded;
            fontSizeSelector.SelectedIndexChanged -= FontSizeSelectorOnSelectedIndexChanged;
            fontSelector.SelectedIndexChanged -= FontSelectorOnSelectedIndexChanged;
        }
    }
}
