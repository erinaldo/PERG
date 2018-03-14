﻿Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmBuscarArticuloSugeridos
    Private _codclie As Integer
    Private _codvendedor As Integer

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Private _modelos As String
    Private _tipos As String

    Private b As New clsBase
    Private permiso As New clsPermisoUsuario

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

    Public Property codClie() As Integer
        Get
            codClie = _codclie
        End Get
        Set(ByVal value As Integer)
            _codclie = value
        End Set
    End Property

    Public Property codVendedor() As Integer
        Get
            codVendedor = _codvendedor
        End Get
        Set(ByVal value As Integer)
            _codvendedor = value
        End Set
    End Property

    Public Property modelos() As String
        Get
            modelos = _modelos
        End Get
        Set(ByVal value As String)
            _modelos = value
        End Set
    End Property

    Public Property tipos() As String
        Get
            tipos = _tipos
        End Get
        Set(ByVal value As String)
            _tipos = value
        End Set
    End Property

    Private Sub frmBuscarArticuloSugeridos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdProductos.ImageList = frmControles.ImageListAdministracion
            Me.grdProductos2.ImageList = frmControles.ImageListAdministracion
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos2)
            fnLlenar_productos1()
            fnLlenar_productos2()
            fnMuestraOferta()
            fnObtieneOferta()
            lblTiempoNoComprado.Text = mdlPublicVars.General_TiempoNoComprado & " meses"
            lblEvaluacion.Text = mdlPublicVars.Empresa_OfertaMinimoDias & " días "
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para saber si se debe de mostrar la oferta
    Private Sub fnMuestraOferta()
        Try
            'Obtenemos la clasificacoin de pago del cliente
            Dim tipoPago As tblCliente_Precio = (From x In ctx.tblCliente_Precio Where x.precio = mdlPublicVars.BuscarArticulo_CodigoOferta _
                                                 And x.cliente = codClie Select x).FirstOrDefault

            If tipoPago Is Nothing Then
                pgOfertas.Dispose()
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para obtener el precio oferta del articulo
    Private Sub fnObtieneOferta()
        Try
            'Reccoremos el grid de productos
            For i As Integer = 0 To Me.grdProductos2.RowCount
                'Obtenemos  el id del producto
                Dim codArt As Integer = CInt(Me.grdProductos2.Rows(i).Cells("id").Value)

                'Consultamos el precio del articulo
                Dim precio As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = codArt And x.tipoPrecio = mdlPublicVars.BuscarArticulo_CodigoOferta _
                              Select x).FirstOrDefault

                Me.grdProductos2.Rows(i).Cells("txbPrecio").Value = Format(precio.precio, mdlPublicVars.formatoMoneda)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion(ByRef grd As Telerik.WinControls.UI.RadGridView)
        Try
            grd.Columns(1).IsVisible = False 'id
            grd.Columns(11).IsVisible = False 'observacion
            grd.Columns(12).IsVisible = False 'empaque
            grd.Columns(14).IsVisible = False 'clrEstado
            grd.Columns(15).IsVisible = False 'numero de articulo en catalogo
            grd.Columns(16).IsVisible = False 'fecha ultima compra
            grd.Columns(17).IsVisible = False 'marca
            grd.Columns(18).IsVisible = False 'bitVentaMaxima
            grd.Columns(19).IsVisible = False 'minimo
            grd.Columns("TipoPrecio").IsVisible = False 'minimo
            grd.Columns("Compatibilidad").IsVisible = False 'minimo

            grd.Columns(0).Width = 60 ' agregar
            grd.Columns(2).Width = 70 ' codigo
            grd.Columns(3).Width = 180 ' nombre
            grd.Columns(4).Width = 70 ' cantidad
            grd.Columns(5).Width = 70 ' existencia
            grd.Columns(6).Width = 70 ' reserva
            grd.Columns(7).Width = 70 ' transito
            grd.Columns(8).Width = 50 ' costo
            grd.Columns(9).Width = 70 ' precio
            grd.Columns(10).Width = 70 ' cantidadmax
            grd.Columns(11).Width = 50 ' observacion
            grd.Columns(12).Width = 60 'unidadempaque
            grd.Columns(13).Width = 70 'surtir

            grd.Columns(0).ReadOnly = False
            grd.Columns(1).ReadOnly = True
            grd.Columns(2).ReadOnly = True
            grd.Columns(3).ReadOnly = True
            grd.Columns(4).ReadOnly = False
            grd.Columns(5).ReadOnly = True
            grd.Columns(6).ReadOnly = True
            grd.Columns(7).ReadOnly = True
            grd.Columns(8).ReadOnly = False
            grd.Columns(9).ReadOnly = True
            grd.Columns(10).ReadOnly = True
            grd.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txmCosto")

            If bitCliente = True Or bitDevolucionCliente = True Then
                grd.Columns("txmCosto").IsVisible = False
                grd.Columns("txbPrecio").IsVisible = True
                grd.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
                grd.Columns("Reserva").IsVisible = False
                grd.Columns("clrEstado").IsVisible = False
                grd.Columns("txbPrecio").IsVisible = False
                grd.Columns("txmSurtir").IsVisible = False
                grd.Columns("CantidadMax").IsVisible = False
                grd.Columns.Move(8, 5)
                'ElseIf OpcionRetorno = "consulta" Then
                '    grd.Columns("txmCosto").IsVisible = False
                '    grd.Columns("clrEstado").IsVisible = False
                '    grd.Columns("txbPrecio").IsVisible = False
            End If

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
        mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario

        If bitCliente = True And bitDevolucionCliente = False Then
            If mdlPublicVars.superSearchInventario <> frmSalidas.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To grd.Rows.Count - 1
            'agrega = CType(Me.grd.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then
            Try
                cantidad = grd.Rows(index).Cells("txmCantidad").Value
            Catch ex As Exception
                cantidad = 0
            End Try

            Try
                surtir = Me.grdProductos.Rows(index).Cells("txmSurtir").Value
            Catch ex As Exception
                surtir = 0
            End Try

            If cantidad > 0 Or surtir > 0 Then
                cont += 1
                If cont = 1 Then
                    If bitCliente = True And bitDevolucionCliente = False Then
                        frmSalidas.fnRemoverFila()
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
                If bitCliente = True And bitDevolucionCliente = False Then
                    mdlPublicVars.superSearchPrecio = precio
                    mdlPublicVars.superSearchSurtir = surtir

                    'Verificamos si la empresa valida la venta maxima por cliente
                    If Empresa_ValidaVenta = True Then
                        If fnCantidadMax(index) = False Then
                            frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        Else
                            Me.grdProductos.Rows(index).Cells("txmCantidad").BeginEdit()
                            Exit For
                        End If
                    Else
                        frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
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
        Next

        If cont > 0 Then
            If bitCliente = True And bitDevolucionCliente = False Then
                frmSalidas.fnNuevaFila()
                frmSalidas.fnBloquearCombo()
            ElseIf bitProveedor = True Then
                frmEntrada.fnNuevaFila()
            ElseIf bitMovimientoInventario = True Then
                frmMovimientoInventarios.fnNuevaFila()
            ElseIf bitDevolucionCliente = True Then
                frmClienteDevolucion.fnNuevaFila()
            End If
        End If
    End Sub

    'FUNCION QUE LLENA EL GRID PRODUCTOS1
    Private Sub fnLlenar_productos1()
        Try
            Me.grdProductos.DataSource = Nothing
            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
            Dim diferenciaMes As DateTime = fechaActual.AddMonths(-mdlPublicVars.General_TiempoNoComprado)

            'Encontramos que productos a comprado el cliente en los ultimos dos meses
            Dim prod = (From x In ctx.tblSalidaDetalles _
                        Where x.tblSalida.idCliente = codClie And x.tblSalida.anulado = False And x.tblSalida.facturado = True _
                        And x.tblSalida.fechaRegistro > diferenciaMes Select Codigo = x.idArticulo)

            'Creamos la cadena
            Dim contador As Integer = 1
            Dim filtro As String = ""
            Dim c

            For Each c In prod
                If contador = 1 Then
                    filtro = c.ToString
                Else
                    filtro = filtro + "," + c.ToString
                End If
                contador += 1
            Next

            Dim cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, filtro, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, tipos, modelos, codClie, 5, True, False, "")

            grdProductos.DataSource = mdlPublicVars.EntitiToDataTable(cons)
            fnConfiguracion(grdProductos)
        Catch ex As Exception
            'Me.grdProductos.Rows.Clear()
            grdProductos.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
    End Sub

    'FUNCION QUE LLENA EL GRID PRODUCTOS2
    Private Sub fnLlenar_productos2()
        Try
            Dim cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, "", mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, tipos, modelos, codClie, 6, True, False, "")

            grdProductos2.DataSource = mdlPublicVars.EntitiToDataTable(cons)
            fnConfiguracion(grdProductos2)
        Catch ex As Exception
            'Me.grdProductos.Rows.Clear()
            grdProductos2.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdProductos2)
    End Sub

    'Cuando se da clic sobre el boton agregar del grid 1
    Private Sub pbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            fnAgregar_Productos(grdProductos)
        Catch ex As Exception
        End Try
    End Sub

    'Cuando se da clic sobre el boton agregar del grid 2
    Private Sub pbAgregar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar2.Click
        Try
            fnAgregar_Productos(grdProductos2)
        Catch ex As Exception
        End Try
    End Sub

    'Evento utilizada para darle colores al grid 1
    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
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

    'Evento utilizada para darle colores al grid 2
    Private Sub grdProductos2_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos2.CellFormatting
        'Cambia el color de la fuente(letra) en el grid
        If Me.grdProductos2.Rows.Count > 0 Then
            If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                mdlPublicVars.GridColor_fila(e, Color.Green)
            ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                mdlPublicVars.GridColor_fila(e, Color.Red)
            Else
                mdlPublicVars.GridColor_fila(e, Color.Black)
            End If

            Dim inicio As Integer = CType(Me.grdProductos2.Columns("Existencia").Index, Integer)
            mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)

        End If
    End Sub

    'Evento que se maneja cuando se presiona ENTER en el grid 1 
    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos.Focused = True Then
            fnAgregar_Productos(grdProductos)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos, 0, e, True)
    End Sub

    'Evento que se maneja cuando se presiona ENTER en el grid 2
    Private Sub grdProductos2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos2.Focused = True Then
            fnAgregar_Productos(grdProductos2)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos2, 0, e, True)
    End Sub

    'Evento que se maneja cuando se cambia de seleccion en el grid 1
    Private Sub grdProductos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Try
                observacion = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Compatibilidad").Value, String)
            Catch ex As Exception
                compatibilidad = ""
            End Try

            lblObservacion.Text = observacion
            lblMarca.Text = marca
            lblCompatibilidad.Text = compatibilidad
            If empaque <> "" Then

                lblEmpaque.Text = empaque
            Else
                lblEmpaque.Text = ""
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Evento que se maneja cuando se cambia de seleccion en el grid 2
    Private Sub grdProductos2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos2.SelectionChanged
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Try
                observacion = CType(Me.grdProductos2.Rows(Me.grdProductos2.SelectedRows(0).Index).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdProductos2.Rows(Me.grdProductos2.SelectedRows(0).Index).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdProductos2.Rows(Me.grdProductos2.SelectedRows(0).Index).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Compatibilidad").Value, String)
            Catch ex As Exception
                compatibilidad = ""
            End Try

            lblObservacion2.Text = observacion
            lblMarca2.Text = marca
            lblCompatibilidad2.Text = compatibilidad
            If empaque <> "" Then

                lblEmpaque2.Text = empaque
            Else
                lblEmpaque2.Text = ""
            End If

            fnUltimaVenta()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada pra encontrar la fecha de ultima venta del articulo
    Private Sub fnUltimaVenta()
        Try
            Dim codArt As Integer = Me.grdProductos2.Rows(Me.grdProductos2.CurrentRow.Index).Cells("id").Value

            'Realizamos la consulta para obtener la ultima venta
            Dim venta As tblSalidaDetalle = (From x In ctx.tblSalidaDetalles Where x.tblSalida.idCliente = codClie _
                                             And x.idArticulo = codArt And x.tblSalida.anulado = False And x.tblSalida.facturado = True _
                                             Select x Order By x.tblSalida.fechaFacturado Descending Take 1).FirstOrDefault

            If venta IsNot Nothing Then
                'Si ya se le vendio
                lblFechaUltimaVenta.Text = Format(venta.tblSalida.fechaFacturado, mdlPublicVars.formatoFecha)
                lblPrecioUltimo.Text = Format(venta.precio, mdlPublicVars.formatoMoneda)
                lblCantidad.Text = venta.cantidad
                'Verificamos hace cuantos dias se realizo la ultima venta
                Dim fechaServidor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)

                Dim fechaMinimo = fechaServidor.AddDays(-mdlPublicVars.Empresa_OfertaMinimoDias)

                If fechaMinimo > venta.tblSalida.fechaFacturado Then
                    lblEstado.BackColor = Color.Green
                Else
                    lblEstado.BackColor = Color.Red
                End If
            Else
                lblCantidad.Text = ""
                lblPrecioUltimo.Text = ""
                lblFechaUltimaVenta.Text = ""
                lblEstado.BackColor = Color.Transparent
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSustitutos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then ' And (estado = 1 Or estado = 2) 
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitSugerir = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticulo, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'DOCUMENTO SALIDA
    Private Sub fnDocSalida() Handles Me.panel0
        Try
            If rpvInformacion.SelectedPage.Name = "pgOfertas" Then
                frmDocumentosSalida.txtTitulo.Text = "Productos Ofertados"
                frmDocumentosSalida.grd = grdProductos
            Else
                frmDocumentosSalida.txtTitulo.Text = "Productos Sugeridos"
                frmDocumentosSalida.grd = grdProductos2
            End If

            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
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

End Class