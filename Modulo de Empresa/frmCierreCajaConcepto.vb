﻿Imports Telerik.WinControls.UI
Imports System.Linq
Imports Telerik.WinControls
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmCierreCajaConcepto

#Region "Variables"
    Private _codigo As Integer
    Private _bitNormal As Boolean
    Private _bitAjuste As Boolean

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property bitNormal As Boolean
        Get
            bitNormal = _bitNormal
        End Get
        Set(ByVal value As Boolean)
            _bitNormal = value
        End Set
    End Property

    Public Property bitAjuste As Boolean
        Get
            bitAjuste = _bitAjuste
        End Get
        Set(ByVal value As Boolean)
            _bitAjuste = value
        End Set
    End Property

    Dim permiso As New clsPermisoUsuario
#End Region

#Region "LOAD"
    Private Sub frmCierreCajaConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        mdlPublicVars.fnFormatoGridMovimientos(grdCheques)
        fnLlenarDatos()
        fnSumarios()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para llenar los datos
    Public Sub fnLlenarDatos()

        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim bitConfirmado As Boolean

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try


                'Obtenemos el registro del cierre de caja
                Dim cierre As tblCierreCaja = (From x In conexion.tblCierreCajas
                                               Where x.codigo = codigo
                                               Select x).FirstOrDefault

                bitConfirmado = cierre.bitConfirmado

                lblDesde.Text = Format(cierre.desde, mdlPublicVars.formatoFecha)
                lblHasta.Text = Format(cierre.hasta, mdlPublicVars.formatoFecha)
                lblFechaRegistro.Text = Format(cierre.fechaRegistro, mdlPublicVars.formatoFecha)
                lblUsuarioRegistro.Text = cierre.tblUsuario2.nombre
                lblEfectivo.Text = Format(If(cierre.tblCierreCajaDetalles.Count > 0, cierre.tblCierreCajaDetalles.Select(Function(x) x.total).Sum, 0), mdlPublicVars.formatoMoneda)
                lblAjuste2.Text = Format(If(cierre.montoAjuste Is Nothing, 0, cierre.montoAjuste), CStr(mdlPublicVars.formatoMoneda))

                lblTotalEfectivo.Text = Format(CDec(lblEfectivo.Text.Replace("Q", "")) + CDec(lblAjuste2.Text.Replace("Q", "")), mdlPublicVars.formatoMoneda)
                Try
                    lblCheque.Text = Format(cierre.tblCierreCajaDetalleCajas.Select(Function(y) y).Where(Function(y) y.bitCheque).Select(Function(y) y.tblCaja.monto).Sum, mdlPublicVars.formatoMoneda)
                Catch ex As Exception
                    lblCheque.Text = Format(0, mdlPublicVars.formatoMoneda)
                End Try

                lblTotalDeposito.Text = Format(CDec(lblTotalEfectivo.Text.Replace("Q", "")) + CDec(lblCheque.Text.Replace("Q", "")), mdlPublicVars.formatoMoneda)

                lblAnulado.Text = If(cierre.bitAnulado, "SI", "NO")
                lblFechaAnulado.Text = If(cierre.fechaAnulado Is Nothing, "", Format(cierre.fechaAnulado, mdlPublicVars.formatoFecha))
                lblUsuarioAnulo.Text = If(cierre.usuarioAnulado Is Nothing, "", cierre.tblUsuario.nombre)

                lblConfirmado.Text = If(cierre.bitConfirmado, "SI", "NO")
                lblFechaConfirmado.Text = If(cierre.fechaConfirmado Is Nothing, "", Format(cierre.fechaConfirmado, mdlPublicVars.formatoFecha))
                lblUsuarioConfirmo.Text = If(cierre.usuarioConfirmado Is Nothing, "", cierre.tblUsuario1.nombre)
                lblUsuarioAjuste.Text = If(cierre.usuarioAjuste Is Nothing, "", cierre.tblUsuario3.nombre)
                lblFechaAjuste.Text = If(cierre.fechaAjuste Is Nothing, "", Format(cierre.fechaAjuste, mdlPublicVars.formatoFecha))
                lblObservacion.Text = If(cierre.observacionAjuste Is Nothing, "", cierre.observacionAjuste)
                lblAjuste.Text = Format(If(cierre.montoAjuste Is Nothing, 0, cierre.montoAjuste), CStr(mdlPublicVars.formatoMoneda))
                Dim listado = Nothing
                Dim cheques = Nothing


                If bitNormal Then
                    'Obtenemos la lista de entradas y salidas
                    listado = (From x In conexion.tblCajas
                                   Select Codigo = x.codigo, Fecha = x.fecha, Documento = x.documento,
                                   Nombre = If(x.cliente > 0, x.tblCliente.Negocio,
                                              If(x.proveedor > 0, x.tblProveedor.negocio,
                                                 If(x.cliente Is Nothing And x.proveedor Is Nothing, "Movimiento de Caja", ""))),
                                   Descripcion = x.tblTipoPago.nombre,
                                   Entrada = If(x.cliente > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.entrada, x.monto, 0)),
                                   Salida = If(x.proveedor > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.salida, x.monto, 0)))
                Else
                    'Obtenemos la lista de entradas y salidas
                    listado = (From x In conexion.tblCierreCajaDetalles
                               Where x.cierreCaja = codigo
                               Select Categoria = x.tblCajaConcepto.tblCajaCategoria.nombre, Concepto = x.tblCajaConcepto.nombre,
                               Unidad = x.tblCajaConcepto.unidad, Cantidad = x.cantidad, Total = x.total)

                    If cierre.bitConfirmado Then
                        cheques = (From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = codigo And x.bitCheque
                               Select x.idCierreCajaDetalleCheque, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
                               Documento = x.tblCaja.documento, Descripcion = x.tblCaja.descripcion, FechaCobro = x.tblCaja.fechaCobro, Monto = x.tblCaja.monto)
                    Else
                        'cheques = ((From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = codigo And x.bitCheque
                        '        Select x.idCierreCajaDetalleCheque, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
                        '        Documento = x.tblCaja.documento, Descripcion = x.tblCaja.descripcion, FechaCobro = x.tblCaja.fechaCobro, Monto = x.tblCaja.monto, chmAgregar = True).Union(
                        '        ((From x In conexion.tblCajas Where Not x.confirmado And Not x.anulado And x.fecha <= fechaServidor _
                        '        And x.cliente IsNot Nothing And x.tblTipoPago.cheque
                        '        Select idCierreCajaDetalleCheque = 0, x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, FechaCobro = x.fechaCobro, _
                        '        Monto = x.monto, chmAgregar = False).Except(
                        '        From x In conexion.tblCierreCajaDetalleCajas
                        '        Select idCierreCajaDetalleCheque = 0, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio, Documento = x.tblCaja.documento,
                        '        Descripcion = x.tblCaja.descripcion, FechaCobro = x.tblCaja.fechaCobro, Monto = x.tblCaja.monto, chmAgregar = False)))
                        '        )




                        cheques = ((From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = codigo And x.bitCheque
                                Select x.idCierreCajaDetalleCheque, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
                                Documento = x.tblCaja.documento, Descripcion = x.tblCaja.descripcion, FechaCobro = x.tblCaja.fechaCobro, Monto = x.tblCaja.monto, chmAgregar = True).Union(
                                ((From x In conexion.tblCajas Where x.confirmado And Not x.anulado And (x.fechaCobro >= cierre.desde And x.fechaCobro <= cierre.hasta) _
                                And x.cliente IsNot Nothing And x.tblTipoPago.cheque
                                Select idCierreCajaDetalleCheque = 0, x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, FechaCobro = x.fechaCobro, _
                                Monto = x.monto, chmAgregar = False).Except(
                                From x In conexion.tblCierreCajaDetalleCajas
                                Select idCierreCajaDetalleCheque = 0, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio, Documento = x.tblCaja.documento,
                                Descripcion = x.tblCaja.descripcion, FechaCobro = x.tblCaja.fechaCobro, Monto = x.tblCaja.monto, chmAgregar = False)))
                                )


                    End If
                End If

                Me.grdDatos.DataSource = listado

                If cierre.bitConfirmado Then
                    Me.grdCheques.DataSource = cheques
                Else
                    Me.grdCheques.DataSource = EntitiToDataTable(cheques)
                    mdlPublicVars.fnGrid_iconos(grdCheques)
                End If

            Catch ex As Exception

            End Try

            conn.Close()
        End Using


        fnConfiguracion()
        fnConfiguracionCheque(bitConfirmado)
    End Sub

    'Funcion utilizada para agregar las fila summary
    Private Sub fnSumarios()
        If bitNormal Then
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Fecha", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryEntradas As New GridViewSummaryItem("Entrada", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            Dim summarySalida As New GridViewSummaryItem("Salida", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryEntradas, summarySalida})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        End If
    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).ReadOnly = True
            Next
            If bitNormal Then
                Me.grdDatos.Columns("Codigo").IsVisible = False

                'Select Codigo, Fecha, Documento,
                '           Nombre ,Descripcion,Entrada,Salida 

                mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Entrada")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Salida")

                Me.grdDatos.Columns("Fecha").Width = 70
                Me.grdDatos.Columns("Documento").Width = 80
                Me.grdDatos.Columns("Nombre").Width = 120
                Me.grdDatos.Columns("Descripcion").Width = 125
                Me.grdDatos.Columns("Entrada").Width = 80
                Me.grdDatos.Columns("Salida").Width = 80
            ElseIf bitAjuste Then
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Total")

                Me.grdDatos.Columns("Categoria").Width = 100
                Me.grdDatos.Columns("Concepto").Width = 160
                Me.grdDatos.Columns("Unidad").Width = 70
                Me.grdDatos.Columns("Cantidad").Width = 70
                Me.grdDatos.Columns("Total").Width = 85
            End If
        End If
    End Sub

    'Funcion utilizada para configurar el grid de cheques
    Private Sub fnConfiguracionCheque(confirmado As Boolean)
        If Me.grdCheques.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdCheques.ColumnCount - 1
                Me.grdCheques.Columns(i).ReadOnly = True
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdCheques, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdCheques, "Monto")

            Me.grdCheques.Columns("idCierreCajaDetalleCheque").IsVisible = False
            Me.grdCheques.Columns("codigo").IsVisible = False

            Me.grdCheques.Columns("Fecha").HeaderText = "Fecha de Registro"
            Me.grdCheques.Columns("FechaCobro").HeaderText = "Fecha de Cobro"

            Me.grdCheques.Columns("Fecha").Width = 30
            Me.grdCheques.Columns("Cliente").Width = 60
            Me.grdCheques.Columns("Documento").Width = 20
            Me.grdCheques.Columns("Descripcion").Width = 50
            Me.grdCheques.Columns("Monto").Width = 15
            Me.grdCheques.Columns("FechaCobro").Width = 30

            If Not confirmado Then
                Me.grdCheques.Columns("chmAgregar").Width = 20
                Me.grdCheques.Columns("chmAgregar").ReadOnly = False
            End If

            'x.idCierreCajaDetalleCheque, x.tblCaja.codigo, Fecha = x.tblCaja.fecha, Cliente = x.tblCaja.tblCliente.Negocio,
            '            Documento = x.tblCaja.documento, Descripcion = x.tblCaja.descripcion, Monto = x.tblCaja.monto, chmAgregar = True
        End If
    End Sub

    'Modificar una salida
    Private Sub fnModificarCierre()
        Dim success As Boolean = True


        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            Using transaction As New TransactionScope
                Try
                    '-- DETALLE
                    'Recorremos el grid de cheques
                    Dim idCierreCajaDetalle As Integer = 0
                    Dim idCaja As Integer = 0
                    Dim agrega As Boolean = True

                    For Each fila As GridViewRowInfo In Me.grdCheques.Rows
                        idCierreCajaDetalle = fila.Cells("idCierreCajaDetalleCheque").Value
                        idCaja = fila.Cells("codigo").Value
                        agrega = fila.Cells("chmAgregar").Value


                        If agrega Then
                            'Si agrega el cheque
                            If idCierreCajaDetalle = 0 Then
                                'Si no tiene id de detalle, entonces se agrega al cierre de caja
                                'Creamos el detalle del cheque    
                                Dim chequeDetalle As New tblCierreCajaDetalleCaja
                                chequeDetalle.idCierreCaja = codigo
                                chequeDetalle.idCaja = idCaja
                                chequeDetalle.bitEfectivo = False
                                chequeDetalle.bitCheque = True
                                conexion.AddTotblCierreCajaDetalleCajas(chequeDetalle)
                                conexion.SaveChanges()
                            End If
                        Else
                            'Si no se agrega el cheque
                            If idCierreCajaDetalle > 0 Then
                                'Si tiene id de detalle, entonces se elimina del cierre de caja

                                'Obtenemos el registro de la tabla
                                Dim detalle As tblCierreCajaDetalleCaja = (From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCajaDetalleCheque = idCierreCajaDetalle
                                                                             Select x).FirstOrDefault

                                conexion.DeleteObject(detalle)
                                conexion.SaveChanges()
                            End If
                        End If
                    Next
                    'Completar transaccion
                    transaction.Complete()
                Catch ex As Exception
                    success = False
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End Try
            End Using

            If success Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            End If

            conn.Close()
        End Using


    End Sub

    'Funcion utilizada para actualizar el total
    Private Sub fnActualizaTotal()
        'Recorremos el grid
        Dim totalConcepto As Decimal = 0
        Dim total As Decimal = 0
        For i As Integer = 0 To Me.grdDatos.RowCount - 1
            totalConcepto = Me.grdDatos.Rows(i).Cells("total").Value

            total += totalConcepto
        Next

        'Recorremos el grid de cheques
        Dim agrega As Boolean = False
        Dim monto As Decimal = 0
        Dim totalCheques As Decimal = 0
        For i As Integer = 0 To Me.grdCheques.RowCount - 1
            agrega = Me.grdCheques.Rows(i).Cells("chmAgregar").Value
            monto = CDec(Replace(Me.grdCheques.Rows(i).Cells("Monto").Value, "Q", "").Trim)
            If agrega Then
                total += monto
                totalCheques += monto
            End If
        Next

        'Establecemos el total
        lblEfectivo.Text = Format(total, mdlPublicVars.formatoMoneda)
        lblTotalDeposito.Text = Format(totalCheques, mdlPublicVars.formatoMoneda)
    End Sub
