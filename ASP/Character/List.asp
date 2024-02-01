<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Character"

    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn,_
            VIEW_CHARACTER_DETAILS,_
            Array(COLUMN_CHARACTER_ID,COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_NAME,COLUMN_LOCATION_NAME),_
            Null,_
            Null)
        StartTable 
            ShowTableHeaders(Array("Character Id","Character Name","Character Type","Location"))
            do until rs.eof
                StartTableRow
                TableCellEditLink SubPath, COLUMN_CHARACTER_ID, rs
                TableCell COLUMN_CHARACTER_NAME, rs
                TableCell COLUMN_CHARACTER_TYPE_NAME, rs
                TableCell COLUMN_LOCATION_NAME, rs
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
