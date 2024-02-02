<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardTypeGenerator/CardType"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS, _
        Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,COLUMN_CARD_TYPE_GENERATOR_ID,COLUMN_CARD_TYPE_NAME,COLUMN_CARD_TYPE_GENERATOR_NAME,COLUMN_GENERATOR_WEIGHT), _
        Array(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID), _
        Array(Request.QueryString(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID)))

    StartPage
        BackToEditLink "CardTypeGenerator", "Card Type Generator",COLUMN_CARD_TYPE_GENERATOR_ID,rs

        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, "Id", rs
                ReadonlyTextInput COLUMN_CARD_TYPE_GENERATOR_NAME, "Card Type Generator", rs
                ReadonlyTextInput COLUMN_CARD_TYPE_NAME, "Card Type", rs
                TextInputEdit COLUMN_GENERATOR_WEIGHT, "Generator Weight", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm SubPath
            HiddenInput COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, Request.QueryString
            HiddenInput COLUMN_CARD_TYPE_GENERATOR_ID, rs
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
