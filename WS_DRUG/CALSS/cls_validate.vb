'------------------------------------------------------------------------------------------
'                              CLASS VALIDATION V.1 (2013/09/20)                          
'-----------------------------------------Validate-----------------------------------------
'สร้าง Function CheckString                                                                 
'-------------------------------------Dropdown Control-------------------------------------
'สร้าง Function BindData                                                                    
'สร้าง Function DropDownInsertData                                                          
'สร้าง Function DropDownInsertDataFirstRow                                                  
'สร้าง Function DropDownInsertDataLastRow                                                   
'สร้าง Function DropDownRemoveData                                                          
'สร้าง Function DropDownSelectData
'สร้าง Function DropDownGetValue
'สร้าง Function DropDownGetText
'------------------------------------------Encode------------------------------------------
'สร้าง Function b64encode
'สร้าง Function b64decode
'-------------------------------------DataBase Control-------------------------------------
'สร้าง Function CopyToDataTable
'--------------------------------------Convert Control-------------------------------------
'สร้าง Function ToCsv
'สร้าง Function ToDecimal
'---------------------------------------Math Control---------------------------------------
'สร้าง Function RoundDouble_to_int
'สร้าง Function RoundUp
'สร้าง Function RoundDown
'--------------------------------------Script Control--------------------------------------
'สร้าง Function Alert
'สร้าง Function DateJava
'------------------------------------------------------------------------------------------

Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports System.Reflection
Imports System.Math
Imports System.Xml.Serialization

Public Module cls_validate
#Region "Validate"
    <System.Runtime.CompilerServices.Extension()>
    Public Sub CheckString(ByVal s As String)

    End Sub

    <System.Runtime.CompilerServices.Extension()>
    Public Function StringTodouble(ByVal s As String) As Double
        Dim d As Double = 0
        Try
            d = CDbl(s)
        Catch ex As Exception

        End Try
        Return d
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function CheckDate(ByVal S As String) As Object
        Dim d As Date = Nothing
        Try
            d = CDate(S)
        Catch ex As Exception
            Return Nothing
        End Try
        Return d
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function StringToDecimal(ByVal s As String) As Decimal
        Dim d As Decimal = 0
        Try
            d = CDec(s)
        Catch ex As Exception

        End Try
        Return d
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function StringformatMoney(ByVal s As Decimal) As String
        Dim d As String = "0.00"
        Try
            d = String.Format("{0:###,###.00}", s)
        Catch ex As Exception

        End Try
        Return d
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function StringformatMoney_double(ByVal s As Double) As String
        Dim d As String = "0.00"
        Try
            d = String.Format("{0:###,###.00}", s)
        Catch ex As Exception

        End Try
        Return d
    End Function
#End Region

