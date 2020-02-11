<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="TransactionLogs.aspx.cs" Inherits="WebApp_FMS_V2.TransactionLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Transaction Logs - Requisition System
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- DataTables CSS -->
    <link href="../assets/vendor/datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- DataTables Responsive CSS -->
    <link href="../assets/vendor/datatables-responsive/dataTables.responsive.css" rel="stylesheet" />
    <!-- Personal CSS -->
    <link href="assets/extra.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-12">
            <ul class="breadcrumb">
                <li><a href="Home">Home</a></li>
                <li>History Logs</li>
                <li>Transaction Logs</li>
            </ul>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-4">
                            <h4>View Transaction Logs</h4>
                        </div>
                        <div class="col-md-4 col-md-offset-4">
                            <div class="form-group input-group mTop3-form-group">
                                <asp:TextBox ID="txtTransactionLogs_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lnkTransactionLogs_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkTransactionLogs_Search_Click">
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div style="width: 100%; overflow-x: scroll;">
                        <asp:GridView runat="server" ID="gvTransactionLogs" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="10"
                            HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowDataBound="gvTransactionLogs_RowDataBound" OnPageIndexChanging="gvTransactionLogs_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:BoundField DataField="UserID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                <asp:BoundField DataField="FormName" HeaderText="FormName" />
                                <asp:BoundField DataField="EventName" HeaderText="EventName" />
                                <asp:BoundField DataField="ExceptionError" HeaderText="ExceptionError" />
                                <asp:BoundField DataField="ComputerName" HeaderText="ComputerName" />
                                <asp:BoundField DataField="IPAddress" HeaderText="IPAddress" />
                                <asp:BoundField DataField="DateTimeLogs" HeaderText="DateTimeLogs" DataFormatString="{0:d}" />
                            </Columns>
                            <EmptyDataTemplate>
                                No data found.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
