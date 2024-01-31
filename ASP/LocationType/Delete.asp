<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    DeleteRecordIfConfirmed Conn, _
        TABLE_LOCATION_TYPES, _
        Array(COLUMN_LOCATION_TYPE_ID), _
        Array(Request.form(COLUMN_LOCATION_TYPE_ID))
RedirectToList "LocationType"

%>
<!--#include virtual="inc/closeconn.inc"-->
