<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, _
        TABLE_CHARACTERS, _
        Array(COLUMN_CHARACTER_ID), _
        Array(Request.form(COLUMN_CHARACTER_ID))
end if
Response.Redirect("/Character/List.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
