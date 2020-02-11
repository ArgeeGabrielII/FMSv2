<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="PaymentTerms.aspx.cs" Inherits="WebApp_FMS_V2.PaymentTerms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Payment Terms - Requisition System
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
                <li>Payment Terms</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnPaymentTerms_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnPaymentTerms_Create_Click" />
            <asp:Button ID="btnPaymentTerms_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnPaymentTerms_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvPaymentTerms" runat="server">
        <asp:View ID="vwViewPaymentTerms" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Payment Terms</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtPaymentTermsView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkPaymentTermsView_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkPaymentTermsView_Search_Click" >
                                                <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvPaymentTermsList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvPaymentTermsList_RowCommand" OnPageIndexChanging="gvPaymentTermsList_PageIndexChanging"
                                OnSelectedIndexChanged="gvPaymentTermsList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="PaymentTermID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="PaymentTermsCode" HeaderText="Payment Terms Code" />
                                    <asp:BoundField DataField="PaymentTerms" HeaderText="Payment Terms" />

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
        <asp:View ID="vwDetailsPaymentTerms" runat="server">
            <asp:HiddenField ID="hfPaymentTermsID" runat="server" Visible="false" />
            <h4>Payment Terms Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblPaymentTermsDetails_Code" runat="server" Text="Payment Terms Code **" />
                    <asp:TextBox ID="txtPaymentTermsDetails_Code" runat="server" CssClass="form-control" placeholder="Payment Terms Code" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblPaymentTermsDetails_PaymentTerms" runat="server" Text="Payment Terms **" />
                    <asp:TextBox ID="txtPaymentTermsDetails_PaymentTerms" runat="server" CssClass="form-control" placeholder="Payment Terms" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblPaymentTermsDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnPaymentTermsDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnPaymentTermsDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnPaymentTermsDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnPaymentTermsDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblPaymentTermsDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblPaymentTermsDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnPaymentTermsDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnPaymentTermsDetails_SaveYes_Click" />
                            <asp:Button ID="btnPaymentTermsDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnPaymentTermsDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnPaymentTermsDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnPaymentTermsDetails_No_Click" />
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
