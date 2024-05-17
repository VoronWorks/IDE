namespace TourFirm
{
    partial class FormTouristChange
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
            this.dataGridViewTourist = new System.Windows.Forms.DataGridView();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbIndex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTourist)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTourist
            // 
            this.dataGridViewTourist.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridViewTourist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTourist.Location = new System.Drawing.Point(8, 8);
            this.dataGridViewTourist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewTourist.Name = "dataGridViewTourist";
            this.dataGridViewTourist.RowHeadersWidth = 82;
            this.dataGridViewTourist.RowTemplate.Height = 33;
            this.dataGridViewTourist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTourist.Size = new System.Drawing.Size(405, 405);
            this.dataGridViewTourist.TabIndex = 1;
            this.dataGridViewTourist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTourist_CellClick);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(575, 381);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 32);
            this.btnChange.TabIndex = 14;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(448, 381);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 332);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Индекс";
            // 
            // tbIndex
            // 
            this.tbIndex.Location = new System.Drawing.Point(448, 350);
            this.tbIndex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(228, 22);
            this.tbIndex.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Номер телефона";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(448, 305);
            this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(228, 22);
            this.tbPhoneNumber.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Страна";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 195);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "Город";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "Данные паспорта";
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(448, 259);
            this.tbCountry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(228, 22);
            this.tbCountry.TabIndex = 40;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(448, 213);
            this.tbCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(228, 22);
            this.tbCity.TabIndex = 39;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(448, 166);
            this.tbPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(228, 22);
            this.tbPass.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Фамилия";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(448, 120);
            this.tbSurname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(228, 22);
            this.tbSurname.TabIndex = 34;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(448, 74);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(228, 22);
            this.tbName.TabIndex = 33;
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(448, 26);
            this.tbLastname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(228, 22);
            this.tbLastname.TabIndex = 32;
            // 
            // FormTouristChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(715, 420);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSurname);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbLastname);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridViewTourist);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTouristChange";
            this.Text = "Изменение туриста";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTourist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTourist;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbLastname;
    }
}