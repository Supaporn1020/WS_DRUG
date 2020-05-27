Public Class LGT_RECIPE_GROUP_TO
    Private _XML_DRUG_RECIPE_GROUP As New XML_DRUG_RECIPE_GROUP
    Public Property XML_DRUG_RECIPE_GROUP() As XML_DRUG_RECIPE_GROUP
        Get
            Return _XML_DRUG_RECIPE_GROUP
        End Get
        Set(ByVal value As XML_DRUG_RECIPE_GROUP)
            _XML_DRUG_RECIPE_GROUP = value
        End Set
    End Property
End Class
