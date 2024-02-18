<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "Location"

    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn,_
            VIEW_LOCATION_DETAILS,_
            Array(COLUMN_LOCATION_ID,COLUMN_LOCATION_NAME,COLUMN_LOCATION_TYPE_NAME),_
            Null,_
            Null)
        StartTable 
            ShowTableHeaders(Array("Location Id","Location Name","Location Type"))
            do until rs.eof
                StartTableRow
                TableCellEditLink SubPath, COLUMN_LOCATION_ID, rs
                TableCell COLUMN_LOCATION_NAME, rs
                TableCell COLUMN_LOCATION_TYPE_NAME, rs
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
