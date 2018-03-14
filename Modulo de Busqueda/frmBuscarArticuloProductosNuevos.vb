﻿Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmBuscarArticuloProductosNuevos
    Dim permiso As New clsPermisoUsuario
    Dim _opcionRetorno As String
    Private _codClie As Integer
    Dim b As New clsBase

    Private _FiltroTipoVehiculo As String
    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean
    Private _venta As Integer

    'Dim _diferenciaTiempo As DateTime ' dias de diferencia

    Private cargo As Boolean

    Private _formSalida As frmSalidas

    Public Property venta As Integer
        Get
            venta = _venta
        End Get
        Set(ByVal value As Integer)
            _venta = value
        End Set
    End Property

    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitMovimientoInventario() As Boolean
        Get
            bitMovimientoInventario = _bitMovimientoInventario
        End Get
        Set(ByVal value As Boolean)
            _bitMovimientoInventario = value
        End Set
    End Property

    Public Property bitDevolucionCliente() As Boolean
        Get
            bitDevolucionCliente = _bitDevolucionCliente
        End Get
        Set(ByVal value As Boolean)
            _bitDevolucionCliente = value
        End Set
    End Property

    Public Property OpcionRetorno() As String
        Get
            OpcionRetorno = _opcionRetorno
        End Get
        Set(ByVal value As String)
            _opcionRetorno = value
        End Set
    End Property


    Public Property FiltroTipoVehiculo() As String
        Get
            FiltroTipoVehiculo = _FiltroTipoVehiculo
        End Get
        Set(ByVal value As String)
            _FiltroTipoVehiculo = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property

    Private Sub frmBuscarArticuloProductosNuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdProductos.ImageList = frmControles.ImageListAdministracion
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoVehiculo)
            mdlPublicVars.fnGrid_iconos(grdTipoVehiculo)
            mdlPublicVars.fnFormatoGridMovimientos(grdProductos2)
            lblGrid1.Text = ProductoGrid1
            fnLllenarcombo()
            cargo = True
            fnLlenar_productos()
            mdlPublicVars.fnGrid_iconos(Me.grdProductos)
            mdlPublicVars.fnGrid_iconos(Me.grdProductos2)
            fnConfigurarSumarios()
                      
            mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")

        Catch ex As Exception

        End Try
    End Sub


    'Llenar combo
    Private Sub fnLllenarcombo()

        Try

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim datos = (From x In conexion.tblListaFiltroFechas Where x.bitBusqueda = True Select x.orden, codigo = x.dias, x.nombre
                             Order By orden Ascending)
                With cmbTiempo
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = datos
                End With


                If bitCliente = True Or bitMovimientoInventario = True Then
                    Me.grdTipoVehiculo.Rows.Clear()
                    'tipo de vehiculo con grid
                    Dim tp = (From x In conexion.tblArticuloTipoVehiculoes Order By x.nombre _
                             Select Agregar = If(((From y In conexion.tblCliente_clasificacionCompra _
                                        Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
                                        Select y.codigo).FirstOrDefault) > 0, True, False), _
                                        IdDetalle = (From y In conexion.tblCliente_clasificacionCompra _
                                        Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
                                        Select y.codigo).FirstOrDefault,
                                       Codigo = x.codigo, Nombre = x.nombre)

                    Me.grdTipoVehiculo.Rows.Clear()
                    Dim cont As Integer = 0
                    Dim verd As Integer = 0
                    Dim v
                    For Each v In tp
                        cont += 1
                        Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
                        If v.AGREGAR = False Then
                            verd += 1
                        End If
                    Next
                End If

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Private Sub fnConfigurarSumarios()

        'Activar barra de totales y crear operaciones.
        grdProductos.MasterTemplate.ShowTotals = True
        grdProductos2.MasterTemplate.ShowTotals = True

        Dim SCodigo As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)

        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {SCodigo})

        'agregar summario arreglo a grid
        grdProductos.SummaryRowsTop.Add(summaryRowItem)

        grdProductos2.SummaryRowsTop.Add(summaryRowItem)

    End Sub

    Private Sub fnLlenar_productos()
        Try
            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
            Dim fechaFiltro As DateTime = fechaActual.AddDays(-cmbTiempo.SelectedValue)
            Dim fecha As String = Format(fechaFiltro, "dd/MM/yyyy hh:mm:ss")

            Me.grdProductos.DataSource = Nothing

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'productos nuevos general
                Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
                Dim cons = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fecha.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", codClie, 4, True, False, "", venta)
                grdProductos.DataSource = cons

                Me.grdProductos2.DataSource = Nothing
                'consulta nuevos no comprados
                Dim cons1 = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fecha.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", codClie, 9, True, False, "", venta)
                grdProductos2.DataSource = cons1

                conn.Close()
            End Using

            fnConfiguracion()
        Catch ex As Exception

            grdProductos.DataSource = Nothing
        End Try
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            Me.grdProductos.Columns(1).IsVisible = False 'id
            Me.grdProductos.Columns(11).IsVisible = False 'observacion
            Me.grdProductos.Columns(12).IsVisible = False 'empaque
            Me.grdProductos.Columns(14).IsVisible = False 'clrEstado
            Me.grdProductos.Columns(15).IsVisible = False 'numero de articulo en catalogo
            Me.grdProductos.Columns(16).IsVisible = False 'fecha ultima compra
            Me.grdProductos.Columns(17).IsVisible = False 'marca
            Me.grdProductos.Columns(18).IsVisible = False 'bitVentaMaxima
            Me.grdProductos.Columns(19).IsVisible = False 'minimo
            Me.grdProductos.Columns("TipoPrecio").IsVisible = False 'minimo
            Me.grdProductos.Columns("Compatibilidad").IsVisible = False 'compatibilidad
            Me.grdProductos.Columns("UbicacionEstanteria").IsVisible = False 'Ubicacion Estanteria

            Me.grdProductos.Columns(0).Width = 60 ' agregar
            Me.grdProductos.Columns(2).Width = 70 ' codigo
            Me.grdProductos.Columns(3).Width = 180 ' nombre
            Me.grdProductos.Columns(4).Width = 70 ' cantidad
            Me.grdProductos.Columns(5).Width = 70 ' existencia
            Me.grdProductos.Columns(6).Width = 70 ' reserva
            Me.grdProductos.Columns(7).Width = 70 ' transito
            Me.grdProductos.Columns(8).Width = 50 ' costo
            Me.grdProductos.Columns(9).Width = 70 ' precio
            Me.grdProductos.Columns(10).Width = 70 ' cantidadmax
            Me.grdProductos.Columns(11).Width = 50 ' observacion
            Me.grdProductos.Columns(12).Width = 60 'unidadempaque
            Me.grdProductos.Columns(13).Width = 70 'surtir

            Me.grdProductos.Columns(0).ReadOnly = False
            Me.grdProductos.Columns(1).ReadOnly = True
            Me.grdProductos.Columns(2).ReadOnly = True
            Me.grdProductos.Columns(3).ReadOnly = True
            Me.grdProductos.Columns(4).ReadOnly = False
            Me.grdProductos.Columns(5).ReadOnly = True
            Me.grdProductos.Columns(6).ReadOnly = True
            Me.grdProductos.Columns(7).ReadOnly = True
            Me.grdProductos.Columns(8).ReadOnly = False
            Me.grdProductos.Columns(9).ReadOnly = True
            Me.grdProductos.Columns(10).ReadOnly = True
            Me.grdProductos.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txmCosto")
            grdProductos.Columns("txbPrecio").HeaderText = "Precio"


            If bitCliente = True Or bitDevolucionCliente = True Then
                Me.grdProductos.Columns("txmCosto").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = True
                Me.grdProductos.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
                Me.grdProductos.Columns("Reserva").IsVisible = False
                Me.grdProductos.Columns("clrEstado").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = False
                Me.grdProductos.Columns("txmSurtir").IsVisible = False
                Me.grdProductos.Columns("CantidadMax").IsVisible = False
                Me.grdProductos.Columns.Move(8, 5)

            ElseIf OpcionRetorno = "consulta" Then
                Me.grdProductos.Columns("txmCosto").IsVisible = False
                Me.grdProductos.Columns("clrEstado").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = False
            End If



            'grid no comprados
            Me.grdProductos2.Columns(1).IsVisible = False 'id
            Me.grdProductos2.Columns(11).IsVisible = False 'observacion
            Me.grdProductos2.Columns(12).IsVisible = False 'empaque
            Me.grdProductos2.Columns(14).IsVisible = False 'clrEstado
            Me.grdProductos2.Columns(15).IsVisible = False 'numero de articulo en catalogo
            Me.grdProductos2.Columns(16).IsVisible = False 'fecha ultima compra
            Me.grdProductos2.Columns(17).IsVisible = False 'marca
            Me.grdProductos2.Columns(18).IsVisible = False 'bitVentaMaxima
            Me.grdProductos2.Columns(19).IsVisible = False 'minimo
            Me.grdProductos2.Columns("TipoPrecio").IsVisible = False 'minimo
            Me.grdProductos2.Columns("Compatibilidad").IsVisible = False 'compatibilidad
            Me.grdProductos2.Columns("UbicacionEstanteria").IsVisible = False 'Ubicacion Estanteria

            Me.grdProductos2.Columns(0).Width = 60 ' agregar
            Me.grdProductos2.Columns(2).Width = 70 ' codigo
            Me.grdProductos2.Columns(3).Width = 180 ' nombre
            Me.grdProductos2.Columns(4).Width = 70 ' cantidad
            Me.grdProductos2.Columns(5).Width = 70 ' existencia
            Me.grdProductos2.Columns(6).Width = 70 ' reserva
            Me.grdProductos2.Columns(7).Width = 70 ' transito
            Me.grdProductos2.Columns(8).Width = 50 ' costo
            Me.grdProductos2.Columns(9).Width = 70 ' precio
            Me.grdProductos2.Columns(10).Width = 70 ' cantidadmax
            Me.grdProductos2.Columns(11).Width = 50 ' observacion
            Me.grdProductos2.Columns(12).Width = 60 'unidadempaque
            Me.grdProductos2.Columns(13).Width = 70 'surtir

            Me.grdProductos2.Columns(0).ReadOnly = False
            Me.grdProductos2.Columns(1).ReadOnly = True
            Me.grdProductos2.Columns(2).ReadOnly = True
            Me.grdProductos2.Columns(3).ReadOnly = True
            Me.grdProductos2.Columns(4).ReadOnly = False
            Me.grdProductos2.Columns(5).ReadOnly = True
            Me.grdProductos2.Columns(6).ReadOnly = True
            Me.grdProductos2.Columns(7).ReadOnly = True
            Me.grdProductos2.Columns(8).ReadOnly = False
            Me.grdProductos2.Columns(9).ReadOnly = True
            Me.grdProductos2.Columns(10).ReadOnly = True
            Me.grdProductos2.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos2, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos2, "txmCosto")
            grdProductos2.Columns("txbPrecio").HeaderText = "Precio"


            If bitCliente = True Or bitDevolucionCliente = True Then
                Me.grdProductos2.Columns("txmCosto").IsVisible = False
                Me.grdProductos2.Columns("txbPrecio").IsVisible = True
                Me.grdProductos2.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
                Me.grdProductos2.Columns("Reserva").IsVisible = False
                Me.grdProductos2.Columns("clrEstado").IsVisible = False
                Me.grdProductos2.Columns("txbPrecio").IsVisible = False
                Me.grdProductos2.Columns("txmSurtir").IsVisible = False
                Me.grdProductos2.Columns("CantidadMax").IsVisible = False
                Me.grdProductos2.Columns.Move(8, 5)

            ElseIf OpcionRetorno = "consulta" Then
                Me.grdProductos2.Columns("txmCosto").IsVisible = False
                Me.grdProductos2.Columns("clrEstado").IsVisible = False
                Me.grdProductos2.Columns("txbPrecio").IsVisible = False
            End If

            mdlPublicVars.fnGrid_iconos(grdProductos)
            mdlPublicVars.fnGrid_iconos(grdProductos2)

        Catch ex As Exception
        End Try
    End Sub

    'Funcion que se utiliza para agregar los productos en el grid 
    Private Sub fnAgregar_Productos(ByRef grd As Telerik.WinControls.UI.RadGridView)
        Dim index As Integer
        Dim cont As Integer = 0
        Dim id As Integer = 0
        Dim cantidad As Integer = 0
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim precio As Decimal = 0
        Dim costo As Decimal = 0
        Dim surtir As Integer = 0
        Dim tipoPrecio As Integer = 0
        Dim estado As Integer = 0
        mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario

        If bitCliente = True Then
            If mdlPublicVars.superSearchInventario <> formSalida.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To grd.Rows.Count - 1
            'agrega = CType(grd.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then

            If grd.Rows(index).Cells("txmCantidad").Value.ToString.Length > 0 Then
                cantidad = grd.Rows(index).Cells("txmCantidad").Value
                surtir = grd.Rows(index).Cells("txmSurtir").Value

                If cantidad > 0 Or surtir > 0 Then
                    cont += 1
                    If cont = 1 Then
                        If bitCliente = True Then
                            formSalida.fnRemoverFila()
                        ElseIf bitProveedor = True Then
                            frmEntrada.fnRemoverFila()
                        ElseIf bitMovimientoInventario = True Then
                            frmMovimientoInventarios.fnRemoverFila()
                        ElseIf bitDevolucionCliente = True Then
                            frmClienteDevolucion.fnRemoverFila()
                        End If
                    End If

                    id = grd.Rows(index).Cells(1).Value
                    codigo = grd.Rows(index).Cells(2).Value
                    nombre = grd.Rows(index).Cells(3).Value
                    tipoPrecio = grd.Rows(index).Cells("TipoPrecio").Value
                    estado = grd.Rows(index).Cells("clrEstado").Value
                    Try
                        precio = grd.Rows(index).Cells("txbPrecio").Value
                    Catch ex As Exception
                        precio = 0
                    End Try

                    Try
                        costo = grd.Rows(index).Cells("txmCosto").Value
                    Catch ex As Exception
                        costo = 0
                    End Try

                    mdlPublicVars.superSearchId = id
                    mdlPublicVars.superSearchCodigo = codigo
                    mdlPublicVars.superSearchNombre = nombre
                    mdlPublicVars.superSearchCantidad = cantidad
                    mdlPublicVars.superSearchTipoPrecio = tipoPrecio
                    If bitCliente = True Then
                        mdlPublicVars.superSearchPrecio = precio
                        mdlPublicVars.superSearchSurtir = surtir

                        'Verificamos si la empresa valida la venta maxima por cliente
                        If Empresa_ValidaVenta = True Then
                            If fnCantidadMax(index) = False Then
                                formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                            Else
                                grd.Rows(index).Cells("txmCantidad").BeginEdit()
                                Exit For
                            End If
                        Else
                            formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        End If
                    ElseIf bitProveedor = True Then
                        mdlPublicVars.superSearchPrecio = costo
                        frmEntrada.fnAgregar_Articulos()
                    ElseIf bitMovimientoInventario = True Then
                        mdlPublicVars.superSearchPrecio = costo
                        frmMovimientoInventarios.fnAgregar_Articulos()
                    ElseIf bitDevolucionCliente = True Then
                        mdlPublicVars.superSearchPrecio = precio
                        frmClienteDevolucion.fnAgregar_Articulos()
                    End If
                End If
                grd.Rows(index).Cells("txmCantidad").Value = 0
                grd.Rows(index).Cells("txmSurtir").Value = 0
            Else
                cantidad = 0
                surtir = 0
            End If

        Next

        If cont > 0 Then
            If bitCliente = True Then
                formSalida.fnNuevaFila()
                formSalida.fnBloquearCombo()
            ElseIf bitProveedor = True Then
                frmEntrada.fnNuevaFila()
            ElseIf bitMovimientoInventario = True Then
                frmMovimientoInventarios.fnNuevaFila()
            ElseIf bitDevolucionCliente = True Then
                frmClienteDevolucion.fnNuevaFila()
            End If
        End If
    End Sub

    'Funcion utilizada para elegir precios
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try

            'si esta activo el page uno ingresa el precio en el grid 1
            If rpvInformacion.SelectedPage.Name = "pgGeneral" Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If

            'si esta activo el page uno ingresa el precio en el grid 1
            If rpvInformacion.SelectedPage.Name = "pgNoComprados" Then
                Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitNuevos = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdProductos2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos2.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos2.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitNuevos = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdProductos.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdProductos.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub grdProductos2_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles grdProductos2.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdProductos2.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdProductos2.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub grdProductos_SelectionChanged(sender As Object, e As EventArgs) Handles grdProductos.SelectionChanged
        fnInformacion(grdProductos)
    End Sub

    Private Sub grdProductos2_SelectionChanged(sender As Object, e As EventArgs) Handles grdProductos2.SelectionChanged
        fnInformacion(grdProductos2)
    End Sub


    Private Sub grdProductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdProductos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos.Focused = True Then
            fnAgregar_Productos(grdProductos)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos, 0, e, True)
    End Sub


    Private Sub grdProductos2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdProductos2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos2.Focused = True Then
            fnAgregar_Productos(grdProductos2)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos2, 0, e, True)
    End Sub


    'iformacion del articulo
    Private Sub fnInformacion(grd As Telerik.WinControls.UI.RadGridView)
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Dim ubicacion As String

            Dim fila As Integer = CInt(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd))

            Try
                observacion = CType(grd.Rows(fila).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(grd.Rows(fila).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(grd.Rows(fila).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(grd.Rows(fila).Cells("Compatibilidad").Value, String)
            Catch ex As Exception
                compatibilidad = ""
            End Try

            Try
                ubicacion = CType(grd.Rows(fila).Cells("UbicacionEstanteria").Value, String)
            Catch ex As Exception
                ubicacion = ""
            End Try

            lblUbicacion.Text = ubicacion
            lblObservacion.Text = observacion
            lblMarca.Text = marca
            lblCompatibilidad.Text = compatibilidad
            If empaque <> "" Then

                lblEmpaque.Text = empaque
            Else
                lblEmpaque.Text = ""
            End If


        Catch ex As Exception
            RadMessageBox.Show(ex.ToString)
        End Try
    End Sub



    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = Me.grdProductos.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = Me.grdProductos.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = Me.grdProductos.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = Me.grdProductos.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = Me.grdProductos.Rows(fila).Cells("minimo").Value

            'Si el saldo es menor que el minimo y bitVentaMaxima = true, se activa la restriccion
            'Pero si la cantidadMaxima es igual a cero no se valida
            If saldo < minimo And valida = True Then
                If limite > 0 Then
                    If cantidad > limite Then
                        RadMessageBox.Show("Cantidad a vender sobrepasa la cantida maxima de venta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Return True
                        Exit Function
                    End If
                End If
            End If

            Return False
        Catch ex As Exception
        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click


        If rpvInformacion.SelectedPage.Name = "pgGeneral" Then
            fnAgregar_Productos(grdProductos)
        End If


        If rpvInformacion.SelectedPage.Name = "pgNoComprados" Then
            fnAgregar_Productos(grdProductos2)
        End If

       
    End Sub


    Private Sub grdTipoVehiculo_ValueChanged(sender As Object, e As EventArgs) Handles grdTipoVehiculo.ValueChanged
        'contador
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")
    End Sub

    Private Sub chkTodosTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosTipo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            mdlPublicVars.fnCheckbox_ActivaDesactivar(grdTipoVehiculo, chkTodosTipo.Checked)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

   
    Private Sub btnBusqueda_Click(sender As Object, e As EventArgs) Handles btnBusqueda.Click
        If cargo Then
            fnLlenar_productos()

        End If
    End Sub


    'DOCUMENTO SALIDA
    Private Sub fnDocSalida() Handles Me.panel1
        Try
            frmDocumentosSalida.txtTitulo.Text = "Productos Nuevos"
            frmDocumentosSalida.grd = Me.grdProductos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub


    'SALIR
    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    Private Sub fnFoto() Handles Me.panel0


        If rpvInformacion.SelectedPage.Name = "pgGeneral" Then
            If Me.grdProductos.Rows.Count > 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
                If fila >= 0 Then
                    frmBuscarArticuloFoto.Text = "Informacion Articulo"
                    frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloFoto.codigo = CType(Me.grdProductos.Rows(fila).Cells("id").Value, Integer)
                    frmBuscarArticuloFoto.cliente = codClie
                    permiso.PermisoDialogEspeciales(frmBuscarArticuloFoto)
                    frmBuscarArticuloFoto.Dispose()

                End If
            End If
        End If

       
        If rpvInformacion.SelectedPage.Name = "pgNoComprados" Then
            If Me.grdProductos2.Rows.Count > 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos2)
                If fila >= 0 Then
                    frmBuscarArticuloFoto.Text = "Informacion Articulo"
                    frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloFoto.codigo = CType(Me.grdProductos2.Rows(fila).Cells("id").Value, Integer)
                    frmBuscarArticuloFoto.cliente = codClie
                    permiso.PermisoDialogEspeciales(frmBuscarArticuloFoto)
                    frmBuscarArticuloFoto.Dispose()

                End If
            End If
        End If

    End Sub

End Class
