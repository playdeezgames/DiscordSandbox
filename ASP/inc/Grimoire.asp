<%
Const COLUMN_CARD_COUNT = "CardCount"
Const COLUMN_CARD_ID = "CardId"
Const COLUMN_CARD_TYPE_ID = "CardTypeId"
Const COLUMN_CARD_TYPE_NAME = "CardTypeName"
Const COLUMN_CHARACTER_ID = "CharacterId"
Const COLUMN_CHARACTER_NAME = "CharacterName"
Const COLUMN_CHARACTER_TYPE_ID = "CharacterTypeId"
Const COLUMN_CHARACTER_TYPE_NAME = "CharacterTypeName"
Const COLUMN_DELETE_ON_PLAY ="DeleteOnPlay"
Const COLUMN_DRAW_ORDER = "DrawOrder"
Const COLUMN_IN_DISCARD_PILE = "InDiscardPile"
Const COLUMN_IN_DRAW_PILE = "InDrawPile"
Const COLUMN_IN_HAND = "InHand"
Const COLUMN_LOCATION_ID = "LocationId"
Const COLUMN_LOCATION_NAME = "LocationName"

Const TABLE_CARD_TYPES = "CardTypes"
Const TABLE_CARDS = "Cards"
Const TABLE_CHARACTERS = "Characters"
Const TABLE_CHARACTER_TYPES = "CharacterTypes"
Const TABLE_LOCATIONS = "Locations"

Const VIEW_CARD_DETAILS = "CardDetails"
Const VIEW_CARD_TYPE_DETAILS = "CardTypeDetails"
Const VIEW_CHARACTER_DETAILS = "CharacterDetails"

Function MakeSelectCommandText(TableName, ShowColumns, FilterColumns)
    Dim result
    result = "SELECT " & Join(ShowColumns,", ") & " FROM " & TableName
    if not isnull(FilterColumns) then
        result = result & " WHERE " & Join(FilterColumns," = ? AND ") & " = ?"
    end if
    MakeSelectCommandText=result
End Function

Function MakeSelectCommand(Conn, TableName, ShowColumns, FilterColumns, FilterValues)
    Set MakeSelectCommand = Server.CreateObject("ADODB.Command")
    Set MakeSelectCommand.activeconnection=Conn
    MakeSelectCommand.CommandType=adCmdText
    MakeSelectCommand.CommandText=MakeSelectCommandText(TableName,ShowColumns,FilterColumns)
    if not isnull(FilterValues) then
        MakeSelectCommand.Parameters.Refresh
        Dim index
        for index=0 to ubound(FilterValues)
            MakeSelectCommand.Parameters(index)=FilterValues(index)
        next
    end if
End Function

Function MakeEditComboBox(Conn, TableName, KeyColumnName, DisplayColumnName, KeyValue)
    Dim result
    result="<select name=""" & KeyColumnName &  """>"
    Dim cmd
    Set cmd = MakeSelectCommand(conn, TableName,Array(KeyColumnName,DisplayColumnName),Null,Null)
    Dim rs
    set rs = cmd.Execute
    do until rs.eof
        result = result & "<option value="""
        result = result & rs(KeyColumnName) 
        result = result & """"
        if rs(KeyColumnName)=KeyValue then
            result = result & " selected=""selected"""
        end if
        result = result & ">"
        result = result & rs(DisplayColumnName)
        result = result & "</option>"
        rs.movenext
    loop
    rs.close
    set rs=nothing
    Set cmd = nothing
    result=result & "</select>"
    MakeEditComboBox=result
End Function
%>