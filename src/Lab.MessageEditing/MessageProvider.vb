Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class MessageProvider
    Public Function LoadMessage(filePath As String) As ZCL_MERE026_IDLE_CAUSE
        Using fileStream = File.OpenRead(filePath)
            Return LoadMessage(fileStream)
        End Using
    End Function

    Public Function LoadMessage(stream As Stream) As ZCL_MERE026_IDLE_CAUSE
        Using reader = XmlReader.Create(stream, New XmlReaderSettings With {.IgnoreWhitespace = True, .IgnoreProcessingInstructions = True})
            reader.MoveToContent()
            reader.ReadStartElement("abap", "http://www.sap.com/abapxml")
            reader.Skip()
            reader.ReadStartElement("heap", "http://www.sap.com/abapxml")
            reader.ReadStartElement("ZCL_MERE026_IDLE_CAUSE", "http://www.sap.com/abapxml/classes/global")

            Using messageReader = reader.ReadSubtree()
                messageReader.MoveToContent()

                Dim serializer As New XmlSerializer(GetType(ZCL_MERE026_IDLE_CAUSE))
                Return DirectCast(serializer.Deserialize(messageReader), ZCL_MERE026_IDLE_CAUSE)
            End Using
        End Using

    End Function

    Public Sub SaveMessage(filePath As String, message As ZCL_MERE026_IDLE_CAUSE)
        Using fileStream = File.OpenWrite(filePath)
            SaveMessage(fileStream, message)
        End Using
    End Sub

    Public Sub SaveMessage(stream As Stream, message As ZCL_MERE026_IDLE_CAUSE)
        Using writer = XmlWriter.Create(stream, New XmlWriterSettings With {.CloseOutput = False, .Indent = True})
            writer.WriteStartElement("asx", "abap", "http://www.sap.com/abapxml")
            writer.WriteAttributeString("xmlns", "asx", "", "http://www.sap.com/abapxml")
            writer.WriteAttributeString("version", "1.0")
            writer.WriteStartElement("asx", "values", "http://www.sap.com/abapxml")
            writer.WriteElementString("X-MLDAT", "2019-04-18")
            writer.WriteElementString("X-MLTIM", "11:55:51")
            writer.WriteStartElement("REF")
            writer.WriteAttributeString("href", "#o90")
            writer.WriteEndElement()
            writer.WriteEndElement()

            writer.WriteStartElement("asx", "heap", "http://www.sap.com/abapxml")
            writer.WriteAttributeString("xmlns", "xsd", "", "http://www.w3.org/2001/XMLSchema")
            writer.WriteAttributeString("xmlns", "abap", "", "http://www.sap.com/abapxml/types/built-in")
            writer.WriteAttributeString("xmlns", "cls", "", "http://www.sap.com/abapxml/classes/global")
            writer.WriteAttributeString("xmlns", "dic", "", "http://www.sap.com/abapxml/types/dictionary")
            writer.WriteStartElement("cls", "ZCL_MERE026_IDLE_CAUSE", "http://www.sap.com/abapxml/classes/global")
            writer.WriteAttributeString("id", "o90")
            Dim serializer As New XmlSerializer(GetType(ZCL_MERE026_IDLE_CAUSE))
            serializer.Serialize(writer, message)
            writer.WriteEndElement()
            writer.WriteEndElement()

            writer.Flush()
        End Using
    End Sub
End Class
