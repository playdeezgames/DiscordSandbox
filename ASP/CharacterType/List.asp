<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType"
    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            VIEW_CHARACTER_TYPE_DETAILS,_
            Array(_
                COLUMN_CHARACTER_TYPE_ID,_
                COLUMN_CHARACTER_TYPE_NAME,_
                COLUMN_IS_PLAYER_SELECTABLE, _
                COLUMN_GENERATOR_WEIGHT), _
            Null,_
            Null)
        StartTable 
            ShowTableHeaders(Array("Character Type Id","Character Type Name","Is Player Selectable?","Generator Weight"))    
            do until rs.eof
                StartTableRow
                    TableCellEditLink SubPath, COLUMN_CHARACTER_TYPE_ID, rs
                    TableCell COLUMN_CHARACTER_TYPE_NAME, rs
                    TableCell COLUMN_IS_PLAYER_SELECTABLE, rs
                    TableCell COLUMN_GENERATOR_WEIGHT, rs
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
