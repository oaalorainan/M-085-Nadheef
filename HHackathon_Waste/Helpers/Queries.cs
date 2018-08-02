using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HHackathon_Waste.Helpers
{
    public class Queries
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand comm;
        SqlDataAdapter dadapter;

        public DataTable GetWBin(string id)
        {
            conn.Open();
            if (!string.IsNullOrEmpty(id))
                dadapter = new SqlDataAdapter("select * from WBin", conn);
            else
            {
                dadapter = new SqlDataAdapter("select * from WBin where ID = @ID", conn);
                dadapter.SelectCommand.Parameters.AddWithValue("@ID", id);
            }
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();

            return table;
        }

        public DataTable GetWBinByLocation(float _lat, float _long)
        {
            conn.Open();
            dadapter = new SqlDataAdapter("select * from WBin where latitute = @latitude and longtitude = @longtitude", conn);
            dadapter.SelectCommand.Parameters.AddWithValue("@latitute", _lat);
            dadapter.SelectCommand.Parameters.AddWithValue("@longtitude", _long);
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();

            return table;
        }

        public DataTable GetWBinByDate(DateTime _pickupDate)
        {
            conn.Open();
            dadapter = new SqlDataAdapter("select * from WBin where createDate = @createDate", conn);
            dadapter.SelectCommand.Parameters.AddWithValue("@createDate", _pickupDate);
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();

            return table;
        }

        public DataTable GetWaste(string _binID)
        {
            conn.Open();
            if (!string.IsNullOrEmpty(_binID))
                dadapter = new SqlDataAdapter("select * from WastePickups", conn);
            else
            {
                dadapter = new SqlDataAdapter("select * from WastePickups where BinID = @BinID", conn);
                dadapter.SelectCommand.Parameters.AddWithValue("@BinID", _binID);
            }
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();

            return table;
        }
    }
}