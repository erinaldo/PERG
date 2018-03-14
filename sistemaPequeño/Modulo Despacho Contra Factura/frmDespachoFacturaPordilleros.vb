﻿Option Strict On

Imports System.Data
Imports System.Data.EntityClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.Linq
Imports System.Transactions

Public Class frmDespachoFacturaPordilleros


#Region "Variables"
    Private _listaEmpleados As List(Of Tuple(Of Integer, String))
#End Region

#Region "Propiedades"
    Public Property listaEmpleados As List(Of Tuple(Of Integer, String))
        Get
            listaEmpleados = _listaEmpleados
        End Get
        Set(value As List(Of Tuple(Of Integer, String)))
            _listaEmpleados = value
        End Set
    End Property
#End Region

#Region "Eventos"
    'LOAD
    Private Sub frmDespachoFacturaPordilleros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdEmpleados)
        mdlPublicVars.fnGrid_iconos(grdEmpleados)

        fnLlenarGrid()
    End Sub

    'CLIC EN ACEPTAR PARA AGREGAR EMPLEADOS
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        listaEmpleados = New List(Of Tuple(Of Integer, String))
        'Obtener los empleados elegidos
        Dim empleados As List(Of GridViewRowInfo) = (From x In grdEmpleados.Rows Where CBool(x.Cells("chmElegir").Value) Select x).ToList

        For Each empleado As GridViewRowInfo In empleados
            listaEmpleados.Add(New Tuple(Of Integer, String)(CInt(empleado.Cells("idEmpleado").Value), CStr2(empleado.Cells("Nombre").Value)))
        Next
        mdlPublicVars.superSearchLista2 = listaEmpleados
        Me.Close()
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

#End Region

#Region "Funciones"
    'LLENAR EL GRID CON LOS EMPLEADOS
    Private Sub fnLlenarGrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim elegir As Boolean = False
                Dim empleados As List(Of tblEmpleado) = (From x In conexion.tblEmpleadoes.AsEnumerable Where x.bitpordillero = True Select x Order By x.nombre Ascending).ToList()

                For Each empleado As tblEmpleado In empleados
                    elegir = If((From x In listaEmpleados Where x.Item1 = empleado.idEmpleado Select x).Count() > 0, True, False)
                    Me.grdEmpleados.Rows.Add({elegir, empleado.idEmpleado, empleado.nombre, empleado.tblpuesto.nombre})
                Next
                conn.Close()
            End Using
        Catch

        End Try
    End Sub

#End Region

End Class