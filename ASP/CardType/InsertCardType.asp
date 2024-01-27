<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<%
Set cmd = Server.CreateObject("ADODB.Command")
Set cmd.activeconnection=conn
cmd.CommandType=adCmdText
cmd.CommandText="INSERT CardTypes(CardTypeName,DeleteOnPlay) VALUES(?,?);"
cmd.Parameters.Refresh
cmd.Parameters(0).Value=Request.Form("CardTypeName")
if Request.Form("DeleteOnPlay")=1 then
    cmd.Parameters(1).Value=True
else
    cmd.Parameters(1).Value=False
end if
cmd.Execute()
Response.Redirect "/CardType/CardTypeList.asp"
Set cmd=nothing
%>
<!--#include virtual="inc/closeconn.inc"-->
