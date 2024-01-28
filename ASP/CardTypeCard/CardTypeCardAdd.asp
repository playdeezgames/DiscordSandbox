<!--#include virtual="inc/Grimoire.asp"-->
<!--#include virtual="inc/AdoVbs.inc"-->
<!--#include virtual="inc/openconn.inc"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardTypeCard/CardTypeCardList.asp?<%=COLUMN_CARD_TYPE_ID%>=<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>">Back to Card Type Card List</a></p>
        <form action="/CardTypeCard/InsertCardTypeCard.asp" method="post">
            <input type="hidden" name="<%=COLUMN_CARD_TYPE_ID%>" value="<%=Request.QueryString(COLUMN_CARD_TYPE_ID)%>"/>
            <%
            set cmd=server.CreateObject("ADODB.Command")
            Set cmd.activeconnection=conn
            cmd.CommandType=adCmdText
            cmd.CommandText="SELECT " & COLUMN_CARD_TYPE_NAME & " FROM " & TABLE_CARD_TYPES & " WHERE " & COLUMN_CARD_TYPE_ID & "=?;"
            cmd.Parameters.Refresh
            cmd.Parameters(0).Value=Request.QueryString(COLUMN_CARD_TYPE_ID)
            set rs = cmd.Execute()
            rs.movefirst
            %>
            <p> Card Type: <%=rs(COLUMN_CARD_TYPE_NAME)%></p>
            <%
            set rs = nothing
            set cmd=nothing
            %>
            <p>Character: 
                <select name="<%=COLUMN_CHARACTER_ID%>">
            <%
            set cmd=server.CreateObject("ADODB.Command")
            Set cmd.activeconnection=conn
            cmd.CommandType=adCmdText
            cmd.CommandText="SELECT " & COLUMN_CHARACTER_ID & ", " & COLUMN_CHARACTER_NAME & " FROM " & TABLE_CHARACTERS & " ORDER BY " & COLUMN_CHARACTER_NAME & ";"
            set rs = cmd.Execute()
            rs.movefirst
            do until rs.eof
            %>
                <option value="<%=rs(COLUMN_CHARACTER_ID)%>"><%=rs(COLUMN_CHARACTER_NAME)%>(#<%=rs(COLUMN_CHARACTER_ID)%>)</option>
            <%
                rs.movenext
            loop
            set rs = nothing
            set cmd=nothing
            %>
                </select>
            </p>
            <p><input type="radio" name="CardState" value="<%=COLUMN_IN_DRAW_PILE%>"/>In Draw Pile</p>
            <p>Draw Order: <input type="text" name="<%=COLUMN_DRAW_ORDER%>" value="0"/></p>
            <p><input type="radio" name="CardState" value="<%=COLUMN_IN_HAND%>"/>In Hand</p>
            <p><input type="radio" name="CardState" value="<%=COLUMN_IN_DISCARD_PILE%>" checked="checked"/> In Discard Pile</p>
            <p><input type="submit"/></p>
        </form>
    </body>
</html>
<!--#include virtual="inc/closeconn.inc"-->