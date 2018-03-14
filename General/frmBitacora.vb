﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmBitacora
    Dim permiso As New clsPermisoUsuario
    Public modifica As Boolean
    Public ver As Boolean
    Public superSearchId As Integer = 0

    Private _idCliente As Integer
    Private _idVendedor As Integer
    Private _fecha As DateTime
    Private _proveedor As Boolean
    Private terminado As Boolean = False
    Private modificar As Boolean = False
    Private codigomodificar As Integer

    Private Sub frmBitacora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.StartPosition = CenterToParent()

        Me.grdSoluciones.Rows.Clear()
        limpiaCampos()
        llenarCombos()
        fnActivaRecordatorio()
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        mdlPublicVars.fnFormatoGridEspeciales(grdSoluciones)
        If modifica = True Then
            fnLlenarBitacora()
        End If

        If ver = True Then
            fnLlenarBitacora()
            fnBloquear()
        End If
        fnHistorial()

        terminado = True
        modificar = False
    End Sub

    Public Property idCliente() As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property

    Public Property idVendedor() As Integer
        Get
            idVendedor = _idVendedor
        End Get
        Set(ByVal value As Integer)
            _idVendedor = value
        End Set
    End Property

    Public Property fecha() As DateTime
        Get
            fecha = _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property proveedor() As Boolean
        Get
            proveedor = _proveedor
        End Get
        Set(ByVal value As Boolean)
            _proveedor = value
        End Set
    End Property

    'AGREGAR
    Private Sub pbAgregar_Click() Handles Me.panel0
        Try
            If modificar = False Then
                If ver = False Then
                    fnGuardarBitacora()
                End If
            Else
                fnModificar()
            End If
            
        Catch ex As Exception
            mdlPublicVars.superSearchId = -1
            mdlPublicVars.superSearchNombre = ""
            mdlPublicVars.Observacion = ""
        End Try

        Me.Close()
        modificar = False
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub fnGuardarBitacora()
        Dim success As Boolean = True
        Try
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try
                    If Me.txtObservacion.Text <> "" Then
                        Dim bitacora As New tblBitacora
                        If modifica = True Then
                            Dim modificaBitacora = (From x In ctx.tblBitacoras Where x.IdBitacora = superSearchId Select x).FirstOrDefault
                            bitacora = modificaBitacora
                        End If

                        Dim fecha As DateTime = fnFecha_horaServidor()

                        'Guardamos la bitacora
                        bitacora.FechaRegistro = fecha
                        bitacora.FechaTransaccion = fecha
                        bitacora.IdUsuario = mdlPublicVars.idUsuario
                        bitacora.IdEmpresa = mdlPublicVars.idEmpresa
                        bitacora.idBitacoraCategoria = CType(cmbConcepto.SelectedValue, Integer)

                        If proveedor = True Then
                            bitacora.proveedor = CType(cmbCliente.SelectedValue, Integer)
                            bitacora.bitCliente = False
                            bitacora.bitProveedor = True
                        Else
                            bitacora.cliente = CType(cmbCliente.SelectedValue, Integer)
                            bitacora.bitCliente = True
                            bitacora.bitProveedor = False
                        End If

                        bitacora.observacion = txtObservacion.Text

                        If chkResponsables.Checked = True Then
                            bitacora.recordatorio = chkResponsables.Checked
                            bitacora.programacion = dtpFechaRecordatorio.Value.Date
                            bitacora.cerrado = chkSolucionado.Checked
                        End If

                        If modifica = False Then
                            ctx.AddTotblBitacoras(bitacora)
                            ctx.SaveChanges()
                        End If

                        ctx.SaveChanges()
                        'Guardamos los responsables de la bitacora si se activo recordatorio
                        Dim codigoBitacora = bitacora.IdBitacora
                        If modifica = False Then
                            If chkResponsables.Checked = True Then
                                Dim index
                                For index = 0 To Me.lstResponsables.Items.Count - 1

                                    'obtener el estado.
                                    Dim chkstate As CheckState
                                    chkstate = lstResponsables.GetItemCheckState(index)
                                    Dim vendedor As String = lstResponsables.Items(index).ToString

                                    If chkstate = CheckState.Checked Then
                                        Dim idVendedor As tblVendedor = (From x In ctx.tblVendedors Where x.nombre = vendedor Select x).FirstOrDefault

                                        Dim bitacoraResponsables As New tblBitacoraResponsable
                                        bitacoraResponsables.idbitacora = codigoBitacora
                                        bitacoraResponsables.idvendedor = idVendedor.idVendedor
                                        ctx.AddTotblBitacoraResponsables(bitacoraResponsables)
                                        ctx.SaveChanges()
                                    End If
                                Next
                            End If

                        End If

                        If chkResponsables.Checked = True And modifica = False Then
                            'Guardamos las soluciones
                            Dim index As Integer
                            For index = 0 To Me.grdSoluciones.Rows.Count - 1
                                Dim usuario As Integer = CType(Me.grdSoluciones.Rows(index).Cells(0).Value, Integer)
                                Dim solucion = Me.grdSoluciones.Rows(index).Cells(2).Value

                                Dim nuevaSolucion As New tblBitacoraSolucione
                                nuevaSolucion.solucion = solucion
                                nuevaSolucion.usuario = usuario
                                nuevaSolucion.bitacora = codigoBitacora
                                ctx.AddTotblBitacoraSoluciones(nuevaSolucion)
                                ctx.SaveChanges()
                            Next
                        End If

                        'Agregamos las soluciones cuando se modifica
                        If modifica = True Then
                            Dim index As Integer
                            For index = 0 To Me.grdSoluciones.Rows.Count - 1
                                Dim idSolucion = CType(Me.grdSoluciones.Rows(index).Cells(3).Value, Integer)

                                If idSolucion = 0 Then
                                    Dim usuario As Integer = CType(Me.grdSoluciones.Rows(index).Cells(0).Value, Integer)
                                    Dim solucion = Me.grdSoluciones.Rows(index).Cells(2).Value
                                    Dim nuevaSolucion As New tblBitacoraSolucione
                                    nuevaSolucion.solucion = solucion
                                    nuevaSolucion.usuario = usuario
                                    nuevaSolucion.bitacora = codigoBitacora
                                    ctx.AddTotblBitacoraSoluciones(nuevaSolucion)
                                    ctx.SaveChanges()
                                End If

                            Next
                        End If

                    Else
                        success = False
                        alerta.contenido = "Bitacora no contiene, observacion; Ingrese observacion"
                        alerta.fnErrorContenido()
                    End If

                    'paso 8, completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                alerta.fnGuardar()
                Me.Close()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub llenarCombos()
        If proveedor = True Then
            Dim prov = (From x In ctx.tblProveedors Select Codigo = x.idProveedor, Nombre = x.negocio)
            With Me.cmbCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = prov
            End With

            Dim concepto = (From x In ctx.tblBitacoraCategorias Where x.proveedor = True Select Codigo = x.IdBitacoraCategoria, Nombre = x.Nombre)

            With Me.cmbConcepto
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = concepto
            End With

            lblCliente.Visible = False
            lblProveedor.Visible = True
        Else
            Dim clientes = (From x In ctx.tblClientes Select Codigo = x.idCliente, Nombre = x.Negocio)
            With Me.cmbCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = clientes
            End With

            Dim concepto = (From x In ctx.tblBitacoraCategorias Where x.cliente = True Select Codigo = x.IdBitacoraCategoria, Nombre = x.Nombre)

            With Me.cmbConcepto
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = concepto
            End With

            lblCliente.Visible = True
            lblProveedor.Visible = False
        End If


        
        If idCliente > 0 Then
            Me.cmbCliente.SelectedValue = idCliente
        End If

        If modifica = True Or ver = True Then
            'Llena la lista de responsables
            Dim modeloVehiculo = (From x In ctx.tblBitacoraResponsables Where x.idbitacora = superSearchId Select Codigo = x.idvendedor, Nombre = x.tblVendedor.nombre)
            Dim modelo
            For Each modelo In modeloVehiculo
                lstResponsables.Items.Add(modelo.nombre, False)
            Next
        Else
            'Llena la lista de responsables
            Dim modeloVehiculo = From x In ctx.tblVendedors Select Codigo = x.idVendedor, Nombre = x.nombre
            lstResponsables.Items.Clear()
            Dim modelo
            For Each modelo In modeloVehiculo
                lstResponsables.Items.Add(modelo.nombre, False)
            Next
        End If


    End Sub

    Private Sub chkResponsables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResponsables.CheckedChanged
        fnActivaRecordatorio()
    End Sub

    Private Sub fnActivaRecordatorio()
        If chkResponsables.Checked = True Then
            Me.dtpFechaRecordatorio.Enabled = True
            Me.txtSolucion.Enabled = True
            Me.btnAgregarSolucion.Enabled = True
            Me.grdSoluciones.Enabled = True
            Me.chkSolucionado.Enabled = True
            Me.lstResponsables.Enabled = True
        Else
            Me.dtpFechaRecordatorio.Enabled = False
            Me.txtSolucion.Enabled = False
            Me.lstResponsables.Enabled = False
            Me.btnAgregarSolucion.Enabled = False
            Me.grdSoluciones.Enabled = False
            Me.chkSolucionado.Enabled = False
        End If
    End Sub

    Private Sub limpiaCampos()
        txtObservacion.Text = ""
        txtSolucion.Text = ""
    End Sub

    Private Sub fnLlenarBitacora()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim bitacora As tblBitacora = (From x In conexion.tblBitacoras Where x.IdBitacora = superSearchId Select x).FirstOrDefault
            If bitacora.proveedor > 0 Then
                cmbCliente.SelectedValue = bitacora.proveedor
            Else
                cmbCliente.SelectedValue = bitacora.cliente
            End If
            cmbConcepto.SelectedValue = bitacora.idBitacoraCategoria
            txtObservacion.Text = bitacora.observacion
            cmbCliente.Enabled = False
            If bitacora.recordatorio = True Then
                chkResponsables.Checked = bitacora.recordatorio
                dtpFechaRecordatorio.Text = bitacora.programacion

                'Llena la lista de responsables
                Dim vendedor As String = ""
                Dim index
                Dim contador As Integer = 0

                'Llenamos la lista de responsables
                For index = 0 To Me.lstResponsables.Items.Count - 1
                    contador = 0
                    vendedor = lstResponsables.Items(index).ToString

                    Dim consulta = (From x In conexion.tblBitacoraResponsables Where x.idbitacora = superSearchId And x.tblVendedor.nombre = vendedor Select x).FirstOrDefault

                    Dim chkstate As CheckState

                    If consulta Is Nothing Then
                        chkstate = CheckState.Unchecked

                    Else
                        chkstate = CheckState.Checked

                    End If

                    lstResponsables.SetItemCheckState(index, chkstate)
                Next

                Me.grdSoluciones.Rows.Clear()

                'Llenamos el grid de soluciones
                Dim soluciones As List(Of tblBitacoraSolucione) = (From x In conexion.tblBitacoraSoluciones Where x.bitacora = superSearchId Select x).ToList
                Dim solucion As New tblBitacoraSolucione

                For Each solucion In soluciones
                    Dim fila As String()
                    fila = {solucion.usuario, solucion.tblUsuario.nombre, solucion.solucion, solucion.codigo}
                    grdSoluciones.Rows.Add(fila)
                Next

                'Establecemos si ha sido cerrado o solucionada.
                chkSolucionado.Checked = bitacora.cerrado
                'Si ha sido solucionado se bloquean los controles
                If bitacora.cerrado = True Then
                    fnBloquear()
                End If
            End If
            lstResponsables.Enabled = False
            conn.Close()
        End Using
    End Sub

    Private Sub btnAgregarSolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSolucion.Click
        If txtSolucion.Text <> "" Then
            Dim fila As String()
            Dim usuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x.nombre).FirstOrDefault

            fila = {mdlPublicVars.idUsuario, usuario, txtSolucion.Text}
            Me.grdSoluciones.Rows.Add(fila)

            txtSolucion.Text = ""
            txtSolucion.Focus()
        Else
            alerta.contenido = "Ingrese una solucion"
            alerta.fnErrorContenido()
        End If
    End Sub

    Private Sub fnBloquear()
        Me.cmbCliente.Enabled = False
        Me.cmbConcepto.Enabled = False
        Me.chkResponsables.Enabled = False
        Me.chkSolucionado.Enabled = False
        Me.dtpFechaRecordatorio.Enabled = False
        Me.txtObservacion.Enabled = False
        Me.txtSolucion.Enabled = False
        Me.btnAgregarSolucion.Enabled = False
    End Sub

    'Funcion utilizada para mostrar el historial de bitacoras
    Private Sub fnHistorial()
        Try
            Dim bitacoraInfo = Nothing
            If proveedor = True Then
                bitacoraInfo = (From x In ctx.tblBitacoras _
                                Where x.IdEmpresa = mdlPublicVars.idEmpresa And x.bitProveedor = True And x.bitCliente = False _
                                And x.proveedor = idCliente _
                                Select Codigo = x.IdBitacora, Fecha = x.FechaRegistro, Concepto = x.tblBitacoraCategoria.Nombre, _
                                Observacion = x.observacion, Recordatorio = x.recordatorio, FechaRecordatorio = x.programacion, Cerrado = x.cerrado)
            Else
                'Clientes
                bitacoraInfo = (From x In ctx.tblBitacoras _
                                Where x.IdEmpresa = mdlPublicVars.idEmpresa And x.bitProveedor = False And x.bitCliente = True _
                                And x.cliente = idCliente
                                Select Codigo = x.IdBitacora, Fecha = x.FechaRegistro, Concepto = x.tblBitacoraCategoria.Nombre, _
                                Observacion = x.observacion, Recordatorio = x.recordatorio, FechaRecordatorio = x.programacion, Cerrado = x.cerrado)
            End If

            Me.grdDatos.DataSource = bitacoraInfo
            fnConfiguracion()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaRecordatorio")
                Me.grdDatos.Columns("Codigo").IsVisible = False

                Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Concepto").TextAlignment = ContentAlignment.MiddleLeft
                Me.grdDatos.Columns("Observacion").TextAlignment = ContentAlignment.MiddleLeft
                Me.grdDatos.Columns("Recordatorio").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("FechaRecordatorio").TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 65
                Me.grdDatos.Columns("Concepto").Width = 100
                Me.grdDatos.Columns("Observacion").Width = 150
                Me.grdDatos.Columns("Recordatorio").Width = 70
                Me.grdDatos.Columns("FechaRecordatorio").Width = 90
                Me.grdDatos.Columns("Cerrardo").Width = 80

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        If Me.grdDatos.CurrentRow.Index >= 0 Then
            'Obtenemos el codigo de la bitacora
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
            Dim bitacora As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

            frmBitacoraConcepto.StartPosition = FormStartPosition.CenterScreen
            frmBitacoraConcepto.Text = "Bitacora"
            frmBitacoraConcepto.superSearchId = bitacora
            frmBitacoraConcepto.ver = True
            permiso.PermisoFrmEspeciales(frmBitacoraConcepto, False)
        End If
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged

        If Me.cmbCliente.SelectedValue > 0 And terminado = True Then
            idCliente = Me.cmbCliente.SelectedValue
            fnHistorial()
        End If

    End Sub

    Private Sub fnLlenaModificar(ByVal codigo As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim bitacora As tblBitacora = (From x In conexion.tblBitacoras Where x.IdBitacora = codigo Select x).FirstOrDefault

                Me.cmbCliente.SelectedValue = bitacora.cliente
                Me.cmbConcepto.SelectedValue = bitacora.idBitacoraCategoria

                Me.txtObservacion.Text = bitacora.observacion
                Me.chkSolucionado.Checked = bitacora.cerrado

                Dim list As List(Of tblBitacoraSolucione) = (From x In conexion.tblBitacoraSoluciones Where x.bitacora = codigo Select x).ToList

                For Each solbitacora As tblBitacoraSolucione In list
                    Dim fila As Object()

                    fila = {solbitacora.tblUsuario.idUsuario, solbitacora.tblUsuario.nombre, solbitacora.solucion, solbitacora.codigo}

                    Me.grdSoluciones.Rows.Add(fila)
                Next

                Me.dtpFechaRecordatorio.Value = bitacora.programacion
                Me.chkResponsables.Checked = bitacora.recordatorio

                Dim vendedor As String = ""
                Dim index
                Dim contador As Integer = 0

                'Llenamos la lista de responsables
                For index = 0 To Me.lstResponsables.Items.Count - 1
                    contador = 0
                    vendedor = lstResponsables.Items(index).ToString

                    Dim consulta = (From x In conexion.tblBitacoraResponsables Where x.idbitacora = codigo And x.tblVendedor.nombre = vendedor Select x).FirstOrDefault

                    Dim chkstate As CheckState

                    If consulta Is Nothing Then
                        chkstate = CheckState.Unchecked

                    Else
                        chkstate = CheckState.Checked

                    End If

                    lstResponsables.SetItemCheckState(index, chkstate)
                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try

        pgCrear.Select()
        pgCrear.Show()
    End Sub

    Private Sub grdDatos_Click(sender As Object, e As EventArgs) Handles grdDatos.Click
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

        If fila >= 0 Then
            Dim columna As Integer = Me.grdDatos.CurrentColumn.Index

            If columna >= 0 Then
                If grdDatos.Columns(columna).Name = "Cerrado" Then

                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        If RadMessageBox.Show("¿Desea Confirmar la Solucion de la Bitacora?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            codigomodificar = Me.grdDatos.Rows(fila).Cells("Codigo").Value
                            Dim fecha As DateTime = fnFecha_horaServidor()

                            Dim bitacora As tblBitacora = (From x In conexion.tblBitacoras Where x.IdBitacora = codigomodificar Select x).FirstOrDefault

                            bitacora.cerrado = True
                            bitacora.fechaCerrado = fecha

                            conexion.SaveChanges()

                        End If

                        conn.Close()
                    End Using
                    fnHistorial()
                End If
            End If
        End If
    End Sub

    Private Sub grdDatos_CommandCellClick(sender As Object, e As EventArgs) Handles grdDatos.CommandCellClick
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

        If fila >= 0 Then
            Dim columna As Integer = Me.grdDatos.CurrentColumn.Index

            If columna >= 0 Then
                If grdDatos.Columns(columna).Name = "Editar" Then

                    codigomodificar = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                    fnLlenaModificar(codigomodificar)

                End If
            End If
        End If

        modificar = True
    End Sub

    Private Sub fnModificar()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim bitacora As tblBitacora = (From x In conexion.tblBitacoras Where x.IdBitacora = codigomodificar Select x).FirstOrDefault

                bitacora.programacion = Me.dtpFechaRecordatorio.Value
                bitacora.idBitacoraCategoria = Me.cmbConcepto.SelectedValue

                conexion.SaveChanges()

                For index As Integer = 0 To Me.grdSoluciones.Rows.Count - 1

                    Dim existe As Integer
                    Try
                        existe = Me.grdSoluciones.Rows(index).Cells("idSolucion").Value
                    Catch ex As Exception
                        existe = 0
                    End Try

                    If existe = 0 Then
                        Dim nuevo As New tblBitacoraSolucione

                        nuevo.bitacora = codigomodificar
                        nuevo.usuario = CInt(Me.grdSoluciones.Rows(index).Cells("idvendedor").Value)
                        nuevo.solucion = CStr(Me.grdSoluciones.Rows(index).Cells("Solucion").Value)

                        conexion.AddTotblBitacoraSoluciones(nuevo)
                        conexion.SaveChanges()
                    End If

                Next

                conn.Close()
            End Using

            alerta.fnModificar()
        Catch ex As Exception

        End Try
    End Sub
End Class
