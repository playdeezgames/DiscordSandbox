<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CARD_TYPE_GENERATORS, _
        Array(COLUMN_CARD_TYPE_GENERATOR_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_ID))
Response.Redirect("/CardTypeGenerator/List.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
