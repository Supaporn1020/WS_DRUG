Public Class LGT_XML_STOWAGR_TO
    Private _XML_DRUG_STOWAGR As New XML_DRUG_STOWAGR
    Public Property XML_DRUG_STOWAGR() As XML_DRUG_STOWAGR
        Get
            Return _XML_DRUG_STOWAGR
        End Get
        Set(ByVal value As XML_DRUG_STOWAGR)
            _XML_DRUG_STOWAGR = value
        End Set
    End Property
End Class
