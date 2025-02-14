using DTO_BHQA;
using System;
using System.Windows.Forms;

namespace GUI_BHQA
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();


        private void linkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau quenmatkhau = new frmQuenMatKhau();
            quenmatkhau.ShowDialog();
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy dangky = new frmDangKy();
            dangky.ShowDialog();
        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTaiKhoan.Text == "Nhập tài khoản")
            {
                txtTaiKhoan.Text = "";
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Text = "Nhập tài khoản";
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            if (tentk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên mật khẩu!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                string query = "Select * from TaiKhoanDangNhap where TenTK = '" + tentk + "' and MatKhau = '" + matkhau + "'";
                if (modify.taiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form_Khach_Hang frmKH = new Form_Khach_Hang(txtTaiKhoan.Text);

                    frmKH.ShowDialog();
                    this.Hide();
                }
                else if (txtTaiKhoan.Text == "Admin" && txtMatKhau.Text == "123")
                {
                    frmQuanLy frmQuanLy = new frmQuanLy();
                    this.Hide();
                    frmQuanLy.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}