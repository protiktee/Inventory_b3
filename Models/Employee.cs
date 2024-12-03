using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventory_b3.Models
{
    public class Employee
    {
        public static DataTable ListEmpAssignHist()
        {
            DataTable dt = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOst_LstCustomerEquiAssignment"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                ////CustomerID	CustomerName	CustomerMobile	CustAddress	EquiCount	EquipmentName 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt); 
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dt;
        }

        public static int SaveAssingment(int CustomerID, int EquipmentID, int EquiCount)
        {
            int ReturnCase = 0;
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOST_InsEquiAssignment";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                cmd.Parameters.Add(new SqlParameter("@EquipmentID", EquipmentID));
                cmd.Parameters.Add(new SqlParameter("@EquiCount", EquiCount));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                ReturnCase = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return ReturnCase;
        }
    }
}