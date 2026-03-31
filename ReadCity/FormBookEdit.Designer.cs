namespace ReadCity
{
    partial class FormBookEdit
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
            panelHeader = new Panel();
            lblTitle = new Label();
            groupBasic = new GroupBox();
            txtPages = new MaskedTextBox();
            lblPages = new Label();
            cbPublisher = new ComboBox();
            cbGenre = new ComboBox();
            cbAuthor = new ComboBox();
            txtYear = new MaskedTextBox();
            lblYear = new Label();
            lblPublisher = new Label();
            lblGenre = new Label();
            lblAuthor = new Label();
            txtName = new MaskedTextBox();
            lblName = new Label();
            txtISBN = new MaskedTextBox();
            lblISBN = new Label();
            groupCopies = new GroupBox();
            txtAvailableCopies = new MaskedTextBox();
            lblAvailable = new Label();
            txtTotalCopies = new MaskedTextBox();
            lblTotal = new Label();
            groupAnnotation = new GroupBox();
            txtAnnotation = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            groupBasic.SuspendLayout();
            groupCopies.SuspendLayout();
            groupAnnotation.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(534, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(181, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавление новой книги";
            // 
            // groupBasic
            // 
            groupBasic.Controls.Add(txtPages);
            groupBasic.Controls.Add(lblPages);
            groupBasic.Controls.Add(cbPublisher);
            groupBasic.Controls.Add(cbGenre);
            groupBasic.Controls.Add(cbAuthor);
            groupBasic.Controls.Add(txtYear);
            groupBasic.Controls.Add(lblYear);
            groupBasic.Controls.Add(lblPublisher);
            groupBasic.Controls.Add(lblGenre);
            groupBasic.Controls.Add(lblAuthor);
            groupBasic.Controls.Add(txtName);
            groupBasic.Controls.Add(lblName);
            groupBasic.Controls.Add(txtISBN);
            groupBasic.Controls.Add(lblISBN);
            groupBasic.Location = new Point(20, 70);
            groupBasic.Name = "groupBasic";
            groupBasic.Size = new Size(500, 320);
            groupBasic.TabIndex = 1;
            groupBasic.TabStop = false;
            groupBasic.Text = "Основная информация";
            // 
            // txtPages
            // 
            txtPages.Location = new Point(120, 278);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(180, 26);
            txtPages.TabIndex = 16;
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(20, 281);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(72, 19);
            lblPages.TabIndex = 15;
            lblPages.Text = "Страниц:";
            // 
            // cbPublisher
            // 
            cbPublisher.FormattingEnabled = true;
            cbPublisher.Location = new Point(120, 192);
            cbPublisher.Name = "cbPublisher";
            cbPublisher.Size = new Size(180, 27);
            cbPublisher.TabIndex = 14;
            // 
            // cbGenre
            // 
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(120, 154);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(180, 27);
            cbGenre.TabIndex = 13;
            // 
            // cbAuthor
            // 
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(120, 111);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(180, 27);
            cbAuthor.TabIndex = 12;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(120, 235);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(180, 26);
            txtYear.TabIndex = 11;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(20, 238);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(36, 19);
            lblYear.TabIndex = 10;
            lblYear.Text = "Год:";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(20, 195);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(103, 19);
            lblPublisher.TabIndex = 8;
            lblPublisher.Text = "Издательство:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(20, 154);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(50, 19);
            lblGenre.TabIndex = 6;
            lblGenre.Text = "Жанр:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(20, 114);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 19);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Автор:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 26);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 73);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 19);
            lblName.TabIndex = 2;
            lblName.Text = "Название:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(120, 35);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(180, 26);
            txtISBN.TabIndex = 1;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(20, 35);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(48, 19);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN:";
            // 
            // groupCopies
            // 
            groupCopies.Controls.Add(txtAvailableCopies);
            groupCopies.Controls.Add(lblAvailable);
            groupCopies.Controls.Add(txtTotalCopies);
            groupCopies.Controls.Add(lblTotal);
            groupCopies.Location = new Point(20, 396);
            groupCopies.Name = "groupCopies";
            groupCopies.Size = new Size(502, 93);
            groupCopies.TabIndex = 2;
            groupCopies.TabStop = false;
            // 
            // txtAvailableCopies
            // 
            txtAvailableCopies.Location = new Point(165, 57);
            txtAvailableCopies.Name = "txtAvailableCopies";
            txtAvailableCopies.Size = new Size(180, 26);
            txtAvailableCopies.TabIndex = 20;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Location = new Point(20, 60);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(78, 19);
            lblAvailable.TabIndex = 19;
            lblAvailable.Text = "Доступно:";
            // 
            // txtTotalCopies
            // 
            txtTotalCopies.Location = new Point(165, 19);
            txtTotalCopies.Name = "txtTotalCopies";
            txtTotalCopies.Size = new Size(180, 26);
            txtTotalCopies.TabIndex = 18;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 22);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(139, 19);
            lblTotal.TabIndex = 17;
            lblTotal.Text = "Всего экземпляров:";
            // 
            // groupAnnotation
            // 
            groupAnnotation.Controls.Add(txtAnnotation);
            groupAnnotation.Location = new Point(20, 495);
            groupAnnotation.Name = "groupAnnotation";
            groupAnnotation.Size = new Size(500, 67);
            groupAnnotation.TabIndex = 3;
            groupAnnotation.TabStop = false;
            groupAnnotation.Text = "Аннотация:";
            // 
            // txtAnnotation
            // 
            txtAnnotation.Location = new Point(6, 35);
            txtAnnotation.Multiline = true;
            txtAnnotation.Name = "txtAnnotation";
            txtAnnotation.ScrollBars = ScrollBars.Vertical;
            txtAnnotation.Size = new Size(339, 23);
            txtAnnotation.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(74, 111, 165);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(20, 568);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 35);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(74, 111, 165);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(185, 568);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // FormBookEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(534, 666);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupAnnotation);
            Controls.Add(groupCopies);
            Controls.Add(groupBasic);
            Controls.Add(panelHeader);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FormBookEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор книг";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBasic.ResumeLayout(false);
            groupBasic.PerformLayout();
            groupCopies.ResumeLayout(false);
            groupCopies.PerformLayout();
            groupAnnotation.ResumeLayout(false);
            groupAnnotation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private GroupBox groupBasic;
        private MaskedTextBox txtISBN;
        private Label lblISBN;
        private MaskedTextBox txtYear;
        private Label lblYear;
        private Label lblPublisher;
        private Label lblGenre;
        private Label lblAuthor;
        private MaskedTextBox txtName;
        private Label lblName;
        private ComboBox cbGenre;
        private ComboBox cbAuthor;
        private ComboBox cbPublisher;
        private MaskedTextBox txtPages;
        private Label lblPages;
        private GroupBox groupCopies;
        private MaskedTextBox txtAvailableCopies;
        private Label lblAvailable;
        private MaskedTextBox txtTotalCopies;
        private Label lblTotal;
        private GroupBox groupAnnotation;
        private TextBox txtAnnotation;
        private Button btnSave;
        private Button btnCancel;
    }
}