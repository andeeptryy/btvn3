using System;
using System.Windows.Forms;

namespace demo3
{
    public partial class Form2 : Form
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public string LuongCB { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtLuongCB.Text, out _))
            {
                MessageBox.Show("Lương cơ bản phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MSNV = txtMSNV.Text.Trim();
            TenNV = txtTenNV.Text.Trim();
            LuongCB = txtLuongCB.Text.Trim();

            this.DialogResult = DialogResult.OK; 
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtMSNV.Text = MSNV;
            txtTenNV.Text = TenNV;
            txtLuongCB.Text = LuongCB;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMSNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
