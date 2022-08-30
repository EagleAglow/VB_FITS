<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btnSaveEdit = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ListBoxLayers = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ListBoxHDUs = New System.Windows.Forms.ListBox()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListBoxCards = New System.Windows.Forms.ListBox()
        Me.ImageBox1 = New Cyotek.Windows.Forms.ImageBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSaveFile)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.btnSaveEdit)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.ListBoxLayers)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.ListBoxHDUs)
        Me.Panel1.Controls.Add(Me.btnLoadFile)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(580, 180)
        Me.Panel1.TabIndex = 3
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveFile.Location = New System.Drawing.Point(479, 9)
        Me.btnSaveFile.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(90, 24)
        Me.btnSaveFile.TabIndex = 14
        Me.btnSaveFile.Text = "Save File"
        Me.btnSaveFile.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(111, 120)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(237, 22)
        Me.TextBox4.TabIndex = 13
        '
        'btnSaveEdit
        '
        Me.btnSaveEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveEdit.Location = New System.Drawing.Point(479, 120)
        Me.btnSaveEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSaveEdit.Name = "btnSaveEdit"
        Me.btnSaveEdit.Size = New System.Drawing.Size(90, 24)
        Me.btnSaveEdit.TabIndex = 12
        Me.btnSaveEdit.Text = "Save Edit"
        Me.btnSaveEdit.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(9, 147)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(560, 22)
        Me.TextBox5.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(9, 120)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(89, 22)
        Me.TextBox3.TabIndex = 9
        '
        'ListBoxLayers
        '
        Me.ListBoxLayers.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxLayers.FormattingEnabled = True
        Me.ListBoxLayers.ItemHeight = 16
        Me.ListBoxLayers.Location = New System.Drawing.Point(479, 63)
        Me.ListBoxLayers.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxLayers.Name = "ListBoxLayers"
        Me.ListBoxLayers.ScrollAlwaysVisible = True
        Me.ListBoxLayers.Size = New System.Drawing.Size(90, 52)
        Me.ListBoxLayers.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(9, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(560, 22)
        Me.TextBox1.TabIndex = 6
        '
        'ListBoxHDUs
        '
        Me.ListBoxHDUs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxHDUs.FormattingEnabled = True
        Me.ListBoxHDUs.ItemHeight = 16
        Me.ListBoxHDUs.Location = New System.Drawing.Point(9, 63)
        Me.ListBoxHDUs.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxHDUs.Name = "ListBoxHDUs"
        Me.ListBoxHDUs.ScrollAlwaysVisible = True
        Me.ListBoxHDUs.Size = New System.Drawing.Size(463, 52)
        Me.ListBoxHDUs.TabIndex = 5
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadFile.Location = New System.Drawing.Point(9, 8)
        Me.btnLoadFile.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(89, 24)
        Me.btnLoadFile.TabIndex = 4
        Me.btnLoadFile.TabStop = False
        Me.btnLoadFile.Text = "Open File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 175)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBoxCards)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImageBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(580, 341)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 13
        '
        'ListBoxCards
        '
        Me.ListBoxCards.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxCards.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ListBoxCards.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBoxCards.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxCards.FormattingEnabled = True
        Me.ListBoxCards.ItemHeight = 16
        Me.ListBoxCards.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxCards.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxCards.Name = "ListBoxCards"
        Me.ListBoxCards.Size = New System.Drawing.Size(260, 336)
        Me.ListBoxCards.TabIndex = 12
        '
        'ImageBox1
        '
        Me.ImageBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageBox1.BackColor = System.Drawing.Color.Black
        Me.ImageBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ImageBox1.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingle
        Me.ImageBox1.Location = New System.Drawing.Point(0, 0)
        Me.ImageBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageBox1.Name = "ImageBox1"
        Me.ImageBox1.Size = New System.Drawing.Size(316, 341)
        Me.ImageBox1.TabIndex = 13
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 515)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLoadFile As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListBoxCards As ListBox
    Friend WithEvents ImageBox1 As Cyotek.Windows.Forms.ImageBox
    Friend WithEvents ListBoxHDUs As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ListBoxLayers As ListBox
    Friend WithEvents btnSaveEdit As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents btnSaveFile As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
