<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType/Card"
    Dim rs
    Set rs = ExecuteSelectCommand(conn, _
        VIEW_CHARACTER_TYPE_CARD_DETAILS, _
        Array(COLUMN_CHARACTER_TYPE_CARD_ID, _
        COLUMN_CHARACTER_TYPE_ID, _
        COLUMN_CARD_QUANTITY, _
        COLUMN_CHARACTER_TYPE_NAME, _
        COLUMN_CARD_TYPE_NAME), _
        Array(COLUMN_CHARACTER_TYPE_CARD_ID), _
        Array(Request.QueryString(COLUMN_CHARACTER_TYPE_CARD_ID)))

    StartPage
        BackToEditLink "CharacterType", "Character Type",COLUMN_CHARACTER_TYPE_ID,rs
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_CARD_ID, "Id", rs
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_NAME, "Character Type", rs
                ReadonlyTextInput COLUMN_CARD_TYPE_NAME, "Card Type", rs
                TextInputEdit COLUMN_CARD_QUANTITY, "Card Quantity", rs
                SubmitButton 
            EndTable 
        EndForm

        StartDeleteForm SubPath
            HiddenInput COLUMN_CHARACTER_TYPE_CARD_ID, Request.QueryString
            HiddenInput COLUMN_CHARACTER_TYPE_ID, rs
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
