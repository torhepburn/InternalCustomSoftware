Public Class XLSControlFile
    Private _SheetCount As Integer
    Public Class XLSControlSheet
        Private _SheetName() As String
        Private _LabelName As String
        Private _FilePath As String
        Property SheetName(ByVal Index As Integer) As String
            Get
                Return _SheetName(Index)
            End Get
            Set(ByVal value As String)
                _SheetName(Index) = value
            End Set
        End Property
        Property LabelName() As String
            Get
                Return _LabelName
            End Get
            Set(ByVal value As String)
                _LabelName = value
            End Set
        End Property
        Property FilePath() As String
            Get
                Return _FilePath
            End Get
            Set(ByVal value As String)
                _FilePath = value
            End Set
        End Property
    End Class
    Property SheetCount() As Integer
        Get
            Return _SheetCount
        End Get
        Set(ByVal value As Integer)
            _SheetCount = value
        End Set
    End Property

End Class
