' This is the class that is used to create questions.
' Handles the storage of answers and the custom interfaces it uses. 

Enum QUESTION_TYPE_ANSWER
    DIFFERENTIATION
    SIMPLIFICATION
End Enum


Class QUESTION

    Protected TYPE As String
    Protected ENABLED As Boolean = True ' Determines if editable.
    Protected FORM
    Protected DATA_HANDLER As DATA_HANDLE
    Protected ANSWER_CLASS As SIMPLE_SIMPLIFY ' Dynamic answer that can be recomputed.
    Dim QUESTION_ANSWER_TYPE As QUESTION_TYPE_ANSWER
    Dim ANSWER As String

    Public Overridable Sub SUBMIT_ANSWER(INPUT As String) 'Submits answer..
        Me.ANSWER = INPUT
    End Sub

    Sub New(INPUT As Form, ByRef DATA_HANDLE_INPUT As DATA_HANDLE)
        FORM = INPUT
        DATA_HANDLER = DATA_HANDLE_INPUT
        AddHandler FORM1.QUESTION_RECOMPUTE_ANSWER.Click, Function(sender, e) RECOMPUTE_CHOSEN_QUESTION()
    End Sub

    'Public Sub SET_ANSWER_MENU() ' Sets the answer menu's (groupbox) properties.
    '    For Each IARRAY As Array In Properties ' Loop through the properties list
    '        If ANSWER_MENU.Controls.ContainsKey(IARRAY(0)) Then
    '            Dim LOCAL_CONTROL As Array = ANSWER_MENU.Controls.Find(IARRAY(0), True)
    '            For Each ICONTROL As Control In LOCAL_CONTROL
    '                ICONTROL.Text = IARRAY(1)
    '            Next
    '        End If
    '    Next
    'End Sub


    ' Teacher section of question class.

    Private Function RECOMPUTE_CHOSEN_QUESTION()
        ' This is for the recomputing whenever the user wants.

        Dim TO_BE_SOLVED As SIMPLE_SIMPLIFY ' 
        Debug.WriteLine("im doing")
        If QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.SIMPLIFICATION Then
            TO_BE_SOLVED = New SIMPLE_SIMPLIFY(FORM1.QUESTION_INPUT.Text, False, True)
        ElseIf QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.DIFFERENTIATION Then
            TO_BE_SOLVED = New SIMPLE_SIMPLIFY(FORM1.QUESTION_INPUT.Text, True) ' Parameters are Differentiate, Expand Brackets.
        End If
        FORM1.QUESTION_CREATION_ANSWER.Text = TO_BE_SOLVED.RESULT
        ANSWER_CLASS = TO_BE_SOLVED



    End Function

    Public Function CHOSEN_QUESTION_TO_CREATE()
        ' This functions occurs when the user has selected a template and clicked create.

        Dim CHOSEN_QUESTION_TEMPLATE As String = FORM1.QUESTION_CHOOSER_LIST.SelectedItem.ToString
        Dim TEMPLATE_ITEMS = DATA_HANDLER.QUESTION_DEFINERS.Item(CHOSEN_QUESTION_TEMPLATE)

        ' Update the group 'Question Creation'
        FORM1.QUESTION_DISPLAY.Text = TEMPLATE_ITEMS(0) ' The first item is always the string question, like "Calculate the like terms." or whatever.
        ' Calculate the number that this question will have, which is always one more than the current number of created questions.
        Dim QUESTION_COUNT As Integer = DATA_HANDLER.RETURN_QUESTION().Count() + 1
        QUESTION_COUNT = QUESTION_COUNT
        ' Get a random question
        Dim RANDOM As New Random
        Dim QUESTION_INDEX As Integer = RANDOM.Next(1, TEMPLATE_ITEMS.Count - 2) ' The random index for 'Template_items'. Note that its -2 as I ignore the first index (0).
        Dim QUESTION_STRING As String = TEMPLATE_ITEMS(QUESTION_INDEX)
        FORM1.QUESTION_INPUT.Text = QUESTION_STRING

        ' Create a 'Simple_Simplify' object that will answer the question. 

        Dim TO_BE_SOLVED As SIMPLE_SIMPLIFY ' This will simplify the expression without expanding power brackets.

        If TEMPLATE_ITEMS(0) = DATA_HANDLER.QUESTION_1 Then ' This is a non differentiation question.
            TO_BE_SOLVED = New SIMPLE_SIMPLIFY(QUESTION_STRING, False, True)
            QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.SIMPLIFICATION
        ElseIf TEMPLATE_ITEMS(0) = DATA_HANDLER.QUESTION_2 Then ' Differentiation does not need bracket expansion.
            TO_BE_SOLVED = New SIMPLE_SIMPLIFY(QUESTION_STRING, True) ' Parameters are Differentiate, Expand Brackets.
            QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.DIFFERENTIATION
        End If

        FORM1.QUESTION_CREATION_ANSWER.Text = TO_BE_SOLVED.RESULT ' This displays the result of the class's calculations.

        FORM1.QUESTION_REMOVE.Visible = False ' As this is a creation we can not remove it.
        FORM1.QUESTION_CREATE.Visible = True

        ANSWER_CLASS = TO_BE_SOLVED


    End Function
End Class