using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HHackathon_Waste.Models
{
    public class DB_Class
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand comm;
        SqlDataAdapter dadapter;
        //public DataTable _Select(SqlCommand sqlcmd)
        //{
        //    //using (SqlConnection con = new SqlConnection(connstring))
        //    //{
        //    //    con.Open();
        //    //    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd, con))
        //    //    {
        //    //        DataSet ds = new DataSet();
        //    //        adapter.Fill(ds);
        //    //        //Debug.Assert(ds.Tables.Count == 1);
        //    //        return ds.Tables[0];
        //    //    }
        //    //}
        //}

        public  DataTable Select(SqlCommand CMD)
        {
            dadapter = new SqlDataAdapter();
            CMD.Connection = conn;
            dadapter.SelectCommand = CMD;
            
            conn.Open();
            
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();
            return table;
        }
    }
}