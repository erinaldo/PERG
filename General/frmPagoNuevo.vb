﻿Imports System.Linq
''Imports System.IO
''Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows

Public Class frmPagoNuevo

    Public anula As Boolean = False
    Public anularPago As Boolean = False
    Public modifica As Boolean = False
    Public codigoPagoDetalle As Integer = 0

    'Variables de estado
    Public bitSalida As Boolean = False
    Public bitEntrada As Boolean = False
    Public bitCliente As Boolean = False
    Public bitProveedor As Boolean = False

    Public codigoPagoModificar As Integer = 0 'Nos permite identificar el pago que vamos a modificar
    Public bitModificar As Boolean = False 'Para saber si va a ser modificacion
    Public montoModificar As Double 'monto a restar al modifcar el pago

    Public codigoES As Integer = 0
    Public codigoCP As Integer = 0

    Private _diasProgramado As Integer
    Private permiso As New clsPermisoUsuario

    'Private _bitPagoVentaPequenia As Boolean = False 'si es pago de venta pequenia


    Private tipoCambio As Double

    Public Property diasProgramado As Integer
        Get
            diasProgramado = _diasProgramado
        End Get
        Set(ByVal value As Integer)
            _diasProgramado = value
        End Set
    End Property

    Private Sub frmClientesPagoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        fnLlenarCombos()

        lblTotal.Text = "0"
        lblSaldoActual.Text = "0"
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "txmMonto")
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        If bitProveedor = True Then
            lblCP.Text = "Proveedor"
        Else
            lblCP.Text = "Cliente"
        End If

        lblEDirFac.Visible = bitCliente
        lblENomFac.Visible = bitCliente
        lblNomFac.Visible = bitCliente
        lblDirFac.Visible = bitCliente

        If diasProgramado > 0 Then
            lblEFechaLimite.Visible = True
            lblFechaLimite.Visible = True
            Dim fechaLimite As DateTime = CType(fnFecha_horaServidor(), DateTime).AddDays(diasProgramado)
            lblFechaLimite.Text = Format(fechaLimite, mdlPublicVars.formatoFecha)
        End If

        mdlPublicVars.fnGrid_iconos(grdProductos)

        If nm5Cambio.Visible = True Then
            fnTotalDolares()
        Else
            fnTotal()
        End If

        'modificar
        If bitModificar Then
            'si es cliente consulta y agrega el pago al detalle.
            If bitCliente = True Then
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                    Try
                        Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigoPagoModificar Select x).FirstOrDefault
                        Me.grdProductos.Rows.Add(pago.tipoPago, pago.cuenta, pago.documento, pago.monto, pago.fecha, pago.observacion)
                    Catch ex As Exception

                    End Try
                    conn.Close()
                End Using

                ''Ocultar Todo
                lblCambio.Visible = False
                nm5Cambio.Visible = False

                lblDocumento.Visible = False
                lblPago.Visible = False
                lblPagos.Visible = False
                cmbMovimiento.Visible = False
                lblSal.Visible = False
                lblSaldos.Visible = False
                lbldocumentofactura.Visible = False
                lbldocumentoboleta.Visible = False
                txtdocumentoboleta.Visible = False
                txtdocumentofactura.Visible = False

                ''Fin Ocultar Todo

            End If
        End If

        If bitCliente Then
            lblCambio.Visible = False
            nm5Cambio.Visible = False

            lblDocumento.Visible = False
            lblPago.Visible = False
            lblPagos.Visible = False
            cmbMovimiento.Visible = False
            lblSal.Visible = False
            lblSaldos.Visible = False
            lbldocumentofactura.Visible = False
            lbldocumentoboleta.Visible = False
            txtdocumentoboleta.Visible = False
            txtdocumentofactura.Visible = False
        End If

    End Sub

    Private Sub fnLlenarCombos()
        Me.grdProductos.Rows.Clear()
        If bitModificar = False Then
            Me.grdProductos.Rows.AddNew()
        End If

        Me.grdProductos.Select()

        lblTotal.Text = "0"
        'Me.grdProductos.AllowAddNewRow = True
        dtpFechaInicio.Text = mdlPublicVars.fnFecha_horaServidor
        Dim consulta = Nothing

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                If bitProveedor Then
                    consulta = (From x In conexion.tblProveedors Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In conexion.tblProveedors _
                               Order By x.negocio
                              Select codigo = x.idProveedor, nombre = x.negocio)

                ElseIf bitCliente Then
                    consulta = From y In (From x In conexion.tblClientes Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In conexion.tblClientes _
                               Select codigo = x.idCliente, nombre = Trim(x.Negocio) & " ( " & x.clave & " ) ").Union(From x In conexion.tblClientes Where Trim(x.Nombre1).Length > 0
                                                                                      Select Codigo = x.idCliente, Nombre = Trim(x.Nombre1) & " ( " & x.clave & " ) ")
                                                                                  Order By y.Nombre
                                                                                  Select y
                End If

                If bitProveedor Or bitCliente Then
                    With cmbCliente
                        .DataSource = Nothing
                        .ValueMember = "codigo"
                        .DisplayMember = "nombre"
                        .DataSource = consulta
                    End With
                End If

                If (bitProveedor = True Or bitCliente = True) And codigoCP > 0 Then
                    cmbCliente.SelectedValue = codigoCP
                End If

                If (bitProveedor = True Or bitCliente = True) And codigoCP > 0 And bitModificar = False Then
                    cmbCliente.Enabled = False
                Else
                    cmbCliente.Enabled = True
                End If

                Me.dtpFechaInicio.Focus()
                mdlPublicVars.comboActivarFiltro(cmbCliente)

                'Agregamos la columna al grid
                'Le asignamos el data source al grid
                If bitCliente = True Then
                    consulta = (From x In conexion.tblTipoPagoes Where x.entrada = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)
                ElseIf bitProveedor = True Then
                    consulta = (From x In conexion.tblTipoPagoes Where x.salida = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)
                End If

            Catch ex As Exception

            End Try
            conn.Close()
        End Using

       
        'agregar columna de tipo combo.
        Dim tipoPago As New GridViewComboBoxColumn()
        tipoPago.FieldName = "txmTipoPago"
        tipoPago.Name = "txmTipoPago"
        tipoPago.HeaderText = "Tipo de Pago"
        tipoPago.Width = 150
        With tipoPago
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = consulta
        End With


        Try
            'Agregamos la columna al grid
            Me.grdProductos.Columns.Add(tipoPago)
            'Movemos la columna
            Me.grdProductos.Columns.Move(Me.grdProductos.ColumnCount - 1, 0)
        Catch ex As Exception
            Console.WriteLine("Ya existe columna")
        End Try


    End Sub

    Private Sub fnTotal()

        Dim index
        Dim total As Double = 0
        Dim totalquetzal As Double = 0

        Dim saldo As Double = 0
        Dim saldoActual As Double = 0
        Dim enProceso As Decimal = CDbl(lblEnProceso.Text)
        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                total = total + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
                '  totalquetzal = totalquetzal + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
                total = total
            End If
        Next

        If IsNumeric(lblSaldo.Text) Then
            saldo = lblSaldo.Text
        Else
            saldo = 0
        End If


        If total > 0 Then
            saldoActual = saldo - total + enProceso
        Else
            saldoActual = saldo + Math.Abs(total) + enProceso
        End If



        'Mostrar resultados.
        If total <> 0 Then
            lblTotal.Text = total
        Else
            lblTotal.Text = 0
        End If

        If saldoActual <> 0 Then
            lblSaldoActual.Text = Format(saldoActual, mdlPublicVars.formatoMoneda)
        Else
            lblSaldoActual.Text = "0"
        End If
    End Sub

    Private Sub fnTotalDolares()

        Dim index
        Dim total As Double = 0
        Dim totalquetzal As Double = 0

        Dim saldo As Double = 0
        Dim saldoActual As Double = 0
        Dim enProceso As Decimal = CDbl(lblEnProceso.Text)
        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                total = total + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * 1)
                '  totalquetzal = totalquetzal + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
                total = total
            End If
        Next

        If IsNumeric(lblSaldo.Text) Then
            saldo = lblSaldo.Text
        Else
            saldo = 0
        End If


        If total > 0 Then
            saldoActual = saldo - total + enProceso
        Else
            saldoActual = saldo + Math.Abs(total) + enProceso
        End If



        'Mostrar resultados.
        If total <> 0 Then
            lblTotal.Text = Format(total, mdlPublicVars.formatoMonedaDolar)
        Else
            lblTotal.Text = 0
        End If

        If saldoActual <> 0 Then
            lblSaldoActual.Text = Format(saldoActual, mdlPublicVars.formatoMonedaDolar)
        Else
            lblSaldoActual.Text = "0"
        End If
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            If e.Column.Name = "observacion" Or e.Column.Name = "txmMonto" Then

                If nm5Cambio.Visible = True Then
                    fnTotalDolares()
                Else
                    fnTotal()
                End If

                'agregar fila
                Dim filas() As String

                'Verificamos si es necesario ingresar una fecha
                Dim idTipoPago As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmTipoPago").Value, Integer)

                If idTipoPago = Nothing Then
                    RadMessageBox.Show("Elija un tipo de pago", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                    Me.grdProductos.Columns("txmTipoPago").IsCurrent = True
                Else

                    Dim tipoPago As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = idTipoPago Select x).First
                    Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value
                    Dim monto = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmMonto").Value

                    If monto Is Nothing Or monto = 0 Then
                        RadMessageBox.Show("Debe ingresar una monto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                        Me.grdProductos.Columns("txmMonto").IsCurrent = True
                    Else
                        If tipoPago.prefechado = True And fecha = Nothing Then
                            RadMessageBox.Show("Debe ingresar una fecha", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                            Me.grdProductos.Columns("txbFecha").IsCurrent = True
                            frmFecha.Text = "Fecha"
                            frmFecha.opcionRetorno = "pagoNuevo"
                            frmFecha.StartPosition = FormStartPosition.CenterScreen
                            frmFecha.ShowDialog()
                        Else
                            'antes de agregar una fila verificar si la ultima es vacia para que no agregue otra.
                            If Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells("txmTipoPago").Value = "0" Then
                            Else
                                'Id, codigo,nombre,precio,cantidad
                                If bitModificar = False Then
                                    filas = {0, 0, "", "?", 0, ""}
                                    grdProductos.Rows.Add(filas)
                                    grdProductos.Columns("txmTipoPago").IsCurrent = True
                                    'grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                                    If Me.grdProductos.Rows.Count > 1 Then
                                        Me.grdProductos.AllowAddNewRow = False
                                    End If
                                End If

                            End If
                        End If
                    End If
                End If
            ElseIf e.Column.Name = "Fecha" Then
                'id, codigo,nombre,precio,cantidad
                Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value
                If fecha = Nothing Then
                Else
                    Dim filas As String()
                    filas = {0, 0, "", "?", 0, ""}
                    grdProductos.Rows.Add(filas)
                    grdProductos.Columns("txmTipoPago").IsCurrent = True
                    grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                End If
            ElseIf e.Column.Name.Equals("txmTipoPago") Then
                Dim idTipoPago As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmTipoPago").Value, Integer)
                Dim tipo As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = idTipoPago Select x).FirstOrDefault

                If tipo.tblBanco_Cuenta IsNot Nothing Then
                    'Establecemos la cuenta
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("Cuenta").Value = tipo.tblBanco_Cuenta.numeroCuenta & " (" & tipo.tblBanco_Cuenta.tblBanco.nombre & ")"
                End If

                If tipo.transito Then
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").ReadOnly = False
                Else
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").ReadOnly = True
                End If
            End If
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If

        Catch ex As Exception
            'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If e.KeyValue = Keys.Delete Then
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If

        End If
    End Sub

    'Funcion para agregar la fecha seleecionada
    Public Sub fnAgregarFecha()
        Try
            If mdlPublicVars.superSearchId = 1 Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value = mdlPublicVars.superSearchFecha.ToShortDateString
                If Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells("txmTipoPago").Value = "0" Then
                Else

                    'agregar una fila vacia.
                    Dim filas() As String
                    'Id, codigo,nombre,precio,cantidad
                    filas = {0, 0, "", "?", 0, ""}
                    grdProductos.Rows.Add(filas)
                    grdProductos.Columns(1).IsCurrent = True
                    grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                    If Me.grdProductos.Rows.Count > 1 Then
                        Me.grdProductos.AllowAddNewRow = False
                    End If
                End If
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnErrores() As Boolean
        Dim errores As Boolean = False
        Dim contenidoer As String = ""

        If Me.grdProductos.Rows.Count > 0 Then
        Else
            contenidoer = "Ingrese un pago"
            errores = True
        End If

        If nm5Cambio.Visible = True Then
            If nm5Cambio.Value <= 1 Then
                alerta.contenido = "Revise el Tipo de Cambio"
                alerta.fnErrorContenido()
                Return True
                Exit Function
            End If
        End If

        Dim index
        For index = 0 To Me.grdProductos.Rows.Count - 1
            'si la columna 0 de codigo
            Dim tipoPago As String = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, String)

            If tipoPago <> "0" Then

                If Me.grdProductos.Rows(index).Cells("txmTipoPago").Value.ToString.Length > 0 Then

                    If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                    Else
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If

                    If Me.grdProductos.Rows(index).Cells("txmMonto").Value = 0 Then
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If
                End If

                If tipoPago = "2" And bitModificar = False Then
                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim doc As String = Me.grdProductos.Rows(index).Cells("txmDocumento").Value

                        Dim nocheque As Integer = (From x In conexion.tblCajas Where x.documento.Equals(doc) And x.tipoPago = tipoPago Select x).Count

                        If nocheque = 0 Then
                        Else
                            errores = True
                            contenidoer = "El Cheque No." & Me.grdProductos.Rows(index).Cells("txmDocumento").Value & " ya esta registrado"
                        End If

                        conn.Close()
                    End Using
                End If

            End If
        Next

        Dim total

        If nm5Cambio.Visible Then
            total = CType(Me.lblTotal.Text, Double)
        Else

            total = CType(Me.lblTotal.Text, Double)

        End If



        If bitSalida = True Then
            If total > CType(lblSaldo.Text, Double) Then
                errores = True
                contenidoer = "Monto pagado es mayor al de entrada"
            End If
        End If

        If total <= 0 And bitSalida = True Then
            errores = True
            contenidoer = "Debe ingresar un pago"
        End If

        If errores = True Then
            alerta.contenido = contenidoer
            alerta.fnErrorContenido()
        End If

        Return errores
    End Function

    'Funcion utilizada para guardar el pago
    Private Sub fnGuardar()
        If fnErrores() = True Then
            Exit Sub
        End If

        If diasProgramado > 0 Then
            If fnPagosProgramados() = False Then
                Exit Sub
            End If
        End If

        'declarar variable de codcliente o codprove
        Dim codcliente As Integer

        'seleccionar el codigo de cliente.
        codcliente = CType(cmbCliente.SelectedValue, Integer)

        If codcliente = 0 Then
            If RadMessageBox.Show("Desea Guardar el Pago Sin Cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                Exit Sub
            End If
        End If

        Dim documento As String = ""
        Dim monto As Double = 0
        Dim tipoPago As Integer = 0
        Dim totalEfectivo As Double = 0
        Dim totalTransito As Double = 0


        'fecha y hora del servidor.
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()
      

        'variables de transaccion.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim observacion As String = ""

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope
                'inicio de excepcion
                Try
                    'paso 1, guardar el encabezado del pago
                    Dim index As Integer

                    'variable de pago modificado.
                    Dim PagoModificado As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigoPagoModificar Select x).FirstOrDefault() 'para modificar pago

                    'variable de cliente para moficiar el pagon (cliente anterior)
                    Dim clienteAnteriorModificar As tblCliente = (From x In conexion.tblClientes
                                                                  Join c In conexion.tblCajas On c.cliente Equals x.idCliente
                                                                  Where c.codigo = codigoPagoModificar Select x).FirstOrDefault

                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        '2do. obtener el tipo de pago
                        tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)

                        '3ro. verificar si tipo de pago es mayor a cero / si existe un tipo de pago.
                        If tipoPago > 0 Then
                            'Obtenemos el tipo de Pago
                            Dim pagoTipo As tblTipoPago = (From x In conexion.tblTipoPagoes.AsEnumerable
                                                           Where x.codigo = tipoPago Select x).FirstOrDefault

                            'obtener datos del grid
                            documento = Me.grdProductos.Rows(index).Cells("txmDocumento").Value
                            monto = Me.grdProductos.Rows(index).Cells("txmMonto").Value
                            observacion = Me.grdProductos.Rows(index).Cells("observacion").Value

                            Dim pago As New tblCaja ' para guardar pago 

                            If bitModificar = True Then  ' comparamos si es una modificacion de pago
                                'guardar temporalmente el monto 
                                montoModificar = PagoModificado.monto ' Capturamos el monto del pago para restarselo a pagos transito del cliente o proveedor

                                'guardar nuevos valores del pago.
                                PagoModificado.documento = If(documento Is Nothing, "", documento)
                                PagoModificado.anulado = 0
                                PagoModificado.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                PagoModificado.fechaTransaccion = fecha
                                PagoModificado.monto = monto
                                PagoModificado.afavor = monto
                                PagoModificado.consumido = 0
                                PagoModificado.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString
                                PagoModificado.tipoPago = tipoPago
                                PagoModificado.empresa = mdlPublicVars.idEmpresa
                                PagoModificado.usuario = mdlPublicVars.idUsuario
                                PagoModificado.observacion = observacion
                                PagoModificado.descripcion = pagoTipo.nombre
                                PagoModificado.bitRechazado = False

                                'agregar cuenta bancaria al pago.
                                If pagoTipo.cuenta IsNot Nothing Then
                                    PagoModificado.cuenta = pagoTipo.cuenta
                                    PagoModificado.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                                End If

                                'agregar configuracion de cliente
                                If bitCliente = True And codcliente > 0 Then

                                    '''''''''''''''SINO TIENE CLIENTE ASIGNADO''''''''''''''
                                    ' si el pago que se va a modificar no tiene cliente asignado
                                    If PagoModificado.cliente Is Nothing Then
                                        PagoModificado.cliente = codcliente
                                        PagoModificado.bitEntrada = True
                                        PagoModificado.bitSalida = False
                                    Else
                                        PagoModificado.cliente = codcliente
                                        PagoModificado.bitEntrada = True
                                        PagoModificado.bitSalida = False
                                    End If

                                    

                                    'agregar configuracion de proveedor
                                ElseIf bitProveedor = True And codcliente > 0 Then
                                    PagoModificado.proveedor = codcliente
                                    PagoModificado.bitEntrada = False
                                    PagoModificado.bitSalida = True

                                    'agregar configuracion de entrada
                                ElseIf bitEntrada = True And codcliente > 0 Then
                                    PagoModificado.codigoEntrada = codigoES

                                    'agregar configuracion de salida.
                                ElseIf bitSalida = True And codcliente > 0 Then
                                    PagoModificado.codigoSalida = codigoES


                                ElseIf bitCliente = True And codcliente = 0 Then
                                    PagoModificado.bitEntrada = True
                                    PagoModificado.bitSalida = True
                                End If


                                If pagoTipo.prefechado = True Then
                                    Dim f = Me.grdProductos.Rows(index).Cells("txbFecha").Value
                                    f = f.substring(0, 10)
                                    Dim fechaConfirma As DateTime = CType(f + " 00:00:00", DateTime)
                                    PagoModificado.fechaCobro = fechaConfirma
                                End If

                                If pagoTipo.calendarizada Then
                                    PagoModificado.transito = 1
                                    PagoModificado.confirmado = 0
                                Else
                                    PagoModificado.transito = 0
                                    PagoModificado.confirmado = 1
                                    PagoModificado.fechaCobro = fecha
                                End If

                                'Guardamos los cambios.
                                conexion.SaveChanges()
                            Else
                                'Si no es modificaion entramos a este bloque
                                'Creamos el registro
                                pago.documento = If(documento Is Nothing, "", documento)
                                pago.anulado = 0
                                pago.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                pago.fechaTransaccion = fecha
                                pago.monto = monto * nm5Cambio.Value
                                pago.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString
                                pago.tipoPago = tipoPago
                                pago.empresa = mdlPublicVars.idEmpresa
                                pago.usuario = mdlPublicVars.idUsuario
                                pago.observacion = observacion
                                pago.descripcion = pagoTipo.nombre
                                pago.bitRechazado = False
                                pago.consumido = 0
                                pago.afavor = monto
                                pago.codutilizado = 0
                                pago.documentofactura = Me.txtdocumentofactura.Text
                                pago.docboletadeposito = Me.txtdocumentoboleta.Text

                                If Me.cmbMovimiento.Visible = True Then
                                    If bitProveedor Then
                                        pago.identradapago = CInt(Me.cmbMovimiento.SelectedValue())
                                    ElseIf bitCliente Then
                                        ''pago.idsalidapago = CInt(Me.cmbMovimiento.SelectedValue())
                                    End If
                                End If

                                If pagoTipo.cuenta IsNot Nothing Then
                                    pago.cuenta = pagoTipo.cuenta
                                    pago.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                                End If

                                If bitCliente = True And codcliente > 0 Then
                                    pago.cliente = codcliente
                                    pago.bitEntrada = True
                                    pago.bitSalida = False
                                ElseIf bitProveedor = True And codcliente > 0 Then
                                    pago.proveedor = codcliente
                                    pago.bitEntrada = False
                                    pago.bitSalida = True
                                ElseIf bitEntrada = True And codcliente > 0 Then
                                    pago.codigoEntrada = codigoES
                                ElseIf bitSalida = True And codcliente > 0 Then
                                    pago.codigoSalida = codigoES
                                ElseIf bitCliente = True And codcliente = 0 Then
                                    pago.bitEntrada = True
                                    pago.bitSalida = True
                                End If


                                If pagoTipo.prefechado = True Then
                                    Dim f = Me.grdProductos.Rows(index).Cells("txbFecha").Value
                                    Dim fechaConfirma As DateTime = CType(f + " 00:00:00", DateTime)
                                    pago.fechaCobro = fechaConfirma
                                End If

                                If pagoTipo.calendarizada Then
                                    pago.transito = 1
                                    pago.confirmado = 0
                                Else
                                    pago.transito = 0
                                    pago.confirmado = 1
                                    pago.fechaCobro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                End If

                                conexion.AddTotblCajas(pago)
                                conexion.SaveChanges()



                            End If

                            'Fin de proceso de creacion de pago o Actualizacion.
                            'Decidimos que hacer dependiendo del tipo pago
                            'Si el pago es de una entrada (FACTURA)
                            If bitEntrada = True Then
                                Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigoES Select x).FirstOrDefault

                                If pagoTipo.calendarizada = True Then
                                    factura.pagosTransito += pago.monto
                                Else
                                    If factura.contado = True Then
                                        'Realizamos las transacciones correspondientes
                                        factura.saldo -= pago.monto
                                        factura.pagos += pago.monto
                                        If factura.saldo = 0 Then
                                            factura.pagado = 1
                                        End If
                                        conexion.SaveChanges()
                                    Else
                                        Dim montoPagar = pago.monto

                                        Dim listaSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                                                                  Where x.IdFactura = factura.IdFactura Select x).ToList
                                        Dim salida As tblSalida
                                        For Each salida In listaSalidas
                                            Dim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars
                                                                             Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                            If montoPagar > ctaCobrar.saldo Then
                                                montoPagar -= ctaCobrar.saldo
                                                ctaCobrar.saldo = 0
                                                ctaCobrar.cancelada = 1
                                            Else
                                                ctaCobrar.saldo -= montoPagar
                                                montoPagar = 0
                                            End If
                                        Next
                                        conexion.SaveChanges()
                                    End If
                                End If

                            ElseIf bitSalida = True Then

                                Dim codigo As Integer = Me.cmbMovimiento.SelectedValue()

                                Dim entrada As tblEntrada = (From x In conexion.tblEntradas
                                                             Where x.idEntrada = codigo Select x).FirstOrDefault
                                If pagoTipo.calendarizada = True Then

                                Else
                                    If entrada.contado = True Then
                                        'Realizamos las transacciones correspondientes
                                        entrada.saldo -= pago.monto
                                        entrada.pagos += pago.monto
                                        If entrada.saldo = 0 Then
                                            entrada.cancelado = 1
                                        End If
                                        'Else
                                        '    Dim montoPagar = pago.monto

                                        '    Dim ctaPagar As tblCtaPagar = (From x In conexion.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                                        '    If montoPagar > ctaPagar.saldo Then
                                        '        montoPagar -= ctaPagar.saldo
                                        '        ctaPagar.saldo = 0
                                        '        ctaPagar.cancelada = 1
                                        '    Else
                                        '        ctaPagar.saldo -= montoPagar
                                        '        montoPagar = 0
                                        '    End If
                                    End If
                                End If


                                'guardar los cambios.
                                conexion.SaveChanges()

                                'Si es un cliente ingresa en este bloque

                            ElseIf bitCliente = True And cmbCliente.SelectedValue > 0 Then

                                'obtener lista de cuentas por cobrar.
                                Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In conexion.tblCtaCobrars
                                                                                Where x.idCliente = pago.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList

                                'YOEL
                                Dim listasSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                                                           Where x.idCliente = pago.cliente And x.empacado And Not x.anulado _
                                                                           And x.saldo > 0
                                                                           Order By x.fechaDespachado Select x).ToList

                                'varible de una cta por cobrar.
                                Dim ctaCobrar As tblCtaCobrar
                                Dim salida As tblSalida
                                ''Dim bancocredito As New tblBanco_Creditos

                                'variable de cliente para guardar nuevo pago.
                                Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                                'variable de cliente para modificar el pago (cliente actual.)
                                Dim clienteNuevoModificar As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).FirstOrDefault
                                If pagoTipo.calendarizada = True Then
                                    'Comparamos si es midificacion
                                    If bitModificar = True Then
                                        If clienteAnteriorModificar Is Nothing Then
                                            '2. modificar solo el cliente nuevo.
                                            clienteNuevoModificar.pagosTransito = (clienteNuevoModificar.pagosTransito) + monto 'descontamos el monto anterior y le sumaos el montoactual
                                        Else
                                            '1ro. verificar si el cliente nuevo es igual al anterior
                                            If clienteAnteriorModificar.idCliente <> clienteNuevoModificar.idCliente Then
                                                '1.1. restar al cliente anterior
                                                clienteAnteriorModificar.pagosTransito -= montoModificar

                                                '1.2 incrementar al cliente nuevo.
                                                clienteNuevoModificar.pagosTransito += monto
                                            Else
                                                '2. modificar solo el cliente nuevo.
                                                clienteNuevoModificar.pagosTransito = (clienteNuevoModificar.pagosTransito - montoModificar) + monto 'descontamos el monto anterior y le sumaos el montoactual
                                            End If

                                        End If
                                    Else
                                        'incrementar al cliente porque es pago nuevo.
                                        cliente.pagosTransito += pago.monto
                                    End If
                                Else
                                    ' Si el pago no es calendarizada 
                                    Dim montoPagar = pago.monto

                                    ' Si es modificacion
                                    If bitModificar = True Then
                                        If clienteAnteriorModificar Is Nothing Then
                                            'si es no tenia cliente asignado
                                            ' clienteNuevoModificar.pagosTransito = (clienteNuevoModificar.pagosTransito - montoModificar) 'Actualizamos el pago en transito descontando el montomodificar 
                                            clienteNuevoModificar.pagos += monto 'actualizamos lo pagos
                                            clienteNuevoModificar.saldo -= monto
                                        Else
                                            '1ro. verificar si el cliente nuevo es igual al anterior
                                            If clienteAnteriorModificar.idCliente <> clienteNuevoModificar.idCliente Then
                                                '1.1. restar al cliente anterior
                                                clienteAnteriorModificar.pagosTransito -= montoModificar
                                                '1.2. actualizamos lo pagos
                                                clienteNuevoModificar.pagos += monto
                                                '1.3. 'actualiza el saldo del cliente.
                                                clienteNuevoModificar.saldo -= monto

                                            Else
                                                'si es el mismo cliente
                                                clienteNuevoModificar.pagosTransito = (clienteNuevoModificar.pagosTransito - montoModificar) 'Actualizamos el pago en transito descontando el montomodificar 
                                                clienteNuevoModificar.pagos += monto 'actualizamos lo pagos
                                                clienteNuevoModificar.saldo -= monto
                                            End If

                                        End If
                                    Else ' pago nuevo
                                        cliente.pagos += pago.monto
                                        cliente.saldo -= pago.monto

                                        'actualizamos la fecha de ultimoPago del clinte
                                        cliente.fechaUltimoPago = pago.fechaCobro
                                    End If
                                    'Guardar los cambios.
                                    conexion.SaveChanges()

                                    ''bancocredito.usuarioRegistra = mdlPublicVars.idUsuario
                                    ''bancocredito.fechaRegistro = fecha
                                    ''bancocredito.documento = pago.documento
                                    ''bancocredito.correlativo = pago.codigo
                                    ''bancocredito.correlativo = pago.cuenta
                                    ''bancocredito.concepto = pago.observacion
                                    ''bancocredito.monto = pago.monto
                                    ''bancocredito.bitConfirmado = pago.confirmado
                                    ''bancocredito.fechaConfirmado = fecha
                                    ''bancocredito.usuarioConfirma = pago.usuario
                                    ''bancocredito.bitAnulado = pago.anulado
                                    ''bancocredito.fechaAnulado = pago.fechaAnulado

                                    ''conexion.AddTotblBanco_Creditos(bancocredito)
                                    ''conexion.SaveChanges()

                                    Dim montoPagar2 As Decimal = montoPagar
                                    For Each ctaCobrar In listasCtaCobrar
                                        If montoPagar > ctaCobrar.saldo Then
                                            montoPagar -= ctaCobrar.saldo
                                            ctaCobrar.pagado += ctaCobrar.saldo
                                            ctaCobrar.saldo = 0
                                            ctaCobrar.cancelada = 1
                                        Else
                                            ctaCobrar.saldo -= montoPagar
                                            ctaCobrar.pagado += montoPagar
                                            montoPagar = 0
                                        End If
                                    Next

                                    'Modificamos las salidas
                                    Dim consumido As Decimal = 0
                                    For Each salida In listasSalidas
                                        If montoPagar2 = 0 Then
                                            Exit For
                                        End If
                                        Dim detallePago As New tblCajaSalida
                                        detallePago.idCaja = pago.codigo
                                        detallePago.idSalida = salida.idSalida
                                        detallePago.idCliente = cliente.idCliente
                                        detallePago.fechaRegistro = fecha
                                        detallePago.fechaFiltro = fecha

                                        If montoPagar2 > salida.saldo Then
                                            detallePago.monto = salida.saldo
                                            detallePago.saldoNuevo = 0
                                            detallePago.saldoSalida = salida.saldo

                                            montoPagar2 -= salida.saldo
                                            salida.pagado += salida.saldo
                                            salida.saldo = 0
                                        Else
                                            detallePago.monto = montoPagar2
                                            detallePago.saldoNuevo = (salida.saldo - montoPagar2)
                                            detallePago.saldoSalida = salida.saldo

                                            salida.saldo -= montoPagar2
                                            salida.pagado += montoPagar2
                                            montoPagar2 = 0
                                        End If
                                        consumido += detallePago.monto
                                        conexion.AddTotblCajaSalidas(detallePago)
                                        conexion.SaveChanges()
                                    Next
                                    pago.consumido += consumido
                                    pago.afavor -= consumido
                                End If

                                'guardar los cambios.
                                conexion.SaveChanges()

                                '' ''Ejecuta el SP para ajustar el saldo del cliente
                                ''Try
                                ''    Dim consulta = Nothing
                                ''    consulta = conexion.sp_herramientas_clienteSaldosIndividual(cliente.idCliente)
                                ''Catch ex As Exception
                                ''    RadMessageBox.Show("Ocurrio un Error al Actualizar el Saldo del Cliente!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                ''End Try

                                'Sis es proveedor entra en este bloque
                            ElseIf bitProveedor = True And cmbCliente.SelectedValue > 0 Then
                                Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                                If proveedor.procedencia = 1 Then
                                    If pagoTipo.calendarizada = True Then
                                        proveedor.pagosTransito += pago.monto
                                    Else
                                        Dim montoPagar = pago.monto
                                        proveedor.pagos += pago.monto
                                        proveedor.saldoActual -= pago.monto
                                        Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars
                                                                                     Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                        Dim ctaPagar As tblCtaPagar

                                        For Each ctaPagar In listaCtaPagar

                                            If montoPagar > ctaPagar.saldo Then
                                                montoPagar -= ctaPagar.saldo
                                                ctaPagar.pagado = ctaPagar.monto
                                                ctaPagar.saldo = 0
                                                ctaPagar.cancelada = 1
                                            Else
                                                ctaPagar.saldo -= montoPagar
                                                ctaPagar.pagado += montoPagar
                                                montoPagar = 0
                                            End If
                                        Next
                                    End If

                                    ''Descuento de la tabla de entradas para las cuentas por pagar Macora

                                    Dim filas As Integer = Me.grdProductos.Rows.Count - 1
                                    Dim pagoprov As Double
                                    Dim proveedorpago As Integer = Me.cmbCliente.SelectedValue

                                    For fil As Integer = 0 To filas
                                        Try
                                            pagoprov = Me.grdProductos.Rows(fil).Cells("txmMonto").Value
                                        Catch ex As Exception
                                            pagoprov = 0
                                        End Try

                                        If pagoprov > 0 And cmbMovimiento.SelectedValue = 0 Then
                                            While pagoprov > 0

                                                Dim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = proveedorpago And x.saldo > 0 And x.anulado = False Order By x.fechaRegistro Select x).Take(1).FirstOrDefault

                                                If entradaspendientes Is Nothing Then
                                                    Exit While
                                                End If

                                                If pagoprov > entradaspendientes.saldo Then

                                                    pagoprov -= entradaspendientes.saldo
                                                    entradaspendientes.saldo = 0
                                                    entradaspendientes.pagos = entradaspendientes.total

                                                ElseIf pagoprov <= entradaspendientes.saldo Then

                                                    entradaspendientes.saldo -= pagoprov
                                                    entradaspendientes.pagos += pagoprov
                                                    pagoprov = 0

                                                End If

                                                conexion.SaveChanges()

                                            End While
                                        ElseIf pagoprov > 0 And cmbMovimiento.SelectedValue > 0 Then
                                            While pagoprov > 0
                                                Dim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = proveedorpago And x.saldo > 0 And x.anulado = False And x.idEntrada = Me.cmbMovimiento.SelectedValue Select x).FirstOrDefault

                                                entradaspendientes.saldo -= pagoprov
                                                entradaspendientes.pagos += pagoprov
                                                pagoprov = 0

                                            End While
                                        End If

                                    Next



                                    ''Finalizacion del descuento de saldos para las cuentas por pagar de macora

                                    'guardar los cambios
                                    conexion.SaveChanges()

                                    'Modificaciones
                                    ' Sis es proveedore Extranjero e
                                ElseIf proveedor.procedencia = 2 Then

                                    If pagoTipo.calendarizada = True Then

                                        If proveedor.pagosTransitoDolar Is Nothing Then
                                            proveedor.pagosTransitoDolar = monto

                                            If proveedor.saldoDolar Is Nothing Then
                                                proveedor.saldoDolar = monto
                                            Else
                                                proveedor.saldoDolar += monto
                                            End If

                                            If proveedor.pagosTransito Is Nothing Then
                                                proveedor.pagosTransito = pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                            Else
                                                proveedor.pagosTransito += pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                            End If


                                        Else
                                            proveedor.pagosTransitoDolar += monto

                                            If proveedor.saldoDolar Is Nothing Then
                                                proveedor.saldoDolar = monto
                                            Else
                                                proveedor.saldoDolar += monto
                                            End If

                                            If proveedor.pagosTransito Is Nothing Then
                                                proveedor.pagosTransito = monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                            Else
                                                proveedor.pagosTransito += monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                            End If

                                            If Me.cmbMovimiento.SelectedValue > 0 Then
                                                Try

                                                    Dim identrada As Integer = Me.cmbMovimiento.SelectedValue
                                                    Dim idproveedor As Integer = Me.cmbCliente.SelectedValue

                                                    Dim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = idproveedor And x.saldo > 0 And x.anulado = False And x.idEntrada = identrada Select x).FirstOrDefault

                                                    entradaspendientes.saldo -= monto
                                                    entradaspendientes.pagos += monto
                                                    monto = 0

                                                    conexion.SaveChanges()

                                                Catch ex As Exception

                                                End Try
                                            End If


                                        End If
                                        proveedor.saldoActual -= monto * Convert.ToDecimal(nm5Cambio.Value).ToString

                                    Else
                                        Dim montoPagar = monto

                                        If proveedor.pagosDolar Is Nothing Then
                                            proveedor.pagosDolar = monto
                                            proveedor.saldoDolar = monto
                                        Else
                                            proveedor.pagosDolar += monto
                                            proveedor.saldoDolar -= monto
                                        End If
                                        proveedor.saldoActual -= monto * Convert.ToDecimal(nm5Cambio.Value).ToString


                                        If Me.cmbMovimiento.SelectedValue > 0 Then
                                            Try

                                                Dim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = CInt(Me.cmbCliente.SelectedValue) And x.saldo > 0 And x.anulado = False And x.idEntrada = CInt(Me.cmbMovimiento.SelectedValue) Select x).FirstOrDefault

                                                entradaspendientes.saldo -= monto
                                                entradaspendientes.pagos += monto
                                                monto = 0

                                            Catch ex As Exception

                                            End Try
                                        End If


                                        Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                        Dim ctaPagar As tblCtaPagar

                                        For Each ctaPagar In listaCtaPagar

                                            If montoPagar > ctaPagar.saldo Then
                                                montoPagar -= ctaPagar.saldo
                                                ctaPagar.pagado = ctaPagar.monto
                                                ctaPagar.saldo = 0
                                                ctaPagar.cancelada = 1
                                            Else
                                                ctaPagar.saldo -= montoPagar
                                                ctaPagar.pagado += montoPagar
                                                montoPagar = 0
                                            End If
                                        Next
                                    End If

                                    conexion.SaveChanges()    ' verificar si va aqui. inicialmente estaba aqui
                                End If

                                conexion.SaveChanges() ' verificar si va aqui. inicialmente estaba aqui

                            End If


                            fecha = fecha.AddSeconds(1)
                        End If
                    Next
                    'generar un recibo de caja de pago, con el detalle de pago.

                    conexion.SaveChanges()

                    'paso 8, completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    success = False
                Catch ex As Exception
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        success = False
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()

            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion.
            conn.Close()

            'finalizar el proceso.
        End Using


        If success = True Then

            If RadMessageBox.Show("Desea realizar nuevo pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                bitModificar = False
                fnLlenarCombos()
                Me.dtpFechaInicio.Focus()
                If nm5Cambio.Visible = True Then
                    fnTotalDolares()
                Else
                    fnTotal()
                End If


            Else
                bitCliente = False   'agregado 
                bitProveedor = False 'agregado
                Me.Close()
            End If
        End If

    End Sub

    'GUARDAR
    Private Sub fnGuardar_Click() Handles Me.panel0
        Try
            fnGuardar()
        Catch ex As Exception

        End Try
    End Sub

    'DETALLE DE SALDO
    Private Sub fnDetalle() Handles Me.panel1
        Try
            Dim codigo As Integer = CInt(cmbCliente.SelectedValue)
            Dim saldo As Decimal = lblSaldo.Text
            If bitProveedor = True Then
                frmDetalleSaldo.lblCP.Text = "Proveedor :"
                frmDetalleSaldo.Text = "Saldo Proveedor"
                frmDetalleSaldo.codigo = codigo
                frmDetalleSaldo.bitProveedor = True
                frmDetalleSaldo.bitCliente = False
                frmDetalleSaldo.saldo = saldo
                frmDetalleSaldo.StartPosition = FormStartPosition.CenterScreen
                frmDetalleSaldo.ShowDialog()
                frmDetalleSaldo.Dispose()
            ElseIf bitCliente = True Then
                frmDetalleSaldo.lblCP.Text = "Cliente :"
                frmDetalleSaldo.Text = "Detalle Cliente"
                frmDetalleSaldo.codigo = codigo
                frmDetalleSaldo.bitProveedor = False
                frmDetalleSaldo.bitCliente = True
                frmDetalleSaldo.saldo = saldo
                frmDetalleSaldo.StartPosition = FormStartPosition.CenterScreen
                frmDetalleSaldo.ShowDialog()
                frmDetalleSaldo.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'ESTADO DE CUENTA
    Private Sub fnEstadoCuentas() Handles Me.panel2
        Try
            Dim codigo As Integer = CInt(cmbCliente.SelectedValue)
            If bitCliente = True Then
                frmClienteEstadoCuenta.Text = "Estado de Cuenta"
                frmClienteEstadoCuenta.cliente = codigo
                frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmClienteEstadoCuenta.BringToFront()
                frmClienteEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
                frmClienteEstadoCuenta.Dispose()
            ElseIf bitProveedor = True Then
                frmProveedorEstadoCuenta.Text = "Estado de Cuenta"
                frmProveedorEstadoCuenta.proveedor = codigo
                frmProveedorEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmProveedorEstadoCuenta.BringToFront()
                frmProveedorEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmProveedorEstadoCuenta)
                frmProveedorEstadoCuenta.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'PAGOS SIN CONFIRMAR
    Private Sub fnBoletasNoConfirmadas() Handles Me.panel3
        Try
            frmPagosSinConfirmar.Text = "Pagos Sin Confirmar"
            frmPagosSinConfirmar.bitCliente = True
            frmPagosSinConfirmar.bitProveedor = False
            frmPagosSinConfirmar.codigo = cmbCliente.SelectedValue
            frmPagosSinConfirmar.StartPosition = FormStartPosition.CenterScreen
            frmPagosSinConfirmar.BringToFront()
            frmPagosSinConfirmar.Focus()
            permiso.PermisoDialogEspeciales(frmPagosSinConfirmar)
            frmProveedorEstadoCuenta.Dispose()
        Catch ex As Exception
            alerta.fnError()
        End Try

    End Sub

    'SALIR
    Private Sub pbx1Salir_Click() Handles Me.panel4
        Me.Close()
    End Sub
    '3184

    Private Sub cmbCliente_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        If CInt(cmbCliente.SelectedValue) > 0 Then

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


                'codigo para CLIENTES.
                If bitCliente = True Then

                    Dim codigo As Integer = cmbCliente.SelectedValue
                    Dim c As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codigo Select x).FirstOrDefault
                    If c.saldo <> 0 Then
                        lblSaldo.Text = Format(c.saldo, mdlPublicVars.formatoMoneda)
                    Else
                        lblSaldo.Text = 0
                    End If

                    Dim salidas As Double
                    Try
                        salidas = (From x In conexion.tblSalidas Where x.idCliente = codigo And x.anulado = False _
                                   And x.facturado = False And x.despachar = True And x.saldo > 0 _
                                   Select x.saldo).Sum
                    Catch ex As Exception
                        salidas = 0
                    End Try

                    lblEnProceso.Text = Format(salidas, mdlPublicVars.formatoMoneda)

                    'Obtenemos la informacion del cliente
                    lblNomFac.Text = c.Nombre1
                    lblDirFac.Text = c.direccionFactura1

                Else
                    lblNomFac.Text = ""
                    lblDirFac.Text = ""

                End If

                '' Codigo para Proveedores
                If bitProveedor = True Then
                    Dim codigo As Integer = cmbCliente.SelectedValue
                    Dim c As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault

                    If c.saldoActual <> 0 Then
                        lblSaldo.Text = Format(c.saldoActual, mdlPublicVars.formatoMoneda)
                    Else
                        lblSaldo.Text = 0
                    End If

                    'procediencia, codigo =2 es extranjero.
                    If c.tblProveedorProcedencia.codigo = 2 Then
                        lblCambio.Visible = True
                        nm5Cambio.Visible = True

                        lblDocumento.Visible = True
                        lblPago.Visible = True
                        lblPagos.Visible = True
                        cmbMovimiento.Visible = True
                        lblSal.Visible = True
                        lblSaldos.Visible = True
                        lbldocumentofactura.Visible = True
                        lbldocumentoboleta.Visible = True
                        txtdocumentoboleta.Visible = True
                        txtdocumentofactura.Visible = True

                        fnllenaComboMovimientos()
                    Else
                        lblCambio.Visible = False
                        nm5Cambio.Visible = False

                        lblDocumento.Visible = False
                        lblPago.Visible = False
                        lblPagos.Visible = False
                        cmbMovimiento.Visible = False
                        lblSal.Visible = False
                        lblSaldos.Visible = False

                        lbldocumentofactura.Visible = True
                        lbldocumentoboleta.Visible = True
                        txtdocumentoboleta.Visible = True
                        txtdocumentofactura.Visible = True
                    End If


                End If

                'Cerrar la conexion.
                conn.Close()

                'finalizar el proceso.
            End Using


            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If
        Else
            lblNomFac.Text = ""
            lblDirFac.Text = ""

            lblCambio.Visible = False
            nm5Cambio.Visible = False
        End If
    End Sub

    Private Sub fnLlenaComboMovimientos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim proveedor As Integer = Me.cmbCliente.SelectedValue()

                ''Dim mov = (From x In conexion.tblEntradas Where x.saldo > 0 And x.anulado = 0 And x.idProveedor = proveedor Select Codigo = 0, Nombre = "Ninguno").Union(From x In conexion.tblEntradas Where x.saldo > 0 And x.anulado = 0 And x.idProveedor = proveedor Select Codigo = x.idEntrada, Nombre = CStr(x.serieDocumento & "-" & x.documento))

                ''Dim mov = (From x In conexion.tblArticuloTipoPrecios Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)

                Dim mov = (From x In conexion.tblEntradas Select Codigo = CInt(0), Nombre = "Ningun Documento").Union(From x In conexion.tblEntradas Where x.idProveedor = proveedor And x.saldo > 0 And x.anulado = False Select Codigo = CInt(x.idEntrada), Nombre = CStr(x.serieDocumento & "-" & x.documento))

                With cmbMovimiento
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = mov
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        Me.cmbMovimiento.SelectedValue = 0
    End Sub

    Private Sub frmPagoNuevo_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPagosLista.frm_llenarLista()
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        If grdProductos.Rows.Count = 0 Then
            Me.grdProductos.Rows.AddNew()
        End If
    End Sub

    'Funcion utilizada para verificar los dias de programacion de cada pago
    Private Function fnPagosProgramados() As Boolean
        Dim fechaPago As DateTime = Nothing
        Dim fechaLimite As DateTime = fnFecha_horaServidor()
        fechaLimite = fechaLimite.AddDays(diasProgramado)

        'Recorremos el grid
        Dim tipoPago As Integer
        For index As Integer = 0 To Me.grdProductos.RowCount - 1
            tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)
            fechaPago = CType(Me.grdProductos.Rows(index).Cells("txbFecha").Value, DateTime)
            If tipoPago > 0 Then
                'Obtenemos el tipo de Pago
                Dim pagoTipo As tblTipoPago = (From x In ctx.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault
                If pagoTipo.transito = True Then
                    If fechaPago > fechaLimite Then
                        alerta.contenido = "Debe ingresar una fecha menor o igual a la fecha limite!"
                        alerta.fnErrorContenido()
                        Me.grdProductos.Rows(index).IsCurrent = True
                        Me.grdProductos.Columns("txbFecha").IsCurrent = True
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Sub btnDetalleVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleVentas.Click
        If bitCliente Then
            If cmbCliente.SelectedValue > 0 Then
                frmDetalleVentasPagos.Text = "Ventas"
                frmDetalleVentasPagos.bitVentas = False
                frmDetalleVentasPagos.bitPagos = True
                frmDetalleVentasPagos.cliente = CInt(cmbCliente.SelectedValue)
                frmDetalleVentasPagos.total = CDec(lblEnProceso.Text)
                frmDetalleVentasPagos.StartPosition = FormStartPosition.CenterScreen
                frmDetalleVentasPagos.ShowDialog()
                frmDetalleVentasPagos.Dispose()
            Else
                alerta.contenido = "Seleccionar un Cliente"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    Private Sub grdProductos_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles grdProductos.CellFormatting
        mdlPublicVars.GridColor_fila(2, e, Color.Blue)
    End Sub

  
    Private Sub nm5Cambio_ValueChanged(sender As Object, e As EventArgs) Handles nm5Cambio.ValueChanged
        tipoCambio = nm5Cambio.Value
        If nm5Cambio.Visible = True And nm5Cambio.Value > 1 Then
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If
        End If
    End Sub

    Private Sub cmbMovimiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMovimiento.SelectedValueChanged
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codigo As Integer = Me.cmbMovimiento.SelectedValue()

                Dim saldos = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x.saldo).FirstOrDefault
                Dim pago = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x.pagos).FirstOrDefault

                Me.lblSaldos.Text = Format(saldos, formatoMonedaDolar)
                Me.lblPagos.Text = Format(pago, formatoMonedaDolar)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class