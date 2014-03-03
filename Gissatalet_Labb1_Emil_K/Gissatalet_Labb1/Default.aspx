<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissatalet_Labb1.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/Style.css" rel="stylesheet" />
    <script src="Script/script.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divfield">
        <asp:Label ID="textLabel" runat="server" Text="Ange ett tal mellan 1 och 100"></asp:Label>
        <asp:TextBox ID="gissaTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="gissaButton" runat="server" Text="Skicka gissning" OnClick="gissaButton_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet är tomt mata in ett tal mellan 1 och 100" ControlToValidate="gissaTextBox"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Måste vara heltal mellan 1 och 100" MinimumValue="1" MaximumValue="100" Type="Integer" ControlToValidate="gissaTextBox"></asp:RangeValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
        <div id="divresultat">
            <asp:Label ID="lastGuessLabel" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="infoGuessLabel" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="totalGuessesLabel" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="errorGuessLabel" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="winLabel" runat="server" Text="" Visible="false"></asp:Label><br />

        </div>
        <div>
            <asp:Button ID="randomButton" runat="server" Text="Slumpa nytt hemligt tal" OnClick="randomButton_Click" CausesValidation="False" />
        </div>
        
    </form>
</body>
</html>
