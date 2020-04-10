<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <p>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    
    <p align="center" >
        <br />
        WELCOME TO THE TEST</p>
    &nbsp;&nbsp;
    <p align="center" >
        This is a timed test.
    </p>
<p align="center" >
        You will be awarded 1 mark for every correct answer and no mark will be deducted 
        for a wrong answer.</p>
<p align="center" >
        You have 60 seconds of time.</p>
    <p align="center">
        Please click the START button to begin the test.</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p align="center" >
        <asp:Button ID="Button1" runat="server" Text="START" Height="36px" 
            Width="93px" />
    </p>
    <p>
    </p>
    <p>
        <marquee>ALL THE BEST</marquee>&nbsp;</p>
    <p>
    </p>
</asp:Content>

