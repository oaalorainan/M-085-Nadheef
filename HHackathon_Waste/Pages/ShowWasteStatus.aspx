<%@ Page Title="" Language="C#" MasterPageFile="~/Mp.master" AutoEventWireup="true" CodeBehind="ShowWasteStatus.aspx.cs" Inherits="HHackathon_Waste.Pages.ShowWasteStatus" %>
 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder111" runat="server">
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>

    <div class="row">
        <div class="col-xs-6">
            <div class="card">
                <div class="header"></div>
                <div class="content">
                    <canvas id="myChart" style="width: 50px !important"></canvas>
                    <asp:Literal ID="LiteralLinear" runat="server"></asp:Literal>
                </div>
            </div>

        </div>
          <div class="col-xs-6">
            <div class="card">
                <div class="header"></div>
                <div class="content">
                    <canvas id="myChart1" style="width: 50px !important"></canvas>
                  <%--  <script>
                        var ctx = document.getElementById("myChart1").getContext('2d');
                        var myChart = new Chart(ctx, {
                            type: 'pie',
                            data: {
                                labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
                                datasets: [{
                                    label: '# of Votes',
                                    data: [12, 19, 3, 5, 2, 3],
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
                            options: {
                                scales: {
                                    yAxes: [{
                                        ticks: {
                                            beginAtZero: true
                                        }
                                    }]
                                }
                            }
                        });
                    </script>--%>
                                        <asp:Literal ID="LiteralSecond" runat="server"></asp:Literal>


                </div>
            </div>

        </div>

    </div>
 </asp:Content>
