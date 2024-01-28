<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="/inc/AdoVbs.inc"-->
<!--#include virtual="/inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="UPDATE " & TABLE_CARD_TYPES & " SET " & COLUMN_CARD_TYPE_NAME & "=?," & COLUMN_DELETE_ON_PLAY & "=? WHERE " & COLUMN_CARD_TYPE_ID & "=?;"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form(COLUMN_CARD_TYPE_NAME)
if Request.Form(COLUMN_DELETE_ON_PLAY)=1 Then
    cmd.Parameters(1).Value=True
else
    cmd.Parameters(1).Value=False
end if
cmd.Parameters(2).Value=Request.Form(COLUMN_CARD_TYPE_ID)
cmd.Execute()
Response.Redirect "/CardType/CardTypeList.asp"
Set cmd=nothing
%>
<!--#include virtual="/inc/closeconn.inc"-->
