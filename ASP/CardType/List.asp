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
            Array( _
                COLUMN_CARD_TYPE_ID, _
                COLUMN_CARD_TYPE_NAME, _
                COLUMN_SELF_DESTRUCT, _ 
                COLUMN_CARD_LIMIT, _
                COLUMN_ALWAYS_AVAILABLE, _
                COLUMN_HAND_SIZE),_
            Null,_
            Null)

        StartTable 
            ShowTableHeaders(Array("Card Type Id","Card Type Name","Self Destruct","Card Limit","Always Available","Counts Towards Hand Size"))
            do until rs.eof
                StartTableRow
                    TableCellEditLink "CardType", COLUMN_CARD_TYPE_ID, rs
                    TableCell COLUMN_CARD_TYPE_NAME, rs
                    TableCell COLUMN_SELF_DESTRUCT, rs
                    TableCell COLUMN_CARD_LIMIT, rs
                    TableCell COLUMN_ALWAYS_AVAILABLE, rs
                    TableCell COLUMN_HAND_SIZE, rs
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
