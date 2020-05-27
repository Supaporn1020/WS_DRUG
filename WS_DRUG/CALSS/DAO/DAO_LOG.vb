Namespace DAO_LOG
    Public MustInherit Class MAIN_CONTEXT
        Public db As New LINQ_DRUG_DEMODataContext
        Public datas

    End Class
    Public Class TB_TESTANGULAR_LOG
        Inherits MAIN_CONTEXT

        Public fields As New TESTANGULAR_LOG

        Public Sub insert()
            db.TESTANGULAR_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Private _Details As New List(Of TESTANGULAR_LOG)
        Public Property Details() As List(Of TESTANGULAR_LOG)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TESTANGULAR_LOG))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TESTANGULAR_LOG
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.TESTANGULAR_LOGs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

    End Class

End Namespace