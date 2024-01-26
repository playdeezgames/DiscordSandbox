<!--#include file="inc/AdoVbs.inc"-->
<!--#include file="inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="INSERT CardTypes(CardTypeName,DeleteOnPlay) VALUES(?,?);"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form("CardTypeName")
cmd.Parameters(1).Value=0
cmd.Execute()
Response.Redirect "CardTypeList.asp"
Set cmd=nothing
%>
<!--#include file="inc/closeconn.inc"-->
