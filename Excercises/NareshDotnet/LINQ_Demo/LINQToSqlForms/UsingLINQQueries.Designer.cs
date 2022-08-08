namespace LINQToSqlForms
{
    partial class UsingLINQQueries
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.OrderBySalarybutton = new System.Windows.Forms.Button();
            this.OrderbyEnameButton = new System.Windows.Forms.Button();
            this.GetSelColbutton = new System.Windows.Forms.Button();
            this.CountEmpButton = new System.Windows.Forms.Button();
            this.JobsHavingEmpGre = new System.Windows.Forms.Button();
            this.CountClerksinEachDeptbutton = new System.Windows.Forms.Button();
            this.MaxSalaryEachDeptbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 415);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // OrderBySalarybutton
            // 
            this.OrderBySalarybutton.Location = new System.Drawing.Point(658, 51);
            this.OrderBySalarybutton.Name = "OrderBySalarybutton";
            this.OrderBySalarybutton.Size = new System.Drawing.Size(154, 44);
            this.OrderBySalarybutton.TabIndex = 3;
            this.OrderBySalarybutton.Text = "Order By Salary";
            this.OrderBySalarybutton.UseVisualStyleBackColor = true;
            this.OrderBySalarybutton.Click += new System.EventHandler(this.OrderBySalarybutton_Click);
            // 
            // OrderbyEnameButton
            // 
            this.OrderbyEnameButton.Location = new System.Drawing.Point(658, 101);
            this.OrderbyEnameButton.Name = "OrderbyEnameButton";
            this.OrderbyEnameButton.Size = new System.Drawing.Size(154, 44);
            this.OrderbyEnameButton.TabIndex = 4;
            this.OrderbyEnameButton.Text = "Order By Ename Desc";
            this.OrderbyEnameButton.UseVisualStyleBackColor = true;
            this.OrderbyEnameButton.Click += new System.EventHandler(this.OrderbyEnameButton_Click);
            // 
            // GetSelColbutton
            // 
            this.GetSelColbutton.Location = new System.Drawing.Point(658, 151);
            this.GetSelColbutton.Name = "GetSelColbutton";
            this.GetSelColbutton.Size = new System.Drawing.Size(154, 44);
            this.GetSelColbutton.TabIndex = 5;
            this.GetSelColbutton.Text = "Get Selected Columns";
            this.GetSelColbutton.UseVisualStyleBackColor = true;
            this.GetSelColbutton.Click += new System.EventHandler(this.GetSelColbutton_Click);
            // 
            // CountEmpButton
            // 
            this.CountEmpButton.Location = new System.Drawing.Point(658, 201);
            this.CountEmpButton.Name = "CountEmpButton";
            this.CountEmpButton.Size = new System.Drawing.Size(154, 44);
            this.CountEmpButton.TabIndex = 6;
            this.CountEmpButton.Text = "Count Emp in each Dept";
            this.CountEmpButton.UseVisualStyleBackColor = true;
            this.CountEmpButton.Click += new System.EventHandler(this.CountEmpButton_Click);
            // 
            // JobsHavingEmpGre
            // 
            this.JobsHavingEmpGre.Location = new System.Drawing.Point(658, 251);
            this.JobsHavingEmpGre.Name = "JobsHavingEmpGre";
            this.JobsHavingEmpGre.Size = new System.Drawing.Size(154, 44);
            this.JobsHavingEmpGre.TabIndex = 7;
            this.JobsHavingEmpGre.Text = "Jobs having Emp<5 ";
            this.JobsHavingEmpGre.UseVisualStyleBackColor = true;
            this.JobsHavingEmpGre.Click += new System.EventHandler(this.JobsHavingEmpGre_Click);
            // 
            // CountClerksinEachDeptbutton
            // 
            this.CountClerksinEachDeptbutton.Location = new System.Drawing.Point(658, 301);
            this.CountClerksinEachDeptbutton.Name = "CountClerksinEachDeptbutton";
            this.CountClerksinEachDeptbutton.Size = new System.Drawing.Size(154, 44);
            this.CountClerksinEachDeptbutton.TabIndex = 8;
            this.CountClerksinEachDeptbutton.Text = "Count Clerks in Each Dept";
            this.CountClerksinEachDeptbutton.UseVisualStyleBackColor = true;
            this.CountClerksinEachDeptbutton.Click += new System.EventHandler(this.CountClerksinEachDeptbutton_Click);
            // 
            // MaxSalaryEachDeptbutton
            // 
            this.MaxSalaryEachDeptbutton.Location = new System.Drawing.Point(658, 351);
            this.MaxSalaryEachDeptbutton.Name = "MaxSalaryEachDeptbutton";
            this.MaxSalaryEachDeptbutton.Size = new System.Drawing.Size(154, 44);
            this.MaxSalaryEachDeptbutton.TabIndex = 9;
            this.MaxSalaryEachDeptbutton.Text = "Max Salary Each Dept";
            this.MaxSalaryEachDeptbutton.UseVisualStyleBackColor = true;
            this.MaxSalaryEachDeptbutton.Click += new System.EventHandler(this.MaxSalaryEachDeptbutton_Click);
            // 
            // UsingLINQQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(816, 467);
            this.Controls.Add(this.MaxSalaryEachDeptbutton);
            this.Controls.Add(this.CountClerksinEachDeptbutton);
            this.Controls.Add(this.JobsHavingEmpGre);
            this.Controls.Add(this.CountEmpButton);
            this.Controls.Add(this.GetSelColbutton);
            this.Controls.Add(this.OrderbyEnameButton);
            this.Controls.Add(this.OrderBySalarybutton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UsingLINQQueries";
            this.Text = "UsingLINQQueries";
            this.Load += new System.EventHandler(this.UsingLINQQueries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button OrderBySalarybutton;
        private System.Windows.Forms.Button OrderbyEnameButton;
        private System.Windows.Forms.Button GetSelColbutton;
        private System.Windows.Forms.Button CountEmpButton;
        private System.Windows.Forms.Button JobsHavingEmpGre;
        private System.Windows.Forms.Button CountClerksinEachDeptbutton;
        private System.Windows.Forms.Button MaxSalaryEachDeptbutton;
    }
}