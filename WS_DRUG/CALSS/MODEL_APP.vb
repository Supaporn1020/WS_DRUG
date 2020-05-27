Public Class MODEL_APP
    Private _Newcode As String
    Public Property Newcode() As String
        Get
            Return _Newcode
        End Get
        Set(ByVal value As String)
            _Newcode = value
        End Set
    End Property

    Private _LGT_IOW_E As LGT_IOW_E
    Public Property LGT_IOW_E() As LGT_IOW_E
        Get
            Return _LGT_IOW_E
        End Get
        Set(ByVal value As LGT_IOW_E)
            _LGT_IOW_E = value
        End Set
    End Property


    Private _citizen_authorize As String
    Public Property citizen_authorize() As String
        Get
            Return _citizen_authorize
        End Get
        Set(ByVal value As String)
            _citizen_authorize = value
        End Set
    End Property

    Private _STATUS_ID As Integer
    Public Property STATUS_ID() As Integer
        Get
            Return _STATUS_ID
        End Get
        Set(ByVal value As Integer)
            _STATUS_ID = value
        End Set
    End Property

    Private _REMARK As String
    Public Property REMARK() As String
        Get
            Return _REMARK
        End Get
        Set(ByVal value As String)
            _REMARK = value
        End Set
    End Property

    Private _process_id As String
    Public Property process_id() As String
        Get
            Return _process_id
        End Get
        Set(ByVal value As String)
            _process_id = value
        End Set
    End Property

    Private _TR_ID As String
    Public Property TR_ID() As String
        Get
            Return _TR_ID
        End Get
        Set(ByVal value As String)
            _TR_ID = value
        End Set
    End Property

End Class
