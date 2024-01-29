<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
if request.form("ConfirmDelete")="1" then
    DeleteRecord Conn, _
        TABLE_LOCATION_TYPES, _
        Array(COLUMN_LOCATION_TYPE_ID), _
        Array(Request.form(COLUMN_LOCATION_TYPE_ID))
end if
Response.Redirect("/LocationType/LocationTypeList.asp")
%>
<!--#include virtual="inc/closeconn.inc"-->
