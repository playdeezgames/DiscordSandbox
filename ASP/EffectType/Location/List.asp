<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/Location"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_EFFECT_TYPE_LOCATION_DETAILS, _
        Array( _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_LOCATION_ID, _
            COLUMN_LOCATION_NAME, _
            COLUMN_EFFECT_TYPE_LOCATION_ID), _
        Array(COLUMN_EFFECT_TYPE_ID), _
        Array(Request.QueryString(COLUMN_EFFECT_TYPE_ID)))

    StartTable
        ShowTableHeaders(Array("Effect Type Location Id","Location"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_EFFECT_TYPE_LOCATION_ID, rs
                TableCell COLUMN_LOCATION_NAME, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.Close
    Set rs = nothing

    FilterAddLink SubPath, "new location", COLUMN_EFFECT_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
