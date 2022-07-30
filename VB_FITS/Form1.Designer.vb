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
        Me.ImageBox1 = New Cyotek.Windows.Forms.ImageBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnCreateImage = New System.Windows.Forms.Button()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ImageBox1
        '
        Me.ImageBox1.BackColor = System.Drawing.Color.Black
        Me.ImageBox1.ImageBorderStyle = Cyotek.Windows.Forms.ImageBoxBorderStyle.FixedSingle
        Me.ImageBox1.Location = New System.Drawing.Point(19, 96)
        Me.ImageBox1.Name = "ImageBox1"
        Me.ImageBox1.Size = New System.Drawing.Size(441, 288)
        Me.ImageBox1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnCreateImage
        '
        Me.btnCreateImage.Location = New System.Drawing.Point(19, 21)
        Me.btnCreateImage.Name = "btnCreateImage"
        Me.btnCreateImage.Size = New System.Drawing.Size(154, 55)
        Me.btnCreateImage.TabIndex = 1
        Me.btnCreateImage.Text = "Create Image"
        Me.btnCreateImage.UseVisualStyleBackColor = True
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(198, 24)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(262, 51)
        Me.btnLoadFile.TabIndex = 2
        Me.btnLoadFile.TabStop = False
        Me.btnLoadFile.Text = "Load File (Takes 10-20 seconds)"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 512)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.btnCreateImage)
        Me.Controls.Add(Me.ImageBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageBox1 As Cyotek.Windows.Forms.ImageBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnCreateImage As Button
    Friend WithEvents btnLoadFile As Button
End Class
