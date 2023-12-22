<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="yazilimsinamaproject.first" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Selection</title>
    <style>
    body {
        display: flex;
        align-items: center;
        justify-content: center;
        min-height: 100vh;
        margin: 0;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background-color: #f8f8f8;
        background-image: url('images/arkaplan.jpeg');
        background-size: cover;
    }

    form {
        max-width: 600px;
        width: 100%;
        background-color: rgba(255, 255, 255, 0.9);
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
    }

    h2 {
        color: #333;
        font-size: 30px; /* Büyütülen yazı büyüklüğü */
        border-bottom: 2px solid #007bff;
        padding-bottom: 10px;
        margin-bottom: 20px;
    }

    button {
        padding: 15px; /* Büyütülen buton yüksekliği */
        margin: 10px; /* Büyütülen buton margin'ı */
        border: none;
        cursor: pointer;
        background-color: #007bff;
        color: #fff;
        border-radius: 5px;
        font-size: 18px; /* Büyütülen yazı büyüklüğü */
        transition: background-color 0.3s ease;
    }

        button:hover {
            background-color: #0056b3;
        }

    a {
        text-decoration: none;
        color: #007bff;
        font-size: 18px; /* Büyütülen yazı büyüklüğü */
        transition: color 0.3s ease;
    }

        a:hover {
            text-decoration: underline;
            color: #0056b3;
        }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Customer or Freelancer ?</h2>
            <button id="btnCustomer" runat="server" onserverclick="btnCustomer_Click" onclientclick="ToggleButtons('<%= btnCustomer.ClientID %>'); return true;">Customer</button>
            <button id="btnFreelancer" runat="server" onserverclick="btnFreelancer_Click" onclientclick="ToggleButtons('<%= btnFreelancer.ClientID %>'); return true;">Freelancer</button>

            <br />

            <asp:PlaceHolder ID="phCustomer" runat="server" Visible="True">
                <a href="CustomerRegister.aspx">Create Account</a>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phFreelancer" runat="server" Visible="True">
                <a href="FreelancerRegister.aspx">Create Account</a>
            </asp:PlaceHolder>
        </div>
    </form>
    <script>
        function ToggleButtons(buttonClientId) {
            var buttons = document.querySelectorAll('button');
            buttons.forEach(function (btn) {
                btn.classList.remove('active');
            });
            document.getElementById(buttonClientId).classList.add('active');
        }
    </script>
</body>

</html>
