<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CARD_TYPE_EFFECT_DETAILS, _
        Array( _
            COLUMN_CARD_TYPE_ID, _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_EFFECT_TYPE_NAME, _
            COLUMN_CARD_TYPE_EFFECT_ID), _
        Array(COLUMN_CARD_TYPE_ID), _
        Array(Request.QueryString(COLUMN_CARD_TYPE_ID)))

    StartTable
    ShowTableHeaders(Array("Effect Type","Action"))
        do until rs.eof
            StartUpdateForm "CardType/Effect"
                HiddenInput COLUMN_CARD_TYPE_ID, rs
                StartTableRow
                    TableCell COLUMN_EFFECT_TYPE_NAME, rs
                    If IsNull(rs(COLUMN_CARD_TYPE_EFFECT_ID)) Then
                        HiddenInput COLUMN_EFFECT_TYPE_ID, rs
                        TableCellActionButton "Add"
                    else
                        HiddenInput COLUMN_CARD_TYPE_EFFECT_ID, rs
                        TableCellActionButton "Remove"
                    end if  
                EndTableRow
            EndForm
            rs.movenext
        loop
    EndTable
    rs.Close
    Set rs = nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
