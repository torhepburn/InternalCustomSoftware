<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Filtering_Default" title="Project Total" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Welcome to the Project Total Site</h1>

    <p>This site is being built as a means to quickly access
    Project data.</p>
    
    <p>Currently it contains Project data:</p>

    <ul>
        <li>Desciption, Finish Date, File Date, Status, </li>
        <li>  Customer, Project Leader.</li>
    </ul>
    <p>Financial Data:</p>
    <ul>
        <li> Total Sales, Transfer Price,</li>
        <li> Labor Cost, Material Cost, Stock Transfers, Other Costs</li>
        <li> and Open POs.</li>
    </ul>
    
    <p>Over time, it will include other Project data:</p>

    <ul>
        <li>Booked Order details,</li>
        <li>Purchase Order details,</li>        
        <li>General Project Costs details.</li>        
        <li>Labor Hours,</li>
        <li>Hour Cost by Month,</li>
        <li>Bill of Material,</li>
        <li>Material Used,</li>        
        <li>Parts List</li>
        <li>Hours by Employee,</li>
        <li>Production Hours,</li>
        <li>And more!</li>
    </ul>
</asp:Content>