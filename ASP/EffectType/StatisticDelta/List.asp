<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/StatisticDelta"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_EFFECT_TYPE_STATISTIC_DELTA_DETAILS, _
        Array( _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_NAME, _
            COLUMN_STATISTIC_VALUE, _
            COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID), _
        Array(COLUMN_EFFECT_TYPE_ID), _
        Array(Request.QueryString(COLUMN_EFFECT_TYPE_ID)))

    StartTable
        ShowTableHeaders(Array("Effect Type Statistic Delta Id","Statistic Type","Statistic Value"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID, rs
                TableCell COLUMN_STATISTIC_TYPE_NAME, rs
                TableCell COLUMN_STATISTIC_VALUE, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.Close
    Set rs = nothing

    FilterAddLink SubPath, "new delta", COLUMN_EFFECT_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
