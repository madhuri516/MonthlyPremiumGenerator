<%@ Page Title="Premium Calculator" Language="C#" AutoEventWireup="true" CodeBehind="PremiumCalculator.aspx.cs" Inherits="MonthlyPremiumGenerator.WebForm1" %>
    <!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Premium Calculator</title>

</head>
<body>
    <h3> Premium Calculator </h3>
    <p>Please fill in this form to calculate monthly premium. All fields are mandatory.</p>
    
    <form id="FormDetails" name="FormDetails" runat="server">
        <asp:scriptmanager id="ScriptManager1" runat="server" />
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" BorderColor="#3399FF" BorderStyle="Solid" Width="909px">
                <br />
            &nbsp;<asp:Label ID="NameLabel" runat="server">Name</asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" id="NameTextInput" />
            &nbsp;<asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ControlToValidate="NameTextInput" Display="Dynamic" ErrorMessage="Name field can't be left blank!" ForeColor="Red" SetFocusOnError="True" ValidationGroup="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <br />
                <br />
&nbsp;<asp:Label ID="AgeLabel" runat="server" Text="Age"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="AgeTextInput" runat="server" OnTextChanged="AgeTextInput_TextChanged"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="AgeRequiredFieldValidator" runat="server" ControlToValidate="AgeTextInput" ErrorMessage="Age field can't be left blank!" ForeColor="Red" ValidationGroup="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;<asp:Label ID="DOBLabel" runat="server" Text="DateOfBirth"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CalendarTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="CalendarTextBoxRequiredFieldValidator" runat="server" ControlToValidate="CalendarTextBox" ErrorMessage="Date Of Birth field can't be left blank!" ForeColor="Red" ValidationGroup="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <asp:Calendar ID="DOBCalendarInput" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="DOBCalendarInput_SelectionChanged" SelectedDate="05/31/2021 12:17:53" SelectionMode="DayWeekMonth" VisibleDate="2021-05-31" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
&nbsp;
                <br />
&nbsp;<asp:Label ID="DeathSumLabel" runat="server" Text="Death-SumInsured"></asp:Label>
                &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="DeathSumTextInput" runat="server" OnTextChanged="DeathSumTextInput_TextChanged"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="DeathSumRequiredFieldValidator" runat="server" ControlToValidate="DeathSumTextInput" ErrorMessage="Death Sum field can't be left blank!" ForeColor="Red" ValidationGroup="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;<asp:Label ID="OccupationLabel" runat="server" Text="Occupation"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="OccupationDropDownList" runat="server" autopostback="true" OnSelectedIndexChanged="OccupationDropDownList_SelectedIndexChanged" Width="269px" CausesValidation="True">
                <asp:ListItem Enabled="True" Selected="True">Select Occupation</asp:ListItem>
                <asp:ListItem>Cleaner</asp:ListItem>
                <asp:ListItem>Doctor</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>
                <asp:ListItem>Farmer</asp:ListItem>
                <asp:ListItem>Mechanic</asp:ListItem>
                <asp:ListItem>Florist</asp:ListItem>
            </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="OccupationRequiredFieldValidator" runat="server" ControlToValidate="OccupationDropDownList" ErrorMessage="Please select an Occupation..." ForeColor="Red" ValidationGroup="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ValidationGroup="RequiredFieldValidator" />
                <br />
            <br />
            <br />
                </asp:Panel>
        </div>

    </form>
</body>
</html>
