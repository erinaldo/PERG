﻿Imports System.Linq
Imports Telerik.WinControls

Public Class frmConfiguracion

    Private Sub frmConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarCombos()
        fnLlenarDatos()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar los cambios?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnModificaVariables()
            fnGuardarCambios()

            If RadMessageBox.Show("¿Desea realizar nuevos cambios?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnLlenarDatos()
            Else
                Close()
            End If

        End If
    End Sub

    'Funcion utilizada para llenar los combos
    Private Sub fnLlenarCombos()
        ' ---- PUESTOS -----
        Dim puesto As DataTable = EntitiToDataTable(From x In ctx.tblpuestoes Select codigo = x.idpuesto, x.nombre)

        With cmbCodigoBodeguero
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = puesto
        End With

        ' ---- INVENTARIOS -----
        Dim inven As DataTable = EntitiToDataTable(From x In ctx.tblTipoInventarios Select codigo = x.idTipoinventario, x.nombre)

        'Devolucion de Cliente
        With cmbInveDevolucionCliente
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = inven
        End With

        'Liquidacion
        With cmbLiquidación
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = inven.Copy
        End With

        'General
        With cmbInveGeneral
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = inven.Copy
        End With

        '------ TIPOS DE PRECIO ---------
        Dim precio As DataTable = EntitiToDataTable(From x In ctx.tblArticuloTipoPrecios Select x.codigo, x.nombre)

        With cmbPrecioEspecial
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = precio
        End With

        With cmbPrecioNormal
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = precio.Copy
        End With

        With cmbPrecioOferta
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = precio.Copy
        End With

        With cmbPrecioUltimasVentas
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = precio.Copy
        End With

        '-------- ALMACEN --------------
        Dim almacen As DataTable = EntitiToDataTable(From x In ctx.tblAlmacens Select x.codigo, x.nombre)

        With cmbAlmacen
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = almacen
        End With

        '------ IMPORTANCIA DE ARTICULO -----
        Dim importancia As IQueryable = (From x In ctx.tblArticuloImportancias Select x.codigo, x.nombre)

        With cmbRotacionArticulo
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = importancia
        End With
    End Sub

    'Funcion utilizada para llenar los datos
    Private Sub fnLlenarDatos()
        cmbCodigoBodeguero.SelectedValue = Bodega_CodigoPuestoBodegero
        chkBitacoraCotizar.Checked = Salida_BitacoraAlCotizar
        chkBitacoraReservar.Checked = Salida_BitaraAlReservar
        chkBitacoraDespachar.Checked = Salida_BitaAlDespachar
        txtDireccionImagenes.Text = General_CarpetaImagenes.Substring(0, General_CarpetaImagenes.LastIndexOf("\"))
        nm0UltimasVentas.Value = buscarArticulo_cantidadUltimasVentas
        txtDireccionCatalogo.Text = BuscarArticulo_CarpetaCatalogo.Substring(0, BuscarArticulo_CarpetaCatalogo.LastIndexOf("\"))
        nm2GeneralIva.Value = General_IVA
        nm0TiempoNoComprado.Value = General_TiempoNoComprado
        nm0ProductosNuevosMostrar.Value = General_NumeroProductosNuevos
        cmbPrecioNormal.SelectedValue = Empresa_PrecioNormal
        nm0IndicadorProductosNuevos.Value = Empresa_DiasUltimosProductos
        nm0DiasBitacoraProducto.Value = General_NumeroDiasBitacoraProductos
        txtDireccionFotoVendedores.Text = General_CarpetaFotosVendedor.Substring(0, General_CarpetaFotosVendedor.LastIndexOf("\"))
        cmbInveGeneral.SelectedValue = General_idTipoInventario
        cmbAlmacen.SelectedValue = General_idAlmacenPrincipal
        nm0DiasReserva.Value = Salida_ReservaDias
        cmbInveDevolucionCliente.SelectedValue = Cliente_InventarioDevolucion
        cmbLiquidación.SelectedValue = General_InventarioLiquidacion
        chkValidaVentaMaxima.Checked = Empresa_ValidaVenta
        nm2MargenMonetario.Value = Empresa_MargenMonetario
        nm0OfertaMinimosDias.Value = Empresa_OfertaMinimoDias
        cmbPrecioEspecial.SelectedValue = Empresa_PrecioEspecial
        cmbPrecioOferta.SelectedValue = BuscarArticulo_CodigoOferta
        txtCorreo.Text = Empresa_Correo
        txtCorreoClave.Text = Empresa_CorreoClave
        txtCorreoHost.Text = Empresa_CorreoHost
        nm0CorreoPuerto.Value = Empresa_CorreoPuerto
        nm0DecimalesCompras.Value = Entrada_numeroDecimales.Length

        'Agregados
        nm0ItemsFactura.Value = mdlPublicVars.numeroDeItemsDeFactura
        cmbPrecioUltimasVentas.SelectedValue = Empresa_PrecioUltimasVentas
        nm0MesesFrecuencia.Value = FrecuenciaCompra_MesesRango
        nm0DiasFrecuencia.Value = FrecuenciaCompra_DiasMargen
        nm2ToleranciaQuetzales.Value = CierreCaja_Tolerancia
        txtCombo1.Text = ProductoCombo1
        txtCombo2.Text = ProductoCombo2
        txtGrid1.Text = ProductoGrid1
        txtGrid2.Text = ProductoGrid2
    End Sub

    'BUSCAR CARPETA
    Private Function fnBuscarCarpeta(ByRef txt As TextBox) As String
        fnBuscarCarpeta = txt.Text

        Dim abrir As New FolderBrowserDialog

        If (abrir.ShowDialog = DialogResult.OK) Then
            fnBuscarCarpeta = abrir.SelectedPath
        End If
    End Function

    'BUSCAR CARPETA DE VENDEDORES
    Private Sub btnBuscarVendedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVendedores.Click
        txtDireccionFotoVendedores.Text = fnBuscarCarpeta(txtDireccionFotoVendedores)
    End Sub

    'BUSCAR CARPETA DE CATALOGOS
    Private Sub btnBuscarCatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCatalogo.Click
        txtDireccionCatalogo.Text = fnBuscarCarpeta(txtDireccionCatalogo)
    End Sub

    'BUSCAR CARPETA DE ARTICULOS
    Private Sub btnBuscarImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarImagenes.Click
        txtDireccionImagenes.Text = fnBuscarCarpeta(txtDireccionImagenes)
    End Sub

    'FUNCION UTILIZADA PARA MODIFICAR LAS VARIABLES DE CONFIGURACION
    Private Sub fnModificaVariables()
        Bodega_CodigoPuestoBodegero = cmbCodigoBodeguero.SelectedValue
        Salida_BitacoraAlCotizar = chkBitacoraCotizar.Checked
        Salida_BitaraAlReservar = chkBitacoraReservar.Checked
        Salida_BitaAlDespachar = chkBitacoraDespachar.Checked
        General_CarpetaImagenes = txtDireccionImagenes.Text
        buscarArticulo_cantidadUltimasVentas = nm0UltimasVentas.Value
        BuscarArticulo_CarpetaCatalogo = txtDireccionCatalogo.Text
        General_IVA = nm2GeneralIva.Value
        General_TiempoNoComprado = nm0TiempoNoComprado.Value
        General_NumeroProductosNuevos = nm0ProductosNuevosMostrar.Value
        Empresa_PrecioNormal = cmbPrecioNormal.SelectedValue
        Empresa_DiasUltimosProductos = nm0IndicadorProductosNuevos.Value
        General_NumeroDiasBitacoraProductos = nm0DiasBitacoraProducto.Value
        General_CarpetaFotosVendedor = txtDireccionFotoVendedores.Text
        General_idTipoInventario = cmbInveGeneral.SelectedValue
        General_idAlmacenPrincipal = cmbAlmacen.SelectedValue
        Salida_ReservaDias = nm0DiasReserva.Value
        Cliente_InventarioDevolucion = cmbInveDevolucionCliente.SelectedValue
        General_InventarioLiquidacion = cmbLiquidación.SelectedValue
        Empresa_ValidaVenta = chkValidaVentaMaxima.Checked
        Empresa_MargenMonetario = nm2MargenMonetario.Value
        Empresa_OfertaMinimoDias = nm0OfertaMinimosDias.Value
        Empresa_PrecioEspecial = cmbPrecioEspecial.SelectedValue
        BuscarArticulo_CodigoOferta = cmbPrecioOferta.SelectedValue
        Empresa_Correo = txtCorreo.Text
        Empresa_CorreoClave = txtCorreoClave.Text
        Empresa_CorreoHost = txtCorreoHost.Text
        Empresa_CorreoPuerto = nm0CorreoPuerto.Value
        Entrada_numeroDecimales = nm0DecimalesCompras.Value
        ProductoCombo1 = txtCombo1.Text
        ProductoCombo2 = txtCombo2.Text
        ProductoGrid1 = txtGrid1.Text
        ProductoGrid2 = txtGrid2.Text

        'Agregados
        mdlPublicVars.numeroDeItemsDeFactura = nm0ItemsFactura.Value
        Empresa_PrecioUltimasVentas = cmbPrecioUltimasVentas.SelectedValue
        FrecuenciaCompra_MesesRango = nm0MesesFrecuencia.Value
        FrecuenciaCompra_DiasMargen = nm0DiasFrecuencia.Value
        CierreCaja_Tolerancia = nm2ToleranciaQuetzales.Value
        ProductoCombo1 = txtCombo1.Text
        ProductoCombo2 = txtCombo2.Text
        ProductoGrid1 = txtGrid1.Text
        ProductoGrid2 = txtGrid2.Text
    End Sub

    'FUNCION UTILIZADA PARA GUARDAR LOS CAMBIOS
    Private Sub fnGuardarCambios()
        'Obtenemos toda las lista de configuraciones
        Dim lConfiguracion As List(Of tblConfiguracion) = (From x In ctx.tblConfiguracions Select x).ToList

        For Each config As tblConfiguracion In lConfiguracion
            If config.id = 15 Then config.valor = Bodega_CodigoPuestoBodegero
            If config.id = 17 Then config.valor = Salida_TipoMovimientoVenta
            If config.id = 20 Then config.valor = If(Salida_BitacoraAlCotizar, "1", "0")
            If config.id = 21 Then config.valor = If(Salida_BitaraAlReservar, "1", "0")
            If config.id = 22 Then config.valor = If(Salida_BitaAlDespachar, "1", "0")
            If config.id = 25 Then config.valor = Factura_CodigoMovimiento
            If config.id = 32 Then config.valor = If(Factura_UsaRegistroBodega, "1", "0")
            If config.id = 33 Then config.valor = Entrada_CodigoMovimiento
            If config.id = 34 Then config.valor = General_CarpetaImagenes
            If config.id = 35 Then config.valor = buscarArticulo_cantidadUltimasVentas
            If config.id = 36 Then config.valor = BuscarArticulo_CarpetaCatalogo
            If config.id = 37 Then config.valor = Cliente_DevolucionCodigoMovimiento
            If config.id = 38 Then config.valor = Proveedor_DevolucionCodigoMovimiento
            If config.id = 39 Then config.valor = Proveedor_AjusteCodigoMovimiento
            If config.id = 40 Then config.valor = General_IVA
            If config.id = 42 Then config.valor = General_TiempoNoComprado
            If config.id = 43 Then config.valor = Ajuste_CodigoMovimiento
            If config.id = 44 Then config.valor = General_NumeroProductosNuevos
            If config.id = 45 Then config.valor = General_CarpetaDocImpresion
            If config.id = 46 Then config.valor = Empresa_PrecioNormal
            If config.id = 48 Then config.valor = Empresa_DiasUltimosProductos
            If config.id = 49 Then config.valor = General_NumeroDiasBitacoraProductos
            If config.id = 50 Then config.valor = General_CarpetaFotosVendedor
            If config.id = 52 Then config.valor = General_idTipoInventario
            If config.id = 53 Then config.valor = General_idAlmacenPrincipal
            If config.id = 54 Then config.valor = Salida_ReservaDias
            If config.id = 55 Then config.valor = Cliente_InventarioDevolucion
            If config.id = 56 Then config.valor = General_InventarioLiquidacion
            If config.id = 57 Then config.valor = If(Empresa_ValidaVenta, "1", "0")
            If config.id = 58 Then config.valor = Empresa_MargenMonetario
            If config.id = 60 Then config.valor = Empresa_OfertaMinimoDias
            If config.id = 61 Then config.valor = Empresa_PrecioEspecial
            If config.id = 63 Then config.valor = BuscarArticulo_CodigoOferta
            If config.id = 64 Then config.valor = Empresa_Correo
            If config.id = 65 Then config.valor = Empresa_CorreoClave
            If config.id = 66 Then config.valor = Empresa_CorreoPuerto
            If config.id = 67 Then config.valor = Empresa_CorreoHost
            If config.id = 70 Then config.valor = nm0DecimalesCompras.Value

            'Agregados
            If config.id = 79 Then config.valor = CierreCaja_Tolerancia
            If config.id = 86 Then config.valor = Empresa_PrecioUltimasVentas
            If config.id = 87 Then config.valor = numeroDeItemsDeFactura
            If config.id = 88 Then config.valor = FrecuenciaCompra_MesesRango
            If config.id = 89 Then config.valor = FrecuenciaCompra_DiasMargen
            If config.id = 90 Then config.valor = ProductoCombo1
            If config.id = 91 Then config.valor = ProductoCombo2
            If config.id = 92 Then config.valor = ProductoGrid1
            If config.id = 93 Then config.valor = ProductoGrid2

            ctx.SaveChanges()
        Next

        mdlPublicVars.CargarVariablesdeConfiguracion()
        alerta.fnGuardar()
    End Sub

End Class