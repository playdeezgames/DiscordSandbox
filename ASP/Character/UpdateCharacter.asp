<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
UpdateRecord Conn, TABLE_CHARACTERS, Array(COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID), Array(COLUMN_CHARACTER_ID), Array(Request.form(COLUMN_CHARACTER_NAME),Request.form(COLUMN_CHARACTER_TYPE_ID),Request.form(COLUMN_LOCATION_ID),Request.form(COLUMN_CHARACTER_ID))
Response.Redirect("/Character/CharacterEdit.asp?" & COLUMN_CHARACTER_ID & "=" & Request.Form(COLUMN_CHARACTER_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
