<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardType/StatisticRequirement"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CARD_TYPE_STATISTIC_REQUIREMENT_DETAILS, _
        Array( _
            COLUMN_CARD_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_ID, _
            COLUMN_STATISTIC_TYPE_NAME, _
            COLUMN_MINIMUM_VALUE, _
            COLUMN_MAXIMUM_VALUE, _
            COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID), _
        Array(COLUMN_CARD_TYPE_ID), _
        Array(Request.QueryString(COLUMN_CARD_TYPE_ID)))

    StartTable
        ShowTableHeaders(Array("Card Type Statistic Requirement Id","Statistic Type","Minimum Value","Maximum Value"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_CARD_TYPE_STATISTIC_REQUIREMENT_ID, rs
                TableCell COLUMN_STATISTIC_TYPE_NAME, rs
                TableCell COLUMN_MINIMUM_VALUE, rs
                TableCell COLUMN_MAXIMUM_VALUE, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.Close
    Set rs = nothing

    FilterAddLink SubPath, "new requirement", COLUMN_CARD_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
