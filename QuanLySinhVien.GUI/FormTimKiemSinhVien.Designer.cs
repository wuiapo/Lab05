namespace QuanLySinhVien.GUI
{
    partial class FormTimKiemSinhVien
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
            pnlBoLoc = new Panel();
            btnXoaBoLoc = new Button();
            chkBaoGomChuaCoDiem = new CheckBox();
            nudDiemDen = new NumericUpDown();
            lblDen = new Label();
            nudDiemTu = new NumericUpDown();
            lblDiemTu = new Label();
            cboKhoa = new ComboBox();
            lblKhoa = new Label();
            txtTuKhoa = new TextBox();
            lblTuKhoa = new Label();
            pnlKetQua = new Panel();
            dgvKetQua = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colMaSV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colDiemTB = new DataGridViewTextBoxColumn();
            colKhoa = new DataGridViewTextBoxColumn();
            lblKetQua = new Label();
            pnlTieuDe.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiemDen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemTu).BeginInit();
            pnlKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();
            //
            // pnlTieuDe
            //
            pnlTieuDe.BackColor = Color.FromArgb(232, 240, 254);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(982, 80);
            pnlTieuDe.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.FromArgb(13, 71, 161);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(982, 80);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "TRA CỨU SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlBoLoc
            //
            pnlBoLoc.BackColor = Color.White;
            pnlBoLoc.Controls.Add(btnXoaBoLoc);
            pnlBoLoc.Controls.Add(chkBaoGomChuaCoDiem);
            pnlBoLoc.Controls.Add(nudDiemDen);
            pnlBoLoc.Controls.Add(lblDen);
            pnlBoLoc.Controls.Add(nudDiemTu);
            pnlBoLoc.Controls.Add(lblDiemTu);
            pnlBoLoc.Controls.Add(cboKhoa);
            pnlBoLoc.Controls.Add(lblKhoa);
            pnlBoLoc.Controls.Add(txtTuKhoa);
            pnlBoLoc.Controls.Add(lblTuKhoa);
            pnlBoLoc.Dock = DockStyle.Top;
            pnlBoLoc.Location = new Point(0, 80);
            pnlBoLoc.Name = "pnlBoLoc";
            pnlBoLoc.Size = new Size(982, 190);
            pnlBoLoc.TabIndex = 1;
            //
            // lblTuKhoa
            //
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(20, 22);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(113, 20);
            lblTuKhoa.TabIndex = 0;
            lblTuKhoa.Text = "Mã SV / Họ tên:";
            //
            // txtTuKhoa
            //
            txtTuKhoa.Location = new Point(160, 19);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập Mã SV hoặc Họ tên...";
            txtTuKhoa.Size = new Size(380, 27);
            txtTuKhoa.TabIndex = 1;
            //
            // lblKhoa
            //
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(20, 62);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(45, 20);
            lblKhoa.TabIndex = 2;
            lblKhoa.Text = "Khoa:";
            //
            // cboKhoa
            //
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(160, 59);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(380, 28);
            cboKhoa.TabIndex = 3;
            //
            // lblDiemTu
            //
            lblDiemTu.AutoSize = true;
            lblDiemTu.Location = new Point(20, 102);
            lblDiemTu.Name = "lblDiemTu";
            lblDiemTu.Size = new Size(87, 20);
            lblDiemTu.TabIndex = 4;
            lblDiemTu.Text = "Điểm TB từ:";
            //
            // nudDiemTu
            //
            nudDiemTu.DecimalPlaces = 1;
            nudDiemTu.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudDiemTu.Location = new Point(160, 100);
            nudDiemTu.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiemTu.Name = "nudDiemTu";
            nudDiemTu.Size = new Size(80, 27);
            nudDiemTu.TabIndex = 5;
            //
            // lblDen
            //
            lblDen.AutoSize = true;
            lblDen.Location = new Point(255, 102);
            lblDen.Name = "lblDen";
            lblDen.Size = new Size(36, 20);
            lblDen.TabIndex = 6;
            lblDen.Text = "đến:";
            //
            // nudDiemDen
            //
            nudDiemDen.DecimalPlaces = 1;
            nudDiemDen.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudDiemDen.Location = new Point(300, 100);
            nudDiemDen.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiemDen.Name = "nudDiemDen";
            nudDiemDen.Size = new Size(80, 27);
            nudDiemDen.TabIndex = 7;
            nudDiemDen.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // chkBaoGomChuaCoDiem
            //
            chkBaoGomChuaCoDiem.AutoSize = true;
            chkBaoGomChuaCoDiem.Checked = true;
            chkBaoGomChuaCoDiem.CheckState = CheckState.Checked;
            chkBaoGomChuaCoDiem.Location = new Point(20, 145);
            chkBaoGomChuaCoDiem.Name = "chkBaoGomChuaCoDiem";
            chkBaoGomChuaCoDiem.Size = new Size(206, 24);
            chkBaoGomChuaCoDiem.TabIndex = 8;
            chkBaoGomChuaCoDiem.Text = "Bao gồm SV chưa có điểm";
            chkBaoGomChuaCoDiem.UseVisualStyleBackColor = true;
            //
            // btnXoaBoLoc
            //
            btnXoaBoLoc.BackColor = Color.FromArgb(108, 117, 125);
            btnXoaBoLoc.FlatAppearance.BorderSize = 0;
            btnXoaBoLoc.FlatStyle = FlatStyle.Flat;
            btnXoaBoLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaBoLoc.ForeColor = Color.White;
            btnXoaBoLoc.Location = new Point(300, 140);
            btnXoaBoLoc.Name = "btnXoaBoLoc";
            btnXoaBoLoc.Size = new Size(140, 34);
            btnXoaBoLoc.TabIndex = 9;
            btnXoaBoLoc.Text = "↺ Xóa bộ lọc";
            btnXoaBoLoc.UseVisualStyleBackColor = false;
            //
            // pnlKetQua
            //
            pnlKetQua.BackColor = Color.FromArgb(245, 247, 250);
            pnlKetQua.Controls.Add(dgvKetQua);
            pnlKetQua.Controls.Add(lblKetQua);
            pnlKetQua.Dock = DockStyle.Fill;
            pnlKetQua.Location = new Point(0, 270);
            pnlKetQua.Name = "pnlKetQua";
            pnlKetQua.Padding = new Padding(15);
            pnlKetQua.Size = new Size(982, 403);
            pnlKetQua.TabIndex = 2;
            //
            // lblKetQua
            //
            lblKetQua.Dock = DockStyle.Top;
            lblKetQua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKetQua.ForeColor = Color.FromArgb(13, 71, 161);
            lblKetQua.Location = new Point(15, 15);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(952, 32);
            lblKetQua.TabIndex = 0;
            lblKetQua.Text = "Tìm thấy: 0 sinh viên";
            lblKetQua.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvKetQua
            //
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.BackgroundColor = Color.White;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { colId, colMaSV, colHoTen, colNgaySinh, colGioiTinh, colDiemTB, colKhoa });
            dgvKetQua.Dock = DockStyle.Fill;
            dgvKetQua.Location = new Point(15, 47);
            dgvKetQua.MultiSelect = false;
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.ReadOnly = true;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.RowHeadersWidth = 51;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.Size = new Size(952, 341);
            dgvKetQua.TabIndex = 1;
            //
            // colId
            //
            colId.FillWeight = 50F;
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            //
            // colMaSV
            //
            colMaSV.HeaderText = "Mã SV";
            colMaSV.MinimumWidth = 6;
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            //
            // colHoTen
            //
            colHoTen.FillWeight = 140F;
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 6;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            //
            // colNgaySinh
            //
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 6;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            //
            // colGioiTinh
            //
            colGioiTinh.FillWeight = 70F;
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 6;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            //
            // colDiemTB
            //
            colDiemTB.FillWeight = 70F;
            colDiemTB.HeaderText = "Điểm TB";
            colDiemTB.MinimumWidth = 6;
            colDiemTB.Name = "colDiemTB";
            colDiemTB.ReadOnly = true;
            //
            // colKhoa
            //
            colKhoa.FillWeight = 140F;
            colKhoa.HeaderText = "Khoa";
            colKhoa.MinimumWidth = 6;
            colKhoa.Name = "colKhoa";
            colKhoa.ReadOnly = true;
            //
            // FormTimKiemSinhVien
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 673);
            Controls.Add(pnlKetQua);
            Controls.Add(pnlBoLoc);
            Controls.Add(pnlTieuDe);
            MinimumSize = new Size(800, 550);
            Name = "FormTimKiemSinhVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tra cứu Sinh viên";
            pnlTieuDe.ResumeLayout(false);
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiemDen).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemTu).EndInit();
            pnlKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTieuDe;
        private Label lblTieuDe;
        private Panel pnlBoLoc;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Label lblDiemTu;
        private NumericUpDown nudDiemTu;
        private Label lblDen;
        private NumericUpDown nudDiemDen;
        private CheckBox chkBaoGomChuaCoDiem;
        private Button btnXoaBoLoc;
        private Panel pnlKetQua;
        private Label lblKetQua;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colDiemTB;
        private DataGridViewTextBoxColumn colKhoa;
    }
}
