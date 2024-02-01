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
                SubmitButton 
            EndTable 
        EndForm
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
