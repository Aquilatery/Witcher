using Witcher.Properties;

namespace Witcher.WF.Notify.Standard
{
    partial class WitcherStandardWF
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WitcherStandardWF));
            this.LEFT = new System.Windows.Forms.Panel();
            this.CLOSE = new System.Windows.Forms.PictureBox();
            this.TEXT = new System.Windows.Forms.Label();
            this.BAR = new System.Windows.Forms.Panel();
            this.General = new System.Windows.Forms.Timer(this.components);
            this.PANEL = new System.Windows.Forms.Panel();
            this.LEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).BeginInit();
            this.PANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // LEFT
            // 
            this.LEFT.BackColor = System.Drawing.Color.Crimson;
            this.LEFT.Controls.Add(this.CLOSE);
            this.LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT.Location = new System.Drawing.Point(0, 0);
            this.LEFT.Margin = new System.Windows.Forms.Padding(0);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(26, 60);
            this.LEFT.TabIndex = 6;
            // 
            // CLOSE
            // 
            this.CLOSE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CLOSE.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLOSE.Image = Resources.Multiply;
            this.CLOSE.Location = new System.Drawing.Point(0, 22);
            this.CLOSE.Margin = new System.Windows.Forms.Padding(0);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(26, 16);
            this.CLOSE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CLOSE.TabIndex = 6;
            this.CLOSE.TabStop = false;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            this.CLOSE.MouseEnter += new System.EventHandler(this.CLOSE_MouseEnter);
            this.CLOSE.MouseLeave += new System.EventHandler(this.CLOSE_MouseLeave);
            // 
            // TEXT
            // 
            this.TEXT.AutoEllipsis = true;
            this.TEXT.BackColor = System.Drawing.Color.Transparent;
            this.TEXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TEXT.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TEXT.ForeColor = System.Drawing.Color.Gainsboro;
            this.TEXT.Location = new System.Drawing.Point(26, 0);
            this.TEXT.Margin = new System.Windows.Forms.Padding(0);
            this.TEXT.Name = "TEXT";
            this.TEXT.Size = new System.Drawing.Size(374, 60);
            this.TEXT.TabIndex = 7;
            this.TEXT.Text = "My Name Is Soferity Witcher WF Sweetheart!";
            this.TEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BAR
            // 
            this.BAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BAR.BackColor = System.Drawing.Color.Crimson;
            this.BAR.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BAR.ForeColor = System.Drawing.Color.White;
            this.BAR.Location = new System.Drawing.Point(0, 0);
            this.BAR.Margin = new System.Windows.Forms.Padding(0);
            this.BAR.Name = "BAR";
            this.BAR.Size = new System.Drawing.Size(0, 2);
            this.BAR.TabIndex = 8;
            // 
            // General
            // 
            this.General.Enabled = true;
            this.General.Interval = 50;
            this.General.Tick += new System.EventHandler(this.General_Tick);
            // 
            // PANEL
            // 
            this.PANEL.BackColor = System.Drawing.Color.Transparent;
            this.PANEL.Controls.Add(this.BAR);
            this.PANEL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PANEL.Location = new System.Drawing.Point(26, 58);
            this.PANEL.Name = "PANEL";
            this.PANEL.Size = new System.Drawing.Size(374, 2);
            this.PANEL.TabIndex = 9;
            // 
            // WitcherStandardWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(400, 60);
            this.ControlBox = false;
            this.Controls.Add(this.PANEL);
            this.Controls.Add(this.TEXT);
            this.Controls.Add(this.LEFT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = Resources.ICO;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WitcherStandardWF";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Witcher Standard WF";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StandardWF_FormClosed);
            this.Load += new System.EventHandler(this.StandardWF_Load);
            this.LocationChanged += new System.EventHandler(this.StandardWF_LocationChanged);
            this.LEFT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).EndInit();
            this.PANEL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel LEFT;
        private System.Windows.Forms.PictureBox CLOSE;
        private System.Windows.Forms.Label TEXT;
        private System.Windows.Forms.Panel BAR;
        private System.Windows.Forms.Timer General;
        private System.Windows.Forms.Panel PANEL;
    }
}