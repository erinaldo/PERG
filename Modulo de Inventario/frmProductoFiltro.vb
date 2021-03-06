﻿Imports System.Linq

Public Class frmProductoFiltro

    Private Sub frmProductoFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnNoModificarTam(Me)
        mdlPublicVars.fnFormatoGridMovimientos(grdImportancia)
        mdlPublicVars.fnFormatoGridMovimientos(grdInventario)
        mdlPublicVars.fnFormatoGridMovimientos(grdMarca)
        mdlPublicVars.fnFormatoGridMovimientos(grdModelo)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        fnLlenarGrid()
        chkTipoInventario.Checked = True
        chkTodosImportancia.Checked = True
        chkTodosMarca.Checked = True
        chkTodosModelo.Checked = True
        chkTodosTipoRepuesto.Checked = True
        chkTodosTipoVehiculo.Checked = True
        mdlPublicVars.fngrd_contador(grdImportancia, lblRecuentoImportancia, "chmAgregar")
        mdlPublicVars.fngrd_contador(grdInventario, lblRecuentoInventario, "chmAgregar")
        mdlPublicVars.fngrd_contador(grdMarca, lblRecuentoMarcaRepuesto, "chmAgregar")
        mdlPublicVars.fngrd_contador(grdModelo, lblRecuentoModelo, "chmAgregar")
        mdlPublicVars.fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto, "chmAgregar")
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo, "chmAgregar")
    End Sub

    'Funcion utilizada para llenar los grid
    Private Sub fnLlenarGrid()
        'INVENTARIOS
        Dim tp = (From x In ctx.tblTipoInventarios Where x.empresa = mdlPublicVars.idEmpresa _
                  Select Agregar = True, Codigo = x.idTipoinventario, Nombre = x.nombre)

        Me.grdInventario.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdInventario.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'MODELOS
        Dim modelos = (From x In ctx.tblArticuloModeloVehiculoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModelo.Rows.Clear()
        For Each v In modelos
            Me.grdModelo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'TIPO VEHICULOS
        Dim tipoVehiculos = (From x In ctx.tblArticuloTipoVehiculoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.Rows.Clear()
        For Each v In tipoVehiculos
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'MARCA
        Dim marca = (From x In ctx.tblArticuloMarcaRepuestoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdMarca.Rows.Clear()
        For Each v In marca
            Me.grdMarca.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'IMPORTANCIA
        Dim importancia = (From x In ctx.tblArticuloImportancias _
                        Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdImportancia.Rows.Clear()
        For Each v In importancia
            Me.grdImportancia.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'TIPO REPUESTO
        Dim tipoRepuesto = (From x In ctx.tblArticuloRepuestoes _
                        Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoRepuesto.Rows.Clear()
        For Each v In tipoRepuesto
            Me.grdTipoRepuesto.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next
    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    'Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
    '    'Recorremos el grid
    '    For i As Integer = 0 To grd.Rows.Count - 1
    '        grd.Rows(i).Cells("chmAgregar").Value = estado
    '    Next
    'End Sub

    'Boton FILTRAR
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        fnFiltrar()
    End Sub

    'FILTRAR
    Public Sub fnFiltrar()

        Dim inventario As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdInventario, 1, 0)
        Dim modelo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelo, 1, 0)
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
        Dim marca As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
        Dim importancia As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdImportancia, 1, 0)
        Dim tipoRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoRepuesto, 1, 0)

        Try
            Dim datos = ctx.sp_Filtro_lista_articulos(mdlPublicVars.idEmpresa, mdlPublicVars.General_idAlmacenPrincipal, inventario, _
                                                      modelo, tipoVehiculo, marca, tipoRepuesto, importancia, If(chkBuscaCodigo.Checked, 1, 0), txtCodigo.Text, _
                                                       If(chkBuscarNombre.Checked, 1, 0), txtNombre.Text)

            frmProductoLista.esfiltro = True
            frmProductoLista.grdDatos.DataSource = datos
            frmProductoLista.filtroActivo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub

    Private Sub chkTipoInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoInventario.CheckedChanged

        mdlPublicVars.fnActivaTodos(chkTipoInventario.Checked, grdInventario, "chmAgregar")
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosModelo.Checked, grdModelo, "chmAgregar")
    End Sub

    Private Sub chkTodosTipoVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoVehiculo.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosTipoVehiculo.Checked, grdTipoVehiculo, "chmAgregar")
    End Sub

    Private Sub chkTodosMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosMarca.Checked, grdMarca, "chmAgregar")
    End Sub

    Private Sub chkTodosImportancia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosImportancia.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosImportancia.Checked, grdImportancia, "chmAgregar")
    End Sub

    Private Sub chkTodosTipoRepuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoRepuesto.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosTipoRepuesto.Checked, grdTipoRepuesto, "chmAgregar")
    End Sub

    Private Sub grdInventario_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdInventario.ValueChanged
        mdlPublicVars.fngrd_contador(grdInventario, lblRecuentoInventario, "chmAgregar")
    End Sub

    Private Sub grdModelo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdModelo.ValueChanged
        mdlPublicVars.fngrd_contador(grdModelo, lblRecuentoModelo, "chmAgregar")
    End Sub

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo, "chmAgregar")
    End Sub

    Private Sub grdMarca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarca.ValueChanged
        mdlPublicVars.fngrd_contador(grdMarca, lblRecuentoMarcaRepuesto, "chmAgregar")
    End Sub

    Private Sub grdImportancia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdImportancia.ValueChanged
        mdlPublicVars.fngrd_contador(grdImportancia, lblRecuentoImportancia, "chmAgregar")
    End Sub

    Private Sub grdTipoRepuesto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoRepuesto.ValueChanged
        mdlPublicVars.fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto, "chmAgregar")
    End Sub
End Class
