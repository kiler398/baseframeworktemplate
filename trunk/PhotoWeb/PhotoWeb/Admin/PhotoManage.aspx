<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="PhotoManage.aspx.cs" Inherits="PhotoWeb.Admin.PhotoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%">
        <tr>
            <td>
                &quot;<asp:Label ID="lblName" runat="server"></asp:Label>&quot;相册照片管理
            </td>
        </tr>
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td width="20%">
                            照片名：
                        </td>
                        <td>
                            <asp:TextBox ID="txtName0" runat="server" Width="58%" ValidationGroup="AddPhoto"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" ValidationGroup="AddPhoto"
                                ErrorMessage="照片名不能为空" ControlToValidate="txtName0" Display="Dynamic"></asp:RequiredFieldValidator>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            描述：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription0" ValidationGroup="AddPhoto" runat="server" Height="152px"
                                TextMode="MultiLine" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            是否显示：
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsShow0" ValidationGroup="AddPhoto" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            照片文件：
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPhoto" ValidationGroup="AddPhoto" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="添加照片" ValidationGroup="AddPhoto" OnClick="btnAdd_Click" />
                            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="ID" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="照片">
                            <ItemTemplate>
                                <asp:Image ID="imgT" ImageUrl='<%# "~/UploadFile/Photos/" + Eval("Turl").ToString() %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名称">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="描述">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否显示">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsShow" runat="server" Checked='<%# Bind("IsShow") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排序号">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSortIndex" runat="server" Width='38px' Text='<%# Bind("SortIndex") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="标题图片">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("SetAsTitleImage") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="管理">
                            <ItemTemplate>
                                <asp:Button ID="btnSetTitlePhoto" runat="server" Text="设为标题照片" CommandName="cmdSetTitlePhoto"  CommandArgument='<%# Bind("ID") %>' />
                                <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="cmdDelete"  CommandArgument='<%# Bind("ID") %>' />
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
