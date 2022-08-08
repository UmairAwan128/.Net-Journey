namespace LINQToSqlForms
{
    partial class StoredProcedureDemo
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
            this.DGViewProc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGViewProc)).BeginInit();
            this.SuspendLayout();
            // 
            // DGViewProc
            // 
            this.DGViewProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGViewProc.Location = new System.Drawing.Point(5, 12);
            this.DGViewProc.Name = "DGViewProc";
            this.DGViewProc.ReadOnly = true;
            this.DGViewProc.Size = new System.Drawing.Size(446, 317);
            this.DGViewProc.TabIndex = 2;
            // 
            // StoredProcedureDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.DGViewProc);
            this.Name = "StoredProcedureDemo";
            this.Text = "StoredProcedureDemo";
            this.Load += new System.EventHandler(this.StoredProcedureDemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGViewProc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGViewProc;
    }
}