﻿Imports System.Data.SqlClient
Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmClientePequenio

    Private Sub frmClientePequenio_Load(sender As Object, e As EventArgs) Handles Me.Load
        limpiarCampos()
    End Sub

    Private Sub pnx1Salir_Click(sender As System.Object, e As System.EventArgs) Handles pnx0Salir.Click, pbx0Salir.Click, lbl0Salir.Click
        mdlPublicVars.superSearchId = 0
        Me.Close()
    End Sub

    Private Sub limpiarCampos()
        txtCliente.Text = ""
        txtDireccion.Text = ""
    End Sub

    Private Sub txtDireccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            fnGuardar()
        End If
    End Sub

    'GUARDAR CLIENTE
    Public Function fnGuardar()
        Dim c As New tblCliente
        Dim bitGuardado As Boolean = False
        Dim success As Boolean = True
        Dim codcliente As Integer = 0
        Dim fecha As Date = fnFecha_horaServidor()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            Try
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                'obtenemos la clave maxima para poder asignarsela al nuevo cliente
                Dim claveMaxima As Integer = (From x In conexion.tblClientes Select CType(x.clave, Integer?)).Max + 1
                c.habillitado = 1
                c.clave = claveMaxima
                c.Negocio = txtCliente.Text
                c.Nombre1 = txtNegocio.Text
                c.Nombre2 = ""
                c.nit1 = txtNit.Text
                c.nit2 = ""
                c.fechaCreacion = fecha
                c.direccionEnvio1 = txtDireccion.Text
                c.direccionEnvio2 = ""
                c.telefono = Nothing
                c.contacto = ""
                c.email = ""
                c.observacion = ""
                c.limiteCredito = 0
                c.porcentajeCredito = 0
                c.diasCredito = 0
                c.idMunicipio = mdlPublicVars.PuntoVentaPequeno_codigoMunicipio ' default. 1
                c.georeferencia = ""
                c.saldo = 0
                c.pagos = 0
                c.pagosTransito = 0
                c.devoluciones = 0
                c.idTipoPago = mdlPublicVars.PuntoVentaPequeno_tipoPago ' 3 Pago de contado por defecto
                c.idVendedor = mdlPublicVars.idVendedor
                c.idTipoNegocio = mdlPublicVars.PuntoVentaPequeno_tipoNegocio ' por defecto negocio local 1
                c.idClasificacionNegocio = mdlPublicVars.PuntoVentaPequeno_ClasificacionNegocio 'Normal por defecto 2
                c.casos = 0
                c.direccionFactura1 = txtDireccion.Text
                c.direccionFactura2 = ""
                c.idEmpresa = mdlPublicVars.idEmpresa
                c.bitMostrador = mdlPublicVars.PuntoVentaPequeno_bitMostrador
                conexion.AddTotblClientes(c)
                conexion.SaveChanges()
                codcliente = c.idCliente


                ''Creacion de un Telefono En Blanco
                Dim tel As New tblClientes_Telefono
                tel.cliente = codcliente
                tel.telefono = ""
                tel.observacion = ""
                conexion.AddTotblClientes_Telefono(tel)
                conexion.SaveChanges()

                'Añadimos el tipo de impresion de Factura por defecto
                Dim cft As New tblCliente_FacturaTipoImpresion
                Dim codigoCliente = (From x In conexion.tblClientes Select x.idCliente).Max

                cft.cliente = codigoCliente
                cft.tipoImpresion = 18  'Factura por defecto
                cft.bitPorcentajeManual = 0
                cft.porcentaje = 0
                conexion.AddTotblCliente_FacturaTipoImpresion(cft)
                conexion.SaveChanges()

                alerta.fnGuardar()
                limpiarCampos()

                mdlPublicVars.superSearchId = c.idCliente
                mdlPublicVars.superSearchNombre = c.Negocio
                mdlPublicVars.superSearchClave = c.clave
                mdlPublicVars.superSearchGenerico1 = c.direccionFactura1
                bitGuardado = True
                conn.Close()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End Using

        If success Then
            alerta.fnGuardar()
        End If

        If bitGuardado = True Then
            Me.Close()
        End If
        Return 0
    End Function

    'GUARDAR
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtCliente.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar el nombre del cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf txtDireccion.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar la direccion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf txtNit.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar el nit", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf txtNegocio.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar el nombre de facturacion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            fnGuardar()
        End If
    End Sub
End Class