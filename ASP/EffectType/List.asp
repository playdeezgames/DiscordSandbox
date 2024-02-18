<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType"
    StartPage
        BackToMainMenuLink

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            VIEW_EFFECT_TYPE_DETAILS,_
            Array( _
                COLUMN_EFFECT_TYPE_ID, _
                COLUMN_EFFECT_TYPE_NAME, _
                COLUMN_LOCATION_TYPE_NAME, _
                COLUMN_REFRESH_HAND),_
            Null,_
            Null)
        StartTable 
            ShowTableHeaders(Array("Effect Type Id","Effect Type Name","Location Type Name","Refresh Hand"))    
            do until rs.eof
                StartTableRow
                    TableCellEditLink SubPath, COLUMN_EFFECT_TYPE_ID, rs
                    TableCell COLUMN_EFFECT_TYPE_NAME, rs
                    TableCell COLUMN_LOCATION_TYPE_NAME, rs
                    TableCell COLUMN_REFRESH_HAND, rs
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
