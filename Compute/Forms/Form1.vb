Imports System.Globalization
Public Class Form1
    Private LostTicketCheck As Boolean = False

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpIn.Format = DateTimePickerFormat.Custom
        dtpIn.CustomFormat = "MM/dd/yyyy hh:mm tt"
        dtpExit.Format = DateTimePickerFormat.Custom
        dtpExit.CustomFormat = "MM/dd/yyyy hh:mm tt"


    End Sub

    Private Sub dtpIn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIn.ValueChanged
        ' Ensure the exit time is never before the entry time
        If dtpExit.Value < dtpIn.Value Then
            dtpExit.Value = dtpIn.Value
        End If
    End Sub

    Private Sub dtpExit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpExit.KeyDown
        If e.KeyCode = Keys.Enter Then
            Total_Click(Nothing, Nothing)
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub dtpExit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpExit.ValueChanged
        ' Ensure the exit time is never before the entry time
        If dtpExit.Value < dtpIn.Value Then
            dtpIn.Value = dtpExit.Value
        End If
    End Sub

    Private Sub Total_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Total.Click
        Dim TimeIn As DateTime = dtpIn.Value
        Dim TimeOut As DateTime = dtpExit.Value

        Dim totalMinutes As Integer = CInt((TimeOut - TimeIn).TotalMinutes)

        Dim chargingRule As ChargingRuleInfo = GetChargingRule(VehicleType.Text, totalMinutes)

        'form-level isLostTicketChecked variable directly
        Dim computationResult As ComputationRef = Computation(chargingRule, TimeIn, TimeOut, LostTicketCheck)




        ' Set the Result textbox text with the total amount including VAT
        If LostTicket.Checked Then
            ' If LostTicket checkbox is checked, display the lost fee along with the total amount
            Result.Text = "Initial Amount: " & chargingRule.InitialAmount.ToString("0.00") & vbCrLf & _
                          "Initial Minute: " & chargingRule.InitialMinute & " Minutes" & vbCrLf & _
                          "Lost Ticket Fee: " & computationResult.LostCard.ToString("0.00") & vbCrLf & _
                          "Overnight Amount: " & chargingRule.OvernightAmt.ToString("0.00") & vbCrLf & _
                          "Succeeding Amount: " & chargingRule.SucceedingAmt.ToString("0.00") & vbCrLf & _
                          "Type of Vehicle: " & chargingRule.TypeofVehicle & vbCrLf & _
                          "ValetFee: " & chargingRule.ValetFee.ToString("0.00") & vbCrLf & _
                          "VAT: " & computationResult.Vat.ToString("0.00") & vbCrLf & _
                          "VAT Sale: " & computationResult.Vat_Sale.ToString("0.00") & vbCrLf & _
                          "Total Amount: " & computationResult.TotalAmount.ToString("0.00")

        Else
            ' If LostTicket checkbox is not checked, display only the total amount
            Result.Text = "Initial Amount: " & chargingRule.InitialAmount.ToString("0.00") & vbCrLf & _
                          "Initial Minute: " & chargingRule.InitialMinute & " Minutes" & vbCrLf & _
                          "Lost Ticket: " & computationResult.LostCard.ToString("0.00") & vbCrLf & _
                          "Overnight Amount: " & chargingRule.OvernightAmt.ToString("0.00") & vbCrLf & _
                          "Succeeding Amount: " & chargingRule.SucceedingAmt.ToString("0.00") & vbCrLf & _
                          "Type of Vehicle: " & chargingRule.TypeofVehicle & vbCrLf & _
                          "ValetFee: " & chargingRule.ValetFee.ToString("0.00") & vbCrLf & _
                          "VAT: " & computationResult.Vat.ToString("0.00") & vbCrLf & _
                          "VAT Sale: " & computationResult.Vat_Sale.ToString("0.00") & vbCrLf & _
                          "Total Amount: " & computationResult.TotalAmount.ToString("0.00")
        End If
    End Sub

    Private Sub LostTicket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LostTicket.CheckedChanged
        LostTicketCheck = LostTicket.Checked
        Console.WriteLine("LostTicket_CheckedChanged - Checkbox checked state: " & LostTicket.Checked.ToString())
        Console.WriteLine("LostTicket_CheckedChanged - LostTicketCheck variable state: " & LostTicketCheck.ToString())
    End Sub

    Private Function GetChargingRule(ByVal VehicleType As String, ByVal totalMinutes As Integer) As ChargingRuleInfo
        Dim result As ChargingRuleInfo
        Dim compute As ComputationRef
        Select Case VehicleType
            Case "Car"
                result.InitialAmount = compute.Regular
                result.InitialMinute = totalMinutes
                result.LostTicket = LostTicketCheck
                result.OvernightAmt = 60
                result.SucceedingAmt = compute.TotalAmount
                result.TypeofVehicle = "Car"
                result.ValetFee = 10
            Case "Motor"
                result.InitialAmount = 30
                result.InitialMinute = 60
                result.LostTicket = LostTicketCheck
                result.OvernightAmt = 60
                result.SucceedingAmt = 30
                result.TypeofVehicle = "Motorcycle"
                result.ValetFee = 10
            Case Else
                result.InitialAmount = 0
                result.InitialMinute = 0
                result.LostTicket = 0
                result.OvernightAmt = 0
                result.SucceedingAmt = 0
                result.TypeofVehicle = "None"
                result.ValetFee = 0


        End Select

        Return result
    End Function
End Class
