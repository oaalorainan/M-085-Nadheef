using HHackathon_Waste.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHackathon_Waste.Pages
{
    public partial class ShowWasteStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable DTLinear = GetWastesByMaxLevel();

            string BinsW_LevelList = string.Join(", ", DTLinear.Rows.OfType<DataRow>().Select(r => r["Waste_Level"].ToString()));
            string BinsDescList = string.Join(", ", DTLinear.Rows.OfType<DataRow>().Select(r => @"""" + r["description"].ToString() + @""""));



            DataTable DTSecond = GetCountOfCollections();
            LinearChart(BinsW_LevelList, BinsDescList); 

                 string BinsCollectionCountList = string.Join(", ", DTSecond.Rows.OfType<DataRow>().Select(r => r["CollectCount"].ToString()));
            string BinsSecondDescList = string.Join(", ", DTSecond.Rows.OfType<DataRow>().Select(r => @"""" + r["description"].ToString() + @""""));
            SecondChart(BinsCollectionCountList, BinsSecondDescList);


        }

        private void LinearChart(string BinsW_LevelList, string BinsDescList)
        {
            StringBuilder strB = new StringBuilder();
            strB.Append(@"                    <script>
                        var ctx = document.getElementById(""myChart"").getContext('2d');
            var myChart = new Chart(ctx, {
                            type: 'line',
                            data:
            {" +
            "labels: [" + BinsDescList + "]," +
                                @"datasets: [{
            label: 'Collective Waste levels',
                                    data: [" + BinsW_LevelList + @"],
                                    backgroundColor: [
                                        'rgba(255, 99, 132, 0.2)',
                                        'rgba(54, 162, 235, 0.2)',
                                        'rgba(255, 206, 86, 0.2)',
                                        'rgba(75, 192, 192, 0.2)',
                                        'rgba(153, 102, 255, 0.2)',
                                        'rgba(255, 159, 64, 0.2)'
                                    ],
                                    borderColor: [
                                        'rgba(255,99,132,1)',
                                        'rgba(54, 162, 235, 1)',
                                        'rgba(255, 206, 86, 1)',
                                        'rgba(75, 192, 192, 1)',
                                        'rgba(153, 102, 255, 1)',
                                        'rgba(255, 159, 64, 1)'
                                    ],
                                    borderWidth: 1
                                }]
                            },
                            options:
            {
            scales:
                {
                yAxes: [{
                    ticks:
                        {
                        beginAtZero: true
                                        }
}]
                                }
            }
        });
                    </script>");
            LiteralLinear.Text = strB.ToString();
        }
        private void SecondChart(string BinsCollectList, string BinsDescList)
        {
            StringBuilder strB = new StringBuilder();
            strB.Append(@"                    <script>
                        var ctx = document.getElementById(""myChart1"").getContext('2d');
            var myChart = new Chart(ctx, {
                            type: 'pie',
                            data:
            {" +
            "labels: [" + BinsDescList + "]," +
                                @"datasets: [{
            label: 'Collective Waste Counts',
                                    data: [" + BinsCollectList + @"],
                                    backgroundColor: [
                                        'rgba(255, 99, 132, 0.2)',
                                        'rgba(54, 162, 235, 0.2)',
                                        'rgba(255, 206, 86, 0.2)',
                                        'rgba(75, 192, 192, 0.2)',
                                        'rgba(153, 102, 255, 0.2)',
                                        'rgba(255, 159, 64, 0.2)'
                                    ],
                                    borderColor: [
                                        'rgba(255,99,132,1)',
                                        'rgba(54, 162, 235, 1)',
                                        'rgba(255, 206, 86, 1)',
                                        'rgba(75, 192, 192, 1)',
                                        'rgba(153, 102, 255, 1)',
                                        'rgba(255, 159, 64, 1)'
                                    ],
                                    borderWidth: 1
                                }]
                            } 
    
        });
                    </script>");
            LiteralSecond.Text = strB.ToString();
        }

        private static DataTable GetWastesByMaxLevel()
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @" select   * from wbin  ";/* P join WBin W on W.id */
           


            DataTable DT = new DB_Class().Select(CMD);
            return DT;
        }

        private static DataTable GetCountOfCollections()
        {
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = @" select   * from CollectCountView  ";/* P join WBin W on W.id */



            DataTable DT = new DB_Class().Select(CMD);
            return DT;
        }
    }
}