<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="WebApp_FMS_V2.ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View Request - Requisition System
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
                <li>Requests</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnViewRequisition_CreateRequest" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create Request" OnClick="btnViewRequisition_CreateRequest_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel-body">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li id="liAllRequest" runat="server"><a href="#AllRequests" data-toggle="tab"><center>All<br />Requests</center></a></li>
                    <li id="liDraftRequests" runat="server"><a href="#DraftRequests" data-toggle="tab"><center>Draft<br />Requests</center></a></li>
                    <li id="liSubmittedRequests" runat="server"><a href="#SubmittedRequests" data-toggle="tab"><center>Submitted<br />Requests</center></a></li>
                    <li id="liForApproval" runat="server"><a href="#ForApproval" data-toggle="tab"><center>For<br />Approval</center></a></li>
                    <li id="liSentBackRequests" runat="server"><a href="#SentBackRequests" data-toggle="tab"><center>Sent Back<br />Requests</center></a></li>
                    <li id="liApprovedRequests" runat="server"><a href="#ApprovedRequests" data-toggle="tab"><center>Approved<br />Requests</center></a></li>
                    <li id="liWarehouseChecking" runat="server"><a href="#WarehouseChecking" data-toggle="tab"><center>Warehouse<br />Checking</center></a></li>
                    <li id="liForCanvassing" runat="server"><a href="#ForCanvassing" data-toggle="tab"><center>For<br />Canvassing</center></a></li>
                    <li id="liCanvassCreatedNotForCanvass" runat="server"><a href="#CanvassCreatedNotForCanvass" data-toggle="tab"><center>Canvass Created<br />Not For Canvass</center></a></li>
                    <li id="liPOCreated" runat="server"><a href="#POCreated" data-toggle="tab"><center>PO<br />Created</center></a></li>
                    <li id="liForwardedToPurchasing" runat="server"><a href="#ForwardedToPurchasing" data-toggle="tab"><center>Forwarded To<br />Purchasing</center></a></li>
                    <li id="liServedRequests" runat="server"><a href="#ServedRequests" data-toggle="tab"><center>Served<br />Requests</center></a></li>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="AllRequests">
                        <!-- Start All Request -->
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <div class="col-md-4 col-md-offset-8">
                                                <div class="form-group input-group mTop3-form-group">
                                                    <asp:TextBox ID="txtViewRequest_ViewAllRequest_Search" runat="server" CssClass="form-control" placeholder="Search All Requests" />
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lnkViewRequest_ViewAllRequest_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkViewRequest_ViewAllRequest_Search_Click">
                                                                <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="gvViewRequest_ViewAllRequests" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="true" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowDataBound="gvViewRequest_ViewAllRequests_RowDataBound" 
                                            OnPageIndexChanging="gvViewRequest_ViewAllRequests_PageIndexChanging" OnSelectedIndexChanged="gvViewRequest_ViewAllRequests_SelectedIndexChanged" 
                                            OnRowCommand="gvViewRequest_ViewAllRequests_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ShowHeader="False" HeaderText="RF No." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" FooterStyle-Width="8%" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkView" CausesValidation="false" CommandName="Select"
                                                            Text='<%# Bind("RequestFormNo") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="DateNeeded" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselName" HeaderText="Vessel / Site / Dept" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestStatus" HeaderText="Status" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="Remarks" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="CreatedByID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="RequestedBy" HeaderText="Requestor" ItemStyle-HorizontalAlign="Center" />
                                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkVerify" CausesValidation="false" CommandName="Verify"
                                                            CssClass="btn btn-primary" CommandArgument='<%# Container.DataItemIndex %>' title="Verify"
                                                            data-rel="tooltip"><i class="glyphicon glyphicon-th-list">
                                                                    </i></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lnkAudit" CausesValidation="false" CommandName="Audit"
                                                            CssClass="btn btn-warning" CommandArgument='<%# Container.DataItemIndex %>' title="Audit Mark"
                                                            data-rel="tooltip"><i class="glyphicon glyphicon-tag">
                                                                    </i></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lnkClose" CausesValidation="false" CommandName="Close"
                                                            CssClass="btn btn-danger" CommandArgument='<%# Container.DataItemIndex %>' title="Close RF"
                                                            data-rel="tooltip"><i class="glyphicon glyphicon-remove-sign">
                                                                    </i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "All Request".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End All Request -->

                        <!-- Start Verify -->
                        <div id="modalAllRequest_Verify" runat="server" class="modal">
                            <div class="modal-content">
                                <div class="row">
                                    <div class="col-md-12">
                                        <center><h3><asp:Label ID="lblAllRequest_Verify_Header" runat="server" /></h3></center>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5 col-md-offset-1">
                                        <asp:Label ID="lblAllRequest_Verify_RequisitionNo" runat="server" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblAllRequest_Verify_VesselName" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1" style="max-height: 300px; overflow-y: scroll">
                                        <asp:GridView runat="server" ID="gvAllRequest_Verify" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="false" HeaderStyle-HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="RequestLineID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkSelectLine" AutoPostBack="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestLineNo" HeaderText="Line No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SubRequestFormNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="LineQuantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitOfMeasurement" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="ItemDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="PONo" HeaderText="PO #" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="COSNo" HeaderText="COS #" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="VerificationStatus" HeaderText="Status" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="VerifiedBy" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VerifiedDateTime" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField HeaderText="Verification Remarks" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtVerifyRemarks" TextMode="MultiLine" Width="95%" Text='<%# Bind("VerificationRemarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Verification".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br /><br /><br />
                                <div class="row">
                                    <div class="col-md-2 col-md-offset-7">
                                        <asp:Button ID="btnAllRequest_Verify_Save" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnAllRequest_Verify_Save_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnAllRequest_Verify_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnAllRequest_Verify_No_Click" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!-- End Verify -->

                        <!-- Start Audit -->
                        <div id="modalAllRequest_Audit" runat="server" class="modal">
                            <div class="modal-content">
                                <div class="row">
                                    <div class="col-md-12">
                                        <center><h3><asp:Label ID="lblAllRequest_Audit_Header" runat="server" /></h3></center>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5 col-md-offset-1">
                                        <asp:Label ID="lblAllRequest_Audit_RequisitionNo" runat="server" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblAllRequest_Audit_VesselName" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1" style="max-height: 300px; overflow-y: scroll">
                                        <asp:GridView runat="server" ID="gvAllRequest_Audit" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="false" HeaderStyle-HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="RequestLineID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkSelectLine" AutoPostBack="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestLineNo" HeaderText="Line No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SubRequestFormNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="LineQuantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitOfMeasurement" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="ItemDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="PONo" HeaderText="PO #" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="COSNo" HeaderText="COS #" ItemStyle-HorizontalAlign="Center" />
                                                <asp:TemplateField HeaderText="Audit Remarks" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtAuditRemarks" TextMode="MultiLine" Width="95%" Text='<%# Bind("AuditRemarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Audit Remarks".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br /><br /><br />
                                <div class="row">
                                    <div class="col-md-2 col-md-offset-7">
                                        <asp:Button ID="btnAllRequest_Audit_Save" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnAllRequest_Audit_Save_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnAllRequest_Audit_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnAllRequest_Audit_No_Click" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!-- End Audit -->

                        <!-- Start Close -->
                        <div id="modalAllRequest_Close" runat="server" class="modal">
                            <div class="modal-content">
                                <div class="row">
                                    <div class="col-md-12">
                                        <center><h3><asp:Label ID="lblAllRequest_Close_Header" runat="server" /></h3></center>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5 col-md-offset-1">
                                        <asp:Label ID="lblAllRequest_Close_RequesitionNo" runat="server" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblAllRequest_Close_VesselName" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1" style="max-height: 300px; overflow-y: scroll">
                                        <asp:GridView runat="server" ID="gvAllRequest_Close" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="false" HeaderStyle-HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="RequestLineID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkSelectLine" AutoPostBack="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestLineNo" HeaderText="Line No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SubRequestFormNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="LineQuantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitOfMeasurement" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="ItemDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="PONo" HeaderText="PO No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="COSNo" HeaderText="COS No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:TemplateField HeaderText="Closing Remarks" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtClosingRemarks" TextMode="MultiLine" Width="95%" Text='<%# Bind("ClosingRemarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Closing".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br /><br /><br />
                                <div class="row">
                                    <div class="col-md-2 col-md-offset-7">
                                        <asp:Button ID="btnAllRequest_Close_Save" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnAllRequest_Close_Save_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnAllRequest_Close_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnAllRequest_Close_No_Click" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!-- End Close -->
                    </div>
                    <div class="tab-pane fade" id="DraftRequests">
                        <!-- Start Draft Request -->
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <div class="col-md-4 col-md-offset-8">
                                                <div class="form-group input-group mTop3-form-group">
                                                    <asp:TextBox ID="txtViewRequest_DraftRequest_Search" runat="server" CssClass="form-control" placeholder="Search Draft Request" />
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lnkViewRequest_DraftRequest_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkViewRequest_DraftRequest_Search_Click">
                                                                <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="gvViewRequest_DraftRequest" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="true" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowDataBound="gvViewRequest_DraftRequest_RowDataBound" 
                                            OnPageIndexChanging="gvViewRequest_DraftRequest_PageIndexChanging" OnSelectedIndexChanged="gvViewRequest_DraftRequest_SelectedIndexChanged" 
                                            OnRowCommand="gvViewRequest_DraftRequest_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ShowHeader="False" HeaderText="RF No." ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="10%" FooterStyle-Width="10%" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkView" CausesValidation="false" CommandName="Select"
                                                            Text='<%# Bind("RequestFormNo") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="DateNeeded" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselName" HeaderText="Vessel / Site / Dept" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="Remarks" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="RequestStatus" HeaderText="Status" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestedBy" HeaderText="Requestor" ItemStyle-HorizontalAlign="Center" />
                                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkDelete" CausesValidation="false" CommandName="Delete"
                                                            CssClass="btn btn-danger" CommandArgument='<%# Container.DataItemIndex %>' title="Delete Draft"
                                                            data-rel="tooltip"><i class="glyphicon glyphicon-remove-sign">
                                                                    </i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Draft Requests".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Draft Request -->

                        <!-- Start Delete Draft -->
                        <div id="modalDraftRequest_Delete" runat="server" class="modal">
                            <div class="modal-content">
                                <div class="row">
                                    <div class="col-md-12">
                                        <center><h3><asp:Label ID="lblDraftRequest_Delete_Header" runat="server" /></h3></center>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5 col-md-offset-1">
                                        <asp:Label ID="lblDraftRequest_Delete_RequisitionNo" runat="server" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblDraftRequest_Delete_VesselName" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1" style="max-height: 300px; overflow-y: scroll">
                                        <asp:GridView runat="server" ID="gvDraftRequest_Delete" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="false" HeaderStyle-HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="RequestLineID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="RequestLineNo" HeaderText="Line No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="SubRequestFormNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="LineQuantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitOfMeasurement" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="ItemDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="PONo" HeaderText="PO No" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="COSNo" HeaderText="COS No" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Deletion".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br /><br /><br />
                                <div class="row">
                                    <div class="col-md-2 col-md-offset-7">
                                        <asp:Button ID="btnDraftRequest_Delete_Save" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnDraftRequest_Delete_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!-- End Delete Draft -->
                    </div>
                    <div class="tab-pane fade" id="SubmittedRequests">
                        <!-- Start Submitted Request -->
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <div class="col-md-4 col-md-offset-8">
                                                <div class="form-group input-group mTop3-form-group">
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search Submitted Request" />
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lnkViewRequest_SubmittedRequest_Search" runat="server" CssClass="btn btn-default btn-padding">
                                                                <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="gvViewRequest_SubmittedRequest" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" 
                                            AllowPaging="true" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination">
                                            <Columns>
                                                <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:TemplateField ShowHeader="False" HeaderText="RF No." ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="10%" FooterStyle-Width="10%" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkView" CausesValidation="false" CommandName="Select"
                                                            Text='<%# Bind("RequestFormNo") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="DateNeeded" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="VesselName" HeaderText="Vessel / Site / Dept" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="Remarks" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                <asp:BoundField DataField="RequestStatus" HeaderText="Status" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="RequestedBy" HeaderText="Requestor" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <EmptyDataTemplate>There are no items to show for "Submitted Requests".</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Submitted Request -->
                    </div>
                    <div class="tab-pane fade" id="ForApproval">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="SentBackRequests">
                        <h4>SentBackRequests</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="ApprovedRequests">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="WarehouseChecking">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="ForCanvassing">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="CanvassCreatedNotForCanvass">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="POCreated">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="ForwardedToPurchasing">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                    <div class="tab-pane fade" id="ServedRequests">
                        <h4>Settings Tab</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
