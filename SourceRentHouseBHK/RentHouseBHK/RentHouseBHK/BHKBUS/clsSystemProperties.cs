using RentHouseBHK.BHKDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKBUS
{
    class clsSystemProperties
    {
        /// <summary>Thuộc tính lưu trữ thông tin kết nối database</summary>
        public static clsDatabase objDatabase;

        /// <summary>Thuộc tính xác nhận user đăng nhập là admin</summary>
        public static UsersDTO UserLogin { get; set; }
    }
}
