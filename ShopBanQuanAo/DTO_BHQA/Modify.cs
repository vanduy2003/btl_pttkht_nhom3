﻿using System.Collections.Generic;
using System.Data.SqlClient;

namespace DTO_BHQA
{
    public class Modify
    {

        public Modify()
        {

        }

        SqlCommand SqlCommand; // dung de truy van cac cau lenh insert, update,delete...
        SqlDataReader dataReader; // dung de doc du lieu trong bang

        // tạo một list tài khoản 
        public List<TaiKhoan> taiKhoans(string query)  // dung check tai khoan
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            // khi using thực thi phần trong ngoăc thì nó sẽ xóa hết đối tượng ở trên 
            using (SqlConnection sqlConnection = DBConnect.chuoiKetNoiCua_Hai())
            {
                sqlConnection.Open();  // mở kết nối 
                SqlCommand = new SqlCommand(query, sqlConnection); // khởi tạo sqlcommand 
                dataReader = SqlCommand.ExecuteReader();      // tạo dâtreader để tiến hành đọc dữ liệu 
                while (dataReader.Read())
                {            // đọc từng dòng dữ liệu rồi add vào list tài khoản
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(3)));
                }

                sqlConnection.Close(); // đóng kết nối 
            }
            return taiKhoans;   // trả về list tài khoản
        }

        public void Command(string query)  // dung de dang ki tai khoan
        {
            using (SqlConnection sqlConnection = DBConnect.chuoiKetNoiCua_Hai())
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand(query, sqlConnection);
                SqlCommand.ExecuteNonQuery(); // thuc thi cau truy van
                sqlConnection.Close();
            }
        }

    }
}
