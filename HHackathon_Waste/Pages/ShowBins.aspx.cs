using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace HHackathon_Waste
{
    public partial class ShowBins : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter dadapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString["Q"];
            if (!string.IsNullOrEmpty(q))
                GridView1.Visible = true;
            else
                GridView1.Visible = false;

            if (!IsPostBack)
                literal1.Text = "<div id='map' style='width: 1250px; height: 800px;'></div>" + ShowBinsOnMap();
            
        }

        public string ShowBinsOnMap()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            conn.ConnectionString = connString;
            conn.Open();
            dadapter = new SqlDataAdapter("select * from CollectCountView", conn);
            DataTable table = new DataTable();
            dadapter.Fill(table);
            conn.Close();

            #region --GOOGLE MAPS API--
            
            //literal1.Text = "<div id='map' style='width: 1250px; height: 800px;'></div>" +
            literal1.Text= "<script type='text/javascript'>" +
            "var locations = [";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                literal1.Text += "['<p style=\"font-weight:bold; background-color:#7A9FAF; color:White; padding-left:3px; padding-right:3px;\">" + table.Rows[i]["description"].ToString() + "</p><br/>" +
                    "Current Waste Level: " + table.Rows[i]["CurrentWasteLevel"].ToString() + "%<br/>" +
                    "Total Number of Pickups: " + table.Rows[i]["CollectCount"].ToString() + "<br/>" +
                    "Has Solid Content: " + (table.Rows[i]["Currentsolids"].ToString() == "1" ? "Yes" : "No") + "<br/>" +
                    "Has Liquid Content: " + (table.Rows[i]["Currentliquids"].ToString() == "1" ? "Yes" : "No") + "<br/>'," +
                    table.Rows[i]["latitute"].ToString() + "," + table.Rows[i]["longitude"].ToString() + "," +
                    i + "],";
            }

            literal1.Text += "];" +
            "var iconURLPrefix = 'http://maps.google.com/mapfiles/ms/icons/';" +
            "var collectionRadius = {";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                literal1.Text +=
            "pin" + i + ": {" +
             " center: {lat: " + table.Rows[i]["latitute"].ToString() + ", lng: " + table.Rows[i]["longitude"].ToString() + "}," +
              "count: " + table.Rows[i]["CollectCount"].ToString() +
            "},";
          }

            literal1.Text +="};"+
                "var iconBase='../assets/img/';" +
            "var icons = [" +
                "iconBase + 'redBin.png'," +
                "iconBase + 'yellowBin.png'," +
                "iconBase + 'greenBin.png'," +
            "];" +
            "var iconsLength = icons.length;" +
            "var map = new google.maps.Map(document.getElementById('map'), {" +
              "zoom: 10," +
              "center: new google.maps.LatLng(-37.92, 151.25)," +
              "mapTypeId: google.maps.MapTypeId.ROADMAP," +
              "mapTypeControl: false," +
              "streetViewControl: false," +
              "panControl: false," +
              "zoomControlOptions: {" +
                 "position: google.maps.ControlPosition.LEFT_BOTTOM" +
              "}" +
            "});" +
            "var infowindow = new google.maps.InfoWindow({" +
            "});" +
            "var markers = new Array();" +
            "var iconCounter = 0;";
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                literal1.Text += "var marker = new google.maps.Marker({" +
                  "position: new google.maps.LatLng(locations[" + i + "][1], locations[" + i + "][2])," +
                  "map: map, " +
                  "icon: icons[" + (int.Parse(table.Rows[i]["CurrentWasteLevel"].ToString()) >= int.Parse(table.Rows[i]["noticeLevel"].ToString()) && int.Parse(table.Rows[i]["CurrentWasteLevel"].ToString()) >= int.Parse(table.Rows[i]["pickupLevel"].ToString()) ? "0" : int.Parse(table.Rows[i]["CurrentWasteLevel"].ToString()) >= int.Parse(table.Rows[i]["noticeLevel"].ToString()) ? "1" : "2") + "]" +
                "});" +
                "markers.push(marker); " +
               " google.maps.event.addListener(marker, 'click', (function(marker) { " +
                 " return function() { " +
                   " infowindow.setContent(locations[" + i + "][0]);" +
                   " infowindow.open(map, marker);" +
                 " }" +
                "})(marker));";
            }


            if (cbxShowGraph.Checked)
            {
                literal1.Text += "for (var pickup in collectionRadius)" +
                     "{" +
                     "var cityCircle = new google.maps.Circle({" +
                 "strokeColor: '#c1daee'," +
                 "strokeOpacity: 0.8," +
                 "strokeWeight: 2," +
                 "fillColor: '#c1daee'," +
                 "fillOpacity: 0.35," +
                 "map: map," +
                 "center: collectionRadius[pickup].center," +
                 "radius: collectionRadius[pickup].count * 50" +
               "});" +
             "}";
            }

        literal1.Text += "function autoCenter() {" +
              "var bounds = new google.maps.LatLngBounds();" +
              "for (var i = 0; i < markers.length; i++) {  " +
                        "bounds.extend(markers[i].position);" +
              "}   " +
              "map.fitBounds(bounds);" +
            "}" +
            "autoCenter();" +
            "</script>";
            #endregion

            string _script = literal1.Text;
            return _script;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //ShowBinsOnMap();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowBinsOnMap(), false);
        }

        protected void lBtn_Click(object sender, EventArgs e)
        {
            if (Timer1.Interval == 7000)
            {
                Timer1.Interval = 60000;
                lblLoop.Text = "Start Loop";
            }
            else
            {
                Timer1.Interval = 7000;
                lblLoop.Text = "Stop Loop";
            }
        }
        
        protected void cbxShowGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowGraph.Checked)
                cbxShowGraph.ForeColor = Color.CornflowerBlue;
            else
                cbxShowGraph.ForeColor = Color.Gray;
        }
    }
}