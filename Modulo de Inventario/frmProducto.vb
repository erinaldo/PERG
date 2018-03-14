﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmProducto
    Dim r As New clsReporte
    Public nuevoProducto As Boolean = False
    Public codigoProductoNuevo As String = ""
    Public nombreProductoNuevo As String = ""
    Public importanciaProductoNuevo As Integer = 0
    Public idPendientePedir As Integer = 0
    Public posicion As Integer = 0
    Public permiso As New clsPermisoUsuario
    Public bitNuevoEntrada As Boolean = False
    Public bitNuevoPendiente As Boolean = False
    Public grdBase As RadGridView = Nothing

    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pgPrecios.Dispose()
        'Me.cmbInventario.Enabled = False
        ' mdlPublicVars.fnCrearCarpeta(mdlPublicVars.General_CarpetaImagenes)
        'mdlPublicVars.fnCrearCarpeta(mdlPublicVars.BuscarArticulo_CarpetaCatalogo)
        mdlPublicVars.fnFormatoGridEspeciales(grdSustitutos)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(grdModeloVehiculo)
        mdlPublicVars.fnFormatoGridEspeciales(grdFotos)
        mdlPublicVars.fnFormatoGridEspeciales(grdCodigosBarra)
        mdlPublicVars.fnFormatoGridEspeciales(grdInventarios)
        mdlPublicVars.fnFormatoGridEspeciales(grdCatalogos)
        mdlPublicVars.fnFormatoGridEspeciales(grdKit)
        mdlPublicVars.fnFormatoGridEspeciales(grdUnidadMedida)

        mdlPublicVars.comboActivarFiltro(cmbImportancia)
        mdlPublicVars.comboActivarFiltro(cmbMarcaRepuesto)
        mdlPublicVars.comboActivarFiltro(cmbTipoRepuesto)

        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automaticos
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        'Me.errores.Controls.Add(Me.txtCodigo1, "Codigo1")
        'Me.errores.SummaryMessage = "Faltan datos"
        llenarCombos()
        llenagrid()

        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)

        pctFoto.SizeMode = PictureBoxSizeMode.StretchImage
        pctFoto.BorderStyle = BorderStyle.Fixed3D

        lbl1Modificar.Text = "Guardar"
        Me.grdModeloVehiculo.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        chkKit.Enabled = NuevoIniciar
        chkProducto.Enabled = NuevoIniciar
        chkServicio.Enabled = NuevoIniciar
        chkUnidadMedida.Enabled = NuevoIniciar
        ''pgKit.Dispose()
        If NuevoIniciar = True Then
            Call limpiaCampos()
            fnLlenar_Listas()
            pnx1Modificar.Visible = False
            pnx0Guardar.Visible = True
            fnLimpiarEtiquetas()
            txtCodigo1.Focus()
            If nuevoProducto = True Then
                txtCodigo1.Text = codigoProductoNuevo
                txtNombre1.Text = nombreProductoNuevo
                cmbImportancia.SelectedValue = importanciaProductoNuevo
                txtNombre1.Focus()

                chkKit.Enabled = Not NuevoIniciar
                chkProducto.Enabled = Not NuevoIniciar
                chkServicio.Enabled = Not NuevoIniciar
            End If
            chkProducto.Checked = True
            btnAgregarKit.Enabled = False
        End If

        ' ''If chkKit.Checked = True Then
        ' ''    lblCostoKit.Visible = True
        ' ''Else
        ' ''    lblCostoKit.Visible = False
        ' ''End If

        lblCostoKit.Text = Format(fnCostoKit, mdlPublicVars.formatoMoneda)
        Me.cmbUnidadMedida.Enabled = True
        Me.nm5Valor.Enabled = True
        Me.nm2PrecioMedida.Enabled = True
        Me.chkDefault.Enabled = True
        Me.btnAgregarMedida.Enabled = True
        Me.btnCrear.Enabled = True

        If fn_recorre_grid() = True Then
            chkDefault.Enabled = False
        Else
            chkDefault.Enabled = True
        End If

        Me.grdUnidadMedida.AllowDeleteRow = False
        Me.grdKit.AllowDeleteRow = False

        fnNombres()

    End Sub

    Private Sub fnNombres()
        Me.lblGrid1.Text = mdlPublicVars.ProductoGrid1
        Me.lblGrid2.Text = mdlPublicVars.ProductoGrid2
        Me.lblCombo1.Text = mdlPublicVars.ProductoCombo1
        Me.lblCombo2.Text = mdlPublicVars.ProductoCombo2
    End Sub

    Private Sub llenagrid()
        Try
            Dim consulta = From x In ctx.tblInventarios Where _
                 x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = InventarioPrincipal _
                                And x.IdAlmacen = BodegaPrincipal _
                                Select Codigo = x.tblArticulo.idArticulo, Codigo1 = x.tblArticulo.codigo1, Codigo2 = x.tblArticulo.codigo2, _
                                Nombre1 = x.tblArticulo.nombre1, Nombre2 = x.tblArticulo.nombre2, x.tblArticulo.unidadEmpaque, _
                                Observacion = x.tblArticulo.Observacion, TipoRepuesto = x.tblArticulo.tblArticuloRepuesto.nombre, _
                                MarcaRepuesto = x.tblArticulo.tblArticuloMarcaRepuesto.nombre, Importancia = x.tblArticulo.tblArticuloImportancia.nombre, _
                                Transito = x.transito, Reserva = x.reserva, Minimo = x.tblArticulo.minimo, Maximo = x.tblArticulo.maximo, _
                                chkHabilitado = x.tblArticulo.Habilitado, x.tblArticulo.precioPublico, Costo = x.tblArticulo.costoIVA, VentaMaxima = x.tblArticulo.ventaMaxima, _
                                chkVentaMaxima = x.tblArticulo.bitVentaMaxima, chkNoSustitutos = x.tblArticulo.bitNoSustitutos, chkNoCajas = x.tblArticulo.bitNoCajas, _
                                chkNoCatalogo = x.tblArticulo.bitNoCatalogo, chkNoCodigos = x.tblArticulo.bitNoCodigosBarra, chkNoEstanteria = x.tblArticulo.bitNoEstanteria, _
                                chkNoFoto = x.tblArticulo.bitNoFotos, FechaCreacion = x.tblArticulo.fechaCrea, chkProducto = x.tblArticulo.bitProducto,
                                chkServicio = x.tblArticulo.bitServicio, chkKit = x.tblArticulo.bitKit, CostoKit = x.tblArticulo.costoIVA, chkUnidadMedida = x.tblArticulo.bitUnidadMedida

            Me.grdDatos.DataSource = consulta

            'Verificamos si esta activo el filtro entonces mostramos solo productos del grid filtrado
            If frmProductoLista.filtroActivo Then
                Dim lFiltro = (From x As GridViewRowInfo In grdBase.Rows Join y As GridViewRowInfo In grdDatos.Rows
                                    On x.Cells("ID").Value Equals y.Cells("Codigo").Value _
                                    Select Codigo = y.Cells("Codigo").Value, Codigo1 = y.Cells("Codigo1").Value, Codigo2 = y.Cells("Codigo2").Value,
                                    Nombre1 = y.Cells("Nombre1").Value, Nombre2 = y.Cells("Nombre2").Value, unidadEmpaque = y.Cells("unidadEmpaque").Value,
                                    Observacion = y.Cells("Observacion").Value, TipoRepuesto = y.Cells("TipoRepuesto").Value, MarcaRepuesto = y.Cells("MarcaRepuesto").Value,
                                    Importancia = y.Cells("Importancia").Value, Transito = y.Cells("Transito").Value, Reserva = y.Cells("Reserva").Value,
                                    Minimo = y.Cells("Minimo").Value, Maximo = y.Cells("Maximo").Value, chkHabilitado = y.Cells("chkHabilitado").Value,
                                    precioPublico = y.Cells("precioPublico").Value, Costo = y.Cells("Costo").Value, VentaMaxima = y.Cells("VentaMaxima").Value,
                                    chkVentaMaxima = y.Cells("chkVentaMaxima").Value, chkNoSustitutos = y.Cells("chkNoSustitutos").Value,
                                    chkNoCajas = y.Cells("chkNoCajas").Value, chkNoCatalogo = y.Cells("chkNoCatalogo").Value, chkNoCodigos = y.Cells("chkNoCodigos").Value,
                                    chkNoEstanteria = y.Cells("chkNoEstanteria").Value, chkNofoto = y.Cells("chkNoFoto").Value, FechaCreacion = y.Cells("FechaCreacion").Value,
                                    chkProducto = y.Cells("chkProducto").Value, chkServicio = y.Cells("chkServicio").Value, chkKit = y.Cells("chkKit").Value,
                                    CostoKit = y.Cells("CostoKit").Value, chkUnidadMedida = y.Cells("bitUnidadMedida").Value
                                    ).ToList

                Me.grdDatos.DataSource = lFiltro
            End If

            If pctFoto.Image IsNot Nothing Then
                pctFoto.Image = Nothing
            End If
            Me.grdFotos.Rows.Clear()
            If Me.grdDatos.Rows.Count > 0 Then
                fnLlenarFotos(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value)
                fnFoto()
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub llenarCombos()

        'cmbInventario.Enabled = True


        'Dim inven = (From x In ctx.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre Order By Codigo Ascending)

        'With Me.cmbInventario
        '    .DataSource = Nothing
        '    .ValueMember = "Codigo"
        '    .DisplayMember = "Nombre"
        '    .DataSource = inven
        'End With
        'cmbInventario.Text = "Estanteria"

        Dim tipoRepuesto = From x In ctx.tblArticuloRepuestoes Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

        With Me.cmbTipoRepuesto
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = tipoRepuesto
        End With

        Dim marcaRepuesto = From x In ctx.tblArticuloMarcaRepuestoes Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

        With Me.cmbMarcaRepuesto
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = marcaRepuesto
        End With

        fnLlenarComboUnidadMedida()

        Dim unidadKit = (From x In ctx.tblArticuloes Select Codigo = 0, Nombre = "< Ninguno >").Union(From x In ctx.tblArticuloes Where x.bitKit Select Codigo = x.idArticulo, Nombre = x.nombre1 Order By Nombre)

        With Me.cmxKit
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = unidadKit
        End With

        Dim importancia = From x In ctx.tblArticuloImportancias Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

        With Me.cmbImportancia
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = importancia
        End With

        'Try
        '    'Tabla para el combo de catalogos
        '    Dim cat As New DataTable
        '    cat.Columns.Add("Codigo")
        '    cat.Columns.Add("Nombre")

        '    ''Carpetas 
        '    Dim catalogos As String() = Directory.GetDirectories(mdlPublicVars.BuscarArticulo_CarpetaCatalogo)
        '    Dim direccion As String()
        '    Dim imagen As String
        '    ''Recorremos el arreglo con catalogos
        '    For i As Integer = 0 To UBound(catalogos)
        '        direccion = Split(catalogos(i), "\")
        '        imagen = direccion(UBound(direccion))

        '        If Not imagen.Equals("Thumbs") Then
        '            cat.Rows.Add(catalogos(i), imagen)
        '        End If
        '    Next

        '    With cmbCarpeta
        '        .DataSource = Nothing
        '        .ValueMember = "Codigo"
        '        .DisplayMember = "Nombre"
        '        .DataSource = cat
        '    End With
        'Catch ex As Exception
        '    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        'End Try
    End Sub

    Private Sub frm_llenarLista() Handles MyBase.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_focoDatos() Handles MyBase.focoDatos
        txtCodigo1.Focus()
    End Sub

    'Funcion que se utiliza para poder crear un nuevo campo
    Private Sub frm_nuevoRegistro() Handles MyBase.nuevoRegistro
        limpiaCampos()
        txtCodigo1.Focus()
        fnLlenar_Listas()
        fnLimpiarEtiquetas()

        If pctFoto.Image IsNot Nothing Then
            pctFoto.Image = Nothing
        End If
        If verRegistro = True Then
            'se manda de parametro el formulario y el estado a deshabilitado.
            base.FnDeshabilitarHabilitarCampos(Me, False)
        End If
    End Sub

    Private Sub fnLimpiarEtiquetas()
        lblPrecioPublico.Text = "0"
        lblCosto.Text = "0"
        lblCostoKit.Text = "0"
    End Sub

    Private Sub fnLlenar_Listas()
        Dim id As Integer

        If NuevoIniciar = True Then
            id = 0
        Else
            Try
                id = txtCodigo.Text
            Catch ex As Exception
                id = 0
            End Try

        End If
        'tipo de vehiculo con grid
        Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblArticulo_TipoVehiculo _
                            Where x.codigo = y.articuloTipoVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblArticulo_TipoVehiculo _
                            Where x.codigo = y.articuloTipoVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)



        Me.grdTipoVehiculo.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.iddetalle, v.CODIGO, v.NOMBRE)
        Next


        'modelo de vehiculo con grid
        Dim mv = (From x In ctx.tblArticuloModeloVehiculoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblArticulo_ModeloVehiculo _
                            Where x.codigo = y.articuloModeloVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblArticulo_ModeloVehiculo _
                            Where x.codigo = y.articuloModeloVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModeloVehiculo.Rows.Clear()
        Dim v2
        For Each v2 In mv
            Me.grdModeloVehiculo.Rows.Add(v2.AGREGAR, v2.iddetalle, v2.CODIGO, v2.NOMBRE)
        Next

    End Sub

    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        'llenar lista de modelo, marcas, tipo de vehiculo.
        fnLlenar_Listas()

        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)

        'llenar clasificacion de compra del cliente.
        If NuevoIniciar = False Then
            Try
                'Colocamos lo que hay pendiente por surtir
                fnPendienteSurtir()

                'Llenamos el grid de inventario
                llenarGridInventarios()

                'Llenamos el grid sustitutos
                Me.grdSustitutos.Rows.Clear()
                llenarGridSustitutos()

                'Llenamos el grid de kits
                Me.grdKit.Rows.Clear()
                fnLlenarGridKit()

                ''Lenamos el grid de Unidades de Medida
                Me.grdUnidadMedida.Rows.Clear()
                fnLlenarGridUnidadMedida()

                'Llenamos las ubicaciones
                Dim ubicaciones As tblArticuloAlmacen = (From x In ctx.tblArticuloAlmacens Where x.articulo = txtCodigo.Text).FirstOrDefault
                If ubicaciones Is Nothing Then
                    txtUbicacionCajas.Text = ""
                    txtUbicacionEstanteria.Text = ""
                Else
                    txtUbicacionCajas.Text = ubicaciones.ubicacionCajas
                    txtUbicacionEstanteria.Text = ubicaciones.ubicacionEstanteria
                End If

                'Liberamos las fotos
                If pctFoto.Image IsNot Nothing Then
                    pctFoto.Image = Nothing
                End If

                'Llenamos el grid de fotos
                fnLlenarFotos(CType(txtCodigo.Text, Integer))

                If Me.grdFotos.Rows.Count > 0 Then
                    fnFoto()
                End If

                ''If chkKit.Checked = True Then
                ''    lblCostoKit.Visible = True
                ''Else
                ''    lblCostoKit.Visible = False
                ''End If

                'Llenamos los codigos de barra
                fnLlenaCodigosBarra(CType(txtCodigo.Text, Integer))
                fnLlenarCatalogos(CType(txtCodigo.Text, Integer))
            Catch ex As Exception

            End Try
        Else
        End If
    End Sub

    'Funcion utilizada para llenar los catalogos
    Private Sub fnLlenarCatalogos(ByVal codArt As Integer)
        grdCatalogos.Rows.Clear()
        'Obtenemos la lista de catalogos de dicho articulo
        Dim catalogos As List(Of tblArticulo_Catalogo) = (From x In ctx.tblArticulo_Catalogo Where x.articulo = codArt _
                                                          Select x).ToList

        For Each cat As tblArticulo_Catalogo In catalogos
            grdCatalogos.Rows.Add(cat.codigo, cat.imagen, cat.numero, cat.observacion)
        Next

    End Sub

    'Funcion utilizada para cargar las fotos
    Private Sub fnCargarFoto(ByRef pct As PictureBox, ByVal direccion As String)
        Try
            'Vaciamos la imagen
            If pct.Image IsNot Nothing Then
                pct.Image = Nothing
            End If

            If direccion IsNot Nothing Then
                If direccion.Length > 0 Then
                    Dim stream As New System.IO.StreamReader(direccion)
                    pct.Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    pct.SizeMode = PictureBoxSizeMode.StretchImage
                    pct.BorderStyle = BorderStyle.Fixed3D
                End If
            End If
        Catch ex As Exception
            alertas.contenido = "Ocurrio un error al intentar abrir la imagen"
            alertas.fnErrorContenido()
        End Try
    End Sub

    'GUARDAR
    Private Sub frm_grabaRegistro() Handles MyBase.grabaRegistro
        If IsNumeric(txtCodigo.Text) Then
            fnModificarProducto()
        Else
            fnGuardarProducto()
        End If
    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles MyBase.modificaRegistro
        If IsNumeric(txtCodigo.Text) Then
            fnModificarProducto()
            lblCostoKit.Text = Format(fnCostoKit, mdlPublicVars.formatoMoneda)
        Else
            fnGuardarProducto()
            lblCostoKit.Text = Format(fnCostoKit, mdlPublicVars.formatoMoneda)
        End If
    End Sub

    'Funcion utilizada para modificar un producto
    Private Sub fnModificarProducto()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigo As Integer = 0
            Dim success As Boolean = True
            Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor

            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try

                    ''Modificaciones de Kits y Unidades de Medida
                    If chkKit.Checked = True Then

                        '---- Si es kit guardamos el kit
                        fnGuardaKit()

                    ElseIf chkUnidadMedida.Checked = True Then

                        '---si es unidad medida guardamos la unidad
                        Dim val As Boolean

                        val = fnGuardarUnidadesMedida()

                        If val = False Then
                            Exit Sub
                        End If
                    End If

                    ctx.SaveChanges()
                    ''Fin de modificaciones de Kits y Unidades de Medida

                    Dim m As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = txtCodigo.Text Select x).FirstOrDefault

                    'recuento de numero de transacciones en salida, entrada.
                    Dim noSalidas As Integer = (From x In ctx.tblSalidaDetalles Where x.idArticulo = m.idArticulo).Count + (From x In ctx.tblEntradasDetalles Where x.idArticulo = m.idArticulo).Count

                    If m.codigo1.Equals(txtCodigo1.Text) Then
                        'no hay problemas
                    ElseIf noSalidas > 0 Then
                        'asignar el contenido del error.
                        alertas.contenido = "No puede cambiar el codigo del producto porque ya tiene registros"
                        'muestra el error.
                        alertas.fnErrorContenido()
                        Exit Sub
                    End If


                    m.Habilitado = chkHabilitado.Checked
                    m.idArticuloImportancia = cmbImportancia.SelectedValue
                    m.idArticuloMarcaRepuesto = cmbMarcaRepuesto.SelectedValue
                    m.idArticuloRepuesto = cmbTipoRepuesto.SelectedValue

                    m.idUsuario = mdlPublicVars.idUsuario
                    m.nombre1 = txtNombre1.Text
                    m.nombre2 = txtNombre2.Text
                    m.codigo1 = txtCodigo1.Text
                    m.codigo2 = txtCodigo2.Text

                    m.Observacion = txtObservacion.Text
                    m.unidadEmpaque = txtUnidadEmpaque.Text
                    m.bitVentaMaxima = chkVentaMaxima.Checked

                    m.minimo = nm0Minimo.Value
                    m.maximo = nm0Maximo.Value
                    m.ventaMaxima = nm0VentaMaxima.Value
                    m.bitVentaMaxima = chkVentaMaxima.Checked
                    m.bitNoCajas = chkNoCajas.Checked
                    m.bitNoCatalogo = chkNoCatalogo.Checked
                    m.bitNoCodigosBarra = chkNoCodigos.Checked
                    m.bitNoEstanteria = chkNoEstanteria.Checked
                    m.bitNoFotos = chkNoFoto.Checked
                    m.bitNoSustitutos = chkNoSustitutos.Checked


                    codigo = m.idArticulo

                    If m.bitKit Then
                        m.costoIVA = CDec(lblCostoKit.Text)
                        m.costoSinIVA = m.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                    End If
                    ctx.SaveChanges()
                    'Guardamos las ubicaciones en el alamacen
                    'guarda la ubicacion en el almacen


                    Dim inv As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = txtCodigo.Text).FirstOrDefault
                    inv.idTipoInventario = 1 'Me.cmbInventario.SelectedValue
                    inv.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                    ctx.SaveChanges()


                    Dim ub As tblArticuloAlmacen = (From x In ctx.tblArticuloAlmacens Where x.articulo = txtCodigo.Text).FirstOrDefault

                    If ub Is Nothing Then
                        Dim nuevaUbicacion As New tblArticuloAlmacen
                        nuevaUbicacion.articulo = m.idArticulo
                        nuevaUbicacion.almacen = mdlPublicVars.General_idAlmacenPrincipal
                        nuevaUbicacion.ubicacionCajas = txtUbicacionCajas.Text
                        nuevaUbicacion.ubicacionEstanteria = txtUbicacionEstanteria.Text
                        ctx.AddTotblArticuloAlmacens(nuevaUbicacion)
                        ctx.SaveChanges()
                    Else
                        ub.almacen = mdlPublicVars.General_idAlmacenPrincipal
                        ub.articulo = m.idArticulo
                        ub.ubicacionCajas = txtUbicacionCajas.Text
                        ub.ubicacionEstanteria = txtUbicacionEstanteria.Text
                        ctx.SaveChanges()
                    End If

                    Dim estado As Boolean = False
                    Dim cod As Integer
                    Dim i As Integer
                    Dim id As Integer
                    Dim grd As Telerik.WinControls.UI.RadGridView

                    'AGREGAR TIPO DE VEHICULO.
                    grd = Me.grdTipoVehiculo
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells("Agregar").Value
                        cod = grd.Rows(i).Cells("Codigo").Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblArticulo_TipoVehiculo
                                tv.articuloTipoVehiculo = cod
                                tv.articulo = m.idArticulo
                                ctx.AddTotblArticulo_TipoVehiculo(tv)
                                ctx.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells("Id").Value
                                Dim tv As tblArticulo_TipoVehiculo = (From x In ctx.tblArticulo_TipoVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    ctx.DeleteObject(tv)
                                    ctx.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'AGREGAR MODELO DE VEHICULO
                    grd = Me.grdModeloVehiculo
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells("Agregar").Value
                        cod = grd.Rows(i).Cells("Codigo").Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                            Else
                                Dim tv As New tblArticulo_ModeloVehiculo
                                tv.articuloModeloVehiculo = cod
                                tv.articulo = m.idArticulo
                                ctx.AddTotblArticulo_ModeloVehiculo(tv)
                                ctx.SaveChanges()
                            End If
                        Else ' si estado = falso
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells("Id").Value
                                Dim tv As tblArticulo_ModeloVehiculo = (From x In ctx.tblArticulo_ModeloVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv IsNot Nothing Then
                                    ctx.DeleteObject(tv)
                                    ctx.SaveChanges()
                                End If
                            End If
                        End If
                    Next


                    '---- SUSTITUTOS -----
                    fnGuardaSustitutos()

                    'completar la transaccion.
                    success = True
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
                        alertas.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                alertas.fnModificar()
                'Vaciamos el picture box
                If pctFoto.Image IsNot Nothing Then
                    pctFoto.Image = Nothing
                End If

                'Guardamos las imagenes
                If Me.grdFotos.Rows.Count > 0 Then
                    For i As Integer = 0 To Me.grdFotos.Rows.Count - 1
                        fnGuardar_foto(codigo, i)
                    Next
                End If

                Call llenagrid()
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using


    End Sub

    'Funcion utilizada para guardar un producto
    Private Sub fnGuardarProducto()
        'Verificamos que no falten los campos requeridos
        If fnRequeridos.Length > 0 Then
            alertas.contenido = fnRequeridos()
            alertas.fnErrorContenido()
            Exit Sub
        End If

        'Verificamos si aun no existe el codigo
        If fnVerificaCodigo(txtCodigo1.Text) = True Then
            RadMessageBox.Show("El codigo " & txtCodigo1.Text & " ya existe !!!", nombreSistema)

            If RadMessageBox.Show("Desea Habilitarlo?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.codigo1 = txtCodigo1.Text And x.empresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                    articulo.Habilitado = True

                    conexion.SaveChanges()

                    conn.Close()
                End Using
            End If

            Exit Sub
        End If

        Dim codigoArticulo As String = ""
        Dim codigo As Integer = 0
        Dim success As Boolean = True
        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim m As New tblArticulo
        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                m.Habilitado = True
                m.idArticuloImportancia = cmbImportancia.SelectedValue
                m.idArticuloMarcaRepuesto = cmbMarcaRepuesto.SelectedValue
                m.idArticuloRepuesto = cmbTipoRepuesto.SelectedValue
                m.empresa = mdlPublicVars.idEmpresa
                m.idUsuario = mdlPublicVars.idUsuario
                m.nombre1 = txtNombre1.Text
                m.nombre2 = txtNombre2.Text
                m.codigo1 = txtCodigo1.Text
                m.codigo2 = txtCodigo2.Text
                m.costoIVA = 0
                m.costoSinIVA = 0
                m.Observacion = txtObservacion.Text
                m.unidadEmpaque = txtUnidadEmpaque.Text
                m.fechaCrea = fecha
                m.preciopublicosucursal = 0

                m.minimo = nm0Minimo.Value
                m.maximo = nm0Maximo.Value
                m.ventaMaxima = nm0VentaMaxima.Value
                m.bitVentaMaxima = chkVentaMaxima.Checked
                m.bitNoCajas = chkNoCajas.Checked
                m.bitNoCatalogo = chkNoCatalogo.Checked
                m.bitNoCodigosBarra = chkNoCodigos.Checked
                m.bitNoEstanteria = chkNoEstanteria.Checked
                m.bitNoFotos = chkNoFoto.Checked
                m.bitNoSustitutos = chkNoSustitutos.Checked
                m.idUnidadMedida = mdlPublicVars.UnidadMedidaDefault

                m.bitProducto = chkProducto.Checked
                m.bitServicio = chkServicio.Checked
                m.bitKit = chkKit.Checked
                m.bitUnidadMedida = chkUnidadMedida.Checked
                m.ultimoprecio = False

                If (Not chkProducto.Checked And Not chkServicio.Checked And Not chkKit.Checked And Not chkUnidadMedida.Checked) Then
                    m.bitProducto = True
                End If

                If m.bitKit Then
                    m.costoIVA = CDec(lblCostoKit.Text)
                    m.costoSinIVA = m.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                End If

                ctx.AddTotblArticuloes(m)
                ctx.SaveChanges()
                codigo = m.idArticulo
                codigoArticulo = m.codigo1
                'guarda la ubicacion en el almacen
                Dim ub As New tblArticuloAlmacen
                ub.almacen = mdlPublicVars.General_idAlmacenPrincipal
                ub.articulo = m.idArticulo
                ub.ubicacionCajas = txtUbicacionCajas.Text
                ub.ubicacionEstanteria = txtUbicacionEstanteria.Text
                ctx.AddTotblArticuloAlmacens(ub)
                ctx.SaveChanges()

                'crear registro de inventario.
                Dim inv As New tblInventario
                inv.idArticulo = m.idArticulo
                inv.entrada = 0
                inv.salida = 0
                inv.saldo = 0
                inv.reserva = 0
                inv.idTipoInventario = 1 'Me.cmbInventario.SelectedValue
                inv.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                inv.transito = 0
                ctx.AddTotblInventarios(inv)
                ctx.SaveChanges()
                'agregar tipo de vehiculo.
                Dim i
                Dim valor As Boolean = False
                Dim cod As Integer = 0

                For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                    valor = Me.grdTipoVehiculo.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdTipoVehiculo.Rows(i).Cells(2).Value
                        Dim tv As New tblArticulo_TipoVehiculo
                        tv.articulo = m.idArticulo
                        tv.articuloTipoVehiculo = cod
                        ctx.AddTotblArticulo_TipoVehiculo(tv)
                        ctx.SaveChanges()
                    End If
                Next

                'modelo de vehiculo
                For i = 0 To Me.grdModeloVehiculo.Rows.Count - 1
                    valor = Me.grdModeloVehiculo.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdModeloVehiculo.Rows(i).Cells(2).Value
                        Dim tv As New tblArticulo_ModeloVehiculo
                        tv.articulo = m.idArticulo
                        tv.articuloModeloVehiculo = cod
                        ctx.AddTotblArticulo_ModeloVehiculo(tv)
                        ctx.SaveChanges()
                    End If
                Next

                alertas.fnGuardar()

                'completar la transaccion.
                success = True
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
                    alertas.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()

            If nuevoProducto = True Then
                If bitNuevoEntrada Then
                    frmEntrada.fnBuscarArticulo(codigoArticulo, posicion)
                ElseIf bitNuevoPendiente Then
                    'Guardamos los cambios del pendiente
                    Dim pendiente As tblPendientePorPedir = (From x In ctx.tblPendientePorPedirs Where x.codigo = idPendientePedir Select x).FirstOrDefault
                    pendiente.articulo = mdlPublicVars.superSearchId
                    pendiente.bitCreado = True
                    ctx.SaveChanges()

                    'Verifica si hay pendientes por pedir
                    fnVerificaPendientePedir(pendiente.codigoArticulo, pendiente.articulo)

                    frmBuscarArticuloPendientePedir.fnLlenarGrid()
                End If
                Me.Close()
            Else
                Call llenagrid()
                NuevoIniciar = False
                Call fnLlenar_Listas()
                If RadMessageBox.Show("¿Desea guardar otro registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    fnlimpiar()
                Else
                    Me.Close()
                End If
            End If
        Else
            alertas.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub

    Public Sub fnlimpiar()
        txtCodigo2.Clear()
        txtCodigo.Clear()
        txtCodigo1.Clear()
        txtCodigoBarra.Clear()
        txtEmpaque.Clear()
        txtImagen.Clear()
        txtNombre1.Clear()
        txtNombre2.Clear()
        txtUnidadEmpaque.Clear()
        txtObservacion.Clear()
        txtObservacionCatalogo.Clear()
        txtUbicacionCajas.Clear()
        txtUbicacionEstanteria.Clear()
        txtUnidadEmpaque.Clear()

        cmbCarpeta.Text = ""
        cmbImportancia.Text = ""
        cmbMarcaRepuesto.Text = ""
        cmbPagina.Text = ""
        cmbTipoRepuesto.Text = ""
        txtObservacion.Clear()
        chkDefault.Checked = False
        chkNoCajas.Checked = False
        chkNoCatalogo.Checked = False
        chkNoEstanteria.Checked = False
        chkNoFoto.Checked = False
        chkNoSustitutos.Checked = False
        chkProducto.Checked = False
        chkServicio.Checked = False
        chkTodosModelo.Checked = False
        chkTodosVehiculo.Checked = False
        chkUnidadMedida.Checked = False
        chkVentaMaxima.Checked = False

        nm0Maximo.Value = 0
        nm0Minimo.Value = 0
        nm0VentaMaxima.Value = 0
        nm2PrecioMedida.Value = 0
        nm5Valor.Value = 0
        End Sub

    'VERIFICA PENDIENTES POR PEDIR
    Private Sub fnVerificaPendientePedir(codArt As String, idArticulo As Integer)
        'Obtenemos el listado de los pendientes por pedir que tengan ese codigo de articulo
        Dim lPendientes As List(Of tblPendientePorPedir) = (From x In ctx.tblPendientePorPedirs Where x.codigoArticulo.Trim = codArt.Trim
                                                            Select x).ToList

        For Each pendiente As tblPendientePorPedir In lPendientes
            'Creamos el pendiente por surtir
            Dim surtir As New tblSurtir
            'Creamos el pendiente por surtir
            surtir.articulo = idArticulo
            surtir.cantidad = pendiente.cantidad
            surtir.saldo = pendiente.cantidad
            surtir.fechaTransaccion = pendiente.fechaRegistro
            surtir.anulado = False
            surtir.usuario = mdlPublicVars.idUsuario
            surtir.vendedor = mdlPublicVars.idVendedor
            surtir.cliente = pendiente.cliente
            ctx.AddTotblSurtirs(surtir)
            ctx.SaveChanges()

            pendiente.pendienteSurtir = surtir.codigo
            pendiente.bitCreado = True
            pendiente.articulo = idArticulo
            ctx.SaveChanges()
        Next

    End Sub


    'Funcion utilizada para guardar una foto
    Private Sub fnGuardar_foto(ByVal codigo As Integer, ByVal fila As String)
        Dim success As Boolean = True


        Using transaction As New TransactionScope
            Try
                'Obtenemos el codigo de la imagen
                Dim idFoto As Integer = CType(Me.grdFotos.Rows(fila).Cells("codigo").Value, Integer)
                Dim direccion As String = CType(Me.grdFotos.Rows(fila).Cells("direccion").Value, String)
                Dim elimina As Integer = CType(Me.grdFotos.Rows(fila).Cells("elimina").Value, Integer)

                'Si elimin
                If elimina > 0 Then
                    'Obtenemos y eliminamos la foto de la carpeta de imagenes
                    Dim foto As tblArticulo_Foto = (From x In ctx.tblArticulo_Foto Where x.codigo = idFoto Select x).FirstOrDefault
                    'Si ya tiene codigo
                    fnEliminaFoto(Path.Combine(mdlPublicVars.General_CarpetaImagenes, foto.codigo & ".jpg"))
                    ctx.DeleteObject(foto)
                    ctx.SaveChanges()
                ElseIf idFoto = 0 Then
                    'Creamos la nueva imagen
                    Dim foto As New tblArticulo_Foto

                    foto.articulo = codigo
                    ctx.AddTotblArticulo_Foto(foto)
                    ctx.SaveChanges()
                    Dim codFoto As Integer = foto.codigo
                    'guardar la imagen.
                    Dim Ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, codFoto & ".jpg")
                    Dim stream As New System.IO.StreamReader(direccion)
                    Dim imagen As Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    Dim bmap As Bitmap = New Bitmap(imagen)
                    bmap.Save(Ruta, imagen.RawFormat)
                    bmap.Dispose()
                    ctx.SaveChanges()
                End If
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
                    alertas.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If

            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
        Else

        End If
    End Sub

    'Elimina una foto
    Private Sub fnEliminaFoto(ByVal dir As String)
        Try
            'verifica si existe la elimina.
            If dir IsNot Nothing Then
                If dir.Length > 0 Then
                    'veririfica si existe el archivo
                    If My.Computer.FileSystem.FileExists(dir) Then
                        'eliminar el archivo.
                        My.Computer.FileSystem.DeleteFile(dir)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Llena el grid de fotos
    Private Sub fnLlenarFotos(ByVal codigo As Integer)
        Try
            Me.grdFotos.Rows.Clear()
            'Obtenemos las fotos del articulo
            Dim fotos As List(Of tblArticulo_Foto) = (From x In ctx.tblArticulo_Foto Where x.articulo = codigo Select x).ToList
            Dim foto As tblArticulo_Foto
            Dim i As Integer = 0
            For Each foto In fotos
                i += 1
                Dim fila As String()
                Dim ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, foto.codigo & ".jpg")
                fila = {foto.codigo, ruta, "0", "Imagen " & i}
                Me.grdFotos.Rows.Add(fila)
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub frm_eliminaRegistro() Handles MyBase.eliminaRegistro

        If MsgBox("Esta seguro de Deshabilitar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If


        Try
            Dim m As tblArticulo = (From e1 In ctx.tblArticuloes Where e1.idArticulo = Me.txtCodigo.Text Select e1).First()
            m.Habilitado = False
            ctx.SaveChanges()

            alertas.contenido = "Registro Deshabilitado"
            alertas.fnErrorContenido()

            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    'Funcion que maneja el evento click en el boton de subirFoto
    Private Sub btnSubirFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        fnSubirFoto(pctFoto)
    End Sub

    'Funcion utilizada para subir la foto
    Private Sub fnSubirFoto(ByRef pct)
        Dim abrir As New OpenFileDialog
        With abrir
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With

        If (abrir.ShowDialog = DialogResult.OK) Then

            Dim stream As New System.IO.StreamReader(abrir.FileName)
            pct.Image = Image.FromStream(stream.BaseStream)
            stream.Dispose()
            pct.SizeMode = PictureBoxSizeMode.StretchImage
            pct.BorderStyle = BorderStyle.Fixed3D

            'Agregamos una fila al grid
            Dim fila As String() = {"0", abrir.FileName.ToString, "0"}
            Me.grdFotos.Rows.Add(fila)
        End If
    End Sub

    Private Sub btnSustitutos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSustituto.Click
        'Obtenemos la primer palabra
        Dim palabras As String() = txtNombre1.Text.Split

        If IsNumeric(txtCodigo.Text) Then
            If fnEliminoRegistro(grdSustitutos) = True Then
                alertas.contenido = "Debe guardar los cambios antes"
                alertas.fnErrorContenido()
            Else
                frmSustitutos.grdBase = Me.grdSustitutos
                frmSustitutos.base2 = txtCodigo.Text
                frmSustitutos.filtro = palabras(0)
                frmSustitutos.Text = "Agregar Sustitutos"
                frmSustitutos.StartPosition = FormStartPosition.CenterScreen
                frmSustitutos.ShowDialog()
            End If
        Else
            alertas.contenido = "Debe de guardar primero el articulo"
            alertas.fnErrorContenido()
        End If
    End Sub

    Public Sub llenarGridSustitutos()
        Try
            Dim articulo As Integer = CType(txtCodigo.Text, Integer)

            Dim categoria = (From x In ctx.tblSustitutoes _
                           Where x.idarticulo = articulo And x.idempresa = mdlPublicVars.idEmpresa And x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                           And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                           Select x).ToList

            Dim listaCategoria As List(Of tblSustituto) = categoria

            Dim contador As Integer = 0
            Dim valor As New tblSustituto
            For Each valor In listaCategoria
                contador = contador + 1
            Next

            If contador > 0 Then
                Dim categoriaSustituto As Integer = CType(valor.idSustitutoCategoria, Integer)
                Dim sustitutos As List(Of tblSustituto) = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo _
                                Where x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                And x.idempresa = mdlPublicVars.idEmpresa And x.idSustitutoCategoria = categoriaSustituto And x.idarticulo <> articulo _
                                Select x).ToList
                Dim arti As New tblSustituto
                For Each arti In sustitutos
                    Dim fila As String()
                    fila = {arti.idSustituto, arti.idarticulo, arti.tblArticulo.codigo1, arti.tblArticulo.codigo2, arti.tblArticulo.nombre1, arti.tblArticulo.nombre2, "0", arti.tblArticulo.tblArticuloMarcaRepuesto.nombre}
                    Me.grdSustitutos.Rows.Add(fila)
                Next

            Else
                Me.grdSustitutos.DataSource = Nothing

            End If

        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar el grid con los detalles de kit
    Private Sub fnLlenarGridKit()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigoArt As Integer = CInt(txtCodigo.Text)
            Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = codigoArt Select x).ToList
            Dim idArticuloUnidadMedida As Integer
            Dim unidadmedida As String
            Dim unidadesmedida As Decimal

            For Each detalle As tblArticulo_Kit In lDetalleKit
                Dim fila As String()

                If IsNothing(detalle.idArticulo_UnidadMedida) Then
                    idArticuloUnidadMedida = Nothing
                    unidadmedida = "Unidad"
                    unidadesmedida = 1.0
                Else
                    idArticuloUnidadMedida = detalle.idArticulo_UnidadMedida
                    unidadmedida = detalle.tblArticulo_UnidadMedida.tblUnidadMedida.nombre
                    unidadesmedida = detalle.tblArticulo_UnidadMedida.valor
                End If


                'iddetalle,id,codigo1,nombre1,nombre2,elimina,marca,cantidad
                fila = {detalle.codigo, detalle.tblArticulo1.idArticulo, detalle.tblArticulo1.codigo1, detalle.tblArticulo1.nombre1,
                        "0", detalle.tblArticulo1.tblArticuloMarcaRepuesto.nombre, Format(detalle.cantidad, mdlPublicVars.formatoNumero), Format(detalle.tblArticulo1.costoIVA * unidadesmedida, mdlPublicVars.formatoNumero), idArticuloUnidadMedida, unidadmedida, Format(unidadesmedida, mdlPublicVars.formatoNumero)}
                Me.grdKit.Rows.Add(fila)

            Next

            conn.Close()
        End Using

    End Sub

    'Funcion utilizada para guardar sustitutos
    Public Sub fnGuardaSustitutos()
        Dim id As Integer = CType(txtCodigo.Text, Integer)

        Dim categoria = (From x In ctx.tblSustitutoes _
                       Where x.idarticulo = id And x.idempresa = mdlPublicVars.idEmpresa And x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                       And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                       Select x)

        Dim contador As Integer = 0
        Dim valor As New tblSustituto
        For Each valor In categoria
            contador = contador + 1
        Next

        If contador > 0 Then
            Dim idCategoria As Integer = CType(valor.idSustitutoCategoria, Integer)
            'Eliminamos toda la categoria de sustitutos anteriores
            Dim listaSustitutos As List(Of tblSustituto) = (From x In ctx.tblSustitutoes Where x.idSustitutoCategoria = idCategoria Select x).ToList
            Dim sust As New tblSustituto
            For Each sust In listaSustitutos
                ctx.DeleteObject(sust)
                ctx.SaveChanges()
            Next
        End If

        'Si el grid de sustitutos es mayor a cero
        If Me.grdSustitutos.RowCount > 0 Then
            Dim sustitutos As Integer = 0
            For i As Integer = 0 To Me.grdSustitutos.RowCount - 1
                If Me.grdSustitutos.Rows(i).IsVisible = True Then
                    sustitutos += 1
                End If
            Next

            If sustitutos >= 1 Then

                'Si sustitutos es mayor o igual 1, se crean los sustitutos
                'Creamos la nueva categoria de sutitutos
                Dim categoriaNueva As New tblSustitutoCategoria
                ctx.AddTotblSustitutoCategorias(categoriaNueva)
                ctx.SaveChanges()
                Dim cat As Integer = CType(categoriaNueva.idSustitutoCategoria, Integer)

                'Guardamos el articulo base
                Dim sustitutoBase As New tblSustituto
                sustitutoBase.idarticulo = id
                sustitutoBase.idSustitutoCategoria = cat
                sustitutoBase.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                sustitutoBase.idempresa = mdlPublicVars.idEmpresa
                sustitutoBase.idTipoInventario = mdlPublicVars.General_idTipoInventario
                ctx.AddTotblSustitutoes(sustitutoBase)
                ctx.SaveChanges()
                'Guardamos todos los sutitutos
                Dim elimina As Integer = 0
                For contador = 0 To Me.grdSustitutos.Rows.Count - 1
                    elimina = grdSustitutos.Rows(contador).Cells("elimina").Value

                    If elimina = 0 Then
                        Dim sustituto As New tblSustituto
                        Dim idArticulo As Integer = CType(Me.grdSustitutos.Rows(contador).Cells("id").Value, Integer)
                        sustituto.idarticulo = idArticulo
                        sustituto.idSustitutoCategoria = cat
                        sustituto.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                        sustituto.idempresa = mdlPublicVars.idEmpresa
                        sustituto.idTipoInventario = mdlPublicVars.General_idTipoInventario
                        ctx.AddTotblSustitutoes(sustituto)
                        ctx.SaveChanges()
                    End If
                Next
            End If
        End If
    End Sub

    'Funcion utilizada para guardar kit de un producto
    Public Sub fnGuardaKit()
        Dim codArt As Integer = CInt(txtCodigo.Text)

        'Guardamos todos los detalles de kit
        Dim elimina As Integer = 0
        Dim idDetalle As Integer = 0
        Dim idArticulo As Integer = 0
        Dim cantidad As Decimal = 0
        Dim codArticuloUnidadMedida As String
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        For index As Integer = 0 To Me.grdKit.Rows.Count - 1
            elimina = grdKit.Rows(index).Cells("elimina").Value
            idDetalle = grdKit.Rows(index).Cells("iddetalle").Value
            idArticulo = CType(Me.grdKit.Rows(index).Cells("id").Value, Integer)
            cantidad = CType(Me.grdKit.Rows(index).Cells("cantidad").Value, Decimal)
            codArticuloUnidadMedida = grdKit.Rows(index).Cells("codArticuloUnidadMedida").Value.ToString

            If elimina = 1 Then
                '-- Elimina el articulo del kit
                'Obtenemos el articulo de la lista
                Dim detalle As tblArticulo_Kit = (From x In ctx.tblArticulo_Kit Where x.codigo = idDetalle Select x).FirstOrDefault

                'Eliminamos el objeto del contexto
                ctx.DeleteObject(detalle)
                ctx.SaveChanges()
            ElseIf idDetalle > 0 Then
                '-- Modificamos el articulo del kit
                'Obtenemos el articulo para poder modificarlo
                Dim detalle As tblArticulo_Kit = (From x In ctx.tblArticulo_Kit Where x.codigo = idDetalle Select x).FirstOrDefault

                detalle.cantidad = cantidad
                detalle.idArticulo_UnidadMedida = codArticuloUnidadMedida
                ctx.SaveChanges()
            Else
                '-- Agregamos el articulo al kit

                'Creamos un nuevo objeto del tipo tblArticulo_Kit
                Dim articulo As New tblArticulo_Kit
                articulo.cantidad = cantidad
                articulo.articuloBase = codArt
                articulo.articulo = idArticulo
                articulo.fecha = fechaServer
                articulo.usuario = mdlPublicVars.idUsuario
                If codArticuloUnidadMedida > 0 Then
                    articulo.idArticulo_UnidadMedida = codArticuloUnidadMedida
                End If


                ctx.AddTotblArticulo_Kit(articulo)
                ctx.SaveChanges()
            End If
        Next
    End Sub

    Public Sub llenarGridInventarios()
        Dim id As Integer = txtCodigo.Text
        Me.grdInventarios.Rows.Clear()
        Try
            Dim inventario As List(Of tblTipoInventario) = (From x In ctx.tblTipoInventarios Select x).ToList

            Dim tipo As New tblTipoInventario
            For Each tipo In inventario
                Dim saldo As tblInventario = (From x In ctx.tblInventarios Where x.idTipoInventario = tipo.idTipoinventario And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                             And x.IdAlmacen = General_idAlmacenPrincipal And x.idArticulo = id Select x).FirstOrDefault

                Dim saldoInventario As Integer
                If saldo Is Nothing Then
                    saldoInventario = 0
                Else
                    saldoInventario = saldo.saldo
                End If
                Dim fila As String()
                fila = {tipo.idTipoinventario, tipo.nombre, saldoInventario}
                Me.grdInventarios.Rows.Add(fila)
            Next

        Catch ex As Exception

        End Try


    End Sub

    Public Sub fnPendienteSurtir()
        Dim codigo As Integer = txtCodigo.Text
        Dim pendiente = (From x In ctx.tblSurtirs Where x.articulo = codigo And x.saldo > 0 _
                                      Select x.cantidad).Sum
        Dim surtir As Integer
        If pendiente Is Nothing Then
            surtir = 0
        Else
            surtir = pendiente
        End If
        lblPendienteSurtir.Text = surtir
    End Sub

    Private Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label)

        Try
            Dim indice As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd)
            txtNombre1.Focus()
            txtNombre1.Select()

            Dim index
            Dim contador As Integer = 0
            Dim estado As Boolean
            For index = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells(0).Value
                If estado = True Then
                    contador = contador + 1
                End If

            Next
            lbl.Text = contador.ToString

            grd.Focus()
            'grd.Rows(indice).Cells(0).IsSelected = True
            'End If
        Catch ex As Exception
            alertas.contenido = ex.ToString
            alertas.fnErrorContenido()
        End Try

    End Sub

    'Funcion que verifica si el codigo del producto no existe aun
    Private Function fnVerificaCodigo(ByVal codigo As String) As Boolean
        Try
            'Realizamos la consulta
            Dim consulta As tblArticulo = (From x In ctx.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

            If consulta Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    Private Sub grdModeloVehiculo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdModeloVehiculo.ValueChanged
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)
    End Sub

    'Funcion que se utlizara para saber si todos los campos requeridos estan llenos
    Private Function fnRequeridos() As String
        'Variables que se utiliran para el control
        Dim errores As String = ""

        'Creamos el arreglo que contenera los errores
        Dim coleccion As New ArrayList
        Dim objeto As String = "Producto"

        'Verificamos que tenga nombre y codigo
        If txtNombre1.TextLength = 0 Then
            coleccion.Add("Nombre de " & objeto)
        End If

        If txtCodigo1.TextLength = 0 Then
            coleccion.Add("Codigo de " & objeto)
        End If

        If (cmbImportancia.Text.Length = 0) Then
            coleccion.Add("Importancia de " & objeto)
        End If

        If (cmbMarcaRepuesto.Text.Length = 0) Then
            coleccion.Add("Marca de " & objeto)
        End If

        If (cmbTipoRepuesto.Text.Length = 0) Then
            coleccion.Add("Tipo de " & objeto)
        End If

        If CInt(lblRecuentoModelo.Text) = 0 Then
            coleccion.Add("Agregar Modelo de Vehiculo de " & objeto)
        End If


        If CInt(lblRecuentoTipoVehiculo.Text) = 0 Then
            coleccion.Add("Agregar Tipo de Vehiculo de " & objeto)
        End If

        Dim cont
        For cont = 0 To coleccion.Count - 1
            errores += "Falta " & coleccion.Item(cont) & vbCrLf
        Next


        Return errores
    End Function

    Private Sub grdDirecciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFotos.SelectionChanged
        Try
            fnFoto()
        Catch ex As Exception

        End Try
    End Sub

    'Coloca la foto
    Private Sub fnFoto()
        Try

            'Seleccionamos la direccion
            Dim direccion As String = CType(Me.grdFotos.Rows(Me.grdFotos.CurrentRow.Index).Cells("direccion").Value, String)
            fnCargarFoto(pctFoto, direccion)
        Catch ex As Exception

        End Try
    End Sub

    'Maneja el evento de la tecla DELETE
    Private Sub grdFotos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdFotos.KeyDown
        If RadMessageBox.Show("¿Desea eliminar foto?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            mdlPublicVars.fnGrid_EliminarFila(sender, e, grdFotos, "codigo")
        End If
    End Sub

    'Despliega Combo
    Private Sub cmbTipoRepuesto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoRepuesto.KeyDown
        If e.KeyCode = Keys.F2 Then
            cmbTipoRepuesto.AllowDrop = True
            cmbTipoRepuesto.DroppedDown = True
        End If
    End Sub

    'Funcion utilizada para activar todos los elementos de un grid
    Private Sub fnActivaTodos(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal estado As Boolean)
        Try
            'Recorremos el grid
            Dim i
            For i = 0 To grd.Rows.Count - 1
                grd.Rows(i).Cells(0).Value = estado
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkTodosVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosVehiculo.CheckedChanged
        fnActivaTodos(grdTipoVehiculo, chkTodosVehiculo.Checked)
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(grdModeloVehiculo, chkTodosModelo.Checked)
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)
    End Sub

    'Funcion que se utiliza para llenar el grid de precios
    Private Sub fnLlenaPrecios()
        Try
            Me.grdPrecios.Rows.Clear()
            'Obtenemos los tipos de negocios
            Dim listaNegocios As List(Of tblClienteTipoNegocio) = (From x In ctx.tblClienteTipoNegocios Select x Order By x.porcentaje Descending).ToList
            Dim negocio As tblClienteTipoNegocio
            Dim idArt As Integer = CInt(txtCodigo.Text)
            For Each negocio In listaNegocios

                'Seleccionamos el el registro del articulo 
                Dim pArt As tblArticulo_TipoNegocio = (From x In ctx.tblArticulo_TipoNegocio _
                                                                 Where x.articulo = idArt And x.tipoNegocio = negocio.idTipoNegocio _
                                                                 Select x).FirstOrDefault
                'Creamos la fila
                Dim fila As Object() = Nothing
                If pArt IsNot Nothing Then
                    fila = {pArt.codigo, pArt.tblClienteTipoNegocio.nombre, pArt.tblClienteTipoNegocio.idTipoNegocio, _
                            Format(pArt.descuento / 100, mdlPublicVars.formatoPorcentaje), "", ""}
                Else
                    fila = {"0", negocio.idTipoNegocio, negocio.nombre, negocio.porcentaje, "", ""}
                End If

                'Agregamos la fila al grid
                Me.grdPrecios.Rows.Add(fila)
            Next


        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para calcular los precio Normales
    Private Sub fnCalculaNormales()
        Try
            'Verificamos si el grid tiene datos
            If Me.grdPrecios.Rows.Count > 0 Then
                'Obtenemos el precio publico y costo Promedio
                Dim pPub As Decimal = 0

                If IsNumeric(lblPrecioPublico.Text) Then
                    pPub = CDec(lblPrecioPublico.Text)
                End If

                Dim cProm As Decimal = CDec(lblCosto.Text)

                'Recorremos el grid
                Dim index
                For index = 0 To Me.grdPrecios.Rows.Count - 1
                    Dim desc As String = CType(Me.grdPrecios.Rows(index).Cells("txmDescuento").Value, String)
                    Dim descuento As Decimal = 0

                    If desc.Contains("%") Then
                        descuento = CType(desc.Substring(0, desc.LastIndexOf("%")), Decimal) / 100
                    Else
                        descuento = CType(desc, Decimal) / 100
                    End If


                    Dim pNor As Decimal = 0
                    Dim utili As Decimal = 0

                    'Realizamos las operaciones
                    pNor = pPub - (pPub * (descuento))
                    If pNor > 0 Then
                        utili = (1 - (cProm / pNor))
                    End If
                    'Modificamos el grid
                    Me.grdPrecios.Rows(index).Cells("precioNormal").Value = Format(pNor, mdlPublicVars.formatoMoneda)
                    Me.grdPrecios.Rows(index).Cells("utilidad").Value = Format(utili, mdlPublicVars.formatoPorcentaje)
                    Me.grdPrecios.Rows(index).Cells("txmDescuento").Value = Format(descuento, mdlPublicVars.formatoPorcentaje)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar el grid de otros precios
    Private Sub fnLlenaOtrosPrecios()
        Try
            Me.grdOtrosPrecios.Rows.Clear()
            'Obtenemos los otros precios
            Dim listaPrecio As List(Of tblArticuloTipoPrecio) = (ctx.tblArticuloTipoPrecios).ToList
            Dim precio As tblArticuloTipoPrecio
            Dim idArt As Integer = CInt(txtCodigo.Text)
            'Recorremos los precios
            For Each precio In listaPrecio
                'Seleccionamos el registro
                Dim pArt As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = idArt And x.tipoPrecio = precio.codigo _
                                                  Select x).FirstOrDefault

                'Creamos la fila
                Dim fila As Object() = Nothing
                If pArt IsNot Nothing Then
                    fila = {pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda)}
                Else

                    fila = {precio.codigo, precio.nombre, Format(0.0, mdlPublicVars.formatoMoneda)}
                End If
                'Agregamos la fila al grid
                Me.grdOtrosPrecios.Rows.Add(fila)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCosto.TextChanged
        fnLlenaPrecios()
        fnCalculaNormales()
        fnLlenaOtrosPrecios()
    End Sub

    Private Sub txtCodigo1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo1.Leave

        If NuevoIniciar Then
            'Verificamos si aun no existe el codigo
            If fnVerificaCodigo(txtCodigo1.Text) Then
                RadMessageBox.Show("El codigo " & txtCodigo1.Text & " ya existe !!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Question)
                txtCodigo1.Focus()

                If RadMessageBox.Show("Desea Habilitarlo?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.codigo1 = txtCodigo1.Text And x.empresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                        articulo.Habilitado = True

                        conexion.SaveChanges()

                        conn.Close()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub frmProducto_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not frmProductoLista.filtroActivo And idPendientePedir <= 0 Then
            If verRegistro = False Then
                frmProductoLista.frm_llenarLista()
            End If
        End If
    End Sub

    'Funcion utilizada para agregar un codigo de barras
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCodigoBarra.Click
        Try
            'Validamos que el codigo de barras no este vacio ni la unidad de empaque
            If txtEmpaque.Text = "" Then
                RadMessageBox.Show("Falta empaque", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            ElseIf Not IsNumeric(txtEmpaque.Text) Then
                RadMessageBox.Show("Debe de ingresar un numero como unidad de empaque", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                Dim codigo As String = txtCodigoBarra.Text
                Dim empaque As Integer = txtEmpaque.Text
                Dim codArt As Integer = txtCodigo.Text

                'Verificamos que el codigo de barra no exista aun
                Dim existe As tblArticulo_CodigoBarra = (From x In ctx.tblArticulo_CodigoBarra Where x.codigoBarra = codigo _
                                                         Select x).FirstOrDefault

                If existe Is Nothing Or codigo = "" Then
                    'Ingresamos el codigo de barra
                    Dim codigoBarra As New tblArticulo_CodigoBarra

                    codigoBarra.codigoBarra = codigo
                    codigoBarra.articulo = codArt
                    codigoBarra.unidadEmpaque = empaque

                    ctx.AddTotblArticulo_CodigoBarra(codigoBarra)
                    ctx.SaveChanges()

                    fnLlenaCodigosBarra(codArt)
                Else
                    alertas.contenido = "Ya existe un artículo registrado con ese código de barra"
                    alertas.fnErrorContenido()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para llenar el grid de codigos de barra
    Private Sub fnLlenaCodigosBarra(ByVal codArt As Integer)
        Try
            Me.grdCodigosBarra.Rows.Clear()
            'Obtenemos todos los codigo de barra
            Dim codigos As List(Of tblArticulo_CodigoBarra) = (From x In ctx.tblArticulo_CodigoBarra _
                                                               Where x.articulo = codArt _
                                                               Select x).ToList
            Dim cod As tblArticulo_CodigoBarra
            For Each cod In codigos
                grdCodigosBarra.Rows.Add(cod.codigo, cod.codigoBarra, cod.unidadEmpaque)
            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdCodigosBarra_UserDeletingRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles grdCodigosBarra.UserDeletingRow
        Try
            'Obtenemos el id del articulo
            Dim codArt As Integer = txtCodigo.Text
            If RadMessageBox.Show("Desea eliminar el registro?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                e.Cancel = True
            Else
                'Obtenemos el codigo d  el registro
                Dim codReg As Integer = Me.grdCodigosBarra.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdCodigosBarra)).Cells("id").Value

                'Obtenemos el registro de la BD
                Dim codigoBarra As tblArticulo_CodigoBarra = (From x In ctx.tblArticulo_CodigoBarra _
                                                              Where x.codigo = codReg _
                                                              Select x).FirstOrDefault

                ctx.DeleteObject(codigoBarra)
                ctx.SaveChanges()
            End If

            fnLlenaCodigosBarra(codArt)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdSustitutos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSustitutos.KeyDown
        mdlPublicVars.fnGrid_EliminarFila(sender, e, grdSustitutos, "iddetalle")
    End Sub

    'Funcion utilizada para verificar si se elimino un sustituto, por consecuente se debe guardar antes el articulo
    Private Function fnEliminoRegistro(ByRef grd As Telerik.WinControls.UI.RadGridView) As Boolean
        'Recorremos el grid para verificar si se elimino sustitutos
        Dim i As Integer = 0
        Dim elimina As Integer = 0

        For i = 0 To grd.Rows.Count - 1
            elimina = grd.Rows(i).Cells("elimina").Value
            If elimina = 1 Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub btnDetalleSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleSurtir.Click
        If Not txtCodigo.Text.Equals("") Then
            frmDetalleSurtirReserva.Text = "Detalle de Surtir"
            frmDetalleSurtirReserva.codigo = CInt(txtCodigo.Text)
            frmDetalleSurtirReserva.bitSurtir = True
            frmDetalleSurtirReserva.StartPosition = FormStartPosition.CenterScreen
            frmDetalleSurtirReserva.ShowDialog()
            frmDetalleSurtirReserva.Dispose()
        Else
            alertas.contenido = "Debe de guardar primero el producto"
            alertas.fnErrorContenido()
        End If

    End Sub

    Private Sub btnDetalleReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleReserva.Click
        If Not txtCodigo.Text.Equals("") Then
            frmDetalleSurtirReserva.Text = "Detalle de Reserva"
            frmDetalleSurtirReserva.codigo = CInt(txtCodigo.Text)
            frmDetalleSurtirReserva.bitReserva = True
            frmDetalleSurtirReserva.StartPosition = FormStartPosition.CenterScreen
            frmDetalleSurtirReserva.ShowDialog()
            frmDetalleSurtirReserva.Dispose()
        Else
            alertas.contenido = "Debe de guardar primero el producto"
            alertas.fnErrorContenido()
        End If
    End Sub

    Private Sub btnAgregarCatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCatalogo.Click
        If txtCodigo.Text.Equals("") Then
            Exit Sub
        End If

        Dim pagina As String = ""
        Try
            pagina = CStr(cmbPagina.SelectedValue)
        Catch ex As Exception
            pagina = ""
        End Try

        If Not pagina.Equals("") Then
            If txtImagen.Text.Equals("") Then
                RadMessageBox.Show("Debe de ingresar un numero de imagen", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                'Creamos el nuevo catalogo
                Dim catalogo As New tblArticulo_Catalogo
                catalogo.articulo = CInt(txtCodigo.Text)
                catalogo.imagen = pagina
                catalogo.numero = txtImagen.Text
                catalogo.observacion = txtObservacionCatalogo.Text

                'Agregamos el nuevo catalogo
                ctx.AddTotblArticulo_Catalogo(catalogo)
                ctx.SaveChanges()

                'Caragamos la lista nuevamente
                fnLlenarCatalogos(CInt(txtCodigo.Text))

                txtObservacionCatalogo.Text = ""
                txtImagen.Text = ""
            End If
        End If
    End Sub

    Private Sub grdCatalogos_UserDeletingRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles grdCatalogos.UserDeletingRow
        'Obtenemos el id del articulo
        Dim codArt As Integer = txtCodigo.Text
        If RadMessageBox.Show("Desea eliminar el registro?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            e.Cancel = True
        Else
            'Obtenemos el codigo d  el registro
            Dim codReg As Integer = Me.grdCatalogos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdCatalogos)).Cells("id").Value

            'Obtenemos el registro de la BD
            Dim codigoCatalogo As tblArticulo_Catalogo = (From x In ctx.tblArticulo_Catalogo _
                                                          Where x.codigo = codReg _
                                                          Select x).FirstOrDefault

            ctx.DeleteObject(codigoCatalogo)
            ctx.SaveChanges()
        End If

        fnLlenaCodigosBarra(codArt)
    End Sub

    Private Sub cmbCarpeta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCarpeta.SelectedValueChanged

        'Obtenemos las fotos del articulo
        Dim carpeta As String = CStr(cmbCarpeta.SelectedValue)

        'Obtenemos los archivos de las fotos
        If carpeta IsNot Nothing Then
            Dim fotos As New DataTable
            fotos.Columns.Add("Codigo")
            fotos.Columns.Add("Nombre")
            Dim archivos As String() = Directory.GetFiles(carpeta)
            Dim direccion As String()
            Dim imagen As String
            'Recorremos el arreglo con catalogos
            For i As Integer = 0 To UBound(archivos)
                direccion = Split(archivos(i), "\")
                imagen = direccion(UBound(direccion))
                fotos.Rows.Add(archivos(i), imagen.Substring(0, imagen.LastIndexOf(".")))
            Next

            With cmbPagina
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = fotos
            End With
        End If
    End Sub

    Private Sub cmbPagina_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPagina.SelectedValueChanged
        fnCargarFoto(pctCatalogo, CStr(cmbPagina.SelectedValue))
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If Not txtCodigo.Text.Equals("") Then
            'Posicion
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdCatalogos)

            frmBuscarArticuloFoto.Text = "Información Articulo"
            frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloFoto.codigo = CInt(txtCodigo.Text)
            frmBuscarArticuloFoto.bitVerFoto = True
            frmBuscarArticuloFoto.dirFoto = Me.grdCatalogos.Rows(fila).Cells("carpeta").Value
            permiso.PermisoDialogEspeciales(frmBuscarArticuloFoto)
        End If
    End Sub

    Private Sub btnVerCatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerCatalogo.Click
        If Not txtCodigo.Text.Equals("") Then
            'Posicion
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdCatalogos)

            frmBuscarArticuloFoto.Text = "Información Articulo"
            frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloFoto.codigo = CInt(txtCodigo.Text)
            frmBuscarArticuloFoto.bitVerFoto = True
            frmBuscarArticuloFoto.dirFoto = CStr(cmbPagina.SelectedValue)
            frmBuscarArticuloFoto.ShowDialog()
            frmBuscarArticuloFoto.Dispose()
        End If
    End Sub

    Private Sub btnVerFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerFoto.Click
        If Not txtCodigo.Text.Equals("") Then
            'Posicion
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdCatalogos)

            frmBuscarArticuloFoto.Text = "Información Articulo"
            frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloFoto.codigo = CInt(txtCodigo.Text)
            frmBuscarArticuloFoto.bitVerFoto = True
            frmBuscarArticuloFoto.dirFoto = Me.grdFotos.Rows(Me.grdFotos.CurrentRow.Index).Cells("direccion").Value
            frmBuscarArticuloFoto.ShowDialog()
            frmBuscarArticuloFoto.Dispose()
        End If
    End Sub

    Private Sub btnCapturarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapturarFoto.Click
        If Not txtCodigo.Text.Equals("") Then
            frmCapturarFoto.Text = "Imagen: Producto"
            frmCapturarFoto.bitProducto = True
            frmCapturarFoto.codigo = CInt(txtCodigo.Text)
            frmCapturarFoto.StartPosition = FormStartPosition.CenterScreen
            frmCapturarFoto.ShowDialog()
            frmCapturarFoto.Dispose()
        End If
    End Sub

    Private Sub grdDirecciones_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdFotos.UserAddedRow
        If grdFotos.RowCount > 0 Then
            fnFoto()
        End If
    End Sub

    Private Sub chkKit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKit.CheckedChanged
        If chkKit.Checked Then
            chkServicio.Checked = False
            chkProducto.Checked = False
            chkUnidadMedida.Checked = False
            btnAgregarKit.Enabled = True
            btnAgregarSustituto.Enabled = False
            pgUnidadMedida.Enabled = False
        Else
            btnAgregarKit.Enabled = False
            btnAgregarSustituto.Enabled = True
        End If
    End Sub

    ''LA VALIDACION DE SI ES UNIDAD DE MEDIDA O NO
    Private Sub chkUnidadMedida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnidadMedida.CheckedChanged
        If chkUnidadMedida.Checked Then
            chkServicio.Checked = False
            chkKit.Checked = False
            chkProducto.Checked = False
            pgUnidadMedida.Enabled = True
        Else
            pgUnidadMedida.Enabled = False
        End If
    End Sub

    Private Sub chkProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProducto.CheckedChanged
        If chkProducto.Checked Then
            chkServicio.Checked = False
            chkUnidadMedida.Checked = False
            chkKit.Checked = False
            pgUnidadMedida.Enabled = False
        End If
    End Sub

    Private Sub chkServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkServicio.CheckedChanged
        If chkServicio.Checked Then
            chkKit.Checked = False
            chkProducto.Checked = False
            chkUnidadMedida.Checked = False
            pgUnidadMedida.Enabled = False
        End If
    End Sub

    Private Sub btnAgregarKit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarKit.Click
        If IsNumeric(txtCodigo.Text) Then
            If fnEliminoRegistro(grdKit) = True Then
                alertas.contenido = "Debe guardar los cambios antes"
                alertas.fnErrorContenido()
            Else
                frmKit.grdBase = Me.grdKit
                frmKit.base2 = txtCodigo.Text
                frmKit.filtro = ""
                frmKit.Text = "Agregar a Kit"
                frmKit.StartPosition = FormStartPosition.CenterScreen
                frmKit.ShowDialog()
                frmKit.Dispose()

                'Calculamos el costo de este kit y se lo asignamos a la etiqueta
                lblCostoKit.Text = Format(fnCostoKit, mdlPublicVars.formatoMoneda)

            End If
        Else
            alertas.contenido = "Debe de guardar primero el articulo"
            alertas.fnErrorContenido()
        End If
    End Sub

    'Funcion utilizada para obtener el costo de este kit
    Private Function fnCostoKit() As Decimal

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            fnCostoKit = 0
            'Recorremos el grid
            Dim idArticulo As Integer = 0
            Dim cantidad As Decimal = 0
            For i As Integer = 0 To Me.grdKit.RowCount - 1
                idArticulo = Me.grdKit.Rows(i).Cells("id").Value
                cantidad = Me.grdKit.Rows(i).Cells("cantidad").Value

                'Obtenemos la informacion del articulo
                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = idArticulo Select x).FirstOrDefault
                fnCostoKit += articulo.costoIVA * cantidad
            Next

            conn.Close()
        End Using

    End Function

    Private Function fnGuardarKit() As Boolean
        Dim codArt As Integer = CInt(txtCodigo.Text)
        Dim errores As Boolean = False

        Dim m As New tblArticulo
        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope
            Try
                Dim elimina As Integer = 0
                Dim idDetalle As Integer = 0
                Dim idArticulo As Integer = 0
                Dim cantidad As Double = 0
                Dim fechaServer As DateTime = Today
                Dim codArticuloUnidadMedida As String = ""

                For index As Integer = 0 To Me.grdKit.Rows.Count - 1
                    elimina = grdKit.Rows(index).Cells("elimina").Value
                    idDetalle = grdKit.Rows(index).Cells("iddetalle").Value
                    idArticulo = CType(Me.grdKit.Rows(index).Cells("id").Value, Integer)
                    cantidad = CDbl(grdKit.Rows(index).Cells("cantidad").Value)
                    codArticuloUnidadMedida = grdKit.Rows(index).Cells("codArticuloUnidadMedida").Value.ToString
                    Dim akit As tblArticulo_Kit = (From x In ctx.tblArticulo_Kit Where x.codigo = idDetalle Select x).FirstOrDefault
                    Dim ikit As New tblArticulo_Kit

                    If elimina = 1 Then
                        ctx.DeleteObject(akit)
                        ctx.SaveChanges()
                        ''ElseIf idDetalle > 0 Then
                        ''    If codArticuloUnidadMedida.Length > 0 And codArticuloUnidadMedidad <> "0" Then
                        ''        mkit.cantidad = cantidad
                        ''        mkit.idArticulo_UnidadMedidad = codArticuloUnidadMedida
                        ''    Else
                        ''        mkit.cantidad = cantidad
                        ''        mkit.idArticulo_UnidadMedida = Null
                        ''    End If
                        ''ctx.SaveChanges()
                    Else
                        ''Agregamos el articulo al kit
                        ''If codArticuloUnidadMedidad = 0 Then
                        ''    codArticuloUnidadMedidad = "Null"
                        ''Else
                        ''    codArticuloUnidadMedida = "" & codArticuloUnidadMedida & ""
                        ''End If

                        ikit.cantidad = cantidad
                        ikit.articuloBase = codArt
                        ikit.articulo = idArticulo
                        ikit.fecha = fechaSQL(fechaServer)
                        ikit.usuario = mdlPublicVars.idUsuario
                        ikit.idArticulo_UnidadMedida = codArticuloUnidadMedida

                    End If
                    ctx.AddTotblArticulo_Kit(ikit)
                    ctx.SaveChanges()

                Next

            Catch ex As Exception
                errores = True
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End Using

        If Not errores Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub grdKit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdKit.KeyDown
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdKit)
        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea Eliminar el Producto del Kit?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdKit, "iddetalle")
                RadMessageBox.Show("Se ah eliminado el Producto!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("El Registro no se ah Eliminado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        End If
        lblCostoKit.Text = Format(fnCostoKit, mdlPublicVars.formatoMoneda)
    End Sub

    Private Sub fnllenarUnidadMedida()
        If IsNumeric(txtCodigo.Text) Then
            Try
                Dim codigoArt As Integer = CInt(txtCodigo.Text)

            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAgregarMedida_Click(sender As Object, e As EventArgs) Handles btnAgregarMedida.Click

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If fn_recorre_grid() = True And chkDefault.Checked = True Then
                RadMessageBox.Show("Ya Existe una Unidad Medida Base", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If

            If IsNumeric(txtCodigo.Text) Then
                If nm2PrecioMedida.Value < 0 Then
                    RadMessageBox.Show("Debe agregar un precio", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                If nm5Valor.Value <= 0 Then
                    RadMessageBox.Show("Debe agregar un Valor", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                If CInt(cmbUnidadMedida.SelectedValue) <= 0 Then
                    RadMessageBox.Show("Debe elegir una Unidad", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                Dim codiarti As Integer = CType(txtCodigo.Text, Integer)
                Dim idunimedi As Integer = CType(cmbUnidadMedida.SelectedValue, Integer)

                ''Verificamos si existe unidad de medida
                Dim conteo As Integer = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = codiarti And x.idUnidadMedida = idunimedi Select x.idArticulo).Count

                If conteo = 0 Then
                    If RadMessageBox.Show("¿Desea Agregar Unidad de Medida?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Dim fila As Object()
                        Dim costo As Decimal
                        Try
                            costo = (From x In conexion.tblArticuloes Where x.idArticulo = txtCodigo.Text Select x.costoIVA).FirstOrDefault
                        Catch ex As Exception
                            costo = 0
                        End Try

                        Dim defal As Boolean = False

                        If chkDefault.Enabled = True Then
                            defal = chkDefault.Checked
                        Else
                            defal = False
                        End If

                        fila = {"0", CInt(cmbUnidadMedida.SelectedValue), cmbUnidadMedida.Text, Format(nm5Valor.Value, mdlPublicVars.formatoNumero), Format((costo * nm5Valor.Value), mdlPublicVars.formatoNumero), Format(nm2PrecioMedida.Value, mdlPublicVars.formatoNumero), defal, "0", False}
                        Me.grdUnidadMedida.Rows.Add(fila)

                        nm5Valor.Value = 0
                        nm2PrecioMedida.Value = 0
                        ''fnverificarunidades()
                    End If
                Else
                    RadMessageBox.Show("Ya Existe un Registro con la Unidad de Medida Seleccionada ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If
            Else
                alertas.contenido = "Debe de Guardar Primero el Articulo"
                alertas.fnErrorContenido()
            End If

            chkDefault.Checked = False

            If fn_recorre_grid() = True Then
                chkDefault.Enabled = False
            Else
                chkDefault.Enabled = True
            End If

            conn.Close()
        End Using

    End Sub

    Private Function fn_recorre_grid()

        Dim filas As Integer = Me.grdUnidadMedida.Rows.Count - 1
        Dim encontrado As Boolean = False

        For index As Integer = 0 To filas
            encontrado = Me.grdUnidadMedida.Rows(index).Cells(6).Value

            If encontrado = True Then
                Exit For
            End If
        Next

        If encontrado = True Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function

    Private Function fnVerificarKitUnidadMedida(ByVal iddetalle As Integer) As Boolean

        Try

            ''Dim conexion As dsi_pos_demoEntities
            ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            ''    conn.Open()
            ''    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            ''Verificar si el Kit tiene asignada la unidad de medida a eliminar

            Dim cont = (From x In ctx.tblArticulo_Kit Where x.idArticulo_UnidadMedida = iddetalle Select x).Count

            If cont > 0 Then

                Dim detallekit As List(Of tblArticulo_Kit) = (From x In ctx.tblArticulo_Kit Where x.idArticulo_UnidadMedida = iddetalle Select x).ToList
                For Each detalle As tblArticulo_Kit In detallekit
                    Dim fila As String()
                    ''iddetalle,idunidadmedidad,descripcion,valor,costo,precio,default,elimina,kit
                    ''fila = {detalle.idArticulo_UnidadMedida, detalle.idUnidadMedida, detalle.tblUnidadMedida.nombre, Format(detalle.valor, mdlPublicVars.formatoNumero), Format(CType((detalle.tblArticulo.costoIVA * detalle.valor), Decimal), mdlPublicVars.formatoNumero), Format(detalle.precio, mdlPublicVars.formatoNumero), detalle.bitDefault, "0", detalle.kit}
                    ''Me.grdUnidadMedida.Rows.Add(fila)

                    Dim borrar = (From x In ctx.tblArticulo_Kit Where x.codigo = detalle.codigo Select x).FirstOrDefault

                    ctx.DeleteObject(borrar)
                    ctx.SaveChanges()
                Next
                Return True
            Else
                Return True
            End If

            ''conn.Close()
            ''End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function fnGuardarUnidadesMedida() As Boolean

        '' ''Verificamos que no falten los campos requeridos
        ''If fnRequeridos.Length > 0 Then
        ''    alertas.contenido = fnRequeridos()
        ''    alertas.fnErrorContenido()
        ''    Exit Sub
        ''End If

        '' ''Verificamos que aun no exista el codigo
        ''If fnVerificaCodigo(txtCodigo1.Text) = True Then
        ''    RadMessageBox.Show("El codigo" & txtCodigo1.Text & " ya existe!!!", nombreSistema)
        ''    Exit Sub
        ''End If

        Dim codArt As Integer = CInt(txtCodigo.Text)

        Dim codigoarticulo As String = ""
        Dim codigo As Integer = 0
        Dim success As Boolean = True
        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim m As New tblArticulo
        ''Crear encabezado de la transaccion

        If fn_recorre_grid() = False And chkUnidadMedida.Checked = True Then
            RadMessageBox.Show("Debe de Asignar una Unidad Medida Base", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Function
            Return False
        End If

        ''inicio de la excepcion
        Try
            Dim elimina As Integer = 0
            Dim iddetalle As Integer = 0
            Dim idunidadmedidad As Integer = 0
            Dim precio As Decimal = 0
            Dim valor As Decimal = 0
            Dim bitkit As Integer = 0
            Dim fechaServer As DateTime = Today
            Dim bitDefault As Boolean = False

            For index As Integer = 0 To Me.grdUnidadMedida.Rows.Count - 1
                elimina = grdUnidadMedida.Rows(index).Cells("elimina").Value
                iddetalle = grdUnidadMedida.Rows(index).Cells("iddetalle").Value
                idunidadmedidad = grdUnidadMedida.Rows(index).Cells("idUnidadMedida").Value
                precio = grdUnidadMedida.Rows(index).Cells("precio").Value
                valor = grdUnidadMedida.Rows(index).Cells("valor").Value
                bitDefault = grdUnidadMedida.Rows(index).Cells("default").Value

                If CType(grdUnidadMedida.Rows(index).Cells("Kit").Value, Boolean) = True Then
                    bitkit = 1
                Else
                    bitkit = 0
                End If

                If elimina > 0 Then
                    ''Eliminamos el articulo del kit
                    ''obtenemos el aritculo de la lista
                    Dim val As Boolean = False
                    val = fnVerificarKitUnidadMedida(iddetalle)

                    If val = True Then
                        Dim detalle As tblArticulo_UnidadMedida = (From x In ctx.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = iddetalle Select x).FirstOrDefault

                        ''eliminamos el objeto del contexto
                        ctx.DeleteObject(detalle)
                        ctx.SaveChanges()
                    Else
                        RadMessageBox.Show("No se pudo eliminar la unidad de medida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Return False
                        Exit Function
                    End If

                ElseIf iddetalle > 0 Then
                    ''Modificamos el articulo del kit
                    ''obtenemos el articulo par apoder modificarlo
                    Dim detalle As tblArticulo_UnidadMedida = (From x In ctx.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = iddetalle Select x).FirstOrDefault

                    detalle.valor = valor
                    detalle.precio = precio
                    detalle.kit = bitkit

                    ctx.SaveChanges()
                Else
                    Dim crear As New tblArticulo_UnidadMedida

                    crear.idArticulo = codArt
                    crear.idUnidadMedida = idunidadmedidad
                    crear.valor = valor
                    crear.precio = precio
                    crear.bitDefault = If(bitDefault, 1, 0).ToString
                    crear.kit = bitkit

                    ctx.AddTotblArticulo_UnidadMedida(crear)
                    ctx.SaveChanges()

                End If
            Next

            If cmxKit.SelectedValue = 0 Then
                Dim modif As tblArticulo_UnidadMedida = (From x In ctx.tblArticulo_UnidadMedida Where x.idArticulo = codArt Select x).FirstOrDefault

                If modif Is Nothing Then

                Else
                    modif.kit = 0
                    ctx.SaveChanges()
                End If
            End If
            Return True
        Catch ex As Exception
            success = False
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try
    End Function

    Private Sub fnLlenarGridUnidadMedida()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codArt As Integer = CInt(txtCodigo.Text)
            Dim lDetalleUnidad As List(Of tblArticulo_UnidadMedida) = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = codArt Select x).ToList
            For Each detalle As tblArticulo_UnidadMedida In lDetalleUnidad
                Dim fila As String()
                ''iddetalle,idunidadmedidad,descripcion,valor,costo,precio,default,elimina,kit
                fila = {detalle.idArticulo_UnidadMedida, detalle.idUnidadMedida, detalle.tblUnidadMedida.nombre, Format(detalle.valor, mdlPublicVars.formatoNumero), Format(CType((detalle.tblArticulo.costoIVA * detalle.valor), Decimal), mdlPublicVars.formatoNumero), Format(detalle.precio, mdlPublicVars.formatoNumero), detalle.bitDefault, "0", detalle.kit}
                Me.grdUnidadMedida.Rows.Add(fila)

            Next

            If fn_recorre_grid() = True Then
                chkDefault.Enabled = False
            Else
                chkDefault.Enabled = True
            End If

            conn.Close()
        End Using

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim unidad As String = cmbUnidadMedida.Text
        Dim falla As Boolean = False
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim nomb As String
                nomb = Me.cmbUnidadMedida.Text
                Dim uni As New tblUnidadMedida
                Dim conteo As Integer = (From x In conexion.tblUnidadMedidas Where x.nombre = nomb Select x.idunidadMedida).Count
                If conteo = 0 Then
                    If RadMessageBox.Show("Desea Crear la Unidad de Medida", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        uni.nombre = unidad
                        conexion.AddTotblUnidadMedidas(uni)
                        conexion.SaveChanges()
                        fnLlenarComboUnidadMedida()
                    Else
                        Exit Sub
                    End If
                Else
                    RadMessageBox.Show("Unidad de Medida ya Existente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    falla = True
                End If
                conn.Close()
            End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

        If falla = False Then
            RadMessageBox.Show("Unidad Medida Creada Satisfactoriamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If


    End Sub

    Private Sub fnLlenarComboUnidadMedida()

        Dim conexion As New dsi_pos_demoEntities
        Using conn As New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim unidadMedida = From x In conexion.tblUnidadMedidas Select Codigo = x.idunidadMedida, Nombre = x.nombre Order By Nombre

            With Me.cmbUnidadMedida
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = unidadMedida
            End With

            conn.Close()
        End Using

    End Sub

    Private Sub grdUnidadMedida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdUnidadMedida.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea Eliminar la Unidad de Medida?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdUnidadMedida, "iddetalle")
                RadMessageBox.Show("Unidad de Medida Eliminada!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("No se ah Eliminado la Unidad de Medida", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        End If
    End Sub

    Private Sub pageDatos_Paint(sender As Object, e As PaintEventArgs) Handles pageDatos.Paint

    End Sub
End Class