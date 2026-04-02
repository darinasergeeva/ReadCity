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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnDeleteLoan = new Button();
            btnEditLoan = new Button();
            btnAddLoan = new Button();
            panelTop = new Panel();
            lblUserName = new Label();
            btnLogut = new Button();
            dgvLoans = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteLoan
            // 
            btnDeleteLoan.BackColor = Color.FromArgb(74, 111, 165);
            btnDeleteLoan.BackgroundImageLayout = ImageLayout.Center;
            btnDeleteLoan.FlatAppearance.BorderSize = 0;
            btnDeleteLoan.FlatStyle = FlatStyle.Flat;
            btnDeleteLoan.Location = new Point(365, 0);
            btnDeleteLoan.Name = "btnDeleteLoan";
            btnDeleteLoan.Size = new Size(150, 40);
            btnDeleteLoan.TabIndex = 10;
            btnDeleteLoan.TabStop = false;
            btnDeleteLoan.Text = "Удалить";
            btnDeleteLoan.UseVisualStyleBackColor = false;
            btnDeleteLoan.Click += btnDeleteLoan_Click;
            // 
            // btnEditLoan
            // 
            btnEditLoan.BackColor = Color.FromArgb(74, 111, 165);
            btnEditLoan.BackgroundImageLayout = ImageLayout.Center;
            btnEditLoan.FlatAppearance.BorderSize = 0;
            btnEditLoan.FlatStyle = FlatStyle.Flat;
            btnEditLoan.Location = new Point(181, 0);
            btnEditLoan.Name = "btnEditLoan";
            btnEditLoan.Size = new Size(150, 40);
            btnEditLoan.TabIndex = 9;
            btnEditLoan.TabStop = false;
            btnEditLoan.Text = "Редактировать";
            btnEditLoan.UseVisualStyleBackColor = false;
            btnEditLoan.Click += btnEditLoan_Click;
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
            btnAddLoan.Click += btnAddLoan_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnDeleteLoan);
            panelTop.Controls.Add(btnEditLoan);
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
            btnLogut.Click += btnLogut_Click;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvLoans.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
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

        private Button btnDeleteLoan;
        private Button btnEditLoan;
        private Button btnAddLoan;
        private Panel panelTop;
        private Label lblUserName;
        private Button btnLogut;
        private DataGridView dgvLoans;
    }
}