<%Option Explicit%>
<!--#include virtual="inc/Grimoire.asp"-->
<%
    If Request.Form("axn")="Add" Then
        Server.Execute("/CardType/Effect/Insert.asp")
    elseif Request.Form("axn")="Remove" Then
        Server.Execute("/CardType/Effect/Delete.asp")
    end if
    RedirectToEdit "CardType", COLUMN_CARD_TYPE_ID, Request.Form
%>
