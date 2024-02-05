<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/CardTypeGenerator"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_EFFECT_TYPE_CARD_TYPE_GENERATOR_DETAILS, _
        Array( _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_CARD_TYPE_GENERATOR_ID, _
            COLUMN_CARD_TYPE_GENERATOR_NAME, _
            COLUMN_CARD_COUNT, _
            COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID), _
        Array(COLUMN_EFFECT_TYPE_ID), _
        Array(Request.QueryString(COLUMN_EFFECT_TYPE_ID)))

    StartTable
        ShowTableHeaders(Array("Effect Type Card Type Generator Id","Card Type Generator","Card Count"))
        do until rs.eof
            StartTableRow
                TableCellEditLink SubPath, COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, rs
                TableCell COLUMN_CARD_TYPE_GENERATOR_NAME, rs
                TableCell COLUMN_CARD_COUNT, rs
            EndTableRow
            rs.movenext
        loop
    EndTable
    rs.Close
    Set rs = nothing

    FilterAddLink SubPath, "new generator", COLUMN_EFFECT_TYPE_ID, Request.QueryString
%>
<!--#include virtual="inc/closeconn.inc"-->
