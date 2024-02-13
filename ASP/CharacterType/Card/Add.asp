<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType/Card"
    StartPage
        BackToEditLink "CharacterType","Character Type",COLUMN_CHARACTER_TYPE_ID,Request.QueryString

        StartInsertForm SubPath
            HiddenInput COLUMN_CHARACTER_TYPE_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_CARD_TYPE_ID, "Card Type", Conn, VIEW_CHARACTER_TYPE_AVAILABLE_CARDS, COLUMN_CARD_TYPE_NAME, COLUMN_CHARACTER_TYPE_ID, Request.QueryString, False
                TextInputAdd COLUMN_CARD_QUANTITY, "Quantity"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
