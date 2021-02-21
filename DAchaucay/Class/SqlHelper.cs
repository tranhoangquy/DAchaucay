using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAchaucay.Class
{
    class SqlHelper
    {
        public static int loainguoidung;
        public static string tennguoidung;
        public static string ConnectString = @"Data Source=DESKTOP-PF3DC38\SQLEXPRESS;Initial Catalog=QLquatrinhbanhang;Integrated Security=True";
        public static SqlConnection con;
    }
}
