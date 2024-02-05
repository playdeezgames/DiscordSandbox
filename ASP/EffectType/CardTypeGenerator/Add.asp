<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "EffectType/CardTypeGenerator"
    StartPage
        BackToEditLink "EffectType", "Effect Type", COLUMN_EFFECT_TYPE_ID, Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_EFFECT_TYPE_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_CARD_TYPE_GENERATOR_ID, "Card Type Generator", Conn, VIEW_EFFECT_TYPE_AVAILABLE_CARD_TYPE_GENERATORS, COLUMN_CARD_TYPE_GENERATOR_NAME, COLUMN_EFFECT_TYPE_ID, Request.QueryString
                TextInputAdd COLUMN_CARD_COUNT, "Card Count"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
