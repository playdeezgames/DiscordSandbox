<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CARD_TYPES, _
        Array(COLUMN_CARD_TYPE_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_ID))
    RedirectToList "CardType"
%>
<!--#include virtual="inc/closeconn.inc"-->
