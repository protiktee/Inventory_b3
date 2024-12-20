﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace Inventory_b3.Models
{
    [Serializable]
    public class EquipmentN
    {
        //[DataMember]
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReceiveDate { get; set; } 
        public List<EquipmentN> ListEquipment()
        {
            List<EquipmentN> equipment = new List<EquipmentN>();  
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOST_LstEquipment";
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                //cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        EquipmentN objBaseEquipment = new EquipmentN();
                        objBaseEquipment.EquipmentId= Convert.ToInt32(reader["EquipmentId"].ToString());
                        objBaseEquipment.EquipmentName = reader["EquipmentName"].ToString();
                        objBaseEquipment.Quantity= Convert.ToInt32(reader["Quantity"].ToString());
                        objBaseEquipment.Stock= Convert.ToInt32(reader["Stock"].ToString());
                        objBaseEquipment.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                        objBaseEquipment.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"]);
                        equipment.Add(objBaseEquipment);
                    }
                }
                reader.Close();
                //DataTable dt = new DataTable();
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                //sqlDataAdapter.Fill(dt);
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
            return equipment;
        }

        public int SaveEquipment()
        {
            int ReturnCase = 0;
            string ConnString = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "spOST_InsEquipment";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Name", this.EquipmentName));
                cmd.Parameters.Add(new SqlParameter("@EcCount", this.Quantity)); 
                cmd.Parameters.Add(new SqlParameter("@ReceiveDate", this.ReceiveDate));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                ReturnCase=cmd.ExecuteNonQuery();
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