namespace ReadCity
{
    partial class FormLoanEdit
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
            lblTitle = new Label();
            lblBook = new Label();
            cbBook = new ComboBox();
            cbReader = new ComboBox();
            lblReader = new Label();
            label1 = new Label();
            numDays = new NumericUpDown();
            lblReturnDate = new Label();
            lblReturnDateValue = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numDays).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Выдача книги";
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(12, 51);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(51, 19);
            lblBook.TabIndex = 1;
            lblBook.Text = "Книга";
            // 
            // cbBook
            // 
            cbBook.FormattingEnabled = true;
            cbBook.Location = new Point(211, 48);
            cbBook.Name = "cbBook";
            cbBook.Size = new Size(217, 27);
            cbBook.TabIndex = 2;
            // 
            // cbReader
            // 
            cbReader.FormattingEnabled = true;
            cbReader.Location = new Point(211, 96);
            cbReader.Name = "cbReader";
            cbReader.Size = new Size(217, 27);
            cbReader.TabIndex = 4;
            // 
            // lblReader
            // 
            lblReader.AutoSize = true;
            lblReader.Location = new Point(12, 99);
            lblReader.Name = "lblReader";
            lblReader.Size = new Size(71, 19);
            lblReader.TabIndex = 3;
            lblReader.Text = "Читатель";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 145);
            label1.Name = "label1";
            label1.Size = new Size(140, 19);
            label1.TabIndex = 5;
            label1.Text = "Срок выдачи(дней)";
            // 
            // numDays
            // 
            numDays.Location = new Point(211, 148);
            numDays.Name = "numDays";
            numDays.Size = new Size(217, 26);
            numDays.TabIndex = 6;
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(12, 193);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(173, 19);
            lblReturnDate.TabIndex = 7;
            lblReturnDate.Text = "Плановая дата возврата:\t";
            // 
            // lblReturnDateValue
            // 
            lblReturnDateValue.Location = new Point(211, 198);
            lblReturnDateValue.Name = "lblReturnDateValue";
            lblReturnDateValue.Size = new Size(217, 15);
            lblReturnDateValue.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(74, 111, 165);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(177, 233);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(74, 111, 165);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(12, 233);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 35);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // FormLoanEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 295);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblReturnDateValue);
            Controls.Add(lblReturnDate);
            Controls.Add(numDays);
            Controls.Add(label1);
            Controls.Add(cbReader);
            Controls.Add(lblReader);
            Controls.Add(cbBook);
            Controls.Add(lblBook);
            Controls.Add(lblTitle);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "FormLoanEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор";
            ((System.ComponentModel.ISupportInitialize)numDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblBook;
        private ComboBox cbBook;
        private ComboBox cbReader;
        private Label lblReader;
        private Label label1;
        private NumericUpDown numDays;
        private Label lblReturnDate;
        private Label lblReturnDateValue;
        private Button btnCancel;
        private Button btnSave;
    }
}