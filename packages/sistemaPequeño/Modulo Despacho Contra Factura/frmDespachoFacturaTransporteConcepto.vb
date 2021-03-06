﻿Option Strict On

Imports System.Data
Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.ComponentModel

Public Class frmDespachoFacturaTransporteConcepto

#Region "Variables"
    Private _idSalidaTransporteMedio As Integer
#End Region

#Region "Propiedades"
    Public Property idSalidaTransporteMedio As Integer
        Get
            idSalidaTransporteMedio = _idSalidaTransporteMedio
        End Get
        Set(value As Integer)
            _idSalidaTransporteMedio = value
        End Set
    End Property
#End Region

#Region "Eventos"
    'INICIO DEL FORMULARIO
    Private Sub frmDespachoFacturaTransporteConcepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdClientesProductos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPordilleros)
        Me.grdClientesProductos.EnableGrouping = True
        fnLlenarDatos()
    End Sub

    'FUNCION PARA LLENAR DATOS
    Private Sub fnLlenarDatos()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim salidaTransporteMedio As tblSalidasTransportesMedio = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = idSalidaTransporteMedio
                Select x).FirstOrDefault

            If salidaTransporteMedio IsNot Nothing Then
                'LLENAR DATOS
                lblCorrelativo.Text = CStr2(salidaTransporteMedio.correlativo)
                lblEstado.Text = If(CInt(salidaTransporteMedio.salida) = 0, "No enviado", "Enviado")
                lblFechaTransporte.Text = Format(mdlPublicVars.formatoFecha, CStr2(salidaTransporteMedio.fechaTransporte))
                lblObservacion.Text = salidaTransporteMedio.observacion
                lblPiloto.Text = salidaTransporteMedio.tblEmpleado.nombre
                lblPlacas.Text = salidaTransporteMedio.tblTransporte.placas
                lblPrecio.Text = Format(mdlPublicVars.formatoMoneda, CStr2(salidaTransporteMedio.costo))
                lblSucursalSalida.Text = CStr2(salidaTransporteMedio.tblSucursale.descripcion)
                lblTipoTransporte.Text = salidaTransporteMedio.tblTransporte.tblTiposTransporte.descripcion
                lblTransporte.Text = salidaTransporteMedio.tblTransporte.descripcion

                ' PORDILLEROS
                Me.grdPordilleros.DataSource = EntitiToDataTable(salidaTransporteMedio.tblSalidasTransportesMediosEmpleados.Select(Function(x) New With {.Nombre = x.tblEmpleado.nombre, .Puesto = x.tblEmpleado.tblpuesto.nombre}))
                ' Configurar el grid de pordilleros
                If Me.grdPordilleros.ColumnCount > 0 Then
                    Me.grdPordilleros.Columns("Nombre").Width = 60
                    Me.grdPordilleros.Columns("Puesto").Width = 40
                End If

                ' CLIENTES Y GRUPOS
                Me.grdClientesProductos.DataSource = EntitiToDataTable(From x In conexion.sp_reporteNTransporteMedioConcepto(idSalidaTransporteMedio, mdlPublicVars.idEmpresa) Select x)
                'Configurar el grid de clientes y productos
                If Me.grdClientesProductos.ColumnCount > 0 Then
                    Me.grdClientesProductos.Columns("idCliente").IsVisible = False

                    Me.grdClientesProductos.Columns("Empresa").IsVisible = False
                    Me.grdClientesProductos.Columns("EDireccion").IsVisible = False
                    Me.grdClientesProductos.Columns("ETelefono").IsVisible = False
                    Me.grdClientesProductos.Columns("ENit").IsVisible = False
                    Me.grdClientesProductos.Columns("ECorreo").IsVisible = False
                    Me.grdClientesProductos.Columns("Piloto").IsVisible = False
                    Me.grdClientesProductos.Columns("TipoTransporte").IsVisible = False
                    Me.grdClientesProductos.Columns("Transporte").IsVisible = False
                    Me.grdClientesProductos.Columns("Placas").IsVisible = False
                    Me.grdClientesProductos.Columns("Observacion").IsVisible = False
                    Me.grdClientesProductos.Columns("FechaTransporte").IsVisible = False
                    Me.grdClientesProductos.Columns("SucursalSalida").IsVisible = False
                    Me.grdClientesProductos.Columns("Correlativo").IsVisible = False
                    Me.grdClientesProductos.Columns("Estado").IsVisible = False
                    Me.grdClientesProductos.Columns("Costo").IsVisible = False

                    Me.grdClientesProductos.Columns("Documento").Width = 10
                    Me.grdClientesProductos.Columns("Cliente").Width = 15
                    Me.grdClientesProductos.Columns("Contacto").Width = 15
                    Me.grdClientesProductos.Columns("Direccion").Width = 20
                    Me.grdClientesProductos.Columns("Codigo").Width = 12
                    Me.grdClientesProductos.Columns("Producto").Width = 18
                    Me.grdClientesProductos.Columns("Cantidad").Width = 10
                End If

                'AGRUPAR LOS DATOS
                Dim descriptor As New GroupDescriptor()
                descriptor.GroupNames.Add("Cliente", ListSortDirection.Ascending)
                descriptor.GroupNames.Add("Direccion", ListSortDirection.Ascending)

                Me.grdClientesProductos.GroupDescriptors.Add(descriptor)
            End If
            conn.Close()
        End Using
    End Sub

    'REPORTE
    Private Sub fnReporte_Salir() Handles Me.panel0

        Dim r As New clsReporte

        Try
            r.reporte = "rptTransporte.rpt"
            r.tabla = EntitiToDataTable(From x In ctx.sp_reporteNTransporteMedioConcepto(idSalidaTransporteMedio, mdlPublicVars.idEmpresa))

            r.verReporte()
        Catch ex As Exception
            RadMessageBox.Show("No se puede generar el reporte, ha ocurrido un error", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnSalir_Click() Handles Me.panel1
        Me.Close()
    End Sub
#End Region

#Region "Funciones"

#End Region

    Private Sub rgbClienteProductos_Click(sender As Object, e As EventArgs) Handles rgbClienteProductos.Click

    End Sub
End Class

