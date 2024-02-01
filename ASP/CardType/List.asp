<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            VIEW_CARD_TYPE_DETAILS,_
            Array(COLUMN_CARD_TYPE_ID,COLUMN_CARD_TYPE_NAME),_
            Null,_
            Null)

        StartTable 
            ShowTableHeaders(Array("Card Type Id","Card Type Name"))
            do until rs.eof
                StartTableRow
                    TableCellEditLink "CardType", COLUMN_CARD_TYPE_ID, rs
                    TableCell COLUMN_CARD_TYPE_NAME, rs
                EndTableRow
                rs.movenext
            loop
        EndTable 
        rs.close
        set rs = nothing

        AddLink "CardType", "new"
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
