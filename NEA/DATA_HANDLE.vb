﻿' This handles the exporting/importing of a set of questions.
Public Enum QUESTION_TYPE
    COLLECTING_LIKE_TERMS
    HARD_COLLECTING_LIKE_TERMS
    EXPANDING_SQUARES
    EXPANDING_3_VARIABLE_BRACKETS
    POWER_RULES
    CUBE_BRACKETS
    DIFFERENTIATING_SINGLE_TERMS
    DIFFERENTIATING_PRODUCTS
    DIFFERENTIATING_BRACKET_POWERS
    DIFFERENTIATING_FRACTIONS
    DIFFERENTIATING_3_TERM_PRODUCTS
    DIFFERENTIATING_2_VARIABLE_FUNCTIONS
    DIFFERENTIATING_3_VARIABLE_FUNCTIONS
    PROVING_PRODUCT_RULE
End Enum



Class DATA_HANDLE_TEACHER : Inherits DATA_HANDLE ' For Teachers.
    Public QUESTIONS As New List(Of TEACHER_QUESTION)
End Class
Class DATA_HANDLE

    Private MARK_SYMBOLS As Dictionary(Of QUESTION_STATUS, String) = New Dictionary(Of QUESTION_STATUS, String) From
    {{QUESTION_STATUS.CORRECT, "✓"}, {QUESTION_STATUS.WRONG, "X"}, {QUESTION_STATUS.INDETERMINED, "?"}}

    Shadows QUESTIONS As New List(Of QUESTION)
    Protected Event QUESTION_LIST_CHANGE()
    Protected Form As Form
    Public QUESTION_DEFINERS As Dictionary(Of String, List(Of String))

    Public STUDENT_NAME As String = ""
    Public Property QUESTION_1
        Get
            Return "Simplify the following expression."
        End Get
        Set(value)
        End Set
    End Property

    Public Property QUESTION_2
        Get
            Return "Calculate the derivative as a ratio over x."
        End Get
        Set(value)
        End Set
    End Property

    Public DESCRIPTION As String = ""
    Public NAME As String = ""
    Public MARKED As Boolean = False

    Sub New(Optional STUDENT As Boolean = False)
        If Not STUDENT Then
            AddHandler QUESTION_LIST_CHANGE, AddressOf UPDATE_QUESTION_LIST
        End If
        ' A bit of data for the templates.Some of it is pretty dumb, like the question identifiers. But I have 2 hours before this must be done :).
        QUESTION_DEFINERS = New Dictionary(Of String, List(Of String)) From {{"Collecting Like Terms", New List(Of String)({QUESTION_1, "3x+9z-10x^2+9y+10x-2y", "24z-10u+3y^2-4u+23", "99x^2-6*9x+33y"})},
            {"Hard Collecting Like Terms", New List(Of String)({QUESTION_1, "33yx^2+99y^(x-3)+2yx^2", "27zx^(x^2-3x)+99zx^2-23y", "37x^(x^2-3x)+99x^2-23y"})},
            {"Expanding Squares", New List(Of String)({QUESTION_1, "(x-10)^2", "(2x^(3x-2)+-3y)^2", "(9x^(10x+3)+3x)^2"})},
            {"Expanding 3 Variable Brackets", New List(Of String)({QUESTION_1, "(9x^3-10x+9y)^2", "(6x^2-y+10z)^2", "(9x^10-23x+2y)^2"})},
            {"Cube Brackets", New List(Of String)({QUESTION_1, "(9x^3-10x)^3", "(6x^2+10z)^3", "(9x^10+2y)^3"})},
            {"Power Rules", New List(Of String)({QUESTION_1, "((x^(3x-9))*x^(9x^2+3x))^3", "(y^(3x-9))*y^(9x^2+3x)+2*(y^(3x-9))*y^(9x^2+3x)", "(x^(6x+18))^2+(x^(3x+9))^4"})},
            {"Differentiating Single Terms", New List(Of String)({QUESTION_2, "10x^3+9x-3", "32x^3-2x^2+55x", "9x^2-10x"})},
            {"Differentiating Products", New List(Of String)({QUESTION_2, "((3x^2-10x)^10)*33x", "((5x-10)^36)*(5x+10)", "((2x^3+10x)^5)*(9x^3+3)"})},
            {"Differentiating Bracket Powers", New List(Of String)({QUESTION_2, "((3x^2-10x+99)^10)", "((5x-10-10x)^36)", "((2x^3+10x+3x^2)^5)"})},
            {"Differentiating Fractions", New List(Of String)({QUESTION_2, "(9x+3)/(10x-3)", "((x-2)^2)/(10x+3)", "(32x^2+1)/((5x-2)^2)"})},
            {"Differentiating 3 Term Products", New List(Of String)({QUESTION_2, "(9x+3)*(10x-3)*((10x+3)^10)", "(99x^2+3)*((3x-2)^5)*((3x+2)^5)", "((5x-6x^2)^5)*((3x-2)^5)*((3x+2)^5)"})},
            {"Differentiating 2 Variable Functions", New List(Of String)({QUESTION_2, "(2y+3x)^2", "(5y-7x)*((13y^2+3)^3)", "(5y+3y^2)/(3x-10)"})},
            {"Differentiating 3 Variable Functions", New List(Of String)({QUESTION_2, "(2y+3x+5z)^2", "(5y-7x-3yu)*((13y^2+3)^3)", "(5yu+3y^2)/(3xy-10)"})},
            {"Proving Product Rule", New List(Of String)({QUESTION_2, "uv"})}}
    End Sub

    Public Function REMOVE(QUESTION_OBJECT As QUESTION)
        QUESTIONS.Remove(QUESTION_OBJECT)
        RaiseEvent QUESTION_LIST_CHANGE()
        Return True
    End Function

    Public Function CLEAR_ALL()
        QUESTIONS = New List(Of QUESTION)
        RaiseEvent QUESTION_LIST_CHANGE()
    End Function

    Public Function ADD(QUESTION_OBJECT As QUESTION)
        QUESTIONS.Add(QUESTION_OBJECT)
        RaiseEvent QUESTION_LIST_CHANGE()
        Return True
    End Function

    Sub UPDATE_QUESTION_LIST()
        FORM1.Q_CONTROL_GROUP_LISTBOX.Items.Clear()
        For Each QUESTION As QUESTION In QUESTIONS
            FORM1.Q_CONTROL_GROUP_LISTBOX.Items.Add(QUESTION.TYPE)
        Next
    End Sub

    Sub UPDATE_TEST_LIST()
        FORM1.TEST_VIEWER_QUESTION_LIST.Items.Clear()
        For Each QUESTION As QUESTION In QUESTIONS
            Dim POSSIBLE_ADD As String = ""
            If MARKED Then
                Select Case QUESTION.STATUS
                    Case QUESTION_STATUS.WRONG
                        POSSIBLE_ADD = " " & MARK_SYMBOLS(QUESTION_STATUS.WRONG)
                    Case QUESTION_STATUS.CORRECT
                        POSSIBLE_ADD = " " & MARK_SYMBOLS(QUESTION_STATUS.CORRECT)
                    Case QUESTION_STATUS.INDETERMINED
                        POSSIBLE_ADD = " " & MARK_SYMBOLS(QUESTION_STATUS.INDETERMINED)
                End Select
            End If
            FORM1.TEST_VIEWER_QUESTION_LIST.Items.Add(QUESTION.TYPE & POSSIBLE_ADD)
        Next
    End Sub

    Function RETURN_QUESTIONS() As List(Of QUESTION)
        Return QUESTIONS
    End Function

End Class
