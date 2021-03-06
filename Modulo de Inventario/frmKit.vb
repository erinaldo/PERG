﻿''Option Strict On

Imports System.Linq
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Data.EntityClient


Public Class frmKit

#Region "Variables"
    Public grdBase As Telerik.WinControls.UI.RadGridView
    Public base2 As Integer = 0
    Public filtro As String = ""
#End Region

#Region "Load"
    Private Sub frmKit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        txtFiltro.Text = filtro
        fnLlenarGrid()
        mdlPublicVars.fnGrid_iconos(grdDatos)
        txtFiltro.Focus()
    End Sub
#End Region


    Private Sub fnLlenarGrid()
        Dim filtro As String = txtFiltro.Text

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_Lista_ArticulosKit(mdlPublicVars.idEmpresa, base2, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, mdlPublicVars.UnidadMedidaDefault) Select x)

            Me.grdDatos.DataSource = datos
            fnBuscarKits()
            fnConfiguracion()

            conn.Close()
        End Using

    End Sub

    Private Sub fnBuscarKits()
        Dim index As Integer
        Dim idSustito As Integer
        Dim detalle As Integer
        Dim idbase As Integer
        For index = 0 To Me.grdDatos.Rows.Count - 18
            Dim contador As Integer
            For contador = 0 To grdBase.Rows.Count - 1
                ''base = Me.grdBase.Rows(contador).Cells("id").Value
                idSustito = Me.grdDatos.Rows(index).Cells("ID").Value
                detalle = Me.grdBase.Rows(contador).Cells("iddetalle").Value
                If idbase = idSustito Then
                    Me.grdDatos.Rows(index).Cells("chmAgregar").Value = True
                    Me.grdDatos.Rows(index).Cells("iddetalle").Value = detalle
                End If
            Next
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fnLlenarBase()
        Me.Close()
    End Sub

    Private Sub fnConfiguracion()
        Try
            Me.grdDatos.Columns("ID").IsVisible = False
            Me.grdDatos.Columns("detalle").IsVisible = False
            Me.grdDatos.Columns("codArticuloUnidadMedida").IsVisible = False

            ''ancho de las columnas
            Me.grdDatos.Columns("chmAgregar").Width = 80
            Me.grdDatos.Columns("Codigo").Width = 120
            Me.grdDatos.Columns("Nombre").Width = 275
            Me.grdDatos.Columns("txmCantidad").Width = 150
            Me.grdDatos.Columns("bitUnidadMedida").Width = 100
            Me.grdDatos.Columns("txbUnidadMedida").Width = 120
            Me.grdDatos.Columns("Unidades").Width = 100
            Me.grdDatos.Columns("Costo").Width = 80

            ''edicion de columnas
            Me.grdDatos.Columns("bitUnidadMedida").ReadOnly = True
            Me.grdDatos.Columns("txbUnidadMedida").ReadOnly = True
            Me.grdDatos.Columns("chmAgregar").ReadOnly = False
            Me.grdDatos.Columns("txmCantidad").ReadOnly = False
            Me.grdDatos.Columns("Unidades").ReadOnly = True
            Me.grdDatos.Columns("Costo").ReadOnly = True
            Me.grdDatos.Columns("Nombre").ReadOnly = True
            Me.grdDatos.Columns("Codigo").ReadOnly = True

            ''Me.grdDatos.Columns("ID").ReadOnly = True
            ''Me.grdDatos.Columns("detalle").IsVisible = False
            ''Me.grdDatos.Columns("codArticuloUniadaMedida").ReadOnly = True
            ''Me.grdDatos.Columns("chmAgregar").ReadOnly = False
            ''Me.grdDatos.Columns("txmCantidad").ReadOnly = False
            ''Me.grdDatos.Columns("Codigo").ReadOnly = True
            ''Me.grdDatos.Columns("Nombre").ReadOnly = True
            ''Me.grdDatos.Columns("bitUnidadMedida").ReadOnly = True
            ''Me.grdDatos.Columns("UnidadMedida").ReadOnly = True
            ''Me.grdDatos.Columns("Unidades").ReadOnly = True
            ''Me.grdDatos.Columns("Costo").ReadOnly = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnLlenarBase()
        Dim detalle As Integer = 0
        Dim cantidad As Double = 0
        Dim idArticulo As Integer = 0
        Dim codi As String = ""
        Dim nombre As String = ""
        Dim marcas As String = ""
        Dim agregar As Boolean = False
        Dim costo As Double = 0
        Dim codArticuloUnidadMedida As Integer = 0
        Dim unidadMedida As String = ""
        Dim unidades As Double = 0
        Dim valore As Double = 1

        grdBase.Rows.Clear()
        For index As Integer = 0 To Me.grdDatos.Rows.Count - 1
            detalle = If(IsDBNull(grdDatos.Rows(index).Cells("detalle").Value), 0, grdDatos.Rows(index).Cells("detalle").Value)
            cantidad = CDbl(grdDatos.Rows(index).Cells("txmCantidad").Value)
            idArticulo = Me.grdDatos.Rows(index).Cells("id").Value
            agregar = Me.grdDatos.Rows(index).Cells("chmAgregar").Value

            If Me.grdDatos.Rows(index).Cells("codArticuloUnidadMedida").Value.ToString.Length = 0 Then
                codArticuloUnidadMedida = 0
            Else
                codArticuloUnidadMedida = Me.grdDatos.Rows(index).Cells("codArticuloUnidadMedida").Value
            End If

            unidadMedida = Me.grdDatos.Rows(index).Cells("txbUnidadMedida").Value.ToString

            If Me.grdDatos.Rows(index).Cells("Unidades").Value.ToString.Length = 0 Then
                unidades = 1
            Else
                unidades = Me.grdDatos.Rows(index).Cells("Unidades").Value.ToString
            End If

            If agregar Or detalle > 0 Then

                codi = (From y In ctx.tblArticuloes Where y.idArticulo = idArticulo Select y.codigo1).FirstOrDefault
                nombre = (From y In ctx.tblArticuloes Where y.idArticulo = idArticulo Select y.nombre1).FirstOrDefault
                costo = (From y In ctx.tblArticuloes Where y.idArticulo = idArticulo Select y.costoIVA).FirstOrDefault
            End If

            If codArticuloUnidadMedida > 0 Then
                valore = (From y In ctx.tblArticulo_UnidadMedida Where y.idArticulo_UnidadMedida = codArticuloUnidadMedida Select y.valor).FirstOrDefault
            Else
                valore = 1
            End If

            If valore > 0 Then
                costo = valore * costo
            End If

            If agregar And cantidad > 0 Then

                Dim fila As String()
                Dim art As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = idArticulo).FirstOrDefault

                fila = {detalle, art.idArticulo, art.codigo1, art.nombre1, 0, "", cantidad, costo, codArticuloUnidadMedida, unidadMedida, unidades}

                ''fila = {0, 1, "DJE34D", "PIDEVIAS TRASERO AMBAR", 0, 1.0, 11.75, 0, "Unidad", 1.0}

                Me.grdBase.Rows.Add(fila)
            ElseIf detalle > 0 Then
                Dim fila As String()
                Dim art As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = idArticulo).FirstOrDefault
                fila = {detalle, art.idArticulo, art.codigo1, art.nombre1, 1, cantidad, costo, codArticuloUnidadMedida, unidadMedida, unidades}
                Me.grdBase.Rows.Add(fila)
                Me.grdDatos.Rows(Me.grdBase.RowCount - 1).IsVisible = False
            End If
        Next
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            fnLlenarGrid()
            fnConfiguracion()
        End If
    End Sub

    Private Sub grdDatos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDatos.ValueChanged
        mdlPublicVars.fngrd_contador(grdDatos, lblContador, txtFiltro, 0)
    End Sub

    Private Sub grdDatos_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyUp
        If e.KeyCode = Keys.F2 Then

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim bitUnidadMedida As Boolean = Me.grdDatos.Rows(fila).Cells("bitUnidadMedida").Value

            If bitUnidadMedida = True Then
                FrmGrid.bitkit = True

                mdlPublicVars.superSearchId = 0
                FrmGrid.filtro1 = Me.grdDatos.Rows(fila).Cells(2).Value
                FrmGrid.filtro2 = 1
                FrmGrid.ShowDialog()
                FrmGrid.Dispose()

                If mdlPublicVars.superSearchId > 0 Then
                    Me.grdDatos.Rows(fila).Cells("codArticuloUnidadMedida").Value = mdlPublicVars.superSearchId
                    Me.grdDatos.Rows(fila).Cells("txbUnidadMedida").Value = mdlPublicVars.superSearchNombre
                    Me.grdDatos.Rows(fila).Cells("Costo").Value = mdlPublicVars.superSearchCosto
                    Me.grdDatos.Rows(fila).Cells("Unidades").Value = mdlPublicVars.superSearchUnidadMedidaValor
                End If
            Else
                alerta.contenido = "Producto no es un kit"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    Private Sub fnsalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class