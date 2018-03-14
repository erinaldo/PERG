﻿Option Strict On

Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient


Public Class frmCierreCajaRevision

#Region "Variables"
    Private _idCierreCaja As Integer

    Public Property idCierreCaja As Integer
        Get
            idCierreCaja = _idCierreCaja
        End Get
        Set(value As Integer)
            _idCierreCaja = value
        End Set
    End Property

    Private permiso As New clsPermisoUsuario
#End Region

#Region "LOAD"
    Private Sub frmCierreCajaRevision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        mdlPublicVars.fnFormatoGridMovimientos(grdCheques)
        fnLlenarDatos()
    End Sub
#End Region

#Region "Funciones"
    'LLENAR DATOS
    Public Sub fnLlenarDatos()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                Dim cierreCaja As tblCierreCaja = (From x In conexion.tblCierreCajas.AsEnumerable Where x.codigo = idCierreCaja
                                                    Select x).FirstOrDefault

                If cierreCaja IsNot Nothing Then
                    Try
                        lblTotalCheques.Text = Format(cierreCaja.tblCierreCajaDetalleCajas.Where(Function(x) CBool(x.bitCheque)).Select(Function(x) x.tblCaja.monto).Sum, CStr(mdlPublicVars.formatoMoneda))
                    Catch ex As Exception
                        lblTotalCheques.Text = Format(0, CStr(mdlPublicVars.formatoMoneda))
                    End Try

                    Try
                        lblTotalSistema.Text = Format(cierreCaja.tblCierreCajaDetalleCajas.Where(Function(x) CBool(x.bitEfectivo) And Not CBool(x.tblCaja.anulado)).Select(Function(x) If(CBool(x.tblCaja.tblTipoPago.entrada), x.tblCaja.monto, -x.tblCaja.monto)).Sum, CStr(mdlPublicVars.formatoMoneda))
                    Catch ex As Exception
                        lblTotalSistema.Text = Format(0, CStr(mdlPublicVars.formatoMoneda))
                    End Try
                    lblTotalUsuario.Text = Format(cierreCaja.tblCierreCajaDetalles.Select(Function(x) x.total).Sum, CStr(mdlPublicVars.formatoMoneda))
                    lblAjuste.Text = Format(If(cierreCaja.bitAjuste, cierreCaja.montoAjuste, 0), CStr(mdlPublicVars.formatoMoneda))

                    lblDiferencia.Text = Format(((CDec(lblTotalUsuario.Text.Replace("Q", "")) + If(cierreCaja.bitAjuste, cierreCaja.montoAjuste, 0))) - CDec(lblTotalSistema.Text.Replace("Q", "")), CStr(mdlPublicVars.formatoMoneda))
                End If

                'DETALLE
                Dim lDetalle As IQueryable = (From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = idCierreCaja And x.bitEfectivo
                                                 Select x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
                                                  Descripcion = x.tblCaja.descripcion, Entrada = If(x.tblCaja.tblTipoPago.entrada, x.tblCaja.monto, 0),
                                                  Salida = If(x.tblCaja.tblTipoPago.salida, x.tblCaja.monto, 0))

                Dim lDetalleCheque As IQueryable = (From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = idCierreCaja And x.bitCheque
                                                  Select x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
                                                  Descripcion = x.tblCaja.descripcion, Monto = x.tblCaja.monto)


                Me.grdDatos.DataSource = lDetalle
                Me.grdCheques.DataSource = lDetalleCheque


            Catch
                alerta.fnError()
            End Try

            conn.Close()
        End Using

        fnConfiguracion(grdDatos)
        fnConfiguracion(grdCheques)
    End Sub

    'CONFIGURACION
    Private Sub fnConfiguracion(grd As RadGridView)
        If Me.grdDatos.ColumnCount > 0 Then
            mdlPublicVars.fnGridTelerik_formatoFecha(grd, "Fecha")

            grd.Columns("codigo").IsVisible = False
            grd.Columns("Fecha").Width = 15
            grd.Columns("Cliente").Width = 40
            grd.Columns("Descripcion").Width = 35

            Try
                grd.Columns("Entrada").Width = 20
                grd.Columns("Salida").Width = 20
                mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "Entrada")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "Salida")
            Catch ex As Exception
                mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "Monto")
                grd.Columns("Monto").Width = 20
            End Try

        End If


    End Sub




    'Funcion utilizada para agregar las fila summary
    'Private Sub fnSumarios()

    '    Try

    '        grdDatos.MasterTemplate.ShowTotals = True
    '        'Agregamos antes las filas de sumas
    '        Dim summaryId As New GridViewSummaryItem("Fecha", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
    '        Dim summaryTotal As New GridViewSummaryItem("Entrada", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
    '        'agregar la fila de operaciones aritmeticas
    '        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

    '        grdDatos.SummaryRowsTop.Add(summaryRowItem)

    '    Catch ex As Exception

    '    End Try

    'End Sub




#End Region

#Region "Eventos"
    Private Sub grdDatos_CellDoubleClick(sender As System.Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        If Me.grdDatos.RowCount > 0 Then
            'Obtenemos el codigo del pago
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = CInt(Me.grdDatos.Rows(fila).Cells("codigo").Value)

            frmVerPago.Text = "Pago No.: " & codigo
            frmVerPago.codigo = codigo
            frmVerPago.StartPosition = FormStartPosition.CenterScreen
            frmVerPago.ShowDialog()
            frmVerPago.Dispose()
        End If
    End Sub

    'AJUSTE
    Private Sub fnAjuste() Handles Me.panel0


        'Obtenemos el encabezado del cierre de caja
        Dim cierre As tblCierreCaja = (From x In ctx.tblCierreCajas.AsEnumerable Where x.codigo = idCierreCaja Select x).FirstOrDefault

        If cierre IsNot Nothing Then

            If cierre.bitConfirmado Then
                RadMessageBox.Show("El cierre ya ha sido confirmado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            ElseIf cierre.bitAjuste Then
                RadMessageBox.Show("El cierre ya ha sido ajustado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                frmCierreCajaAjuste.Text = "Ajuste de Cierre"
                frmCierreCajaAjuste.StartPosition = FormStartPosition.CenterScreen
                frmCierreCajaAjuste.idCierreCaja = Me.idCierreCaja
                permiso.PermisoDialogEspeciales(frmCierreCajaAjuste)
            End If
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'CIERRA FORMULARIO
    Private Sub frmCierreCajaRevision_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmCierreCajaConcepto.fnLlenarDatos()
    End Sub
#End Region

End Class