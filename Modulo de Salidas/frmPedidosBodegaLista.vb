﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.EntityClient

Public Class frmPedidosBodegaLista
    Dim alerta As New bl_Alertas
    Private permiso As New clsPermisoUsuario

    Private Sub frmPedidosBodegaLista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Try
            Dim iz As New frmPedidosFacturasBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

            'desactivar Barra derecha
            pnlOpciones.Visible = False
        Catch ex As Exception
        End Try

        llenagrid()
        fnCambioFila()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filaAct As Integer = filaActual
            Dim filtro As String = txtFiltro.Text

            ''Dim consulta = (From x In ctx.tblsalidaBodegas Where x.tblSalida.anulado = False And (x.tblSalida.empacado = True Or x.tblSalida.despachar = True Or x.tblSalida.facturado = True) _
            ''                Select Bodega = x.idsalidaBodega, Salida = x.idsalida, Documento = x.tblSalida.documento, Negocio = x.tblSalida.cliente,
            ''                Fecha = x.tblSalida.fechaRegistro, Vendedor = x.tblSalida.tblVendedor.nombre, _
            ''                txbSacado = x.tblEmpleado.nombre, txbEmpacado = x.tblEmpleado2.nombre, txbRevisado = x.tblEmpleado1.nombre, txmObservacion = x.observacion
            ''                Order By Fecha Descending)
            ''Me.grdDatos.DataSource = consulta

            Dim consulta = ctx.sp_bodega_lista()
            Me.grdDatos.DataSource = consulta

            fnConfiguracion(filaAct)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion(ByVal fila As Integer)
        If Me.grdDatos.Rows.Count >= 0 Then
            Dim filaActual2 = grdDatos.CurrentRow.Index
            If grdDatos.RowCount > 0 Then
                Me.grdDatos.Rows(fila).IsCurrent = True
                Me.grdDatos.Rows(fila).IsSelected = True
            End If

            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)

            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdDatos.Columns("Bodega").Width = 60
            Me.grdDatos.Columns("Salida").Width = 60
            Me.grdDatos.Columns("Documento").Width = 60
            Me.grdDatos.Columns("Negocio").Width = 120
            Me.grdDatos.Columns("Errores").Width = 50
            Me.grdDatos.Rows(filaActual).Cells("txmObservacion").ReadOnly = False
        End If
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        If Me.grdDatos.Rows.Count > 0 Then
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchInventario = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Salida").Value, Integer)
                filaActual = grdDatos.CurrentRow.Index
                Me.grdDatos.Rows(filaActual).Cells("txmObservacion").ReadOnly = False
            End If
        End If
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                ''fnDatos()
            End If
        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub

    'Funcion utilizada para ver los datos de bodega
    Private Sub fnDatos()
        Dim fechahoraserver As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim fil As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        Dim col As Integer = Me.grdDatos.CurrentColumn.Index

        Dim codbodega As Integer = Me.grdDatos.Rows(fil).Cells(1).Value

        'Sacado
        If Me.grdDatos.Columns(col).Name.ToString.ToLower = "txbsacado" Then
            Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = mdlPublicVars.Bodega_CodigoPuestoBodegero Select Codigo = x.idEmpleado, Nombre = x.nombre)
            frmCombo.Text = "Seleccionar Sacado"
            With frmCombo.combo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons
            End With
            frmCombo.ShowDialog()

            If mdlPublicVars.superSearchId = 0 Then
            Else
                'actualizar
                Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                bodega.sacado = mdlPublicVars.superSearchId
                bodega.fechaSacado = fechahoraserver
                ctx.SaveChanges()
                alerta.contenido = "Registro Actualizado"
                alerta.fnErrorContenido()
                frm_llenarLista()
            End If
        End If ' fin de sacado.

        'Sacado
        If Me.grdDatos.Columns(col).Name.ToString.ToLower = "txbrevisado" Then
            Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = Bodega_CodigoPuestoBodegero Select Codigo = x.idEmpleado, Nombre = x.nombre)
            frmCombo.Text = "Seleccionar Sacado"
            With frmCombo.combo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons
            End With
            frmCombo.ShowDialog()

            If mdlPublicVars.superSearchId = 0 Then
            Else
                'actualizar
                Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                bodega.revisado = mdlPublicVars.superSearchId
                bodega.fechaRevisado = fechahoraserver
                ctx.SaveChanges()
                alerta.contenido = "Registro Actualizado"
                alerta.fnErrorContenido()
                frm_llenarLista()
            End If
        End If ' fin de revisado

        'Empacado
        If Me.grdDatos.Columns(col).Name.ToString.ToLower = "txbempacado" Then
            Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = mdlPublicVars.Bodega_CodigoPuestoBodegero Select Codigo = x.idEmpleado, Nombre = x.nombre)
            frmCombo.Text = "Seleccionar Empacado"
            With frmCombo.combo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons
            End With
            frmCombo.ShowDialog()

            If mdlPublicVars.superSearchId = 0 Then
            Else
                'actualizar
                Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                bodega.empacado = mdlPublicVars.superSearchId
                bodega.fechaEmpacado = fechahoraserver
                ctx.SaveChanges()
                alerta.contenido = "Registro Actualizado"
                alerta.fnErrorContenido()
                frm_llenarLista()
            End If
        End If ' fin de Empacado

        'Observacion
        If Me.grdDatos.Columns(col).Name.ToString.ToLower = "txmobservacion" Then
            'Obtenemos el valor de la observacion
            Dim conexion As dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim observacion As String = Me.grdDatos.Rows(fil).Cells(col).Value
                frmTexto.Text = "Ingresar Observacion"
                frmTexto.texto = observacion
                frmTexto.StartPosition = FormStartPosition.CenterScreen
                frmTexto.ShowDialog()


                If frmTexto.guarda = True Then
                    'actualizar
                    Dim filaac = grdDatos.CurrentRow.Index
                    Dim codigobodega As Integer = Me.grdDatos.Rows(filaac).Cells("Bodega").Value
                    Dim bodega2 As tblsalidaBodega = (From x In conexion.tblsalidaBodegas Where x.idsalidaBodega = codigobodega Select x).First

                    bodega2.observacion = mdlPublicVars.superSearchNombre
                    conexion.SaveChanges()
                    alerta.contenido = "Registro Actualizado"
                    alerta.fnErrorContenido()
                    frm_llenarLista()
                End If
                conn.Close()
            End Using

        End If ' fin de Empacado
    End Sub

    'VER
    Private Sub frm_Ver() Handles Me.verRegistro
        Try
            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    Dim codigo As Integer = mdlPublicVars.superSearchInventario
                    frmPedidoConcepto.Text = "Pedidos"
                    frmPedidoConcepto.idSalida = codigo
                    frmPedidoConcepto.WindowState = FormWindowState.Normal
                    frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmPedidoConcepto, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'MODIFICAR
    Private Sub fnModificar() Handles Me.modificaRegistro
        fnDatos()
    End Sub

    Private Sub frmPedidosBodegaLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Bodega-Pedidos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
