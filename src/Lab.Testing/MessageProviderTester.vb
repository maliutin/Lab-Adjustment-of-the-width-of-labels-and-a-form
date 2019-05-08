Imports System.IO

Imports NUnit.Framework

Imports Lab.MessageEditing

Public Class MessageProviderTester
    Private _messageProvider As MessageProvider

    <SetUp>
    Public Sub SetUp()
        _messageProvider = New MessageProvider()
    End Sub

    <Test>
    Public Sub Test01_Load()
        Dim template = "<?xml version='1.0' encoding='utf-16'?>
<asx:abap xmlns:asx='http://www.sap.com/abapxml' version='1.0'>
  <asx:values>
    <X-MLDAT>2019-04-18</X-MLDAT>
    <X-MLTIM>11:55:51</X-MLTIM>
    <REF href='#o90'/>
  </asx:values>
  <asx:heap xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:abap='http://www.sap.com/abapxml/types/built-in' xmlns:cls='http://www.sap.com/abapxml/classes/global' xmlns:dic='http://www.sap.com/abapxml/types/dictionary'>
    <cls:ZCL_MERE026_IDLE_CAUSE id='o90'>
      <ZCL_MERE026_IDLE_CAUSE>
        <MT_IDLE_CAUSE>
          <QMUR>
            <MANDT>400</MANDT>
            <QMNUM>000012838398</QMNUM>
            <FENUM>0001</FENUM>
            <URNUM>0001</URNUM>
            <ERNAM>10611073</ERNAM>
            <ERDAT>2018-07-31</ERDAT>
            <AENAM>10600263</AENAM>
            <AEDAT>2018-08-03</AEDAT>
            <URTXT/>
            <URKAT>5</URKAT>
            <URGRP>STOIR2</URGRP>
            <URCOD>TO03</URCOD>
            <URVER>000001</URVER>
            <INDTX>X</INDTX>
            <KZMLA>R</KZMLA>
            <ERZEIT>20:07:00</ERZEIT>
            <AEZEIT>18:43:24</AEZEIT>
            <VUKAT/>
            <VUGRP/>
            <VUCOD/>
            <PARVW/>
            <PARNR/>
            <BAUTL/>
            <URMENGE>0.0</URMENGE>
            <URMGEIN/>
            <KZLOESCH/>
            <QURNUM>0001</QURNUM>
            <AUTKZ/>
            <INVOLVPERC>000</INVOLVPERC>
          </QMUR>
        </MT_IDLE_CAUSE>
        <MT_CAUSE_LONG_TXT>
          <ZTLINE>
            <POSITION_ID>0001</POSITION_ID>
            <TDFORMAT>*</TDFORMAT>
            <TDLINE>Смещение колосника аглодробилки из проектного положения.</TDLINE>
          </ZTLINE>
        </MT_CAUSE_LONG_TXT>
        <G_MESSAGE_ID>000012838398</G_MESSAGE_ID>
        <G_POSITION_ID>0001</G_POSITION_ID>
      </ZCL_MERE026_IDLE_CAUSE>
    </cls:ZCL_MERE026_IDLE_CAUSE>
  </asx:heap>
</asx:abap>
"

        Dim message As ZCL_MERE026_IDLE_CAUSE

        Using memoryStream As New MemoryStream
            Dim streamWriter As New StreamWriter(memoryStream, Text.Encoding.Unicode)
            streamWriter.Write(template)
            streamWriter.Flush()

            memoryStream.Position = 0

            message = _messageProvider.LoadMessage(memoryStream)
        End Using

        Assert.That(message, [Is].Not.Null)
        With message
            Assert.That(.MT_IDLE_CAUSE, [Is].Not.Null)
            With .MT_IDLE_CAUSE
                Assert.That(.QMUR, [Is].Not.Null)
                With .QMUR
                    Assert.That(.MANDT, [Is].EqualTo("400"))
                    'and etc.
                End With
            End With
            Assert.That(.MT_CAUSE_LONG_TXT, [Is].Not.Null)
            With .MT_CAUSE_LONG_TXT
                Assert.That(.ZTLINE, [Is].Not.Null)
                With .ZTLINE
                    Assert.That(.POSITION_ID, [Is].EqualTo("0001"))
                    'and etc.
                End With
            End With
        End With
    End Sub

    <Test>
    Public Sub Test02_Save()
        Dim message As New ZCL_MERE026_IDLE_CAUSE With {
            .MT_IDLE_CAUSE = New MT_IDLE_CAUSE With {
                .QMUR = New QMUR With {
                    .MANDT = "400",
                    .QMNUM = "000012838398",
                    .FENUM = "1",
                    .URNUM = "1",
                    .ERNAM = "10611073",
                    .ERDAT = "2018-07-31",
                    .AENAM = "10600263",
                    .AEDAT = "2018-08-03",
                    .URKAT = "5",
                    .URGRP = "STOIR2",
                    .URCOD = "TO03",
                    .URVER = "000001",
                    .INDTX = "X",
                    .KZMLA = "R",
                    .ERZEIT = "20:07:00",
                    .AEZEIT = "18:43:24",
                    .URMENGE = "0.0",
                    .QURNUM = "0001",
                    .INVOLVPERC = "000"
                }
            },
            .MT_CAUSE_LONG_TXT = New MT_CAUSE_LONG_TXT With {
                .ZTLINE = New ZTLINE With {
                    .POSITION_ID = "0001",
                    .TDFORMAT = "*",
                    .TDLINE = "Смещение колосника аглодробилки из проектного положения."
                }
            }
        }

        Using memoryStream As New MemoryStream
            _messageProvider.SaveMessage(memoryStream, message)

            memoryStream.Position = 0

            Using reader As New StreamReader(memoryStream)
                Dim text = reader.ReadToEnd()
                Console.WriteLine(text)
            End Using
        End Using
    End Sub
End Class
