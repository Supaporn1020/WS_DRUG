Imports System.Data
Imports System.Data.SqlClient
Namespace BAO
    Public Class BAO
        Dim cmd As New SqlCommand
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        Public Function Queryds_xml_drug(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=10.111.28.124;Initial Catalog=FDA_XML_DRUG_ESUB;User ID=fusion;Password=P@ssw0rd;"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function SP_UPDATE_DRUG_ESUB(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_UPDATE_DRUG_ESUB] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_xml_drug(sql)
            dt.TableName = "SP_UPDATE_DRUG_ESUB"
            Return dt
        End Function
        Public Function SP_UPDATE_DRUG_GROUP_ESUB(ByVal pvncd As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal rgtno As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_UPDATE_DRUG_GROUP_ESUB] @pvncd = '" & pvncd & "',@rgttpcd = '" & rgttpcd & "',@drgtpcd = '" & drgtpcd & "',@rgtno = '" & rgtno & "'"
            Dim dt As New DataTable
            dt = Queryds_xml_drug(sql)
            dt.TableName = "SP_UPDATE_DRUG_GROUP_ESUB"

            Return dt
        End Function
        Public Function SP_PRODUCT_DRUG_MANAGE_INSERT(ByVal pvncd As String, ByVal drgtpcd As String, ByVal rgttpcd As String, ByVal rgtno As String, ByVal lcnno As String) As DataTable

            Dim dt As New DataTable
            Dim sql As String = "exec SP_PRODUCT_DRUG_MANAGE_INSERT @pvncd='" & pvncd & "',@drgtpcd='" & drgtpcd & "',@rgttpcd='" & rgttpcd & "',@rgtno='" & rgtno & "',@lcnno='" & lcnno & "'"
            dt = Queryds_xml_drug(sql)
            Return dt
        End Function
    End Class
End Namespace





