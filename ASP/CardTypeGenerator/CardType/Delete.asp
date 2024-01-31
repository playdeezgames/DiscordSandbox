<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CARD_TYPE_GENERATOR_CARD_TYPES, _
        Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID))
Response.Redirect("/CardTypeGenerator/Edit.asp?" & COLUMN_CARD_TYPE_GENERATOR_ID & "=" & Request.Form(COLUMN_CARD_TYPE_GENERATOR_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
