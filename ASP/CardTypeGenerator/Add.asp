<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    StartPage
        BackToListLink "CardTypeGenerator", "Card Type Generator"

        StartInsertForm "CardTypeGenerator"
            StartTable 
                TextInputAdd COLUMN_CARD_TYPE_GENERATOR_NAME, "Name"
                SubmitButton
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
