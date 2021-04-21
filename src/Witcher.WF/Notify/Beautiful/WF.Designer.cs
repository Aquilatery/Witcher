namespace Witcher.WF.Notify.Beautiful
{
    partial class WitcherBeautifulWF
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
            this.TITLE = new System.Windows.Forms.Label();
            this.CLOSE = new System.Windows.Forms.PictureBox();
            this.STATE = new System.Windows.Forms.PictureBox();
            this.TEXT = new System.Windows.Forms.Label();
            this.LEFT = new System.Windows.Forms.Panel();
            this.LBAR = new System.Windows.Forms.Panel();
            this.RIGHT = new System.Windows.Forms.Panel();
            this.RBAR = new System.Windows.Forms.Panel();
            this.TOP = new System.Windows.Forms.Panel();
            this.TBAR = new System.Windows.Forms.Panel();
            this.BOT = new System.Windows.Forms.Panel();
            this.BBAR = new System.Windows.Forms.Panel();
            this.General = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STATE)).BeginInit();
            this.LEFT.SuspendLayout();
            this.RIGHT.SuspendLayout();
            this.TOP.SuspendLayout();
            this.BOT.SuspendLayout();
            this.SuspendLayout();
            // 
            // TITLE
            // 
            this.TITLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TITLE.AutoEllipsis = true;
            this.TITLE.BackColor = System.Drawing.Color.Transparent;
            this.TITLE.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TITLE.ForeColor = System.Drawing.Color.Gainsboro;
            this.TITLE.Location = new System.Drawing.Point(79, 12);
            this.TITLE.Margin = new System.Windows.Forms.Padding(0);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(332, 24);
            this.TITLE.TabIndex = 7;
            this.TITLE.Text = "Soferity Witcher WF";
            this.TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CLOSE
            // 
            this.CLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLOSE.Image = global::Witcher.WF.Properties.Resources.Multiply;
            this.CLOSE.Location = new System.Drawing.Point(416, 14);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(20, 20);
            this.CLOSE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CLOSE.TabIndex = 8;
            this.CLOSE.TabStop = false;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            this.CLOSE.MouseEnter += new System.EventHandler(this.CLOSE_MouseEnter);
            this.CLOSE.MouseLeave += new System.EventHandler(this.CLOSE_MouseLeave);
            // 
            // STATE
            // 
            this.STATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.STATE.Image = global::Witcher.WF.Properties.Resources.Error;
            this.STATE.Location = new System.Drawing.Point(12, 12);
            this.STATE.Name = "STATE";
            this.STATE.Size = new System.Drawing.Size(64, 64);
            this.STATE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.STATE.TabIndex = 9;
            this.STATE.TabStop = false;
            // 
            // TEXT
            // 
            this.TEXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TEXT.AutoEllipsis = true;
            this.TEXT.BackColor = System.Drawing.Color.Transparent;
            this.TEXT.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TEXT.ForeColor = System.Drawing.Color.Gainsboro;
            this.TEXT.Location = new System.Drawing.Point(79, 39);
            this.TEXT.Margin = new System.Windows.Forms.Padding(0);
            this.TEXT.Name = "TEXT";
            this.TEXT.Size = new System.Drawing.Size(359, 37);
            this.TEXT.TabIndex = 10;
            this.TEXT.Text = "My Name Is Soferity Witcher WF Sweetheart!";
            this.TEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LEFT
            // 
            this.LEFT.BackColor = System.Drawing.Color.Transparent;
            this.LEFT.Controls.Add(this.LBAR);
            this.LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT.Location = new System.Drawing.Point(0, 0);
            this.LEFT.Margin = new System.Windows.Forms.Padding(0);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(2, 88);
            this.LEFT.TabIndex = 11;
            // 
            // LBAR
            // 
            this.LBAR.BackColor = System.Drawing.Color.Crimson;
            this.LBAR.Location = new System.Drawing.Point(0, 0);
            this.LBAR.Margin = new System.Windows.Forms.Padding(0);
            this.LBAR.Name = "LBAR";
            this.LBAR.Size = new System.Drawing.Size(2, 0);
            this.LBAR.TabIndex = 15;
            // 
            // RIGHT
            // 
            this.RIGHT.BackColor = System.Drawing.Color.Transparent;
            this.RIGHT.Controls.Add(this.RBAR);
            this.RIGHT.Dock = System.Windows.Forms.DockStyle.Right;
            this.RIGHT.Location = new System.Drawing.Point(448, 0);
            this.RIGHT.Margin = new System.Windows.Forms.Padding(0);
            this.RIGHT.Name = "RIGHT";
            this.RIGHT.Size = new System.Drawing.Size(2, 88);
            this.RIGHT.TabIndex = 12;
            // 
            // RBAR
            // 
            this.RBAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RBAR.BackColor = System.Drawing.Color.Crimson;
            this.RBAR.Location = new System.Drawing.Point(0, 88);
            this.RBAR.Margin = new System.Windows.Forms.Padding(0);
            this.RBAR.Name = "RBAR";
            this.RBAR.Size = new System.Drawing.Size(2, 0);
            this.RBAR.TabIndex = 16;
            // 
            // TOP
            // 
            this.TOP.BackColor = System.Drawing.Color.Transparent;
            this.TOP.Controls.Add(this.TBAR);
            this.TOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOP.Location = new System.Drawing.Point(2, 0);
            this.TOP.Margin = new System.Windows.Forms.Padding(0);
            this.TOP.Name = "TOP";
            this.TOP.Size = new System.Drawing.Size(446, 2);
            this.TOP.TabIndex = 13;
            // 
            // TBAR
            // 
            this.TBAR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TBAR.BackColor = System.Drawing.Color.Crimson;
            this.TBAR.Location = new System.Drawing.Point(0, 0);
            this.TBAR.Margin = new System.Windows.Forms.Padding(0);
            this.TBAR.Name = "TBAR";
            this.TBAR.Size = new System.Drawing.Size(0, 2);
            this.TBAR.TabIndex = 16;
            // 
            // BOT
            // 
            this.BOT.BackColor = System.Drawing.Color.Transparent;
            this.BOT.Controls.Add(this.BBAR);
            this.BOT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BOT.Location = new System.Drawing.Point(2, 86);
            this.BOT.Margin = new System.Windows.Forms.Padding(0);
            this.BOT.Name = "BOT";
            this.BOT.Size = new System.Drawing.Size(446, 2);
            this.BOT.TabIndex = 14;
            // 
            // BBAR
            // 
            this.BBAR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BBAR.BackColor = System.Drawing.Color.Crimson;
            this.BBAR.Location = new System.Drawing.Point(446, 0);
            this.BBAR.Margin = new System.Windows.Forms.Padding(0);
            this.BBAR.Name = "BBAR";
            this.BBAR.Size = new System.Drawing.Size(0, 2);
            this.BBAR.TabIndex = 16;
            // 
            // General
            // 
            this.General.Enabled = true;
            this.General.Interval = 50;
            this.General.Tick += new System.EventHandler(this.General_Tick);
            // 
            // WitcherBeautifulWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(450, 88);
            this.ControlBox = false;
            this.Controls.Add(this.BOT);
            this.Controls.Add(this.TOP);
            this.Controls.Add(this.LEFT);
            this.Controls.Add(this.RIGHT);
            this.Controls.Add(this.STATE);
            this.Controls.Add(this.CLOSE);
            this.Controls.Add(this.TITLE);
            this.Controls.Add(this.TEXT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Witcher.WF.Properties.Resources.ICO;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 88);
            this.Name = "WitcherBeautifulWF";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Witcher Beautiful WF";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BeautifulWF_FormClosed);
            this.Load += new System.EventHandler(this.BeautifulWF_Load);
            this.LocationChanged += new System.EventHandler(this.BeautifulWF_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STATE)).EndInit();
            this.LEFT.ResumeLayout(false);
            this.RIGHT.ResumeLayout(false);
            this.TOP.ResumeLayout(false);
            this.BOT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TITLE;
        private System.Windows.Forms.PictureBox CLOSE;
        private System.Windows.Forms.PictureBox STATE;
        private System.Windows.Forms.Label TEXT;
        private System.Windows.Forms.Panel LEFT;
        private System.Windows.Forms.Panel RIGHT;
        private System.Windows.Forms.Panel TOP;
        private System.Windows.Forms.Panel LBAR;
        private System.Windows.Forms.Panel TBAR;
        private System.Windows.Forms.Panel RBAR;
        private System.Windows.Forms.Panel BOT;
        private System.Windows.Forms.Panel BBAR;
        private System.Windows.Forms.Timer General;
    }
}