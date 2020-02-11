<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="VesselSiteDepartment.aspx.cs" Inherits="WebApp_FMS_V2.VesselSiteDept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Vessel - Site - Department - Requisition System
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
                <li>Vessel - Site - Department</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnVesselDept_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnVesselDept_Create_Click" />
            <asp:Button ID="btnVesselDept_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnVesselDept_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvVesselDept" runat="server">
        <asp:View ID="vwViewVesselDept" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Vessel / Site / Deptartment</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtVesselDept_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkVesselDept_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkVesselDept_Search_Click">
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="gvVesselDeptList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="10"
                                HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvVesselDeptList_RowCommand" OnPageIndexChanging="gvVesselDeptList_PageIndexChanging"
                                OnSelectedIndexChanged="gvVesselDeptList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="VesselID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="VesselCode" HeaderText="VesselCode" />
                                    <asp:BoundField DataField="VesselName" HeaderText="VesselName" />
                                    <asp:BoundField DataField="VesselTypeID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="VesselType" HeaderText="VesselType" />
                                    <asp:BoundField DataField="FlagID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="FlagName" HeaderText="FlagRegistration" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />

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

        <asp:View ID="vwDetailsVesselDept" runat="server">
            <asp:HiddenField ID="hfVesselDeptID" runat="server" Visible="false" />
            <h4>Vessel / Site / Department Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblVesselDeptDetails_Code" runat="server" Text="Vessel/Site/Dept Code **" />
                    <asp:TextBox ID="txtVesselDeptDetails_Code" runat="server" CssClass="form-control" placeholder="Code" />
                </div>
                <div class="col-md-4 chkPaddingTop">
                    <asp:CheckBox ID="chkVesselDeptDetails_Active" runat="server" />
                    <asp:Label ID="lblVesselDeptDetails_Active" runat="server" Text="Active" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblVesselDeptDetails_Name" runat="server" Text="Name **" />
                    <asp:TextBox ID="txtVesselDeptDetails_Name" runat="server" CssClass="form-control" placeholder="Name" />
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblVesselDeptDetails_Type" runat="server" Text="Type" />
                        <asp:DropDownList ID="ddlVesselDeptDetails_Type" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="VesselType" class="btn btn-default btnTop10">•••</a>
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblVesselDeptDetails_FlagRegistration" runat="server" Text="Flag Registration" />
                        <asp:DropDownList ID="ddlVesselDeptDetails_FlagRegistration" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="FlagRegistration" class="btn btn-default btnTop10">•••</a>
                        </span>
                    </div>
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblVesselDeptDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnVesselDeptDetails_Save" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Save" OnClick="btnVesselDeptDetails_Save_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnVesselDeptDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnVesselDeptDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblVesselDeptDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblVesselDeptDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnVesselDeptDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnVesselDeptDetails_SaveYes_Click" />
                            <asp:Button ID="btnVesselDeptDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnVesselDeptDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnVesselDeptDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnVesselDeptDetails_No_Click" />
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
