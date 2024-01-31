<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CHARACTER_TYPE_STATISTICS, _
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID), _
        Array(Request.form(COLUMN_CHARACTER_TYPE_STATISTIC_ID))
Response.Redirect("/CharacterType/Edit.asp?" & COLUMN_CHARACTER_TYPE_ID & "=" & Request.Form(COLUMN_CHARACTER_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
