using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CBlitz.Common
{
   public static class DBCommon
    {
       const  string Cnn = @"Server=DESKTOP-T4F5P7T\SQLEXPRESS;Database=Blitz_Project;User ID=sa;Password=sa_123;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Cnn);
        }

    }
}
