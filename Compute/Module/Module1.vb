Imports System.Globalization

Module Module1
#Region "Public Printer Settings Variable"
    Public IsGP As Boolean
    Public GPPrintDisabled As Boolean
    Public ZeroPrintDisable As Boolean
    Public IsOffLineGP As Boolean
#End Region

    Public Structure ChargingRuleInfo
        Public TypeofVehicle As String
        Public InitialMinute As Integer
        Public InitialAmount As Double
        Public SucceedingAmt As Double
        Public OvernightAmt As Double
        Public LostTicket As Double
        Public ValetFee As Double
    End Structure

    Public Structure ComputationRef
        Public Consumed As String
        Public Timeout As Date
        Public Timein As Date
        Public Vehicle As String
        Public Overnight As Double
        Public ValetFee As Double
        Public Regular As Double
        Public LostCard As Double
        Public TotalAmount As Double
        Public Vat As Double
        Public Vat_Sale As Double

    End Structure

    Public Function Get_SubTotal(ByVal Amount As Double, ByVal Vat As Double) As Double
        Return Math.Round(Amount - Vat, 2)
    End Function

    Public Function CalculateVAT(ByVal Amount As Double, ByVal Rate As Double) As Double
        Return Amount * Rate
    End Function

    Public Function Computation(ByVal ChargingRule As ChargingRuleInfo, ByVal TimeIn As Date, ByVal TimeOut As Date, ByVal LostTicketCheck As Boolean) As ComputationRef
        Dim totalMinutes As Integer = CInt((TimeOut - TimeIn).TotalMinutes)
        Dim entrycomp As New ComputationRef()

        ' Assigning values from ChargingRuleInfo to entrycomp
        entrycomp.Vehicle = ChargingRule.TypeofVehicle
        entrycomp.Regular = ChargingRule.InitialAmount
        entrycomp.TotalAmount = ChargingRule.SucceedingAmt



        ' Calculate total amount based on charging rules
        If totalMinutes <= ChargingRule.InitialMinute Then
            entrycomp.TotalAmount = ChargingRule.InitialAmount
        ElseIf totalMinutes > ChargingRule.InitialMinute Then
            entrycomp.Regular = ChargingRule.InitialAmount + (Math.Ceiling((totalMinutes - ChargingRule.InitialMinute) / 60) * ChargingRule.SucceedingAmt)
        End If



        ' Check for overnight parking
        Dim tempTimeIn As Date = TimeIn
        Dim tempTimeOut As Date = TimeOut
        entrycomp.Overnight = 0

        ' Check for overnight parking
        Dim tempTime As Date = TimeIn
        entrycomp.Overnight = 0

        Do While tempTime.Date < TimeOut.Date
            If tempTime.TimeOfDay = TimeSpan.Zero Then
                entrycomp.Overnight += 1

            End If

            tempTime = tempTime.AddHours(1)
        Loop


        ' Add valet fee
        entrycomp.ValetFee = ChargingRule.ValetFee
        entrycomp.TotalAmount += entrycomp.ValetFee


        ' Check for lost ticket
        If LostTicketCheck Then
            entrycomp.LostCard = 200 ' Lost ticket fee is 200
            entrycomp.TotalAmount += entrycomp.LostCard
        End If


        ' Calculate total amount including overnight charges
        If entrycomp.Overnight > 0 Then
            Dim overnightCost As Double = ChargingRule.OvernightAmt * entrycomp.Overnight
            entrycomp.TotalAmount += overnightCost
        End If

        ' Calculate VAT
        Dim vatRate As Double = 0.12 ' 12%
        entrycomp.Vat = CalculateVAT(entrycomp.TotalAmount, vatRate)
        entrycomp.Vat_Sale = Get_SubTotal(entrycomp.TotalAmount, entrycomp.Vat)

        Return entrycomp
    End Function

End Module

