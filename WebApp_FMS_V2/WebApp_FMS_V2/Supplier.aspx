<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="WebApp_FMS_V2.Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Supplier - Requisition System
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
                <li>Supplier</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnSupplier_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnSupplier_Create_Click" />
            <asp:Button ID="btnSupplier_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnSupplier_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvSupplier" runat="server">
        <asp:View ID="vwViewSupplier" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Supplier</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtSupplier_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkSupplier_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkSupplier_Search_Click">
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvSupplierList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="10"
                                HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvSupplierList_RowCommand" OnPageIndexChanging="gvSupplierList_PageIndexChanging"
                                OnSelectedIndexChanged="gvSupplierList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="SupplierID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ContactPerson" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="CurrencyID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CurrencyName" HeaderText="Currency" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Terms" HeaderText="Terms of Payment" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ModeOfPayment" HeaderText="Mode of Payment" ItemStyle-HorizontalAlign="Center" />
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
        <asp:View ID="vwDetailsSupplier" runat="server">
            <asp:HiddenField ID="hfSupplierID" runat="server" Visible="false" />
            <h4>Supplier Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblSupplierDetails_SupplierName" runat="server" Text="Supplier Name **" />
                    <asp:TextBox ID="txtSupplierDetails_SupplierName" runat="server" CssClass="form-control" placeholder="Supplier Name" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblSupplierDetails_ContactPerson" runat="server" Text="Contact Person" />
                    <asp:TextBox ID="txtSupplierDetails_ContactPerson" runat="server" CssClass="form-control" placeholder="Contact Person" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblSupplierDetails_ContactNo" runat="server" Text="Contact No" />
                    <asp:TextBox ID="txtSupplierDetails_ContactNo" runat="server" CssClass="form-control" placeholder="Contact No" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblSupplierDetails_PaymentTerms" runat="server" Text="Payment Terms" />
                        <asp:DropDownList ID="ddlSupplierDetails_PaymentTerms" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="PaymentTerms" class="btn btn-default btnTop10">•••</a>
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblSupplierDetails_ModeOfPayment" runat="server" Text="Mode of Payment" />
                        <asp:DropDownList ID="ddlSupplierDetails_ModeOfPayment" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="PaymentMode" class="btn btn-default btnTop10">•••</a>
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblSupplierDetails_Currency" runat="server" Text="Currency" />
                        <asp:DropDownList ID="ddlSupplierDetails_Currency" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="Currency" class="btn btn-default btnTop10">•••</a>
                        </span>
                    </div>
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblSupplierDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnSupplierDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnSupplierDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSupplierDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnSupplierDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblSupplierDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblSupplierDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSupplierDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnSupplierDetails_SaveYes_Click" />
                            <asp:Button ID="btnSupplierDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnSupplierDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSupplierDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnSupplierDetails_No_Click" />
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
