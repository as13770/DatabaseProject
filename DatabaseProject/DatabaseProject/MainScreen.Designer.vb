<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Welcome = New System.Windows.Forms.Label()
        Me.UName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Welcome
        '
        Me.Welcome.AutoSize = True
        Me.Welcome.Location = New System.Drawing.Point(12, 9)
        Me.Welcome.Name = "Welcome"
        Me.Welcome.Size = New System.Drawing.Size(52, 13)
        Me.Welcome.TabIndex = 0
        Me.Welcome.Text = "Welcome"
        '
        'UName
        '
        Me.UName.AutoSize = True
        Me.UName.Location = New System.Drawing.Point(87, 9)
        Me.UName.Name = "UName"
        Me.UName.Size = New System.Drawing.Size(0, 13)
        Me.UName.TabIndex = 1
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.UName)
        Me.Controls.Add(Me.Welcome)
        Me.Name = "MainScreen"
        Me.Text = "MainScreen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Welcome As Label
    Friend WithEvents UName As Label
End Class
