Imports System.ComponentModel
Imports System.Windows.Forms
Imports system.Drawing
Imports System.Drawing.Drawing2D



<ProvideProperty("PrintUnits", GetType(Control))> _
<ProvideProperty("PrintOrientation", GetType(Control))> _
<ProvideProperty("PrintRectangle", GetType(Control))> _
<ProvideProperty("PrintFont", GetType(Control))> _
Public Class Printing
    Implements System.ComponentModel.IExtenderProvider

    Private m_rect As New Dictionary(Of Control, RectangleF)
    Private m_unit As New Dictionary(Of Control, GraphicsUnit)
    Private m_orient As New Dictionary(Of Control, Integer)
    Private m_font As New Dictionary(Of Control, Font)

    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        Return TypeOf extendee Is Control
    End Function

    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <DefaultValue(GetType(RectangleF), "0.0,0.0,0.0,0.0")> _
    <Description("Specifies printing rectangle")> _
    <TypeConverter(GetType(PointFConverter))> _
    Public Function GetPrintRectangle(ByVal extendee As Control) As RectangleF
        ' See if we are extending this Control.
        If m_rect.ContainsKey(extendee) Then
            Return m_rect(extendee)
        Else
            ' We're not extending this Control.
            Return Rectangle.Empty
        End If
    End Function


    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing rectangle")> _
    <TypeConverter(GetType(PointFConverter))> _
    Public Sub SetPrintRectangle(ByVal extendee As Control, ByVal value As RectangleF)
        ' Remove the extendee's entry if it is present.
        If m_rect.ContainsKey(extendee) Then
            m_rect.Remove(extendee)
            'RemoveHandler extendee.Validating, AddressOf Extendee_Validating
        End If

        ' Add the new value.
        If value <> Rectangle.Empty Then
            ' Add the extendee's value.
            m_rect.Add(extendee, value)
            ' AddHandler extendee.Validating, AddressOf Extendee_Validating
        End If
    End Sub

    <ExtenderProvidedProperty()> _
    <DefaultValue(0)> _
    <Category("Printing")> _
    <Description("Specifies printing orientation: 0 deg, 90 deg, 180 deg, 270 deg")> _
    Public Function GetPrintOrientation(ByVal extendee As Control) As Integer
        ' See if we are extending this Control.
        If TypeOf extendee Is Form AndAlso m_orient.ContainsKey(extendee) Then
            Return m_orient(extendee)
        Else
            ' We're not extending this Control. Return the default orientation.
            Return 0
        End If
    End Function


    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing orientation: 0 deg, 90 deg, 180 deg, 270 deg")> _
    Public Sub SetPrintOrientation(ByVal extendee As Control, ByVal value As Integer)
        ' Remove the extendee's entry if it is present.
        If Not TypeOf extendee Is Form Then Exit Sub
        If m_orient.ContainsKey(extendee) Then
            m_orient.Remove(extendee)
            'RemoveHandler extendee.Validating, AddressOf Extendee_Validating
        End If

        ' Add the new value.
        If value Mod 90 = 0 Then
            ' Add the extendee's value.
            m_orient.Add(extendee, value)
            ' AddHandler extendee.Validating, AddressOf Extendee_Validating
        End If
    End Sub

    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing units")> _
    <DefaultValue(GetType(GraphicsUnit), "GraphicsUnit.Millimeter")> _
    Public Function GetPrintUnits(ByVal extendee As Control) As GraphicsUnit
        If m_unit.ContainsKey(extendee) Then
            Return m_unit(extendee)
        Else
            Return GraphicsUnit.Pixel
        End If
    End Function

    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing units")> _
    Public Sub SetPrintUnits(ByVal extendee As Control, ByVal value As GraphicsUnit)
        ' Remove the extendee's entry if it is present.
        If m_unit.ContainsKey(extendee) Then
            m_unit.Remove(extendee)
        End If
        m_unit.Add(extendee, value)
    End Sub

    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing font (if different from display)")> _
    Public Function GetPrintFont(ByVal extendee As Control) As Font
        ' See if we are extending this Control.
        If TypeOf extendee Is Label AndAlso m_font.ContainsKey(extendee) Then
            ' Return the Font value.
            Return m_font(extendee)
        Else
            ' We're not extending this Control.
            Return Nothing
        End If
    End Function


    <ExtenderProvidedProperty()> _
    <Category("Printing")> _
    <Description("Specifies printing font (if different from display)")> _
    Public Sub SetPrintFont(ByVal extendee As Control, ByVal value As Font)
        If Not TypeOf extendee Is Label Then Return
        ' Remove the extendee's entry if it is present.
        If m_font.ContainsKey(extendee) Then
            m_font.Remove(extendee)
        End If

        ' Add the new value.
        If Not extendee.Font.Equals(value) Then
            ' Add the extendee's value.
            m_font.Add(extendee, value)
        End If
    End Sub

    Public Sub Print(ByVal GC As Graphics, ByVal ctrl As Control)
        Dim gcont As GraphicsContainer = GC.BeginContainer()
        PrintGraphics(GC, ctrl)
        GC.EndContainer(gcont)
        gcont = GC.BeginContainer()
        PrintText(GC, ctrl)
        GC.EndContainer(gcont)
    End Sub

    Public Sub PrintGraphics(ByVal GC As Graphics, ByVal ctrl As Control)

        If m_rect.ContainsKey(ctrl) AndAlso Not m_rect(ctrl).IsEmpty Then
            Dim irect As RectangleF = m_rect(ctrl)
            GC.PageUnit = GraphicsUnit.Millimeter

            Dim brect As RectangleF = irect

            If TypeOf ctrl Is Form Then
                Dim orient As Integer = 0
                If m_orient.ContainsKey(ctrl) Then orient = m_orient(ctrl)
                GC.RotateTransform(orient)
                Dim dx, dy As Single
                Select Case orient
                    Case 0
                        dx = 0 : dy = 0
                    Case 90
                        dx = 0 : dy = -brect.Height
                    Case 180
                        dx = -brect.Width : dy = -brect.Height
                    Case 270
                        dx = -brect.Width : dy = 0
                End Select
                GC.TranslateTransform(dx, dy)
            ElseIf TypeOf ctrl Is PictureBox Then
                Dim bm As Bitmap = CType(ctrl, PictureBox).Image
                If bm IsNot Nothing Then
                    GC.DrawImage(bm, brect)
                End If
            Else
            End If
        End If

        ' Iterate thru all controls and render them
        For Each iC As Control In ctrl.Controls
            If m_rect.ContainsKey(iC) AndAlso Not m_rect(iC).IsEmpty Then
                PrintGraphics(GC, iC)
            End If
        Next
    End Sub
    Private Sub PrintText(ByVal GC As Graphics, ByVal ctrl As Control)

        If m_rect.ContainsKey(ctrl) AndAlso Not m_rect(ctrl).IsEmpty Then
            Dim irect As RectangleF = m_rect(ctrl)
            GC.PageUnit = GraphicsUnit.Millimeter

            Dim brect As RectangleF = irect

            If TypeOf ctrl Is Label Then
                Dim ft As Font = ctrl.Font
                If m_font.ContainsKey(ctrl) AndAlso m_font(ctrl) IsNot Nothing Then ft = m_font(ctrl)
                Dim ts As New SizeF(brect.Size)
                Dim sf As New StringFormat(StringFormatFlags.NoWrap)
                sf.LineAlignment = StringAlignment.Near


                GC.SmoothingMode = SmoothingMode.HighQuality
                GC.TextRenderingHint = Text.TextRenderingHint.AntiAlias
                GC.CompositingQuality = CompositingQuality.HighQuality
                GC.InterpolationMode = InterpolationMode.HighQualityBicubic

                Dim meas As SizeF = GC.MeasureString(ctrl.Text, ft)
                If meas.Width > ts.Width Then
                    Dim nFont As New Font(ft.FontFamily, ft.Size * ts.Width / meas.Width, ft.Style, GraphicsUnit.Point)
                    GC.DrawString(ctrl.Text, nFont, Brushes.Black, brect.Location, sf)
                    nFont.Dispose()
                Else
                    GC.DrawString(ctrl.Text, ft, Brushes.Black, brect.Location, sf)
                End If
                sf.Dispose()
            ElseIf TypeOf ctrl Is Form Then
                Dim orient As Integer = 0
                If m_orient.ContainsKey(ctrl) Then orient = m_orient(ctrl)
                GC.RotateTransform(orient)
                Dim dx, dy As Single
                Select Case orient
                    Case 0
                        dx = 0 : dy = 0
                    Case 90
                        dx = 0 : dy = -brect.Height
                    Case 180
                        dx = -brect.Width : dy = -brect.Height
                    Case 270
                        dx = -brect.Width : dy = 0
                End Select
                GC.TranslateTransform(dx, dy)
            Else
            End If
        End If

        ' Iterate thru all controls and render them
        For Each iC As Control In ctrl.Controls
            If m_rect.ContainsKey(iC) AndAlso Not m_rect(iC).IsEmpty Then
                PrintText(GC, iC)
            End If
        Next
    End Sub


    Public Function GetPrintRectInPixels(ByVal gc As Graphics, ByVal cntrl As Control)
        Dim PrintRect As RectangleF
        Dim PrintUnits As GraphicsUnit
        Dim PrintWidth As Integer
        Dim PrintHeight As Integer
        Dim XScale, YScale As Single

        PrintRect = GetPrintRectangle(cntrl)
        PrintUnits = GetPrintUnits(cntrl)

        If PrintRect.IsEmpty Then
            PrintRect = New Rectangle(0, 0, cntrl.Width, cntrl.Height)
            PrintUnits = GraphicsUnit.Pixel
        End If

        Select Case PrintUnits
            Case GraphicsUnit.Millimeter
                XScale = gc.DpiX / 25.4F
                YScale = gc.DpiY / 25.4F
            Case GraphicsUnit.Pixel
                XScale = 1
                YScale = 1
            Case GraphicsUnit.Point
                XScale = gc.DpiX / 72.0F
                YScale = gc.DpiY / 72.0F
            Case GraphicsUnit.Display
                XScale = gc.DpiX / 96.0F
                YScale = gc.DpiY / 96.0F
        End Select
        PrintWidth = PrintRect.Width * XScale
        PrintHeight = PrintRect.Height * YScale

        Return New Rectangle(0, 0, PrintWidth, PrintHeight)
    End Function

