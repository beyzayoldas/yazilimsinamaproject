<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnasayfaCustomer.aspx.cs" Inherits="yazilimsinamaproject.AnasayfaCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anasayfa - Customer</title>
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
            margin-top: 20px;
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

        h2 + asp\:GridView {
            margin-top: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #007bff;
            color: #fff;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>İş Tanımlama Modülü</h2>
            <div>
                <label for="txtProjectTitle">Proje Başlığı:</label>
                <asp:TextBox ID="txtProjectTitle" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtProjectDescription">Proje Açıklaması:</label>
                <asp:TextBox ID="txtProjectDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div>
                <label for="txtProjectBudget">Proje Bütçesi:</label>
                <asp:TextBox ID="txtProjectBudget" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtProjectDeadline">Proje Bitiş Tarihi:</label>
                <asp:TextBox ID="txtProjectDeadline" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnSaveProject" runat="server" Text="Projeyi Kaydet" OnClick="btnSaveProject_Click" />
            </div>

            <h2>Müşteri Projeleriniz</h2>
            <asp:GridView ID="gvCustomerProjects" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ProjectTitle" HeaderText="Proje Başlığı" />
                    <asp:BoundField DataField="ProjectDescription" HeaderText="Proje Açıklaması" />
                    <asp:BoundField DataField="ProjectBudget" HeaderText="Proje Bütçesi" />
                    <asp:BoundField DataField="ProjectDeadline" HeaderText="Proje Bitiş Tarihi" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
