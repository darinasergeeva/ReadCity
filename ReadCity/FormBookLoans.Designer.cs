namespace ReadCity
{
    partial class FormBookLoans
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAddLoan = new Button();
            panelTop = new Panel();
            lblUserName = new Label();
            btnLogut = new Button();
            dgvLoans = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(74, 111, 165);
            btnDelete.BackgroundImageLayout = ImageLayout.Center;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(365, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 40);
            btnDelete.TabIndex = 10;
            btnDelete.TabStop = false;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(74, 111, 165);
            btnEdit.BackgroundImageLayout = ImageLayout.Center;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(181, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 40);
            btnEdit.TabIndex = 9;
            btnEdit.TabStop = false;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAddLoan
            // 
            btnAddLoan.BackColor = Color.FromArgb(74, 111, 165);
            btnAddLoan.BackgroundImageLayout = ImageLayout.Center;
            btnAddLoan.Dock = DockStyle.Left;
            btnAddLoan.FlatAppearance.BorderSize = 0;
            btnAddLoan.FlatStyle = FlatStyle.Flat;
            btnAddLoan.Location = new Point(0, 0);
            btnAddLoan.Name = "btnAddLoan";
            btnAddLoan.Size = new Size(150, 40);
            btnAddLoan.TabIndex = 8;
            btnAddLoan.TabStop = false;
            btnAddLoan.Text = "Добавить";
            btnAddLoan.UseVisualStyleBackColor = false;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnDelete);
            panelTop.Controls.Add(btnEdit);
            panelTop.Controls.Add(btnAddLoan);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogut);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1029, 40);
            panelTop.TabIndex = 2;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(834, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "label1";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogut
            // 
            btnLogut.BackColor = Color.FromArgb(74, 111, 165);
            btnLogut.BackgroundImageLayout = ImageLayout.Center;
            btnLogut.Dock = DockStyle.Right;
            btnLogut.FlatAppearance.BorderSize = 0;
            btnLogut.FlatStyle = FlatStyle.Flat;
            btnLogut.Location = new Point(879, 0);
            btnLogut.Name = "btnLogut";
            btnLogut.Size = new Size(150, 40);
            btnLogut.TabIndex = 5;
            btnLogut.TabStop = false;
            btnLogut.Text = "Выйти";
            btnLogut.UseVisualStyleBackColor = false;
            // 
            // dgvLoans
            // 
            dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoans.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLoans.BackgroundColor = Color.White;
            dgvLoans.BorderStyle = BorderStyle.None;
            dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoans.ColumnHeadersVisible = false;
            dgvLoans.Dock = DockStyle.Fill;
            dgvLoans.Location = new Point(0, 40);
            dgvLoans.MultiSelect = false;
            dgvLoans.Name = "dgvLoans";
            dgvLoans.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLoans.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLoans.RowHeadersVisible = false;
            dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoans.Size = new Size(1029, 530);
            dgvLoans.TabIndex = 3;
            // 
            // FormBookLoans
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 570);
            Controls.Add(dgvLoans);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormBookLoans";
            Text = "Выдача книг";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnAddLoan;
        private Panel panelTop;
        private Label lblUserName;
        private Button btnLogut;
        private DataGridView dgvLoans;
    }
}