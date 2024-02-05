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
            COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, _
            COLUMN_EFFECT_TYPE_ID, _
            COLUMN_CARD_COUNT, _
            COLUMN_EFFECT_TYPE_NAME, _
            COLUMN_CARD_TYPE_GENERATOR_NAME), _
        Array(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID), _
        Array(Request.QueryString(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID)))

    StartPage
        BackToEditLink "EffectType", "Effect Type",COLUMN_EFFECT_TYPE_ID,rs
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, "Id", rs
                ReadonlyTextInput COLUMN_EFFECT_TYPE_NAME, "Effect Type", rs
                ReadonlyTextInput COLUMN_CARD_TYPE_GENERATOR_NAME, "Card Type Generator", rs
                TextInputEdit COLUMN_CARD_COUNT, "Card Count", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, Request.QueryString
            HiddenInput COLUMN_EFFECT_TYPE_ID, rs
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm
    EndPage
    rs.close
    set rs = nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
