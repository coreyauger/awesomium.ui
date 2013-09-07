using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace awesomium.ui
{
    public partial class WebControlBase : UserControl
    {
        public WebControlBase()
        {
            InitializeComponent();
        }

        public EventHandler OnClose;

        public WebBrowser WebBrowser { get { return webBrowser; } }

        private bool CanDrag = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CanDrag = true;
            _startGrabPoint = new Point(e.Location.X, e.Location.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanDrag)
            {

                this.Parent.Location = new Point(Cursor.Position.X - _startGrabPoint.X, Cursor.Position.Y - _startGrabPoint.Y);
                /* // TODO: (CA) - snap to edge of screen like winamp
                Screen scn = Screen.FromPoint(this.Location);
                if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
                if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
                if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
                if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
                 */
                this.Update();
            }
        }

        private const int SnapDist = 100;
        private Point _startGrabPoint = new Point();
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            CanDrag = false;
        }

        private void bTray_Click(object sender, EventArgs e)
        {
            if (this.OnClose != null)
            {
                this.OnClose(sender, e);
            }
        }
    }
}
