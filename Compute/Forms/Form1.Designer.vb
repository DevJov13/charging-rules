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
        Me.dtpIn = New System.Windows.Forms.DateTimePicker
        Me.dtpExit = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Total = New System.Windows.Forms.Button
        Me.VehicleType = New System.Windows.Forms.ComboBox
        Me.Result = New System.Windows.Forms.TextBox
        Me.LostTicket = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'dtpIn
        '
        Me.dtpIn.Location = New System.Drawing.Point(98, 153)
        Me.dtpIn.MinDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.dtpIn.Name = "dtpIn"
        Me.dtpIn.Size = New System.Drawing.Size(200, 20)
        Me.dtpIn.TabIndex = 0
        '
        'dtpExit
        '
        Me.dtpExit.Location = New System.Drawing.Point(98, 197)
        Me.dtpExit.MinDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.dtpExit.Name = "dtpExit"
        Me.dtpExit.Size = New System.Drawing.Size(200, 20)
        Me.dtpExit.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "IN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "OUT"
        '
        'Total
        '
        Me.Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.Location = New System.Drawing.Point(135, 234)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(121, 23)
        Me.Total.TabIndex = 4
        Me.Total.Text = "TOTAL"
        Me.Total.UseVisualStyleBackColor = True
        '
        'VehicleType
        '
        Me.VehicleType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.VehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VehicleType.FormattingEnabled = True
        Me.VehicleType.Items.AddRange(New Object() {"Motor", "Car"})
        Me.VehicleType.Location = New System.Drawing.Point(135, 111)
        Me.VehicleType.Name = "VehicleType"
        Me.VehicleType.Size = New System.Drawing.Size(121, 21)
        Me.VehicleType.TabIndex = 5
        '
        'Result
        '
        Me.Result.Location = New System.Drawing.Point(98, 263)
        Me.Result.Multiline = True
        Me.Result.Name = "Result"
        Me.Result.Size = New System.Drawing.Size(200, 175)
        Me.Result.TabIndex = 6
        '
        'LostTicket
        '
        Me.LostTicket.AutoSize = True
        Me.LostTicket.Location = New System.Drawing.Point(135, 88)
        Me.LostTicket.Name = "LostTicket"
        Me.LostTicket.Size = New System.Drawing.Size(95, 17)
        Me.LostTicket.TabIndex = 8
        Me.LostTicket.Text = "LOST TICKET"
        Me.LostTicket.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 450)
        Me.Controls.Add(Me.LostTicket)
        Me.Controls.Add(Me.Result)
        Me.Controls.Add(Me.VehicleType)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpExit)
        Me.Controls.Add(Me.dtpIn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpExit As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Total As System.Windows.Forms.Button
    Friend WithEvents VehicleType As System.Windows.Forms.ComboBox
    Friend WithEvents Result As System.Windows.Forms.TextBox
    Friend WithEvents LostTicket As System.Windows.Forms.CheckBox

End Class
