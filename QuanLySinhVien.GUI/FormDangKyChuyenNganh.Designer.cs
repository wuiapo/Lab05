namespace QuanLySinhVien.GUI
{
    partial class FormDangKyChuyenNganh
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTieuDe = new Panel();
            lblTieuDe = new Label();
            lblSinhVien = new Label();
            cboSinhVien = new ComboBox();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            lblChuyenNganh = new Label();
            cboChuyenNganh = new ComboBox();
            lblHienTaiTieuDe = new Label();
            lblHienTai = new Label();
            btnDangKy = new Button();
            btnDong = new Button();
            pnlTieuDe.SuspendLayout();
            SuspendLayout();
            //
            // pnlTieuDe
            //
            pnlTieuDe.BackColor = Color.FromArgb(232, 240, 254);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(562, 72);
            pnlTieuDe.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.FromArgb(13, 71, 161);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(562, 72);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÝ CHUYÊN NGÀNH CHO SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblSinhVien
            //
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(30, 92);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(116, 20);
            lblSinhVien.TabIndex = 1;
            lblSinhVien.Text = "Chọn sinh viên:";
            //
            // cboSinhVien
            //
            cboSinhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSinhVien.FormattingEnabled = true;
            cboSinhVien.Location = new Point(30, 117);
            cboSinhVien.Name = "cboSinhVien";
            cboSinhVien.Size = new Size(500, 28);
            cboSinhVien.TabIndex = 2;
            //
            // lblKhoa
            //
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(30, 162);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(45, 20);
            lblKhoa.TabIndex = 3;
            lblKhoa.Text = "Khoa:";
            //
            // cboKhoa
            //
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(30, 187);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(500, 28);
            cboKhoa.TabIndex = 4;
            //
            // lblChuyenNganh
            //
            lblChuyenNganh.AutoSize = true;
            lblChuyenNganh.Location = new Point(30, 232);
            lblChuyenNganh.Name = "lblChuyenNganh";
            lblChuyenNganh.Size = new Size(104, 20);
            lblChuyenNganh.TabIndex = 5;
            lblChuyenNganh.Text = "Chuyên ngành:";
            //
            // cboChuyenNganh
            //
            cboChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChuyenNganh.FormattingEnabled = true;
            cboChuyenNganh.Location = new Point(30, 257);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(500, 28);
            cboChuyenNganh.TabIndex = 6;
            //
            // lblHienTaiTieuDe
            //
            lblHienTaiTieuDe.AutoSize = true;
            lblHienTaiTieuDe.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHienTaiTieuDe.ForeColor = Color.Gray;
            lblHienTaiTieuDe.Location = new Point(30, 302);
            lblHienTaiTieuDe.Name = "lblHienTaiTieuDe";
            lblHienTaiTieuDe.Size = new Size(165, 20);
            lblHienTaiTieuDe.TabIndex = 7;
            lblHienTaiTieuDe.Text = "Chuyên ngành hiện tại:";
            //
            // lblHienTai
            //
            lblHienTai.AutoEllipsis = true;
            lblHienTai.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHienTai.ForeColor = Color.FromArgb(13, 71, 161);
            lblHienTai.Location = new Point(200, 302);
            lblHienTai.Name = "lblHienTai";
            lblHienTai.Size = new Size(330, 26);
            lblHienTai.TabIndex = 8;
            lblHienTai.Text = "Chưa đăng ký";
            //
            // btnDangKy
            //
            btnDangKy.BackColor = Color.FromArgb(25, 135, 84);
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangKy.ForeColor = Color.White;
            btnDangKy.Location = new Point(130, 350);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 48);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "✔ Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            //
            // btnDong
            //
            btnDong.BackColor = Color.FromArgb(108, 117, 125);
            btnDong.DialogResult = DialogResult.Cancel;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(292, 350);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(120, 48);
            btnDong.TabIndex = 10;
            btnDong.Text = "✕ Đóng";
            btnDong.UseVisualStyleBackColor = false;
            //
            // FormDangKyChuyenNganh
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnDong;
            ClientSize = new Size(562, 425);
            Controls.Add(btnDong);
            Controls.Add(btnDangKy);
            Controls.Add(lblHienTai);
            Controls.Add(lblHienTaiTieuDe);
            Controls.Add(cboChuyenNganh);
            Controls.Add(lblChuyenNganh);
            Controls.Add(cboKhoa);
            Controls.Add(lblKhoa);
            Controls.Add(cboSinhVien);
            Controls.Add(lblSinhVien);
            Controls.Add(pnlTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDangKyChuyenNganh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký Chuyên ngành";
            pnlTieuDe.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTieuDe;
        private Label lblTieuDe;
        private Label lblSinhVien;
        private ComboBox cboSinhVien;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Label lblChuyenNganh;
        private ComboBox cboChuyenNganh;
        private Label lblHienTaiTieuDe;
        private Label lblHienTai;
        private Button btnDangKy;
        private Button btnDong;
    }
}
