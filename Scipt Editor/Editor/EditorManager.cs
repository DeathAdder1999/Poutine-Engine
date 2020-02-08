using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
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

        public TabControl TabControl { get; set; }

        private EditorManager()
        {
            InitializeShortcuts();
        }

        public void CreateNewDocument()
        {
            var tab = new TabPageClosable("Untitled");
            tab.Controls.Add(new RichTextBox {Dock = DockStyle.Fill});
            _openedDocuments.Add(new Document(tab));
            TabControl.Controls.Add(tab);
        }

        public void OpenDocument()
        {
            var dlg = new OpenFileDialog {CheckFileExists = true, Multiselect = false};

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var openedDocument = GetOpenDocument(dlg.FileName);


                if (openedDocument != null)
                {
                    openedDocument.SetActive();
                    return;
                }

                var tab = new TabPageClosable(Path.GetFileName(dlg.FileName));
                tab.Controls.Add(new RichTextBox {Dock = DockStyle.Fill});

                _openedDocuments.Add(new Document(tab, dlg.FileName));


                TabControl?.Controls.Add(tab);
            }
        }


        public void SaveAs()
        {
            if (CurrentDocument == null)
            {
                return;
            }

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

        public void UpdateFont(string fontName, int size)
        {
            CurrentDocument.Font = new Font(fontName, size);
        }

        private void InitializeShortcuts()
        {
            Shortcuts.AddShortcut(Keys.Control | Keys.S, new Shortcut("Save", () => CurrentDocument?.Save()));
            Shortcuts.AddShortcut(Keys.Control | Keys.O, new Shortcut("Open", OpenDocument));
            Shortcuts.AddShortcut(Keys.Control | Keys.N, new Shortcut("New", CreateNewDocument));
        }
    }
}