End Class

#Region " PointFConverter "

Public Class PointFConverter : Inherits ExpandableObjectConverter

    Public Const gcFormatString As String = ""


    Public Overloads Overrides Function CanConvertTo( _
    ByVal context As ITypeDescriptorContext, _
    ByVal destinationType As System.Type) As Boolean

        'Return True if destinationType is a class that is supported by this Converter.
        If (destinationType Is GetType(Drawing.PointF)) OrElse _
        (destinationType Is GetType(System.ComponentModel.Design.Serialization.InstanceDescriptor)) Then

            Return True
        End If

        'If we get here then we must use a method from MyBase since we encountered a type that is not supported by this class.
        Return MyBase.CanConvertFrom(context, destinationType)
    End Function


    Public Overloads Overrides Function CanConvertFrom( _
    ByVal context As ITypeDescriptorContext, _
    ByVal sourceType As System.Type) As Boolean

        'Return True if sourceType is a string.
        If (sourceType Is GetType(String)) Then Return True

        'If we get here then we must use a method from MyBase since we encountered a type that is not supported by this class.
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function


    Public Overloads Overrides Function ConvertTo( _
    ByVal context As ITypeDescriptorContext, _
    ByVal culture As System.Globalization.CultureInfo, _
    ByVal value As Object, _
    ByVal destinationType As System.Type) As Object

        If ((TypeOf value Is Drawing.PointF) AndAlso (destinationType Is GetType(System.String))) Then
            'Convert value to the appropriate type.
            Dim point As Drawing.PointF = DirectCast(value, Drawing.PointF)

            'Convert value to a string.
            With point
                Dim propertyValues() As String = {.X.ToString(gcFormatString), .Y.ToString(gcFormatString)}

                Return JoinConverterDestinationStringArray(propertyValues)
            End With 'From point

        ElseIf ((TypeOf value Is Drawing.PointF) AndAlso (destinationType Is GetType(System.ComponentModel.Design.Serialization.InstanceDescriptor))) Then
            MessageBox.Show("Not Supported!")
        End If

        'If we get here then we must use a method from MyBase since we encountered a type that is not supported by this method.
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function


    Public Overloads Overrides Function ConvertFrom( _
    ByVal context As ITypeDescriptorContext, _
    ByVal culture As System.Globalization.CultureInfo, _
    ByVal value As Object) As Object

        If (TypeOf value Is String) Then
            Try
                'Split value into its individual values.
                Dim propertyValues() As String = SplitConverterSourceString(CStr(value))

                'Convert the values.
                Dim x As Single = Single.Parse(propertyValues(0))
                Dim y As Single = Single.Parse(propertyValues(1))

                'Return the object that corresponds to value.
                Return New Drawing.PointF(x, y)

            Catch e As Exception
                MessageBox.Show(e.ToString)
            End Try
        End If

        'If we get here then we must use a method from MyBase since we encountered a type that is not supported by this method.
        Return MyBase.ConvertFrom(context, culture, value)
    End Function


    Public Shared Function SplitConverterSourceString(ByVal sourceString As String) As String()
        Dim splitString As New System.Collections.Generic.List(Of String)
        If String.IsNullOrEmpty(sourceString) Then Return Nothing

        'Split sourceString into its individual PropertyValues
        'Trim each of the members in splitString
        For Each iStr As String In sourceString.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
            splitString.Add(iStr.Trim.ToUpper)
        Next
        Return splitString.ToArray()
    End Function


    Public Shared Function JoinConverterDestinationStringArray(ByVal destinationString() As String) As String
        'Validate destinationString
        If (destinationString Is Nothing) Then Return ""
        Return String.Join(", ", destinationString)
    End Function

End Class

#End Region




