using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Awesomium.Core;

namespace awesomium.ui
{
    public partial class FormBase : Form
    {
        private Awesomium.Core.JSObject _jsObject;
        protected bool UseLocalHtml = true;

        protected bool WebReady = false;

        protected Point RestoreLocation;
        protected Size RestoreSize;


        //ContextMenu _trayMenu = new ContextMenu();
        //NotifyIcon _trayIcon = new NotifyIcon();

        public FormBase()
        {
            // (CA) - for some reason i can not get the OnPaint to fire without added something that has a special draw routine.. ie a transparent panel;
            Panel p = new Panel();
            p.Width =p.Height = 1;
            p.BackColor = Color.FromArgb(0, Color.Black);
            this.Controls.Add(p);

            p.Focus();           
            InitializeComponent();
            
            //Set control styles to eliminate flicker on redraw and to redraw on resize
            this.SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer,
                true);            
        }

        
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_RESTORE = 0xF120;

            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_RESTORE)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Width = RestoreSize.Width;
                    this.Height = RestoreSize.Height;
                    this.Location = new Point(0, 0);
                    this.ResumeLayout();
                }));
                //this.DesktopBounds = new Rectangle(RestoreLocation, RestoreSize);
            //    this.Location = RestoreLocation;
           //     this.Size = RestoreSize;
            //    this.WindowState = FormWindowState.Normal;
              //  this.Show();
            }
            // this is not working... I think since this is a borderless window.. we do not receive these events.
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
            }

            base.WndProc(ref m);
        }

        protected void TopBarColor(Color color)
        {
            awesomium.TopBar.BackgroundImage = null;
            awesomium.TopBar.BackColor = color;
        }    

        protected void HookMouseResize()
        {
            try
            {
                string isDragResize = string.Empty;
                MouseHook.Start();
                int w = this.Width;
                int h = this.Height;
                int x = this.Location.X;
                MouseHook.MouseMove += (ss, ee) =>
                {
                    if (!string.IsNullOrEmpty(isDragResize))
                    {
                        MouseLocEventArgs ma = ee as MouseLocEventArgs;
                        if (ma != null)
                        {
                            if (isDragResize.Contains('e'))
                            {
                                w = ma.X - this.Location.X;
                            }
                            else if (isDragResize.Contains('w'))
                            {
                                x = ma.X;
                                w = this.Width + (this.Location.X - x);
                            }
                            if (isDragResize.Contains('s'))
                            {
                                h = ma.Y - this.Location.Y;
                            }                            
                        }

                    }

                };
                MouseHook.MouseLeftDown += (ss, ee) =>
                {
                    if (string.IsNullOrEmpty(isDragResize))
                    {
                        MouseLocEventArgs ma = ee as MouseLocEventArgs;
                        if (ma != null)
                        {
                            w = this.Width;
                            h = this.Height;
                            x = this.Location.X;
                            isDragResize = string.Empty;
                            if (Math.Abs(ma.X - (this.Location.X + this.Width)) < 10)
                            {
                          //      this.SuspendLayout();
                                isDragResize += "e";
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.PanWest;
                            }
                            else if (Math.Abs(ma.X - (this.Location.X)) < 10)
                            {
                           //     this.SuspendLayout();
                                isDragResize += "w";
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.PanWest;
                            }
                            if (Math.Abs(ma.Y - (this.Location.Y + this.Height)) < 10)
                            {
                          //      this.SuspendLayout();
                                isDragResize += "s";
                            }
                        }
                    }
                };
                MouseHook.MouseLeftUp += (ss, ee) =>
                {
                    if (!string.IsNullOrEmpty(isDragResize))
                    {
                        this.Location = new Point(x, this.Location.Y);
                        this.Size = new Size(w, h);
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    }
                    isDragResize = string.Empty;
                    
                };

            }
            catch
            {   // unable to get mouse hook... no window resize
                //_man.LogWarn("Could not get low level mouse hook.  Window will not be resizeable");
            }
        }


        public bool ShowMin { get { return awesomium.MinButton.Visible; } set { awesomium.MinButton.Visible = value; } }
        public bool ShowMax { get { return awesomium.MaxButton.Visible; } set { awesomium.MaxButton.Visible = value; } }

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
                            new System.Drawing.Drawing2D.GraphicsPath();

            // Set a new rectangle to the same size as the button's  
            // ClientRectangle property.
            System.Drawing.Rectangle newRectangle = this.ClientRectangle;

            // Increase the size of the rectangle to include the border.
            newRectangle.Inflate(1, 1);            
            // Set the button's Region property to the newly created 
            // circle region.
            this.Region = new System.Drawing.Region(awesomium.CreateRoundRect(newRectangle, 10, AwesomiumBase.RectangleCorners.All));
            base.OnPaint(e);
        }              

        private void OnJsCall(object sender, JavascriptMethodEventArgs args)
        {   // call is a generic function handeling routine ...
            // the first argument is going to be the name of the function to call.. all other args are simple string args to that function
            string methodName = args.Arguments[0];
            MethodInfo mi = this.GetType().GetMethods().FirstOrDefault(m => m.Name == methodName);
            if (mi != null)
            {
                string[] margs = args.Arguments.Skip(1).Select( v => v.ToString() ).ToArray();
                mi.Invoke(this, margs);
            }          
        }

        protected Awesomium.Core.JSObject JSObject { get { return _jsObject; } }
        protected Awesomium.Windows.Forms.WebControl WebBrowser { get { return awesomium.WebBrowser; } }

        public event EventHandler OnCloseButtonClick = null;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            
            RestoreLocation = this.Location;
            RestoreSize = this.Size;
            awesomium.OnClose += (ss, ee) =>
            {
                if (OnCloseButtonClick != null)
                {
                    this.OnCloseButtonClick(ss, ee);
                }
            };
            awesomium.OnMax += (ss, ee) =>
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    if (this.Size != this.MaximumSize)
                    {
                        RestoreLocation = this.Location;
                        RestoreSize = this.Size;
                        Screen s = Screen.FromControl(this);
                        this.Size = new Size(s.Bounds.Width,s.Bounds.Height);
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
                else
                {
                    // restore location and size of the form on the desktop
                    this.DesktopBounds = new Rectangle(RestoreLocation,RestoreSize);                    
                    // restore form's window state
                    this.WindowState = FormWindowState.Normal;
                }
            };
            awesomium.OnMin += (ss, ee) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    RestoreLocation = this.Location;
                    RestoreSize = this.Size;
                    this.WindowState = FormWindowState.Minimized;
                }));             
            };
            _jsObject = awesomium.WebBrowser.CreateGlobalJavascriptObject("ScriptInterface");
            // setup some javascript callbacks
            _jsObject.Bind("call", false, OnJsCall);          
            if (UseLocalHtml)
            {
                string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string url = assemblyPath + Path.DirectorySeparatorChar + ".appui/" + this.GetType().Name.ToLower() + ".html";
                if (File.Exists(url))
                {
                    awesomium.WebBrowser.Source = new Uri(url);
                }
            }
            
            
        }

        protected void RemoveAddWebBrowser()
        {
            this.awesomium.Controls.Remove(this.awesomium.WebBrowser);
            Panel p = new Panel();
            p.Controls.Add(this.awesomium.WebBrowser);
            this.awesomium.Controls.Add(p);
        }


        protected Uri GetAppUiUrl(string htmlFile)
        {
            if (UseLocalHtml)
            {
                string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                 string url = assemblyPath + Path.DirectorySeparatorChar + ".appui/" + htmlFile + ".html";
                 return new Uri(url);
            }
            return null;
        }

        public void JSCopyToClipboard(string toCopy)
        {
            System.Windows.Forms.Clipboard.SetText(toCopy);
        }

        public void JSLoad()
        {
            WebReady = true;
        }

        public void JSOpenFileDialog(string location)
        {
            //if (this.OnOpenFileDialog != null)
            //{
            //    this.OnOpenFileDialog(this, new FileEventArgs() { Filename = location });
            //}
        }

        public void JSOpenUrl(string url)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = url;
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.RedirectStandardOutput = false;
            myProcess.Start();
            myProcess.Dispose();
        }        


        // Override Window.OnClosed.
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Dispose the WebControl.
            WebBrowser.Dispose();

            // This was the only Window in our app.
            // Shutdown the WebCore while exiting.            
            //Awesomium.Core.WebCore.Shutdown();
        }


        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (OnCloseButtonClick != null)
            {
                this.OnCloseButtonClick(sender, e);
            }
        }
    }
}
