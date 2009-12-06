<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AlbumManage.aspx.cs" Inherits="PhotoWeb.Admin.AlbumManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%">
        <tr>
            <td>
                相册管理
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="添加相册" 
                    onclick="btnAdd_Click" />
&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="更新" onclick="btnUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="ID"
                    ForeColor="#333333" GridLines="None" Width="100%" 
                    onrowcommand="GridView1_RowCommand">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="相册名称">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="描述">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode=MultiLine Text='<%# Bind("Description") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否显示">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsShow" runat=server Checked='<%# Bind("IsShow") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排序号">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSortIndex" runat="server" Width='38px' Text='<%# Bind("SortIndex") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="管理">
                            <ItemTemplate>
                                <asp:Button ID="btnManagePhoto" runat="server" Text="管理照片" CommandName="cmdManagePhoto" CommandArgument='<%# Bind("ID") %>' />
                                <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="cmdDelete" CommandArgument='<%# Bind("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
