<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PanelInkHost = New System.Windows.Forms.Panel()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PanelInkHost
        '
        Me.PanelInkHost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInkHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelInkHost.Location = New System.Drawing.Point(12, 12)
        Me.PanelInkHost.Name = "PanelInkHost"
        Me.PanelInkHost.Size = New System.Drawing.Size(760, 480)
        Me.PanelInkHost.TabIndex = 0
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(12, 510)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(120, 40)
        Me.ButtonClear.TabIndex = 1
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(142, 510)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(120, 40)
        Me.ButtonSave.TabIndex = 2
        Me.ButtonSave.Text = "Save Signature"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.PanelInkHost)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelInkHost As Panel
    Friend WithEvents ButtonClear As Button
    Friend WithEvents ButtonSave As Button
End Class
