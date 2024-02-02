<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType/Statistic"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CHARACTER_TYPE_STATISTIC_DETAILS,_
        Array(COLUMN_CHARACTER_TYPE_STATISTIC_ID,_
            COLUMN_STATISTIC_TYPE_NAME,_
            COLUMN_STATISTIC_VALUE,_
            COLUMN_MAXIMUM_VALUE,_
            COLUMN_MINIMUM_VALUE),_
        Array(COLUMN_CHARACTER_TYPE_ID),_
        Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
    StartTable 
        ShowTableHeaders(Array("Character Type Statistic Id","Statistic Type Name","Statistic Value","Minimum Value","Maximum Value"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_CHARACTER_TYPE_STATISTIC_ID, rs
                TableCell COLUMN_STATISTIC_TYPE_NAME, rs
                TableCell COLUMN_STATISTIC_VALUE, rs
                TableCell COLUMN_MINIMUM_VALUE, rs
                TableCell COLUMN_MAXIMUM_VALUE, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.close
    set rs = nothing

    FilterAddLink SubPath, "new statistic", COLUMN_CHARACTER_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
