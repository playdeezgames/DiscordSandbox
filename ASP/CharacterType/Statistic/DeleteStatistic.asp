<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, _
        TABLE_CHARACTER_TYPE_STATISTICS, _
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_STATISTIC_ID))
end if
Response.Redirect("/CharacterType/Edit.asp?" & COLUMN_CHARACTER_TYPE_ID & "=" & Request.Form(COLUMN_CHARACTER_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