#Region "Dropdown Control"
    ''' <summary>
    ''' แสดงข้อมูลลง Dropdown
    ''' </summary>
    ''' <param name="drop">DropdownList</param>
    ''' <param name="Dataname">ชื่อที่แสดงใน Dropdown</param>
    ''' <param name="ValueName">ชื่อค่าใน Dropdown</param>
    ''' <param name="DT">Datatable</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub BindData(ByRef drop As DropDownList, ByVal Dataname As String, ByVal ValueName As String, ByVal DT As DataTable)
        drop.DataValueField = ValueName
        drop.DataTextField = Dataname
        drop.DataSource = DT
    End Sub

    ''' <summary>
    ''' Insert ข้อมูลลง DropdownList
    ''' </summary>
    ''' <param name="Dropdown">DropdrowList</param>
    ''' <param name="Text">ชื่อ</param>
    ''' <param name="Value">ค่า</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownInsertData(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        ' Dropdown.DataBind()
        Dim i As Integer = 0
        If Dropdown.Items.Count > 0 Then
            i = Dropdown.Items.Count
        End If
        Dropdown.Items.Insert(i, New ListItem(Text, Value))
    End Sub

    ''' <summary>
    ''' Insert ข้อมูลแถวแรกลง DropdownList
    ''' </summary>
    ''' <param name="Dropdown">DropdrowList</param>
    ''' <param name="Text">ชื่อ</param>
    ''' <param name="Value">ค่า</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownInsertDataFirstRow(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        Dropdown.Items.Insert(0, New ListItem(Text, Value))
        Dropdown.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Insert ข้อมูลแถวสุดท้ายลง DropdownList
    ''' </summary>
    ''' <param name="Dropdown">DropdrowList</param>
    ''' <param name="Text">ชื่อ</param>
    ''' <param name="Value">ค่า</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownInsertDataLastRow(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        Dropdown.Items.Insert(Dropdown.Items.Count, New ListItem(Text, Value))
        Dropdown.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' ลบข้อมูลใน DropdownList
    ''' </summary>
    ''' <param name="DropDown">DropdownList</param>
    ''' <param name="Value">ค่า</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownRemoveData(ByRef DropDown As DropDownList, ByVal Value As Integer)
        'DropDown.DataBind()
        '    DropDown.Items.RemoveAt(Value)
        Dim i As Integer = 0
        For Each LT As ListItem In DropDown.Items
            If LT.Value = Value Then
                DropDown.Items.RemoveAt(i)
            End If
            i = i + 1
        Next
    End Sub

    ''' <summary>
    ''' เลือกข้อมูลใน DropdownList
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownSelectData(ByRef Dropdown As DropDownList, ByVal Value As String)

        For Each LT As ListItem In Dropdown.Items
            If LT.Value = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' เลือกข้อมูลใน DropdownList โดยใช้ Text
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <param name="Text"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DropDownSeleteData_ByText(ByRef Dropdown As DropDownList, ByVal Text As String)
        For Each LT As ListItem In Dropdown.Items
            If LT.Text = Text Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' ดึง value ของ Dropdown
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function DropDownGetValue(ByRef Dropdown As DropDownList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Value
                Exit For
            End If
        Next
        Return Value
    End Function

    ''' <summary>
    ''' ดึง Text ของ Dropdown
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function DropDownGetText(ByRef Dropdown As DropDownList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Text
                Exit For
            End If
        Next
        Return Value
    End Function



    ''' <summary>
    ''' ดึง Text ของ Dropdown
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function RadioGetText(ByRef Dropdown As RadioButtonList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Text
                Exit For
            End If
        Next
        Return Value
    End Function


    ''' <summary>
    ''' ดึง Value ของ Dropdown
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function RadioGetValue(ByRef Dropdown As RadioButtonList) As String
        Dim Value As String = ""
        For Each LT As ListItem In Dropdown.Items
            If LT.Selected = True Then
                Value = LT.Value
                Exit For
            End If
        Next
        Return Value
    End Function
#End Region

#Region "RadioButtonList Control"
    ''' <summary>
    ''' ดึงค่า RadioList
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub RadioListSelectData(ByRef radios As RadioButtonList, ByVal Value As String)

        For Each LT As ListItem In radios.Items
            If LT.Value = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub


    ''' <summary>
    ''' ดึงค่า RadioList
    ''' </summary>
    ''' <param name="Dropdown"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub CheckBox_SelectData(ByRef CHK As CheckBoxList, ByVal Value As String)

        For Each LT As ListItem In CHK.Items
            If LT.Value = Value Then
                LT.Selected = True
            End If
        Next
    End Sub

    ' ''' <summary>
    ' ''' ดึงค่า RadioList
    ' ''' </summary>
    ' ''' <remarks></remarks>
    '<System.Runtime.CompilerServices.Extension()> _
    'Public Sub RadioList_MultiSelectData(ByRef radios As RadioButtonList, ByVal Values() As String)
    '    For Each s As String In Values
    '        For Each LT As ListItem In radios.Items
    '            If LT.Value = s Then
    '                LT.Selected = True
    '            End If
    '        Next
    '    Next

    'End Sub

#End Region

#Region "Encode"
    ''' <summary>
    ''' เข้ารหัส แบบ base64
    ''' </summary>
    ''' <param name="StrEncode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function b64encode(ByVal StrEncode As String)
        Dim encodedString As String
        encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)))
        Return (encodedString)
    End Function

    ''' <summary>
    ''' ถอดรหัสแบบ base64
    ''' </summary>
    ''' <param name="StrDecode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function b64decode(ByVal StrDecode As String)
        Dim decodedString As String
        decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode))
        Return decodedString
    End Function
