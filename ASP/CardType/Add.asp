<%
    Option Explicit
%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Server.Execute("/inc/Start.asp")
    BackToListLink "CardType", "Card Type"
    StartInsertForm "CardType"
    StartTable 
    NameInput COLUMN_CARD_TYPE_NAME, "Name"
    SubmitButton 
    EndTable 
    EndForm
    Server.Execute("/inc/End.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
