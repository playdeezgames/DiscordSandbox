<!--#include file="inc/AdoVbs.inc"-->
<!--#include file="inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="UPDATE CardTypes SET CardTypeName=? WHERE CardTypeId=?;"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form("CardTypeName")
cmd.Parameters(1).Value=Request.Form("CardTypeId")
cmd.Execute()
Response.Redirect "CardTypeEdit.asp?CardTypeId=" & Request.Form("CardTypeId")
Set cmd=nothing
%>
<!--#include file="inc/closeconn.inc"-->
