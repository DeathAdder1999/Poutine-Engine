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

            tabControl1.Selected += TabControl1OnSelected;
            tabControl1.ControlAdded += TabControl1OnControlAdded;
        }

        private void TabControl1OnControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is TabPageClosable tab && EditorManager.Instance.CurrentDocument == null)
            {
                Editor.EditorManager.Instance.CurrentDocument = tab.Document;
            }
        }

        private void TabControl1OnSelected(object sender, TabControlEventArgs e)
        {
            EditorManager.Instance.CurrentDocument = ((TabPageClosable) e.TabPage).Document;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tabPage = new TabPageClosable("Untitled");
            
            EditorManager.Instance.CreateNewDocument(tabPage);

            tabControl1.Controls.Add(tabPage);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Add(EditorManager.Instance.OpenDocument());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((TabPageClosable) tabControl1.SelectedTab)?.Document?.Save();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            var doc = EditorManager.Instance.OpenDocument();

            if (doc != null)
            {
                tabControl1.Controls.Add(EditorManager.Instance.OpenDocument());
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            ((TabPageClosable)tabControl1.SelectedTab)?.Document?.Save();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.SaveAs();
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditorManager.Instance.SaveAs();
        }
    }
}
