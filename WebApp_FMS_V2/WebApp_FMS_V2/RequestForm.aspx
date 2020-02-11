<%@ Page Title="" Language="C#" MasterPageFile="~/FMS.Master" AutoEventWireup="true" CodeBehind="RequestForm.aspx.cs" Inherits="WebApp_FMS_V2.RequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Request Form - Requisition System
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- Personal CSS -->
    <link href="assets/extra.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <br />
    <div class="row">
        <div id="divBreadCrumb" runat="server" class="col-md-12">
            <ul class="breadcrumb">
                <li><a href="Home">Home</a></li>
                <li><a href="ViewRequest">Requests</a></li>
                <li>Request Form</li>
            </ul>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_RequestID" runat="server" Text="Request ID" />
                    <asp:TextBox ID="txtRequestHeader_RequestID" runat="server" placeholder="Request ID" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_RequestedBy" runat="server" Text="Request By" />
                    <asp:TextBox ID="txtRequestHeader_RequestedBy" runat="server" placeholder="Request By" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_DateRequested" runat="server" Text="Date Requested" />
                    <asp:TextBox ID="txtRequestHeader_DateRequested" runat="server" placeholder="DateRequested" CssClass="form-control" ReadOnly="true" TextMode="Date" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_VesselSiteDept" runat="server" Text="Vessel/Site/Dept **" />
                    <asp:DropDownList ID="ddlRequestHeader_VesselSiteDept" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_ItemFor" runat="server" Text="Item For **" />
                    <asp:DropDownList ID="ddlRequestHeader_ItemFor" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Dry Dock" Value="DryDock"></asp:ListItem>
                        <asp:ListItem Text="Operations at Sea" Value="Operations"></asp:ListItem>
                        <asp:ListItem Text="Warehouse Stock" Value="Warehouse"></asp:ListItem>
                        <asp:ListItem Text="Administration" Value="Admin"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_DateNeeded" runat="server" Text="Date Needed **" />
                    <asp:TextBox ID="txtRequestHeader_DateNeeded" runat="server" CssClass="form-control" TextMode="Date" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_Notify" runat="server" Text="Notify" />
                    <asp:TextBox ID="txtRequestHeader_Notify" runat="server" CssClass="form-control" placeholder="Notify" TextMode="MultiLine" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_DeliverTo" runat="server" Text="Deliver To" />
                    <asp:TextBox ID="txtRequestHeader_DeliverTo" runat="server" CssClass="form-control" placeholder="Deliver To" TextMode="MultiLine" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblRequestHeader_Remarks" runat="server" Text="Remarks" />
                    <asp:TextBox ID="txtRequestHeader_Remarks" runat="server" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine" />
                </div>
            </div>
            <br />
            <br />
            <asp:Label ID="lblRequestHeader_Alert" runat="server" CssClass="AlertRed" />
            <br />
            <br />
            <div class="row">
                <div class="col-md-offset-6 col-md-2">
                    <asp:Button ID="btnRequestHeader_SaveDraft" runat="server" Text="Save Draft" CssClass="btn btn-primary" Width="100%" OnClick="btnRequestHeader_SaveDraft_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestHeader_AddItems" runat="server" Text="Add Items" CssClass="btn btn-success" Width="100%" OnClick="btnRequestHeader_AddItems_Click" />
                    <asp:Button ID="btnRequestHeader_EditItems" runat="server" Text="Edit Items" CssClass="btn btn-success" Width="100%" OnClick="btnRequestHeader_EditItems_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestHeader_Cancel" runat="server" Text="Cancel" CssClass="btn btn-danger" Width="100%" OnClick="btnRequestHeader_Cancel_Click" />
                </div>
            </div>
        </div>
    </div>

    <div id="modalRequestLines" runat="server" class="modal">
        <div class="modal-content">
            <!-- Request Header Summary -->
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <h3>Request Detail Header</h3>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <b><asp:Label ID="Label1" runat="server" Text="Request ID: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_RequestID" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <b><asp:Label ID="Label2" runat="server" Text="Date Requested: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_DateRequested" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-md-2">
                            <b><asp:Label ID="Label3" runat="server" Text="Date Needed: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_DateNeeded" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <b><asp:Label ID="Label4" runat="server" Text="Vessel/Site/Dept: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_VesselSiteDeptartment" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-md-2">
                            <b><asp:Label ID="Label5" runat="server" Text="Item For: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_ItemFor" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <b><asp:Label ID="Label6" runat="server" Text="Notify: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_Notify" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <b><asp:Label ID="Label7" runat="server" Text="Deliver To: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_DeliverTo" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <b><asp:Label ID="Label8" runat="server" Text="Remarks: " /></b>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRHSummary_Remarks" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        
                    </div>
                </div>
            </div>
            <br />
            <!-- Request Lines -->
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <br />
                    <div class="row">
                        <div class="col-md-10">
                            <h3>Request Item Details</h3>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnRequestLines_SaveItem" runat="server" Text="Save Item" CssClass="btn btn-success" Width="100%" style="margin-top: 20px !important" OnClick="btnRequestLines_SaveItem_Click" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_Quantity" runat="server" Text="Quantity **" />
                            <asp:TextBox ID="txtRequestLines_Quantity" runat="server" placeholder="Quantity" CssClass="form-control" TextMode="Number" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_UnitOfMeasurement" runat="server" Text="Unit of Measurement **" />
                            <asp:TextBox ID="txtRequestLines_UnitOfMeasurement" runat="server" placeholder="Unit [Pc/Kg/L/...]" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_ItemDescription" runat="server" Text="Item Description **" />
                            <asp:TextBox ID="txtRequestLines_ItemDescription" runat="server" placeholder="Item Description" CssClass="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_Department" runat="server" Text="Department **" />
                            <asp:DropDownList ID="ddlRequestLines_Department" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_ItemType" runat="server" Text="Item Type **" />
                            <asp:DropDownList ID="ddlRequestLines_ItemType" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_WhereToBuy" runat="server" Text="Where to Buy **" />
                            <asp:DropDownList ID="ddlRequestLines_WhereToBuy" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_Make" runat="server" Text="Make" />
                            <asp:TextBox ID="txtRequestLines_Make" runat="server" placeholder="Make" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_Model" runat="server" Text="Model" />
                            <asp:TextBox ID="txtRequestLines_Model" runat="server" placeholder="Model" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_SerialNo" runat="server" Text="Serial No" />
                            <asp:TextBox ID="txtRequestLines_SerialNo" runat="server" placeholder="Serial No" CssClass="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_PartNo" runat="server" Text="Part No" />
                            <asp:TextBox ID="txtRequestLines_PartNo" runat="server" placeholder="Part No" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblRequestLines_ArrangementNoCPL" runat="server" Text="Arrangement No / CPL" />
                            <asp:TextBox ID="txtRequestLines_ArrangementNoCPL" runat="server" placeholder="Arrangement No / CPL" CssClass="form-control" />
                        </div>
                        
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="lblRequestLines_Alert" runat="server" CssClass="AlertRed" />
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12" style="max-height: 300px; overflow: scroll">
                            <asp:GridView runat="server" ID="gvAllRequest_Close" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                AllowPaging="false" HeaderStyle-HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" FooterStyle-Width="15%" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" CausesValidation="false" CommandName="Edit"
                                                CssClass="btn btn-primary" CommandArgument='<%# Container.DataItemIndex %>' title="Edit"
                                                data-rel="tooltip"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkDelete" CausesValidation="false" CommandName="Delete"
                                                CssClass="btn btn-danger" CommandArgument='<%# Container.DataItemIndex %>' title="Delete"
                                                data-rel="tooltip"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="RequestLineID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="RequestLineNo" HeaderText="Line No" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="RequestID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="SubRequestFormNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="LineQuantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="UnitOfMeasurement" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ItemDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Make" HeaderText="Make" />
                                    <asp:BoundField DataField="Model" HeaderText="Model" />
                                    <asp:BoundField DataField="Serial_EngineNo" HeaderText="Serial_EngineNo" />
                                    <asp:BoundField DataField="PartNo" HeaderText="PartNo" />
                                    <asp:BoundField DataField="ArrangementNo_CPL" HeaderText="ArrangementNo_CPL" />
                                    <asp:BoundField DataField="WhereToBuy" HeaderText="WhereToBuy" />
                                    <asp:BoundField DataField="WarehouseStatus" HeaderText="WarehouseStatus" />
                                </Columns>
                                <EmptyDataTemplate>There are no items to show. Please add an item(s).</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-offset-8 col-md-2">
                            <asp:Button ID="btnRequestLines_ForApproval" runat="server" Text="For Approval" CssClass="btn btn-success" Width="100%" OnClick="btnRequestLines_ForApproval_Click" />
                            <asp:Button ID="btnRequestLines_Resend" runat="server" Text="Resend" CssClass="btn btn-success" Width="100%" OnClick="btnRequestLines_Resend_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnRequestLines_Back" runat="server" Text="Back" CssClass="btn btn-danger" Width="100%" OnClick="btnRequestLines_Back_Click" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>

    <div id="modalRequestHeader_Notification" runat="server" class="modal">
        <div class="modal-content">
            <div class="row">
                <div class="col-md-12">
                    <center><h3><asp:Label ID="lblRequestHeader_NotifHeader" runat="server" /></h3></center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <center><asp:Label ID="lblRequestHeader_NotifBody" runat="server" /></center>
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-md-7"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestHeaderDraft_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnRequestHeaderDraft_SaveYes_Click" />
                    <%--<asp:Button ID="btnRequestHeader_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnRequestHeader_SaveYes_Click" />--%>
                    <asp:Button ID="btnRequestHeader_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnRequestHeader_CancelYes_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestHeader_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnRequestHeader_No_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
    <div id="modalRequestLines_Notification" runat="server" class="modal">
        <div class="modal-content">
            <div class="row">
                <div class="col-md-12">
                    <center><h3><asp:Label ID="lblRequestLines_NotifHeader" runat="server" /></h3></center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <center><asp:Label ID="lblRequestLines_NotifBody" runat="server" /></center>
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-md-7"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestLines_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnRequestLines_SaveYes_Click" />
                    <asp:Button ID="btnRequestLines_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnRequestLines_CancelYes_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnRequestLines_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnRequestLines_No_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
