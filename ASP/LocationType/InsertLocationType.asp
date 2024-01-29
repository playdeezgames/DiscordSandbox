<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
InsertRecord Conn, _
    TABLE_LOCATION_TYPES, _
    Array(COLUMN_LOCATION_TYPE_NAME), _
    Array(Request.form(COLUMN_LOCATION_TYPE_NAME))
Response.Redirect("/LocationType/LocationTypeList.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
