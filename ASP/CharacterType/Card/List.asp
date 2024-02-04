<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType/Card"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CHARACTER_TYPE_CARD_DETAILS,_
        Array(_
            COLUMN_CHARACTER_TYPE_CARD_ID,_
            COLUMN_CARD_TYPE_NAME,
            COLUMN_CARD_QUANTITY),_
        Array(COLUMN_CHARACTER_TYPE_ID),_
        Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
    StartTable 
        ShowTableHeaders(Array("Character Type Card Id","Card Type Name","Card Quantity"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_CHARACTER_TYPE_CARD_ID, rs
                TableCell COLUMN_CARD_TYPE_NAME, rs
                TableCell COLUMN_CARD_QUANTITY, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.close
    set rs = nothing

    FilterAddLink SubPath, "new statistic", COLUMN_CHARACTER_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
