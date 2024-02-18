<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType"
    StartPage
        BackToListLink SubPath, "Character Type"

        StartInsertForm SubPath
            StartTable 
                TextInputAdd COLUMN_CHARACTER_TYPE_NAME, "Name"
                CheckboxInputAdd COLUMN_IS_PLAYER_SELECTABLE, "Is Player Selectable?", False
                TextInputAdd COLUMN_GENERATOR_WEIGHT, "Generator Weight"
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
