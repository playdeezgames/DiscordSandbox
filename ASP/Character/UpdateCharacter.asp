<%Option Explicit%>
<!--#include virtual="inc/openconn.inc"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/Grimoire.asp"-->
<%
Dim TableName
TableName=TABLE_CHARACTERS
Dim ColumnNames
ColumnNames=Array(COLUMN_CHARACTER_NAME,COLUMN_CHARACTER_TYPE_ID,COLUMN_LOCATION_ID)
Dim FilterColumns
FilterColumns = Array(COLUMN_CHARACTER_ID)
Dim ColumnValues
ColumnValues=Array(Request.form(COLUMN_CHARACTER_NAME),Request.form(COLUMN_CHARACTER_TYPE_ID),Request.form(COLUMN_LOCATION_ID),Request.form(COLUMN_CHARACTER_ID))

Dim result
result="UPDATE " & TableName & " SET " & Join(ColumnNames," = ?," ) & " = ? WHERE " & Join(FilterColumns," = ? AND ") & " = ?;"

Dim cmd
Set cmd = Server.CreateObject("ADODB.Command")
cmd.activeconnection=Conn
cmd.CommandType=adCmdText
cmd.CommandText= result
cmd.Parameters.Refresh
Dim index
for index=0 to ubound(ColumnValues)
    cmd.Parameters(index)=ColumnValues(index)
next
cmd.Execute()
Set cmd = nothing
Response.Redirect("/Character/CharacterEdit.asp?" & COLUMN_CHARACTER_ID & "=" & Request.Form(COLUMN_CHARACTER_ID))
%>
<!--#include virtual="inc/closeconn.inc"-->
