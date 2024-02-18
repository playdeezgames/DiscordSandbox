<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_LOCATIONS, _
        Array(COLUMN_LOCATION_ID), _
        Array(Request.form(COLUMN_LOCATION_ID))
    RedirectToList "Location"
%>
<!--#include virtual="inc/closeconn.inc"-->
