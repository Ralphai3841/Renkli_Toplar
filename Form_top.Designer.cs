namespace Ball
{
    partial class Form_top
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sag_tik = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cikis = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sag_tik,
            this.toolStripMenuItem1,
            this.cikis});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 54);
            // 
            // sag_tik
            // 
            this.sag_tik.CheckOnClick = true;
            this.sag_tik.Name = "sag_tik";
            this.sag_tik.Size = new System.Drawing.Size(118, 22);
            this.sag_tik.Text = "Duraklat";
            this.sag_tik.Click += new System.EventHandler(this.sag_tik_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // cikis
            // 
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(118, 22);
            this.cikis.Text = "Çıkış";
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // BallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(24, 24);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BallForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BallForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Cyan;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BallForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BallForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BallForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BallForm_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cikis;
        private System.Windows.Forms.ToolStripMenuItem sag_tik;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}