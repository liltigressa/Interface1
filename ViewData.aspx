<%@ Page Language="C#" MaintainScrollPositionOnPostback="true"  AutoEventWireup="true" CodeBehind="ViewData.aspx.cs" Inherits="Interface.ViewData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 149px;
        }
        .auto-style3 {
            width: 149px;
            height: 36px;
        }
        .auto-style5 {
            height: 23px;
            width: 720px;
        }
        .auto-style11 {
            height: 1886px;
        }
        .auto-style12 {
            width: 93%;
            height: 151px;
        }
        .auto-style13 {
            width: 720px;
            height: 36px;
        }
        .auto-style14 {
            width: 149px;
            height: 33px;
        }
        .auto-style15 {
            width: 720px;
            height: 33px;
        }
        .auto-style16 {
            height: 33px;
        }
        .auto-style17 {
            height: 36px;
        }
        .auto-style18 {
            height: 23px;
            margin-left: 120px;
        }
        .auto-style28 {
            width: 139px;
            height: 21px;
        }
        .auto-style29 {
            width: 764px;
            height: 21px;
        }
        .auto-style30 {
            height: 21px;
        }
        .auto-style8 {
            width: 139px;
            height: 26px;
        }
        .auto-style9 {
            width: 764px;
            height: 26px;
        }
        .auto-style10 {
            height: 26px;
        }
        .auto-style4 {
            width: 139px;
        }
        .auto-style7 {
            width: 764px;
        }
        .auto-style25 {
            width: 139px;
            height: 25px;
        }
        .auto-style26 {
            width: 764px;
            height: 25px;
        }
        .auto-style27 {
            height: 25px;
        }
        .auto-style33 {
            margin-left: 120px;
            height: 36px;
        }
        .auto-style34 {
            width: 139px;
            height: 34px;
        }
        .auto-style35 {
            width: 764px;
            height: 34px;
        }
        .auto-style36 {
            height: 34px;
        }
        .auto-style37 {
            width: 188px;
        }
        .auto-style38 {
            height: 23px;
            width: 188px;
        }
        .auto-style39 {
            width: 777px;
        }
        .auto-style40 {
            height: 23px;
            width: 777px;
        }
        .auto-style41 {
            width: 188px;
            height: 25px;
        }
        .auto-style42 {
            width: 777px;
            height: 25px;
        }
        .auto-style46 {
            width: 139px;
            height: 30px;
        }
        .auto-style47 {
            width: 764px;
            height: 30px;
        }
        .auto-style48 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="auto-style11">
            <br />
            <br />
            <br />
            <table class="auto-style12">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Format Types: " Font-Size="Large" ForeColor="Black"></asp:Label>
                    </td>
                    <td class="auto-style5"></td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblFormatType" runat="server" Text="Format Type: "></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddFormatType" runat="server" Width="317px" OnSelectedIndexChanged="ddFormatType_SelectedIndexChanged1" >
                        </asp:DropDownList>
&nbsp;<asp:Button ID="btnAddFormatTypetoDropDownList" runat="server" Font-Bold="True" Height="23px" Text="Add to List" Width="107px" OnClick="btnAddFormatTypetoDropDownList_Click" />
            &nbsp;<asp:TextBox ID="txtFormatType" runat="server" Width="269px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
            <asp:Label ID="lblFormatDescription" runat="server" Text="Format Description:"></asp:Label>
                    </td>
                    <td class="auto-style15">
            <asp:TextBox ID="txtFormatDescription" runat="server" Width="543px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        
                        <asp:Label ID="lblDateCreated" runat="server" Text="Date Created: " Visible="False"></asp:Label>
                        <asp:TextBox ID="txtDateCreated" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:Label ID="lblFormatSpecification" runat="server" Text="Format Specification: "></asp:Label>
                    </td>
                    <td class="auto-style13"><asp:TextBox ID="txtFormatSpecification" runat="server" Width="543px"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        
                        <asp:Label ID="lblInactiveDate" runat="server" Text="Inactive Date:" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtInactiveDate" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style5">
                        &nbsp;<asp:Button ID="btnNewFormatType" runat="server" OnClick="btnNewFormatType_Click" Text="New" CausesValidation="false" Height="23px" Width="138px" Font-Bold="True" />
                        &nbsp;<asp:Button ID="btnEditFormatType" runat="server" Height="23px" OnClick="btnEditFormatType_Click" Text="Edit" Width="138px" Font-Bold="True" />
