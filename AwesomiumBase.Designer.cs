namespace awesomium.ui
{
    partial class AwesomiumBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AwesomiumBase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bMin = new System.Windows.Forms.Button();
            this.bMax = new System.Windows.Forms.Button();
            this.bTray = new System.Windows.Forms.Button();
            this.webBrowser = new Awesomium.Windows.Forms.WebControl(this.components);
            this.toolTipClose = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.bMin);
            this.panel1.Controls.Add(this.bMax);
            this.panel1.Controls.Add(this.bTray);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 24);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // bMin
            // 
            this.bMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMin.BackColor = System.Drawing.Color.DarkRed;
            this.bMin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bMin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bMin.FlatAppearance.BorderSize = 0;
            this.bMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMin.ForeColor = System.Drawing.Color.White;
            this.bMin.Location = new System.Drawing.Point(286, 3);
            this.bMin.Name = "bMin";
            this.bMin.Size = new System.Drawing.Size(16, 16);
            this.bMin.TabIndex = 11;
            this.bMin.Text = "-";
            this.bMin.UseVisualStyleBackColor = false;
            this.bMin.Click += new System.EventHandler(this.bMin_Click);
            // 
            // bMax
            // 
            this.bMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMax.BackColor = System.Drawing.Color.DarkRed;
            this.bMax.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bMax.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bMax.FlatAppearance.BorderSize = 0;
            this.bMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMax.ForeColor = System.Drawing.Color.White;
            this.bMax.Location = new System.Drawing.Point(305, 3);
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(16, 16);
            this.bMax.TabIndex = 1;
            this.bMax.Text = "ﬦ\r\n";
            this.bMax.UseVisualStyleBackColor = false;
            this.bMax.Click += new System.EventHandler(this.bMax_Click);
            // 
            // bTray
            // 
            this.bTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bTray.BackColor = System.Drawing.Color.DarkRed;
            this.bTray.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bTray.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bTray.FlatAppearance.BorderSize = 0;
            this.bTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTray.ForeColor = System.Drawing.Color.White;
            this.bTray.Location = new System.Drawing.Point(324, 3);
            this.bTray.Name = "bTray";
            this.bTray.Size = new System.Drawing.Size(16, 16);
            this.bTray.TabIndex = 10;
            this.bTray.Text = "X";
            this.toolTipClose.SetToolTip(this.bTray, "Click to minimize to system tray");
            this.bTray.UseVisualStyleBackColor = false;
            this.bTray.Click += new System.EventHandler(this.bTray_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Size = new System.Drawing.Size(350, 350);
            this.webBrowser.TabIndex = 0;
            // 
            // AwesomiumBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AwesomiumBase";
            this.Size = new System.Drawing.Size(350, 350);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bTray;
        private Awesomium.Windows.Forms.WebControl webBrowser;
        private System.Windows.Forms.ToolTip toolTipClose;
        private System.Windows.Forms.Button bMax;
        private System.Windows.Forms.Button bMin;

    }
}