#End Region

#Region "DataBase Control"
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal obj As Object) As DataTable

        Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)

    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

        Return New ObjectShredder(Of T)().Shred(source, table, options)

    End Function
#End Region

#Region "Convert Control"
    ''' <summary>
    ''' convert csv
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToCsv(Of T)(ByVal source As IEnumerable(Of T)) As String
        If source Is Nothing Then
            Throw New ArgumentNullException("source")
        End If
        Return String.Join(",", source.[Select](Function(s) s.ToString()).ToArray())
    End Function

    ''' <summary>
    ''' convert decimal
    ''' </summary>
    ''' <param name="i"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDecimal(ByVal i As Integer) As String
        Return i & ".00"
    End Function

    ''' <summary>
    ''' แปลงตัวเลขเป็นตัวหนังสือ
    ''' </summary>
    ''' <param name="Money"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ConvertMoneyToText(ByVal Money As Decimal) As String
        Dim check As Integer
        Dim Text As String = ""
        Text = Money.ToString(".00")
        check = 1
        Dim textn As String = ""
        Dim textd As String = ""
        Dim temp As String = ""
        Dim posi1 As Integer = 0
        Dim read As String = ""
        Dim su As Integer = 0



        Dim c As Integer
        For j = 1 To Len(Text)
            If Mid(Text, j, 1) = "." Then
                c = 1
            Else : textn = Text
                textd = "00"
            End If
        Next j
        If c = 1 Then
            For i = 1 To Len(Text)
                If Mid(Text, i, 1) = "." Then
                    textn = Mid(Text, 1, i - 1)
                    textd = Mid(Text, i + 1, Len(Text))
                End If
            Next i
        End If

        If Len(textn) > 7 Then
            read = SubConvert(Mid(textn, 1, Len(textn) - 6)) & "ล้าน"

            read = read & SubConvert(Mid(textn, Len(textn) - 5, 6))
        Else
            read = read & SubConvert(textn)
        End If

        read = read + "บาท"

        If (Mid(textd, 1, 1) = "0" And Mid(textd, 2, 1) = "0") Then
            read = read + "ถ้วน"
        Else
            For i = 1 To Len(textd)
                temp = Mid(textd, i, 1)
                posi1 = Len(textd) - i
                Select Case temp
                    Case "1"
                        Select Case posi1
                            Case 0
                                If Len(textd) = 1 Then
                                    read = read + "หนึ่ง"
                                Else
                                    If Mid(textd, 1, 1) = 0 Then
                                        read = read + "หนึ่ง"
                                    Else : read = read + "เอ็ด"
                                    End If
                                End If
                            Case 1
                                read = read + "สิบ"
                            Case 2
                                read = read + "หนึ่งร้อย"
                            Case 3
                                read = read + "หนึ่งพัน"
                            Case 4
                                read = read + "หนึ่งหมื่น"
                            Case 5
                                read = read + "หนึ่งแสน"
                            Case 6
                                read = read + "หนึ่งล้าน"
                        End Select
                    Case "2"
                        Select Case posi1
                            Case 0
                                read = read + "สอง"
                            Case 1
                                read = read + "ยี่สิบ"
                            Case 2
                                read = read + "สองร้อย"
                            Case 3
                                read = read + "สองพัน"
                            Case 4
                                read = read + "สองหมื่น"
                            Case 5
                                read = read + "สองแสน"
                            Case 6
                                read = read + "สองล้าน"
                        End Select
                    Case "3"
                        Select Case posi1
                            Case 0
                                read = read + "สาม"
                            Case 1
                                read = read + "สามสิบ"
                            Case 2
                                read = read + "สามร้อย"
                            Case 3
                                read = read + "สามพัน"
                            Case 4
                                read = read + "สามหมื่น"
                            Case 5
                                read = read + "สามแสน"
                            Case 6
                                read = read + "สามล้าน"
                        End Select
                    Case "4"
                        Select Case posi1
                            Case 0
                                read = read + "สี่"
                            Case 1
                                read = read + "สี่สิบ"
                            Case 2
                                read = read + "สี่ร้อย"
                            Case 3
                                read = read + "สี่พัน"
                            Case 4
                                read = read + "สี่หมื่น"
                            Case 5
                                read = read + "สี่แสน"
                            Case 6
                                read = read + "สี่ล้าน"
                        End Select
                    Case "5"
                        Select Case posi1
                            Case 0
                                read = read + "ห้า"
                            Case 1
                                read = read + "ห้าสิบ"
                            Case 2
                                read = read + "ห้าร้อย"
                            Case 3
                                read = read + "ห้าพัน"
                            Case 4
                                read = read + "ห้าหมื่น"
                            Case 5
                                read = read + "ห้าแสน"
                            Case 6
                                read = read + "ห้าล้าน"
                        End Select
                    Case "6"
                        Select Case posi1
                            Case 0
                                read = read + "หก"
                            Case 1
                                read = read + "หกสิบ"
                            Case 2
                                read = read + "หกร้อย"
                            Case 3
                                read = read + "หกพัน"
                            Case 4
                                read = read + "หกหมื่น"
                            Case 5
                                read = read + "หกแสน"
                            Case 6
                                read = read + "หกล้าน"
                        End Select
                    Case "7"
                        Select Case posi1
                            Case 0
                                read = read + "เจ็ด"
                            Case 1
                                read = read + "เจ็ดสิบ"
                            Case 2
                                read = read + "เจ็ดร้อย"
                            Case 3
                                read = read + "เจ็ดพัน"
                            Case 4
                                read = read + "เจ็ดหมื่น"
                            Case 5
                                read = read + "เจ็ดแสน"
                            Case 6
                                read = read + "เจ็ดล้าน"
                        End Select
                    Case "8"
                        Select Case posi1
                            Case 0
                                read = read + "แปด"
                            Case 1
                                read = read + "แปดสิบ"
                            Case 2
                                read = read + "แปดร้อย"
                            Case 3
                                read = read + "แปดพัน"
                            Case 4
                                read = read + "แปดหมื่น"
                            Case 5
                                read = read + "แปดแสน"
                            Case 6
                                read = read + "แปดล้าน"
                        End Select
                    Case "9"
                        Select Case posi1
                            Case 0
                                read = read + "เก้า"
                            Case 1
                                read = read + "เก้าสิบ"
                            Case 2
                                read = read + "เก้าร้อย"
                            Case 3
                                read = read + "เก้าพัน"
                            Case 4
                                read = read + "เก้าหมื่น"
                            Case 5
                                read = read + "เก้าแสน"
                            Case 6
                                read = read + "เก้าล้าน"
                        End Select
                End Select
            Next i
            read = read + "สตางค์"
        End If

        'If textd = "00" Then
        ConvertMoneyToText = read
        'Else
        '    textread = read + "="
        'End If
        '   Return ConvertMoneyToText
    End Function

    Public Function SubConvert(ByVal textn As String) As String
        Dim read As String = ""
        Dim posi1 As Integer
        Dim temp As String = ""
        Dim su As Integer = 0
        For i = 1 To Len(textn)
            temp = Mid(textn, i, 1)
            posi1 = Len(textn) - i
            Select Case temp
                Case "1"
                    Select Case posi1
                        Case 0
                            If Len(textn) = 1 Then
                                read = read + "หนี่ง"
                            Else
                                su = Len(textn) - 1
                                If Mid(textn, su, 1) = 0 Then
                                    read = read + "หนึ่ง"
                                Else : read = read + "เอ็ด"
                                End If
                            End If
                        Case 1
                            read = read + "สิบ"
                        Case 2
                            read = read + "หนึ่งร้อย"
                        Case 3
                            read = read + "หนึ่งพัน"
                        Case 4
                            read = read + "หนึ่งหมื่น"
                        Case 5
                            read = read + "หนึ่งแสน"
                        Case 6
                            read = read + "หนึ่งล้าน"

                    End Select
                Case "2"
                    Select Case posi1
                        Case 0
                            read = read + "สอง"
                        Case 1
                            read = read + "ยี่สิบ"
                        Case 2
                            read = read + "สองร้อย"
                        Case 3
                            read = read + "สองพัน"
                        Case 4
                            read = read + "สองหมื่น"
                        Case 5
                            read = read + "สองแสน"
                        Case 6
                            read = read + "สองล้าน"

                    End Select
                Case "3"
                    Select Case posi1
                        Case 0
                            read = read + "สาม"
                        Case 1
                            read = read + "สามสิบ"
                        Case 2
                            read = read + "สามร้อย"
                        Case 3
                            read = read + "สามพัน"
                        Case 4
                            read = read + "สามหมื่น"
                        Case 5
                            read = read + "สามแสน"
                        Case 6
                            read = read + "สามล้าน"

                    End Select
                Case "4"
                    Select Case posi1
                        Case 0
                            read = read + "สี่"
                        Case 1
                            read = read + "สี่สิบ"
                        Case 2
                            read = read + "สี่ร้อย"
                        Case 3
                            read = read + "สี่พัน"
                        Case 4
                            read = read + "สี่หมื่น"
                        Case 5
                            read = read + "สี่แสน"
                        Case 6
                            read = read + "สี่ล้าน"

                    End Select
                Case "5"
                    Select Case posi1
                        Case 0
                            read = read + "ห้า"
                        Case 1
                            read = read + "ห้าสิบ"
                        Case 2
                            read = read + "ห้าร้อย"
                        Case 3
                            read = read + "ห้าพัน"
                        Case 4
                            read = read + "ห้าหมื่น"
                        Case 5
                            read = read + "ห้าแสน"
                        Case 6
                            read = read + "ห้าล้าน"

                    End Select
                Case "6"
                    Select Case posi1
                        Case 0
                            read = read + "หก"
                        Case 1
                            read = read + "หกสิบ"
                        Case 2
                            read = read + "หกร้อย"
                        Case 3
                            read = read + "หกพัน"
                        Case 4
                            read = read + "หกหมื่น"
                        Case 5
                            read = read + "หกแสน"
                        Case 6
                            read = read + "หกล้าน"

                    End Select
                Case "7"
                    Select Case posi1
                        Case 0
                            read = read + "เจ็ด"
                        Case 1
                            read = read + "เจ็ดสิบ"
                        Case 2
                            read = read + "เจ็ดร้อย"
                        Case 3
                            read = read + "เจ็ดพัน"
                        Case 4
                            read = read + "เจ็ดหมื่น"
                        Case 5
                            read = read + "เจ็ดแสน"
                        Case 6
                            read = read + "เจ็ดล้าน"

                    End Select
                Case "8"
                    Select Case posi1
                        Case 0
                            read = read + "แปด"
                        Case 1
                            read = read + "แปดสิบ"
                        Case 2
                            read = read + "แปดร้อย"
                        Case 3
                            read = read + "แปดพัน"
                        Case 4
                            read = read + "แปดหมื่น"
                        Case 5
                            read = read + "แปดแสน"
                        Case 6
                            read = read + "แปดล้าน"

                    End Select
                Case "9"
                    Select Case posi1
                        Case 0
                            read = read + "เก้า"
                        Case 1
                            read = read + "เก้าสิบ"
                        Case 2
                            read = read + "เก้าร้อย"
                        Case 3
                            read = read + "เก้าพัน"
                        Case 4
                            read = read + "เก้าหมื่น"
                        Case 5
                            read = read + "เก้าแสน"
                        Case 6
                            read = read + "เก้าล้าน"

                    End Select
            End Select
        Next i
        Return read
    End Function
