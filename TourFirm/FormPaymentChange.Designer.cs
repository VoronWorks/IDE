namespace TourFirm
{
    partial class FormPaymentChange
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
            this.tbDeposit = new System.Windows.Forms.TextBox();
            this.datePayment = new System.Windows.Forms.DateTimePicker();
            this.comboBoxVoucher = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewPayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDeposit
            // 
            this.tbDeposit.Location = new System.Drawing.Point(447, 138);
            this.tbDeposit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbDeposit.Name = "tbDeposit";
            this.tbDeposit.Size = new System.Drawing.Size(228, 22);
            this.tbDeposit.TabIndex = 73;
            this.tbDeposit.TextChanged += new System.EventHandler(this.tbDeposit_TextChanged);
            // 
            // datePayment
            // 
            this.datePayment.Location = new System.Drawing.Point(447, 90);
            this.datePayment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datePayment.Name = "datePayment";
            this.datePayment.Size = new System.Drawing.Size(228, 22);
            this.datePayment.TabIndex = 72;
            // 
            // comboBoxVoucher
            // 
            this.comboBoxVoucher.FormattingEnabled = true;
            this.comboBoxVoucher.Location = new System.Drawing.Point(447, 41);
            this.comboBoxVoucher.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxVoucher.Name = "comboBoxVoucher";
            this.comboBoxVoucher.Size = new System.Drawing.Size(228, 24);
            this.comboBoxVoucher.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Сумма платежа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Дата платежа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Путёвка (id)";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(575, 363);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 32);
            this.btnChange.TabIndex = 67;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(449, 363);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPayment
            // 
            this.dataGridViewPayment.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridViewPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayment.Location = new System.Drawing.Point(8, 8);
            this.dataGridViewPayment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewPayment.Name = "dataGridViewPayment";
            this.dataGridViewPayment.RowHeadersWidth = 82;
            this.dataGridViewPayment.RowTemplate.Height = 33;
            this.dataGridViewPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPayment.Size = new System.Drawing.Size(405, 405);
            this.dataGridViewPayment.TabIndex = 65;
            this.dataGridViewPayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPayment_CellClick);
            // 
            // FormPaymentChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(715, 420);
            this.Controls.Add(this.tbDeposit);
            this.Controls.Add(this.datePayment);
            this.Controls.Add(this.comboBoxVoucher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridViewPayment);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPaymentChange";
            this.Text = "FormPaymentChange";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDeposit;
        private System.Windows.Forms.DateTimePicker datePayment;
        private System.Windows.Forms.ComboBox comboBoxVoucher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridViewPayment;
    }
}