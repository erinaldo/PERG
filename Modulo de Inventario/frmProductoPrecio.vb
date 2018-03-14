﻿Imports System.Linq
Imports System.Transactions
Imports Telerik.WinControls

Imports Telerik.WinControls.UI
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmProductoPrecio

    Dim alerta As New bl_Alertas
    Dim permiso As New clsPermisoUsuario

    Private Sub frmProductoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdOtrosPrecios)
        mdlPublicVars.fnFormatoGridEspeciales(grdOtrosPreciosSucursal)
        mdlPublicVars.fnFormatoGridEspeciales(grdPrecios)
        mdlPublicVars.fnFormatoGridEspeciales(grdSustitutos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPreciosSustitutos)
        mdlPublicVars.fnFormatoGridEspeciales(grdUltimasCompras)
        mdlPublicVars.fnFormatoGridEspeciales(grdPreciosCompe)
        mdlPublicVars.fnFormatoGridEspeciales(grdUltimasVentas)
        mdlPublicVars.fnFormatoGridEspeciales(grdPreciosMotriza)
        mdlPublicVars.fnGrid_iconos(grdPreciosMotriza)
        mdlPublicVars.fnGrid_iconos(grdOtrosPrecios)
        mdlPublicVars.fnGrid_iconos(grdOtrosPreciosSucursal)
        mdlPublicVars.fnGrid_iconos(grdPrecios)

        mdlPublicVars.comboActivarFiltro(cmbNombre1)

        lbl1Modificar.Text = "Guardar"

        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automatico
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        'Me.errores.Controls.Add(Me.txtCodigo1, "Codigo1")
        'Me.errores.SummaryMessage = "Faltan datos"

        fnLlenarCombo()
        llenagrid()
        fnConfiguracion()
        mdlPublicVars.fnSeleccionarDefault(grdDatos, mdlPublicVars.superSearchId, True)
        Call frm_txtcodigo()


        Me.grdDatos.Visible = False
        lblRegistros.Visible = False

    End Sub

    Private Sub llenagrid()
        Try

            Dim consulta = From x In ctx.tblArticuloes Order By x.codigo1 Where x.empresa = mdlPublicVars.idEmpresa _
                           Select Codigo = x.idArticulo, Codigo1 = x.codigo1, Nombre1 = x.nombre1 + " - " + x.codigo1, _
                           Existencia = (From i In ctx.tblInventarios Where x.idArticulo = i.idArticulo Select i.saldo).FirstOrDefault, _
                           Importacia = x.tblArticuloImportancia.nombre, Minimo = x.minimo, PrecioPublico = x.precioPublico, PrecioPublicoMotriza = x.preciopublicosucursal, Importancia = x.tblArticuloImportancia.nombre, _
                           CostoLocal = x.costoIVA, CostoImportacion = 0, Costo = (x.costoIVA + 0), Observacion = x.observacionPrecio Order By Codigo

            Me.grdDatos.DataSource = consulta
            fnLlenaPrecios()
            fnCalculaNormales()
            fnUltimasCompras()
            fnUltimasVentas()
            'calcular los costos
            fnCalculaOtros()
        Catch ex As Exception
        End Try

    End Sub

    'Aplica configuraciones de formato a los grid, textbox, label...
    Private Sub fnConfiguracion()
        Try
            Dim costo As Decimal = lblCosto.Text
            lblCosto.Text = Format(costo, mdlPublicVars.formatoMoneda)

            'Configuramos el grid de sustitutos
            If Me.grdSustitutos.Rows.Count > 0 Then
                Me.grdSustitutos.Columns(0).IsVisible = False
                Me.grdSustitutos.Columns(1).Width = 80
                Me.grdSustitutos.Columns(2).Width = 200
                Me.grdSustitutos.Columns(3).Width = 100
                Me.grdSustitutos.Columns(4).Width = 100
                Me.grdSustitutos.Columns(5).Width = 100


                Me.grdSustitutos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter

                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioPublico")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioNormal")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioA")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioB")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioOferta")


                'Definimos que columnas no se podran editar
                Me.grdSustitutos.Columns(0).ReadOnly = True
                Me.grdSustitutos.Columns(1).ReadOnly = True
                Me.grdSustitutos.Columns(2).ReadOnly = True
                Me.grdSustitutos.Columns(3).ReadOnly = True
                Me.grdSustitutos.Columns(4).ReadOnly = True
                Me.grdSustitutos.Columns(6).ReadOnly = True
                Me.grdSustitutos.Columns(10).ReadOnly = True

                Me.grdSustitutos.Columns(5).ReadOnly = False
                Me.grdSustitutos.Columns(7).ReadOnly = False
                Me.grdSustitutos.Columns(8).ReadOnly = False
                Me.grdSustitutos.Columns(9).ReadOnly = False
            End If

            If Me.grdUltimasCompras.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdUltimasCompras, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdUltimasCompras, "Costo")
                Me.grdUltimasCompras.Columns(0).Width = 100
                Me.grdUltimasCompras.Columns(1).Width = 200
                Me.grdUltimasCompras.Columns(2).Width = 100
                Me.grdUltimasCompras.Columns(3).Width = 100

                For i As Integer = 0 To Me.grdUltimasCompras.Columns.Count - 1
                    Me.grdUltimasCompras.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
            End If

            If Me.grdUltimasVentas.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdUltimasVentas, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdUltimasVentas, "Precio")

                Me.grdUltimasVentas.Columns(0).Width = 80
                Me.grdUltimasVentas.Columns(1).Width = 160
                Me.grdUltimasVentas.Columns(2).Width = 70
                Me.grdUltimasVentas.Columns(3).Width = 60
                Me.grdUltimasVentas.Columns(4).Width = 70
                Me.grdUltimasVentas.Columns(5).Width = 70
            End If


            If Me.grdPreciosCompe.RowCount > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdPreciosCompe, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdPreciosCompe, "Precio")

                For i As Integer = 0 To Me.grdPreciosCompe.ColumnCount - 1
                    Me.grdPreciosCompe.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdPreciosCompe.Columns(0).Width = 15
                Me.grdPreciosCompe.Columns(1).Width = 35
                Me.grdPreciosCompe.Columns(2).Width = 15
                Me.grdPreciosCompe.Columns(3).Width = 35
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Ultimas Ventas
    Private Sub fnUltimasVentas()
        Dim codArt As Integer = CInt(cmbNombre1.SelectedValue)
        Dim general = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False And x.tblSalida.empacado = True And x.idArticulo = codArt _
                        Select Fecha = x.tblSalida.fechaRegistro, Cliente = x.tblSalida.tblCliente.Negocio, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio, _
                         TipoPrecio = (From y In ctx.tblArticuloTipoPrecios Where x.tipoPrecio = y.codigo Select y.nombre).FirstOrDefault _
                        Order By Fecha Descending)

        Me.grdUltimasVentas.DataSource = general
    End Sub

    'Funcion utilizada para llenar el combo
    Private Sub fnLlenarCombo()
        Try
            'Realizamos la consulta
            Dim cons = (From x In ctx.tblArticuloes _
                        Select Codigo = x.idArticulo, Nombre = x.nombre1 + " - " + x.codigo1)

            'Llenamos el combo1
            With Me.cmbNombre1
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_focoDatos() Handles Me.focoDatos
        lblCodigo1.Focus()
    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try
            Dim success As Boolean = True
            Dim codArt As Integer = CType(txtCodigo.Text, Integer)
            Dim fechaServidor As DateTime = fnFecha_horaServidor()

            Using transaction As New TransactionScope


                Try
                    'Obtenemos el articulo que queremos modificar
                    Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codArt Select x).FirstOrDefault

                    Dim precioPublico As Decimal = 0
                    Dim preciopublicosucursal As Decimal = 0

                    If IsNumeric(txtPrecioPublico.Text) Then
                        precioPublico = CDec(txtPrecioPublico.Text)
                    End If

                    If IsNumeric(txtPrecioPublicoMotriza.Text) Then
                        preciopublicosucursal = CDec(txtPrecioPublicoMotriza.Text)
                    End If

                    'Modificamos los precios del articulo
                    articulo.precioPublico = precioPublico
                    articulo.preciopublicosucursal = preciopublicosucursal
                    articulo.observacionPrecio = txtObservacion.Text
                    articulo.fechaprecio = CDate(fnFecha_horaServidor())

                    'Recorremos el grid de precio para guardar los precios.
                    Dim i = 0
                    Dim descuento As Double = 0
                    Dim utilidad As String = ""
                    Dim precio As Decimal = 0
                    Dim preciosucursal As Decimal = 0
                    Dim tipoNegocio As Integer = 0
                    Dim codigo As Integer = 0
                    Dim descuentosucursal As Double = 0


                    For i = 0 To Me.grdPrecios.Rows.Count - 1
                        Dim desc As String = CType(Me.grdPrecios.Rows(i).Cells("txmDescuento").Value, String)
                        descuento = desc.Substring(0, desc.LastIndexOf("%"))
                        Dim desc2 As String = CType(Me.grdPreciosMotriza.Rows(i).Cells("txmDescuento").Value, String)
                        descuentosucursal = desc2.Substring(0, desc2.LastIndexOf("%"))


                        utilidad = CType(Me.grdPrecios.Rows(i).Cells("utilidad").Value, String)
                        precio = CType(Me.grdPrecios.Rows(i).Cells("precioNormal").Value, Decimal)
                        tipoNegocio = CType(Me.grdPrecios.Rows(i).Cells("codTipoNegocio").Value, Integer)
                        codigo = CType(Me.grdPrecios.Rows(i).Cells("codigo").Value, Integer)
                        If codigo > 0 Then
                            'Si tipo de precio es mayor a cero, modificamos el registro
                            Dim tipo As tblArticulo_TipoNegocio = (From x In ctx.tblArticulo_TipoNegocio Where x.codigo = codigo _
                                                                      Select x).FirstOrDefault
                            'tipo.precioNormal = precio
                            'tipo.utilidad = utilidad.Substring(0, utilidad.Length - 2)
                            tipo.descuento = descuento
                            tipo.descuentosucursal = descuentosucursal
                            tipo.articulo = articulo.idArticulo
                            tipo.tipoNegocio = tipoNegocio
                            ctx.SaveChanges()
                        Else
                            'De lo contrario creamos el registro
                            Dim tipo As New tblArticulo_TipoNegocio
                            'tipo.precioNormal = precio
                            'tipo.utilidad = utilidad.Substring(0, utilidad.Length - 2)
                            tipo.descuento = descuento
                            tipo.descuentosucursal = descuentosucursal
                            tipo.articulo = articulo.idArticulo
                            tipo.tipoNegocio = tipoNegocio
                            ctx.AddTotblArticulo_TipoNegocio(tipo)
                            ctx.SaveChanges()
                        End If
                    Next



                    'Variables utilizadas para recorrer el grid de precios
                    'Recorremos el grid de otros precios para guardar los precios
                    Dim activa As Boolean = False
                    Dim perdida As Boolean = False
                    Dim cantEsta As Boolean = False
                    Dim fechaEsta As Boolean = False
                    Dim tPrecio As Integer = 0
                    Dim porcen As String = ""
                    Dim fInici As DateTime = Nothing
                    Dim fFin As DateTime = Nothing
                    Dim minima As Integer = 0
                    Dim activasucursal As Boolean = False
                    Dim perdidasucursal As Boolean = False
                    Dim cantestasucursal As Boolean = False
                    Dim fechaestasucursal As Boolean = False
                    Dim tpreciosucursal As Integer = 0
                    Dim porcensucursal As String = ""
                    Dim finicisucursal As DateTime = Nothing
                    Dim ffinsucursal As DateTime = Nothing
                    Dim minimasucursal As Integer = 0



                    '--- BITACORA DE PRECIOS
                    'Obtenemos la lista de otros precios
                    Dim lPrecio As List(Of tblArticulo_Precio) = (From x In ctx.tblArticulo_Precio.AsEnumerable Where x.articulo = codArt And Not x.tblArticuloTipoPrecio.bitEspecial _
                                                                  Select x).ToList
                    'Cadena utilizada para guardar la bitacora
                    Dim bitacora As String = ""
                    'Recorremos la lista de precios y el grid a la vez
                    For Each dPrecio As tblArticulo_Precio In lPrecio

                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            'Reseteamos la cadena de bitacora
                            bitacora = ""

                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)
                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                            Catch ex As Exception
                                fInici = Nothing
                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                            Catch ex As Exception
                                fFin = Nothing
                            End Try

                            'Verificamos si tienen el mismo codigo entonces procedemos a revisar cambios
                            If dPrecio.codigo = codigo Then
                                'SI SE ACTIVO O DESACTIVO PRECIO
                                If dPrecio.habilitado <> activa Then
                                    bitacora += "Se " & If(activa, "activo", "desactivo") & " precio" & vbCrLf
                                End If

                                'SI SE CAMBIO PRECIO
                                If dPrecio.precio <> precio Then
                                    bitacora += "Se cambio precio, Anterior: " & Format(dPrecio.precio, mdlPublicVars.formatoMoneda) _
                                        & " - Ahora: " & Format(precio, mdlPublicVars.formatoMoneda) & vbCrLf
                                End If

                                'SI SE ACTIVO POLITICA DE CANTIDAD MINIMA
                                If dPrecio.bitCantidad <> cantEsta Then
                                    bitacora += "Se " & If(cantEsta, "activo", "desactivo") & " politica de cantidad "

                                    If cantEsta Then
                                        bitacora += ", minimo : " & minima & vbCrLf
                                    End If

                                End If

                                'SI SE ACTIVO POLITICA DE FECHAS
                                If dPrecio.bitFecha <> fechaEsta Then
                                    bitacora += "Se " & If(fechaEsta, "activo", "desactivo") & " politica de fechas, "

                                    If fechaEsta Then
                                        bitacora += "De : " & fInici.ToShortDateString & " - Hasta :" & fFin.ToShortDateString
                                    End If
                                End If

                                If bitacora.Length > 0 Or Not bitacora.Equals("") Then
                                    'Creamos el nuevo registro de bitacora
                                    Dim eBitacora As New tblBitacoraPreciosArticulo
                                    eBitacora.articulo_precio = codigo
                                    eBitacora.descripcion = bitacora
                                    eBitacora.fechaRegistro = fechaServidor

                                    'Agregamos el registro al contexto
                                    ctx.AddTotblBitacoraPreciosArticuloes(eBitacora)
                                    ctx.SaveChanges()
                                End If
                            End If
                        Next

                    Next


                    '--- FIN DE BITACORA

                    Dim noempresa As Integer
                    Dim empresa As String

                    Dim idempresa As tblEmpresa = (From x In ctx.tblEmpresas _
                                          Select x).FirstOrDefault

                    noempresa = idempresa.idEmpresa

                    Dim nombreempresa As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = noempresa _
                                                 Select x).FirstOrDefault
                    empresa = nombreempresa.nombre

                    If empresa = "PRIMSA" Then
                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            tPrecio = CType(Me.grdOtrosPrecios.Rows(i).Cells("codPrecio").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)
                            activasucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("chmActiva").Value, Boolean)
                            Try
                                preciosucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txmPreciosucursal").Value, Decimal)
                            Catch ex As Exception

                            End Try


                            porcen = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)

                            porcensucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdidasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantestasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minimasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            ''fechaestasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)

                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                                ''finicisucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                                finicisucursal = Nothing
                            Catch ex As Exception
                                fInici = Nothing
                                finicisucursal = Nothing
                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                                ''ffinsucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                                ffinsucursal = Nothing
                            Catch ex As Exception
                                fFin = Nothing
                                ffinsucursal = Nothing
                            End Try


                            If codigo > 0 Then
                                'Modificamos el registro
                                Dim registro As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.codigo = codigo _
                                                                    Select x).FirstOrDefault
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                registro.preciosucursal = preciosucursal
                                registro.habilitadoSucursal = activasucursal
                                registro.bitCantidadSucursal = cantestasucursal
                                registro.bitFechaSucursal = fechaestasucursal
                                registro.cantidadMinimaSucursal = minimasucursal
                                registro.porcentajeSucursal = porcensucursal.Substring(0, porcensucursal.Length - 2)

                                finicisucursal = Nothing
                                ffinsucursal = Nothing

                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                    ''registro.fechaInicioSucursal = finicisucursal
                                    ''registro.fechaFin = ffinsucursal
                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                    ''registro.fechaInicioSucursal = Nothing
                                    ''registro.fechaFinSucursal = Nothing
                                End If
                                ctx.SaveChanges()
                            Else
                                'Creamos el registro
                                Dim registro As New tblArticulo_Precio
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                registro.preciosucursal = preciosucursal
                                registro.habilitadoSucursal = activasucursal
                                registro.bitCantidadSucursal = cantestasucursal
                                registro.bitFechaSucursal = fechaestasucursal
                                registro.bitPermitePerdidaSucursal = perdidasucursal
                                registro.cantidadMinimaSucursal = minimasucursal
                                registro.porcentajeSucursal = porcensucursal.Substring(0, porcen.Length - 2)


                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                    ''registro.fechaInicioSucursal = finicisucursal
                                    ''registro.fechaFinSucursal = ffinsucursal
                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                    ''registro.fechaInicioSucursal = Nothing
                                    ''registro.fechaFinSucursal = Nothing
                                End If
                                ctx.AddTotblArticulo_Precio(registro)
                                ctx.SaveChanges()
                            End If
                        Next


                    Else

                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            tPrecio = CType(Me.grdOtrosPrecios.Rows(i).Cells("codPrecio").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)


                            porcen = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)



                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)


                            Catch ex As Exception
                                fInici = Nothing

                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)


                            Catch ex As Exception
                                fFin = Nothing

                            End Try


                            If codigo > 0 Then
                                'Modificamos el registro
                                Dim registro As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.codigo = codigo _
                                                                    Select x).FirstOrDefault
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                End If
                                ctx.SaveChanges()
                            Else
                                'Creamos el registro
                                Dim registro As New tblArticulo_Precio
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio



                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing


                                End If
                                ctx.AddTotblArticulo_Precio(registro)
                                ctx.SaveChanges()
                            End If
                        Next



                    End If

                    'Modificamos los sustitutos
                    Dim pPub As Decimal = 0
                    Dim pA As Decimal = 0
                    Dim pB As Decimal = 0
                    Dim pOfer As Decimal = 0
                    Dim idSust As Decimal = 0
                    Dim costo As Decimal = 0
                    For i = 0 To Me.grdSustitutos.Rows.Count - 1
                        idSust = Me.grdSustitutos.Rows(i).Cells("ID").Value
                        Try
                            pPub = Me.grdSustitutos.Rows(i).Cells("PrecioPublico").Value
                        Catch ex As Exception
                            pPub = 0
                        End Try
                        Try
                            pA = Me.grdSustitutos.Rows(i).Cells("PrecioA").Value
                        Catch ex As Exception
                            pA = 0
                        End Try
                        Try
                            pB = Me.grdSustitutos.Rows(i).Cells("PrecioB").Value
                        Catch ex As Exception
                            pB = 0
                        End Try


                        Try
                            pOfer = Me.grdSustitutos.Rows(i).Cells("PrecioOferta").Value
                        Catch ex As Exception
                            pOfer = 0
                        End Try
                        Try
                            costo = Me.grdSustitutos.Rows(i).Cells("Costo").Value
                        Catch ex As Exception
                            costo = 0
                        End Try


                        'Seleccionamos el articulo que modificaremos
                        Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = idSust Select x).FirstOrDefault
                        art.precioPublico = pPub
                        ctx.SaveChanges()

                        'Modificamos el precioA, precioB, precioOferta

                        'Obtenemos los precios
                        Dim listaP As List(Of tblArticulo_Precio) = (From x In ctx.tblArticulo_Precio _
                                                                     Where x.articulo = idSust Select x).ToList
                        Dim pre As tblArticulo_Precio
                        Dim marge As Decimal = 0
                        'Recorremos la lista de precios
                        For Each pre In listaP

                            If pre.tblArticuloTipoPrecio.nombre = "Precio A" Then
                                pre.precio = pA
                                Try
                                    utilidad = (1 - (pA / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try

                            ElseIf pre.tblArticuloTipoPrecio.nombre = "Precio B" Then
                                pre.precio = pB
                                Try
                                    utilidad = (1 - (pB / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try

                            ElseIf pre.tblArticuloTipoPrecio.nombre = "Precio Oferta" Then
                                pre.precio = pOfer
                                Try
                                    utilidad = (1 - (pOfer / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try
                            End If
                            pre.porcentaje = utilidad
                            ctx.SaveChanges()
                        Next

                    Next

                    ctx.SaveChanges()

                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    'success = False
                Catch ex As Exception
                    'success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If

                End Try




            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                alerta.fnModificar()
                Call llenagrid()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar el grid de precios

    Private Sub fnLlenaPrecios()
        Try
            Me.grdPrecios.Rows.Clear()
            Me.grdPreciosMotriza.Rows.Clear()
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
                Dim filas As Object() = Nothing
                If pArt IsNot Nothing Then
                    fila = {pArt.codigo, pArt.tblClienteTipoNegocio.idTipoNegocio, pArt.tblClienteTipoNegocio.nombre, _
                            Format(pArt.descuento / 100, mdlPublicVars.formatoPorcentaje), "", ""}

                    filas = {pArt.codigo, pArt.tblClienteTipoNegocio.idTipoNegocio, pArt.tblClienteTipoNegocio.nombre, _
                            Format(pArt.descuentosucursal / 100, mdlPublicVars.formatoPorcentaje), "", ""}
                Else
                    fila = {"0", negocio.idTipoNegocio, negocio.nombre, negocio.porcentaje, "", ""}

                    filas = {"0", negocio.idTipoNegocio, negocio.nombre, negocio.porcentaje, "", ""}

                End If

                'Agregamos la fila al grid
                Me.grdPrecios.Rows.Add(fila)
                Me.grdPreciosMotriza.Rows.Add(filas)

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
                Dim pPub2 As Decimal = 0

                If IsNumeric(txtPrecioPublico.Text) Then
                    pPub = CDec(txtPrecioPublico.Text)
                End If
                If IsNumeric(txtPrecioPublicoMotriza.Text) Then
                    pPub2 = CDec(txtPrecioPublicoMotriza.Text)
                End If

                Dim cProm As Decimal = CDec(lblCosto.Text)

                'Recorremos el grid
                Dim index
                For index = 0 To Me.grdPrecios.Rows.Count - 1
                    Dim desc As String = CType(Me.grdPrecios.Rows(index).Cells("txmDescuento").Value, String)
                    Dim descsucursal As String = CType(Me.grdPreciosMotriza.Rows(index).Cells("txmDescuento").Value, String)
                    Dim descuento As Decimal = 0
                    Dim descuentosucursal As Decimal = 0

                    If desc.Contains("%") Then
                        descuento = CType(desc.Substring(0, desc.LastIndexOf("%")), Decimal) / 100
                    Else
                        descuento = CType(desc, Decimal) / 100
                    End If

                    If descsucursal.Contains("%") Then
                        descuentosucursal = CType(descsucursal.Substring(0, descsucursal.LastIndexOf("%")), Decimal) / 100
                    Else
                        descuentosucursal = CType(descsucursal, Decimal) / 100
                    End If


                    Dim pNor As Decimal = 0
                    Dim utili As Decimal = 0
                    Dim pNorSucursal As Decimal = 0
                    Dim utiliSucursal As Decimal = 0

                    'Realizamos las operaciones
                    pNor = pPub - (pPub * (descuento))
                    If pNor > 0 Then
                        utili = (1 - (cProm / pNor))
                    End If

                    'Realizamos las operaciones
                    pNorSucursal = pPub2 - (pPub2 * (descuentosucursal))
                    If pNorSucursal > 0 Then
                        utiliSucursal = (1 - (cProm / pNorSucursal))
                    End If

                    'Modificamos el grid
                    Me.grdPrecios.Rows(index).Cells("precioNormal").Value = Format(pNor, mdlPublicVars.formatoMoneda)
                    Me.grdPreciosMotriza.Rows(index).Cells("precioNormal").Value = Format(pNorSucursal, mdlPublicVars.formatoMoneda)

                    Me.grdPrecios.Rows(index).Cells("utilidad").Value = Format(utili, mdlPublicVars.formatoPorcentaje)
                    Me.grdPreciosMotriza.Rows(index).Cells("Utilidad").Value = Format(utiliSucursal, mdlPublicVars.formatoPorcentaje)

                    Me.grdPrecios.Rows(index).Cells("txmDescuento").Value = Format(descuento, mdlPublicVars.formatoPorcentaje)
                    Me.grdPreciosMotriza.Rows(index).Cells("txmDescuento").Value = Format(descuentosucursal, mdlPublicVars.formatoPorcentaje)

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para recalcular los precios normales, cuando se termina de editar una celda
    Private Sub grdPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdPrecios.CellEndEdit
        Try
            fnCalculaNormales()
        Catch ex As Exception
        End Try
    End Sub

    'Evento que se utiliza pra recalcular los precios normales, cuando se cambia el precio publico
    Private Sub txtPrecioPublico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioPublico.TextChanged
        Try
            fnCalculaNormales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecioPublicoMotriza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioPublicoMotriza.TextChanged
        Try
            fnCalculaNormales()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar el grid de otros precios
    Private Sub fnLlenaOtrosPrecios()
        Try
            Me.grdOtrosPrecios.Rows.Clear()
            Me.grdOtrosPrecios2.Rows.Clear()
            Me.grdOtrosPreciosSucursal.Rows.Clear()
            Dim noempresa As Integer
            'Obtenemos los otros precios
            Dim listaPrecio As List(Of tblArticuloTipoPrecio) = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False).ToList
            Dim precio As tblArticuloTipoPrecio
            Dim idArt As Integer = CInt(txtCodigo.Text)
            Dim empresa As String
            'Recorremos los precios
            For Each precio In listaPrecio
                'Seleccionamos el registro
                Dim pArt As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = idArt And x.tipoPrecio = precio.codigo _
                                                  Select x).FirstOrDefault


                Dim idempresa As tblEmpresa = (From x In ctx.tblEmpresas _
                                      Select x).FirstOrDefault

                noempresa = idempresa.idEmpresa

                Dim nombreempresa As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = noempresa _
                                             Select x).FirstOrDefault
                empresa = nombreempresa.nombre
                'Creamos la fila
                Dim fila As Object() = Nothing
                Dim fila2 As Object() = Nothing
                Dim filasucursal As Object() = Nothing



                If empresa = "PRIMSA" Then
                    If pArt IsNot Nothing Then
                        fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                                pArt.habilitado, pArt.porcentaje, "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                                Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}

                        filasucursal = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.preciosucursal, mdlPublicVars.formatoMoneda), _
                                pArt.habilitadosucursal, pArt.porcentajesucursal, "0", pArt.bitpermiteperdidasucursal, pArt.bitcantidadsucursal, Format(pArt.cantidadminimasucursal, mdlPublicVars.formatoCantidad), pArt.bitfechasucursal, _
                                Format(pArt.fechainiciosucursal, mdlPublicVars.formatoFecha), Format(pArt.fechafinsucursal, mdlPublicVars.formatoFecha)}


                        fila2 = {pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda)}
                    Else
                        fila = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}
                        filasucursal = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}

                        fila2 = {precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda)}
                    End If
                    'Agregamos la fila al grid
                    Me.grdOtrosPrecios.Rows.Add(fila)
                    Me.grdOtrosPrecios2.Rows.Add(fila2)
                    Me.grdOtrosPreciosSucursal.Rows.Add(filasucursal)


                Else
                    If pArt IsNot Nothing Then
                        fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                                pArt.habilitado, pArt.porcentaje, "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                                Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}


                        fila2 = {pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda)}
                    Else
                        fila = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}

                        fila2 = {precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda)}
                    End If
                    'Agregamos la fila al grid
                    Me.grdOtrosPrecios.Rows.Add(fila)
                    Me.grdOtrosPrecios2.Rows.Add(fila2)
                End If

            Next

        Catch ex As Exception
            System.Console.WriteLine(ex.ToString())
        End Try
    End Sub

    'Funcion que se utiliza para calcular los otros precios
    Private Sub fnCalculaOtros()
        Try
            'Verificamos si el grid tiene datos
            If Me.grdOtrosPrecios.Rows.Count > 0 Then
                'Recorremos el grid
                Dim index

                Dim precioBase As Decimal = 0
                Dim utilidad As Decimal = 0
                Dim costoPromedio As Double = lblCosto.Text

                For index = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                    precioBase = CType(Me.grdOtrosPrecios.Rows(index).Cells("txmPrecio").Value, Decimal)

                    Try
                        utilidad = 1 - (costoPromedio / precioBase)
                    Catch ex As Exception
                        utilidad = 0
                    End Try

                    If mdlPublicVars.empresa = "PRIMSA" Then
                        Me.grdOtrosPrecios.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString
                        Me.grdOtrosPreciosSucursal.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString

                        'Me.grdOtrosPrecios.Rows(index).Cells("txmPrecio").Value = Format(precioBase, mdlPublicVars.formatoMoneda)
                    Else
                        Me.grdOtrosPrecios.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString

                    End If

                Next


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdOtrosPrecios.CellEndEdit
        Try
            fnCalculaOtros()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdOtrosPrecios.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdOtrosPrecios.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdOtrosPrecios.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdOtrosPrecios.Columns(col).Name)

            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtCodigo.Focus()
                txtCodigo.Select()
                grdOtrosPrecios.Focus()
                Me.grdPrecios.Rows(fil).Cells(col).IsSelected = True
            End If

            'Copiamos los cambios al grid 2
            Dim i
            Dim precio As String
            For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, String)

                'Asignamos el cambio al otro grid
                Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value = precio

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdOtrosPrecios.KeyDown
        Try
            'Si presionamos la tecla F2
            If e.KeyCode = Keys.F2 Then
                fnFechas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnFechas()
        Dim fil = Me.grdOtrosPrecios.CurrentRow.Index
        Dim col = Me.grdOtrosPrecios.CurrentColumn.Index

        Dim acFecha As Boolean = CType(Me.grdOtrosPrecios.Rows(fil).Cells("chmFechaEstado").Value, Boolean)

        If acFecha = True And col > 10 Then
            frmFecha.Text = "Fecha"
            If col = 11 Then
                frmFecha.opcionRetorno = "precioInicio"
                frmFecha.bitgrid1 = True
            ElseIf col = 12 Then
                frmFecha.opcionRetorno = "precioFinal"
                frmFecha.bitgrid1 = True
            End If
            frmFecha.StartPosition = FormStartPosition.CenterScreen
            frmFecha.ShowDialog()
        End If
    End Sub

    Private Sub fnFechasSucursal()
        Dim fil = Me.grdOtrosPreciosSucursal.CurrentRow.Index
        Dim col = Me.grdOtrosPreciosSucursal.CurrentColumn.Index

        Dim acFecha As Boolean = CType(Me.grdOtrosPreciosSucursal.Rows(fil).Cells("chmFechaEstado").Value, Boolean)

        If acFecha = True And col > 10 Then
            frmFecha.Text = "Fecha"
            If col = 11 Then
                frmFecha.opcionRetorno = "precioInicio"
                frmFecha.bitgrid1 = False
            ElseIf col = 12 Then
                frmFecha.opcionRetorno = "precioFinal"
                frmFecha.bitgrid1 = False
            End If
            frmFecha.StartPosition = FormStartPosition.CenterScreen
            frmFecha.ShowDialog()
        End If
    End Sub
    'Funcion para agregar la fecha seleecionada
    Public Sub fnAgregarFecha()
        Try
            If mdlPublicVars.superSearchId = 1 Then
                Me.grdOtrosPrecios.Rows(Me.grdOtrosPrecios.CurrentRow.Index).Cells("txbFechaInicio").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            ElseIf mdlPublicVars.superSearchId = 2 Then
                Me.grdOtrosPrecios.Rows(Me.grdOtrosPrecios.CurrentRow.Index).Cells("txbFechaFinal").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fnAgregarFechaSucursal()
        Try
            If mdlPublicVars.superSearchId = 1 Then
                Me.grdOtrosPreciosSucursal.Rows(Me.grdOtrosPreciosSucursal.CurrentRow.Index).Cells("txbFechaInicio").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            ElseIf mdlPublicVars.superSearchId = 2 Then
                Me.grdOtrosPreciosSucursal.Rows(Me.grdOtrosPreciosSucursal.CurrentRow.Index).Cells("txbFechaFinal").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCosto.TextChanged
        Try
            fnLlenaPrecios()
            fnCalculaNormales()
            fnLlenaOtrosPrecios()
            fnCalculaOtros()
            fnConfiguracion()
            lblCostoProm.Text = lblCosto.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios2_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdOtrosPrecios2.CellEndEdit
        Try
            'Recorremos el grid de precios.
            Dim i
            Dim precio As Decimal = 0
            For i = 0 To Me.grdOtrosPrecios2.Rows.Count - 1
                precio = CType(Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value, Decimal)

                Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
                Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
            Next

            fnCalculaOtros()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar los sustitutos
    Private Sub fnLlenarSustitutos()
        Try
            'Codigo
            Dim codArt As Integer = CType(Me.txtCodigo.Text, Integer)
            Dim sustituto As tblSustituto = (From x In ctx.tblSustitutoes Where x.idarticulo = codArt Select x).FirstOrDefault

            If sustituto IsNot Nothing Then
                Dim consulta = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo Order By y.codigo1
                             Where x.idSustitutoCategoria = sustituto.idSustitutoCategoria And y.idArticulo <> codArt
                             Select ID = y.idArticulo, Codigo = y.codigo1, Nombre = y.nombre1, Marca = y.tblArticuloMarcaRepuesto.nombre, _
                             Costo = y.costoIVA, PrecioPublico = y.precioPublico, _
                             PrecioNormal = (From a In ctx.tblArticulo_TipoNegocio Where a.articulo = y.idArticulo And a.tipoNegocio = 6 Select a.tblArticulo.precioPublico * (100 - a.descuento) / 100).FirstOrDefault, _
                             PrecioA = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 1 Select a.precio).FirstOrDefault, _
                             PrecioB = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 2 Select a.precio).FirstOrDefault, _
                             PrecioOferta = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 3 Select a.precio).FirstOrDefault, _
                             Existencia = (From z In ctx.tblInventarios Where z.idArticulo = y.idArticulo Select z.saldo).FirstOrDefault).ToList

                Me.grdSustitutos.DataSource = consulta

            Else
                Me.grdSustitutos.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se maneja cada vez que se cambia de sustituto
    Private Sub grdSustitutos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSustitutos.SelectionChanged
        Try
            'Codigo articulo
            Dim codArt As Integer = Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("ID").Value
            fnLlenarPreciosSustitutos(codArt)
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar los precios del sustituto
    Private Sub fnLlenarPreciosSustitutos(ByVal codArt As Integer)
        Try
            Me.grdPreciosSustitutos.Rows.Clear()
            'Obtenemos los otros precios
            Dim listaPrecio As List(Of tblArticuloTipoPrecio) = (From x In ctx.tblArticuloTipoPrecios _
                                                                 Where x.bitEspecial = False).ToList
            Dim precio As tblArticuloTipoPrecio
            'Recorremos los precios
            For Each precio In listaPrecio
                'Seleccionamos el registro
                Dim pArt As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = codArt And x.tipoPrecio = precio.codigo _
                                                  Select x).FirstOrDefault

                'Creamos la fila
                Dim fila As Object() = Nothing

                If pArt IsNot Nothing Then
                    fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                            pArt.habilitado, Format(pArt.porcentaje / 100, mdlPublicVars.formatoPorcentaje), "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                            Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}

                Else
                    fila = {"0", precio.codigo, precio.nombre, "0.00", False, Format(precio.porcentaje / 100, mdlPublicVars.formatoPorcentaje), _
                            "0", False, False, "0", False, "", ""}

                End If
                'Agregamos la fila al grid
                Me.grdPreciosSustitutos.Rows.Add(fila)

            Next
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para manejar el cambio de articulo
    Private Sub cmbNombre1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombre1.SelectedValueChanged
        Try
            'Obtenemos el id del articulo
            Dim codArt As Integer = CType(cmbNombre1.SelectedValue, Integer)
            fnBuscaArticulo(codArt)
            fnUltimasVentas()
            fnUltimasCompras()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para posicionarse en el grid de articulos segun el codigo del producto
    Private Sub fnBuscaArticulo(ByVal codArt As Integer)
        Try
            'Variable utilizada para recorrer el grid
            Dim i

            'Variable utilizada temporalmente para guardar temporalmente el id de articulo
            Dim id As Integer = 0
            'Recorremos el grid
            For i = 0 To Me.grdDatos.Rows.Count - 1
                id = CType(grdDatos.Rows(i).Cells("Codigo").Value, Integer)

                If id = codArt Then
                    Me.grdDatos.Rows(i).IsSelected = True
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    'Funcion utilizada para llenar las ultimas compras del producto
    Private Sub fnUltimasCompras()
        Try
            Dim codArt As Integer = CInt(cmbNombre1.SelectedValue)
            Dim lista = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False And x.idArticulo = codArt _
                        Select Fecha = x.tblEntrada.fechaRegistro, Proveedor = x.tblEntrada.tblProveedor.negocio, Cantidad = x.cantidad, Costo = x.costoIVA _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

            Me.grdUltimasCompras.DataSource = lista
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar los precios de la competencia
    Private Sub fnPreciosCompetencia()
        Try
            'Obtenemos los precios de la competencia en base a el articulo
            Dim codArt As Integer = CInt(cmbNombre1.SelectedValue)

            Dim cons = (From x In ctx.tblPrecioCompetencias Where x.articulo = codArt _
                        Select Fecha = x.fechaRegistro, Cliente = x.tblCliente.Negocio, Precio = x.precio, Observacion = x.observacion _
                        Order By Fecha Descending)

            Me.grdPreciosCompe.DataSource = cons
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmProductoPrecio_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPriceLista.frm_llenarLista()
        frmProductoLista.frm_llenarLista()
    End Sub

    Private Sub grdOtrosPrecios_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdOtrosPrecios.CellDoubleClick
        fnFechas()
    End Sub

    Private Sub btnActualizarCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCosto.Click
        frmIngresaClave.Text = "Ingrese clave"
        frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
        frmIngresaClave.ShowDialog()
        frmIngresaClave.Dispose()
        If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) Then
            frmEditaCosto.Text = "Edita Costo"
            frmEditaCosto.articulo = CInt(cmbNombre1.SelectedValue)
            frmEditaCosto.StartPosition = FormStartPosition.CenterParent
            frmEditaCosto.ShowDialog()
            frmEditaCosto.Dispose()
            llenagrid()
        Else
            RadMessageBox.Show("La contraseña ingresada es incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End If
    End Sub


    Private Sub btnPrecioCompetencia_Click(sender As Object, e As EventArgs) Handles btnPrecioCompetencia.Click
        Try
            frmBuscarArticuloPrecioCompetencia.Text = "Precios Competencia"
            frmBuscarArticuloPrecioCompetencia.codigoArticulo = CType(txtCodigo.Text, Integer)
            frmBuscarArticuloPrecioCompetencia.bitBloquearCombo = False
            frmBuscarArticuloPrecioCompetencia.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmBuscarArticuloPrecioCompetencia)
            frmBuscarArticuloPrecioCompetencia.Dispose()
            fnPreciosCompetencia()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdOtrosPreciosSucursal_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdOtrosPreciosSucursal_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            'Si presionamos la tecla F2
            If e.KeyCode = Keys.F2 Then
                fnFechasSucursal()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para cuando se cambia de producto
    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        Try
            fnLlenaPrecios()
            fnCalculaNormales()
            fnLlenaOtrosPrecios()
            fnCalculaOtros()
            fnLlenarSustitutos()
            fnPreciosCompetencia()
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub
End Class