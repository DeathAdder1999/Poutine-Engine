using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Scipt_Editor.Extensions;
using Scipt_Editor.UI;

namespace Scipt_Editor.Editor
{
    class EditorManager
    {
        public static EditorManager Instance = new EditorManager();

        private readonly List<Document> _openedDocuments = new List<Document>();

        public Document CurrentDocument { get; set; }

        private EditorManager()
        {

        }

        public void CreateNewDocument(TabPageClosable tab)
        {
            tab.Controls.Add(new RichTextBox {Dock = DockStyle.Fill});
            _openedDocuments.Add(new Document(tab));
        }

        public TabPageClosable OpenDocument()
        {
            var dlg = new OpenFileDialog {CheckFileExists = true, Multiselect = false};

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var openedDocument = GetOpenDocument(dlg.FileName);


                if (openedDocument != null)
                {
                    openedDocument.SetActive();
                    return null;
                }

                var tab = new TabPageClosable(Path.GetFileName(dlg.FileName));
                tab.Controls.Add(new RichTextBox {Dock = DockStyle.Fill});

                _openedDocuments.Add(new Document(tab, dlg.FileName));


                return tab;
            }

            return null;
        }


        public void SaveAs()
        {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = ".gs";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentDocument.FilePath = dlg.FileName;
                CurrentDocument.SaveAs();
            }
        }

        private Document GetOpenDocument(string path)
        {
            foreach (var document in _openedDocuments)
            {
                if (!document.FilePath.IsNullOrEmpty() && document.FilePath == path)
                {
                    return document;
                }
            }

            return null;
        }
    }
}
