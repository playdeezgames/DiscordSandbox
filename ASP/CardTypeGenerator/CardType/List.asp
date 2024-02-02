<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardTypeGenerator/CardType"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS,_
        Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,_
            COLUMN_CARD_TYPE_GENERATOR_ID,_
            COLUMN_CARD_TYPE_ID,_
            COLUMN_GENERATOR_WEIGHT,_
            COLUMN_CARD_TYPE_GENERATOR_NAME,_
            COLUMN_CARD_TYPE_NAME),_
        Array(COLUMN_CARD_TYPE_GENERATOR_ID),_
        Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_ID)))

    StartTable 
        ShowTableHeaders(Array("Card Type Generator Card Type Id","Card Type","Generator Weight"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, rs
                TableCell COLUMN_CARD_TYPE_NAME, rs
                TableCell COLUMN_GENERATOR_WEIGHT, rs
            EndTableRow
            rs.movenext
        loop
    EndTable 

    FilterAddLink SubPath, "new card type", COLUMN_CARD_TYPE_GENERATOR_ID, Request.QueryString

    rs.close
    set rs = nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
