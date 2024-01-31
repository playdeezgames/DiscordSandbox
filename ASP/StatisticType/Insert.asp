<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, _
    TABLE_STATISTIC_TYPES, _
    Array(COLUMN_STATISTIC_TYPE_NAME), _
    Array(Request.form(COLUMN_STATISTIC_TYPE_NAME))
RedirectToList "StatisticType"
%>
<!--#include virtual="inc/closeconn.inc"-->
