Imports System.Windows.Forms.Integration
Imports System.Windows.Ink
Imports System.Windows.Controls

Public Class Form1
    Private inkCanvas As InkCanvas
    Private elementHost As ElementHost

    Public Sub New()
        InitializeComponent()

        ' Create the ElementHost control to host WPF content
        elementHost = New ElementHost()
        elementHost.Dock = DockStyle.Fill
        PanelInkHost.Controls.Add(elementHost)

        ' Create the WPF InkCanvas
        inkCanvas = New InkCanvas()
        inkCanvas.Background = New System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Colors.White)

        ' Configure drawing attributes for the pen
        inkCanvas.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Black
        inkCanvas.DefaultDrawingAttributes.Width = 2
        inkCanvas.DefaultDrawingAttributes.Height = 2
        inkCanvas.DefaultDrawingAttributes.FitToCurve = True
        inkCanvas.DefaultDrawingAttributes.IsHighlighter = False
        inkCanvas.DefaultDrawingAttributes.IgnorePressure = False  ' Enable pressure sensitivity

        ' Set the InkCanvas as the hosted content
        elementHost.Child = inkCanvas
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        inkCanvas.Strokes.Clear()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp"
            saveDialog.Title = "Save Signature"
            saveDialog.DefaultExt = ".png"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Try
                    ' Create a RenderTargetBitmap to render the InkCanvas
                    Dim rtb As New System.Windows.Media.Imaging.RenderTargetBitmap(
                        CInt(inkCanvas.ActualWidth), CInt(inkCanvas.ActualHeight),
                        96, 96, System.Windows.Media.PixelFormats.Default)

                    ' Render the InkCanvas to the bitmap
                    rtb.Render(inkCanvas)

                    ' Create appropriate encoder based on file extension
                    Dim ext As String = System.IO.Path.GetExtension(
                        saveDialog.FileName).ToLower()
                    Dim encoder As System.Windows.Media.Imaging.BitmapEncoder

                    Select Case ext
                        Case ".png"
                            encoder = New System.Windows.Media.Imaging.PngBitmapEncoder()
                        Case ".jpg", ".jpeg"
                            encoder = New System.Windows.Media.Imaging.JpegBitmapEncoder()
                        Case ".bmp"
                            encoder = New System.Windows.Media.Imaging.BmpBitmapEncoder()
                        Case Else
                            encoder = New System.Windows.Media.Imaging.PngBitmapEncoder()
                    End Select

                    ' Add the rendered bitmap to the encoder
                    encoder.Frames.Add(
                        System.Windows.Media.Imaging.BitmapFrame.Create(rtb))

                    ' Save the image
                    Using stream As New System.IO.FileStream(
                        saveDialog.FileName, IO.FileMode.Create)
                        encoder.Save(stream)
                    End Using

                    MessageBox.Show("Signature saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error saving signature: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' Optional: Add a method to get the signature as a bitmap for use in your application
    Public Function GetSignatureAsBitmap() As Bitmap
        ' Create a RenderTargetBitmap
        Dim rtb As New System.Windows.Media.Imaging.RenderTargetBitmap(
            CInt(inkCanvas.ActualWidth), CInt(inkCanvas.ActualHeight),
            96, 96, System.Windows.Media.PixelFormats.Default)

        ' Render the InkCanvas to the bitmap
        rtb.Render(inkCanvas)

        ' Convert to a BitmapSource
        Dim bitmapSource As System.Windows.Media.Imaging.BitmapSource =
            System.Windows.Media.Imaging.BitmapFrame.Create(rtb)

        ' Convert BitmapSource to System.Drawing.Bitmap
        Dim bitmap As New Bitmap(
            bitmapSource.PixelWidth,
            bitmapSource.PixelHeight,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim bitmapData As System.Drawing.Imaging.BitmapData =
            bitmap.LockBits(
                New Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb)

        bitmapSource.CopyPixels(
            System.Windows.Int32Rect.Empty,
            bitmapData.Scan0,
            bitmapData.Height * bitmapData.Stride,
            bitmapData.Stride)

        bitmap.UnlockBits(bitmapData)

        Return bitmap
    End Function
End Class