#End Region

#Region "Math Control"
    ''' <summary>
    ''' กำหนดจำนวนทศนิยม
    ''' </summary>
    ''' <param name="number"></param>
    ''' <param name="dec"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function RoundDouble_to_int(ByVal number As Double, ByVal dec As Integer) As Double
        Return Round(number, dec)
    End Function

    ''' <summary>
    ''' ปัดเศษทศนิยมขึ้น
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function RoundUp(ByVal number As Double) As Integer
        Return Ceiling(number)
    End Function

    ''' <summary>
    ''' ปัดเศษทศนิยมลง
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function RoundDown(ByVal number As Double) As Integer
        Return Floor(number)
    End Function
#End Region

#Region "Script Control"
    ''' <summary>
    ''' Alert
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="MSG"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Alert(ByRef s As HttpResponse, ByVal MSG As String)
        s.Write("<script language=javascript>")
        s.Write("alert('" & MSG & "');")
        s.Write("</script>")
    End Sub

    ''' <summary>
    ''' Date
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="T"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DateJava(ByRef s As Literal, ByVal T As TextBox)
        Dim Sql As String = "<script type='text/javascript'>" & vbNewLine & _
        "    $(document).ready(function() {" & vbNewLine & _
        "    var targetobject = $('#" & T.ClientID & "');" & vbNewLine & _
        "" & vbNewLine & _
        "        $(targetobject).datepicker({ showOn: 'button'," & vbNewLine & _
        "" & vbNewLine & _
        "            buttonImage: '../Script/calendar.gif'," & vbNewLine & _
        "" & vbNewLine & _
        "            buttonImageOnly: true" & vbNewLine & _
        "        });" & vbNewLine & _
        "" & vbNewLine & _
        "    });      " & vbNewLine & _
        "</script> "
        Dim Decode As String = """"
        s.Text = Sql.Replace("'", Decode)
    End Sub
#End Region

    Public Class ObjectShredder(Of T)

        Private _fi() As FieldInfo

        Private _pi() As PropertyInfo

        Private _ordinalMap As Dictionary(Of String, Integer)

        Private _type As Type

        Public Sub New()

            _type = GetType(T)

            _fi = _type.GetFields()

            _pi = _type.GetProperties()

            _ordinalMap = New Dictionary(Of String, Integer)()

        End Sub

        Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

            If GetType(T).IsPrimitive Then

                Return ShredPrimitive(source, table, options)

            End If

            If table Is Nothing Then

                table = New DataTable(GetType(T).Name)

            End If

            ' now see if need to extend datatable base on the type T + build ordinal map

            table = ExtendTable(table, GetType(T))

            table.BeginLoadData()

            Using e As IEnumerator(Of T) = source.GetEnumerator()

                Do While e.MoveNext()

                    If options.HasValue Then

                        table.LoadDataRow(ShredObject(table, e.Current), CType(options, LoadOption))

                    Else

                        table.LoadDataRow(ShredObject(table, e.Current), True)

                    End If

                Loop

            End Using

            table.EndLoadData()

            Return table

        End Function

        Public Function ShredPrimitive(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As Nullable(Of LoadOption)) As DataTable

            If table Is Nothing Then

                table = New DataTable(GetType(T).Name)

            End If

            If (Not table.Columns.Contains("Value")) Then

                table.Columns.Add("Value", GetType(T))

            End If

            table.BeginLoadData()

            Using e As IEnumerator(Of T) = source.GetEnumerator()

                Dim values() As Object = New Object(table.Columns.Count - 1) {}

                Do While e.MoveNext()

                    values(table.Columns("Value").Ordinal) = e.Current

                    If options.HasValue Then

                        table.LoadDataRow(values, CType(options, LoadOption))

                    Else

                        table.LoadDataRow(values, True)

                    End If

                Loop

            End Using

            table.EndLoadData()

            Return table

        End Function

        Public Function ExtendTable(ByVal table As DataTable, ByVal type As Type) As DataTable

            ' value is type derived from T, may need to extend table.

            For Each f As FieldInfo In type.GetFields()

                If (Not _ordinalMap.ContainsKey(f.Name)) Then

                    Dim dc As DataColumn

                    dc = If(table.Columns.Contains(f.Name), table.Columns(f.Name), table.Columns.Add(f.Name, f.FieldType))

                    _ordinalMap.Add(f.Name, dc.Ordinal)

                End If

            Next f

            For Each p As PropertyInfo In type.GetProperties()

                If (Not _ordinalMap.ContainsKey(p.Name)) Then

                    Dim dc As DataColumn
                    Try
                        dc = If(table.Columns.Contains(p.Name), table.Columns(p.Name), table.Columns.Add(p.Name, p.PropertyType))
                    Catch ex As Exception
                        dc = table.Columns.Add(p.Name)
                    End Try
                    _ordinalMap.Add(p.Name, dc.Ordinal)

                End If

            Next p

            Return table

        End Function

        Public Function ShredObject(ByVal table As DataTable, ByVal instance As T) As Object()

            Dim fi() As FieldInfo = _fi

            Dim pi() As PropertyInfo = _pi

            If instance.GetType() IsNot GetType(T) Then

                ExtendTable(table, instance.GetType())

                fi = instance.GetType().GetFields()

                pi = instance.GetType().GetProperties()

            End If

            Dim values() As Object = New Object(table.Columns.Count - 1) {}

            For Each f As FieldInfo In fi

                values(_ordinalMap(f.Name)) = f.GetValue(instance)

            Next f

            For Each p As PropertyInfo In pi
                values(_ordinalMap(p.Name)) = p.GetValue(instance, Nothing)
            Next p

            Return values

        End Function

    End Class

    <System.Runtime.CompilerServices.Extension()> _
    Public Function get_Year(ByVal Mas As MasterPage) As String
        Dim bgYear As String = 0
        If Mas.Request.QueryString("bgyear") Is Nothing Then
            Dim dd_BudgetYear As DropDownList
            dd_BudgetYear = CType(Mas.FindControl("dd_year"), DropDownList)
            bgYear = dd_BudgetYear.SelectedValue
        Else
            bgYear = Mas.Request.QueryString("bgyear")
        End If

        Return bgYear
    End Function
    Function ConvertFromXml(Of T As Class)(ByRef str As String) As T


        Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))


        Dim reader As StringReader = New StringReader(str)


        Dim c As T = TryCast(serializer.Deserialize(reader), T)


        Return c


    End Function
#Region "AD"

    ''' <summary>
    ''' ดึงแต่ชื่อ AD
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NameUserAD() As String
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    Dim NAME As String = ""

    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    End If

    '    Dim dao_user As New DAO_USER.TB_tbl_USER_Procurement
    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_P Is Nothing Or dao_user.fields.PERMISSION_P = 0 Then
    '        HttpContext.Current.Response.Write("<script language=javascript>")
    '        HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        HttpContext.Current.Response.Write("window.location='/procurement/frmc_NoPermission.aspx';")
    '        HttpContext.Current.Response.Write("</script>")
    '    Else
    '        NAME = dao_user.fields.AD_NAME
    '    End If

    '    Return NAME
    'End Function


    ''' <summary>
    ''' ดึงกองของ AD ออกมา
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NameUserAD_DEPARTMENT() As Integer
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    Dim DEPARTMENT As Integer = 0

    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    End If
    '    Dim dao_user As New DAO_USER.TB_tbl_USER_Procurement

    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_P Is Nothing Or dao_user.fields.PERMISSION_P = 0 Then
    '        HttpContext.Current.Response.Write("<script language=javascript>")
    '        HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        HttpContext.Current.Response.Write("window.location='/procurement/frmc_NoPermission.aspx';")
    '        HttpContext.Current.Response.Write("</script>")
    '    Else
    '        DEPARTMENT = dao_user.fields.DEPARTMENT_ID

    '        Dim dao_dep As New dao_dtambg.TB_Department
    '        dao_dep.GetData_ByID(dao_user.fields.DEPARTMENT_ID)
    '        DepName = dao_dep.fields.DEPARTMENT_DESCRIPTION
    '    End If

    '    Return DEPARTMENT
    'End Function


    ''' <summary>
    ''' ดึงกองหลักออกมา
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NameUserAD_MAINDEPARTMENT() As Integer
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    Dim DEPARTMENT As Integer = 0

    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    End If

    '    Dim dao_user As New DAO_USER.TB_tbl_USER_Procurement
    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_P Is Nothing Or dao_user.fields.PERMISSION_P = 0 Then
    '        HttpContext.Current.Response.Write("<script language=javascript>")
    '        HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        HttpContext.Current.Response.Write("window.location='/procurement/frmc_NoPermission.aspx';")
    '        HttpContext.Current.Response.Write("</script>")
    '    Else
    '        Dim dao_department As New dao_dtambg.TB_Department
    '        dao_department.GetData_ByID(dao_user.fields.DEPARTMENT_ID)
    '        DEPARTMENT = dao_department.fields.DEPARTMENT_HEAD_ID
    '    End If

    '    Return DEPARTMENT
    'End Function


    ''' <summary>
    ''' ดึงสิทธิ์ออกมาว่าระดับอะไร
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NameUserAD_PERMISSION() As Integer
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    Dim PERMISSION As Integer = 0

    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    End If

    '    Dim dao_user As New DAO_USER.TB_tbl_USER_Procurement
    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_P Is Nothing Or dao_user.fields.PERMISSION_P = 0 Then
    '        HttpContext.Current.Response.Write("<script language=javascript>")
    '        HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        HttpContext.Current.Response.Write("window.location='/procurement/frmc_NoPermission.aspx';")
    '        HttpContext.Current.Response.Write("</script>")
    '    Else
    '        PERMISSION = dao_user.fields.PERMISSION_P
    '    End If

    '    Return PERMISSION
    'End Function


    ''' <summary>
    ''' ดึงสิทธิ์ออกมาว่าระดับอะไร
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function NameUserAD_FirstNameLastName() As String
    '    Dim p As System.Security.Principal.WindowsPrincipal = TryCast(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    '    Dim strWindowName As String = p.Identity.Name
    '    Dim strScript As String = ""
    '    Dim ADNAME As String = ""
    '    Dim FullName As String = ""

    '    If strWindowName.Trim() <> "" Then
    '        Dim arrWindowName As String() = strWindowName.Split("\")
    '        '   strDomainName = arrWindowName(0).ToString()
    '        ADNAME = arrWindowName(1).ToString()
    '    End If

    '    Dim dao_user As New DAO_USER.TB_tbl_USER_Procurement
    '    dao_user.Getdata_by_AD_NAME(ADNAME)
    '    If dao_user.fields.PERMISSION_P Is Nothing Or dao_user.fields.PERMISSION_P = 0 Then
    '        HttpContext.Current.Response.Write("<script language=javascript>")
    '        HttpContext.Current.Response.Write("alert('คุณไม่มีสิทธิเข้าใช้งานในระบบ');")
    '        HttpContext.Current.Response.Write("window.location='/procurement/frmc_NoPermission.aspx';")
    '        HttpContext.Current.Response.Write("</script>")
    '    Else
    '        FullName = dao_user.fields.PREFIX & " " & dao_user.fields.NAME & " " & dao_user.fields.SURNAME
    '    End If

    '    Return FullName
    'End Function


    Private _DepName As String
    Public Property DepName() As String
        Get
            Return _DepName
        End Get
        Set(ByVal value As String)
            _DepName = value
        End Set
    End Property


    Private _DepCode As String
    Public Property DepCode() As String
        Get
            Return _DepCode
        End Get
        Set(ByVal value As String)
            _DepCode = value
        End Set
    End Property

    Private _DepPlace As String
    Public Property DepPlace() As String
        Get
            Return _DepPlace
        End Get
        Set(ByVal value As String)
            _DepPlace = value
        End Set
    End Property

    ''' <summary>
    ''' ดึงรหัสและที่อยู่ออกมา
    ''' </summary>
    ''' <remarks></remarks>
    'Public Sub Module_GetDepartment()
    '    Dim dao As New dao_procurement.TB_DEPARTMENT_CODE
    '    dao.GetDataby_DepID(NameUserAD_DEPARTMENT)
    '    DepCode = dao.fields.Dep_Code
    '    DepPlace = dao.fields.Dep_Place
    'End Sub

#End Region
End Module
