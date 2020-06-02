Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WS_DRUG
    Inherits System.Web.Services.WebService
    Dim des As String = ""
    Dim p2 As New LGT_IOW_E
    Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
#Region "XML_DRUG_BC_UPDATE_TB'ทำให้พี่xและนนใช้(ใช้ปัจจุบัน27-5-63)"
    <SoapDocumentMethod(OneWay:=True),
    WebMethod(Description:="XML_DRUG_BC_UPDATE_TB")>
    Public Sub XML_DRUG_BC_UPDATE_TB(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
        'เอกส่ง Newcode_U มาเอาไปดึง xml จาก BC พี่บิ๊ก
        'เอา xml มาอ่านค่าและอัพเดทในตาราง PRODUCT GROUP
        'ตารางหลักupdate ทับค่าเดิม
        'ตาราง detail ลบใน stoก่อนแล้ว insert ใหม่
        'ลบทุกแถวยกเว้นแถวที่ 1 แล้วเข้าsto เอา TB หลัก join กับ TB ผู้ผลิตตปท 
        'insert ลงตารางหลัก
        Dim msg As String = ""
        Dim cls_xml As New Cls_XML
        Dim bao As New BAO.BAO
        Try

            des = "START FC:XML_DRUG_BC_UPDATE_TB"
            des_log(Newcode, IDENTIFY_EDIT, des, "")
            Dim xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(Newcode)
            p2 = ConvertFromXml(Of LGT_IOW_E)(xml_str)   'ดึงไฟล์xml จาก BC
            Dim dao_pro_drug As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
            Dim pvncd_h As String = p2.XML_SEARCH_DRUG_DR.pvncd
            Dim rgttpcd_h As String = p2.XML_SEARCH_DRUG_DR.rgttpcd
            Dim drgtpcd_h As String = p2.XML_SEARCH_DRUG_DR.drgtpcd
            Dim rgtno_h As String = p2.XML_SEARCH_DRUG_DR.rgtno
            Dim lcnno_h As String = p2.XML_SEARCH_DRUG_DR.lcnno

            'ลบตารางหลักกับ ตาราง detail
            des = "START FC:XML_DRUG_BC_UPDATE_TB : ดึงไฟล์xml จาก BC"
            bao.SP_UPDATE_DRUG_GROUP_ESUB(pvncd_h, rgttpcd_h, drgtpcd_h, rgtno_h) 'ลบตารางหลัก
            des = "START FC:XML_DRUG_BC_UPDATE_TB : DELETE_PRODUCT_GROUP_SUCCESS"
            dao_pro_drug.GETDATA_BY_Newcode_U(Newcode)
            bao.SP_UPDATE_DRUG_ESUB(Newcode)  'ลบตารางdetail    'คือNewcode_U
            des = "START FC:XML_DRUG_BC_UPDATE_TB : DELETE_TB_DETAIL_SUCCESS"
            'ลบตารางหลักกับ ตาราง detail


            DRUG_ANIMAL(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_ANIMAL_SUCCESS"
            DRUG_COLOR(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_COLOR_SUCCESS"
            DRUG_CONDITION_TABEAN(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_DRUG_CONDITION_TABEAN_SUCCESS"
            DRUG_CONTAIN(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_CONTAIN_SUCCESS"
            DRUG_CONTROL_ANALYZE(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_CONTROL_ANALYZE_SUCCESS"
            DRUG_EXPORT(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_EXPORT_SUCCESS"

            'ผู้ผลิตต่างประเทศกับตารางหลักทะเบียน
            If p2.LGT_XML_FRGN_ALL_TO.Count = 0 Then  'ถ้าไม่มีผู้ผลิตต่างประเทศสักเดียว ให้เพิ่มทุกแถวตามจำนวนแท๊กใน xml 
                dao_pro_drug = New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
                dao_pro_drug.fields = p2.XML_SEARCH_DRUG_DR
                dao_pro_drug.insert()

                des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_SEARCH_PRODUCT_GROUP_SUCCESS1"
            Else
                For Each STO In p2.LGT_XML_FRGN_ALL_TO  'ถ้ามีผู้ผลิตต่างต่างประเทศแล้ว ให้เพิ่ม ทุกแถวยกเว้นแถวที่ frn_no =  1
                    dao_pro_drug = New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
                    dao_pro_drug.fields = p2.XML_SEARCH_DRUG_DR  'เอา xml insert ลงtb
                    dao_pro_drug.fields.funcnm = STO.XML_DRUG_FRGN.funcnm
                    dao_pro_drug.fields.frn_no = STO.XML_DRUG_FRGN.rid
                    dao_pro_drug.fields.engfrgnnm = STO.XML_DRUG_FRGN.engfrgnnm
                    dao_pro_drug.fields.engfrgnnm_addr = STO.XML_DRUG_FRGN.engfrgnnm_all
                    dao_pro_drug.fields.Newcode = dao_pro_drug.fields.Newcode.Substring(0, dao_pro_drug.fields.Newcode.Length - 2) & STO.XML_DRUG_FRGN.rid & "C"
                    dao_pro_drug.insert()
                    Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_FRGN
                    dao_drug.fields = STO.XML_DRUG_FRGN
                    dao_drug.insert()
                Next

                des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_SEARCH_PRODUCT_GROUP_SUCCESS2"

            End If
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_FRGN_SUCCESS"
            'ผู้ผลิตต่างประเทศกับตารางหลักทะเบียน


            DRUG_IOW_TYPE(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_IOW_SUCCESS"
            DRUG_RECIPE_GROUP(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_RECIPE_GROUP_SUCCESS"
            DRUG_STORY_EDIT_HISTORY(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_STORY_EDIT_HISTORY_SUCCESS"
            DRUG_STOWAGR(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_STOWAGR_SUCCESS"
            DRUG_AGENT(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_AGENT_SUCCESS"

            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_INSERT_TB_DETAIL_SUCCESS"
            des_log(Newcode, IDENTIFY_EDIT, des, "")
        Catch ex As Exception
            Dim title As String
            Dim Content As String
            title = "ERROR อัพเดททะเบียนยา " & Newcode
            des_log(Newcode, IDENTIFY_EDIT, des, ex.Message)
            Content = Newcode & " : " & des

            'SendMail(Content, "therdsak.b@fsa.co.th", title) 'พี่ x
            'SendMail(Content, "puwadol.t@fsa.co.th", title) 'พี่บิ๊ก
            'SendMail(Content, "supaporn.s@fsa.co.th", title) 'ทราย
            'SendMail(Content, "koeza2009@gmail.com", title) 'ก้อ
            'SendMail(Content, "amornsak.y@fsa.co.th", title) 'นน
            'SendMail(Content, "moszazeed9@gmail.com", title) 'มอส
            msg = "ERROR"



            des = "START FC:XML_DRUG_BC_UPDATE_TB"
            des_log(Newcode, IDENTIFY_EDIT, des, "")
            Dim xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(Newcode)
            p2 = ConvertFromXml(Of LGT_IOW_E)(xml_str)   'ดึงไฟล์xml จาก BC
            Dim dao_pro_drug As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
            Dim pvncd_h As String = p2.XML_SEARCH_DRUG_DR.pvncd
            Dim rgttpcd_h As String = p2.XML_SEARCH_DRUG_DR.rgttpcd
            Dim drgtpcd_h As String = p2.XML_SEARCH_DRUG_DR.drgtpcd
            Dim rgtno_h As String = p2.XML_SEARCH_DRUG_DR.rgtno
            Dim lcnno_h As String = p2.XML_SEARCH_DRUG_DR.lcnno

            des = "START FC:XML_DRUG_BC_UPDATE_TB : ดึงไฟล์xml จาก BC"

            'ลบตารางหลักกับ ตาราง detail
            des = "START FC:XML_DRUG_BC_UPDATE_TB : ดึงไฟล์xml จาก BC"
            bao.SP_UPDATE_DRUG_GROUP_ESUB(pvncd_h, rgttpcd_h, drgtpcd_h, rgtno_h) 'ลบตารางหลัก
            des = "START FC:XML_DRUG_BC_UPDATE_TB : DELETE_PRODUCT_GROUP_SUCCESS"
            dao_pro_drug.GETDATA_BY_Newcode_U(Newcode)
            bao.SP_UPDATE_DRUG_ESUB(Newcode)  'ลบตารางdetail    'คือNewcode_U
            des = "START FC:XML_DRUG_BC_UPDATE_TB : DELETE_TB_DETAIL_SUCCESS"
            'ลบตารางหลักกับ ตาราง detail


            DRUG_ANIMAL(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_ANIMAL_SUCCESS"
            DRUG_COLOR(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_COLOR_SUCCESS"
            DRUG_CONDITION_TABEAN(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_DRUG_CONDITION_TABEAN_SUCCESS"
            DRUG_CONTAIN(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_CONTAIN_SUCCESS"
            DRUG_CONTROL_ANALYZE(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_CONTROL_ANALYZE_SUCCESS"
            DRUG_EXPORT(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_EXPORT_SUCCESS"

            'ผู้ผลิตต่างประเทศกับตารางหลักทะเบียน
            If p2.LGT_XML_FRGN_ALL_TO.Count = 0 Then  'ถ้าไม่มีผู้ผลิตต่างประเทศสักเดียว ให้เพิ่มทุกแถวตามจำนวนแท๊กใน xml 
                dao_pro_drug = New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
                dao_pro_drug.fields = p2.XML_SEARCH_DRUG_DR
                dao_pro_drug.insert()

                des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_SEARCH_PRODUCT_GROUP_SUCCESS1"
            Else
                For Each STO In p2.LGT_XML_FRGN_ALL_TO  'ถ้ามีผู้ผลิตต่างต่างประเทศแล้ว ให้เพิ่ม ทุกแถวยกเว้นแถวที่ frn_no =  1
                    dao_pro_drug = New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
                    dao_pro_drug.fields = p2.XML_SEARCH_DRUG_DR  'เอา xml insert ลงtb
                    dao_pro_drug.fields.funcnm = STO.XML_DRUG_FRGN.funcnm
                    dao_pro_drug.fields.frn_no = STO.XML_DRUG_FRGN.rid
                    dao_pro_drug.fields.engfrgnnm = STO.XML_DRUG_FRGN.engfrgnnm
                    dao_pro_drug.fields.engfrgnnm_addr = STO.XML_DRUG_FRGN.engfrgnnm_all
                    dao_pro_drug.fields.Newcode = dao_pro_drug.fields.Newcode.Substring(0, dao_pro_drug.fields.Newcode.Length - 2) & STO.XML_DRUG_FRGN.rid & "C"
                    dao_pro_drug.insert()
                    Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_FRGN
                    dao_drug.fields = STO.XML_DRUG_FRGN
                    dao_drug.insert()
                Next

                des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_SEARCH_PRODUCT_GROUP_SUCCESS2"

            End If
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_FRGN_SUCCESS"
            'ผู้ผลิตต่างประเทศกับตารางหลักทะเบียน


            DRUG_IOW_TYPE(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_IOW_SUCCESS"
            DRUG_RECIPE_GROUP(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_RECIPE_GROUP_SUCCESS"
            DRUG_STORY_EDIT_HISTORY(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_STORY_EDIT_HISTORY_SUCCESS"
            DRUG_STOWAGR(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_STOWAGR_SUCCESS"
            DRUG_AGENT(p2)
            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_XML_DRUG_AGENT_SUCCESS"

            des = "START FC:XML_DRUG_BC_UPDATE_TB : INSERT_INSERT_TB_DETAIL_SUCCESS"
            des_log(Newcode, IDENTIFY_EDIT, des, "")
        End Try

    End Sub
    Function DRUG_ANIMAL(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_ANIMAL_DRUGS_TO
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_ANIMAL
            dao_drug.fields = STO.XML_DRUG_ANIMAL
            dao_drug.insert()
            For Each STO_TO In STO.LGT_ANIMAL_CONSUME_DRUGS_TO
                Dim dao_eq_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_ANIMAL_CONSUME
                dao_eq_drug.fields = STO_TO.XML_DRUG_ANIMAL_CONSUME
                dao_eq_drug.insert()
            Next
        Next
        Return "ANIMAL"
    End Function
    Function DRUG_COLOR(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_COLOR
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_COLOR
            dao_drug.fields = STO.XML_DRUG_COLOR
            dao_drug.insert()
        Next
        Return "COLOR"
    End Function
    Function DRUG_CONDITION_TABEAN(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_CONDITION_TABEAN
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONDITION_TABEAN
            dao_drug.fields = STO.XML_DRUG_CONDITION_TABEAN
            dao_drug.insert()
        Next
        Return "CONDITION_TABEAN"
    End Function
    Function DRUG_CONTAIN(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_CONTAIN
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONTAIN
            dao_drug.fields = STO.XML_DRUG_CONTAIN
            dao_drug.insert()
        Next
        Return "CONTAIN"
    End Function
    Function DRUG_CONTROL_ANALYZE(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_CONTROL_ANALYZE
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONTROL_ANALYZE
            dao_drug.fields = STO.XML_DRUG_CONTROL_ANALYZE
            dao_drug.insert()
        Next
        Return "CONTROL_ANALYZE"
    End Function
    Function DRUG_EXPORT(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_EXPORT
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_EXPORT
            dao_drug.fields = STO.XML_DRUG_EXPORT
            dao_drug.insert()
        Next
        Return "EXPORT"
    End Function
    Function DRUG_IOW_TYPE(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_IOW_EQ.XML_DRUG_IOW_TYPE
            For Each STO_TO In STO.XML_DRUG_IOW_TO
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_IOW
                dao_drug.fields = STO_TO.XML_DRUG_IOW
                dao_drug.insert()
                For Each STO_EQ In STO_TO.LGT_IOW_EQ_TO
                    Dim dao_eq_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_IOW_EQ
                    dao_eq_drug.fields = STO_EQ.XML_DRUG_IOW_EQ
                    dao_eq_drug.insert()
                Next
            Next
        Next
        Return "IOW_TYPE"
    End Function
    Function DRUG_RECIPE_GROUP(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_RECIPE_GROUP_TO
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_RECIPE_GROUP
            dao_drug.fields = STO.XML_DRUG_RECIPE_GROUP
            dao_drug.insert()
        Next
        Return "RECIPE_GROUP"
    End Function
    Function DRUG_STORY_EDIT_HISTORY(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_STORY_EDIT_HISTORY
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_STORY_EDIT_HISTORY
            dao_drug.fields = STO.XML_DRUG_STORY_EDIT_HISTORY
            dao_drug.insert()
        Next
        Return "STORY_EDIT_HISTORY"
    End Function
    Function DRUG_STOWAGR(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_STOWAGR_TO
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_STOWAGR
            dao_drug.fields = STO.XML_DRUG_STOWAGR
            dao_drug.insert()
        Next
        Return "STOWAGR"
    End Function
    Function DRUG_AGENT(ByVal p2 As LGT_IOW_E)
        For Each STO In p2.LGT_XML_DRUG_AGENT
            Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_AGENT
            dao_drug.fields = STO.XML_DRUG_AGENT
            dao_drug.insert()
        Next
        Return "AGENT"
    End Function
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String)
        Dim mm As New WS_MAIL.FDA_MAIL
        Dim mcontent As New WS_MAIL.Fields_Mail
        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email
        mm.SendMail(mcontent)
    End Sub
    Private Sub des_log(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String, ByVal des As String, ByVal remark As String)
        Dim dao_log As New DAO_DRUG_ESUB.TB_tb_log_temp
        dao_log.fields.log_des = des  'รายละเอียดแต่ละขั้นตอน
        dao_log.fields.IDENTIFY_EDIT = IDENTIFY_EDIT  'เลขจากใครที่แก้ไข
        dao_log.fields.log_date = Date.Now  'เข้ามาเมื่อไร
        dao_log.fields.Newcode = Newcode
        dao_log.fields.remark = remark  'แก้ไขอะไร
        dao_log.fields.groupname = "DR"
        dao_log.insert()
    End Sub
#End Region
#Region "XML_DRUG_MERGE_UPDATE'ทำให้พี่xและนนใช้(เลิกใช้แล้ว)"

    <WebMethod(Description:="XML_DRUG_MERGE_UPDATE")>
    Public Function XML_DRUG_MERGE_UPDATE(ByVal pvncd As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal rgtno As String, ByVal identify_edit As String) As String
        'พี่x และนน ส่ง 4คีย์ มาอัพเดทตารางทราย
        'ส่งเลข U ไปสร้าง xml ลง BC 
        Dim dao_log As New DAO_DRUG_ESUB.TB_tb_log_temp
        dao_log.fields.drgtpcd = drgtpcd
        dao_log.fields.log_date = Date.Now
        dao_log.fields.log_des = "WS:พี่x&นน : Step1: เริ่มต้นการแก้ไข"
        dao_log.fields.pvncd = pvncd
        dao_log.fields.rgtno = rgtno
        dao_log.fields.rgttpcd = rgttpcd
        'dao_log.fields.lcnno = lcnno
        dao_log.fields.groupname = "DR"
        dao_log.insert()


        Try
            Dim str_retrun As String
            Dim ws As New DRUG_INSERT_DR.WS_DRUG
            str_retrun = ws.DRUG_UPDATE_DR(pvncd, rgttpcd, drgtpcd, rgtno)  'ส่งเลขมาอัพเดทที่ตารางทราย และสร้าง xmlที่โฟเดอร์ทราย
            'log

            'log
            Dim dao As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
            dao.GETDATA_BY_4key(pvncd, rgttpcd, drgtpcd, rgtno)    'where เพื่อได้ Newcode_U
            update_block(dao.fields.Newcode_U, identify_edit) 'identify_edit คือเลขบัตรของผู้ที่แก้ไขข้อมูล  
            'log
            dao_log.fields.drgtpcd = drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS:พี่x&นน : Step2: สร้าง xmlลง BC สำเร็จ"
            dao_log.fields.pvncd = pvncd
            dao_log.fields.rgtno = rgtno
            dao_log.fields.rgttpcd = rgttpcd
            'dao_log.fields.lcnno = lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()
            'log
        Catch ex As Exception

        End Try
    End Function
    ''' <summary>
    ''' สร้าง xml ลง BC 
    ''' </summary>
    ''' <param name="Newcode_U"></param>
    ''' <param name="citizen"></param>
    ''' <returns></returns>
    Public Function update_block(ByVal Newcode_U As String, ByVal identify_edit As String)
        Dim alert As String
        Dim log As New DAO_LOG.TB_TESTANGULAR_LOG  'ตารางเก็บ log ว่ามีเลข U ไหนบ้างที่สร้างไปแล้ว
        'Dim dao As New DAO_XML_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
        'dao.GETDATABY_LCT(pvncd, drgtpcd, rgttpcd, rgtno)
        Try
            'Dim ws_xml1 As New XML_DRUG_FORMULA.WS_INSERT_XML_DRUG
            Dim model As New MODEL_APP
            Dim ws As New WS_DRUGG.WS_DRUG
            model.Newcode = Newcode_U
            'ws_xml1.XML_DRUG_FORMULA(Newcode_U) 'สร้าง xml 
            Dim xml_str = ws.XML_GET_DRUG_ESUB("DRUG", "XML_PRODUCT", Newcode_U) 'ดึงเอาไฟล์ xmlที่สร้างมา
            model.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str) 'เอาไฟล์ xml ไปแปลง เป็น DB 64
            model.citizen_authorize = identify_edit
            model.STATUS_ID = 8
            model.REMARK = "อัพเดทด้วยระบบ"
            model.process_id = "3181"
            model.TR_ID = Newcode_U
            Dim common As New common
            common.SEND_XML(model)
            alert = "SUCCESS"
        Catch ex As Exception
            log.fields.REMARK = ex.ToString
            log.fields.TIME = Date.Now
            log.fields.STATUS_ID = 99
            log.fields.TR_ID = Newcode_U
            log.fields.PROCESS_ID = "00000"
            log.insert()
            alert = "FAIL"
        End Try
        Return alert
    End Function
    Function ConvermXmlstr_TO_CLASS(Of T As Class)(ByRef str As String)
        Dim c As T = Nothing
        Try
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Dim reader As StringReader = New StringReader(str)
            c = TryCast(serializer.Deserialize(reader), T)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return c

    End Function
#End Region
End Class