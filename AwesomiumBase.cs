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
    public partial class AwesomiumBase : UserControl
    {
        public AwesomiumBase()
        {
            InitializeComponent();
            this.webBrowser.Focus();
        }
       

        public event EventHandler OnClose;
        public event EventHandler OnMax;
        public event EventHandler OnMin;

        public Button MinButton { get { return bMin; } }
        public Button MaxButton { get { return bMax; } }

        public Awesomium.Windows.Forms.WebControl WebBrowser { get { return webBrowser; } }

        private bool CanDrag = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CanDrag = true;
            _startGrabPoint = new Point(e.Location.X, e.Location.Y);
        }

        public enum RectangleCorners
        {
            None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateRoundRect(System.Drawing.Rectangle rect, int radius, RectangleCorners corners)
        {
            return CreateRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius, corners);
        }

        public System.Drawing.Drawing2D.GraphicsPath CreateRoundRect(int x, int y, int width, int height, int radius, RectangleCorners corners)
        {
            int xw = x + width;
            int yh = y + height;
            int xwr = xw - radius;
            int yhr = yh - radius;
            int xr = x + radius;
            int yr = y + radius;
            int r2 = radius * 2;
            int xwr2 = xw - r2;
            int yhr2 = yh - r2;

            System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
            p.StartFigure();

            //Top Left Corner
            if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft)
            {
                p.AddArc(x, y, r2, r2, 180, 90);
            }
            else
            {
                p.AddLine(x, yr, x, y);
                p.AddLine(x, y, xr, y);
            }

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner
            if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }
            else
            {
                p.AddLine(xwr, y, xw, y);
                p.AddLine(xw, y, xw, yr);
            }

            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner
            if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }
            else
            {
                p.AddLine(xw, yhr, xw, yh);
                p.AddLine(xw, yh, xwr, yh);
            }

            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);

            //Bottom Left Corner
            if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }
            else
            {
                p.AddLine(xr, yh, x, yh);
                p.AddLine(x, yh, x, yhr);
            }

            //Left Edge
            p.AddLine(x, yhr, x, yr);

            p.CloseFigure();
            return p;
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

        public Panel TopBar { get { return panel1; } }

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

        private void bMax_Click(object sender, EventArgs e)
        {
            if (this.OnMax != null)
            {
                this.OnMax(sender, e);
            }
        }

        private void bMin_Click(object sender, EventArgs e)
        {
            if (this.OnMin != null)
            {
                this.OnMin(sender, e);
            }
        }
    }
}
