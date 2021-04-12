namespace Witcher.Notify.Standard
{
    partial class NYB
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
            this.CloseForm = new System.Windows.Forms.Timer(this.components);
            this.StartForm = new System.Windows.Forms.Timer(this.components);
            this.FinishForm = new System.Windows.Forms.Timer(this.components);
            this.ShowForm = new System.Windows.Forms.Timer(this.components);
            this.LEFT = new System.Windows.Forms.Panel();
            this.CLOSE = new System.Windows.Forms.PictureBox();
            this.TEXT = new System.Windows.Forms.Label();
            this.BAR = new ReaLTaiizor.Controls.MetroProgressBar();
            this.LEFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseForm
            // 
            this.CloseForm.Interval = 50;
            this.CloseForm.Tick += new System.EventHandler(this.CloseForm_Tick);
            // 
            // StartForm
            // 
            this.StartForm.Interval = 25;
            this.StartForm.Tick += new System.EventHandler(this.StartForm_Tick);
            // 
            // FinishForm
            // 
            this.FinishForm.Interval = 50;
            this.FinishForm.Tick += new System.EventHandler(this.FinishForm_Tick);
            // 
            // ShowForm
            // 
            this.ShowForm.Enabled = true;
            this.ShowForm.Interval = 25;
            this.ShowForm.Tick += new System.EventHandler(this.ShowForm_Tick);
            // 
            // LEFT
            // 
            this.LEFT.BackColor = System.Drawing.Color.Crimson;
            this.LEFT.Controls.Add(this.CLOSE);
            this.LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT.Location = new System.Drawing.Point(0, 0);
            this.LEFT.Margin = new System.Windows.Forms.Padding(0);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(25, 61);
            this.LEFT.TabIndex = 6;
            // 
            // CLOSE
            // 
            this.CLOSE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CLOSE.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLOSE.Image = global::Witcher.Properties.Resources.Multiply;
            this.CLOSE.Location = new System.Drawing.Point(0, 22);
            this.CLOSE.Margin = new System.Windows.Forms.Padding(0);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(25, 16);
            this.CLOSE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CLOSE.TabIndex = 6;
            this.CLOSE.TabStop = false;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            // 
            // TEXT
            // 
            this.TEXT.BackColor = System.Drawing.Color.Transparent;
            this.TEXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TEXT.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TEXT.ForeColor = System.Drawing.Color.Gainsboro;
            this.TEXT.Location = new System.Drawing.Point(25, 0);
            this.TEXT.Margin = new System.Windows.Forms.Padding(0);
            this.TEXT.Name = "TEXT";
            this.TEXT.Size = new System.Drawing.Size(376, 61);
            this.TEXT.TabIndex = 7;
            this.TEXT.Text = "Benim Adım Soferity Witcher Pro Tatlım!";
            this.TEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BAR
            // 
            this.BAR.BackgroundColor = System.Drawing.Color.Transparent;
            this.BAR.BorderColor = System.Drawing.Color.Transparent;
            this.BAR.DisabledBackColor = System.Drawing.Color.Transparent;
            this.BAR.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.BAR.DisabledProgressColor = System.Drawing.Color.Transparent;
            this.BAR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BAR.IsDerivedStyle = true;
            this.BAR.Location = new System.Drawing.Point(25, 59);
            this.BAR.Margin = new System.Windows.Forms.Padding(0);
            this.BAR.Maximum = 100;
            this.BAR.Minimum = 0;
            this.BAR.Name = "BAR";
            this.BAR.Orientation = ReaLTaiizor.Enum.Metro.ProgressOrientation.Horizontal;
            this.BAR.ProgressColor = System.Drawing.Color.Crimson;
            this.BAR.Size = new System.Drawing.Size(376, 2);
            this.BAR.Style = ReaLTaiizor.Enum.Metro.Style.Custom;
            this.BAR.StyleManager = null;
            this.BAR.TabIndex = 8;
            this.BAR.ThemeAuthor = "Taiizor";
            this.BAR.ThemeName = "MetroLight";
            this.BAR.Value = 0;
            // 
            // NYB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(401, 61);
            this.ControlBox = false;
            this.Controls.Add(this.BAR);
            this.Controls.Add(this.TEXT);
            this.Controls.Add(this.LEFT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NYB";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NYS";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NYB_FormClosed);
            this.Load += new System.EventHandler(this.NYB_Load);
            this.LocationChanged += new System.EventHandler(this.NYB_LocationChanged);
            this.LEFT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CLOSE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CloseForm;
        private System.Windows.Forms.Timer StartForm;
        private System.Windows.Forms.Timer FinishForm;
        private System.Windows.Forms.Timer ShowForm;
        private System.Windows.Forms.Panel LEFT;
        private System.Windows.Forms.PictureBox CLOSE;
        private System.Windows.Forms.Label TEXT;
        private ReaLTaiizor.Controls.MetroProgressBar BAR;
    }
}