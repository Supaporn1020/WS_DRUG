Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Public Class common
    Public Function DataTableToJSON(ByVal table As DataTable) As Object
        Dim list = New List(Of Dictionary(Of String, Object))()

        For Each row As DataRow In table.Rows
            Dim dict = New Dictionary(Of String, Object)()

            For Each col As DataColumn In table.Columns
                dict(col.ColumnName) = (Convert.ToString(row(col)))
            Next

            list.Add(dict)
        Next

        Return list
        'Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        'Return serializer.Serialize(list)
    End Function
    Public Function CLASSTOXMLSTR(ByVal cls_rev As Object) 'เอา class มารับ class ที่ส่งเข้ามา
        Dim x2 As New XmlSerializer(cls_rev.GetType())
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim mem2 As New MemoryStream()
        Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
            x2.Serialize(writer, cls_rev)
            writer.Flush()
            writer.Close()
        End Using
        Dim B64 As String = ""
        B64 = Convert.ToBase64String(mem2.GetBuffer())
        Return B64
    End Function
    Public Sub SEND_XML(ByVal model As MODEL_APP)
        Dim dao As New DAO_LOG.TB_TESTANGULAR_LOG
        dao.fields.STATUS_ID = 8
        dao.fields.PROCESS_ID = CInt(model.process_id)
        dao.fields.TR_ID = model.TR_ID
        dao.fields.TIME = Date.Now
        Try
            Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
            Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
            ws_fields.PROCESS_ID = model.process_id 'เลขกระบวนการ
            ws_fields.TR_ID = model.TR_ID 'เลขTRANSATION
            ws_fields.REF_TR_ID = model.LGT_IOW_E.XML_SEARCH_DRUG_DR.Newcode_U 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
            ws_fields.IDENTIFY = model.citizen_authorize 'เลขนิติบุคคล
            ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
            ws_fields.SOP_STATUS = model.STATUS_ID 'สถานะคำขอนะ
            ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
            ws_fields.SOP_REMARK = model.REMARK 'ความเห็น จนทที่พิมพ์มา
            ws_fields.XML_DATA = CLASSTOXMLSTR(model.LGT_IOW_E) 'classxml ข้อมูล
            ws_blockchain.WS_BLOCK_CHAIN_V3(ws_fields)
            dao.fields.REMARK = "ส่งxmlไปเก็บที่svสำเร็จ"
        Catch ex As Exception
            dao.fields.REMARK = ex.ToString
        End Try
        dao.insert()
    End Sub

    'Public Function convert_Database_To_XML(ByVal MODEL As MODEL_APP)
    '    Dim bao_show As New BAO_SHOW
    '    Dim dao_lcn As New DAO_DRUG_T.TB_dalcn
    '    dao_lcn.GetDataby_IDA(MODEL.IDA)
    '    Dim cls_xml As New CLASS_EXTEND                                                                     ' ประกาศตัวแปรจาก CLASS_DALCN 
    '    cls_xml = gen_xml(MODEL)                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
    '    Dim lct_ida As Integer = 0

    '    Dim newyear As Integer = 0
    '    Dim year_present As Integer = 0
    '    Dim montn_present As Integer = 0
    '    year_present = Year(Date.Now)
    '    montn_present = Month(Date.Now)
    '    If montn_present = 1 Then
    '        newyear = year_present
    '    Else
    '        newyear = year_present + 1
    '    End If
    '    cls_xml.EXP_NEWYEAR = newyear 'ต่ออายุใบอนุญาติ
    '    cls_xml.dalcns_new = dao_lcn.fields

    '    cls_xml.DT_SHOW.DT9 = bao_show.SP_DOWNDATA_EXTENDPDF_by_IDA(MODEL.IDA) 'ข้อมูลสถานที่จำลอง


    '    'ขย15
    '    If dao_lcn.fields.lcntpcd = "ขย1" Then
    '        cls_xml.CHK_TYPE = 1
    '        cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
    '    ElseIf dao_lcn.fields.lcntpcd = "ขย2" Then
    '        cls_xml.CHK_TYPE = 3
    '        cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
    '    ElseIf dao_lcn.fields.lcntpcd = "ขย3" Then
    '        cls_xml.CHK_TYPE = 4
    '        cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
    '    ElseIf dao_lcn.fields.lcntpcd = "ขย4" Then
    '        cls_xml.CHK_TYPE = 2
    '        cls_xml.CHK_NAME = "ขายส่งยาแผนปัจจุบันฯ"

    '        'ยบ13
    '    ElseIf dao_lcn.fields.lcntpcd = "ผยบ" Then
    '        cls_xml.CHK_TYPE = 1
    '    ElseIf dao_lcn.fields.lcntpcd = "นยบ" Then
    '        cls_xml.CHK_TYPE = 3
    '    ElseIf dao_lcn.fields.lcntpcd = "ขยบ" Then
    '        cls_xml.CHK_TYPE = 2
    '    End If
    '    Dim path = "C:/"
    '    Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
    '    Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
    '    x.Serialize(objStreamWriter, cls_xml)
    '    objStreamWriter.Close()
    '    Return path
    'End Function
    'Public Function gen_xml(ByVal model As MODEL_APP) As CLASS_EXTEND
    '    Dim class_xml As New CLASS_EXTEND
    '    Dim dao_dalcn As New DAO_DRUG_T.TB_dalcn
    '    dao_dalcn.GetDataby_IDA(model.IDA)
    '    Dim dao_lcnrequest As New DAO_DRUG_T.TB_LCN_EXTEND_LITE
    '    'dao_lcnrequest.GetDataby_IDA(dao_dalcn.fields.IDA)
    '    'dao_dalcn.fields.IDA = dao_lcnrequest.fields.FK_IDA
    '    'dao_lcnrequest.fields.IDA = 


    '    'Intial Default Value
    '    class_xml.dalcns = AddValue(class_xml.dalcns)
    '    'class_xml.dalcns.pvncd = _PVNC
    '    class_xml.dalcns.lcnsid = dao_dalcn.fields.lcnsid
    '    class_xml.dalcns.rcvno = 0
    '    'class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
    '    'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1

    '    '_______________SHOW___________________
    '    Dim bao_show As New BAO_SHOW
    '    class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(model.IDA) 'ข้อมูลสถานที่จำลอง
    '    class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao_dalcn.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
    '    class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(model.AUTHEN_INFORMATION.CITIZEN_ID_AUTHORIZE, dao_dalcn.fields.lcnsid) 'ข้อมูลบริษัท
    '    class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao_dalcn.fields.lcnsid) 'ที่เก็บ
    '    class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
    '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(model.IDA) 'ผู้ดำเนิน

    '    '_______________MASTER_________________
    '    Dim bao_master As New BAO_MASTER
    '    class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(model.IDA) 'ใบอนุญาตสถานที่
    '    Try
    '        'class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'ใบอนุญาตต่ออายุสถานที่
    '    Catch ex As Exception

    '    End Try

    '    ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
    '    class_xml.EXP_YEAR = ""
    '    class_xml.LCNNO_SHOW = ""
    '    class_xml.RCVDAY = ""
    '    class_xml.CHK_TYPE = ""
    '    class_xml.RCVMONTH = ""
    '    class_xml.RCVYEAR = ""
    '    'class_xml.SHOW_LCNNO = ""
    '    'class_xml.phr_medical_type = ""
    '    class_xml.dalcns.opentime = dao_dalcn.fields.opentime
    '    Return class_xml

    'End Function
End Class
