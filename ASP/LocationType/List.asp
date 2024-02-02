<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "LocationType"
    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            VIEW_LOCATION_TYPE_DETAILS,_
            Array(COLUMN_LOCATION_TYPE_ID,COLUMN_LOCATION_TYPE_NAME),_
            Null,_
            Null)
        StartTable 
            ShowTableHeaders(Array("Location Type Id","Location Type Name"))
            do until rs.eof
                StartTableRow
                    TableCellEditLink SubPath, COLUMN_LOCATION_TYPE_ID, rs
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
