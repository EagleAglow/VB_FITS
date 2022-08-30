Module Module1
    ''
    'Sub HeaderText(HeaderIndex As Integer)

    '    Dim f As New nom.tam.fits.Fits(OpenFileDialog1.FileName)
    '    Dim hduBasic As nom.tam.fits.BasicHDU = f.GetHDU(100)   ' attempt to read large number, see how many we get
    '    Dim hduCount As Integer = f.NumberOfHDUs                ' not valid or error, without previous line!
    '    Dim hduIndex As Integer
    '    Dim hduDesc As String
    '    Dim hduType As String
    '    Dim myImageData As New nom.tam.fits.ImageData
    '    Dim myHeader As New nom.tam.fits.Header

    '    Dim hdu As nom.tam.fits.ImageHDU

    '    Dim myMatrix() As Array
    '    Dim matrixOrder As String
    '    Dim myLayerCount As UInt16
    '    Dim myRowCount As UInt16
    '    Dim myColumnCount As UInt16


    '    ' list hdus
    '    For hduIndex = 0 To hduCount - 1
    '        hduBasic = f.GetHDU(hduIndex)
    '        hduType = hduBasic.GetType.Name
    '        If hduType = "ImageHDU" Then ' verify that we have suitable data
    '            hdu = f.GetHDU(hduIndex)
    '            myImageData = hdu.Data
    '            myLayerCount = 1

    '            If Not (myImageData.DataArray Is Nothing) Then
    '                myMatrix = myImageData.Tiler.CompleteImage
    '                ' myImageData is array, or matrix (array of array of array, etc.), order (number of dimensions) not yet known
    '                If VarType(myMatrix) >= vbArray Then
    '                    If VarType(myMatrix(0)) >= vbArray Then
    '                        If VarType(myMatrix(0)(0)) >= vbArray Then
    '                            If VarType(myMatrix(0)(0)(0)) >= vbArray Then
    '                                matrixOrder = "3+"
    '                                hduDesc = Str(hduIndex) & ": " & hduType & " (3D+ array, " & (1 + UBound(myMatrix)) & " array layers)"
    '                            Else
    '                                matrixOrder = "3"
    '                                hduDesc = Str(hduIndex) & ": " & hduType & " (3D array, " & (1 + UBound(myMatrix)) & " layers, " & (1 + UBound(myMatrix(0))) & "x" & (1 + UBound(myMatrix(0)(0))) & " elements)"
    '                            End If
    '                        Else
    '                            matrixOrder = "2"
    '                            hduDesc = Str(hduIndex) & ": " & hduType & " (2D array, " & (1 + UBound(myMatrix)) & "x" & (1 + UBound(myMatrix(0))) & " elements)"
    '                        End If
    '                    Else
    '                        matrixOrder = "1"
    '                        hduDesc = Str(hduIndex) & ": " & hduType & " (1D array, " & (1 + UBound(myMatrix)) & " elements)"
    '                    End If
    '                Else
    '                    hduDesc = Str(hduIndex) & ": " & hduType & " (Data is not an array)"
    '                End If
    '            Else
    '                hduDesc = Str(hduIndex) & ": " & hduType & " (Data is not defined)"
    '            End If
    '        Else
    '            hduDesc = Str(hduIndex) & ": " & hduType
    '        End If
    '        ListBox2.Items.Add(hduDesc)
    '    Next

    '    If hduCount < 1 Then   ' problem
    '        MsgBox("No Basic HDUs were found!")
    '        Exit Sub
    '    End If

    '    ListBox2.SelectedIndex = 0

    '    hdu = f.GetHDU(0)  ' get first HDU

    '    'Dim nAxes As Short = hdu.Axes.Count
    '    'Dim aZero As UInt32 = hdu.Axes(0)
    '    'Dim aOne As UInt32 = hdu.Axes(1)
    '    '            Dim aTwo As UInt32 = hdu.Axes(2)
    '    '            MsgBox("BITPIX: " & hdu.BitPix)
    '    '            MsgBox("Number of axes: " & nAxes)
    '    '            MsgBox("Axis 0 element count: " & aZero)
    '    '            MsgBox("Axis 1 element count: " & aOne)
    '    '            MsgBox("Axis 2 element count: " & aTwo)

    '    myImageData = hdu.Data
    '    myHeader = hdu.Header
    '    Dim cardCount As Integer = myHeader.NumberOfCards
    '    '            MsgBox("Cards: " & cardCount)
    '    Dim card As Integer
    '    For card = 0 To cardCount - 1
    '        ListBox1.Items.Add(myHeader.GetCard(card).ToString())
    '    Next

    '    Exit Sub ' ==================================================================================== debug


    '    myMatrix = myImageData.Tiler.CompleteImage ' supposedly, can modify Tiler parameters to only pull part of myImageData


    '    ' arbitrary terminology - may or may not match FITS concepts
    '    Dim myImageArray() As Array  ' for three axes, will be array of "layer" arrays of "row" arrays of "column" array of pixels
    '    Dim myLayer() As Array   'First layer - For 2D data, interpret as greyscale; for 3D data of four layers, interpret As luminance (and ignore it)
    '    ' FITS data options...
    '    '   unsigned 8 bit integer (BITPIX=8) => Byte
    '    '   16 bit twos complement integer (BITPIX=16) => Short
    '    '   32 bit twos complement integer (BITPIX=32) => Integer
    '    '   32 bit IEEE floating point format (BITPIX=-32) => Single
    '    '   64 bit IEEE floating point format (BITPIX=-64) => Double
    '    ' all are converted to double when processing


    '    myImageArray = myImageData.Tiler.CompleteImage ' supposedly, can modify Tiler parameters to only pull part of myImageData

    '    ' handle 2D and 3D data - not ready for 1D data or 4D+ data
    '    'If nAxes = 2 Then ' if two axes, copy myImageArray into myLayer
    '    If matrixOrder = 2 Then ' if two axes, copy myImageArray into myLayer
    '        myLayer = myImageArray
    '        myLayerCount = 1
    '    Else ' assume nAxes = 3
    '        ' zero based arrays
    '        myLayerCount = 1 + myImageArray.GetUpperBound(0)
    '        myLayer = myImageArray(0) ' use first layer - future, maybe try selecting  and/or combining layers
    '    End If
    '    '            MsgBox("Layers: " & myLayerCount)

    '    myRowCount = 1 + myLayer.GetUpperBound(0)
    '    '            MsgBox("Rows: " & myRowCount)
    '    myColumnCount = 1 + myLayer(0).GetUpperBound(0)
    '    '            MsgBox("Columns: " & myColumnCount)

    '    Dim bPixel As Byte    ' RGB color data
    '    Dim maxPixel As Double ' maximum value of aPixel, used to scale conversion from aPixel to bPixel
    '    Dim minPixel As Double ' minimum value of aPixel, used to scale conversion from aPixel to bPixel

    '    Dim myFormat As System.Drawing.Imaging.PixelFormat
    '    ' see: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=netframework-4.7.2
    '    ' Pixel format is 24 bits per pixel; 8 bits each are used for the red, green, and blue components, no Alpha.
    '    myFormat = 137224  ' Format24bppRgb
    '    Dim myBitmap As New Bitmap(myColumnCount, myRowCount, myFormat)
    '    Dim myColor As Color

    '    ' from: https://docs.astropy.org/en/stable/io/fits/
    '    ' Unsigned integers - Due to the FITS format's Fortran origins, FITS does not natively support unsigned integer data
    '    ' in images or tables.  However, there is a common convention to store unsigned integers as signed integers, along
    '    ' with a shift instruction (a BZERO keyword with value 2 ** (BITPIX - 1)) to shift up all signed integers to unsigned
    '    ' integers. For example, when writing the value 0 as an unsigned 32-bit integer, it is stored in the FITS file as -32768,
    '    ' along with the header keyword BZERO = 32768.




    '    ' odd bug in 16 bit file (w0bw0103t_c0h.fit), minimum was -32766, but image looked better (had black background) when
    '    ' every pixel was multiplied by -1.  So, try fixing two's complement???
    '    ' need another sample file - I think this one is bad (or I just don't understand...)

    '    'If hdu.BZero = "32768" Then ' note - should use different value for 32bit!
    '    'If ((hdu.BitPix = "16") Or (hdu.BitPix = "32")) Then ' fix
    '    '    For myY = 0 To myRowCount - 1
    '    '        For myX = 0 To myColumnCount - 1
    '    '            If myLayer(myY)(myX) < 0 Then
    '    '                myLayer(myY)(myX) = (myLayer(myY)(myX) + 32768)
    '    '            Else
    '    '                myLayer(myY)(myX) = (myLayer(myY)(myX))
    '    '            End If
    '    '        Next
    '    '    Next
    '    'End If
    '    'End If


    '    ' get highest/lowest value of array elements, use double to handle any element type
    '    maxPixel = -1.0E+308
    '    minPixel = 1.0E+308

    '    If myLayerCount = 1 Then ' just process myLayer
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                If CDbl(myLayer(myY)(myX)) > maxPixel Then
    '                    maxPixel = CDbl(myLayer(myY)(myX))
    '                End If
    '                If CDbl(myLayer(myY)(myX)) < minPixel Then
    '                    minPixel = CDbl(myLayer(myY)(myX))
    '                End If
    '            Next
    '        Next
    '        ' scale values and fill in bitmap
    '        Dim temp As Int32
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                temp = CInt(255.0 * (myLayer(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If temp > 255 Then temp = 255  ' just in case...
    '                If temp < 0 Then temp = 0  ' just in case...
    '                bPixel = CByte(temp)
    '                myColor = Color.FromArgb(255, bPixel, bPixel, bPixel)
    '                myBitmap.SetPixel(myX, myRowCount - 1 - myY, myColor)   ' invert vertical
    '            Next
    '        Next
    '        ImageBox1.Image = myBitmap
    '    End If

    '    If myLayerCount = 2 Or myLayerCount > 4 Then ' complain
    '        MsgBox("File needs 1, 3 or 4 layers")
    '    End If

    '    If myLayerCount = 3 Then ' process layers as RGB
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                For myZ = 0 To 2
    '                    'If CDbl(myImageArray(myY)(myX)(myZ) > maxPixel) Then
    '                    If CDbl(myImageArray(myZ)(myY)(myX) > maxPixel) Then
    '                        maxPixel = CDbl(myImageArray(myZ)(myY)(myX))
    '                    End If
    '                    If CDbl(myImageArray(myZ)(myY)(myX) < minPixel) Then
    '                        minPixel = CDbl(myImageArray(myZ)(myY)(myX))
    '                    End If
    '                Next
    '            Next
    '        Next
    '        ' scale values and fill in bitmap, assume mapped as BGR
    '        Dim tempR As Int32
    '        Dim tempG As Int32
    '        Dim tempB As Int32
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                tempR = CInt(255.0 * (myImageArray(2)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempR > 255 Then tempR = 255  ' just in case...
    '                If tempR < 0 Then tempR = 0  ' just in case...
    '                tempG = CInt(255.0 * (myImageArray(1)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempG > 255 Then tempG = 255  ' just in case...
    '                If tempG < 0 Then tempG = 0  ' just in case...
    '                tempB = CInt(255.0 * (myImageArray(0)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempB > 255 Then tempB = 255  ' just in case...
    '                If tempB < 0 Then tempB = 0  ' just in case...
    '                myColor = Color.FromArgb(255, CByte(tempR), CByte(tempG), CByte(tempB))

    '                myBitmap.SetPixel(myX, myRowCount - 1 - myY, myColor)   ' invert vertical
    '            Next
    '        Next
    '        ImageBox1.Image = myBitmap
    '    End If

    '    If myLayerCount = 4 Then ' process layers as BGRL, but only use BGR
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                For myZ = 0 To 2
    '                    'If CDbl(myImageArray(myY)(myX)(myZ) > maxPixel) Then
    '                    If CDbl(myImageArray(myZ)(myY)(myX) > maxPixel) Then
    '                        maxPixel = CDbl(myImageArray(myZ)(myY)(myX))
    '                    End If
    '                    If CDbl(myImageArray(myZ)(myY)(myX) < minPixel) Then
    '                        minPixel = CDbl(myImageArray(myZ)(myY)(myX))
    '                    End If
    '                Next
    '            Next
    '        Next
    '        ' scale values and fill in bitmap
    '        Dim tempR As Int32
    '        Dim tempG As Int32
    '        Dim tempB As Int32
    '        For myY = 0 To myRowCount - 1
    '            For myX = 0 To myColumnCount - 1
    '                tempR = CInt(255.0 * (myImageArray(2)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempR > 255 Then tempR = 255  ' just in case...
    '                If tempR < 0 Then tempR = 0  ' just in case...
    '                tempG = CInt(255.0 * (myImageArray(1)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempG > 255 Then tempG = 255  ' just in case...
    '                If tempG < 0 Then tempG = 0  ' just in case...
    '                tempB = CInt(255.0 * (myImageArray(0)(myY)(myX) - minPixel) / (maxPixel - minPixel))
    '                If tempB > 255 Then tempB = 255  ' just in case...
    '                If tempB < 0 Then tempB = 0  ' just in case...
    '                myColor = Color.FromArgb(255, CByte(tempR), CByte(tempG), CByte(tempB))

    '                myBitmap.SetPixel(myX, myRowCount - 1 - myY, myColor)   ' invert vertical
    '            Next
    '        Next
    '        ImageBox1.Image = myBitmap
    '    End If

    '    MsgBox(myLayerCount & " Layers, Pixel Min/Max: " & minPixel & " / " & maxPixel)
    '    End If

    'End Sub



End Module
