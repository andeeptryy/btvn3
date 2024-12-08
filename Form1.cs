using System;
using System.Windows.Forms;

namespace demo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView(); 
        }

        
        private void InitializeDataGridView()
        {
            
            dataGridView1.Columns.Clear();

            
            dataGridView1.Columns.Add("MSNV", "Mã Số Nhân Viên");
            dataGridView1.Columns.Add("TenNV", "Tên Nhân Viên");
            dataGridView1.Columns.Add("LuongCB", "Lương Cơ Bản");

            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dataGridView1.MultiSelect = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); 
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(frm.MSNV) || string.IsNullOrWhiteSpace(frm.TenNV) || string.IsNullOrWhiteSpace(frm.LuongCB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridView1.Rows.Add(frm.MSNV, frm.TenNV, frm.LuongCB);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dongChon = dataGridView1.SelectedRows[0];

                if (!dongChon.IsNewRow)
                {
                    if (dongChon.Cells[0].Value == null || dongChon.Cells[1].Value == null || dongChon.Cells[2].Value == null)
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Form2 frm = new Form2
                    {
                        MSNV = dongChon.Cells[0].Value?.ToString(),
                        TenNV = dongChon.Cells[1].Value?.ToString(),
                        LuongCB = dongChon.Cells[2].Value?.ToString()
                    };

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dongChon.Cells[0].Value = frm.MSNV;
                        dongChon.Cells[1].Value = frm.TenNV;
                        dongChon.Cells[2].Value = frm.LuongCB;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể sửa dòng trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng nào để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
