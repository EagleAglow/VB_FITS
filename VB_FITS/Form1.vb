Public Class Form1
    Dim myX As Int32
    Dim myY As Int32
    Dim myZ As Int32




    Private Sub btnLoadFile_Click(sender As Object, e As EventArgs) Handles btnLoadFile.Click

        ' see: https://github.com/nom-tam-fits/nom-tam-fits#reading-fits-files

        '   sample file:      w0bw0103t_c0h.fit
        ' G:\DownLoadsTemporary\FITS_Samples\w0bw0103t_c0h.fit


        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            fileNameFITS = OpenFileDialog1.FileName
            TextBox1.Text = fileNameFITS

            Call OpenFITS(fileNameFITS)

            If hduCount > 0 Then              ' select first hdu, get cards, if any
                ListBoxHDUs.SelectedIndex = 0
                '                Call ReadCards(0)
                Call ReadCards(0)
                If hduLayerCount(0) > 0 Then               ' get the image
                    ListBoxLayers.SelectedIndex = 0

                    Call ReadImage(0, 0)            ' first hdu, first layer


                End If
            End If


        End If



    End Sub

    Private Sub ListBoxCards_Click(sender As Object, e As EventArgs) Handles ListBoxCards.Click
        Dim whichCard As Integer
        Dim whichHDU As Integer
        If ListBoxCards.SelectedIndex > -1 Then
            If ListBoxHDUs.SelectedIndex > -1 Then
                whichHDU = ListBoxHDUs.SelectedIndex
                whichCard = ListBoxCards.SelectedIndex
                ReadCard(whichHDU, whichCard)

                ListBoxLayers.Items.Clear()
                If hduLayerCount(ListBoxHDUs.SelectedIndex) > 0 Then
                    Dim i As Integer
                    For i = 0 To hduLayerCount(ListBoxHDUs.SelectedIndex) - 1
                        ListBoxLayers.Items.Add(Str(i))
                    Next
                    ListBoxLayers.SelectedIndex = 0
                End If
            End If
        End If

    End Sub

    Private Sub btnSaveEdit_Click(sender As Object, e As EventArgs) Handles btnSaveEdit.Click
        '
        Dim whichHDU As Integer
        Dim myCardText As String
        Dim strKey As String
        Dim strValue As String
        Dim strComment As String

        If ListBoxHDUs.SelectedIndex > -1 Then
            whichHDU = ListBoxHDUs.SelectedIndex
            strKey = UCase(Trim(TextBox3.Text))
            strValue = Trim(TextBox4.Text)
            strComment = Trim(TextBox5.Text)
            If strKey = "" Then   ' no key, not going to check for value
                If strComment = "" Then ' no key, no comment
                    ' do nothing
                Else  ' try to add/store string with / at character 32
                    myCardText = Space(31) & "/ " & strComment
                    Call WriteCard(whichHDU, myCardText)    ' OK
                End If
            Else ' key exists, check for value
                If strValue = "" Then  ' no value, maybe HISTORY or COMMENT?
                    If strKey = "HISTORY" Or strKey = "COMMENT" Then
                        myCardText = strKey & " " & strComment
                        Call WriteCard(whichHDU, myCardText)   ' OK
                    Else ' key, no value
                        ' do nothing
                    End If
                Else   ' we have key and value, what about comment?
                    If strComment = "" Then ' key, value, no comment
                        myCardText = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Left(strKey, 8) & "        ", 8) & "= " & Trim(strValue)
                        Call WriteCard(whichHDU, myCardText)     ' OK
                    Else  ' we have key, value and comment
                        myCardText = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Left(strKey, 8) & "        ", 8) & "= " & Microsoft.VisualBasic.Left(Trim(strValue), 22)
                        myCardText = Microsoft.VisualBasic.Left(myCardText & "/ " & strComment, 80)
                        Call WriteCard(whichHDU, myCardText)   ' OK
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        '
        Call SaveFITS()

    End Sub

    Private Sub ListBoxHDUs_Click(sender As Object, e As EventArgs) Handles ListBoxHDUs.Click
        If ListBoxHDUs.SelectedIndex > -1 Then

            ReadCards(ListBoxHDUs.SelectedIndex)

            Dim i As Integer

            ListBoxLayers.Items.Clear()
            ImageBox1.Image = Nothing
            If hduLayerCount(ListBoxHDUs.SelectedIndex) > 0 Then
                For i = 0 To hduLayerCount(ListBoxHDUs.SelectedIndex) - 1
                    ListBoxLayers.Items.Add(Str(i))
                Next
                ListBoxLayers.SelectedIndex = 0
                ReadImage(ListBoxHDUs.SelectedIndex, 0)

            End If
        End If
    End Sub

    Private Sub ListBoxLayers_Click(sender As Object, e As EventArgs) Handles ListBoxLayers.Click
        If ListBoxLayers.SelectedIndex > -1 Then
            If ListBoxHDUs.SelectedIndex > -1 Then
                ReadImage(ListBoxHDUs.SelectedIndex, ListBoxLayers.SelectedIndex)
            End If
        End If

    End Sub

End Class
