<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
    Const SubPath = "CharacterType"

    StartPage
        BackToListLink SubPath, "Character Type"

        Dim rs
        Set rs = ExecuteSelectCommand(conn, _
            TABLE_CHARACTER_TYPES, _
            Array(COLUMN_CHARACTER_TYPE_ID, _
            COLUMN_CHARACTER_TYPE_NAME, _
            COLUMN_IS_PLAYER_SELECTABLE, _
            COLUMN_GENERATOR_WEIGHT), _
            Array(COLUMN_CHARACTER_TYPE_ID), _
            Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_CHARACTER_TYPE_NAME, "Name", rs
                CheckboxInputEdit COLUMN_IS_PLAYER_SELECTABLE, "Is Player Selectable?", rs
                TextInputEdit COLUMN_GENERATOR_WEIGHT, "Generator Weight", rs
                SubmitButton 
            EndTable 
        EndForm
        rs.close
        set rs = nothing

        StartDeleteForm SubPath
            HiddenInput COLUMN_CHARACTER_TYPE_ID, Request.QueryString
            StartTable 
                ConfirmDeleteCheckbox
                SubmitButton 
            EndTable 
        EndForm

        Server.Execute("/CharacterType/Statistic/List.asp")
    EndPage
%>
<!--#include virtual="inc/closeconn.inc"-->
