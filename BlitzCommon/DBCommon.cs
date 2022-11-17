using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzCommon
{
    public static class DBCommon
    {
        const string Cnn = @"Server=DESKTOP-T4F5P7T\SQLEXPRESS;Database=Blitz_Project;User ID=sa;Password=sa_123;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Cnn);
        }
    }
}
