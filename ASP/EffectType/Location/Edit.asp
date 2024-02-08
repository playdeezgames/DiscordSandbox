<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/Location"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_EFFECT_TYPE_LOCATION_DETAILS, _
        Array( _
            COLUMN_EFFECT_TYPE_LOCATION_ID, _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_EFFECT_TYPE_NAME, _
            COLUMN_LOCATION_NAME), _
        Array(COLUMN_EFFECT_TYPE_LOCATION_ID), _
        Array(Request.QueryString(COLUMN_EFFECT_TYPE_LOCATION_ID)))

    StartPage
        BackToEditLink "EffectType", "Effect Type",COLUMN_EFFECT_TYPE_ID,rs

        StartDeleteForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID, rs
            StartTable 
                ReadonlyTextInput COLUMN_EFFECT_TYPE_LOCATION_ID, "Id", rs
                ReadonlyTextInput COLUMN_EFFECT_TYPE_NAME, "Effect Type", rs
                ReadonlyTextInput COLUMN_LOCATION_NAME, "Location", rs
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
    rs.close
    set rs = nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
