﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls


Public Class frmProveedorListaImportacion



    Public filtroActivo As Boolean
    Dim permiso As New clsPermisoUsuario
    Private Sub frmProveedorLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmProveedorLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            lbl2Eliminar.Text = "Deshabilitar"
            Dim iz As New frmProveedorBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmProveedorBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        llenagrid()

    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text

            Dim proveedorInfo = From x In ctx.tblProveedors Where x.idProveedor > 0 And x.empresa = mdlPublicVars.idEmpresa _
                                And (x.negocio.Contains(filtro) Or CType(x.idProveedor, String).Contains(filtro)) _
                                And x.procedencia = 2
                                Select Codigo = x.idProveedor, Clave = x.clave, Nombre = x.negocio, chkHabilitado = x.habilitado, _
                                Telefono = x.telefono, UltimaCompra = x.ultimaCompra, SaldoFisico = x.saldoActual, _
                                SaldoTransito = x.saldoTransito, SaldoDolar = x.saldoDolar,
                                PagosDolar = x.pagosDolar, PagosTransitoDolar = x.pagosTransitoDolar, ProximaFechaPago = ""

            Me.grdDatos.DataSource = proveedorInfo
            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnConfiguracion()
            fnEstableceFechas()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para establecer la proxima fecha de pago del cliente
    Public Sub fnEstableceFechas()
        Try
            'Recorremos el grid de proveedores
            Dim i
            Dim codPro As Integer = 0
            For i = 0 To Me.grdDatos.Rows.Count - 1
                'Obtenemos el codigo del proveedor
                codPro = Me.grdDatos.Rows(i).Cells("Codigo").Value

                Dim proximaFecha As DateTime = Today
                Dim minimo As DateTime = Nothing
                'Obtenemos la lista de compras a ese proveedor
                Dim lEntrada As List(Of tblEntrada) = (From x In ctx.tblEntradas Where x.idProveedor = codPro _
                                                     Select x Order By x.fechaPago Ascending).ToList

                For Each entrada As tblEntrada In lEntrada
                    minimo = Today
                    'Si fue al credito
                    If entrada.credito = True Then
                        'Obtenemos la fecha de pago
                        If entrada.fechaPago >= proximaFecha Then
                            minimo = entrada.fechaPago
                            Exit For
                        End If
                    End If
                Next
                Me.grdDatos.Rows(i).Cells("ProximaFechaPago").Value = minimo.ToShortDateString
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count >= 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "UltimaCompra")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "SaldoTransito")
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdDatos, "SaldoFisico")

                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdDatos, "SaldoDolar")
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdDatos, "PagosDolar")
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdDatos, "PagosTransitoDolar")


                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("UltimaCompra").HeaderText = "Ultima Compra"
                Me.grdDatos.Columns("chkHabilitado").HeaderText = "Habilitado"

                Me.grdDatos.Columns("Codigo").IsVisible = False

                Me.grdDatos.Columns("Codigo").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Nombre").Width = 200
                Me.grdDatos.Columns("chkHabilitado").Width = 60
                Me.grdDatos.Columns("Telefono").Width = 90
                Me.grdDatos.Columns("UltimaCompra").Width = 80
                Me.grdDatos.Columns("SaldoFisico").Width = 80
                'Me.grdDatos.Columns("SaldoTransito").Width = 80
                Me.grdDatos.Columns("SaldoDolar").Width = 80

                Me.grdDatos.Columns("PagosDolar").Width = 80
                Me.grdDatos.Columns("PagosTransitoDolar").Width = 80
                Me.grdDatos.Columns("ProximaFechaPago").Width = 80
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            frmProveedor.Text = "Modulo de Proveedores"
            frmProveedor.NuevoIniciar = True
            frmProveedor.proveedorlocal = False
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If

        Try
            frmProveedor.seleccionDefault = True
            frmProveedor.codigoDefault = codigo
            frmProveedor.NuevoIniciar = False
            frmProveedor.Text = "Modulo de Proveedores"
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If

            fnDeshabilita(codigo)
            Call llenagrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try

            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If

            Dim permiso As New clsPermisoUsuario
            frmProveedor.seleccionDefault = True
            frmProveedor.codigoDefault = codigo
            frmProveedor.NuevoIniciar = False
            frmProveedor.verRegistro = True
            frmProveedor.Text = "Modulo de Proveedores"
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para desabilitar un proveedor
    Private Sub fnDeshabilita(ByVal codigo As Integer)

        If RadMessageBox.Show("Desea anular !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim success As Boolean = True

            Try
                'Obtenemos el cliente con ese codigo
                Dim cli As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault

                'Deshabilitamos al cliente
                cli.habilitado = False
                ctx.SaveChanges()
            Catch ex As Exception
                success = False
            End Try

            If success = True Then
                alertas.fnModificar()
            Else
                alertas.fnErrorModificar()
            End If
        End If

    End Sub

    Public Function fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Dim codigo As Integer = 0
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                codigo = CType(Me.grdDatos.Rows(index).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchId = codigo
            End If
        Catch ex As Exception
            codigo = -1
            alertas.contenido = "Error al seleccionar Registro "
        End Try

        Return codigo
    End Function

    Private Sub fnFiltros() Handles Me.Exportar
        frmProveedorFiltro.Text = "Filtro: PROVEEDORES"
        frmProveedorFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmProveedorFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Proveedores"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub


End Class