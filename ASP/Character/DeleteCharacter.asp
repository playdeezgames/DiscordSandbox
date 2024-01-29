<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, TABLE_CHARACTERS, Array(COLUMN_CHARACTER_ID), Array(Request.form(COLUMN_CHARACTER_ID))
end if
Response.Redirect("/Character/CharacterList.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
