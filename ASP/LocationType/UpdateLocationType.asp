<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
UpdateRecord Conn, _
    TABLE_LOCATION_TYPES, _
    Array(COLUMN_LOCATION_TYPE_NAME), _
    Array(COLUMN_LOCATION_TYPE_ID), _
    Array(Request.form(COLUMN_LOCATION_TYPE_NAME),Request.form(COLUMN_LOCATION_TYPE_ID))
Response.Redirect("/LocationType/LocationTypeEdit.asp?" & COLUMN_LOCATION_TYPE_ID & "=" & Request.Form(COLUMN_LOCATION_TYPE_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
