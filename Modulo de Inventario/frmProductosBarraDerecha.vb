﻿Public Class frmProductosBarraDerecha
    Private permiso As New clsPermisoUsuario

    Private Sub frmProductosBarraDerecha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl2.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            frmProductoPrecio.Text = "Precios"
            frmProductoPrecio.StartPosition = FormStartPosition.CenterScreen
            frmProductoPrecio.BringToFront()
            frmProductoPrecio.Focus()
            permiso.PermisoDialogEspeciales(frmProductoPrecio)
            frmProductoPrecio.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim idArticulo As Integer = mdlPublicVars.superSearchId
            frmProductoKardex.Text = "Kardex"
            frmProductoKardex.StartPosition = FormStartPosition.CenterScreen
            frmProductoKardex.articulo = idArticulo
            permiso.PermisoDialogEspeciales(frmProductoKardex)
            frmProductoKardex.Dispose()
        End If
    End Sub

    ''Private Sub fnPanel4() Handles Me.panel4
    ''    'If mdlPublicVars.superSearchFilasGrid > 0 Then
    ''    frmSustitutoLista.Text = "Sustitutos"
    ''    frmSustitutoLista.StartPosition = FormStartPosition.CenterScreen
    ''    frmSustitutoLista.BringToFront()
    ''    frmSustitutoLista.Focus()
    ''    permiso.PermisoDialogEspeciales(frmSustitutoLista)
    ''    frmSustitutoLista.Dispose()
    ''    'End If
    ''End Sub

    Private Sub fnConvertir() Handles Me.panel4
        frmConversorProductos.Text = "Conversor Productos"
        frmConversorProductos.StartPosition = FormStartPosition.CenterScreen
        frmConversorProductos.WindowState = FormWindowState.Normal
        frmConversorProductos.ShowDialog()
        frmConversorProductos.Dispose()
        Me.Close()
    End Sub

    Private Sub fnSucursal() Handles Me.panel5
        frmCrearArticulo_ActualizarPrecioSucursal.Text = "Actualizar Producto"
        frmCrearArticulo_ActualizarPrecioSucursal.StartPosition = FormStartPosition.CenterScreen
        frmCrearArticulo_ActualizarPrecioSucursal.WindowState = FormWindowState.Normal
        frmCrearArticulo_ActualizarPrecioSucursal.ShowDialog()
        frmCrearArticulo_ActualizarPrecioSucursal.Dispose()
        Me.Close()

    End Sub
End Class
