<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CHARACTERS, _
        Array(COLUMN_CHARACTER_ID), _
        Array(Request.form(COLUMN_CHARACTER_ID))
    RedirectToList "Character"
%>
<!--#include virtual="inc/closeconn.inc"-->
