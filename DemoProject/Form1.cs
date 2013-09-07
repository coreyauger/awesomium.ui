using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using awesomium.ui;

namespace DemoProject
{
    public partial class Form1 : FormBase
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;           // assign a width
            this.Height = 600;          // assign a height
            base.HookMouseResize();     // allow our 'sketchy' resize function to process. ;)

            // Add close event handler...
            base.OnCloseButtonClick += (ss, ee) =>
            {
                this.Close();
            };            
        }

        public void JSOpenNotepad(string args)
        {
            Process.Start("notepad.exe");
            base.WebBrowser.ExecuteJavascript("alert('notepad is open');");
        }
    }
}
