Imports System.Configuration
Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Cyotek.Windows.Forms
Imports Microsoft.VisualBasic.Devices
Imports nom.tam.fits

Module Engine

    Public fileNameFITS As String
    Public fileFITS As nom.tam.fits.Fits
    Public fileIO As nom.tam.util.BufferedFile
    Public fileFITS2 As nom.tam.fits.Fits
    Public fileIO2 As nom.tam.util.BufferedFile


    Public hduBasic As nom.tam.fits.BasicHDU
    Public hduImage As nom.tam.fits.ImageHDU
    Public hduAsciiTable As nom.tam.fits.AsciiTableHDU
    Public hduBinaryTable As nom.tam.fits.BinaryTableHDU
    Public hduUndefined As nom.tam.fits.UndefinedHDU



    Public hduCount As Integer
    Public hduIndex As Integer
    Public hduDesc As String
    Public hduType As String
    Public myImageData As New nom.tam.fits.ImageData
    Public myHeader As New nom.tam.fits.Header


    '    Public myMatrix() As Array   ' defined locally, does not need to be Public
    Public matrixOrder As Integer
    Public myLayerCount As UInt16
    Public myRowCount As UInt16
    Public myColumnCount As UInt16

    Public hduLayerCount(99) As Integer       ' keep track of hdus with image data. Picked 100 max, due to code in library for getting count of basic hdus).
    Public hduTypeName(99) As String


    ' example: three hdus, first with a 2D image, second with a 3D matrix (assumed to be a stack of four 2D images), third with no image
    ' hduLayerCount would be: [ 1, 4, 0 ]



    ' load file, parse content
    Sub OpenFITS(strFileName As String)
        Dim msg As String
        fileIO = New nom.tam.util.BufferedFile(strFileName, IO.FileAccess.ReadWrite, IO.FileShare.ReadWrite)
        fileFITS = New nom.tam.fits.Fits(fileIO)
        ' see how many hdus we can read
        Dim h As BasicHDU
        For hduCount = 0 To 99   ' note that 100 is the size of class FITS property ArrayList
            On Error Resume Next
            h = fileFITS.ReadHDU()
            If Err.Number <> 0 Then  ' some problem
                msg = "Error Number: " & Err.Number & vbCrLf & "File may be wrong type, wrong format or corrupted!" & vbCrLf & " (" & hduCount & " hdus were successfully read)"
                MsgBox(msg)
                On Error GoTo 0
                Exit For
            End If
            If (h Is Nothing) Then
                Exit For
            End If
        Next

        Dim hduIndex As Integer
        Dim hduDesc As String
        '        Dim hduType As String  ' already Public
        Dim myImageData As New nom.tam.fits.ImageData
        Dim myHeader As New nom.tam.fits.Header

        'Dim hduImage As nom.tam.fits.ImageHDU  ' defined Public

        Dim myMatrix() As Array

        ' list hdus
        For hduIndex = 0 To hduCount - 1
            hduLayerCount(hduIndex) = 0    ' unless changed below - this is used to list layers in ListBox3
            hduBasic = fileFITS.GetHDU(hduIndex)
            hduType = hduBasic.GetType.Name
            hduTypeName(hduIndex) = hduType
            If hduType = "ImageHDU" Then ' verify that we have suitable data
                hduImage = fileFITS.GetHDU(hduIndex)
                matrixOrder = 0         ' unless changed below
                myImageData = hduImage.Data

                If Not (myImageData.DataArray Is Nothing) Then
                    myMatrix = myImageData.Tiler.CompleteImage


                    ' myImageData is array, or matrix (array of array of array, etc.), order (number of dimensions) not yet known
                    If VarType(myMatrix) >= vbArray Then
                        If VarType(myMatrix(0)) >= vbArray Then
                            If VarType(myMatrix(0)(0)) >= vbArray Then
                                If VarType(myMatrix(0)(0)(0)) >= vbArray Then
                                    matrixOrder = 4
                                    hduDesc = Str(hduIndex) & ": " & hduType & " (4D, or more, array, " & (1 + UBound(myMatrix)) & " array layers)"
                                Else
                                    matrixOrder = 3
                                    hduDesc = Str(hduIndex) & ": " & hduType & " (3D array, " & (1 + UBound(myMatrix)) & " layers, " & (1 + UBound(myMatrix(0))) & "x" & (1 + UBound(myMatrix(0)(0))) & " elements)"
                                    hduLayerCount(hduIndex) = (1 + UBound(myMatrix))
                                End If
                            Else
                                matrixOrder = 2
                                hduDesc = Str(hduIndex) & ": " & hduType & " (2D array, " & (1 + UBound(myMatrix)) & "x" & (1 + UBound(myMatrix(0))) & " elements)"
                                hduLayerCount(hduIndex) = 1
                            End If
                        Else
                            matrixOrder = 1
                            hduDesc = Str(hduIndex) & ": " & hduType & " (1D array, " & (1 + UBound(myMatrix)) & " elements)"
                        End If
                    Else
                        hduDesc = Str(hduIndex) & ": " & hduType & " (Data is not an array)"
                    End If
                Else
                    hduDesc = Str(hduIndex) & ": " & hduType & " (Data is not defined)"
                End If
            Else
                hduDesc = Str(hduIndex) & ": " & hduType
            End If
            Form1.ListBoxHDUs.Items.Add(hduDesc)
            Form1.ListBoxHDUs.Update()                ' possible problem here, displays slowly or too late
        Next

        Dim i As Integer

        If hduCount < 1 Then   ' problem
            MsgBox("No Basic HDUs were found!")
        Else
            Form1.ListBoxLayers.Items.Clear()
            If hduLayerCount(0) > 0 Then
                For i = 0 To hduLayerCount(0) - 1
                    Form1.ListBoxLayers.Items.Add(Str(i))
                Next
            End If
        End If

    End Sub

    Sub SaveFITS()
        Dim strFileName2 As String
        strFileName2 = Form1.TextBox1.Text
        If fileNameFITS = strFileName2 Then  ' write back to original file
            fileIO.Position = 0
            fileFITS.Write(fileIO)
            fileIO.Close()
        Else                                 ' write to different file
            fileFITS2 = New nom.tam.fits.Fits
            fileFITS2 = fileFITS
            fileIO2 = New nom.tam.util.BufferedFile(strFileName2, IO.FileAccess.ReadWrite, IO.FileShare.ReadWrite)
            fileFITS2.Write(fileIO2)
            fileIO2.Close()
            fileIO.Close()
        End If
        MsgBox("Data written to:" & vbCrLf & strFileName2)
    End Sub


    ' get cards for selected hdu index
    Sub ReadCards(whichHDU As Integer)
        Form1.ListBoxCards.Items.Clear()
        myHeader = Nothing

        If hduTypeName(whichHDU) = "ImageHDU" Then
            hduImage = fileFITS.GetHDU(whichHDU)
            myHeader = hduImage.Header             ' apparently, ImageHDU always has a header?
        Else
            If hduTypeName(whichHDU) = "UndefinedHDU" Then
                hduUndefined = fileFITS.GetHDU(whichHDU)  ' apparently, always has a header?
                myHeader = hduUndefined.Header
            Else
                If hduTypeName(whichHDU) = "AsciiTableHDU" Then
                    hduAsciiTable = fileFITS.GetHDU(whichHDU)
                    If hduAsciiTable.HasHeader Then
                        myHeader = hduAsciiTable.Header
                    Else
                        Exit Sub   ' nothing to read
                    End If
                Else
                    If hduTypeName(whichHDU) = "BinaryTableHDU" Then
                        hduBinaryTable = fileFITS.GetHDU(whichHDU)
                        If hduBinaryTable.HasHeader Then
                            myHeader = hduBinaryTable.Header
                        Else
                            Exit Sub  ' nothing to read
                        End If
                    Else
                        Exit Sub  ' nothing to read
                    End If
                End If
            End If
        End If

        Dim cardCount As Integer = myHeader.NumberOfCards
        '            MsgBox("Cards: " & cardCount)
        Dim card As Integer
        If cardCount > 0 Then
            For card = 0 To cardCount - 1
                Form1.ListBoxCards.Items.Add(myHeader.GetCard(card))
                Form1.ListBoxCards.Update()
            Next
        End If
    End Sub

    ' get card for selected hdu index
    Sub ReadCard(whichHDU As Integer, whichCard As Integer)
        ' Note from: https://fits.gsfc.nasa.gov/fits_primer.html
        ' Each header unit contains a sequence of fixed-length 80-character keyword records which have the general form:
        '        KEYNAME = value / comment String
        ' The keyword names may be up To 8 characters Long And can only contain uppercase letters A To Z, the digits 0 To 9,
        ' the hyphen, And the underscore character. The keyword name Is (usually) followed by an equals sign And a space
        ' character in columns 9 And 10 of the record, followed by the value of the keyword which may be either an integer,
        ' a floating point number, a complex value (i.e., a pair of numbers), a character string (enclosed in single quotes),
        ' Or a Boolean value (the letter T Or F). Some keywords, (e.g., COMMENT And HISTORY) are Not followed by an equals
        ' sign And in that case columns 9 - 80 of the record may contain any string of ASCII text.

        ' ---------------- fix in future? ---------- this duplicates code in "ReadCards"

        myHeader = Nothing


        If hduTypeName(whichHDU) = "ImageHDU" Then
            hduImage = fileFITS.GetHDU(whichHDU)
            myHeader = hduImage.Header             ' apparently, ImageHDU always has a header?
        Else
            If hduTypeName(whichHDU) = "UndefinedHDU" Then
                hduUndefined = fileFITS.GetHDU(whichHDU)  ' apparently, always has a header?
                myHeader = hduUndefined.Header
            Else
                If hduTypeName(whichHDU) = "AsciiTableHDU" Then
                    hduAsciiTable = fileFITS.GetHDU(whichHDU)
                    If hduAsciiTable.HasHeader Then
                        myHeader = hduAsciiTable.Header
                    Else
                        Exit Sub   ' nothing to read
                    End If
                Else
                    If hduTypeName(whichHDU) = "BinaryTableHDU" Then
                        hduBinaryTable = fileFITS.GetHDU(whichHDU)
                        If hduBinaryTable.HasHeader Then
                            myHeader = hduBinaryTable.Header
                        Else
                            Exit Sub  ' nothing to read
                        End If
                    Else
                        Exit Sub  ' nothing to read
                    End If
                End If
            End If
        End If

        Dim myCardText As String

        myCardText = myHeader.GetCard(whichCard)
        Form1.TextBox3.Clear()
        Form1.TextBox4.Clear()
        Form1.TextBox5.Clear()

        Form1.TextBox3.Text = Trim(Left(myCardText, 8))
        If Mid(myCardText, 9, 1) = "=" Then   ' probably not "COMMENT" or "HISTORY"
            If Mid(myCardText, 32, 2) = "/ " Then   ' seems to have a trailing comment
                Form1.TextBox4.Text = Trim(Mid(myCardText, 10, 22))
                Form1.TextBox5.Text = Trim(Mid(myCardText, 33))
            Else
                Form1.TextBox4.Text = Trim(Mid(myCardText, 10))
            End If
        Else
            If ((UCase(Trim(Left(myCardText, 7))) = "HISTORY") Or (UCase(Trim(Left(myCardText, 7))) = "COMMENT")) Then
                Form1.TextBox5.Text = Mid(myCardText, 9)
            Else
                If Mid(myCardText, 32, 1) = "/" Then   ' no key, no value, but seems to have a trailing comment
                    Form1.TextBox5.Text = Trim(Mid(myCardText, 33))
                Else
                    MsgBox("Problem Parsing: " & myCardText)
                End If
            End If
        End If

    End Sub

    Sub WriteCard(whichHDU As Integer, cardText As String)
        cardText = Trim(cardText)
        Dim myHeaderCard As New nom.tam.fits.HeaderCard(cardText)

        myHeader = Nothing


        ' ---------------- fix in future? ---------- this duplicates code in "ReadCards"
        If hduTypeName(whichHDU) = "ImageHDU" Then
            hduImage = fileFITS.GetHDU(whichHDU)
            myHeader = hduImage.Header             ' apparently, ImageHDU always has a header?
            myHeader.AddCard(myHeaderCard)  ' overwrites if key/value exists
            fileFITS.InsertHDU(hduImage, whichHDU)
            fileFITS.DeleteHDU(whichHDU)
        Else
            If hduTypeName(whichHDU) = "UndefinedHDU" Then
                hduUndefined = fileFITS.GetHDU(whichHDU)  ' apparently, always has a header?
                myHeader = hduUndefined.Header
                myHeader.AddCard(myHeaderCard)  ' overwrites if key/value exists
                fileFITS.InsertHDU(hduUndefined, whichHDU)
                fileFITS.DeleteHDU(whichHDU)
            Else
                If hduTypeName(whichHDU) = "AsciiTableHDU" Then
                    hduAsciiTable = fileFITS.GetHDU(whichHDU)
                    If hduAsciiTable.HasHeader Then
                        myHeader = hduAsciiTable.Header
                        myHeader.AddCard(myHeaderCard)  ' overwrites if key/value exists
                        fileFITS.InsertHDU(hduAsciiTable, whichHDU)
                        fileFITS.DeleteHDU(whichHDU)
                    Else
                        Exit Sub   ' nowhere to write
                    End If
                Else
                    If hduTypeName(whichHDU) = "BinaryTableHDU" Then
                        hduBinaryTable = fileFITS.GetHDU(whichHDU)
                        If hduBinaryTable.HasHeader Then
                            myHeader = hduBinaryTable.Header
                            myHeader.AddCard(myHeaderCard)  ' overwrites if key/value exists
                            fileFITS.InsertHDU(hduBinaryTable, whichHDU)
                            fileFITS.DeleteHDU(whichHDU)
                        Else
                            Exit Sub   ' nowhere to write
                        End If
                    Else
                        Exit Sub   ' nowhere to write
                    End If
                End If
            End If
        End If

        Call ReadCards(whichHDU)


        '        problem -after saving a card edit, reading cards Is screwed up

    End Sub





    ' get selected image layer from selected hdu
    Sub ReadImage(whichHDU As Integer, whichLayer As Integer)

        ' clear image
        Form1.ImageBox1.Image = Nothing

        If whichLayer < hduLayerCount(whichHDU) Then

            hduImage = fileFITS.GetHDU(whichHDU)
            myImageData = hduImage.Data

            '        myMatrix = myImageData.Tiler.CompleteImage ' supposedly, can modify Tiler parameters to only pull part of myImageData

            ' arbitrary terminology - may or may not match FITS concepts
            Dim myImageArray() As Array  ' for three axes, will be array of "layer" arrays of "row" arrays of "column" array of pixels
            Dim myLayer() As Array


            myImageArray = myImageData.Tiler.CompleteImage ' supposedly, can modify Tiler parameters to only pull part of myImageData

            ' handle 2D and 3D data - not ready for 1D data or 4D+ data
            If matrixOrder = 2 Then ' copy myImageArray into myLayer
                myLayer = myImageArray
                myLayerCount = 1
            End If
            If matrixOrder = 3 Then  ' copy selected layer of myImageArray into myLayer
                myLayerCount = 1 + myImageArray.GetUpperBound(0)
                myLayer = myImageArray(whichLayer) ' ----------------- need to validate whichLayer, or handle error if not valid
            End If

            myRowCount = 1 + myLayer.GetUpperBound(0)
            '            MsgBox("Rows: " & myRowCount)
            myColumnCount = 1 + myLayer(0).GetUpperBound(0)
            '            MsgBox("Columns: " & myColumnCount)

            Dim bPixel As Byte       ' RGB color data
            Dim maxPixel As Double   ' maximum value of aPixel, used to scale conversion from aPixel to bPixel
            Dim minPixel As Double   ' minimum value of aPixel, used to scale conversion from aPixel to bPixel
            Dim tempPixel As Double  ' scaled value of aPixel, used to scale conversion from aPixel to bPixel

            Dim myFormat As System.Drawing.Imaging.PixelFormat
            ' see: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=netframework-4.7.2
            ' Pixel format is 24 bits per pixel; 8 bits each are used for the red, green, and blue components, no Alpha.
            myFormat = 137224  ' Format24bppRgb
            Dim myBitmap As New Bitmap(myColumnCount, myRowCount, myFormat)
            Dim myColor As Color

            ' FITS data options...
            '   unsigned 8 bit integer (BITPIX=8) => Byte
            '   16 bit twos complement integer (BITPIX=16) => Short
            '   32 bit twos complement integer (BITPIX=32) => Integer
            '   32 bit IEEE floating point format (BITPIX=-32) => Single
            '   64 bit IEEE floating point format (BITPIX=-64) => Double
            ' all are converted to double when processing

            ' from: https://docs.astropy.org/en/stable/io/fits/
            ' Unsigned integers - Due to the FITS format's Fortran origins, FITS does not natively support unsigned integer data
            ' in images or tables.  However, there is a common convention to store unsigned integers as signed integers, along
            ' with a shift instruction (a BZERO keyword with value 2 ** (BITPIX - 1)) to shift up all signed integers to unsigned
            ' integers. For example, when writing the value 0 as an unsigned 32-bit integer, it is stored in the FITS file as -32768,
            ' along with the header keyword BZERO = 32768.

            '             This seems to be working with the files from "nrao-tests"

            ' get highest/lowest value of array elements, use double to handle any element type
            maxPixel = -1.0E+308
            minPixel = 1.0E+308

            ' process myLayer for min/max values
            For myY = 0 To myRowCount - 1
                For myX = 0 To myColumnCount - 1
                    If CDbl(myLayer(myY)(myX)) > maxPixel Then
                        maxPixel = CDbl(myLayer(myY)(myX))
                    End If
                    If CDbl(myLayer(myY)(myX)) < minPixel Then
                        minPixel = CDbl(myLayer(myY)(myX))
                    End If
                Next
            Next

            ' scale values and fill in bitmap
            For myY = 0 To myRowCount - 1
                For myX = 0 To myColumnCount - 1
                    tempPixel = 255.0 * (myLayer(myY)(myX) - minPixel) / (maxPixel - minPixel)
                    If tempPixel > 255.0 Then
                        bPixel = 255
                    Else
                        If tempPixel < 0 Then
                            bPixel = 0
                        Else
                            If System.Double.IsNaN(tempPixel) Then
                                myColor = Color.FromArgb(255, 255, 0, 0)  ' red for not a number...
                            Else
                                bPixel = CByte(tempPixel)
                                myColor = Color.FromArgb(255, bPixel, bPixel, bPixel)
                            End If
                        End If
                    End If
                    myBitmap.SetPixel(myX, myRowCount - 1 - myY, myColor)   ' invert vertical
                Next
            Next
            Form1.ImageBox1.Image = myBitmap

        End If
    End Sub



End Module
