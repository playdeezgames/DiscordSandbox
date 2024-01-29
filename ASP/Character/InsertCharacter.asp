<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, TABLE_CHARACTERS, Array(COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID), Array(Request.form(COLUMN_CHARACTER_NAME),Request.form(COLUMN_CHARACTER_TYPE_ID),Request.form(COLUMN_LOCATION_ID))
Response.Redirect("/Character/CharacterList.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
