<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, _
    TABLE_CHARACTER_TYPES, _
    Array(COLUMN_CHARACTER_TYPE_NAME), _
    Array(Request.form(COLUMN_CHARACTER_TYPE_NAME))
RedirectToList "CharacterType"
%>
<!--#include virtual="inc/closeconn.inc"-->
