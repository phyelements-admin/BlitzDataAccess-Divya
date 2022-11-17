using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blitz.Models;
using Newtonsoft.Json;
using BlitzCommon;



namespace Blitz.DataAccess
{
    public class ProjectDAO : IProjectDAO   
    {
        public int AddProject(Project p)
        {
            string query = "INSERT INTO Blitz (Id,Name,StartDate) Values (@Id,@Name,@StartDate)";
            using (SqlConnection con = DBCommon.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@Name", p.Name);
                    cmd.Parameters.AddWithValue("@StartDate", p.StartDate);
                    int rowInserted = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int DeleteProject(int id)
        {
            string query = "DELETE FROM Blitz WHERE Id = " + id + " ";
            using (SqlConnection con = DBCommon.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    var i = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public IEnumerable<Project> GetProjectById(int id)
        {
            List<Project> p1 = new List<Project>();
            string query = "SELECT * FROM Blitz WHERE Id = " + id + " ";
            using (SqlConnection con = DBCommon.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            p1.Add(new Project
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = Convert.ToString(sdr["Name"]),
                                StartDate = Convert.ToDateTime(sdr["StartDate"])
                            });
                        }
                    }
                    con.Close();
                }
            }

           return p1;
        }
        public IEnumerable<Project> GetProjects()
            {
            List<Project> p1 = new List<Project>();
            string query = "SELECT * FROM Blitz";
            using (SqlConnection con = DBCommon.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            p1.Add(new Project
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = Convert.ToString(sdr["Name"]),
                                StartDate = Convert.ToDateTime(sdr["StartDate"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            if (p1.Count == 0)
            {
                p1.Add(new Project());
            }
            return p1;
        }
        public int UpdateProject(Project p)
        {
            string query = "UPDATE Blitz SET Name=@name,StartDate=@StartDate WHERE Id=@Id";
            using (SqlConnection con = DBCommon.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("Name", p.Name);
                    cmd.Parameters.AddWithValue("@StartDate", p.StartDate);
                    int i = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }

    }
}
