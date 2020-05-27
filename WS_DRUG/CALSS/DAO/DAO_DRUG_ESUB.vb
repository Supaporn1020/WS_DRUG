Namespace DAO_DRUG_ESUB
    Public MustInherit Class MAIN_CONTEXT
        Public db As New LGT_DRUGDataContext
        Public datas

    End Class
    Public Class TB_XML_SEARCH_PRODUCT_GROUP
        Inherits MAIN_CONTEXT

        Public fields As New XML_SEARCH_PRODUCT_GROUP_ESUB

        Private _Details As New List(Of XML_SEARCH_PRODUCT_GROUP_ESUB)
        Public Property Details() As List(Of XML_SEARCH_PRODUCT_GROUP_ESUB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_SEARCH_PRODUCT_GROUP_ESUB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_SEARCH_PRODUCT_GROUP_ESUB
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        Public Sub GETDATA_BY_IDA_Nndetail(ByVal IDA As Integer)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GETDATA_BY_Newcode_U(ByVal Newcode As String)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode_U = Newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GETDATA_BY_4key(ByVal pvncd As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal rgtno As String)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.pvncd = pvncd And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd And p.rgtno = rgtno Select p)
            For Each Me.fields In datas

            Next
        End Sub


        Public Sub insert()
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย

            db.SubmitChanges()
        End Sub

        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63
        Inherits MAIN_CONTEXT

        Public fields As New XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63

        Private _Details As New List(Of XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63)
        Public Property Details() As List(Of XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63s Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GETDATA_BY_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63s Where p.Newcode_U = Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub insert()
            db.XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub
        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class


    Public Class TB_XML_DRUG_STOWAGR
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_STOWAGR

        Private _Details As New List(Of XML_DRUG_STOWAGR)
        Public Property Details() As List(Of XML_DRUG_STOWAGR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_STOWAGR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_STOWAGR
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_STOWAGRs Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GETDATA_BY_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_STOWAGRs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub insert()
            db.XML_DRUG_STOWAGRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_STOWAGRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub
        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_RECIPE_GROUP
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_RECIPE_GROUP

        Private _Details As New List(Of XML_DRUG_RECIPE_GROUP)
        Public Property Details() As List(Of XML_DRUG_RECIPE_GROUP)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_RECIPE_GROUP))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_RECIPE_GROUP
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GETDATA_BY_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub insert()
            db.XML_DRUG_RECIPE_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_RECIPE_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_ANIMAL

        Private _Details As New List(Of XML_DRUG_ANIMAL)
        Public Property Details() As List(Of XML_DRUG_ANIMAL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_ANIMALs Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GETDATA_BY_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_ANIMALs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_ANIMAL.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_ANIMALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL_CONSUME
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_ANIMAL_CONSUME

        Private _Details As New List(Of XML_DRUG_ANIMAL_CONSUME)
        Public Property Details() As List(Of XML_DRUG_ANIMAL_CONSUME)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL_CONSUME))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL_CONSUME
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GETDATA_BY_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_ANIMAL_CONSUMEs.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMAL_CONSUMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_ANIMAL_CONSUMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub
        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_IOW

        Private _Details As New List(Of XML_DRUG_IOW)
        Public Property Details() As List(Of XML_DRUG_IOW)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_IOWs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_IOWs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String, ByVal flineno As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U And p.flineno = flineno Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U_GROUP(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U Group p By p.flineno Into Group
                     Select New With {flineno})
        End Sub

        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_IOWs.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_IOWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_IOWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub
        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW_EQ
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_IOW_EQ

        Private _Details As New List(Of XML_DRUG_IOW_EQ)
        Public Property Details() As List(Of XML_DRUG_IOW_EQ)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW_EQ))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW_EQ
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_IOW_EQs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_RID(ByVal Newcode_RID As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode_rid = Newcode_RID Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_IOW_EQ.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_IOW_EQs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_IOW_EQs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_FRGN
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_FRGN

        Private _Details As New List(Of XML_DRUG_FRGN)
        Public Property Details() As List(Of XML_DRUG_FRGN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_FRGN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_FRGN
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_FRGNs Order By p.Newcode Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_FRGNs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_FRGNs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_FRGNs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_FRGN.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_FRGNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_FRGNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_EXPORT
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_EXPORT

        Private _Details As New List(Of XML_DRUG_EXPORT)
        Public Property Details() As List(Of XML_DRUG_EXPORT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_EXPORT))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_EXPORT
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_EXPORTs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_EXPORTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_EXPORTs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_EXPORT.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_EXPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_EXPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_COLOR
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_COLOR

        Private _Details As New List(Of XML_DRUG_COLOR)
        Public Property Details() As List(Of XML_DRUG_COLOR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_COLOR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_COLOR
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_COLORs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_COLORs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_COLORs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_COLOR.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_AGENT
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_AGENT

        Private _Details As New List(Of XML_DRUG_AGENT)
        Public Property Details() As List(Of XML_DRUG_AGENT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_AGENT))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_AGENT
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_AGENTs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_AGENTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_AGENTs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_AGENT.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_AGENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_AGENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_STORY_EDIT_HISTORY
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_STORY_EDIT_HISTORY

        Private _Details As New List(Of XML_DRUG_STORY_EDIT_HISTORY)
        Public Property Details() As List(Of XML_DRUG_STORY_EDIT_HISTORY)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_STORY_EDIT_HISTORY))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_STORY_EDIT_HISTORY
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_STORY_EDIT_HISTORY.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_STORY_EDIT_HISTORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_STORY_EDIT_HISTORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONDITION_TABEAN
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_CONDITION_TABEAN

        Private _Details As New List(Of XML_DRUG_CONDITION_TABEAN)
        Public Property Details() As List(Of XML_DRUG_CONDITION_TABEAN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONDITION_TABEAN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONDITION_TABEAN
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_CONDITION_TABEANs.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_CONDITION_TABEANs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_CONDITION_TABEANs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_DOC_PDF
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_DOC_PDF

        Private _Details As New List(Of XML_DRUG_DOC_PDF)
        Public Property Details() As List(Of XML_DRUG_DOC_PDF)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_DOC_PDF))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_DOC_PDF
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_DOC_PDFs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_DOC_PDFs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_DOC_PDFs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_DOC_PDF.Add(fields)
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_DOC_PDFs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_DOC_PDFs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_SPC
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_SPC

        Private _Details As New List(Of XML_DRUG_SPC)
        Public Property Details() As List(Of XML_DRUG_SPC)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_SPC))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_SPC
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_SPCs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_SPCs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_SPCs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_SPC.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_SPCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_SPCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_PI
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_PI

        Private _Details As New List(Of XML_DRUG_PI)
        Public Property Details() As List(Of XML_DRUG_PI)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_PI))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_PI
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_PIs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_PIs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_PIs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_PI.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_PIs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_PIs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_PIL
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_PIL

        Private _Details As New List(Of XML_DRUG_PIL)
        Public Property Details() As List(Of XML_DRUG_PIL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_PIL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_PIL
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_PILs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_PILs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_PILs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_PIL.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_PILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_PILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_SOURCE_OF_RM
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_SOURCE_OF_RM

        Private _Details As New List(Of XML_DRUG_SOURCE_OF_RM)
        Public Property Details() As List(Of XML_DRUG_SOURCE_OF_RM)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_SOURCE_OF_RM))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_SOURCE_OF_RM
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_SOURCE_OF_RM.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_SOURCE_OF_RMs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_SOURCE_OF_RMs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_CODE
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_CODE

        Private _Details As New List(Of XML_DRUG_CODE)
        Public Property Details() As List(Of XML_DRUG_CODE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CODE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CODE
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_CODEs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CODEs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CODEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_CODE.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_CODEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_CODEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTAIN
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_CONTAIN

        Private _Details As New List(Of XML_DRUG_CONTAIN)
        Public Property Details() As List(Of XML_DRUG_CONTAIN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTAIN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTAIN
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_CONTAINs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONTAINs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONTAINs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_CONTAIN.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_CONTAINs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_CONTAINs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTROL_ANALYZE
        Inherits MAIN_CONTEXT

        Public fields As New XML_DRUG_CONTROL_ANALYZE

        Private _Details As New List(Of XML_DRUG_CONTROL_ANALYZE)
        Public Property Details() As List(Of XML_DRUG_CONTROL_ANALYZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTROL_ANALYZE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTROL_ANALYZE
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.XML_DRUG_CONTROL_ANALYZE.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.XML_DRUG_CONTROL_ANALYZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.XML_DRUG_CONTROL_ANALYZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_tb_log_temp
        Inherits MAIN_CONTEXT

        Public fields As New tb_log_temp

        Private _Details As New List(Of tb_log_temp)
        Public Property Details() As List(Of tb_log_temp)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of tb_log_temp))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New tb_log_temp
        End Sub

        Public Sub GETDATA_ALL()
            datas = (From p In db.tb_log_temps Select p)
            For Each Me.fields In datas
                'AddDetails()
            Next
        End Sub
        'Public Sub insert()
        '    db.tb_log_temp.Add(fields)
        '    db.SaveChanges()
        'End Sub
        'Public Sub DELETE()
        '    fields = Details(0)
        '    db.Entry(fields).State = Entity.EntityState.Deleted
        '    db.SaveChanges()
        'End Sub
        Public Sub insert()
            db.tb_log_temps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub DELETE()
            'fields = Details(0)
            db.tb_log_temps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Update()
            'db.Entry(fields).State = Entity.EntityState.Modified 'ใน DB กับในฟิลด์มีอะไรตรงกันมั้ย
            db.SubmitChanges()
        End Sub


        Public Sub UpdateALL()
            'db.Entry(Details).State = Entity.EntityState.Modified
            db.SubmitChanges()
        End Sub
    End Class

End Namespace