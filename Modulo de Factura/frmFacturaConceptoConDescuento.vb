﻿Imports System.Linq
Imports Telerik.WinControls.UI


Public Class frmFacturaConceptoConDescuento


    Dim descuento As Double
    Private _codigo As Integer


    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property



    Private Sub frmFacturaConceptoConDescuento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        mdlPublicVars.fnFormatoGridEspeciales(grdProductos)

       

        fnLlenarDatos()
        fnConfiguracion()
    End Sub

        Private Sub fnConfiguracion()

        'Formato para las columnas.
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Precio")

        'Activar barra de totales y crear operaciones.
        grdProductos.MasterTemplate.ShowTotals = True
        Dim STotal As New GridViewSummaryItem("Total", mdlPublicVars.SimboloSuma + "={0}", GridAggregateFunction.Sum)
        Dim SCodigo As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)

        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {SCodigo, STotal})

        'agregar summario arreglo a grid
        grdProductos.SummaryRowsTop.Add(summaryRowItem)


    End Sub

    'Funcion que se utliza para llenar los datos de unqa salida cuando se esta en modificar
    Private Sub fnLlenarDatos()
        


        Try


            'Obtenemos los datos de la factura
            Dim factura As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault
            lblFechaRegistro.Text = Format(factura.Fecha, mdlPublicVars.formatoFecha)


            If factura.descuento Is Nothing Then
                descuento = 0
            Else
                descuento = factura.descuento
            End If

            lblFactura.Text = factura.DocumentoFactura




            If factura.idResolucion Is Nothing Then
                lblSerieFactura.Text = ""
            Else
                lblSerieFactura.Text = factura.tblResolucionFactura.serie
            End If

            If factura.idResolucion Is Nothing Then
                lblResolucion.Text = ""
            Else
                lblResolucion.Text = factura.tblResolucionFactura.resolucion
            End If

            'lblSerieFactura.Text = factura.tblResolucionFactura.serie
            'lblResolucion.Text = factura.tblResolucionFactura.resolucion
            lblDescuento.Text = factura.descuento & " % "


            'Obtenemos los pedidos de la factura
            Dim lPedidos As List(Of tblSalida) = (From x In ctx.tblSalidas Where x.IdFactura = codigo _
                                                  And x.anulado = False Select x).ToList

            Dim pedido As tblSalida

            Dim dirEnvios As String = ""
            Dim vendedores As String = ""
            Dim documentos As String = ""
            Dim totalGeneral As Double = 0


            Dim lDetalle = (From x In ctx.tblSalidaDetalles Where x.tblSalida.IdFactura = factura.IdFactura _
                                                            Select Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1,
                                                            Cantidad = x.cantidad, Precio = Math.Round((x.precio) - ((x.precio) * descuento / 100), 2),
                                                            TipoPrecio = x.tblArticuloTipoPrecio.nombre,
                                                            Total = Math.Round((Math.Round((CDec(x.precio)) - ((CDec(x.precio)) * CDec(descuento) / 100), 2) * CDbl(x.cantidad)), 2)).ToList

            Dim lTotal As Double = (From x In ctx.tblSalidaDetalles Where x.tblSalida.IdFactura = factura.IdFactura _
                                                            Select Math.Round((Math.Round((CDec(x.precio)) - ((CDec(x.precio)) * CDec(descuento) / 100), 2) * CDbl(x.cantidad)), 2)).Sum


            grdProductos.DataSource = lDetalle

            'asignar el total
            lblTotal.Text = Format(lTotal, mdlPublicVars.formatoMoneda)


            For Each pedido In lPedidos
                lblNombreFacturacion.Text = pedido.cliente
                vendedores += pedido.tblVendedor.nombre & ", "
                dirEnvios += pedido.direccionEnvio & ","
                lblCliente.Text = pedido.tblCliente.Negocio
                lblNit.Text = pedido.nit
                lblDireccionFacturacion.Text = pedido.direccionFacturacion
                documentos += pedido.documento & ", "


            Next

            'Asignar valores del encabezado.

            lblDireccionEnvio.Text = dirEnvios
            lblVendedor.Text = vendedores

        Catch ex As Exception
        End Try
    End Sub



    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub



    Private Sub fnDocSalida() Handles Me.panel1
        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario

        Try

            Try
                Dim salida As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigo).FirstOrDefault
                frmDocumentosSalida.tabla = EntitiToDataTable(ctx.sp_ReporteFactura1("", codigo, mdlPublicVars.idEmpresa))
                frmDocumentosSalida.reporteBase = Nothing
                frmDocumentosSalida.bitGenerico = False
                frmDocumentosSalida.bitImg = False
                frmDocumentosSalida.bitListaCombo = True
                frmDocumentosSalida.ListaCombo = "factura"
                frmDocumentosSalida.codigo = codigo
                frmDocumentosSalida.txtTitulo.Text = "Factura : " & salida.DocumentoFactura
                frmDocumentosSalida.Text = "Doc de Salida, Ventas"
                frmDocumentosSalida.bitCliente = True
                permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try

    End Sub


End Class
