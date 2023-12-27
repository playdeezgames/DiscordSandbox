Imports Shouldly
Imports Xunit

Public Class Bot_should
    <Fact>
    Sub have_a_blank_initial_state()
        Dim worldModel As FakeWorldModel = New FakeWorldModel
        Dim subject As IBot = New SPLORRBot(worldModel)
        worldModel.InitializeCalled.ShouldBeFalse
        worldModel.CleanUpCalled.ShouldBeFalse
    End Sub
    <Fact>
    Sub start()
        Dim worldModel As FakeWorldModel = New FakeWorldModel
        Dim subject As IBot = New SPLORRBot(worldModel)
        subject.Start()
        worldModel.InitializeCalled.ShouldBeTrue
        worldModel.CleanUpCalled.ShouldBeFalse
    End Sub
    <Fact>
    Sub [stop]()
        Dim worldModel As FakeWorldModel = New FakeWorldModel
        Dim subject As IBot = New SPLORRBot(worldModel)
        subject.Stop()
        worldModel.InitializeCalled.ShouldBeFalse
        worldModel.CleanUpCalled.ShouldBeTrue
    End Sub
    Const NO_CHARACTER_RESULT = "You have no character!"
    Const INVALID_INPUT_RESULT = "Invalid input!"
    <Theory>
    <InlineData(0, "", INVALID_INPUT_RESULT)>
    Sub handle_empty_message_with_invalid_input(authorId As ULong, message As String, expectedMessage As String)
        Dim worldModel As FakeWorldModel = New FakeWorldModel()
        Dim subject As IBot = New SPLORRBot(worldModel)

        Dim actual = subject.HandleMessage(authorId, message)
        actual.ShouldBe(expectedMessage)

        worldModel.FakePlayers.ShouldHaveSingleItem
    End Sub
    <Theory>
    <InlineData(0, "status", NO_CHARACTER_RESULT)>
    <InlineData(0, "Status", NO_CHARACTER_RESULT)>
    <InlineData(0, "statuS", NO_CHARACTER_RESULT)>
    <InlineData(0, "STATUS", NO_CHARACTER_RESULT)>
    Sub handle_status_message_regardless_of_casing_when_player_has_no_character(authorId As ULong, message As String, expectedMessage As String)
        Dim worldModel As FakeWorldModel = New FakeWorldModel()
        Dim subject As IBot = New SPLORRBot(worldModel)

        Dim actual = subject.HandleMessage(authorId, message)
        actual.ShouldBe(expectedMessage)

        worldModel.FakePlayers.ShouldHaveSingleItem
    End Sub
    <Theory>
    <InlineData(0, "status asdflkasdkfjal", INVALID_INPUT_RESULT)>
    Sub handle_status_message_with_additional_tokens_with_invalid_input(authorId As ULong, message As String, expectedMessage As String)
        Dim worldModel As FakeWorldModel = New FakeWorldModel()
        Dim subject As IBot = New SPLORRBot(worldModel)

        Dim actual = subject.HandleMessage(authorId, message)
        actual.ShouldBe(expectedMessage)

        worldModel.FakePlayers.ShouldHaveSingleItem
    End Sub
    <Fact>
    Sub handle_rolling_up_character_when_player_has_no_character()
        Const authorId As ULong = 0
        Const message = "create character"
        Const expectedMessage = "success"

        Dim worldModel As FakeWorldModel = New FakeWorldModel()
        Dim subject As IBot = New SPLORRBot(worldModel)

        Dim actual = subject.HandleMessage(authorId, message)
        actual.ShouldContain(expectedMessage)

        worldModel.FakePlayers.ShouldHaveSingleItem
        Dim playerModel = worldModel.FakePlayers.Single.Value

        playerModel.FakeCharacter.ShouldNotBeNull
    End Sub
    <Fact>
    Sub handle_rolling_up_character_when_player_has_character_already()
        Const authorId As ULong = 0
        Const message = "create character"
        Const expectedMessage = "failure"
        Dim characterModel As New FakeCharacterModel

        Dim worldModel As New FakeWorldModel(
                getPlayerHook:=Function(id) New FakePlayerModel(characterModel:=characterModel))
        Dim subject As IBot = New SPLORRBot(worldModel)

        Dim actual = subject.HandleMessage(authorId, message)
        actual.ShouldContain(expectedMessage)

        worldModel.FakePlayers.ShouldHaveSingleItem
        Dim playerModel = worldModel.FakePlayers.Single.Value

        playerModel.FakeCharacter.ShouldBe(characterModel)
    End Sub
End Class