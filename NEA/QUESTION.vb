' This is the class that is used to create questions.
' Handles the storage of answers and the custom interfaces it uses. 

Enum QUESTION_TYPE_ANSWER
    DIFFERENTIATION
    SIMPLIFICATION
End Enum

Enum QUESTION_STATUS
    CORRECT
    INDETERMINED
    WRONG
End Enum

Class TEACHER_QUESTION : Inherits QUESTION

    Sub New(ByRef DATA_HANDLE_INPUT As DATA_HANDLE)
        DATA_HANDLER = DATA_HANDLE_INPUT
        AddHandler FORM1.QUESTION_RECOMPUTE_ANSWER.Click, RECALC_EVENT
    End Sub


    Dim RECALC_EVENT As EventHandler = Function(sender, e) RECOMPUTE_CHOSEN_QUESTION()
    Dim ADDING_EVENT As EventHandler = Function(sender, e) UPDATE_CLASS(False)
    Dim EDITING_EVENT As EventHandler = Function(sender, e) UPDATE_CLASS(True)
    Dim REVOKER_EVENT As EventHandler = Function(sender, e) REMOVE_HANDLER()

    Private Function UPDATE_CLASS(Optional EDIT As Boolean = False)
        QUESTION_TEXT = FORM1.QUESTION_INPUT.Text
        If Not EDIT Then
            DATA_HANDLER.ADD(Me)
        End If
    End Function

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


        Return True
    End Function

    Private Function REMOVE_HANDLER()
        RemoveHandler FORM1.QUESTION_RECOMPUTE_ANSWER.Click, RECALC_EVENT
        RemoveHandler FORM1.QUESTION_CREATE.Click, ADDING_EVENT
        RemoveHandler FORM1.QUESTION_CREATE.Click, REVOKER_EVENT
        RemoveHandler FORM1.QUESTION_CREATION_EXIT.Click, REVOKER_EVENT
        RemoveHandler FORM1.QUESTION_CREATE.Click, EDITING_EVENT
        Return True
    End Function

    Public Function CHOSEN_QUESTION_TO_CREATE()
        ' This functions occurs when the user has selected a template and clicked create.

        Dim CHOSEN_QUESTION_TEMPLATE As String = FORM1.QUESTION_CHOOSER_LIST.SelectedItem.ToString
        Dim TEMPLATE_ITEMS = DATA_HANDLER.QUESTION_DEFINERS.Item(CHOSEN_QUESTION_TEMPLATE)
        Type = FORM1.QUESTION_CHOOSER_LIST.SelectedItem.ToString
        ' Update the group 'Question Creation'
        FORM1.QUESTION_DISPLAY.Text = TEMPLATE_ITEMS(0) ' The first item is always the string question, like "Calculate the like terms." or whatever.
        QUESTION_TITLE = TEMPLATE_ITEMS(0)
        ' Calculate the number that this question will have, which is always one more than the current number of created questions.
        Dim QUESTION_COUNT_NUM As Integer = DATA_HANDLER.RETURN_QUESTIONS().Count() + 1
        FORM1.QUESTION_COUNT.Text = QUESTION_COUNT_NUM
        ' Get a random question
        Dim RANDOM As New Random
        Dim QUESTION_INDEX As Integer = RANDOM.Next(1, TEMPLATE_ITEMS.Count) ' The random index for 'Template_items'.
        Dim QUESTION_STRING As String = TEMPLATE_ITEMS(QUESTION_INDEX)
        FORM1.QUESTION_INPUT.Text = QUESTION_STRING

        ' Create a 'Simple_Simplify' object that will answer the question. 
        Debug.WriteLine(QUESTION_STRING)
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

        AddHandler FORM1.QUESTION_CREATE.Click, REVOKER_EVENT
        AddHandler FORM1.QUESTION_CREATION_EXIT.Click, REVOKER_EVENT
        AddHandler FORM1.QUESTION_CREATE.Click, ADDING_EVENT

        Return True
    End Function

    Public Function EDIT_QUESTION(QUESTION_INDEX As Integer)

        FORM1.QUESTION_INPUT.Text = QUESTION_TEXT
        FORM1.QUESTION_COUNT.Text = QUESTION_INDEX + 1
        FORM1.QUESTION_DISPLAY.Text = QUESTION_TITLE
        RECOMPUTE_CHOSEN_QUESTION()


        AddHandler FORM1.QUESTION_RECOMPUTE_ANSWER.Click, RECALC_EVENT
        AddHandler FORM1.QUESTION_CREATE.Click, REVOKER_EVENT
        AddHandler FORM1.QUESTION_CREATE.Click, EDITING_EVENT
        Return True
    End Function
End Class


Class QUESTION

    Public TYPE As String

    Protected ENABLED As Boolean = True ' Determines if editable.
    Protected DATA_HANDLER As DATA_HANDLE
    Protected ANSWER_CLASS As SIMPLE_SIMPLIFY ' Dynamic answer that can be recomputed.
    Protected QUESTION_TEXT As String ' This is the actual question that is saved in the class.

    Public Property QUESTION_ANSWER_TYPE As QUESTION_TYPE_ANSWER
    Public Property QUESTION_TITLE As String
    Public Property STATUS As QUESTION_STATUS ' This is used for submissions. I won't make a seperate class for this as it will just complicate things for no reason... e.e
    Public Property TEACHER_EDITED As Boolean = False

    Public Function RETURN_QUESTION()
        Return QUESTION_TEXT
    End Function

    Public Sub SET_QUESTION(V As String)
        QUESTION_TEXT = V
    End Sub

    Public Function RETURN_COMPUTED_ANSWER()
        Return ANSWER_CLASS.RESULT
    End Function

    Protected ANSWER As String = ""

    Public Function RETURN_ANSWER()
        Return ANSWER
    End Function

    Public Function RETURN_ANSWER_FUNCTION_OUTPUT(VALUE As Integer)
        Return ANSWER_CLASS.GET_OUTPUT(VALUE) ' Says f(x) = 9x^2, this will output the 9x^2 for the selected value, like 1.
    End Function

    Public Overridable Sub SUBMIT_ANSWER(INPUT As String) 'Submits answer..
        Me.ANSWER = INPUT

        ' When the user answer is set it is expected that the actual answer will also exist, so this will check for it. 
        If ANSWER_CLASS Is Nothing Then
            If QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.SIMPLIFICATION Then
                ANSWER_CLASS = New SIMPLE_SIMPLIFY(Me.QUESTION_TEXT, False, True)
            ElseIf QUESTION_ANSWER_TYPE = QUESTION_TYPE_ANSWER.DIFFERENTIATION Then
                ANSWER_CLASS = New SIMPLE_SIMPLIFY(Me.QUESTION_TEXT, True) ' Parameters are Differentiate, Expand Brackets.
            End If
        End If
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



End Class

