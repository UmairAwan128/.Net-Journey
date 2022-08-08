namespace LINQToSqlForms
{
    partial class CRUDOperationsForm
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
            this.DGViewCRUD = new System.Windows.Forms.DataGridView();
            this.ClosebuttonCRUD = new System.Windows.Forms.Button();
            this.UpdateButtonCRUD = new System.Windows.Forms.Button();
            this.Insert_CRUD = new System.Windows.Forms.Button();
            this.DeleteButtonCRUD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGViewCRUD)).BeginInit();
            this.SuspendLayout();
            // 
            // DGViewCRUD
            // 
            this.DGViewCRUD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGViewCRUD.Location = new System.Drawing.Point(-1, 1);
            this.DGViewCRUD.Name = "DGViewCRUD";
            this.DGViewCRUD.ReadOnly = true;
            this.DGViewCRUD.Size = new System.Drawing.Size(446, 317);
            this.DGViewCRUD.TabIndex = 0;
            // 
            // ClosebuttonCRUD
            // 
            this.ClosebuttonCRUD.Location = new System.Drawing.Point(336, 324);
            this.ClosebuttonCRUD.Name = "ClosebuttonCRUD";
            this.ClosebuttonCRUD.Size = new System.Drawing.Size(97, 35);
            this.ClosebuttonCRUD.TabIndex = 16;
            this.ClosebuttonCRUD.Text = "Close";
            this.ClosebuttonCRUD.UseVisualStyleBackColor = true;
            this.ClosebuttonCRUD.Click += new System.EventHandler(this.ClosebuttonCRUD_Click);
            // 
            // UpdateButtonCRUD
            // 
            this.UpdateButtonCRUD.Location = new System.Drawing.Point(122, 324);
            this.UpdateButtonCRUD.Name = "UpdateButtonCRUD";
            this.UpdateButtonCRUD.Size = new System.Drawing.Size(97, 35);
            this.UpdateButtonCRUD.TabIndex = 15;
            this.UpdateButtonCRUD.Text = "Update";
            this.UpdateButtonCRUD.UseVisualStyleBackColor = true;
            this.UpdateButtonCRUD.Click += new System.EventHandler(this.UpdateButtonCRUD_Click);
            // 
            // Insert_CRUD
            // 
            this.Insert_CRUD.Location = new System.Drawing.Point(12, 324);
            this.Insert_CRUD.Name = "Insert_CRUD";
            this.Insert_CRUD.Size = new System.Drawing.Size(104, 35);
            this.Insert_CRUD.TabIndex = 14;
            this.Insert_CRUD.Text = "Insert";
            this.Insert_CRUD.UseVisualStyleBackColor = true;
            this.Insert_CRUD.Click += new System.EventHandler(this.Insert_CRUD_Click);
            // 
            // DeleteButtonCRUD
            // 
            this.DeleteButtonCRUD.Location = new System.Drawing.Point(225, 324);
            this.DeleteButtonCRUD.Name = "DeleteButtonCRUD";
            this.DeleteButtonCRUD.Size = new System.Drawing.Size(97, 35);
            this.DeleteButtonCRUD.TabIndex = 17;
            this.DeleteButtonCRUD.Text = "Delete";
            this.DeleteButtonCRUD.UseVisualStyleBackColor = true;
            this.DeleteButtonCRUD.Click += new System.EventHandler(this.DeleteButtonCRUD_Click);
            // 
            // CRUDOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 367);
            this.Controls.Add(this.DeleteButtonCRUD);
            this.Controls.Add(this.ClosebuttonCRUD);
            this.Controls.Add(this.UpdateButtonCRUD);
            this.Controls.Add(this.Insert_CRUD);
            this.Controls.Add(this.DGViewCRUD);
            this.Name = "CRUDOperationsForm";
            this.Text = "CRUDOperationsForm";
            this.Load += new System.EventHandler(this.CRUDOperationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGViewCRUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGViewCRUD;
        private System.Windows.Forms.Button ClosebuttonCRUD;
        private System.Windows.Forms.Button UpdateButtonCRUD;
        private System.Windows.Forms.Button Insert_CRUD;
        private System.Windows.Forms.Button DeleteButtonCRUD;
    }
}