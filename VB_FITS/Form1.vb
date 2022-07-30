Public Class Form1
    Private Sub btnCreateImage_Click(sender As Object, e As EventArgs) Handles btnCreateImage.Click
        Dim myWidth As Int32 = 400
        Dim myHeight As Int32 = 300
        Dim myX As Int32
        Dim myY As Int32
        Dim myFormat As System.Drawing.Imaging.PixelFormat
        ' see: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=netframework-4.7.2
        ' greyscale looks good, but ImageBox doesn't seem to like it, and SetPixel fails... so, try this...
        ' Pixel format is 24 bits per pixel; 8 bits each are used for the red, green, and blue components, no Alpha.
        myFormat = 137224  ' Format24bppRgb
        Dim myBitmap As New Bitmap(myWidth, myHeight, myFormat)
        Dim myColor As Color
        For myX = 0 To myWidth - 1
            For myY = 0 To myHeight - 1
                If myX = myY Then
                    myColor = Color.FromArgb(30, 30, 30)
                    myBitmap.SetPixel(myX, myY, myColor)
                End If
                If myX = myY + 1 Then
                    myColor = Color.FromArgb(230, 230, 230)
                    myBitmap.SetPixel(myX, myY, myColor)
                End If
                If myX = myY + 2 Then
                    myColor = Color.Red
                    myBitmap.SetPixel(myX, myY, myColor)
                End If
            Next
        Next
        ImageBox1.Image = myBitmap
    End Sub

    Private Sub btnLoadFile_Click(sender As Object, e As EventArgs) Handles btnLoadFile.Click

        ' see: https://github.com/nom-tam-fits/nom-tam-fits#reading-fits-files

        '   sample file:      w0bw0103t_c0h.fit

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim f As New nom.tam.fits.Fits(OpenFileDialog1.FileName)
            'MsgBox("Number of HDUs: " & f.NumberOfHDUs)  ' zero based???? test file with one HDU returns zero ??

            Dim hdu As nom.tam.fits.ImageHDU = f.GetHDU(0)  ' get first HDU
            Dim nAxes As Short = hdu.Axes.Count
            Dim aZero As UInt32 = hdu.Axes(0)
            Dim aOne As UInt32 = hdu.Axes(1)
            Dim aTwo As UInt32 = hdu.Axes(2)
            MsgBox("BITPIX: " & hdu.BitPix)
            '            MsgBox("Number of axes: " & nAxes)
            '            MsgBox("Axis 0 element count: " & aZero)
            '            MsgBox("Axis 1 element count: " & aOne)
            '            MsgBox("Axis 2 element count: " & aTwo)

            Dim myImageData As New nom.tam.fits.ImageData
            myImageData = hdu.Data

            ' arbitrary terminology - may or may not match FITS concepts
            Dim myImageArray() As Array  ' actually will be array of "layer" arrays of "row" arrays of "column" array of pixels
            Dim myLayer() As Array
            ' FITS data options...
            '   unsigned 8 bit integer (BITPIX=8) => Byte
            '   16 bit signed integer (BITPIX=16) => Short
            '   32 bit twos complement integer (BITPIX=32) => Integer
            '   32 bit IEEE floating point format (BITPIX=-32) => Single
            '   64 bit IEEE floating point format (BITPIX=-64) => Double
            ' to handle that, just convert to double when processing

            Dim myLayerCount As UInt16  ' not used here, maybe later
            Dim myRowCount As UInt16
            Dim myColumnCount As UInt16

            myImageArray = myImageData.Tiler.CompleteImage ' supposedly, can modify Tiler parameters to only pull part of myImageData

            ' assumes zero based arrays
            myLayerCount = 1 + myImageArray.GetUpperBound(0)
            MsgBox("Layers: " & myLayerCount)

            ' use first layer - future, maybe try selecting  and/or combining layers
            myLayer = myImageArray(0)
            myRowCount = 1 + myLayer.GetUpperBound(0)
            MsgBox("Rows: " & myRowCount)
            myColumnCount = 1 + myLayer(0).GetUpperBound(0)
            MsgBox("Columns: " & myColumnCount)

            Dim bPixel As Byte    ' RGB color data
            Dim maxPixel As Double ' maximum value of aPixel, used to scale conversion from aPixel to bPixel
            Dim minPixel As Double ' minimum value of aPixel, used to scale conversion from aPixel to bPixel

            Dim myFormat As System.Drawing.Imaging.PixelFormat
            ' see: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=netframework-4.7.2
            ' greyscale looks good, but ImageBox doesn't seem to like it, and SetPixel has no greyscale method. Instead...
            ' Pixel format is 24 bits per pixel; 8 bits each are used for the red, green, and blue components, no Alpha.
            myFormat = 137224  ' Format24bppRgb
            Dim myBitmap As New Bitmap(myRowCount, myColumnCount, myFormat)
            Dim myColor As Color

            ' get highest/lowest value of aPixel
            maxPixel = -1.0E+308
            minPixel = 1.0E+308
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
            MsgBox("Pixel Min/Max: " & minPixel & " / " & maxPixel)
            ' scale values
            Dim temp As Int32
            For myY = 0 To myRowCount - 1
                For myX = 0 To myColumnCount - 1
                    temp = CInt(255.0 * (myLayer(myY)(myX) - minPixel) / (maxPixel - minPixel))
                    If temp > 255 Then temp = 255  ' just in case...
                    If temp < 0 Then temp = 0  ' just in case...
                    bPixel = CByte(temp)
                    myColor = Color.FromArgb(255, bPixel, bPixel, bPixel)
                    myBitmap.SetPixel(myX, myRowCount - 1 - myY, myColor)   ' invert vertical
                Next
            Next
            ImageBox1.Image = myBitmap

        End If

    End Sub
End Class
