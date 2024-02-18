<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    UpdateRecord Conn, _
        TABLE_LOCATIONS, _
        Array(COLUMN_LOCATION_NAME,COLUMN_LOCATION_TYPE_ID), _
        Array(COLUMN_LOCATION_ID), _
        Array(Request.form(COLUMN_LOCATION_NAME),Request.form(COLUMN_LOCATION_TYPE_ID),Request.form(COLUMN_LOCATION_ID))
    RedirectToEdit "Location", COLUMN_LOCATION_ID, Request.Form
%>
<!--#include virtual="inc/closeconn.inc"-->
