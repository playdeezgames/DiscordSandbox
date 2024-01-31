<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, _
    TABLE_CARD_TYPES, _
    Array(COLUMN_CARD_TYPE_NAME), _
    Array(Request.form(COLUMN_CARD_TYPE_NAME))
    RedirectToList "CardType"
%>
<!--#include virtual="inc/closeconn.inc"-->
