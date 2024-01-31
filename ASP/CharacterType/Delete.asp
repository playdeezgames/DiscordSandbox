<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CHARACTER_TYPES, _
        Array(COLUMN_CHARACTER_TYPE_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_ID))
    RedirectToList "CharacterType"
%>
<!--#include virtual="inc/closeconn.inc"-->
