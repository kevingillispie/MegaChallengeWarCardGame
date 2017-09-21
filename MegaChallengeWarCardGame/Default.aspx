<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeWarCardGame.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Play War!</h3>
            <p>
                <asp:Button ID="playButton" runat="server" OnClick="playButton_Click" Text="PLAY!" />
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Label ID="resultLabel1" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
