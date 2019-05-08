Imports System.ComponentModel

Public Class Form1
    Private ReadOnly _messageProvider As New MessageProvider

    Private _originMessageData As OriginMessageData

    Private Sub AddTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTextToolStripMenuItem.Click
        RootPanel.SuspendLayout()
        For Each control In GetControls()
            control.Text = "==" & control.Text & "=="
        Next
        RootPanel.ResumeLayout(True)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RootPanel.SuspendLayout()
        For Each control In GetControls()
            control.Text = control.Text.Trim("="c)
        Next
        RootPanel.ResumeLayout(True)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim filePath As String
            Using openFileDialog As New OpenFileDialog
                openFileDialog.Multiselect = False
                openFileDialog.Filter = "Message|*.xml"

                If openFileDialog.ShowDialog(Me) <> DialogResult.OK Then Return

                filePath = openFileDialog.FileName
            End Using

            Dim message = _messageProvider.LoadMessage(filePath)

            FillUIContrlos(message)

            _originMessageData = New OriginMessageData(filePath, message)
        Catch ex As Exception
            MessageBox.Show(Me,
                            ex.Message,
                            "Unexpected error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveButton.Click, SaveAsToolStripMenuItem.Click
        Try
            Dim filePath As String
            If sender Is SaveAsToolStripMenuItem OrElse _originMessageData Is Nothing Then
                Using saveFileDialog As New SaveFileDialog
                    saveFileDialog.Filter = "Message|*.xml"

                    If saveFileDialog.ShowDialog(Me) <> DialogResult.OK Then Return

                    filePath = saveFileDialog.FileName
                End Using
            Else
                filePath = _originMessageData.FilePath
            End If

            Dim message = GetMessage()

            _messageProvider.SaveMessage(filePath, message)

            _originMessageData = New OriginMessageData(filePath, message)
        Catch ex As Exception
            MessageBox.Show(Me,
                            ex.Message,
                            "Unexpected error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        If _originMessageData IsNot Nothing Then
            Dim message = GetMessage()
            If Not message.Equals(_originMessageData.Message) Then
                Dim result = MessageBox.Show(Me,
                                             "The current message data has not been save." & vbNewLine & "If you click OK it will be lost.",
                                             "Waring!",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Warning)

                If result = MsgBoxResult.Cancel Then
                    e.Cancel = True
                End If
            End If
        End If

        MyBase.OnClosing(e)
    End Sub

    Private Sub FillUIContrlos(message As ZCL_MERE026_IDLE_CAUSE)
        If message?.MT_IDLE_CAUSE?.QMUR IsNot Nothing Then
            With message.MT_IDLE_CAUSE.QMUR
                MandtBox.Text = .MANDT
                QmnumBox.Text = .QMNUM
                FenumBox.Text = .FENUM
                UrnumBox.Text = .URNUM
                ErnamBox.Text = .ERNAM
                ErdatPicker.Text = .ERDAT
                AenamBox.Text = .AENAM
                AedatPicker.Text = .AEDAT
                UrtxtBox.Text = .URTXT
                UrkatBox.Text = .URKAT
                UrgrpBox.Text = .URGRP
                UrcodBox.Text = .URCOD
                UrverBox.Text = .URVER
                IndtxBox.Text = .INDTX
                KzmlaBox.Text = .KZMLA
                ErzeitPicker.Text = .ERZEIT
                AezeitPicker.Text = .AEZEIT
                VukatBox.Text = .VUKAT
                VugrpBox.Text = .VUGRP
                VucodBox.Text = .VUCOD
                ParvwBox.Text = .PARVW
                ParnrBox.Text = .PARNR
                BautlBox.Text = .BAUTL
                UrmengeBox.Text = .URMENGE
                UrmgeinBox.Text = .URMGEIN
                KzloeschBox.Text = .KZLOESCH
                QurnumBox.Text = .QURNUM
                AutkzBox.Text = .AUTKZ
                InvolvpercBox.Text = .INVOLVPERC
            End With
        End If

        If message?.MT_CAUSE_LONG_TXT?.ZTLINE IsNot Nothing Then
            With message.MT_CAUSE_LONG_TXT.ZTLINE
                PositionIdBox.Text = .POSITION_ID
                TdformatBox.Text = .TDFORMAT
                TdlineBox.Text = .TDLINE
            End With
        End If
    End Sub

    Private Function GetMessage() As ZCL_MERE026_IDLE_CAUSE
        Dim message As New ZCL_MERE026_IDLE_CAUSE With {
            .MT_IDLE_CAUSE = New MT_IDLE_CAUSE With {.QMUR = New QMUR},
            .MT_CAUSE_LONG_TXT = New MT_CAUSE_LONG_TXT With {.ZTLINE = New ZTLINE}}

        With message.MT_IDLE_CAUSE.QMUR
            .MANDT = MandtBox.Text
            .QMNUM = QmnumBox.Text
            .FENUM = FenumBox.Text
            .URNUM = UrnumBox.Text
            .ERNAM = ErnamBox.Text
            .ERDAT = ErdatPicker.Text
            .AENAM = AenamBox.Text
            .AEDAT = AedatPicker.Text
            .URTXT = UrtxtBox.Text
            .URKAT = UrkatBox.Text
            .URGRP = UrgrpBox.Text
            .URCOD = UrcodBox.Text
            .URVER = UrverBox.Text
            .INDTX = IndtxBox.Text
            .KZMLA = KzmlaBox.Text
            .ERZEIT = ErzeitPicker.Text
            .AEZEIT = AezeitPicker.Text
            .VUKAT = VukatBox.Text
            .VUGRP = VugrpBox.Text
            .VUCOD = VucodBox.Text
            .PARVW = ParvwBox.Text
            .PARNR = ParnrBox.Text
            .BAUTL = BautlBox.Text
            .URMENGE = UrmengeBox.Text
            .URMGEIN = UrmgeinBox.Text
            .KZLOESCH = KzloeschBox.Text
            .QURNUM = QurnumBox.Text
            .AUTKZ = AutkzBox.Text
            .INVOLVPERC = InvolvpercBox.Text
        End With

        With message.MT_CAUSE_LONG_TXT.ZTLINE
            .POSITION_ID = PositionIdBox.Text
            .TDFORMAT = TdformatBox.Text
            .TDLINE = TdlineBox.Text
        End With

        Return message
    End Function

    Private Function GetControls() As Control()
        Return New Control() {
            MandtLabel,
            QmnumLabel,
            FenumLabel,
            UrnumLabel,
            ErnamLabel,
            ErdatLabel,
            AenamLabel,
            AedatLabel,
            UrtxtLabel,
            UrkatLabel,
            UrgrpLabel,
            UrcodLabel,
            UrverLabel,
            IndtxLabel,
            KzmlaLabel,
            ErzeitLabel,
            AezeitLabel,
            VukatLabel,
            VugrpLabel,
            VucodLabel,
            ParvwLabel,
            ParnrLabel,
            BautlLabel,
            UrmengeLabel,
            UrmgeinLabel,
            KzloeschLabel,
            QurnumLabel,
            AutkzLabel,
            InvolvpercLabel,
            PositionIdLabel,
            TdformatLabel,
            TdlineLabel,
            SaveButton,
            CloseButton}
    End Function
End Class
