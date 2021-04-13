﻿
namespace Witcher.Notify.Manager
{
    partial class WitcherManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WitcherManagement));
            this.Control = new System.Windows.Forms.Timer(this.components);
            this.Notification = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Control
            // 
            this.Control.Enabled = true;
            this.Control.Interval = 50;
            this.Control.Tick += new System.EventHandler(this.Control_Tick);
            // 
            // Notification
            // 
            this.Notification.Enabled = true;
            this.Notification.Interval = 50;
            this.Notification.Tick += new System.EventHandler(this.Notification_Tick);
            // 
            // WitcherManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Witcher.Properties.Resources.ICO;
            this.Name = "WitcherManagement";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Witcher Management";
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Management_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Management_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Control;
        private System.Windows.Forms.Timer Notification;
    }
}