&nbsp;<asp:Button ID="btnCancelFormatType" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="138px" CausesValidation ="false" Height="23px" Font-Bold="True" />
                        <asp:Button ID="btnSaveFormatType" runat="server" OnClick="btnSaveFormatType_Click" Text="Save" Width="138px" Height="23px" ValidationGroup="FormatTypeValidation" Font-Bold="True" />
                        </td>
                    <td class="auto-style18">
                        
                        <asp:CheckBox ID="cbInactive" runat="server" OnCheckedChanged="cbInactive_CheckedChanged" Text="Inactive" />
&nbsp;
                                                
                    </td>
                </tr>           
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style13">
                        
                        <asp:CheckBox ID="cbShowInactive" AutoPostBack="true" runat="server" Text="Show Inactive " OnCheckedChanged="cbShowInactive_CheckedChanged" />
                        
                        </td>
                    <td class="auto-style33">
                        
&nbsp;
                        </td>
                </tr>           
            </table>
            <br/>
            <asp:GridView ID="gvFormatTypes" runat="server" Autopostback ="true" AutoGenerateColumns="false" CellPadding="3" DataKeyNames="ID"  Font-Names="Lucida Sans" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gvFormatTypes_SelectedIndexChanged"  Height="16px" Width="1419px" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" ItemStyle-Width="10%" SortExpression="ID" />
                    <asp:BoundField DataField="FormatType" HeaderText="Format Type" SortExpression="FormatType" />
                    <asp:BoundField DataField="Description" HeaderText="Description"  ItemStyle-Width="45%" SortExpression="Description" />
                    <asp:BoundField DataField="FormatSpecification" HeaderText="Format Specification" SortExpression="FormatSpecification" />
                    <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MM/dd/yyyy}"/>
                    <asp:BoundField DataField="InactiveDate" HeaderText="Inactive Date" SortExpression="InactiveDate" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MM/dd/yyyy}"/>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#3333FF" Font-Bold="True"></asp:Label>
                        <br />
            <br />
            <br />
            <br />
            <table style="width:100%;" border="0">
                <tr>
                    <td class="auto-style28">
            <asp:Label ID="lblAttributes" runat="server" Text="Attributes:" align="left" Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </td>
                    <td class="auto-style29" dir="ltr">
                        &nbsp;</td>
                    <td class="auto-style30">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style28">
                        &nbsp;</td>
                    <td class="auto-style29" dir="ltr">
                    &nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style34">
            <asp:Label ID="lblAttributeName" runat="server" Text="Attribute Name: " align="right"></asp:Label>
                    </td>
                    <td class="auto-style35" dir="ltr">
                        <asp:DropDownList ID="ddAttributeName" runat="server" Width="317px" AppendDataBoundItems="True" OnSelectedIndexChanged="ddAttributeName_SelectedIndexChanged" AutoPostBack="True" >                   
                        </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnAddAttributetoDropDown" runat="server" Font-Bold="True" Height="23px" OnClick="btnAddAttributetoDropDown_Click" Text="Add to list" Width="107px" />
                        &nbsp;
                        <asp:TextBox ID="txtNewAttributeName" runat="server" Width="269px"></asp:TextBox>
                    </td>
                    <td class="auto-style36">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
            <asp:Label ID="lblDataType" runat="server" Text="Data Type: "></asp:Label>
                    </td>
                    <td class="auto-style9" dir="ltr">
            <asp:DropDownList ID="ddDataType" runat="server" Width="178px"   >
            </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    <td class="auto-style10">
                        
                        <asp:Button ID="btnNewAttributeName" runat="server" Text="New" Width="138px" Height="23px" Font-Bold="True" OnClick="btnNewAttributeName_Click" Visible="False" /> 
                     
                        </td>
                </tr>
                <tr>
                    <td class="auto-style8">
            <asp:Label ID="lblAttributeDescription" runat="server" Text="Description:"></asp:Label>
                    </td>
                    <td class="auto-style9" dir="ltr">
            <asp:TextBox ID="txtAttributeDescription" runat="server" Width="521px"></asp:TextBox>
                    </td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style26" dir="ltr">
            <asp:CheckBox ID="cbAllowMultiSelect" runat="server" Text="Allow Multi Select" TextAlign="Left" />
                    </td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style26" dir="ltr">
            <asp:CheckBox ID="cbUserEdit" runat="server" Text="Allow User Edit          " TextAlign="Left" />
                    </td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <asp:Label ID="lblAttributeValues" runat="server" Text="Attribute Values:"></asp:Label>
                    </td>
                    <td class="auto-style26" dir="ltr">
                        <asp:CheckBox ID="cbCopyAttributeValues" runat="server" AutoPostBack="true" Text="Copy Attribute Values" OnCheckedChanged="cbCopyAttributeValues_CheckedChanged" />
                    </td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style46"></td>
                    <td class="auto-style47" dir="ltr">
                        <asp:Label ID="Label7" runat="server" Text="Value"></asp:Label>
                        <asp:CheckBoxList ID="cbAttributeValues" runat="server" Height="16px" Width="255px" RepeatDirection="Vertical" TextAlign="right" AutoPostBack="True"   >
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:CheckBoxList>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Label:"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        </asp:CheckBoxList>
&nbsp;
                    </td>
                    <td class="auto-style48"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style7" dir="ltr">
                        <asp:Button ID="btnAddAttribute" runat="server" OnClick="btnAddAttribute_Click" Text="New" CausesValidation ="false" Height="23px" Width="138px" Font-Bold="True" ValidationGroup="AttributeValidation" />
                        <asp:Button ID="btnEditAttribute" runat="server" Font-Bold="True" Height="23px" Text="Edit" Width="138px" OnClick="btnEditAttribute_Click" ValidationGroup="AttributeValidation" />
                        
                        <asp:Button ID="btnCancelAttribute" runat="server" OnClick="btnCancelAttribute_Click" Text="Cancel" Width="138px" Font-Bold="True" Height="23px" />
                        <asp:Button ID="btnSaveAttribute" runat="server" OnClick="btnSaveAttribute_Click" Text="Save" Width="138px" Font-Bold="True" Height="23px" ValidationGroup="AttributeValidation"  />
                        <asp:Button ID="btnDeleteAttribute" runat="server" Font-Bold="True" Height="23px" OnClick="btnDeleteAttribute_Click" Text="Delete" Width="138px" ValidationGroup="AttributeValidation" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style46">
                        <asp:Label ID="lblFormatTypeID" runat="server" Text="FormatTypeID:"></asp:Label>
                    </td>
                    <td class="auto-style47" dir="ltr">
            <asp:TextBox ID="txtFormatTypeID" runat="server"></asp:TextBox>
                        <asp:Label ID="lblAttributeID" runat="server" Text="ID:" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtAttributeID" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style48"></td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"  Font-Names="Lucida Sans" Width="1419px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"  DataSourceID="SqlDataSource1" ShowHeaderWhenEmpty="True" EmptyDataText="No Records to Display!" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="AttributeName" HeaderText="Name" SortExpression="AttributeName" />
                    <asp:BoundField DataField="AttributeDataType" HeaderText="Data Type" SortExpression="AttributeDataType" />
                    <asp:CheckBoxField DataField="AllowMultiSelect" HeaderText="Allow Multi Select" SortExpression="AllowMultiSelect" />
                    <asp:CheckBoxField DataField="AllowUserEdit" HeaderText="Predefined Values" SortExpression="AllowUserEdit" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                
                        <asp:Label ID="lblAttributeMessage" runat="server" ForeColor="Blue" Font-Bold="True"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ContentDeliveryConnectionString %>" SelectCommand="SELECT [ID], [AttributeName], [AttributeDataType], [AllowMultiSelect], [AllowUserEdit], [Description] FROM [FormatAttribute] WHERE ([FormatTypeID] = @FormatTypeID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvFormatTypes" Name="FormatTypeID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style37">
            <asp:Label ID="lblAttributes0" runat="server" Text="Attribute Values:" align="left" Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38"></td>
                    <td class="auto-style40"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style38">
                        <asp:Label ID="lblAttributeLabel" runat="server" Text="Attribute Label:"></asp:Label>
&nbsp;</td>
                    <td class="auto-style40">
                        <asp:TextBox ID="txtAttributeLabel" runat="server" Width="410px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style41">
                        <asp:Label ID="lblVvalueString" runat="server" Text="Attribute Value for String:"></asp:Label>
&nbsp;</td>
                    <td class="auto-style42">
                        <asp:TextBox ID="txtAttributeValue" runat="server" Width="408px"></asp:TextBox>
                    </td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style41">
                        <asp:Label ID="Label5" runat="server" Text="Attribute Value for Int:"></asp:Label>
                    </td>
                    <td class="auto-style42">
                        &nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38">
                        <asp:Label ID="lblValueBit" runat="server" Text="Attribute Value for Bit:"></asp:Label>
                    </td>
                    <td class="auto-style40">
                        <asp:RadioButtonList ID="rbBitValue" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>No</asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style38">&nbsp;</td>
                    <td class="auto-style40">
                        <asp:CheckBox ID="cbIsDefault" runat="server" Text="Default" TextAlign="Left" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38">&nbsp;</td>
                    <td class="auto-style40">
                        &nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38">&nbsp;</td>
                    <td class="auto-style40">
                        <asp:Button ID="btnNewValue" runat="server" Font-Bold="True" Height="23px" OnClick="btnNewValue_Click" Text="New" Width="138px" />
                        <asp:Button ID="btnEditValue" runat="server" Font-Bold="True" Height="23px" OnClick="btnEditValue_Click" Text="Edit" Width="138px" />
<asp:Button ID="btnCancelValue" runat="server" Font-Bold="True" Height="23px" Text="Cancel" Width="138px" OnClick="btnCancelValue_Click" />
<asp:Button ID="btnSaveValue" runat="server" Font-Bold="True" Height="23px" Text="Save" Width="138px" OnClick="btnSaveValue_Click" />
                        <asp:Button ID="btnDeleteValue" runat="server" Font-Bold="True" Height="23px" OnClick="btnDeleteValue_Click" Text="Delete" Width="138px" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38">
                        <asp:Label ID="Label4" runat="server" Text="Data Type:" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style40">
                        <asp:TextBox ID="txtDataType" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style38">
                        <asp:Label ID="lblAttributeValueID" runat="server" Text="ID:" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style40">
                        <asp:TextBox ID="txtFormatAttributeValueID" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>

            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="1322px" AllowPaging="True" Font-Names="Lucida Sans"  ViewStateMode="Enabled" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" ShowHeaderWhenEmpty="True" EmptyDataText="No Records to Display!" Height="16px" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="AttributeLabel" HeaderText="Label" SortExpression="AttributeLabel" />
                    <asp:BoundField DataField="AttributeValue" HeaderText="Value" SortExpression="AttributeValue" />
                    <asp:CheckBoxField DataField="IsDefault" HeaderText="Default" SortExpression="IsDefault" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ContentDeliveryConnectionString %>" SelectCommand="SELECT [ID], [AttributeLabel], [AttributeValue], [IsDefault] FROM [FormatAttributeValue] WHERE ([FormatAttributeID] = @FormatAttributeID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridView2" Name="FormatAttributeID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Label ID="lblValueMessage" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>

            <br />
&nbsp;<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
                    <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
