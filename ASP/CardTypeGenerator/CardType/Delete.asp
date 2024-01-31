<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, _
        TABLE_CARD_TYPE_GENERATOR_CARD_TYPES, _
        Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
        Array(Request.form(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID))
end if
Response.Redirect("/CardTypeGenerator/Edit.asp?" & COLUMN_CARD_TYPE_GENERATOR_ID & "=" & Request.Form(COLUMN_CARD_TYPE_GENERATOR_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
