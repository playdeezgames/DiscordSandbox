<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, _
        TABLE_CHARACTER_TYPES, _
        Array(COLUMN_CHARACTER_TYPE_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_ID))
end if
Response.Redirect("/CharacterType/List.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
