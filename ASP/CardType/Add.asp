<%
    Option Explicit
%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    StartPage
        BackToListLink "CardType", "Card Type"
        StartInsertForm "CardType"
            StartTable 
                TextInputAdd COLUMN_CARD_TYPE_NAME, "Name"
                CheckboxInputAdd COLUMN_SELF_DESTRUCT, "Self Destruct", False
                TextInputAdd COLUMN_CARD_LIMIT, "Limit"
                CheckboxInputAdd COLUMN_ALWAYS_AVAILABLE, "Always Available", False
                CheckboxInputAdd COLUMN_HAND_SIZE, "Counts Towards Hand Size", True
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
