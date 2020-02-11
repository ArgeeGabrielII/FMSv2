<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="FlagRegistration.aspx.cs" Inherits="WebApp_FMS_V2.FlagRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Flag Registration - Requisition System
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
                <li>Flag Registration</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnFlagRegistration_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnFlagRegistration_Create_Click" />
            <asp:Button ID="btnFlagRegistration_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnFlagRegistration_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvFlagRegistration" runat="server">
        <asp:View ID="vwViewFlagRegistration" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Flag Registration</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtFlagRegistrationView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkFlagRegistrationView_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkFlagRegistrationView_Search_Click" >
                                                <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvFlagRegistrationList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvFlagRegistrationList_RowCommand" OnPageIndexChanging="gvFlagRegistrationList_PageIndexChanging"
                                OnSelectedIndexChanged="gvFlagRegistrationList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="FlagID" HeaderText="Flag ID" />
                                    <asp:BoundField DataField="FlagName" HeaderText="Flag Name" />
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
        <asp:View ID="vwDetailsFlagRegistration" runat="server">
            <asp:HiddenField ID="hfFlagRegistrationID" runat="server" Visible="false" />
            <h4>Flag Registration Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblFlagRegistrationDetails_FlagName" runat="server" Text="Flag Name **" />
                    <asp:TextBox ID="txtFlagRegistrationDetails_FlagName" runat="server" CssClass="form-control" placeholder="Flag Name" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblFlagRegistrationDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnFlagRegistrationDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnFlagRegistrationDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnFlagRegistrationDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnFlagRegistrationDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblFlagRegistrationDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblFlagRegistrationDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnFlagRegistrationDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnFlagRegistrationDetails_SaveYes_Click" />
                            <asp:Button ID="btnFlagRegistrationDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnFlagRegistrationDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnFlagRegistrationDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnFlagRegistrationDetails_No_Click" />
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
