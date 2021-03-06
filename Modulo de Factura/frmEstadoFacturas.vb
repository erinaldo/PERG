﻿Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmEstadoFacturas

    Dim desde As DateTime
    Dim hasta As DateTime
    Dim permiso As New clsPermisoUsuario
    Dim filtro As String

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        desde = dtpFechaInicio.Text + " 00:00:00"

    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        hasta = dtpFechaFin.Text + " 23:59:59"

    End Sub

    'Enviar a Modulo de Impresion
    Private Sub btnModuloImpresion_Click(sender As Object, e As EventArgs) Handles btnModuloImpresion.Click
        filtro = ""

        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                Dim fechaInicio As String = dtpFechaInicio.Text + " 00:00:00"
                Dim fechaFin As String = dtpFechaFin.Text + " 23:59:00"

                r.reporte = "rptReporteEstadoFactura.rpt"
                r.tabla = EntitiToDataTable(conexion.sp_reporteEstado_Factura(mdlPublicVars.idEmpresa, filtro, fechaInicio, fechaFin))

                r.nombreParametro = "filtro"
                r.parametro = "Filtro del reporte:  "
                frmDocumentosSalida.reporteBase = r.DocumentoReporte()
                frmDocumentosSalida.txtTitulo.Text = "Venta : "
                frmDocumentosSalida.Text = "Reporte Facturas"
                frmDocumentosSalida.bitGenerico = False
                frmDocumentosSalida.bitCliente = False

                ' frmDocumentosSalida.codigo = salida.idCliente
                permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

            Catch ex As Exception
            End Try

            'cerrar la conexion.
            conn.Close()

        End Using
    End Sub

    'Generar Excel
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        'URL: http://www.tutorialspoint.com/vb.net/vb.net_excel_sheet.htm

        'Declarar variables de EXCEL
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        'Variables de configuracion
        Dim filaencabezados As Integer = 2
        Dim filacontenido As Integer = 3
        Dim inicio As Integer = 1
        Dim final As Integer = 1
        Dim rango1 As String = ""
        Dim rango2 As String = ""

        ' Iniciar excel y obtener el objeto Application
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Añadir nueva hoja

        wbXl = appXL.Workbooks.Add()
        'wbXl.appXL.workbook.Sheets["Sheet1"];
        shXL = wbXl.ActiveSheet
        ' Crear encabezado de titulo,y los encabezados de la tabla celda por celda  
        Dim datos As Array = {"No FACTURA", "RESOLUCION", "SERIE", "MONEDA", "TIPO CAMBIO", "NIT", "NOMBRE", "DIRECCION", "FECHA", "TOTAL LETRAS", "TOTAL", "MONTO EXCENTO", "DESCUENTO", "ESTADO", "CODPRODUCTO",
                              "CANTIDAD", "METRICA", "DESCRIPCION", "PRECIO UNITARIO", "IVA", "TTOTAL",
                              "OPCIONAL 1", "OPCIONAL 2", "OPCIONAL 3", "OPCIONAL 4", "OPCIONAL 5", "OPCIONAL 6", "OPCIONAL 7", "OPCIONAL 8", "OPCIONAL 9", "OPCIONAL 10"}

        For Each encabezado As String In datos
            shXL.Cells(filaencabezados, inicio).value = encabezado
            inicio += 1
        Next
        final = inicio
        inicio = 1

        ' Establecer los encabezados en negrita
        With shXL.Range("A" & filaencabezados, "AE" & filaencabezados)
            .Font.Bold = True
        End With

        'Obtener los resultados de las facturas

        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                Dim fechaInicio As String = dtpFechaInicio.Text + " 00:00:00"
                Dim fechaFin As String = dtpFechaFin.Text + " 23:59:00"
                Dim resultados As DataTable = EntitiToDataTable(conexion.sp_EstadoFacturaExcel(mdlPublicVars.idEmpresa, fechaInicio, fechaFin))
                Dim resultados2(resultados.Rows.Count, resultados.Columns.Count) As Object

                Dim contador As Integer = 0
                Dim i As Integer = 0
                Dim tipo As String = ""
                final = filacontenido




                For Each fila As DataRow In resultados.Rows
                    i = 0
                    For Each columna As DataColumn In resultados.Columns
                        tipo = columna.ColumnName.Substring(0, 3)
                        fila.Item(i) = fila.Item(i).ToString.Trim

                        If fila.Item(i).ToString.Length > 128 Then
                            fila.Item(i) = fila.Item(i).ToString.Substring(0, 128)
                        End If

                        Select Case tipo
                            Case "Int"
                                resultados2(contador, i) = CInt(fila.Item(i))
                            Case "Dec"
                                resultados2(contador, i) = CDec(fila.Item(i))
                            Case Else
                                resultados2(contador, i) = CStr2(fila.Item(i))
                        End Select

                        i += 1
                    Next

                    contador += 1
                    final += 1
                Next




                shXL.Range("A" & filacontenido, "U" & final).Value = resultados2
                'Formula del IVA
                raXL = shXL.Range("T" & filacontenido, "T" & final)
                raXL.Formula = "=S" & filacontenido & " *0.12"
                raXL.NumberFormat = "0.00"

                'Formatos
                raXL = shXL.Range("A" & filacontenido, "A" & final) ' Documento
                raXL.NumberFormat = "@"
                raXL = shXL.Range("E" & filacontenido, "E" & final) ' Tipo de Cambio
                raXL.NumberFormat = "0.00"
                raXL = shXL.Range("K" & filacontenido, "M" & final) ' Total, Monto excento  y descuento
                raXL.NumberFormat = "0.00"
                raXL = shXL.Range("P" & filacontenido, "P" & final) ' Cantidad
                raXL.NumberFormat = "0.00"
                raXL = shXL.Range("S" & filacontenido, "U" & final) ' Precio Unitario, IVA, Total
                raXL.NumberFormat = "0.00"
                raXL = shXL.Range("I" & filacontenido, "I" & final) ' Fecha
                raXL.NumberFormat = "dd-mm-yyyy"
            Catch ex As Exception
                ' RadMessageBox.Show("Ocurrio un error", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try

            conn.Close()

        End Using

        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.
        appXL.Visible = True
        appXL.UserControl = True
        ' Release object references.
        raXL = Nothing
        shXL = Nothing
        wbXl = Nothing
        appXL.Quit()
        appXL = Nothing
        Exit Sub
    End Sub

End Class