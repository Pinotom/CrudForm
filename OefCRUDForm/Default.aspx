<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OefCRUDForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <style>
        td, th{
            padding: 5px;
        }
    </style>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="page-header">
                <h1>Oefening CRUD-form</h1>
            </div>
            <div class="form-group" style="padding-top: 3em;">
                <label class="control-label col-sm-2" for="txtName">Name:</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtName" runat="server"  class="form-control" placeholder="Enter name..."></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="Name is required field" ControlToValidate="txtName"><i class="fa fa-exclamation-circle"></i></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlCommands" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCommands_SelectedIndexChanged" TabIndex="1"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-2" for="txtAge">Age:</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtAge" runat="server"  class="form-control" placeholder="Enter age..." TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="ReqAge" runat="server" ErrorMessage="Age is required field" ControlToValidate="txtAge"><i class="fa fa-exclamation-circle"></i></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtID" runat="server"  class="form-control" placeholder="Enter ID..." Visible="False" TabIndex="1"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <asp:RequiredFieldValidator ID="ReqID" runat="server" ErrorMessage="ID is required" ControlToValidate="txtID" Enabled="False"><i class="fa fa-exclamation-circle"></i></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-2" for="txtAddress">Address:</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtAddress" runat="server"  class="form-control" placeholder="Enter address..."></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="ReqAddress" runat="server" ErrorMessage="Address is required field" ControlToValidate="txtAddress"><i class="fa fa-exclamation-circle"></i></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-2" for="txtCity">City:</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtCity" runat="server"  class="form-control" placeholder="Enter city..."></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="ReqCity" runat="server" ErrorMessage="City is required field" ControlToValidate="txtCity"><i class="fa fa-exclamation-circle"></i></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="btnExecute" runat="server" Text="Execute" CssClass="btn btn-primary" OnClick="btnExecute_Click"/>
                </div>
            </div>
            <div class="row"  style="padding-top: 2em; padding-bottom: 2em;">
                <div class ="col-sm-8 col-sm-offset-2">
                    <asp:Label ID="lblLog" runat="server" Text=""></asp:Label></div>
            </div>

            <div class="row">
                <div class="col-sm-8 col-sm-offset-2">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </form>
    </div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</body>
</html>
