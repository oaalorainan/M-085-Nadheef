using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HHackathon_Waste.BinSimulator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand comm;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBtn_Click(object sender, ImageClickEventArgs e)
        {
            conn.Open();
            comm = new SqlCommand("update WBin set createDate = @createDate, status = @status, Waste_Level = @Waste_Level, PickupDate = @PickupDate, solids = @solids, liquids = @liquids, temperature = @temperature, tilt = @tilt where ID = @ID", conn);
            comm.Parameters.AddWithValue("@ID", ddlBin.SelectedItem.ToString());
            comm.Parameters.AddWithValue("@createDate", DateTime.Now);
            comm.Parameters.AddWithValue("@status", "1");
            comm.Parameters.AddWithValue("@Waste_Level", tbLevel.Text);
            comm.Parameters.AddWithValue("@PickupDate", DateTime.Now);
            comm.Parameters.AddWithValue("@solids", cbxSolid.Checked ? true : false);
            comm.Parameters.AddWithValue("@liquids", cbxLiquid.Checked ? true : false);
            comm.Parameters.AddWithValue("@temperature", tbTemp.Text);
            comm.Parameters.AddWithValue("@tilt", tbTilt.Text);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}