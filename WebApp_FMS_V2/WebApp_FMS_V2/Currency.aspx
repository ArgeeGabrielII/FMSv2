<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="Currency.aspx.cs" Inherits="WebApp_FMS_V2.Currency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Currency - Requisition System
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
        <div class="col-md-10">
            <ul class="breadcrumb">
                <li><a href="Home">Home</a></li>
                <li>Administator</li>
                <li>Data Management</li>
                <li>Currency</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnCurrency_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnCurrency_Create_Click" />
            <asp:Button ID="btnCurrency_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnCurrency_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvCurrency" runat="server">
        <asp:View ID="vwViewCurrency" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Currency</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtCurrency_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkCurrency_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkCurrency_Search_Click" >
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvCurrencyList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="10"
                                HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvCurrencyList_RowCommand" OnPageIndexChanging="gvCurrencyList_PageIndexChanging"
                                OnSelectedIndexChanged="gvCurrencyList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="CurrencyID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CurrencyCode" HeaderText="CurrencyCode" />
                                    <asp:BoundField DataField="CurrencyName" HeaderText="CurrencyName" />

                                    <asp:TemplateField ItemStyle-Width="5%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CausesValidation="false" CommandName="Select" CssClass="btn btn-primary" title="Select"
                                                CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-th-list"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No data found.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwDetailsCurrency" runat="server">
            <asp:HiddenField ID="hfCurrencyID" runat="server" Visible="false" />
            <h4>Currency Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblCurrencyDetails_Code" runat="server" Text="Code **" />
                    <asp:TextBox ID="txtCurrencyDetails_Code" runat="server" CssClass="form-control" placeholder="Code" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCurrencyDetails_Currency" runat="server" Text="Currency **" />
                    <asp:TextBox ID="txtCurrencyDetails_Currency" runat="server" CssClass="form-control" placeholder="Currency" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblCurrencyDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnCurrencyDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnCurrencyDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnCurrencyDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnCurrencyDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblCurrencyDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblCurrencyDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnCurrencyDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnCurrencyDetails_SaveYes_Click" />
                            <asp:Button ID="btnCurrencyDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnCurrencyDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnCurrencyDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnCurrencyDetails_No_Click" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
