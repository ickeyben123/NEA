﻿' The Account Class contains the methods for authentication. 
' Events 'Login' and 'Logout' are to be connected to the respective buttons.

' Items are named first as their page, in form page_x.

' GLOBAL ENUMS

' Login enum for the login_mode of the account. 
' It is also used to state what mode the account is in (once logged in).
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Serialization
Public Enum LOGIN_MODE
    TEACHER
    STUDENT
End Enum



' This enum contains all the available questions

' The class for the form.
Public Class FORM1

    ' Main Sub
    Private Sub Main(sender As Object, e As EventArgs) Handles Me.Shown

        SHOW_MODE_SCREEN()


    End Sub

    ' EVENTS

    Dim WithEvents ACCOUNT_OBJECT As New ACCOUNT
    Dim WithEvents NOTIFICATIONS_OBJECT As New NOTIFICATIONS(Me)
    Dim DATA_HANDLER
    Dim TESTS As New List(Of DATA_HANDLE)
    Dim QUESTION_POINTER As Integer = 0

    '/////////////////////////////
    ' General Form Subroutines
    '/////////////////////////////

    Public Function CLEAR_ALL()
        For Each cControl As Control In Controls  'Loops through all 'controls' in the form
            If TypeOf cControl Is GroupBox Then
                cControl.Visible = False
            End If
        Next
        Return True
    End Function

    Private Sub SHOW_LOGIN_SCREEN() Handles ACCOUNT_OBJECT.LOGIN_SCREEN
        CLEAR_ALL()
        LOGIN_GROUP.Visible = True
    End Sub

    Private Sub SHOW_MODE_SCREEN() Handles ACCOUNT_OBJECT.MODE_SCREEN
        CLEAR_ALL()
        MODE_GROUP.Visible = True
    End Sub

    Private Function TOGGLE_CERTAIN_SCREEN(SCREEN, SETTING)
        CLEAR_ALL()
        SCREEN.Visible = SETTING
        Return True
    End Function


    ' Account Login Subroutines

    Public Function UPPER_CASE(ByVal Match As Match) As String
        ' Used for .Replace regex to set a match upper case
        Return Match.ToString.ToUpper()
    End Function

    Public Sub ATTEMPT_LOGIN() Handles LOGIN_BUTTON.MouseClick ' This fires when the user clicks the login buttonm
        Dim result As Boolean = ACCOUNT_OBJECT.LOGIN(LOGIN_INPUT.Text) ' Calls login method in the account object.
        If result Then 'if it was correct
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Correct Login Info! Transferring to " & ACCOUNT_OBJECT.ACCOUNT_TYPE.ToString & " Screen", Color.Green)

            If ACCOUNT_OBJECT.ACCOUNT_TYPE = LOGIN_MODE.STUDENT Then
                TOGGLE_CERTAIN_SCREEN(TEST_AREA, True) ' Shows the default area for doing the tests given by teachers.

                ' Setup common events for the student.
                AddHandler TEST_VIEWER_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEST_AREA, True)
                AddHandler TESTS_AREA_VIEW_TEST.Click, Function(sender, e) VIEW_TEST()
                AddHandler TESTS_AREA_REMOVE_TEST.Click, Function(sender, e) TEST_DELETE()
                AddHandler TEST_VIEWER_ANSWER_SELECTED_QUESTION.Click, Function(sender, e) DISPLAY_ANSWER_QUESTION()
                AddHandler QUESTION_ANSWERER_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEST_VIEWER, True)
                AddHandler QUESTION_ANSWERER_EXIT.Click, Function(sender, e) ANSWER_QUESTION() ' This is easier trust me :L
                AddHandler QUESTION_ANSWERER_EXIT.Click, Function(sender, e) TEST_QUESTION_LIST_MOUSE_UP()
                AddHandler EXPORT_ANSWERS_EXPORT.Click, Function(sender, e) EXPORT(sender, e, TESTS(TEST_AREA_LIST.SelectedIndex), "Answers.json", EXPORT_ANSWERS_NAME.Text) ' The export function that I modified to accomodate for custom data_handle object inputs.
                AddHandler EXIT_EXPORT_ANSWERS.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEST_AREA, True)
            Else
                TOGGLE_CERTAIN_SCREEN(TEACHER_GROUP, True)
                AddHandler TEACHER_CREATE_QUESTIONS.Click, Function(sender, e) SETUP_QUESTION_CREATOR()
                DATA_HANDLER = New DATA_HANDLE_TEACHER()

                ' Update the question chooser with the current available enums.
                Dim ENUMS As New List(Of QUESTION_TYPE)(System.Enum.GetValues(GetType(QUESTION_TYPE)))
                ' Setup common events for the teacher.
                AddHandler Q_CONTROL_GROUP_ADD_QUESTION.Click, Function(sender, e) SETUP_QUESTION_CHOOSER()
                AddHandler QUESTION_CHOOSER_BACK.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)
                AddHandler QUESTION_CHOOSER_CREATE.Click, Function(sender, e) CREATE_QUESTION()
                AddHandler QUESTION_CREATION_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(QUESTION_CHOOSER, True)
                AddHandler QUESTION_CREATE.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)
                AddHandler Q_CONTROL_GROUP_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEACHER_GROUP, True)
                AddHandler Q_CONTROL_GROUP_EXIT.Click, Function(sender, e) CLEAR_ALL_DATA()
                AddHandler Q_CONTROL_GROUP_EDIT.Click, Function(SENDER, E) EDIT()
                AddHandler Q_CONTROL_GROUP_REMOVE.Click, Function(sender, e) DELETE(Q_CONTROL_GROUP_LISTBOX.SelectedIndex)
                AddHandler Q_CONTROL_GROUP_CLEAR_ALL.Click, Function(sender, e) DATA_HANDLER.CLEAR_ALL()
                AddHandler Q_CONTROL_GROUP_EXPORT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEST_EXPORT, True)
                AddHandler TEST_EXPORT_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)

                ' Answer Submissions section
                AddHandler SUBMISSIONS_REMOVE.Click, Function(sender, e) TEST_DELETE(SUBMISSIONS_LIST.SelectedIndex) ' As there are a number of simularities between this and the student area I will recycle some functions.
                AddHandler MARK_QUESTION_CORRECT.Click, Function(sender, e) OVERRIDE_SUBMISSION_QUESTION(sender, e, QUESTION_STATUS.CORRECT)
                AddHandler MARK_QUESTION_INCORRECT.Click, Function(sender, e) OVERRIDE_SUBMISSION_QUESTION(sender, e, QUESTION_STATUS.WRONG)
                AddHandler MARK_QUESTION_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(VIEW_SUBMISSION, True)
                AddHandler MARK_QUESTION_EXIT.Click, Function(sender, e) UPDATE_LIST_OF_QUESTIONS_ON_SELECTED_SUBMISSION()
                AddHandler VIEW_SUBMISSION_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(SUBMISSIONS, True)
                AddHandler SUBMISSIONS_EXIT.Click, Function(sender, e) TOGGLE_CERTAIN_SCREEN(TEACHER_GROUP, True)
                AddHandler SUBMISSIONS_EXIT.Click, Function(sender, e) CLEAR_ALL_DATA()
                AddHandler SUBMISSIONS_EXPORT.Click, Function(sender, e) EXPORT(sender, e, TESTS(SUBMISSIONS_LIST.SelectedIndex), "Marked Answers.json", TESTS(SUBMISSIONS_LIST.SelectedIndex).STUDENT_NAME)

                ' Update the question chooser listview.
                For Each ENUM_ITEM As QUESTION_TYPE In ENUMS
                    Dim MODIFIABLE As String = ENUM_ITEM.ToString.ToLower()
                    Dim SPACE As New Regex("_")
                    Dim CAPITALISE As New Regex("[ ]\w|(^\w)") ' Gets every first letter.
                    MODIFIABLE = SPACE.Replace(MODIFIABLE, " ")
                    MODIFIABLE = CAPITALISE.Replace(MODIFIABLE, New MatchEvaluator(AddressOf UPPER_CASE))
                    QUESTION_CHOOSER_LIST.Items.Add(MODIFIABLE)
                Next

            End If

        Else
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Wrong Login Info!", Color.Red)
        End If
    End Sub

    Public Sub MODE_CLICK(sender As Object, e As EventArgs) Handles MODE_STUDENT.MouseClick, MODE_TEACHER.MouseClick
        If sender Is MODE_STUDENT Then ' This means they chose to be a student
            ACCOUNT_OBJECT.SELECT_MODE(LOGIN_MODE.STUDENT)
        Else ' They chose teacher
            ACCOUNT_OBJECT.SELECT_MODE(LOGIN_MODE.TEACHER)
        End If
    End Sub


    '/////////////////////////////
    ' END
    '////////////////////////////

    Private Function CLEAR_ALL_DATA()
        TESTS = New List(Of DATA_HANDLE)
        DATA_HANDLER.CLEAR_ALL()
        Return True
    End Function

    '//////////////////////////////
    ' Student UI Subroutines.
    '/////////////////////////////

    Dim SELECTED_TEST As Integer = 0
    Private Sub EXPORT_ANSWERS(sender As Object, e As EventArgs) Handles TESTS_AREA_EXPORT_TEST.Click
        ' I will be using much of the same method for exporting the answers of the student.
        If TEST_AREA_LIST.SelectedItems.Count = 1 Then '  
            TOGGLE_CERTAIN_SCREEN(EXPORT_ANSWERS_GROUP, True)
        End If
    End Sub

    Private Sub CLEAR_ALL(sender As Object, e As EventArgs) Handles TESTS_AREA_CLEAR_ALL.Click
        TESTS.RemoveRange(0, TESTS.Count)
        TEST_LIST_UPDATE()
    End Sub

    Private Sub TEST_LIST_UPDATE() ' Updates the test list.
        TEST_AREA_LIST.Items.Clear()
        For Each TEST As DATA_HANDLE In TESTS
            TEST_AREA_LIST.Items.Add(TEST.NAME)
        Next
    End Sub
    Private Function VIEW_TEST()
        If TEST_AREA_LIST.SelectedItems.Count = 1 Then '  
            Dim INDEX_OF_ITEM = TEST_AREA_LIST.SelectedIndex
            SELECTED_TEST = INDEX_OF_ITEM
            TESTS(INDEX_OF_ITEM).UPDATE_TEST_LIST() ' This updates the list of questions in the selected test.
            TOGGLE_CERTAIN_SCREEN(TEST_VIEWER, True)
            If TESTS(INDEX_OF_ITEM).MARKED Then ' If the test is marked then they cannot answer it anymore.
                TEST_VIEWER_ANSWER_SELECTED_QUESTION.Visible = False
            Else
                TEST_VIEWER_ANSWER_SELECTED_QUESTION.Visible = True
            End If
            Return True
        End If
        Return False
    End Function

    Private Function ADD_TEST(ByVal SENDER As Object, ByVal E As EventArgs, Optional REVOKE_EXTRAS As Boolean = False) Handles TESTS_AREA_ADD_NEW_TEST.Click
        '   Dim TO_BE_CONVERTED As String = TEST_INPUT_DATA_TEXT.Text
        '  Debug.WriteLine(TEST_INPUT_DATA_TEXT.Text)

        Dim DIALOG As New OpenFileDialog()
        DIALOG.Filter = "Json Files|*.json"
        If DialogResult.OK = DIALOG.ShowDialog Then
            Dim JSON_STRING As String = File.ReadAllText(DIALOG.FileName)
            Dim QUESTION_LIST As List(Of Dictionary(Of String, String)) = JsonSerializer.Deserialize(Of List(Of Dictionary(Of String, String)))(JSON_STRING)  ' Decserialiszes the data yeahhhh!!!
            Dim NEW_TEST
            If Not REVOKE_EXTRAS Then
                NEW_TEST = New DATA_HANDLE(True)
            Else
                NEW_TEST = New DATA_HANDLE_TEACHER()
            End If

            NEW_TEST.NAME = QUESTION_LIST(0).Item("NAME") ' Adds the metadata for the test.
            NEW_TEST.DESCRIPTION = QUESTION_LIST(0).Item("DESCRIPTION")

            If QUESTION_LIST(0).Item("MARKED") = "False" Then ' This deems whether it has been marked by a teacher.
                NEW_TEST.MARKED = False
            ElseIf QUESTION_LIST(0).Item("MARKED") = "True" Then
                NEW_TEST.MARKED = True
            End If
            If QUESTION_LIST(0).ContainsKey("STUDENT NAME") Then
                NEW_TEST.STUDENT_NAME = QUESTION_LIST(0).Item("STUDENT NAME")
            End If
            QUESTION_LIST.RemoveAt(0) ' Removes the metadata

            For Each QUESTION As Dictionary(Of String, String) In QUESTION_LIST
                Dim NEW_QUESTION As New QUESTION()
                NEW_QUESTION.SET_QUESTION(QUESTION.Item("QUESTION"))
                NEW_QUESTION.QUESTION_TITLE = QUESTION.Item("QUESTION TITLE")
                If QUESTION.Item("QUESTION TYPE") = "DIFFERENTIATION" Then
                    NEW_QUESTION.QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.DIFFERENTIATION
                Else
                    NEW_QUESTION.QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.SIMPLIFICATION
                End If
                If Not QUESTION.ContainsKey("TEACHER EDITED") Then
                    NEW_QUESTION.TEACHER_EDITED = False
                ElseIf QUESTION.Item("TEACHER EDITED") = "False" Then ' For the submission data.
                    NEW_QUESTION.TEACHER_EDITED = False
                ElseIf QUESTION.Item("TEACHER EDITED") = "True" Then
                    NEW_QUESTION.TEACHER_EDITED = True
                End If

                If QUESTION.ContainsKey("STATUS") Then ' Status enum serialisation, which probably can be done better but it works hahahahahahahahahaaaaaaa
                    Select Case QUESTION.Item("STATUS")
                        Case "CORRECT"
                            NEW_QUESTION.STATUS = QUESTION_STATUS.CORRECT
                        Case "INDETERMINED"
                            NEW_QUESTION.STATUS = QUESTION_STATUS.INDETERMINED
                        Case "WRONG"
                            NEW_QUESTION.STATUS = QUESTION_STATUS.WRONG
                    End Select
                End If

                NEW_QUESTION.TYPE = QUESTION.Item("TYPE")
                If QUESTION.ContainsKey("ANSWER") Then ' If the user is adding their answer document back in, then they go back to where they were.
                    NEW_QUESTION.SUBMIT_ANSWER(QUESTION.Item("ANSWER"))
                End If
                NEW_TEST.ADD(NEW_QUESTION)
            Next
            TESTS.Add(NEW_TEST)
                If Not REVOKE_EXTRAS Then
                    TEST_LIST_UPDATE()
                    TOGGLE_CERTAIN_SCREEN(TEST_AREA, True)
                    NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Test " & NEW_TEST.NAME & " has been successfully added.", Color.Orange)
                End If
            End If
            Return True
    End Function

    Private Function MOVE_LEFT_QUESTION() Handles QUESTION_ANSWERER_LEFT.Click ' This is for moving left in the test.
        ANSWER_QUESTION() 'Auto updates the current question.
        If QUESTION_POINTER > 0 Then
            QUESTION_POINTER -= 1
            DISPLAY_ANSWER_QUESTION() ' Displays the new question, even if it does some redundant things ;0.
        End If
    End Function

    Private Function MOVE_RIGHT_QUESTION() Handles QUESTION_ANSWERER_RIGHT.Click ' This is for moving left in the test.
        ANSWER_QUESTION() 'Auto updates the current question.
        If QUESTION_POINTER < TESTS(SELECTED_TEST).RETURN_QUESTIONS.Count() - 1 Then
            QUESTION_POINTER += 1
            DISPLAY_ANSWER_QUESTION() ' Displays the new question, even if it does some redundant things ;0.
        End If
    End Function

    Private Function DISPLAY_ANSWER_QUESTION() ' Displays the question
        Dim SELECTED_QUESTION = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(QUESTION_POINTER)
        QUESTION_ANSWERER_QUESTION.Text = SELECTED_QUESTION.RETURN_QUESTION
        QUESTION_ANSWERER_TITLE.Text = SELECTED_QUESTION.QUESTION_TITLE
        QUESTION_ANSWERER_ANSWER.Text = SELECTED_QUESTION.RETURN_ANSWER
        QUESTION_ANSWERER_NUMBER.Text = QUESTION_POINTER + 1
        TOGGLE_CERTAIN_SCREEN(QUESTION_ANSWERER, True)
        Return True
    End Function

    Private Function ANSWER_QUESTION() ' Answers the question via the user.
        Dim SELECTED_QUESTION = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(QUESTION_POINTER)
        SELECTED_QUESTION.SUBMIT_ANSWER(QUESTION_ANSWERER_ANSWER.Text)
        'TEST_QUESTION_LIST_MOUSE_UP()
        Return True
    End Function
    Private Function TEST_DELETE(Optional INDEX As Integer = -1)
        If INDEX = -1 Then
            INDEX = TEST_AREA_LIST.SelectedIndex
        End If
        If TESTS.Count >= INDEX And INDEX <> -1 Then
            Dim SELECTED As Integer = INDEX
            TESTS.RemoveAt(INDEX)
            TEST_LIST_UPDATE()
            SUBMISSIONS_LIST_UPDATE()
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Test " & SELECTED + 1 & " Deleted.", Color.Red)
            Return True
        End If
        Return False
    End Function

    Private Function TEST_QUESTION_LIST_MOUSE_UP(Optional ByVal SENDER As Object = Nothing, Optional ByVal E As System.Windows.Forms.MouseEventArgs = Nothing) Handles TEST_VIEWER_QUESTION_LIST.MouseUp
        ' This shows the options when you right click on the question viewer for the teacher.
        Dim SELECTED_TEST = TEST_AREA_LIST.SelectedIndex
        Dim SELECTED_TEST_QUESTION = TEST_VIEWER_QUESTION_LIST.SelectedIndex  ' The question within the test.
        If TEST_VIEWER_QUESTION_LIST.SelectedItems.Count = 1 Then
            QUESTION_POINTER = SELECTED_TEST_QUESTION ' This is for use when the user is moving through the questions in the question answer page.
            TEST_VIEWER_PREVIEW_QUESTION.Text = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(SELECTED_TEST_QUESTION).RETURN_QUESTION ' Sets the preview of the question and answer.
            TEST_VIEWER_PREVIEW_ANSWER.Text = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(SELECTED_TEST_QUESTION).RETURN_ANSWER
        End If
        Return True
    End Function
    Private Sub STUDENT_LISTBOX_MOUSE_UP(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles TEST_AREA_LIST.MouseUp
        ' This shows the options when you right click on the question viewer for the teacher.
        Dim CMS = New ContextMenuStrip
        Dim SELECTED_ITEM = TEST_AREA_LIST.SelectedItem
        If E.Button = MouseButtons.Right Then
            If TEST_AREA_LIST.SelectedItems.Count = 1 Then
                Dim ITEM1 = CMS.Items.Add("View " & SELECTED_ITEM.ToString)
                ITEM1.Tag = 1
                AddHandler ITEM1.Click, AddressOf VIEW_TEST
                Dim ITEM2 = CMS.Items.Add("Delete " & SELECTED_ITEM.ToString)
                ITEM2.Tag = 2
                AddHandler ITEM2.Click, Function(s, ev) TEST_DELETE()
            End If
            Dim ITEM3 = CMS.Items.Add("Add new test")
            ITEM3.Tag = 3
            'AddHandler ITEM3.Click, ADD_TEST()
            CMS.Show(TEST_AREA_LIST, E.Location)
        ElseIf TEST_AREA_LIST.SelectedItems.Count = 1 Then
            Dim INDEX_OF_ITEM = TEST_AREA_LIST.SelectedIndex
            TESTS_AREA_TEST_TITLE.Text = "TEST " & (INDEX_OF_ITEM + 1)
            TESTS_AREA_TEST_DESCRIPTION.Text = TESTS(INDEX_OF_ITEM).DESCRIPTION
        End If
    End Sub


    '/////////////////////////////
    ' END
    '////////////////////////////


    '//////////////////////////////
    ' Teacher UI Subroutines.
    '/////////////////////////////

    Private Function ADD_SUBMISSION(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles SUBMISSIONS_ADD.Click
        ADD_TEST(SENDER, E, True) ' Adds a selected test through deserialisation.
        SUBMISSIONS_LIST_UPDATE()
        If TESTS.Count > 0 Then
            Dim ADDED_TEST As DATA_HANDLE = TESTS(TESTS.Count - 1)
            ADDED_TEST.MARKED = True ' This will allow the student to view the data and see the marks they got.
            For Each SELECTED_QUESTION In ADDED_TEST.RETURN_QUESTIONS
                If Not SELECTED_QUESTION.TEACHER_EDITED Then ' This means that the teacher hasn't overridden the marking.
                    Dim BASELINE As Double = SELECTED_QUESTION.RETURN_ANSWER_FUNCTION_OUTPUT(3)
                    Dim NEW_QUESTION As New SIMPLE_SIMPLIFY(SELECTED_QUESTION.RETURN_ANSWER)
                    Dim TO_COMPARE As Double = NEW_QUESTION.GET_OUTPUT(3)
                    Debug.WriteLine("COMPARING " & TO_COMPARE & BASELINE)
                    If BASELINE = TO_COMPARE And SELECTED_QUESTION.QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.DIFFERENTIATION Then
                        ' I am only checking that the functions output the same values.
                        ' For differentiation where form doesn't matter, this is good enough.
                        SELECTED_QUESTION.STATUS = QUESTION_STATUS.CORRECT
                    ElseIf BASELINE <> TO_COMPARE Then
                        ' This will always mean that it is wrong.
                        SELECTED_QUESTION.STATUS = QUESTION_STATUS.WRONG
                    ElseIf BASELINE = TO_COMPARE And SELECTED_QUESTION.QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.SIMPLIFICATION Then
                        ' As 3x+2x = 5x, and substituting 3 for each will yield the same result, I cannot say it is correct, as the user can change nothing and it will still say baseline = to_compare.
                        SELECTED_QUESTION.STATUS = QUESTION_STATUS.INDETERMINED
                        ' This must be checked by the teacher
                    End If
                End If
            Next

            Return True
        End If
        Return False
    End Function

    Private Function UPDATE_LIST_OF_QUESTIONS_ON_SELECTED_SUBMISSION()
        ' This updates the list of questions in the selected submission that the teacher chose to view.
        Dim SELECTED_TEST As Integer = SUBMISSIONS_LIST.SelectedIndex
        VIEW_SUBMISSION_COLLECTION.Items.Clear()
        For Each QUESTION_O As QUESTION In TESTS.Item(SELECTED_TEST).RETURN_QUESTIONS
            Dim TO_BE_STRING As String = QUESTION_O.TYPE & " "
            Select Case QUESTION_O.STATUS
                Case QUESTION_STATUS.CORRECT
                    TO_BE_STRING = TO_BE_STRING & "✓"
                Case QUESTION_STATUS.WRONG
                    TO_BE_STRING = TO_BE_STRING & "X"
                Case QUESTION_STATUS.INDETERMINED
                    TO_BE_STRING = TO_BE_STRING & "?"
            End Select
            VIEW_SUBMISSION_COLLECTION.Items.Add(TO_BE_STRING)
        Next
    End Function

    Private Function OVERRIDE_SUBMISSION_QUESTION(SENDER As Object, E As EventArgs, TYPE As QUESTION_STATUS)
        Dim SELECTED_QUESTION As QUESTION = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(VIEW_SUBMISSION_COLLECTION.SelectedIndex)
        SELECTED_QUESTION.STATUS = TYPE
        SELECTED_QUESTION.TEACHER_EDITED = True
        OVERRIDE_SUBMISSION_QUESTION_PREP(SENDER, E) ' This will redisplay the page with the correct data.
    End Function
    Public Function OVERRIDE_SUBMISSION_QUESTION_PREP(ByVal SENDER As Object, ByVal E As EventArgs) Handles VIEW_SUBMISSION_OVERRIDE.Click
        ' This is for overriding the submission's teacher selected question.

        If VIEW_SUBMISSION_COLLECTION.SelectedItems.Count > 0 Then
            Dim SELECTED_QUESTION As QUESTION = TESTS(SELECTED_TEST).RETURN_QUESTIONS()(VIEW_SUBMISSION_COLLECTION.SelectedIndex) ' This is the question chosen to override marking.
            MARK_QUESTION_QUESTION.Text = SELECTED_QUESTION.RETURN_QUESTION ' The Question
            MARK_QUESTION_COMPUTED_ANSWER.Text = SELECTED_QUESTION.RETURN_COMPUTED_ANSWER ' the computed answer.
            MARK_QUESTION_STUDENTS_ANSWER.Text = SELECTED_QUESTION.RETURN_ANSWER ' The students answer.
            MARK_QUESTION_TITLE.Text = SELECTED_QUESTION.QUESTION_TITLE
            MARK_QUESTION_NUMBER.Text = VIEW_SUBMISSION_COLLECTION.SelectedIndex + 1
            Select Case SELECTED_QUESTION.STATUS
                Case QUESTION_STATUS.CORRECT
                    MARK_QUESTION_COMPUTED_ANSWER.BackColor = Color.FromArgb(192, 255, 192)
                    MARK_QUESTION_DEEMED_VALIDITY.Text = "Marked Correct"
                    If Not SELECTED_QUESTION.TEACHER_EDITED Then
                        MARK_QUESTION_DEEMED_REASON.Text = "Automated check has found that the student's answer procures the same value as the computed answer."
                    Else
                        MARK_QUESTION_DEEMED_REASON.Text = "The teacher has overriden the automated decision."
                    End If
                Case QUESTION_STATUS.WRONG
                    MARK_QUESTION_COMPUTED_ANSWER.BackColor = Color.FromArgb(255, 128, 128)
                    MARK_QUESTION_DEEMED_VALIDITY.Text = "Marked Wrong"
                    Debug.WriteLine("qwrr" & SELECTED_QUESTION.TEACHER_EDITED.ToString)
                    If Not SELECTED_QUESTION.TEACHER_EDITED Then
                        MARK_QUESTION_DEEMED_REASON.Text = "Automated check deemed that the calculated answer does not procure the same value as the students."
                    Else
                        MARK_QUESTION_DEEMED_REASON.Text = "The teacher has overriden the automated decision."
                    End If
                Case QUESTION_STATUS.INDETERMINED
                    MARK_QUESTION_DEEMED_VALIDITY.Text = "Marked Indetermined"
                    MARK_QUESTION_COMPUTED_ANSWER.BackColor = Color.FromArgb(255, 192, 128)
                    MARK_QUESTION_DEEMED_REASON.Text = "Automated check deemed that it requires further teacher input on the validity of the student's answer."
            End Select
            TOGGLE_CERTAIN_SCREEN(MARK_QUESTION, True)
        End If
    End Function

    Public Function VIEW_SUBMISSION_EVENT(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles SUBMISSIONS_VIEW.Click
        ' This occurs when the teachers clicks the button to view the actual submitted test
        If SUBMISSIONS_LIST.SelectedItems.Count > 0 Then
            UPDATE_LIST_OF_QUESTIONS_ON_SELECTED_SUBMISSION()
            TOGGLE_CERTAIN_SCREEN(VIEW_SUBMISSION, True)
        End If
    End Function

    Private Sub VIEW_SUBMISSIONS_LIST_MOUSE_UP(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles VIEW_SUBMISSION_COLLECTION.MouseUp
        ' This shows the options when you right click on the question on the submission test section for the teacher.
        Dim CMS = New ContextMenuStrip
        Dim SELECTED_ITEM = VIEW_SUBMISSION_COLLECTION.SelectedItem
        If E.Button = MouseButtons.Right Then
            If VIEW_SUBMISSION_COLLECTION.SelectedItems.Count = 1 Then
                Dim ITEM1 = CMS.Items.Add("Override " & SELECTED_ITEM.ToString)
                ITEM1.Tag = 1
                AddHandler ITEM1.Click, Function(s, ev) VIEW_SUBMISSION_EVENT(s, ev)
            End If
            CMS.Show(VIEW_SUBMISSION_COLLECTION, E.Location)
        ElseIf VIEW_SUBMISSION_COLLECTION.SelectedItems.Count = 1 Then ' If they havent selected any question.
            Dim INDEX_OF_ITEM = VIEW_SUBMISSION_COLLECTION.SelectedIndex
            VIEW_SUBMISSION_QUESTION.Text = TESTS(SUBMISSIONS_LIST.SelectedIndex).RETURN_QUESTIONS()(INDEX_OF_ITEM).RETURN_QUESTION
            VIEW_SUBMISSION_ANSWER.Text = TESTS(SUBMISSIONS_LIST.SelectedIndex).RETURN_QUESTIONS()(INDEX_OF_ITEM).RETURN_ANSWER
        End If
    End Sub

    Private Sub SUBMISSIONS_LIST_MOUSE_UP(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles SUBMISSIONS_LIST.MouseUp
        ' This shows the options when you right click on the question viewer for the teacher.
        Dim CMS = New ContextMenuStrip
        Dim SELECTED_ITEM = SUBMISSIONS_LIST.SelectedItem
        If E.Button = MouseButtons.Right Then
            If SUBMISSIONS_LIST.SelectedItems.Count = 1 Then
                Dim ITEM1 = CMS.Items.Add("View " & SELECTED_ITEM.ToString)
                ITEM1.Tag = 1
                AddHandler ITEM1.Click, Function(s, ev) VIEW_SUBMISSION_EVENT(s, ev)
                Dim ITEM2 = CMS.Items.Add("Delete " & SELECTED_ITEM.ToString)
                ITEM2.Tag = 2
                AddHandler ITEM2.Click, Function(s, ev) TEST_DELETE(SUBMISSIONS_LIST.SelectedIndex)
            End If
            Dim ITEM3 = CMS.Items.Add("Add new submission")
            ITEM3.Tag = 3
            AddHandler ITEM3.Click, Function(s, ev) ADD_SUBMISSION(SENDER, E)
            CMS.Show(SUBMISSIONS_LIST, E.Location)
        ElseIf SUBMISSIONS_LIST.SelectedItems.Count = 1 Then ' If they havent selected any question.
            Dim INDEX_OF_ITEM = SUBMISSIONS_LIST.SelectedIndex
            SUBMISSION_TITLE.Text = "ANSWER " & (INDEX_OF_ITEM + 1)
            SUBMISSIONS_DESCRIPTION.Text = TESTS(INDEX_OF_ITEM).DESCRIPTION
        End If
    End Sub

    Private Sub VIEW_SUBMISSION_COLLECTION_HOVER(SENDER As System.Object, E As EventArgs) Handles VIEW_SUBMISSION_COLLECTION.SelectedIndexChanged
        ' This is required so that it looks like something is happening when you hover.

        VIEW_SUBMISSION_COLLECTION.Refresh() ' I have to refresh it every single time and it is appalling who made this system ahhh
        ' E.Item.BackColor = Color.Lime
    End Sub

    Private Sub VIEW_SUBMISSION_COLLECTION_DRAW(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles VIEW_SUBMISSION_COLLECTION.DrawItem
        e.DrawBackground()
        ' This basically colour codes the questions based on their status.
        Dim TEXT_COLOUR = Brushes.White
        If VIEW_SUBMISSION_COLLECTION.SelectedIndex = e.Index Then
            If VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("?") Then
                e.Graphics.FillRectangle(Brushes.Orange, e.Bounds)
            ElseIf VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("✓") Then
                e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds)
            ElseIf VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("X") Then
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds)
            End If
        ElseIf VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("?") Then
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds)
        ElseIf VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("✓") Then
            e.Graphics.FillRectangle(Brushes.DarkGreen, e.Bounds)
        ElseIf VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString().Contains("X") Then
            e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds)
        End If
        e.Graphics.DrawString(VIEW_SUBMISSION_COLLECTION.Items(e.Index).ToString(), e.Font, TEXT_COLOUR, New System.Drawing.PointF(e.Bounds.X, e.Bounds.Y))
        e.DrawFocusRectangle()
    End Sub
    Private Function SELECTED_SUBMISSION_QUESTION_UPDATE() ' Updates the SUBMISSION list.
        SUBMISSIONS_LIST.Items.Clear()
        For Each TEST As DATA_HANDLE In TESTS
            SUBMISSIONS_LIST.Items.Add(TEST.NAME & " | " & TEST.STUDENT_NAME)
        Next
    End Function
    Private Function SUBMISSIONS_LIST_UPDATE() ' Updates the SUBMISSION list.
        SUBMISSIONS_LIST.Items.Clear()
        For Each TEST As DATA_HANDLE In TESTS
            SUBMISSIONS_LIST.Items.Add(TEST.NAME & " | " & TEST.STUDENT_NAME)
        Next
    End Function
    Private Function SETUP_QUESTION_CREATOR()
        TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True) ' Shows the question creator screen.
        Return True
    End Function

    Private Function SETUP_QUESTION_CHOOSER()
        TOGGLE_CERTAIN_SCREEN(QUESTION_CHOOSER, True) ' Shows the question creator chooser screen.
        Return True
    End Function

    Private Function CREATE_QUESTION()
        If QUESTION_CHOOSER_LIST.SelectedItems.Count = 1 Then
            Dim NEW_QUESTION As New TEACHER_QUESTION(DATA_HANDLER)
            NEW_QUESTION.CHOSEN_QUESTION_TO_CREATE()
            TOGGLE_CERTAIN_SCREEN(QUESTION_INPUT1, True)
            QUESTION_CREATION_EXIT.Visible = True
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Question successfully created.", Color.Green)
        End If
        Return True
    End Function

    Private Function ENTER_SUBMISSION_AREA(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles TEACHER_MARK_SUBMISSIONS.MouseUp
        If E.Button = MouseButtons.Left Then
            TESTS = New List(Of DATA_HANDLE)
            TOGGLE_CERTAIN_SCREEN(SUBMISSIONS, True)
        End If
    End Function

    Private Sub LISTBOX_MOUSE_UP(ByVal SENDER As Object, ByVal E As System.Windows.Forms.MouseEventArgs) Handles Q_CONTROL_GROUP_LISTBOX.MouseUp
        ' This shows the options when you right click on the question viewer for the teacher.
        Dim CMS = New ContextMenuStrip
        Dim SELECTED_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedItem
        If E.Button = MouseButtons.Right Then
            If Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then
                Dim ITEM1 = CMS.Items.Add("Edit " & SELECTED_ITEM.ToString)
                ITEM1.Tag = 1
                AddHandler ITEM1.Click, AddressOf EDIT
                Dim ITEM2 = CMS.Items.Add("Delete " & SELECTED_ITEM.ToString)
                ITEM2.Tag = 2
                AddHandler ITEM2.Click, Function(s, ev) DELETE(Q_CONTROL_GROUP_LISTBOX.SelectedIndex)
            End If
            Dim ITEM3 = CMS.Items.Add("Add new question")
            ITEM3.Tag = 3
            AddHandler ITEM3.Click, AddressOf SETUP_QUESTION_CHOOSER
            CMS.Show(Q_CONTROL_GROUP_LISTBOX, E.Location)
        ElseIf Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then ' If they havent selected any question.
            Dim INDEX_OF_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedIndex
            QUESTION_TITLE_NUMBER.Text = "QUESTION " & (INDEX_OF_ITEM + 1)
            QUESTION_TITLE_NAME.Text = DATA_HANDLER.RETURN_QUESTIONS()(INDEX_OF_ITEM).TYPE
        End If
    End Sub

    Private Function EDIT()
        If Q_CONTROL_GROUP_LISTBOX.SelectedItems.Count = 1 Then ' Edit the selected question item.
            Dim INDEX_OF_ITEM = Q_CONTROL_GROUP_LISTBOX.SelectedIndex
            DATA_HANDLER.RETURN_QUESTIONS()(INDEX_OF_ITEM).EDIT_QUESTION(INDEX_OF_ITEM)
            TOGGLE_CERTAIN_SCREEN(QUESTION_INPUT1, True)
            QUESTION_CREATION_EXIT.Visible = False
            Return True
        End If
        Return False
    End Function

    Private Function DELETE(INDEX As Integer)
        If DATA_HANDLER.RETURN_QUESTIONS().Count >= INDEX And INDEX <> -1 Then
            DATA_HANDLER.REMOVE(DATA_HANDLER.RETURN_QUESTIONS().Item(INDEX))
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Question " & INDEX + 1 & " Deleted.", Color.Red)
            Return True
        End If
        Return False
    End Function

    Private Function EXPORT(SENDER As Object, E As EventArgs, Optional TEST As DATA_HANDLE = Nothing, Optional TEST_NAME As String = "Question Export.json", Optional STUDENT_NAME As String = "") Handles TEST_EXPORT_EXPORT.Click

        Dim CHOSEN_TO_EXPORT = DATA_HANDLER
        Dim NAME = TEST_EXPORT_NAME.Text
        Dim DESCRIPTION = TEST_EXPORT_DESC.Text
        If Not TEST Is Nothing Then ' As the function is largely the same for exporting the student answers, I will just modify this to accomodate for it :P.
            CHOSEN_TO_EXPORT = TEST
            NAME = CHOSEN_TO_EXPORT.NAME
            DESCRIPTION = CHOSEN_TO_EXPORT.DESCRIPTION
        End If

        If CHOSEN_TO_EXPORT.RETURN_QUESTIONS().Count > 0 Then

            ' I aim to create a list of all the data I need.
            Dim STREAM As Stream = File.Open(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & STUDENT_NAME & " " & NAME & " " & TEST_NAME, FileMode.OpenOrCreate) ' The file I will be exporting to.

            Dim DATA_LIST As New List(Of Dictionary(Of String, String))

            Dim META_DATA As New Dictionary(Of String, String) ' The name and description of the test.
            META_DATA.Add("NAME", NAME)
            META_DATA.Add("DESCRIPTION", DESCRIPTION)
            If Not STUDENT_NAME = "" Then
                META_DATA.Add("STUDENT NAME", STUDENT_NAME)
            End If
            META_DATA.Add("MARKED", CHOSEN_TO_EXPORT.MARKED.ToString)
            DATA_LIST.Add(META_DATA)

            For Each QUESTION As QUESTION In CHOSEN_TO_EXPORT.RETURN_QUESTIONS
                Dim QUESTION_DATA As New Dictionary(Of String, String)
                QUESTION_DATA.Add("QUESTION", QUESTION.RETURN_QUESTION) ' The question, like 3x+3x
                QUESTION_DATA.Add("QUESTION TITLE", QUESTION.QUESTION_TITLE) ' The title, like "Differentiate with respect to x"
                QUESTION_DATA.Add("QUESTION TYPE", QUESTION.QUESTION_ANSWER_TYPE.ToString) ' The type, either differentiation or simplification.
                QUESTION_DATA.Add("ANSWER", QUESTION.RETURN_ANSWER) ' The answer the user set.
                QUESTION_DATA.Add("TYPE", QUESTION.TYPE) ' The type, either differentiation or simplification.
                QUESTION_DATA.Add("TEACHER EDITED", QUESTION.TEACHER_EDITED.ToString) ' The type, either differentiation or simplification.
                QUESTION_DATA.Add("STATUS", QUESTION.STATUS.ToString) ' The type, either differentiation or simplification.
                DATA_LIST.Add(QUESTION_DATA)
            Next

            JsonSerializer.SerializeAsync(STREAM, DATA_LIST) ' This converts the list into a string that is then written into my text file.
            Debug.WriteLine(JsonSerializer.Serialize(DATA_LIST))
            STREAM.Close()
            Shell("explorer /select," & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & STUDENT_NAME & " " & NAME & " " & TEST_NAME, AppWinStyle.NormalFocus)
            If TEST_NAME = "\QUESTION Export.json" Then
                TOGGLE_CERTAIN_SCREEN(Q_CONTROL_GROUP, True)
            End If
            NOTIFICATIONS_OBJECT.ADD_NOTIFICATION("Successfully exported", Color.Green)
        End If
        Return False
    End Function


    '/////////////////////////////
    ' END
    '////////////////////////////


End Class


' A custom class for notification creation. An optional addition that I made... because I like to waste time.
Class NOTIFICATIONS ' Handles notifications, has a max of 6 notifications at one time. 

    ' Possible improvement*
    '//Make the timer reset on each new notification.//

    Private WINDOW_WIDTH
    Private WINDOW_HEIGHT
    Private FORM As Form
    Private NOTIFICATIONS As New Stack(Of Label) ' Will be in the form { Label,Label }, it is used to hold the notifications.
    Private INTERNAL_REMOVAL As Boolean = False
    Private TIMER As System.Timers.Timer

    ' Window Resize Handling

    ' Delegate for control changing (due to thread differences this is required for invoking)
    Private Delegate Sub PROPERTY_CONTROL(Label As Label)
    Private Delegate Sub PROPERTY_CONTROL_LOCATION(Label As Label, POINT As Point)

    Private Sub E_RESIZE() 'Changes the WINDOW_WIDTH & WINDOW_HEIGHT whenever window is resized
        Debug.Print(Me.FORM.Height & Me.FORM.Width)
        Me.WINDOW_HEIGHT = FORM1.LOGIN_GROUP.Height ' The group has an offset, allowing the placing to be pleasing to the eye.
        Me.WINDOW_WIDTH = FORM1.LOGIN_GROUP.Width
    End Sub

    Sub New(ByRef FORM_INPUT As Form) ' This is sent a reference for the form, so it can access it.
        Me.FORM = FORM_INPUT ' Sets private variable
        AddHandler Me.FORM.ResizeEnd, AddressOf E_RESIZE 'Adds the resize handler to the E_RESIZE subroutine.
        Threading.Thread.Sleep(500)
        Me.WINDOW_HEIGHT = 690
        Me.WINDOW_WIDTH = 883 ' Initialises the variables
    End Sub

    ' Delegate methods used for thread communication.
    Private Sub REMOVE(INPUT As Label) ' Removes a control.
        INPUT.Dispose()
    End Sub

    Private Sub LOCATION(INPUT As Label, POINT As Point) ' Used to change controls position.
        INPUT.Location = POINT
    End Sub

    ' Notification System

    Private Sub ELAPSED()
        If Me.NOTIFICATIONS.Count = 0 Then ' If there are no more notifications.
            TIMER.Dispose()
            Me.INTERNAL_REMOVAL = False ' Disables the check variable so this sub can be initialised again.
            Return
        End If
        Dim REMOVED As Label = Me.NOTIFICATIONS.Pop() ' Gets the popped label so we can dispose of it.
        Dim REMOVE_DELEGATE As PROPERTY_CONTROL = New PROPERTY_CONTROL(AddressOf REMOVE) ' Creates a delegate that points to the remove subroutines
        REMOVED.Invoke(REMOVE_DELEGATE, New Object() {REMOVED}) 'Passes the delegate (ie a pointer to a function) with the paramter of the label. This removes the control within the controls thread. 
        Dim Count As Integer = 0 ' Used to stack the notifications.
        Dim POSITION_DELEGATE As PROPERTY_CONTROL_LOCATION = New PROPERTY_CONTROL_LOCATION(AddressOf LOCATION) ' Creates a delegate for position changing.
        For Each ILabel As Label In Me.NOTIFICATIONS 'Rearrange them
            Count += 1
            ILabel.Invoke(POSITION_DELEGATE, New Object() {REMOVED, New Point(Me.WINDOW_WIDTH - ILabel.Width, (Me.WINDOW_HEIGHT - ILabel.Height) - ILabel.Height * (Count))}) ' Sends both argurments with the delegate to run in the correct thread.
        Next
    End Sub

    Private Sub INTERNAL_NOTIFICATION() ' Intermediate subroutine for elapsed subroutines.
        Me.INTERNAL_REMOVAL = True ' Enables the check variable so this cannot be called again.
        TIMER = New System.Timers.Timer(3000) ' Creates a timer.
        TIMER.Enabled = True
        AddHandler TIMER.Elapsed, AddressOf ELAPSED ' Connects the event of the timer to the elapsed subroutines, making it run ever 3 seconds.
    End Sub


    Public Sub ADD_NOTIFICATION(Message As String, Colour As Color)
        If Me.NOTIFICATIONS.Count < 6 Then
            ' Create Label
            Dim Label As New Label
            Debug.Print(FORM1.Controls.Count)
            FORM1.Controls.Add(Label)
            Label.Text = Message
            Label.AutoSize = True
            Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label.Refresh()
            Label.Location = New System.Drawing.Point(Me.WINDOW_WIDTH - Label.Size.Width, (Me.WINDOW_HEIGHT - Label.Size.Height / 2) - Label.Height * (Me.NOTIFICATIONS.Count + 1)) ' Positions it in the corner.
            Label.TabIndex = 4
            Label.Anchor = System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Bottom ' Anchors it so that it moves when resized.
            Label.BringToFront() ' Brings it to the front so it can be seen.
            Label.ForeColor = Colour ' Sets the arguement colour.
            Me.NOTIFICATIONS.Push(Label)
            If Not Me.INTERNAL_REMOVAL Then 'Starts a thread to automatically remove notifications every 3 seconds.
                Me.INTERNAL_NOTIFICATION()
            End If
        End If
    End Sub

End Class

' Handles the logging in of an account.
Class ACCOUNT

    ' EVENTS 

    ' Page Events
    ' Fire when the program should change page.

    Public Event LOGIN_SCREEN()
    Public Event MODE_SCREEN()

    ' Properties

    ' Account Properties
    Private Property LOGGING_MODE As LOGIN_MODE ' This determines whether the student is logging in as a teacher or a student.
    Private Property MODE As LOGIN_MODE ' This is the property for the accounts actual mode. This is changed when logging in.

    Private CODE As New Dictionary(Of LOGIN_MODE, String) From {{LOGIN_MODE.STUDENT, "student"}, {LOGIN_MODE.TEACHER, "teacher"}} ' Used for easy indexing of the login codes.

    ' Methods

    ' Account Methods

    ' Subroutines
    Public Sub SELECT_MODE(INPUT As LOGIN_MODE) ' The input must be in the Enum form. This selects the mode 
        Me.LOGGING_MODE = INPUT
        RaiseEvent LOGIN_SCREEN() ' Shows the login screen. 
    End Sub

    ' Functions
    Public Function LOGIN(INPUT As String)
        If Me.CODE.Item(Me.LOGGING_MODE) = INPUT Then 'They entered the correct code
            Me.MODE = Me.LOGGING_MODE 'Set the current mode the program is in.
            Return True
        End If
        Return False
    End Function

    Public Function ACCOUNT_TYPE()
        Return Me.MODE
    End Function

End Class