#End Region

#Region "Eventos"
    'Doble click en el grid 
    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        If bitNormal Then
            'Doble clic en el grid de pagos
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

            frmVerPago.Text = "Pago No.: " & codigo
            frmVerPago.codigo = codigo
            frmVerPago.StartPosition = FormStartPosition.CenterScreen
            frmVerPago.ShowDialog()
            frmVerPago.Dispose()
        End If
    End Sub

    'MODIFICAR
    Private Sub fnModificar() Handles Me.panel0
        'Verificamos si no esta confirmado el cierre de caja

        Dim bitAnulado As Boolean
        Dim bitConfirmado As Boolean

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                Dim cierreCaja As tblCierreCaja = (From x In conexion.tblCierreCajas.AsEnumerable Where x.codigo = codigo Select x).FirstOrDefault

                bitAnulado = cierreCaja.bitAnulado
                bitConfirmado = cierreCaja.bitConfirmado
            Catch ex As Exception

            End Try

            conn.Close()
        End Using



        If bitAnulado Then
            RadMessageBox.Show("El cierre caja ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        ElseIf bitConfirmado Then
            RadMessageBox.Show("El cierre caja ya ha sido confirmado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            If RadMessageBox.Show("¿Desea modificar el cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnModificarCierre()
            End If
        End If
    End Sub

    'REVISION
    Private Sub fnRevision() Handles Me.panel1
        If bitAjuste Then
            frmCierreCajaRevision.Text = "Revisión"
            frmCierreCajaRevision.idCierreCaja = codigo
            frmCierreCajaRevision.StartPosition = FormStartPosition.CenterScreen
            frmCierreCajaRevision.ShowDialog()
            frmCierreCajaRevision.Dispose()
        End If
    End Sub

    'DOC DE SALIDA
    Private Sub fnDocSalida() Handles Me.panel2
        If bitNormal Then
            'Obtenemos informacion sobre el movimiento de inventario
            Dim cierre As tblCierreCaja = (From x In ctx.tblCierreCajas.AsEnumerable Where x.codigo = codigo
                                                         Select x).FirstOrDefault
            Dim r As New clsReporte
            r.reporte = "rptCierreCaja.rpt"
            ''r.tabla = EntitiToDataTable(From x In ctx.sp_reporteCierreCaja("", codigo) Select x)
            r.nombreParametro = "@filtro"
            r.parametro = "Filtro del reporte:  "

            frmDocumentosSalida.txtTitulo.Text = "Cierre de Caja, Desde: " & Format(cierre.desde, mdlPublicVars.formatoFecha) & " - Hasta: " & Format(cierre.hasta, mdlPublicVars.formatoFecha)
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = False
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()
            permiso.PermisoDialogEspeciales(frmDocumentosSalida)
            frmDocumentosSalida.Dispose()
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel3
        Me.Close()
    End Sub

    'Cambio de valor
    Private Sub grdCheques_ValueChanged(sender As System.Object, e As System.EventArgs) Handles grdCheques.ValueChanged
        Try
            Dim columna As Integer = Me.grdCheques.CurrentColumn.Index
            If Me.grdCheques.RowCount > 0 Then
                If Me.grdCheques.CurrentRow.Index > 0 Then
                    Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                    lbl0Modificar.Focus()
                    lbl0Modificar.Select()
                    fnActualizaTotal()
                    Me.grdCheques.Rows(fila).Cells(columna).IsSelected = True
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'CIERRA FORMULARIO
    Private Sub frmCierreCajaConcepto_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmCierreCajaLista.frm_llenarLista()
    End Sub
#End Region

End Class