﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedorDevolucion
    Inherits laFuente.FrmBaseEspeciales

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedorDevolucion))
        Me.pbBuscarProducto = New System.Windows.Forms.PictureBox()
        Me.lblProductos = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rgbPago = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMovimientos = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.chkAcreditado = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCompras = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.rgbProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblRecuento = New System.Windows.Forms.Label()
        Me.lblRecuentoDevolver = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Guardar = New System.Windows.Forms.Panel()
        Me.pbx1Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl1Guardar = New System.Windows.Forms.Label()
        Me.pnx0Nuevo = New System.Windows.Forms.Panel()
        Me.pbx0Nuevo = New System.Windows.Forms.PictureBox()
        Me.lbl0Nuevo = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBuscarProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbPago.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbProductos.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Guardar.SuspendLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Nuevo.SuspendLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pbBuscarProducto
        '
        Me.pbBuscarProducto.Image = Global.laFuente.My.Resources.Resources.buscar_Negro
        Me.pbBuscarProducto.Location = New System.Drawing.Point(31, 227)
        Me.pbBuscarProducto.Name = "pbBuscarProducto"
        Me.pbBuscarProducto.Size = New System.Drawing.Size(40, 33)
        Me.pbBuscarProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBuscarProducto.TabIndex = 111
        Me.pbBuscarProducto.TabStop = False
        '
        'lblProductos
        '
        Me.lblProductos.AutoSize = True
        Me.lblProductos.BackColor = System.Drawing.Color.Transparent
        Me.lblProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductos.ForeColor = System.Drawing.Color.DimGray
        Me.lblProductos.Location = New System.Drawing.Point(63, 231)
        Me.lblProductos.Name = "lblProductos"
        Me.lblProductos.Size = New System.Drawing.Size(138, 29)
        Me.lblProductos.TabIndex = 110
        Me.lblProductos.Text = " Productos"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.dinero_gris
        Me.PictureBox5.Location = New System.Drawing.Point(779, 52)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(52, 46)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 114
        Me.PictureBox5.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(822, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 29)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Total "
        '
        'rgbPago
        '
        Me.rgbPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbPago.BackColor = System.Drawing.Color.Transparent
        Me.rgbPago.Controls.Add(Me.lblTotal)
        Me.rgbPago.FooterImageIndex = -1
        Me.rgbPago.FooterImageKey = ""
        Me.rgbPago.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbPago.HeaderImageIndex = -1
        Me.rgbPago.HeaderImageKey = "dinero.png"
        Me.rgbPago.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbPago.HeaderText = ""
        Me.rgbPago.Location = New System.Drawing.Point(760, 73)
        Me.rgbPago.Name = "rgbPago"
        Me.rgbPago.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbPago.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbPago.Size = New System.Drawing.Size(318, 148)
        Me.rgbPago.TabIndex = 119
        Me.rgbPago.ThemeName = "radGroupBoxAzul"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(5, 41)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(303, 54)
        Me.lblTotal.TabIndex = 80
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(25, 56)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 118
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(63, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 32)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Informacion"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.BackColor = System.Drawing.Color.Transparent
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.cmbMovimientos)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.txtCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.chkAcreditado)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.cmbCompras)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.cmbProveedor)
        Me.rgbInformacion.Controls.Add(Me.Label17)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.txtObservacion)
        Me.rgbInformacion.Controls.Add(Me.Label20)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 73)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(742, 148)
        Me.rgbInformacion.TabIndex = 116
        Me.rgbInformacion.ThemeName = "radGroupBoxAzul"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(7, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Movimiento :"
        '
        'cmbMovimientos
        '
        Me.cmbMovimientos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMovimientos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMovimientos.FormattingEnabled = True
        Me.cmbMovimientos.Location = New System.Drawing.Point(87, 93)
        Me.cmbMovimientos.Name = "cmbMovimientos"
        Me.cmbMovimientos.Size = New System.Drawing.Size(290, 21)
        Me.cmbMovimientos.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Correlativo :"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCorrelativo.Enabled = False
        Me.txtCorrelativo.Location = New System.Drawing.Point(87, 44)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(103, 20)
        Me.txtCorrelativo.TabIndex = 1
        Me.txtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkAcreditado
        '
        Me.chkAcreditado.AutoSize = True
        Me.chkAcreditado.Enabled = False
        Me.chkAcreditado.Location = New System.Drawing.Point(438, 18)
        Me.chkAcreditado.Name = "chkAcreditado"
        Me.chkAcreditado.Size = New System.Drawing.Size(82, 17)
        Me.chkAcreditado.TabIndex = 5
        Me.chkAcreditado.Text = "Acreditado"
        Me.chkAcreditado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(28, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Compra :"
        '
        'cmbCompras
        '
        Me.cmbCompras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompras.FormattingEnabled = True
        Me.cmbCompras.Location = New System.Drawing.Point(87, 117)
        Me.cmbCompras.Name = "cmbCompras"
        Me.cmbCompras.Size = New System.Drawing.Size(290, 21)
        Me.cmbCompras.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(16, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Proveedor :"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(87, 67)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(290, 21)
        Me.cmbProveedor.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(39, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Fecha :"
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(87, 18)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(103, 20)
        Me.dtpFechaRegistro.TabIndex = 0
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.Location = New System.Drawing.Point(438, 56)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(291, 82)
        Me.txtObservacion.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(441, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "Observacion :"
        '
        'rgbProductos
        '
        Me.rgbProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbProductos.BackColor = System.Drawing.Color.Transparent
        Me.rgbProductos.Controls.Add(Me.lblRecuento)
        Me.rgbProductos.Controls.Add(Me.lblRecuentoDevolver)
        Me.rgbProductos.Controls.Add(Me.Label7)
        Me.rgbProductos.Controls.Add(Me.PictureBox3)
        Me.rgbProductos.Controls.Add(Me.grdProductos)
        Me.rgbProductos.Controls.Add(Me.Label24)
        Me.rgbProductos.FooterImageIndex = -1
        Me.rgbProductos.FooterImageKey = ""
        Me.rgbProductos.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbProductos.HeaderImageIndex = -1
        Me.rgbProductos.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbProductos.HeaderText = ""
        Me.rgbProductos.Location = New System.Drawing.Point(12, 243)
        Me.rgbProductos.Name = "rgbProductos"
        Me.rgbProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbProductos.Size = New System.Drawing.Size(1065, 329)
        Me.rgbProductos.TabIndex = 115
        Me.rgbProductos.ThemeName = "radGroupBoxAzul"
        '
        'lblRecuento
        '
        Me.lblRecuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecuento.AutoSize = True
        Me.lblRecuento.BackColor = System.Drawing.Color.Transparent
        Me.lblRecuento.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecuento.Location = New System.Drawing.Point(1024, 2)
        Me.lblRecuento.Name = "lblRecuento"
        Me.lblRecuento.Size = New System.Drawing.Size(23, 25)
        Me.lblRecuento.TabIndex = 122
        Me.lblRecuento.Text = "0"
        '
        'lblRecuentoDevolver
        '
        Me.lblRecuentoDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecuentoDevolver.AutoSize = True
        Me.lblRecuentoDevolver.BackColor = System.Drawing.Color.Transparent
        Me.lblRecuentoDevolver.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecuentoDevolver.Location = New System.Drawing.Point(893, 3)
        Me.lblRecuentoDevolver.Name = "lblRecuentoDevolver"
        Me.lblRecuentoDevolver.Size = New System.Drawing.Size(23, 25)
        Me.lblRecuentoDevolver.TabIndex = 121
        Me.lblRecuentoDevolver.Text = "0"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(729, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 21)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Productos a Devolver :"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.circulo_verde
        Me.PictureBox3.Location = New System.Drawing.Point(691, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(30, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 122
        Me.PictureBox3.TabStop = False
        '
        'grdProductos
        '
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(10, 28)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.HeaderText = "iddetalle"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "iddetalle"
        GridViewTextBoxColumn2.HeaderText = "detalleEntrada"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "idDetalleEntrada"
        GridViewTextBoxColumn3.HeaderText = "Id"
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "Id"
        GridViewTextBoxColumn4.HeaderText = "Cantidad Comprada"
        GridViewTextBoxColumn4.Name = "cantidadComprada"
        GridViewTextBoxColumn4.ReadOnly = True
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn4.Width = 112
        GridViewTextBoxColumn5.HeaderText = "Codigo"
        GridViewTextBoxColumn5.Name = "Codigo"
        GridViewTextBoxColumn5.ReadOnly = True
        GridViewTextBoxColumn5.Width = 84
        GridViewTextBoxColumn6.HeaderText = "Articulo"
        GridViewTextBoxColumn6.Name = "txbProducto"
        GridViewTextBoxColumn6.ReadOnly = True
        GridViewTextBoxColumn6.Width = 322
        GridViewTextBoxColumn7.HeaderText = "Cantidad"
        GridViewTextBoxColumn7.Name = "txmCantidad"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn7.Width = 102
        GridViewTextBoxColumn8.HeaderText = "Costo"
        GridViewTextBoxColumn8.Name = "Costo"
        GridViewTextBoxColumn8.ReadOnly = True
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 80
        GridViewTextBoxColumn9.HeaderText = "Total"
        GridViewTextBoxColumn9.Name = "Total"
        GridViewTextBoxColumn9.ReadOnly = True
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.Width = 90
        GridViewTextBoxColumn10.HeaderText = "elimina"
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.Name = "elimina"
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        FilterDescriptor1.PropertyName = Nothing
        Me.grdProductos.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1042, 288)
        Me.grdProductos.TabIndex = 0
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label24.Location = New System.Drawing.Point(939, 4)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(82, 21)
        Me.Label24.TabIndex = 120
        Me.Label24.Text = "Recuento :"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx1Guardar)
        Me.pnlBarra.Controls.Add(Me.pnx0Nuevo)
        Me.pnlBarra.Location = New System.Drawing.Point(465, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(629, 51)
        Me.pnlBarra.TabIndex = 112
        '
        'pnx1Guardar
        '
        Me.pnx1Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx1Guardar.Controls.Add(Me.pbx1Guardar)
        Me.pnx1Guardar.Controls.Add(Me.lbl1Guardar)
        Me.pnx1Guardar.Location = New System.Drawing.Point(500, 7)
        Me.pnx1Guardar.Name = "pnx1Guardar"
        Me.pnx1Guardar.Size = New System.Drawing.Size(117, 40)
        Me.pnx1Guardar.TabIndex = 100
        '
        'pbx1Guardar
        '
        Me.pbx1Guardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx1Guardar.Location = New System.Drawing.Point(3, 3)
        Me.pbx1Guardar.Name = "pbx1Guardar"
        Me.pbx1Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Guardar.TabIndex = 75
        Me.pbx1Guardar.TabStop = False
        '
        'lbl1Guardar
        '
        Me.lbl1Guardar.AutoSize = True
        Me.lbl1Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl1Guardar.Location = New System.Drawing.Point(43, 10)
        Me.lbl1Guardar.Name = "lbl1Guardar"
        Me.lbl1Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl1Guardar.TabIndex = 76
        Me.lbl1Guardar.Text = "Guardar"
        '
        'pnx0Nuevo
        '
        Me.pnx0Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Nuevo.BackColor = System.Drawing.Color.Navy
        Me.pnx0Nuevo.Controls.Add(Me.pbx0Nuevo)
        Me.pnx0Nuevo.Controls.Add(Me.lbl0Nuevo)
        Me.pnx0Nuevo.Location = New System.Drawing.Point(387, 7)
        Me.pnx0Nuevo.Name = "pnx0Nuevo"
        Me.pnx0Nuevo.Size = New System.Drawing.Size(106, 40)
        Me.pnx0Nuevo.TabIndex = 99
        '
        'pbx0Nuevo
        '
        Me.pbx0Nuevo.Image = CType(resources.GetObject("pbx0Nuevo.Image"), System.Drawing.Image)
        Me.pbx0Nuevo.Location = New System.Drawing.Point(3, 4)
        Me.pbx0Nuevo.Name = "pbx0Nuevo"
        Me.pbx0Nuevo.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Nuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Nuevo.TabIndex = 95
        Me.pbx0Nuevo.TabStop = False
        '
        'lbl0Nuevo
        '
        Me.lbl0Nuevo.AutoSize = True
        Me.lbl0Nuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Nuevo.ForeColor = System.Drawing.Color.White
        Me.lbl0Nuevo.Location = New System.Drawing.Point(44, 11)
        Me.lbl0Nuevo.Name = "lbl0Nuevo"
        Me.lbl0Nuevo.Size = New System.Drawing.Size(53, 19)
        Me.lbl0Nuevo.TabIndex = 96
        Me.lbl0Nuevo.Text = "Nuevo"
        '
        'frmProveedorDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1090, 584)
        Me.Controls.Add(Me.pbBuscarProducto)
        Me.Controls.Add(Me.lblProductos)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.rgbPago)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.rgbProductos)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProveedorDevolucion"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbProductos, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.rgbPago, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.lblProductos, 0)
        Me.Controls.SetChildIndex(Me.pbBuscarProducto, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBuscarProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbPago.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rgbProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbProductos.ResumeLayout(False)
        Me.rgbProductos.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Guardar.ResumeLayout(False)
        Me.pnx1Guardar.PerformLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Nuevo.ResumeLayout(False)
        Me.pnx0Nuevo.PerformLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbBuscarProducto As System.Windows.Forms.PictureBox
    Friend WithEvents lblProductos As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rgbPago As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkAcreditado As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCompras As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents rgbProductos As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx1Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Guardar As System.Windows.Forms.Label
    Friend WithEvents pnx0Nuevo As System.Windows.Forms.Panel
    Friend WithEvents pbx0Nuevo As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Nuevo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents lblRecuentoDevolver As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMovimientos As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblRecuento As System.Windows.Forms.Label

End Class
