
<!--#include virtual="inc/Grimoire.asp"-->
<html>
    <head>
        <title>SPLORR!!</title>
    </head>
    <body>
        <p><a href="/CardType/CardTypeList.asp">Back to Card Type List</a></p>
        <form action="/CardType/InsertCardType.asp" method="POST">
            <p>Card Type Name: <input name="<%=COLUMN_CARD_TYPE_NAME%>" type="text" size="100" maxlength="100" /></p>
            <p>Delete On Play: <input name="<%=COLUMN_DELETE_ON_PLAY%>" type="checkbox" value="1" /></p>
            <input type="submit"/>
        </form>
    </body>
</html>
