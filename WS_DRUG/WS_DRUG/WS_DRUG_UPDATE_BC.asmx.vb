Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_DRUG_UPDATE_BC
    Inherits System.Web.Services.WebService
    ''' <summary>
    ''' อัพเดทpvnabbr
    ''' </summary>
    ''' <param name="Newcode"></param>
    ''' <returns></returns>
    <WebMethod(Description:="XML_DRUG_BC_UPDATE_TB_CUT")>
    Public Function XML_DRUG_BC_UPDATE_TB_CUT(ByVal Newcode As String) As String

        'เอกส่ง Newcode_U มาเอาไปดึง xml จาก BC พี่บิ๊ก
        'เอา xml มาอ่านค่าและอัพเดทในตาราง PRODUCT GROUP
        'ตารางหลักupdate ทับค่าเดิม
        'ตาราง detail ลบใน stoก่อนแล้ว insert ใหม่
        'ลบทุกแถวยกเว้นแถวที่ 1 แล้วเข้าsto เอา TB หลัก join กับ TB ผู้ผลิตตปท 
        'insert ลงตารางหลัก
        Dim msg As String = ""
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim cls_xml As New Cls_XML
        Dim p2 As New LGT_IOW_E
        Dim bao As New BAO.BAO
        Dim dao_log As New DAO_DRUG_ESUB.TB_tb_log_temp
        Try


            Dim xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(Newcode)
            p2 = ConvertFromXml(Of LGT_IOW_E)(xml_str)
            Dim dao_pro_drug As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
            Dim pvncd_h As String = p2.XML_SEARCH_DRUG_DR.pvncd
            Dim rgttpcd_h As String = p2.XML_SEARCH_DRUG_DR.rgttpcd
            Dim drgtpcd_h As String = p2.XML_SEARCH_DRUG_DR.drgtpcd
            Dim rgtno_h As String = p2.XML_SEARCH_DRUG_DR.rgtno
            Dim lcnno_h As String = p2.XML_SEARCH_DRUG_DR.lcnno


            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = drgtpcd_h
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "START WS_DRUG"
            dao_log.fields.pvncd = pvncd_h
            dao_log.fields.rgtno = rgtno_h
            dao_log.fields.rgttpcd = rgttpcd_h
            dao_log.fields.lcnno = lcnno_h
            dao_log.fields.groupname = "DR"
            dao_log.insert()


            bao.SP_UPDATE_DRUG_GROUP_ESUB(pvncd_h, rgttpcd_h, drgtpcd_h, rgtno_h) 'ลบตารางหลัก
            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS_DRUG_DELETE_TBXML_SEARCH_PRODUCT_GROUP_SUCCESS"
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()



            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS_DRUG_INSERT_TBXML_SEARCH_PRODUCT_GROUP_SUCCESS"
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()

            'dao_pro_drug.GETDATA_BY_Newcode_U(Newcode)
            bao.SP_UPDATE_DRUG_ESUB(Newcode)  'ลบตารางdetail    'คือNewcode_U



            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS_DRUG_DELETE_TB_DETAIL_SUCCESS"
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()

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

            For Each STO In p2.LGT_XML_DRUG_COLOR
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_COLOR
                dao_drug.fields = STO.XML_DRUG_COLOR
                dao_drug.insert()
            Next

            For Each STO In p2.LGT_XML_DRUG_CONDITION_TABEAN
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONDITION_TABEAN
                dao_drug.fields = STO.XML_DRUG_CONDITION_TABEAN
                dao_drug.insert()
            Next


            For Each STO In p2.LGT_XML_DRUG_CONTAIN
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONTAIN
                dao_drug.fields = STO.XML_DRUG_CONTAIN
                dao_drug.insert()
            Next

            For Each STO In p2.LGT_XML_DRUG_CONTROL_ANALYZE
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_CONTROL_ANALYZE
                dao_drug.fields = STO.XML_DRUG_CONTROL_ANALYZE
                dao_drug.insert()
            Next

            For Each STO In p2.LGT_XML_DRUG_EXPORT
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_EXPORT
                dao_drug.fields = STO.XML_DRUG_EXPORT
                dao_drug.insert()
            Next


            If p2.LGT_XML_FRGN_ALL_TO.Count = 0 Then
                dao_pro_drug = New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP
                dao_pro_drug.fields = p2.XML_SEARCH_DRUG_DR
                dao_pro_drug.insert()


                'Dim dao_pro_drug_bk As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63
                'dao_pro_drug_bk.GETDATA_BY_Newcode(p2.XML_SEARCH_DRUG_DR.Newcode_U)
                'dao_pro_drug.fields.thakindnm = dao_pro_drug_bk.fields.thakindnm
                'dao_pro_drug.fields.engkindnm = dao_pro_drug_bk.fields.engkindnm
                'dao_pro_drug.fields.pvnabbr = dao_pro_drug_bk.fields.pvnabbr
                'dao_pro_drug.fields.lcntpcd = dao_pro_drug_bk.fields.lcntpcd
                'dao_pro_drug.fields.lcnno = dao_pro_drug_bk.fields.lcnno
                'dao_pro_drug.fields.licen_loca = dao_pro_drug_bk.fields.licen_loca
                'dao_pro_drug.Update()

            Else
                For Each STO In p2.LGT_XML_FRGN_ALL_TO
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


                    'Dim dao_pro_drug_bk As New DAO_DRUG_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB_BK12_2_63
                    'dao_pro_drug_bk.GETDATA_BY_Newcode(p2.XML_SEARCH_DRUG_DR.Newcode_U)
                    'dao_pro_drug.fields.thakindnm = dao_pro_drug_bk.fields.thakindnm
                    'dao_pro_drug.fields.engkindnm = dao_pro_drug_bk.fields.engkindnm
                    'dao_pro_drug.fields.pvnabbr = dao_pro_drug_bk.fields.pvnabbr
                    'dao_pro_drug.fields.lcntpcd = dao_pro_drug_bk.fields.lcntpcd
                    'dao_pro_drug.fields.lcnno = dao_pro_drug_bk.fields.lcnno
                    'dao_pro_drug.fields.licen_loca = dao_pro_drug_bk.fields.licen_loca
                    'dao_pro_drug.Update()

                Next

            End If



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

            For Each STO In p2.LGT_RECIPE_GROUP_TO
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_RECIPE_GROUP
                dao_drug.fields = STO.XML_DRUG_RECIPE_GROUP
                dao_drug.insert()
            Next


            For Each STO In p2.LGT_XML_DRUG_STORY_EDIT_HISTORY
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_STORY_EDIT_HISTORY
                dao_drug.fields = STO.XML_DRUG_STORY_EDIT_HISTORY
                dao_drug.insert()
            Next


            For Each STO In p2.LGT_XML_STOWAGR_TO
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_STOWAGR
                dao_drug.fields = STO.XML_DRUG_STOWAGR
                dao_drug.insert()
            Next


            For Each STO In p2.LGT_XML_DRUG_AGENT
                Dim dao_drug As New DAO_DRUG_ESUB.TB_XML_DRUG_AGENT
                dao_drug.fields = STO.XML_DRUG_AGENT
                dao_drug.insert()
            Next

            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS_DRUG_INSERT_TB_DETAIL_SUCCESS"
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()

            Dim pvncd As String = dao_pro_drug.fields.pvncd
            Dim drgtpcd As String = dao_pro_drug.fields.drgtpcd
            Dim rgttpcd As String = dao_pro_drug.fields.rgttpcd
            Dim rgtno As String = dao_pro_drug.fields.rgtno
            Dim lcnno As String = dao_pro_drug.fields.lcnno

            'bao.SP_PRODUCT_DRUG_MANAGE_INSERT(pvncd, drgtpcd, rgttpcd, rgtno, lcnno)  'ลบผู้ผลิตต่างประเทศแถวที่ไม่ใช่แถวที่ 1 แล้วเพิ่มแถวอื่นลงไป

            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = "WS_DRUG_INSERT_TB_DETAIL_FRGN_SUCCESS"
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()


            msg = "COMPLETE"
        Catch ex As Exception
            dao_log = New DAO_DRUG_ESUB.TB_tb_log_temp
            dao_log.fields.drgtpcd = p2.XML_SEARCH_DRUG_DR.drgtpcd
            dao_log.fields.log_date = Date.Now
            dao_log.fields.log_des = ex.Message
            dao_log.fields.pvncd = p2.XML_SEARCH_DRUG_DR.pvncd
            dao_log.fields.rgtno = p2.XML_SEARCH_DRUG_DR.rgtno
            dao_log.fields.rgttpcd = p2.XML_SEARCH_DRUG_DR.rgttpcd
            dao_log.fields.lcnno = p2.XML_SEARCH_DRUG_DR.lcnno
            dao_log.fields.groupname = "DR"
            dao_log.insert()
            msg = "ERROR"
        End Try
        Return msg
    End Function

End Class