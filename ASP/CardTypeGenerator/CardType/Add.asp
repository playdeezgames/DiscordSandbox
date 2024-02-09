<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CardTypeGenerator/CardType"
    StartPage
        BackToEditLink "CardTypeGenerator","Card Type Generator",COLUMN_CARD_TYPE_GENERATOR_ID,Request.QueryString
        StartInsertForm SubPath
            HiddenInput COLUMN_CARD_TYPE_GENERATOR_ID,Request.QueryString
            StartTable 
                FilteredComboBoxAdd COLUMN_CARD_TYPE_ID, "Card Type", Conn, VIEW_CARD_TYPE_GENERATOR_AVAILABLE_CARD_TYPES, COLUMN_CARD_TYPE_NAME, COLUMN_CARD_TYPE_GENERATOR_ID, Request.QueryString, False
                TextInputAdd COLUMN_GENERATOR_WEIGHT, "Generator Weight"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
