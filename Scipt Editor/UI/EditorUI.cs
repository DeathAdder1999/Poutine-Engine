using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.UI
{
    public enum DocumentState
    {
        Modified,
        Latest
    }

    public partial class EditorUI : UserControl
    {
        private DocumentState _state = DocumentState.Latest;
        public event EventHandler StateChanged;

        public EditorUI()
        {
            InitializeComponent();
        }

        private DocumentState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;

                    if (_state == DocumentState.Modified)
                    {
                        OnStateChanged(new EventArgs());
                    }
                }
            }
        }

        protected virtual void OnStateChanged(EventArgs e)
        {
            EventHandler handler = StateChanged;
            handler?.Invoke(this, e);
        }
    }
}
