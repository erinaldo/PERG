﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmProveedorClasificacionNegocio
    Public codigoCliente As Integer

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmProveedorBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try
        fnllenaCombos()
        llenagrid()

    End Sub

    Private Sub fnllenaCombos()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                'Contabilidad Combos

                Dim partida = (From x In conexion.tblPartidas Select Codigo = x.idpartida, Nombre = x.descripcion)

                With Me.cmbPartida
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = partida
                End With

                Dim departamento = (From x In conexion.tblDepartamentoEmpresas Select Codigo = x.iddepartamento, Nombre = x.descripcioin)

                With cmbDepartamento
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = departamento
                End With

                Dim pago = (From x In conexion.tblTipoPagoGastos Select codigo = x.idtipopago, nombre = x.descripcion)

                With cmbTipoPago
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = pago
                End With

                Dim gasto = (From x In conexion.tblTipoGastoes Select codigo = x.idtipogasto, nombre = x.descripcion)

                With cmbTipoGasto
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = gasto
                End With

                Dim tipocompra = (From x In conexion.tblTipoCompras Select codigo = x.idtipocompra, nombre = x.descripcion)

                With cmbTipoCompra
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = tipocompra
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim Data = From x In conexion.tblProveedorClasificacionNegocios _
                   Select Codigo = x.idProveedorClasificacionNegocio, Nombre = x.nombre, Partida = x.tblPartida.descripcion, _
                   Departamento = x.tblDepartamentoEmpresa.descripcioin, TipoPago = x.tblTipoPagoGasto.descripcion, _
                   TipoGasto = x.tblTipoGasto.descripcion, TipoCompra = x.tblTipoCompra.descripcion

                'Llenamos el grid de los datos con la consulta..
                Me.grdDatos.DataSource = Data

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblProveedorClasificacionNegocio
        Try
            m.nombre = txtNombre.Text
            m.idtipopago = Me.cmbTipoPago.SelectedValue
            m.idtipogasto = Me.cmbTipoGasto.SelectedValue
            m.idpartida = Me.cmbPartida.SelectedValue
            m.idtipocompra = Me.cmbTipoCompra.SelectedValue
            m.iddepartamento = Me.cmbDepartamento.SelectedValue

            ctx.AddTotblProveedorClasificacionNegocios(m)
            ctx.SaveChanges()
            alertas.fnGuardar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try
            Dim m As tblProveedorClasificacionNegocio = (From e1 In ctx.tblProveedorClasificacionNegocios Where e1.idProveedorClasificacionNegocio = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.idtipopago = Me.cmbTipoPago.SelectedValue
            m.idtipogasto = Me.cmbTipoGasto.SelectedValue
            m.idpartida = Me.cmbPartida.SelectedValue
            m.idtipocompra = Me.cmbTipoCompra.SelectedValue
            m.iddepartamento = Me.cmbDepartamento.SelectedValue

            ctx.SaveChanges()
            alertas.fnModificar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro
        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblProveedorClasificacionNegocio = (From e1 In ctx.tblProveedorClasificacionNegocios Where e1.idProveedorClasificacionNegocio = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
End Class