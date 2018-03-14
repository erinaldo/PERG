﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmPedidosListaBarraDerecha
    Public alerta As New bl_Alertas
    Dim blPedidos As New bl_Pedidos
    Private permiso As New clsPermisoUsuario

    'Variables para guardar el total a pagar y descuento de la salida que se selecciona.
    Dim totalPagar As Double = 0
    Dim descuento As Double = 0

    Private Sub frmPedidosListaBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl8.Focus()
    End Sub

    'DESPACHAR
    Private Sub fnPanel1() Handles Me.panel1
        If mdlPublicVars.superSearchFilasGrid > 0 Then

            frmPedidosLista.fnCambioFila()

            Dim tipoSalida As String = mdlPublicVars.superSearchNombre
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim salida As tblSalida

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
            

                If tipoSalida = "Cotizado" Then
                    If RadMessageBox.Show("¿Desea pasar la cotización a despacho?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        If blPedidos.fnCotizarDespachar(salida.idSalida, salida.credito, salida.idCliente, conexion) = False Then
                            If RadMessageBox.Show("¿Desea modificar la cotización?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                fnSugerir(salida.idSalida, True)
                            End If
                        Else
                            fnImprimir(salida.idSalida)
                        End If
                    End If
                ElseIf tipoSalida = "Reservado" Then
                    If RadMessageBox.Show("¿Desea pasar la reserva a despacho?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        CambiaReservarAdespacho(salida.idSalida, salida.credito, salida.idCliente)
                        fnImprimir(salida.idSalida)
                    End If
                Else
                    alerta.contenido = "El pedido ya ha sido " & tipoSalida & " no se puede Despachar"
                    alerta.fnErrorContenido()
                End If
                conn.Close()
            End Using
            Me.Hide()
            frmPedidosLista.frm_llenarLista()
        End If
    End Sub

    'FACTURAR
    Private Sub fnPanel2() Handles Me.panel2
        Try
            frmPedidosLista.fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then

                Dim salida As tblSalida
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
                    salida = (From x In conexion.tblSalidas Where x.idSalida = mdlPublicVars.superSearchId Select x).FirstOrDefault
                    conn.Close()
                End Using

                Dim conx3 As dsi_pos_demoEntities
                Using conn3 As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn3.Open()
                    conx3 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim tblsal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                    If tblsal.facturado = True Then

                        frmAlertasPantalla.Text = "Alertas Pantalla"
                        frmAlertasPantalla.lblMensaje.Text = "¡ESTA SALIDA YA FUE FACTURADA!"
                        frmAlertasPantalla.lblPiePagina.Text = "¡SE ENVIARA CORREO INFORMATIVO A GERENCIA GENERAL!"
                        frmAlertasPantalla.WindowState = FormWindowState.Maximized
                        frmAlertasPantalla.StartPosition = FormStartPosition.CenterScreen
                        frmAlertasPantalla.ShowDialog()
                        frmAlertasPantalla.Dispose()

                        conn3.Close()
                        Exit Sub
                    End If

                    conn3.Close()
                End Using

                If salida.anulado = True Or salida.facturado = True Then
                    alerta.contenido = "Venta Facturada o Anulada "
                    alerta.fnErrorContenido()
                    Exit Sub
                End If

                If salida IsNot Nothing Then
                    'Si la salida ya esta revisada
                    If salida.empacado = True And salida.anulado = False Then



                        Dim estado

                        '  Dim consulta As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = codigo And x.anulado = False Select x).ToList

                        'conexion nueva.
                        Dim conexion2 As New dsi_pos_demoEntities

                        Using conn2 As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn2.Open()
                            conexion2 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                            'Obtenemos el estado
                            estado = New List(Of sp_salida_Estado_Result)
                            estado = From x In conexion2.sp_salida_Estado(mdlPublicVars.idEmpresa, salida.idSalida).ToList()
                            conn2.Close()
                        End Using

                       

                        For Each es As sp_salida_Estado_Result In estado
                            If es.clrEnvio <> 1 Then
                                fnFacturar(salida)
                                fnValidarSalida(salida)
                            Else
                                RadMessageBox.Show("Debe autorizar el pedido", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            End If
                        Next
                    Else
                        If salida.anulado Then
                            alerta.contenido = "El pedido ya ha sido anulado"
                        Else
                            alerta.contenido = "El pedido no ha sido revisado"
                        End If
                        alerta.fnErrorContenido()
                    End If
                Else
                    alerta.contenido = "Error en la operacion"
                    alerta.fnErrorContenido()
                End If
            End If
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

    End Sub

    'CAMBIAR A RESERVA
    Private Sub fnPanel3() Handles Me.panel3

        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then

            Dim tipoSalida As String = mdlPublicVars.superSearchNombre
            Dim codigo As Integer = mdlPublicVars.superSearchId

            Dim salida As tblSalida


            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using


            If tipoSalida = "Cotizado" Then
                If RadMessageBox.Show("¿Desea pasar la cotización a reserva?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    If CambiacotizarAreservar(salida.idSalida, salida.credito, salida.idCliente) = False Then
                        If RadMessageBox.Show("¿Desea modificar los datos?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            fnSugerir(salida.idSalida, False)
                            frmPedidosLista.frm_llenarLista()
                        End If
                    End If
                End If
            Else
                alerta.contenido = "El pedido ya ha sido " & tipoSalida & "no se puede Reservar"
                alerta.fnErrorContenido()
            End If


            Me.Hide()
        End If
    End Sub

    'BODEGA
    Private Sub fnPanel4() Handles Me.panel4

        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            frmPedidosLista.fnCambioFila()
            'Muestra la paqueteria de esa salida
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim noEditable As Boolean = False
            Dim salida As tblSalida
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using


            If (salida.empacado = True Or salida.despachar = True Or salida.facturado) And salida.anulado = False Then
                noEditable = False
                frmPedidosBodega.Text = "Bodega"
                frmPedidosBodega.StartPosition = FormStartPosition.CenterScreen
                frmPedidosBodega.idSalida = mdlPublicVars.superSearchId
                frmPedidosBodega.BringToFront()
                frmPedidosBodega.Focus()
                permiso.PermisoFrmEspeciales(frmPedidosBodega, False)
            Else
                alerta.contenido = "No tiene registro de bodega"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    'COTIZAR
    Private Sub fnPanel5() Handles Me.panel5
        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim tipoSalida As String = mdlPublicVars.superSearchNombre
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim salida As tblSalida

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using

            If tipoSalida = "Reservado" Then
                If RadMessageBox.Show("¿Desea pasar la reserva a cotización?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    fnCambiarReservaACotizacion(salida.idSalida, salida.idCliente)
                    frmPedidosLista.frm_llenarLista()
                End If
            Else
                alerta.contenido = "El pedido ya ha sido " & tipoSalida & "no se puede Reservar"
                alerta.fnErrorContenido()
            End If
            Me.Hide()

        End If
    End Sub

    'AUTORIZAR VENTA
    Private Sub fnPanel6() Handles Me.panel6
        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim tipoVenta As String = mdlPublicVars.superSearchEnvio
            'Obtenemos la salida y el usuario

            Dim salida As tblSalida
            Dim usuario As tblUsuario
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                usuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                If mdlPublicVars.superSearchEstado = 1 Then
                    'Fecha del servidor
                    Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
                    If usuario.bitAutorizaVenta Then
                        If RadMessageBox.Show("¿Desea autorizar la venta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            frmIngresaClave.Text = "Ingrese clave"
                            frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
                            permiso.PermisoDialogEspeciales(frmIngresaClave)
                            frmIngresaClave.Dispose()
                            If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) Then
                                salida.autorizado = True
                                salida.usuarioAutorizo = usuario.idUsuario
                                salida.fechaAutorizado = fechaServidor
                                conexion.SaveChanges()
                                RadMessageBox.Show("Venta autorizada correctamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Question)
                                frmPedidosLista.frm_llenarLista()
                            Else
                                RadMessageBox.Show("Clave ingresada incorrecta!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            End If
                        End If
                    Else
                        RadMessageBox.Show("No tiene permisos para autorizar una venta ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If
                End If

                'cerrar la conexion
                conn.Close()
            End Using

        End If

    End Sub

    'REALIZAR PAGO
    Private Sub fnPanel7() Handles Me.panel7
        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            'Obtenemos el saldo del cliente

            Dim cliente As tblCliente
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                cliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = mdlPublicVars.superSearchCodSurtir
                                             Select x).FirstOrDefault
                conn.Close()
            End Using


            frmPagoNuevo.Text = "Pagos"
            frmPagoNuevo.bitCliente = True
            frmPagoNuevo.codigoCP = mdlPublicVars.superSearchCodSurtir
            frmPagoNuevo.lblSaldo.Text = cliente.saldo
            frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
            frmPagoNuevo.ShowDialog()
        End If
    End Sub

    'PAQUETERIA
    Private Sub fnPanel8() Handles Me.panel8
        frmPedidosLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            'Muestra la paqueteria de esa salida
            Dim codigo As Integer = mdlPublicVars.superSearchId

            Dim salida As tblSalida

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using

            If salida.anulado = False Then
                frmPedidosPaqueteria.id = mdlPublicVars.superSearchId
                frmPedidosPaqueteria.Text = "Paqueteria"
                frmPedidosPaqueteria.StartPosition = FormStartPosition.CenterScreen
                frmPedidosPaqueteria.BringToFront()
                frmPedidosPaqueteria.Focus()
                permiso.PermisoDialogEspeciales(frmPedidosPaqueteria)
                frmPedidosPaqueteria.Dispose()
            Else
                alerta.contenido = "Pedido Anulado !!!"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    'PENDIENTES POR SURTIR
    Private Sub fnPanel9() Handles Me.panel9
        Try
            frmPedidosLista.fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Muestra la paqueteria de esa salida
                Dim codigo As Integer = mdlPublicVars.superSearchId
                Dim salida As tblSalida

                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    salida = (From x In conexion.tblSalidas.AsEnumerable Where x.idSalida = codigo Select x).FirstOrDefault
                    conn.Close()
                End Using

                frmPedidosPendientesSurtirConceptos.Text = "Pendientes por Surtir"
                frmPedidosPendientesSurtirConceptos.StartPosition = FormStartPosition.CenterScreen
                frmPedidosPendientesSurtirConceptos.BringToFront()
                frmPedidosPendientesSurtirConceptos.codSalida = codigo
                frmPedidosPendientesSurtirConceptos.codClie = salida.idCliente
                frmPedidosPendientesSurtirConceptos.Focus()
                permiso.PermisoDialogEspeciales(frmPedidosPendientesSurtirConceptos)
                frmPedidosPendientesSurtirConceptos.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'AJUSTES
    Private Sub fnPanel10() Handles Me.panel10
        Try
            frmPedidosLista.fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Muestra la paqueteria de esa salida
                Dim codigo As Integer = mdlPublicVars.superSearchId

                Dim salida As tblSalida
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                    salida = (From x In conexion.tblSalidas.AsEnumerable Where x.idSalida = codigo Select x).FirstOrDefault
                    conn.Close()
                End Using

                frmPedidosAjustesConceptos.Text = "Ajustes"
                frmPedidosAjustesConceptos.StartPosition = FormStartPosition.CenterScreen
                frmPedidosAjustesConceptos.BringToFront()
                frmPedidosAjustesConceptos.codClie = salida.idCliente
                frmPedidosAjustesConceptos.codSalida = codigo
                frmPedidosAjustesConceptos.Focus()
                permiso.PermisoDialogEspeciales(frmPedidosAjustesConceptos)
                frmPedidosAjustesConceptos.Dispose()
            End If
        Catch ex As Exception
        End Try
    End Sub

   

    'Procedimiento que permite cambiar el estado de una Reserva a Despachado.
    Public Sub CambiaReservarAdespacho(ByVal codigo As Integer, ByVal escredito As Boolean, ByVal codcliente As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor

        'crear variable de conexion.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope
                Try
                    'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                    Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                                  Where x.idSalida = codigo Select x).FirstOrDefault
                    'verificar opciones de conversion.
                    If salida.anulado = True Or salida.empacado = True Or salida.despachar = True Then
                        alerta.contenido = "Salida Anulada/Empacada/Despachada/Facturada No se puede convertir !!!  "
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    'verificar si esta reservado
                    If salida.reservado = False Then
                        alerta.contenido = "Salida no esta en reserva !!!"
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    'crear registro de salida bodega.
                    Dim sb As New tblsalidaBodega
                    sb.idsalida = codigo
                    conexion.AddTotblsalidaBodegas(sb)
                    conexion.SaveChanges()

                    'pasar despachar a true
                    If escredito = True Then
                        salida.despachar = True
                        Dim dia = Weekday(fechaVencimiento, vbMonday)
                        Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
                        Dim diasCredito As Integer = (From x In conexion.tblClienteTipoPagoes Where x.idtipoPago = cli.idTipoPago Select x.dias).First

                        If diasCredito = 5 Then
                            If dia = 1 Then
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito)
                            Else
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 1)
                            End If
                        End If

                        If diasCredito = 20 Then
                            If dia >= 1 And dia <= 4 Then
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 3)
                            Else
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 4)
                            End If
                        End If
                        salida.fechaDespachado = fecha
                    Else
                        salida.despachar = True
                        salida.fechaDespachado = fecha
                    End If

                    salida.saldo = salida.total
                    salida.pagado = 0
                    salida.fechaVencimientoReserva = Nothing
                    salida.fechaRegistro = fecha
                    salida.fechaDespachado = fecha
                    salida.fechaFiltro = fecha
                    conexion.SaveChanges()
                    Dim sal As Decimal
                    sal = salida.total

                    'Actualizamos la fecha de ultima compra del cliente
                    Dim cliente As tblCliente = (From c In conexion.tblClientes
                                                 Where c.idCliente = salida.idCliente Select c).FirstOrDefault
                    cliente.FechaUltimaCompra = salida.fechaDespachado
                    conexion.SaveChanges()


                    'descontar la reserva de inventario.
                    Dim consulta As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = codigo And x.anulado = False Select x).ToList
                    Dim fila As tblSalidaDetalle

                    For Each fila In consulta
                        fila.precioFactura = fila.precio
                        Dim id As Integer = fila.idArticulo
                        'seleccionar el registro de inventario por medio del idempresa y articulo.
                        Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                           Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = id _
                                                           And x.idTipoInventario = fila.tipoInventario
                                                           Select x).First

                        If fila.tblArticulo.bitProducto Then
                            'Descontamos de reserva
                            inventario.reserva = inventario.reserva - fila.cantidad
                            inventario.salida = inventario.salida + fila.cantidad

                            conexion.SaveChanges()
                            'ElseIf fila.tblArticulo.bitKit Then
                            '    inventario.salida = inventario.salida + fila.cantidad
                            '    inventario.saldo = inventario.saldo - fila.cantidad
                            '    conexion.SaveChanges()
                        End If

                        'Verificamos si tiene pendientes por pedir
                        Dim lPendientes As List(Of tblPendientePorPedir) = (From x In conexion.tblPendientePorPedirs
                                                                             Where x.bitCreado And Not x.anulado And x.saldo > 0 And x.articulo = id
                                                                             Select x).ToList
                        Dim cantidadDescontar As Integer = fila.cantidad
                        'Recorremos la lista de pendientes
                        For Each pendiente As tblPendientePorPedir In lPendientes
                            If cantidadDescontar > pendiente.saldo Then
                                cantidadDescontar -= pendiente.saldo
                                pendiente.saldo = 0
                            Else
                                pendiente.saldo -= cantidadDescontar
                                cantidadDescontar = 0
                            End If
                            conexion.SaveChanges()
                            If cantidadDescontar = 0 Then
                                Exit For
                            End If
                        Next
                    Next
                     
                    'confirmar todos los cambios.
                    conexion.SaveChanges()

                    ''-----********------------IMPUESTOS-*-*-*-*--*-*-------------------**************
                    If Activar_Impuestos = True Then
                        Dim totalcon As Decimal
                        totalcon = CDec(Replace(sal, "Q", "").Trim)

                        Dim impuesto = (From x In conexion.tblImpuestoPagar_TipoMovimiento, y In conexion.tblImpuestoPagar_Impuesto, z In conexion.tblImpuestoes Where y.idImpuestoPagar = x.idImpuestoPagar _
                                        And z.idImpuesto = y.idImpuesto And x.idTipoMovimiento = Salida_TipoMovimientoVenta Select z.idImpuesto, z.nombre, z.formula)

                        Dim impuestos As DataTable = mdlPublicVars.EntitiToDataTable(impuesto)

                        Dim idimpues As Integer = 0
                        Dim nombreimpuesto As String = ""
                        Dim formu As String = ""
                        Dim expresionpostfija As String = ""
                        Dim validador As New clsValidar
                        Dim convertidor As New clsConvertir
                        Dim resuelve As New clsResolver
                        Dim impues As Decimal = 0
                        Dim totalString As String = ""

                        For Each fil As DataRow In impuestos.Rows

                            totalString = CStr(totalcon)
                            idimpues = fil.Item("idImpuesto")
                            nombreimpuesto = fil.Item("nombre")
                            formu = fil.Item("formula")
                            formu = formu.Replace("dato", CStr(totalString))

                            If validador.validar(formu) Then
                                expresionpostfija = convertidor.fnConvierte(formu)
                                impues = CDec(resuelve.fnResolver(expresionpostfija))

                                Dim impuestosalida As New tblImpuesto_Salida
                                impuestosalida.idImpuesto = idimpues
                                impuestosalida.idSalida = codigo
                                impuestosalida.descripcion = nombreimpuesto
                                impuestosalida.valor = impues

                                conexion.AddTotblImpuesto_Salida(impuestosalida)
                                conexion.SaveChanges()

                            End If

                        Next
                    End If
                    ''-------------************FIN DE IMPUESTOS************----------------------------

                    'paso 8, completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        RadMessageBox.Show("Error al Guardar " + ex.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using
            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            End If

            'cerrar la conexion
            conn.Close()
        End Using
    End Sub

    'Procedimiento que permite cambiar el Estado de una salida de Cotizado a á Reservado.
    Public Function CambiacotizarAreservar(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        'agregar variable de conexion.
        Dim conexion As New dsi_pos_demoEntities

        'agregar cadena de conexion.
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)

            'abrir la conexion.
            conn.Open()

            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Using transaction As New TransactionScope
                Try

                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                    'verificar si esta anulado.
                    If salida.anulado = True Or salida.empacado = True Or salida.despachar = True Then
                        alerta.contenido = "Salida Anulada/Empacada/Despachada/Facturada Actualice la Lista !!!  "
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    'verificar si esta reservado
                    If salida.reservado = True Then
                        alerta.contenido = "Salida ya esta Reservada !!!"
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    Dim ArtEmpresa

                    'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                    Dim NombreArt As String
                    Dim CodArticulo As Integer
                    Dim Pedido As Integer
                    Dim saldo As Integer
                    Dim tInventario As Integer
                    Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles
                                                                 Join y In conexion.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                                 Where x.idSalida = codigo And x.anulado = False
                                                                 Select x).ToList


                    'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
                    For Each fila As tblSalidaDetalle In Detalles
                        NombreArt = fila.tblArticulo.nombre1
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        tInventario = fila.tipoInventario

                        If fila.tblArticulo.bitProducto Then
                            'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                            ArtEmpresa = (From AE In conexion.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                          And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                            If ArtEmpresa.saldo < Pedido Then
                                saldo = Pedido - ArtEmpresa.saldo
                                'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                                errContenido += "El articulo: " & NombreArt & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo.ToString + vbCrLf
                                success = False
                            End If
                        End If
                    Next

                    'Si existe un error mandamos el mensaje e interrumpimos la aplicación
                    If success = False Then
                        RadMessageBox.Show(errContenido, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Exit Try
                    End If

                    'Definimos la fecha en que vencerá la reserva
                    Dim diaSemana As Integer = Weekday(mdlPublicVars.fnFecha_horaServidor, vbMonday)
                    Dim fechaActual As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim fechaReserva As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim dias As Integer = 0
                    Try
                        Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", mdlPublicVars.Salida_ReservaDias)
                        dias = CInt(cadDias)
                    Catch ex As Exception
                        dias = mdlPublicVars.Salida_ReservaDias
                    End Try

                    If (diaSemana = 1) Then
                        fechaReserva = fechaActual.AddDays(dias)
                    Else
                        fechaReserva = fechaActual.AddDays(dias + 1)
                    End If

                    'pasar reservado  a true
                    salida.reservado = True
                    salida.fechaVencimientoReserva = fechaReserva

                    conexion.SaveChanges()

                    'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                    For Each fila As tblSalidaDetalle In Detalles
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        fila.precioFactura = fila.precio
                        ''actualizar el modelo
                        'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
                        'conexion.SaveChanges()


                        'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                        Dim inve As tblInventario = (From x In conexion.tblInventarios _
                                                      Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                                      And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idArticulo = CodArticulo Select x).First

                        'descontar existencias.
                        inve.saldo = inve.saldo - Pedido
                        inve.reserva = inve.reserva + Pedido

                        conexion.SaveChanges()
                    Next

                    'completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        success = False
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'liberar la conexion
            conn.Close()
        End Using
        Return success
    End Function

    'Cotizacion a despacho
    Private Sub fnSugerir(ByVal codigo As Integer, ByVal bitSugerirDespacho As Boolean)
        frmSalidas.Text = "Editar Pedido "
        frmSalidas.codigo = codigo
        frmSalidas.bitEditarBodega = False
        frmSalidas.bitEditarSalida = True
        frmSalidas.bitSugerirDespacho = bitSugerirDespacho
        frmSalidas.bitSugerirReserva = Not bitSugerirDespacho
        frmSalidas.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(frmSalidas, False)
    End Sub

    Private Sub frmPedidosListaBarraDerecha_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPedidosLista.frm_llenarLista()
    End Sub

    'Funcion que se utiliza para poder cambiar una reserva a cotizacion
    Public Sub fnCambiarReservaACotizacion(ByVal codigo As Integer, ByVal codCliente As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        'crear variable de conexion.
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope

                Try

                    'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                    Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                                  Where x.idSalida = codigo Select x).First

                    'verificar si esta anulado.
                    If salida.anulado = True Or salida.empacado = True Or salida.despachar = True Then
                        alerta.contenido = "Salida Anulada/Empacada/Despachada/Facturada No se puede convertir !!!  "
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    'verificar si esta reservado
                    If salida.reservado = False Then
                        alerta.contenido = "Salida no esta en reserva !!!"
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If


                    salida.reservado = False
                    salida.fechaVencimientoReserva = Nothing
                    salida.cotizado = True
                    salida.fechaFiltro = fecha
                    conexion.SaveChanges()

                    'descontar la reserva de inventario.
                    Dim consulta As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = codigo And x.anulado = False Select x).ToList
                    Dim fila As tblSalidaDetalle
                    For Each fila In consulta
                        Dim id As Integer = fila.idArticulo
                        If fila.tblArticulo.bitProducto Then
                            'seleccionar el registro de inventario por medio del idempresa y articulo.
                            Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                               Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = id Select x).First

                            'Descontamos de inventario
                            inventario.reserva -= fila.cantidad
                            inventario.saldo += fila.cantidad
                            conexion.SaveChanges()
                        End If
                    Next

                    'paso 8, completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion.
            conn.Close()

        End Using


    End Sub

    'Funcion utilizada para imprimir el despacho
    Private Sub fnImprimir(ByVal codSalida)
        Dim c As New clsReporte
        Dim tabla As DataTable

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
            conn.Close()
        End Using

        Try
            c.tabla = tabla
            c.nombreParametro = "@filtro"
            c.reporte = "ventas_Picking.rpt"
            c.parametro = ""
            c.verReporte()
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    'Funcion utilizada para realizar el proceso de facturacion
    Private Sub fnFacturar(ByVal salida As tblSalida)
        'variables.
        Dim nFacturas As Integer = 0
        Dim xx
        Dim agregar As Integer = 0
        Dim codigoCliente
        Dim direccion1
        Dim total1
        Dim vendedor1
        Dim documento1
        Dim fecha1
        Dim pagos1
        Dim codigo1

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

        'consultas a bd.
            Dim consulta = (From x In conexion.tblSalidas _
                                                      Where x.idSalida = salida.idSalida And salida.facturado = False And x.anulado = False _
                                                      Select Codigo = x.idSalida, Pagos = If(x.contado = True, "Contado", "Credito"),
                                                      Fecha = x.fechaRegistro, Documento = x.documento, _
                                                      DireccionFacturacion = x.direccionFacturacion,
                                                      Vendedor = x.tblVendedor.nombre, Total = x.total, clrEstado = 0, Estado = "Revisado",
                                                      Descripcion = "", Clave = salida.idCliente).FirstOrDefault
            
            codigo1 = consulta.Codigo
            pagos1 = consulta.Pagos
            fecha1 = consulta.Fecha
            documento1 = consulta.Documento
            vendedor1 = consulta.Vendedor
            total1 = consulta.Total
            direccion1 = consulta.DireccionFacturacion
            codigoCliente = consulta.Clave

            Dim consFacturas = (From x In conexion.tblSalidas
                                    Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa _
                                    And x.idCliente = salida.idCliente And x.cliente = salida.cliente And x.direccionEnvio = salida.direccionEnvio And x.nit = salida.nit _
                                     And x.anulado = False Select x.idSalida).ToList()

        
        For Each xx In consFacturas
                Dim estado = conexion.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).ToList
                For Each es As sp_salida_Estado_Result In estado
                    nFacturas = nFacturas + 1
                Next
        Next
            'seleccionar todos los detalles 
            ' Dim detalles As List(Of tblSalidaDetalle) = (From y In conexion.tblSalidaDetalles Where y.idSalida = salida.idSalida Select y).ToList

            'cerrar la conexion.
            conn.Close()

            'fin de proceso.
        End Using

        If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            Dim codigoFactura As Integer = 0
            Dim total As Decimal = mdlPublicVars.fnTotalTablaFacturas

            codigoFactura = mdlPublicVars.GuardarFacturacion(codigo1) 'codigo1 guarda el idsalida en la consulta de arriba
        End If
        frmPedidosLista.frm_llenarLista()
    End Sub

    Private Sub fnPanle11() Handles Me.panel11
        Try
            frmPedidosLista.fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then
                Dim codigo As Integer = mdlPublicVars.superSearchId
                frmSalidaEnvio.Codigo = codigo
                frmSalidaEnvio.bitTemporal = False
                frmSalidaEnvio.Text = "Guias de Pedidos"
                frmSalidaEnvio.ShowDialog()
                frmSalidaEnvio.Dispose()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnValidarSalida(ByVal salida As tblSalida)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                If CInt(ClienteSucursal) = CInt(salida.idCliente) Then

                    ''Dim val = conexion.sp_crear_compra_sucursal(salida.idSalida, "Trans-", ServidorSucursal, BDSucursal)

                End If

                conn.Close()
            End Using
        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
