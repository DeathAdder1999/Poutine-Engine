using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scipt_Editor.UI
{
    // Reference: https://www.codeguru.com/csharp/.net/net_asp/controls/adding-close-buttons-to-tab-pages-with-.net.html
    public partial class TabControlClosable : TabControl
    {
        private Dictionary<Button, TabPage> dicButtons = new Dictionary<Button, TabPage>();
        private bool blnShow = true;

        public event CancelEventHandler CloseClick;

        public TabControlClosable()
        {
            InitializeComponent();
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Padding = new Point(13, 0);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Rectangle r = GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            string title = TabPages[e.Index].Text;
            e.Graphics.DrawString(title, Font, TitleBrush, new PointF(r.X, r.Y));
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Show / Hide Close Button(s)")]
        public new bool Show
        {
            get
            {
                return blnShow;
            }

            set
            {
                blnShow = value;
                foreach (var btn in dicButtons.Keys)
                {
                    btn.Visible = blnShow;
                }
                Repos();
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            TabPage tpCurrent = (TabPage)e.Control;

            Rectangle rtCurrent = GetTabRect(TabPages.IndexOf(tpCurrent));

            CloseButton closeBtn = new CloseButton();
            closeBtn.Size = new Size(rtCurrent.Height - 5, rtCurrent.Height - 5);
            closeBtn.Location = new Point(rtCurrent.X + rtCurrent.Width - rtCurrent.Height + 1, rtCurrent.Y + 3);

            SetParent(closeBtn.Handle, this.Handle);

            closeBtn.Click += OnCloseClick;

            dicButtons.Add(closeBtn, tpCurrent);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Repos();
        }

        protected override void OnLayout(LayoutEventArgs lea)
        {
            base.OnLayout(lea);
            Repos();
        }

        protected virtual void OnCloseClick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Button btnClose = (Button)sender;
                TabPage tpCurrent = dicButtons[btnClose];

                CancelEventArgs cea = new CancelEventArgs();

                CloseClick?.Invoke(sender, cea);

                if (!cea.Cancel)
                {
                    if (TabPages.Count > 1)
                    {
                        TabPages.Remove(tpCurrent);

                        btnClose.Dispose();
                        Repos();
                    }
                    else
                    {
                        MessageBox.Show("Must Have At Least 1 Tab Page");
                    }
                }
            }
        }

        public void Repos()
        {
            foreach (var but in dicButtons)
            {
                Repos(but.Value);
            }
        }

        public void Repos(TabPage tpCurrent)
        {

            Button btnClose = CloseButton(tpCurrent);

            if (btnClose != null)
            {

                int tpIndex = TabPages.IndexOf(tpCurrent);

                if (tpIndex >= 0)
                {
                    Rectangle rctCurrent = GetTabRect(tpIndex);

                    if (SelectedTab == tpCurrent)
                    {
                        btnClose.Size = new Size(rctCurrent.Height - 5, rctCurrent.Height - 5);
                        btnClose.Location = new Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height + 1, rctCurrent.Y + 3);
                    }
                    else
                    {
                        btnClose.Size = new Size(rctCurrent.Height - 5, rctCurrent.Height - 5);
                        btnClose.Location = new Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height + 1, rctCurrent.Y + 3);
                    }

                    btnClose.Visible = Show;
                    btnClose.BringToFront();
                }

            }

        }

        protected Button CloseButton(TabPage tpCurrent)
        {
            return (from item in dicButtons
                    where item.Value == tpCurrent
                    select item.Key).FirstOrDefault();
        }
    }
}
