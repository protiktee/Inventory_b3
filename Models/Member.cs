using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Inventory_b3.Models
{
    public class Member
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string ServiceType { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DashBoardPageURL { get; set; }

        public void ValidateMember(string UserName,string Password)
        { 
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOst_LstMember";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        this.id = Convert.ToInt32(reader["id"].ToString());
                        this.Name = reader["Name"].ToString();
                        this.Age = reader["Age"].ToString();
                        this.ServiceType = reader["ServiceType"].ToString();
                        this.Password = reader["Password"].ToString();
                        this.Role = reader["Role"].ToString();
                        this.DashBoardPageURL = reader["DashBoardPageURL"].ToString();

                    }
                }
                reader.Close();
                //DataTable dt = new DataTable();
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                //sqlDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                
            }
            finally 
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            } 
        }

    }
}