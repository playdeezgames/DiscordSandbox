<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardTypeGenerator"

    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            VIEW_CARD_TYPE_GENERATOR_DETAILS,_
            Array(COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_GENERATOR_NAME),_
            Null,_
            Null)

        StartTable 
            ShowTableHeaders(Array("Card Type Generator Id","Card Type Generator Name"))
            do until rs.eof
                StartTableRow
                    TableCellEditLink SubPath, COLUMN_CARD_TYPE_GENERATOR_ID, rs
                    TableCell COLUMN_CARD_TYPE_GENERATOR_NAME, rs
                EndTableRow
            rs.movenext
            loop
        EndTable 
        rs.close
        set rs = nothing

        AddLink SubPath, "new"
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
