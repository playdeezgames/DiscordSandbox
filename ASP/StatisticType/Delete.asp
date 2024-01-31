<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_STATISTIC_TYPES, _
        Array(COLUMN_STATISTIC_TYPE_ID), _
        Array(Request.form(COLUMN_STATISTIC_TYPE_ID))
Response.Redirect("/StatisticType/List.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
