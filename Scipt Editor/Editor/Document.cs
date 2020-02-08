using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Scipt_Editor.Exceptions;
using Scipt_Editor.Extensions;
using Scipt_Editor.UI;

namespace Scipt_Editor
{
    enum DocumentState
    {
        Modified,
        Latest
    }

    class Document
    {
        private string _extension;
        private string _name;
        private string _filePath;
        private DocumentState _state = DocumentState.Latest;
        private readonly TabPageClosable _tab;
        private readonly RichTextBox _txtBox;

        public string Extension => _extension;
        public string Name => _name;

        public string FilePath
        {
            get => _filePath;
            set
            {

                var ext = Path.GetExtension(value);

                //TODO might need to seperate extensions
                if (ext.IsNullOrEmpty())
                {
                    throw new ExtensionNotSupportedException("Extension cannot be empty.");
                }

                if (!Configs.SupportedExtensions.Contains(ext))
                {
                    throw new ExtensionNotSupportedException($"{ext} Extension not supported!");
                }

                _filePath = value;
                _name = Path.GetFileName(value);
                _extension = ext;

                if (_txtBox.Text.IsNullOrEmpty() || !FilePath.IsNullOrEmpty())
                {
                    Open();
                }
            }
        }

        public DocumentState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    Console.WriteLine(_tab.Text);
                    _state = value;

                    if (_state == DocumentState.Latest)
                    {
                        _tab.Text = _tab.Text.Remove(_tab.Text.Length - 1, 1);
                    }
                    else
                    {
                        _tab.Text += "*";
                    }
                }
            }
        }

        public Document(TabPageClosable tab)
        {
            _tab = tab;
            _tab.Document = this;
            _txtBox = tab.Controls[0] as RichTextBox;
            _txtBox.TextChanged += OnContentChanged;

            Debug.Assert(_txtBox != null);
        }

        public Document(TabPageClosable tab, string path) : this(tab)
        {
            FilePath = path;
        }

        private void OnContentChanged(object sender, EventArgs e)
        {
            State = DocumentState.Modified;
        }

        public void Save()
        {
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, _txtBox.Text); 
                State = DocumentState.Latest;
            }
        }

        public void SaveAs()
        {
            using (var stream = File.Create(FilePath))
            {
                var fStream = new StreamWriter(stream);
                fStream.WriteLine(_txtBox.Text);
            }

            State = DocumentState.Latest;
        }

        public void SetActive()
        {
            ((TabControl) _tab.Parent).SelectedTab = _tab;
        }

        private void Open()
        {
            if (File.Exists(FilePath))
            {
                _txtBox.Text = File.ReadAllText(FilePath);
            }
        }
    }
}
