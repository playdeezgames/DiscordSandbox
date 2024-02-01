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
            Array(COLUMN_CHARACTER_TYPE_ID,COLUMN_CHARACTER_TYPE_NAME), _
            Array(COLUMN_CHARACTER_TYPE_ID), _
            Array(Request.QueryString(COLUMN_CHARACTER_TYPE_ID)))
        StartUpdateForm SubPath
            StartTable 
                ReadonlyTextInput COLUMN_CHARACTER_TYPE_ID, "Id", rs
                TextInputEdit COLUMN_CHARACTER_TYPE_NAME, "Name", rs
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
