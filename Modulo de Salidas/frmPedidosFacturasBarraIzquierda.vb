﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmPedidosFacturasBarraIzquierda
    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario

    Private Sub frmPedidosFacturasBarraIzquierda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try

            ''Agregado para la venta Pequenia
            If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                frmVentaPequeniaLista.Text = "Modulo de Ventas"
                frmVentaPequeniaLista.MdiParent = frmMenuPrincipal


                If permiso.PermisoMantenimientoLista(frmVentaPequeniaLista, True) = True Then
                    fnFRMhijos_cerrar(frmVentaPequeniaLista)
                    Me.Hide()

                End If

            ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = False Then


                frmPedidosLista.Text = "Modulo de Pedidos"
                frmPedidosLista.MdiParent = frmMenuPrincipal

                If permiso.PermisoMantenimientoLista(frmPedidosLista, True) = True Then
                    fnFRMhijos_cerrar(frmPedidosLista)
                    Me.Hide()
                End If

            End If



        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        Try
            frmFacturasLista.Text = "Modulo de Facturas"
            frmFacturasLista.MdiParent = frmMenuPrincipal
            frmFacturasLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmFacturasLista, True) = True Then
                fnFRMhijos_cerrar(frmFacturasLista)
                Me.Hide()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        Try
            frmPedidosBodegaLista.Text = "Modulo de Bodega"
            frmPedidosBodegaLista.MdiParent = frmMenuPrincipal
            frmPedidosBodegaLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmPedidosBodegaLista, True) = True Then
                fnFRMhijos_cerrar(frmPedidosBodegaLista)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        Try
            frmPedidosPendienteSurtir.Text = "Pendientos por Surtir"
            frmPedidosPendienteSurtir.MdiParent = frmMenuPrincipal
            If permiso.PermisoMantenimientoLista(frmPedidosPendienteSurtir, False) = True Then
                fnFRMhijos_cerrar(frmPedidosPendienteSurtir)
                Me.Hide()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel5() Handles Me.panel5
        frmPagosLista.Dispose()
        frmPagosLista.Text = "Modulo de Pagos"
        frmPagosLista.bitVenta = True
        frmPagosLista.bitCompra = False
        frmPagosLista.bitProveedor = False
        frmPagosLista.bitCliente = False
        frmPagosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmPagosLista, True) = True Then
            fnFRMhijos_cerrar(frmPagosLista)
            Me.Hide()
        End If

    End Sub

    Private Sub fnPanel6() Handles Me.panel6
        frmGuiasLista.Dispose()
        frmGuiasLista.Text = "Guias de Facturas"
        frmGuiasLista.MdiParent = frmMenuPrincipal
        frmGuiasLista.bitFactura = True
        frmGuiasLista.bitCompra = False
        frmGuiasLista.bitDevolucionCliente = False
        frmGuiasLista.bitDevolucionProveedor = False
        If permiso.PermisoMantenimientoLista(frmGuiasLista, False) = True Then
            fnFRMhijos_cerrar(frmGuiasLista)
            Me.Hide()
        End If
    End Sub

    Private Sub fnPanel7() Handles Me.panel7
        frmClienteDevolucionLista.Name = "frmClienteDevolucionLista"
        frmClienteDevolucionLista.Text = "Lista de Devoluciones"
        frmClienteDevolucionLista.MdiParent = frmMenuPrincipal
        frmClienteDevolucionLista.bitVenta = True
        If permiso.PermisoMantenimientoLista(frmClienteDevolucionLista, True) = True Then
            fnFRMhijos_cerrar(frmClienteDevolucionLista)
            Me.Hide()
        End If
    End Sub

    'LISTA DE CIERRES DE CAJA
    Private Sub fnPanel8() Handles Me.panel8
        frmCierreCajaLista.Text = "Cierres de Caja"
        frmCierreCajaLista.MdiParent = frmMenuPrincipal
        If permiso.PermisoMantenimientoLista(frmCierreCajaLista, True) = True Then
            fnFRMhijos_cerrar(frmCierreCajaLista)
            Me.Hide()
        End If

    End Sub

    Private Sub fnPanel9() Handles Me.panel9
        frmReporteEstadisticas.Text = "Estadisticas"
        frmReporteEstadisticas.StartPosition = FormStartPosition.CenterScreen
        frmReporteEstadisticas.WindowState = FormWindowState.Normal
        frmReporteEstadisticas.ShowDialog()
        frmReporteEstadisticas.Dispose()
    End Sub

End Class