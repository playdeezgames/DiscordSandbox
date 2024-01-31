<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
UpdateRecord Conn, _
    TABLE_CARD_TYPE_GENERATOR_CARD_TYPES, _
    Array(COLUMN_GENERATOR_WEIGHT), _
    Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
    Array(Request.form(COLUMN_GENERATOR_WEIGHT),Request.form(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID))
Response.Redirect("/CardTypeGenerator/CardType/CardTypeEdit.asp?" & COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID & "=" & Request.Form(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
