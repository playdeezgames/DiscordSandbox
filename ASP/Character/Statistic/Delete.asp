<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_CHARACTER_STATISTICS, _
        Array(COLUMN_CHARACTER_STATISTIC_ID), _
        Array(Request.form(COLUMN_CHARACTER_STATISTIC_ID))
    RedirectToEdit "Character", COLUMN_CHARACTER_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
