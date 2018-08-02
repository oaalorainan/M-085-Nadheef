<%@ Page Title="" Language="C#" MasterPageFile="~/Mp.master" AutoEventWireup="true" CodeBehind="ShowBins.aspx.cs" Inherits="HHackathon_Waste.ShowBins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder111" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div class="row">
        <div class="col-lg-10">
            <asp:Literal ID="literal1" runat="server" />
            <div id='map' style='width: 1250px; height: 800px;'></div>
        </div>
        <div class="col-lg-2">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:LinkButton ID="lBtn" runat="server" CssClass="btn btn-primary" OnClick="lBtn_Click">
                        <i class="fa fa-refresh"></i>
                        &nbsp;
                        <asp:Label id="lblLoop" runat="server" Text="Stop Loop" />
                    </asp:LinkButton>
                </div>
            </div>
            <br /><br />
            <div class="card card-info">
                <div class="row">
                    <div class="col-xs-4">
                        <img src="../assets/img/redBin.png" class="img img-responsive" style="padding:5px;"/>
                    </div>
                    <div class="col-xs-8" style="padding:15px;">
                        <span style="top:0; bottom:0;">Limit Reached</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4">
                        <img src="../assets/img/yellowBin.png" class="img img-responsive" style="padding:5px;" />
                    </div>
                    <div class="col-xs-8" style="padding:15px;">
                        Above 75%
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4">
                        <img src="../assets/img/greenBin.png" class="img img-responsive" style="padding:5px;" />
                    </div>
                    <div class="col-xs-8"  style="padding:15px;">
                        Bellow 75%
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:CheckBox ID="cbxShowGraph" runat="server" Text="Show Collection Graph" Font-Size="Large" ForeColor="Gray" AutoPostBack="true" OnCheckedChanged="cbxShowGraph_CheckedChanged" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="98%" CssClass="table table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="No." ReadOnly="True" SortExpression="id" ItemStyle-CssClass="text-center"></asp:BoundField>
                            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description"></asp:BoundField>
                            <asp:BoundField DataField="CurrentWasteLevel" HeaderText="Current Level" SortExpression="CurrentWasteLevel" ItemStyle-CssClass="text-center"></asp:BoundField>
                            <asp:BoundField DataField="CollectCount" HeaderText="Times Collected" ReadOnly="True" SortExpression="CollectCount" ItemStyle-CssClass="text-center"></asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                        <RowStyle BackColor="#EFF3FB"></RowStyle>

                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [id], [description], [CurrentWasteLevel], [CollectCount] FROM [CollectCountView] where status = '1'"></asp:SqlDataSource>
                </div>
            </div>
            <%--<asp:LinkButton ID="lBtn" runat="server" CssClass="fa fa-refresh" Font-Size="Large" ForeColor="#9A9A9A" OnClick="lBtn_Click" Visible="false" />--%>
        </div>
    </div>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="7000"></asp:Timer>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
