using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuySan.utils
{
    public static class Constants
    {
        public static class Config
        {
            public const string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ql-thuysan.mdf;Integrated Security=True";
        }
        public static class Pages{
            public const string HOME_PAGE = "Trang chủ";
            public const string PRODUTE_PAGE = "Sản phẩm";
            public const string GOODS_PAGE = "Sản phẩm";
            public const string IMPORT_PAGE = "Nhập hàng";
            public const string EXPORT_PAGE = "Xuất hàng";
            public const string CUSTOMER_PAGE = "Khách hàng";
            public const string SUPPLIER_PAGE = "Nhà cung cấp";
        }

    }
}
