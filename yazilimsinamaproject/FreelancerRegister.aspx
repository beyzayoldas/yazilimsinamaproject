<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreelancerRegister.aspx.cs" Inherits="yazilimsinamaproject.FreelancerRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Freelancer Registration</title>
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
            font-size: 30px;
            border-bottom: 2px solid #007bff;
            padding-bottom: 10px;
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 10px;
            font-size: 18px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        button {
            padding: 15px;
            margin: 10px;
            border: none;
            cursor: pointer;
            background-color: #007bff;
            color: #fff;
            border-radius: 5px;
            font-size: 18px;
            transition: background-color 0.3s ease;
        }

        button:hover {
            background-color: #0056b3;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfUserID" runat="server" />
            <h2>Freelancer Registration</h2>
            <div>
                <label for="txtFirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtLastName">Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail">Work Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <label for="txtCountry">Country:</label>
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnCreateAccount" runat="server" Text="Create My Account" OnClick="btnCreateAccount_Click" />
            </div>
        </div>
    </form>
</body>
</html>
