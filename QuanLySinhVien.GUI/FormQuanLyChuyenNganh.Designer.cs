namespace QuanLySinhVien.GUI
{
    partial class FormQuanLyChuyenNganh
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
            gpbThongTin = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboKhoa = new ComboBox();
            lblKhoa = new Label();
            txtTenChuyenNganh = new TextBox();
            lblTenChuyenNganh = new Label();
            pnlDanhSach = new Panel();
            dgvChuyenNganh = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTenChuyenNganh = new DataGridViewTextBoxColumn();
            colKhoa = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            pnlTieuDe.SuspendLayout();
            gpbThongTin.SuspendLayout();
            pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenNganh).BeginInit();
            SuspendLayout();
            //
            // pnlTieuDe
            //
            pnlTieuDe.BackColor = Color.FromArgb(232, 240, 254);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(1082, 80);
            pnlTieuDe.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.FromArgb(13, 71, 161);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1082, 80);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ CHUYÊN NGÀNH";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // gpbThongTin
            //
            gpbThongTin.Controls.Add(btnLamMoi);
            gpbThongTin.Controls.Add(btnXoa);
            gpbThongTin.Controls.Add(btnSua);
            gpbThongTin.Controls.Add(btnThem);
            gpbThongTin.Controls.Add(cboKhoa);
            gpbThongTin.Controls.Add(lblKhoa);
            gpbThongTin.Controls.Add(txtTenChuyenNganh);
            gpbThongTin.Controls.Add(lblTenChuyenNganh);
            gpbThongTin.Dock = DockStyle.Left;
            gpbThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpbThongTin.Location = new Point(0, 80);
            gpbThongTin.Name = "gpbThongTin";
            gpbThongTin.Padding = new Padding(10);
            gpbThongTin.Size = new Size(360, 573);
            gpbThongTin.TabIndex = 1;
            gpbThongTin.TabStop = false;
            gpbThongTin.Text = "Thông Tin Chuyên Ngành";
            //
            // lblTenChuyenNganh
            //
            lblTenChuyenNganh.AutoSize = true;
            lblTenChuyenNganh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenChuyenNganh.Location = new Point(21, 47);
            lblTenChuyenNganh.Name = "lblTenChuyenNganh";
            lblTenChuyenNganh.Size = new Size(132, 20);
            lblTenChuyenNganh.TabIndex = 0;
            lblTenChuyenNganh.Text = "Tên chuyên ngành:";
            //
            // txtTenChuyenNganh
            //
            txtTenChuyenNganh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenChuyenNganh.Location = new Point(21, 74);
            txtTenChuyenNganh.Name = "txtTenChuyenNganh";
            txtTenChuyenNganh.Size = new Size(316, 27);
            txtTenChuyenNganh.TabIndex = 1;
            //
            // lblKhoa
            //
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKhoa.Location = new Point(21, 125);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(45, 20);
            lblKhoa.TabIndex = 2;
            lblKhoa.Text = "Khoa:";
            //
            // cboKhoa
            //
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(21, 152);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(316, 28);
            cboKhoa.TabIndex = 3;
            //
            // btnThem
            //
            btnThem.BackColor = Color.FromArgb(25, 135, 84);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(21, 215);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 45);
            btnThem.TabIndex = 4;
            btnThem.Text = "+ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            //
            // btnSua
            //
            btnSua.BackColor = Color.FromArgb(13, 110, 253);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(187, 215);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 45);
            btnSua.TabIndex = 5;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            //
            // btnXoa
            //
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(21, 274);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 45);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "✕ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            //
            // btnLamMoi
            //
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(187, 274);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 45);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            //
            // pnlDanhSach
            //
            pnlDanhSach.Controls.Add(dgvChuyenNganh);
            pnlDanhSach.Controls.Add(lblTongSo);
            pnlDanhSach.Dock = DockStyle.Fill;
            pnlDanhSach.Location = new Point(360, 80);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Padding = new Padding(12, 8, 12, 12);
            pnlDanhSach.Size = new Size(722, 573);
            pnlDanhSach.TabIndex = 2;
            //
            // lblTongSo
            //
            lblTongSo.Dock = DockStyle.Top;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSo.ForeColor = Color.FromArgb(13, 71, 161);
            lblTongSo.Location = new Point(12, 8);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(698, 32);
            lblTongSo.TabIndex = 0;
            lblTongSo.Text = "Tổng số Chuyên ngành: 0";
            lblTongSo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvChuyenNganh
            //
            dgvChuyenNganh.AllowUserToAddRows = false;
            dgvChuyenNganh.AllowUserToDeleteRows = false;
            dgvChuyenNganh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenNganh.BackgroundColor = Color.White;
            dgvChuyenNganh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenNganh.Columns.AddRange(new DataGridViewColumn[] { colId, colTenChuyenNganh, colKhoa });
            dgvChuyenNganh.Dock = DockStyle.Fill;
            dgvChuyenNganh.Location = new Point(12, 40);
            dgvChuyenNganh.MultiSelect = false;
            dgvChuyenNganh.Name = "dgvChuyenNganh";
            dgvChuyenNganh.ReadOnly = true;
            dgvChuyenNganh.RowHeadersVisible = false;
            dgvChuyenNganh.RowHeadersWidth = 51;
            dgvChuyenNganh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenNganh.Size = new Size(698, 521);
            dgvChuyenNganh.TabIndex = 1;
            //
            // colId
            //
            colId.FillWeight = 40F;
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            //
            // colTenChuyenNganh
            //
            colTenChuyenNganh.FillWeight = 150F;
            colTenChuyenNganh.HeaderText = "Chuyên ngành";
            colTenChuyenNganh.MinimumWidth = 6;
            colTenChuyenNganh.Name = "colTenChuyenNganh";
            colTenChuyenNganh.ReadOnly = true;
            //
            // colKhoa
            //
            colKhoa.FillWeight = 120F;
            colKhoa.HeaderText = "Khoa";
            colKhoa.MinimumWidth = 6;
            colKhoa.Name = "colKhoa";
            colKhoa.ReadOnly = true;
            //
            // FormQuanLyChuyenNganh
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(pnlDanhSach);
            Controls.Add(gpbThongTin);
            Controls.Add(pnlTieuDe);
            MinimumSize = new Size(900, 550);
            Name = "FormQuanLyChuyenNganh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Chuyên ngành";
            pnlTieuDe.ResumeLayout(false);
            gpbThongTin.ResumeLayout(false);
            gpbThongTin.PerformLayout();
            pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenNganh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTieuDe;
        private Label lblTieuDe;
        private GroupBox gpbThongTin;
        private Label lblTenChuyenNganh;
        private TextBox txtTenChuyenNganh;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlDanhSach;
        private Label lblTongSo;
        private DataGridView dgvChuyenNganh;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTenChuyenNganh;
        private DataGridViewTextBoxColumn colKhoa;
    }
}
