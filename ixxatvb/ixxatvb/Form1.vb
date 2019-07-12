Imports System.Threading
Imports System
Imports Microsoft


Public Class Form1
    Private mDevice As Ixxat.Vci4.IVciDevice = Nothing
    Private mCanChn As Ixxat.Vci4.Bal.Can.ICanChannel = Nothing
    Private mReader As Ixxat.Vci4.Bal.Can.ICanMessageReader = Nothing
    Private mWriter As Ixxat.Vci4.Bal.Can.ICanMessageWriter = Nothing
    Private mCanCtl As Ixxat.Vci4.Bal.Can.ICanControl = Nothing

    Private mRxEvent As System.Threading.AutoResetEvent = Nothing
    Private rxThread As System.Threading.Thread = Nothing

    Private deviceManager As Ixxat.Vci4.IVciDeviceManager = Nothing
    Private deviceList As Ixxat.Vci4.IVciDeviceList = Nothing
    Private deviceEnum As IEnumerator = Nothing

    Private changeEvent As New AutoResetEvent(True)
    Private interfaceChangeThread As System.Threading.Thread = Nothing


    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)

    ' Here is the tread safe call for the interface list box
    Delegate Sub FillListBoxWithInterFacesCallBack()
    Private Sub CloseAll()
        If mCanCtl IsNot Nothing Then
            ' stop the CAN controller
            Try
                mCanCtl.StopLine()
            Catch ex As Exception
                ' the can control has leave the scope,
                ' e.g. a plugable interface which was removed
            End Try
        End If

        TimerGetStatus.Enabled = False

        If rxThread IsNot Nothing Then
            '
            ' tell receive thread to quit
            '
            rxThread.Abort()

            '
            ' Wait for termination of receive thread
            '
            rxThread.Join()

            rxThread = Nothing
        End If

        If interfaceChangeThread IsNot Nothing Then
            '
            ' tell interface change thread to quit
            '
            interfaceChangeThread.Abort()

            '
            ' Wait for termination of interface change thread
            '
            interfaceChangeThread.Join()

            interfaceChangeThread = Nothing
        End If

        ' dispose all open objects including the vci object itself
        CloseVciObjects(True)
    End Sub


    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click

        CloseAll()

        Close()
    End Sub

    Private Sub ButtonInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInit.Click

        Dim CurListViewItem As ListViewItem
        CurListViewItem = ListViewAvailInterfaces.SelectedItems(0)

        TimerGetStatus.Enabled = False

        CloseCurrentExistingController()

        If CurListViewItem IsNot Nothing Then


            SelectDevice(CurListViewItem.Tag)
            InitSocket(0)

            '
            ' start the receive thread
            '
            rxThread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf ReceiveThreadFunc))
            rxThread.Start()


            ButtonInit.Enabled = False
            ButtonTransmitData.Enabled = True
            TimerGetStatus.Enabled = True

            '      TimerSendData.Enabled = True
        End If  'If CurListViewItem
    End Sub

    Private Sub SelectDevice(ByVal DeviceEnumNumber As Long)
        Dim mTempDevice As Ixxat.Vci4.IVciDevice = Nothing
        Dim deviceHardwareID As Object
        Try
            deviceEnum = deviceList.GetEnumerator()
            deviceEnum.Reset()

            Do While deviceEnum.MoveNext() = True

                mTempDevice = deviceEnum.Current

                If mTempDevice.VciObjectId = DeviceEnumNumber Then
                    mDevice = mTempDevice

                    ' a sample how to read the unique hardware ID from the device
                    deviceHardwareID = mTempDevice.UniqueHardwareId

                    ' if the UniqueHardwareId returns a GUID the try to convert it
                    ' to a IXXAT like serial number HWxxxxxx
                    If TypeOf deviceHardwareID Is System.Guid Then
                        LblHWID.Text = GetSerialNumber(deviceHardwareID)
                    Else
                        LblHWID.Text = deviceHardwareID.ToString()
                    End If

                End If

            Loop

        Catch ex As Exception
            ' todo show the exception
        End Try

    End Sub


    Private Sub InitSocket(ByVal canNo As Byte)
        Dim bal As Ixxat.Vci4.Bal.IBalObject

        Dim balType As Type
        balType = GetType(Ixxat.Vci4.Bal.Can.ICanChannel)


        Try
            bal = mDevice.OpenBusAccessLayer()

            mCanChn = bal.OpenSocket(canNo, balType)

            ' Initialize the message channel
            mCanChn.Initialize(1024, 128, False)

            ' Get a message reader object
            mReader = mCanChn.GetMessageReader()

            ' Initialize message reader
            mReader.Threshold = 1

            ' Create and assign the event that's set if at least one message
            ' was received.
            mRxEvent = New System.Threading.AutoResetEvent(False)
            mReader.AssignEvent(mRxEvent)

            ' Get a message writer object
            mWriter = mCanChn.GetMessageWriter()

            ' Initialize message writer
            mWriter.Threshold = 1

            ' Activate the message channel
            mCanChn.Activate()


            ' Open the CAN controller
            Dim canCtrlType As Type
            canCtrlType = GetType(Ixxat.Vci4.Bal.Can.ICanControl)
            mCanCtl = bal.OpenSocket(canNo, canCtrlType)

            ' Initialize the CAN controller
            Dim operatingMode As Byte
            operatingMode = Ixxat.Vci4.Bal.Can.CanOperatingModes.Standard Or Ixxat.Vci4.Bal.Can.CanOperatingModes.Extended Or Ixxat.Vci4.Bal.Can.CanOperatingModes.ErrFrame


            Dim bitRate As Ixxat.Vci4.Bal.Can.CanBitrate
            bitRate = GetSelectedBaudRate()
            mCanCtl.InitLine(operatingMode, bitRate)

            '  Set the acceptance filter
            Dim accCode As UInteger
            Dim accMask As UInteger

            accCode = Ixxat.Vci4.Bal.Can.CanAccCode.All
            accMask = Ixxat.Vci4.Bal.Can.CanAccMask.All

            mCanCtl.SetAccFilter(Ixxat.Vci4.Bal.Can.CanFilter.Std, accCode, accMask)

            ' Start the CAN controller
            mCanCtl.StartLine()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return
        End Try


    End Sub

    ' if another controller is selected then the
    ' existing controller and channel objects must be closed
    Private Sub CloseCurrentExistingController()
        ' if necessary close a existing connection
        If mCanCtl IsNot Nothing Then
            ' stop the CAN controller
            Try
                mCanCtl.StopLine()
            Catch ex As Exception
                ' the can control has leave the scope,
                ' e.g. a plugable interface which was removed
            End Try
        End If

        ' close the receive thread we will reopen it
        ' with another event
        If rxThread IsNot Nothing Then
            '
            ' tell receive thread to quit
            '
            rxThread.Abort()

            '
            ' Wait for termination of receive thread
            '
            rxThread.Join()

            rxThread = Nothing
        End If
        CloseVciObjects(False)
    End Sub

    Private Sub CloseVciObjects(closeVciObject As Boolean)
        ' Dispose all hold VCI objects.

        ' Dispose message reader
        If (mReader IsNot Nothing) Then
            DisposeVciObject(mReader)
            mReader = Nothing
        End If

        ' Dispose message writer 
        If (mWriter IsNot Nothing) Then
            DisposeVciObject(mWriter)
            mWriter = Nothing
        End If

        ' Dispose CAN channel
        If (mCanChn IsNot Nothing) Then
            DisposeVciObject(mCanChn)
            mCanChn = Nothing
        End If

        ' Dispose CAN controller
        If (mCanCtl IsNot Nothing) Then
            DisposeVciObject(mCanCtl)
            mCanCtl = Nothing
        End If

        ' Dispose VCI device
        DisposeVciObject(mDevice)
    End Sub

    Private Sub DisposeVciObject(ByVal obj As Object)
        If obj IsNot Nothing Then
            Dim dispose As System.IDisposable
            dispose = obj
            If dispose IsNot Nothing Then
                dispose.Dispose()
                obj = Nothing
            End If
        End If
    End Sub

    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If labelLastRxMsg.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})



        Else
            labelLastRxMsg.Text = [text]
        End If
    End Sub

    ' a thread callback function to check if the 
    ' interfaces have changed (e.g. removed or added a USB interface)
    Private Sub InterfaceChangeThreadFunc()
        Do
            If changeEvent.WaitOne(-1, False) Then
                FillListBoxWithInterFaces()
            End If
        Loop
    End Sub


    Private Sub ReceiveThreadFunc()

        Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage = Nothing

        Do
            ' Wait 100 msec for a message reception
            If mRxEvent.WaitOne(100, False) Then

                '      // read a CAN message from the receive FIFO
                If mReader.ReadMessage(canMessage) Then
                    ShowReceivedMessage(canMessage)
                End If 'If mReader.ReadMessage(canMessage) Then
            End If  'If mRxEvent.WaitOne(100, False) Then
        Loop
    End Sub

    Private Sub ShowReceivedMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        Select Case canMessage.FrameType
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
                ShowDataMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.Error
                ShowErrorMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.Info
                ShowInfoMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.Status
                ShowStatusMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.TimeOverrun
                ShowTimerOverrunMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.TimeReset
                ShowTimerResetMessage(canMessage)
            Case Ixxat.Vci4.Bal.Can.CanMsgFrameType.Wakeup
                ShowWakeUpMessage(canMessage)
        End Select
    End Sub

    Private Sub ShowDataMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        Dim textLine As String
        textLine = "Time: " + canMessage.TimeStamp.ToString + " ID: " + canMessage.Identifier.ToString("X3") + "h"

        If canMessage.RemoteTransmissionRequest Then
            textLine = textLine + " Remote Request Data Length: " + canMessage.DataLength.ToString()
        Else
            Dim i As Byte
            For i = 1 To canMessage.DataLength
                ' we start the data bytes from 0
                textLine = textLine + " " + canMessage(i - 1).ToString("X2")
            Next
        End If

        If canMessage.SelfReceptionRequest Then
            textLine = textLine + " Self Reception"
        End If

        ' set the text thread safe to the label
        SetText(textLine)
    End Sub

    Private Sub ShowErrorMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        ' todo
        Dim msgError As Ixxat.Vci4.Bal.Can.CanMsgError
        msgError = canMessage(0)
        Select Case msgError
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Acknowledge
                SetText("Error: Acknowledge")
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Bit
                SetText("Error: Bit")
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Crc
                SetText("Error: Crc")
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Form
                SetText("Error: Form")
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Other
                SetText("Error: Other")
            Case Ixxat.Vci4.Bal.Can.CanMsgError.Stuff
                SetText("Error: Stuff")
        End Select
    End Sub
    Private Sub ShowInfoMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)

    End Sub
    Private Sub ShowStatusMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
    End Sub
    Private Sub ShowTimerOverrunMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        ' todo
    End Sub
    Private Sub ShowTimerResetMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        ' todo
    End Sub
    Private Sub ShowWakeUpMessage(ByVal canMessage As Ixxat.Vci4.Bal.Can.ICanMessage)
        ' todo
    End Sub



    Private Sub ButtonTransmitData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransmitData.Click

        If mWriter IsNot Nothing Then
            'IMessageFactory factory = VciServer.Instance().MsgFactory;
            Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
            Dim factory As Ixxat.Vci4.IMessageFactory
            Dim mainIndex As UInt16 = &H6040

            Dim mainIndexhi As Byte = &H40
            Dim mainIndexlo As Byte = &H60
            Dim subIndex As Byte = &H0
            Dim data As Byte = &H0
            factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

            canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

            ' canMessage = factory.CreateMsg(Ixxat.Vci4.Bal.Can.ICanMessage)

            'ICanMessage canMsg = (ICanMessage)factory.CreateMsg(typeof(Ixxat.Vci4.Bal.Can.ICanMessage));


            canMessage.TimeStamp = 0
            canMessage.Identifier = &H601
            canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
            canMessage.DataLength = 8
            canMessage.SelfReceptionRequest = True

            'Dim i As Byte
            'For i = 0 To 7
            '    canMessage(i) = i
            'Next

            canMessage(0) = &H40
            'canMessage(1) = CByte(mainIndex)  ' &H6
            canMessage(1) = mainIndex Mod 256

            ' mainIndexhi


            ' low8 = Int16 Mod 256
            ' hi8 = Int16 / 256
            'yobyte(mainIndex)
            canMessage(2) = mainIndex / 256
            ' mainIndexlo
            canMessage(3) = subIndex
            canMessage(4) = data Mod 256
            canMessage(5) = data / 256
            canMessage(6) = 0
            canMessage(7) = 0
            'msg[1] = (Byte)mainIndex;
            'msg[2] = (Byte)(mainIndex >> 8);
            'msg[3] = subIndex;
            'msg[4] = (Byte)data;
            'msg[5] = (Byte)(data >> 8);
            'msg[6] = 0;
            'msg[7] = 0;
            ' Write the CAN message into the transmit FIFO
            If mWriter.Capacity > 0 Then
                mWriter.SendMessage(canMessage)
            End If



        End If

    End Sub

    Private Sub TimerGetStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGetStatus.Tick

        If mCanCtl IsNot Nothing Then
            Dim lineStatus As Ixxat.Vci4.Bal.Can.CanLineStatus

            ' use a try, when we want read the status of 
            ' a interface which does not longer exists it will
            ' crash
            Try
                lineStatus = mCanCtl.LineStatus

                If lineStatus.IsInInitMode Then
                    PictureBoxInitMode.BackColor = Color.Red
                Else
                    PictureBoxInitMode.BackColor = Color.LightGreen
                End If

                If lineStatus.IsTransmitPending Then
                    PictureBoxTxPending.BackColor = Color.Red
                Else
                    PictureBoxTxPending.BackColor = Color.LightGreen
                End If

                If lineStatus.HasDataOverrun Then
                    PictureBoxOverrun.BackColor = Color.Red
                Else
                    PictureBoxOverrun.BackColor = Color.LightGreen
                End If

                If lineStatus.HasErrorOverrun Then
                    PictureBoxWarningLevel.BackColor = Color.Red
                Else
                    PictureBoxWarningLevel.BackColor = Color.LightGreen
                End If

                If lineStatus.IsBusOff Then
                    PictureBoxBusOff.BackColor = Color.Red
                Else
                    PictureBoxBusOff.BackColor = Color.LightGreen
                End If
            Catch ex As Exception
                PictureBoxInitMode.BackColor = Color.Gray
                PictureBoxTxPending.BackColor = Color.Gray
                PictureBoxOverrun.BackColor = Color.Gray
                PictureBoxOverrun.BackColor = Color.Gray
                PictureBoxWarningLevel.BackColor = Color.Gray
                PictureBoxBusOff.BackColor = Color.Gray
            End Try


        End If

    End Sub

    Private Sub FillListBoxWithInterFaces()

        If ListViewAvailInterfaces.InvokeRequired Then
            Dim d As New FillListBoxWithInterFacesCallBack(AddressOf FillListBoxWithInterFaces)
            Me.Invoke(d, New Object() {})
        Else
            ' first remove all items of the listbox
            ' ListBoxAvailInterfaces.Items.Clear()
            ListViewAvailInterfaces.Items.Clear()

            '    Dim CurItem As Item
            'Dim CurItemIndex As Integer

            ' now walk through the device list
            Try
                deviceManager = Ixxat.Vci4.VciServer.Instance().DeviceManager
                deviceList = deviceManager.GetDeviceList()
                deviceEnum = deviceList.GetEnumerator()
                deviceEnum.Reset()
                'WuP: todo
                ' deviceList.AssignEvent(changeEvent)
                Do While deviceEnum.MoveNext() = True
                    'while deviceEnum.MoveNext() = True Then
                    mDevice = deviceEnum.Current


                    ' set the new list view item
                    ' the Tag should be the unique object ID
                    ' the Text should be the device description
                    Dim CurListViewItem = New ListViewItem
                    CurListViewItem.Tag = mDevice.VciObjectId
                    CurListViewItem.Text = mDevice.Description

                    ListViewAvailInterfaces.Items.Add(CurListViewItem)
                Loop


            Catch ex As Exception
            End Try
        End If



    End Sub

    Private Sub FormVCIV4Demo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Me.DataGridView1.AllowUserToAddRows = False
        'DataGridView1.RowTemplate.Height = 20
        'DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

        'Me.DataGridView1.Columns.Add("Main Index", "Main Index")
        'Me.DataGridView1.Columns.Add("Sub Index", "Sub Index")
        'Me.DataGridView1.Columns.Add("Data", "Data")
        'For i = 1 To 3
        '    Me.DataGridView1.Rows.Add()
        'Next

        'Me.DataGridView1.Columns(0).Width = 100
        'Me.DataGridView1.Columns(1).Width = 100
        'Me.DataGridView1.Columns(0).Width = 100
        Text = Text + " V" + Application.ProductVersion
        deviceManager = Ixxat.Vci4.VciServer.Instance().DeviceManager
        deviceList = deviceManager.GetDeviceList()

        ' set a event to the devicelist to send this event if the interface list changes
        changeEvent = New System.Threading.AutoResetEvent(False)
        deviceList.AssignEvent(changeEvent)

        FillListBoxWithInterFaces()

        ' set 500 kBit/s as default baud rate
        ListBoxBaudrate.SelectedIndex = 2

        ' start a own thread which wait for a interface change message e.g. a USB device was plugged in or out
        interfaceChangeThread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf InterfaceChangeThreadFunc))
        interfaceChangeThread.Start()

    End Sub


    Private Sub ListViewAvailInterfaces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAvailInterfaces.SelectedIndexChanged
        ButtonInit.Enabled = True
        ShowDeviceHardwareID()
    End Sub

    Private Sub TimerSendData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSendData.Tick
        If mWriter IsNot Nothing Then
            Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
            Dim factory As Ixxat.Vci4.IMessageFactory
            factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

            canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

            canMessage.TimeStamp = 0
            canMessage.Identifier = &H100
            canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
            canMessage.DataLength = 8
            canMessage.SelfReceptionRequest = True

            Dim i As Byte
            For i = 0 To 7
                canMessage(i) = i
            Next

            ' Write the CAN message into the transmit FIFO
            If (Not mWriter.SendMessage(canMessage)) Then
                TimerSendData.Enabled = False
            End If

        End If
    End Sub

    Private Sub ShowDeviceHardwareID()
        Dim CurListViewItem As ListViewItem

        Dim selIndex As Windows.Forms.ListView.SelectedIndexCollection

        selIndex = ListViewAvailInterfaces.SelectedIndices()

        If selIndex.Count > 0 Then
            CurListViewItem = ListViewAvailInterfaces.SelectedItems(0)
            If CurListViewItem IsNot Nothing Then
                SelectDevice(CurListViewItem.Tag)
            End If
        End If
    End Sub


    ' Change the UniqueHardwareID to a string.
    ' Because of a bug in the .NET API unteil VCI 3.1.4.1784 the property
    ' UniqueHardwareId returns always a GUID. In newer version it returns
    ' a string with the HWxxxxx serial number.
    Private Function GetSerialNumber(ByVal inputGuid As System.Guid) As String
        Dim resultString As String

        ' Convert the GUID to a byte array
        Dim byteArray() As Byte = inputGuid.ToByteArray()

        ' The first 2 bytes must have HW as data, then it is really a serial number
        If (Chr(byteArray(0)) = "H") And (Chr(byteArray(1)) = "W") Then
            resultString = System.Text.Encoding.ASCII.GetString(byteArray)
        Else
            resultString = inputGuid.ToString()
        End If


        Return resultString
    End Function

    Private Function GetSelectedBaudRate() As Ixxat.Vci4.Bal.Can.CanBitrate

        Dim resultBaud As Ixxat.Vci4.Bal.Can.CanBitrate

        Select Case ListBoxBaudrate.SelectedIndex
            Case 0
                resultBaud = Ixxat.Vci4.Bal.Can.CanBitrate.Cia125KBit
            Case 1
                resultBaud = Ixxat.Vci4.Bal.Can.CanBitrate.Cia250KBit
            Case 2
                resultBaud = Ixxat.Vci4.Bal.Can.CanBitrate.Cia500KBit
            Case 3
                resultBaud = Ixxat.Vci4.Bal.Can.CanBitrate.Cia800KBit
            Case Else
                resultBaud = Ixxat.Vci4.Bal.Can.CanBitrate.Cia1000KBit
        End Select

        Return resultBaud
    End Function

    Private Sub FormVCIV4Demo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        CloseAll()
    End Sub

    ' Set the acceptance mask that all identifiers can pass
    Private Sub btnAcceptanceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptanceAll.Click

        mCanCtl.StopLine()

        '  Set the acceptance filter
        Dim accCode As UInteger
        Dim accMask As UInteger

        accCode = Ixxat.Vci4.Bal.Can.CanAccCode.All
        accMask = Ixxat.Vci4.Bal.Can.CanAccMask.All

        mCanCtl.SetAccFilter(Ixxat.Vci4.Bal.Can.CanFilter.Std, accCode, accMask)

        mCanCtl.StartLine()

    End Sub

    ' Set the acceptance mask that all identifiers with bit 0 have value 1 can pass
    Private Sub btnAcceptanceID1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptanceID1.Click

        mCanCtl.StopLine()

        '  Set the acceptance filter
        Dim accCode As UInteger
        Dim accMask As UInteger

        ' we want to see all identifier which have bit 0 set as 1
        ' binary mask/value filter:
        ' 000 0000 0001
        ' 000 0000 0001
        ' -------------
        ' xxx xxxx xxx1
        accCode = &H1
        accMask = &H1

        ' shift the identifier values one bit left, this means that the last
        ' bit (bit 0) is 0 and the RTR bit in the filter doesn't matter
        ' binary mask/value filter:
        ' 0000 0000 0010
        ' 0000 0000 0010
        ' --------------
        ' xxxx xxxx xx1x
        accCode = accCode << 1
        accMask = accMask << 1

        accCode = accCode + 1
        accMask = accMask + 1



        mCanCtl.SetAccFilter(Ixxat.Vci4.Bal.Can.CanFilter.Std, accCode, accMask)

        mCanCtl.StartLine()

    End Sub

    Private Sub Button_Read_Sdo_Click(sender As Object, e As EventArgs) Handles Button_Read_Sdo.Click


        If mWriter IsNot Nothing Then
            'IMessageFactory factory = VciServer.Instance().MsgFactory;
            Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
            Dim factory As Ixxat.Vci4.IMessageFactory
            Dim mainIndex As UInt16 = Val("&H" + TextBox1.Text) '&H60F6 'StrConv(TextBox1.Text, vbFromUnicode)

            Dim mainIndexhi As Byte = &H40
            Dim mainIndexlo As Byte = &H60
            Dim subIndex As Byte = Val("&H" + TextBox2.Text)
            Dim data As Byte = &H0
            factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

            canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

            ' canMessage = factory.CreateMsg(Ixxat.Vci4.Bal.Can.ICanMessage)

            'ICanMessage canMsg = (ICanMessage)factory.CreateMsg(typeof(Ixxat.Vci4.Bal.Can.ICanMessage));


            canMessage.TimeStamp = 0
            canMessage.Identifier = （"&H" + TextBox15.Text） ' &H601
            canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
            canMessage.DataLength = 8
            canMessage.SelfReceptionRequest = True

            'Dim i As Byte
            'For i = 0 To 7
            '    canMessage(i) = i
            'Next

            canMessage(0) = &H40
            'canMessage(1) = CByte(mainIndex)  ' &H6
            canMessage(1) = mainIndex Mod 256

            ' mainIndexhi


            ' low8 = Int16 Mod 256
            ' hi8 = Int16 / 256
            'yobyte(mainIndex)
            canMessage(2) = mainIndex >> 8
            ' mainIndexlo
            canMessage(3) = subIndex
            canMessage(4) = data Mod 256
            canMessage(5) = data >> 8
            canMessage(6) = 0
            canMessage(7) = 0
            'msg[1] = (Byte)mainIndex;
            'msg[2] = (Byte)(mainIndex >> 8);
            'msg[3] = subIndex;
            'msg[4] = (Byte)data;
            'msg[5] = (Byte)(data >> 8);
            'msg[6] = 0;
            'msg[7] = 0;
            ' Write the CAN message into the transmit FIFO
            If mWriter.Capacity > 0 Then
                mWriter.SendMessage(canMessage)
            End If



        End If
    End Sub

    Private Sub Button_Write_Sdo_Click(sender As Object, e As EventArgs) Handles Button_Write_Sdo.Click


        If mWriter IsNot Nothing Then

            'IMessageFactory factory = VciServer.Instance().MsgFactory;
            Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
                Dim factory As Ixxat.Vci4.IMessageFactory
                Dim mainIndex As UInt16 = Val("&H" + TextBox1.Text) ' &H60F6

                '  Dim mainIndexhi As Byte = &H40
                ' Dim mainIndexlo As Byte = &H60
                Dim subIndex As Byte = Val("&H" + TextBox2.Text)


                Dim transmit As String = Hex((TextBox3.Text))


                Dim data As Int16 = Val("&H" + transmit)
                'Val("&H" + TextBox3.Text)
                factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

                canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

                ' canMessage = factory.CreateMsg(Ixxat.Vci4.Bal.Can.ICanMessage)

                'ICanMessage canMsg = (ICanMessage)factory.CreateMsg(typeof(Ixxat.Vci4.Bal.Can.ICanMessage));


                canMessage.TimeStamp = 0
            canMessage.Identifier = （"&H" + TextBox15.Text） '&H601
            canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
                canMessage.DataLength = 8
                canMessage.SelfReceptionRequest = True

                'Dim i As Byte
                'For i = 0 To 7
                '    canMessage(i) = i
                'Next

                canMessage(0) = &H22
                'canMessage(1) = CByte(mainIndex)  ' &H6
                canMessage(1) = mainIndex Mod 256

                ' mainIndexhi


                ' low8 = Int16 Mod 256
                ' hi8 = Int16 / 256
                'yobyte(mainIndex)
                canMessage(2) = mainIndex >> 8
                ' mainIndexlo
                canMessage(3) = subIndex
                canMessage(4) = data Mod 256
                canMessage(5) = data >> 8
                canMessage(6) = 0
                canMessage(7) = 0
                'msg[1] = (Byte)mainIndex;
                'msg[2] = (Byte)(mainIndex >> 8);
                'msg[3] = subIndex;
                'msg[4] = (Byte)data;
                'msg[5] = (Byte)(data >> 8);
                'msg[6] = 0;
                'msg[7] = 0;
                ' Write the CAN message into the transmit FIFO
                If mWriter.Capacity > 0 Then
                    mWriter.SendMessage(canMessage)
                End If

            End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'node
        Try
            If DataGridView1.Item(0, 0).ToString IsNot Nothing Then
                TextBox5.Text = (DataGridView1.Item(0, 0).Value).ToString
            Else

                TextBox5.Text = "no"
            End If
        Catch ex As Exception
            ' the can control has leave the scope,
            ' e.g. a plugable interface which was removed
            MessageBox.Show("Enter Something to mainindex1!")
        End Try
        'mian
        Try
            If DataGridView1.Item(1, 0).ToString IsNot Nothing Then
                TextBox6.Text = (DataGridView1.Item(1, 0).Value).ToString
            Else

                TextBox6.Text = "no"
            End If
        Catch ex As Exception
            ' the can control has leave the scope,
            ' e.g. a plugable interface which was removed
            MessageBox.Show("Enter Something to subindex1 !")
        End Try


        'subindex
        Try
            If DataGridView1.Item(2, 0).ToString IsNot Nothing Then
                TextBox7.Text = (DataGridView1.Item(2, 0).Value).ToString
            Else

                TextBox7.Text = "no"
            End If
        Catch ex As Exception
            ' the can control has leave the scope,
            ' e.g. a plugable interface which was removed
            MessageBox.Show("Enter Something to data1!")
        End Try

        'data
        Try
            If DataGridView1.Item(3, 0).ToString IsNot Nothing Then
                TextBox8.Text = (DataGridView1.Item(3, 0).Value).ToString
            Else

                TextBox8.Text = "no"
            End If
        Catch ex As Exception
            ' the can control has leave the scope,
            ' e.g. a plugable interface which was removed
            MessageBox.Show("Enter Something to data1!")
        End Try

        If mWriter IsNot Nothing Then

            'IMessageFactory factory = VciServer.Instance().MsgFactory;
            Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
            Dim factory As Ixxat.Vci4.IMessageFactory
            Dim mainIndex As UInt16 = Val("&H" + TextBox6.Text) ' &H60F6
            Dim nodeid As UInt16 = （"&H" + TextBox5.Text）

            '  Dim mainIndexhi As Byte = &H40
            ' Dim mainIndexlo As Byte = &H60
            Dim subIndex As Byte = Val("&H" + TextBox7.Text)


            Dim transmit As String = Hex((TextBox8.Text))


            Dim data As Int16 = Val("&H" + transmit)
            'Val("&H" + TextBox3.Text)
            factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

            canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

            ' canMessage = factory.CreateMsg(Ixxat.Vci4.Bal.Can.ICanMessage)

            'ICanMessage canMsg = (ICanMessage)factory.CreateMsg(typeof(Ixxat.Vci4.Bal.Can.ICanMessage));


            canMessage.TimeStamp = 0
            canMessage.Identifier = nodeid
            '&H601
            canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
            canMessage.DataLength = 8
            canMessage.SelfReceptionRequest = True

            'Dim i As Byte
            'For i = 0 To 7
            '    canMessage(i) = i
            'Next

            canMessage(0) = &H22
            'canMessage(1) = CByte(mainIndex)  ' &H6
            canMessage(1) = mainIndex Mod 256

            ' mainIndexhi


            ' low8 = Int16 Mod 256
            ' hi8 = Int16 / 256
            'yobyte(mainIndex)
            canMessage(2) = mainIndex >> 8
            ' mainIndexlo
            canMessage(3) = subIndex
            canMessage(4) = data Mod 256
            canMessage(5) = data >> 8
            canMessage(6) = 0
            canMessage(7) = 0
            'msg[1] = (Byte)mainIndex;
            'msg[2] = (Byte)(mainIndex >> 8);
            'msg[3] = subIndex;
            'msg[4] = (Byte)data;
            'msg[5] = (Byte)(data >> 8);
            'msg[6] = 0;
            'msg[7] = 0;
            ' Write the CAN message into the transmit FIFO
            If mWriter.Capacity > 0 Then
                mWriter.SendMessage(canMessage)
            End If

        End If

    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pausetime As Int32 = 5000
        pausetime = Convert.ToInt32(TextBox4.Text)

        For i As Integer = 0 To RichTextBox1.Lines.Count - 1
            Dim txt As String = Me.RichTextBox1.Lines(i)
            'If txt.Contains("""") Then
            '    txt = txt.Replace("""", """""")
            'End If 

            Dim b As String()
            b = Split(txt, " ")
            Try
                TextBox13.Text = b(4)
                TextBox12.Text = b(3)
                TextBox11.Text = b(2)
                TextBox14.Text = b(1)
                TextBox10.Text = b(0)
            Catch ex As Exception

                MessageBox.Show("Enter Something to data1!")
            End Try

            If mWriter IsNot Nothing Then

                'IMessageFactory factory = VciServer.Instance().MsgFactory;
                Dim canMessage As Ixxat.Vci4.Bal.Can.ICanMessage
                Dim factory As Ixxat.Vci4.IMessageFactory
                Dim mainIndex As UInt16 = Val("&H" + TextBox11.Text) ' &H60F6
                Dim nodeid As UInt16 = （"&H" + TextBox10.Text）


                '  Dim mainIndexhi As Byte = &H40
                ' Dim mainIndexlo As Byte = &H60
                Dim subIndex As Byte = Val("&H" + TextBox12.Text)

                Dim transmit As String = Hex((TextBox13.Text))


                Dim data As Int16 = Val("&H" + transmit)
                'Val("&H" + TextBox3.Text)
                factory = Ixxat.Vci4.VciServer.Instance.MsgFactory

                canMessage = factory.CreateMsg(GetType(Ixxat.Vci4.Bal.Can.ICanMessage))

                ' canMessage = factory.CreateMsg(Ixxat.Vci4.Bal.Can.ICanMessage)

                'ICanMessage canMsg = (ICanMessage)factory.CreateMsg(typeof(Ixxat.Vci4.Bal.Can.ICanMessage));


                canMessage.TimeStamp = 0
                canMessage.Identifier = nodeid
                '&H601
                canMessage.FrameType = Ixxat.Vci4.Bal.Can.CanMsgFrameType.Data
                canMessage.DataLength = 8
                canMessage.SelfReceptionRequest = True

                'Dim i As Byte
                'For i = 0 To 7
                '    canMessage(i) = i
                'Next

                canMessage(0) = "&H" + TextBox14.Text     '&H22
                'canMessage(1) = CByte(mainIndex)  ' &H6
                canMessage(1) = mainIndex Mod 256

                ' mainIndexhi


                ' low8 = Int16 Mod 256
                ' hi8 = Int16 / 256
                'yobyte(mainIndex)
                canMessage(2) = mainIndex >> 8
                ' mainIndexlo
                canMessage(3) = subIndex
                canMessage(4) = data Mod 256
                canMessage(5) = data >> 8
                canMessage(6) = 0
                canMessage(7) = 0
                'msg[1] = (Byte)mainIndex;
                'msg[2] = (Byte)(mainIndex >> 8);
                'msg[3] = subIndex;
                'msg[4] = (Byte)data;
                'msg[5] = (Byte)(data >> 8);
                'msg[6] = 0;
                'msg[7] = 0;
                ' Write the CAN message into the transmit FIFO
                If mWriter.Capacity > 0 Then
                    mWriter.SendMessage(canMessage)
                End If

            End If

            'tmp.Append("SwFromFileStream.Write(""" & txt & """ + vbCrLf)" + vbCrLf)

            Thread.Sleep(pausetime)
            Application.DoEvents()

        Next


    End Sub


    Private Sub labelLastRxMsg_TextChanged(sender As Object, e As EventArgs) Handles labelLastRxMsg.TextChanged
        TextBox9.AppendText(labelLastRxMsg.Text)

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

        Button1.Enabled = True

    End Sub


End Class
