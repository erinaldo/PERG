﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Telerik.WinControls.Primitives
Imports System.Windows



Public Class frmClienteLista
    Public filtroActivo As Boolean
    Dim permiso As New clsPermisoUsuario
    Dim cont As Integer = 0

    Private Sub frmClienteLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmClienteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdDatos.ImageList = frmControles.ImageListAdministracion
            lbl2Eliminar.Text = "Deshabilitar"
            Dim iz As New frmClientesBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmClientesBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        fnLlenarCombos()
        Me.cmbEstado.SelectedValue = 1
        llenagrid()

        Try
            fnVerificarRecordatorio()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombos()
        ''Try

        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("Codigo") = CInt(Val("0"))
        dr("Descripcion") = "Deshabilitados"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = CInt(Val("1"))
        dr("Descripcion") = "Habilitados"
        dt.Rows.Add(dr)

        With cmbEstado
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            .DataSource = dt
        End With
        ''cmbEstado.DataSource = dt
        ''cmbEstado.ValueMember = "Codigo"
        ''cmbEstado.DisplayMember = "Descripcion"

        cmbEstado.SelectedValue = 1
        ''Catch ex As Exception

        ''End Try
    End Sub

    Private Sub fnsumarios()
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)

        Dim summarySaldo As New GridViewSummaryItem("Saldo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summarySaldoVencido As New GridViewSummaryItem("SaldoVencido", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summaryLimiteSaldo As New GridViewSummaryItem("LimiteSaldo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)


        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summarySaldo, summarySaldoVencido, summaryLimiteSaldo})


        'agregar summario arreglo a grid
        grdDatos.SummaryRowsTop.Add(summaryRowItem)

    End Sub
    Private Sub llenagrid()

        Try
            Dim filtro As String = txtFiltro.Text
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim validacion As Integer = Me.cmbEstado.SelectedValue
                Dim val As Boolean

                If validacion = 0 Then
                    val = False
                Else
                    val = True
                End If

                Dim companyInfo = conexion.sp_lista_clientes(mdlPublicVars.idEmpresa, filtro, val)
                Me.grdDatos.DataSource = companyInfo
                'cerrar la conexion.
                conn.Close()
            End Using

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnConfiguracion()
            If cont = 0 Then
                fnsumarios()
            Else
            End If
            cont = cont + 1
Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            Try
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Saldo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "LimiteSaldo")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaUltimaCompra")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "fechaUltimoPago")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "SaldoVencido")

                Me.grdDatos.Columns("LimiteSaldo").HeaderText = "Limite de Saldo"
                Me.grdDatos.Columns("FechaUltimaCompra").HeaderText = "Ult.Compra"

                Me.grdDatos.Columns("fechaUltimoPago").HeaderText = "Ulti.Pago"


                For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("ID").IsVisible = False

                Me.grdDatos.Columns("Clave").Width = 50
                Me.grdDatos.Columns("Negocio").Width = 160
                Me.grdDatos.Columns("chkHabilitado").Width = 62
                ''Me.grdDatos.Columns("Telefono").Width = 70
                Me.grdDatos.Columns("Pais").Width = 70
                Me.grdDatos.Columns("Categoria").Width = 120
                Me.grdDatos.Columns("Departamento").Width = 90
                Me.grdDatos.Columns("Municipio").Width = 90
                Me.grdDatos.Columns("Saldo").Width = 90
                Me.grdDatos.Columns("SaldoVencido").Width = 80
                Me.grdDatos.Columns("LimiteSaldo").Width = 80
                Me.grdDatos.Columns("FechaUltimaCompra").Width = 80
                Me.grdDatos.Columns("fechaUltimoPago").Width = 80
                Me.grdDatos.Columns("Vendedor").Width = 95
                ''Me.grdDatos.Columns("clrEstadoCred").Width = 70
                '' Me.grdDatos.Columns("DiasCred").Width = 60
                '' Me.grdDatos.Columns("clrFrecCompra").Width = 70
                '' Me.grdDatos.Columns("DiasCompra").Width = 60
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        frmClientes.seleccionDefault = False
        frmClientes.Text = "Modulo de Clientes"
        frmClientes.NuevoIniciar = True
        permiso.PermisoMantenimientoTelerik2(frmClientes, False)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        frmClientes.seleccionDefault = True
        frmClientes.codigoDefault = mdlPublicVars.superSearchId
        frmClientes.NuevoIniciar = False
        frmClientes.Text = "Modulo de Clientes"
        permiso.PermisoMantenimientoTelerik2(frmClientes, False)
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        fnDeshabilita(grdDatos.Rows(fila).Cells(0).Value())
        Call llenagrid()
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        frmClientes.seleccionDefault = True
        frmClientes.codigoDefault = mdlPublicVars.superSearchId
        frmClientes.NuevoIniciar = False
        frmClientes.verRegistro = True
        frmClientes.Text = "Modulo de Clientes"
        permiso.PermisoMantenimientoTelerik2(frmClientes, False)
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("ID").Value, Integer)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.RowCount
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para desabilitar un cliente
    Private Sub fnDeshabilita(ByVal codigo As Integer)
        Dim success As Boolean = True
        Try
            'Obtenemos el cliente con ese codigo
            Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault

            'Deshabilitamos al cliente
            cli.habillitado = False
            ctx.SaveChanges()
        Catch ex As Exception
            success = False
        End Try

        If success = True Then
            alertas.fnModificar()
        Else
            alertas.fnErrorModificar()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        Try
            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = Me.grdDatos.Rows(index).Cells(0).Value

            frmDocumentosSalida.txtTitulo.Text = "Lista de Clientes"
            frmDocumentosSalida.grd = Me.grdDatos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codigo
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmClientesFiltro.Text = "Filtro: CLIENTES"
        frmClientesFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmClientesFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
    End Sub

    Private Sub fnVerificarRecordatorio()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim recordatorio As String = ""

                Dim listabitacoras As List(Of tblBitacora) = (From x In conexion.tblBitacoras Where x.cerrado = False Select x).ToList

                For Each bitacora As tblBitacora In listabitacoras

                    Dim fecha As Date = fnFechaServidor()

                    If CDate(bitacora.programacion).ToShortDateString = fecha Then
                        recordatorio += bitacora.tblCliente.Nombre1 + ","
                    End If
                Next

                ''Dim contador = (From x In conexion.tblSalidas Where x.reservado = True Select x).Count
                If recordatorio.Length > 0 Then
                    RadMessageBox.Show("Los Clientes con Programacion(Recordatorio) para hoy son: " + CStr(recordatorio), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedValueChanged
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        Try

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

            Dim cliente As Integer = Me.grdDatos.Rows(fila).Cells("Id").Value

            If e.KeyCode = Keys.F4 Then
                frmTelefonosCliente.Text = "Telefonos"
                frmTelefonosCliente.StartPosition = FormStartPosition.CenterScreen
                frmTelefonosCliente.WindowState = FormWindowState.Normal
                frmTelefonosCliente.idCliente = cliente
                frmTelefonosCliente.ShowDialog()
                frmTelefonosCliente.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class