﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloProductosNuevos
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarArticuloProductosNuevos))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbProducto = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rpvInformacion = New Telerik.WinControls.UI.RadPageView()
        Me.pgGeneral = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.pgNoComprados = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdProductos2 = New Telerik.WinControls.UI.RadGridView()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCompatibilidad = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblEmpaque = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Foto = New System.Windows.Forms.Panel()
        Me.pbx0Foto = New System.Windows.Forms.PictureBox()
        Me.lbl0Foto = New System.Windows.Forms.Label()
        Me.pnx1DocSalida = New System.Windows.Forms.Panel()
        Me.pbx1DocSalida = New System.Windows.Forms.PictureBox()
        Me.lbl1DocSalida = New System.Windows.Forms.Label()
        Me.pnx2Salir = New System.Windows.Forms.Panel()
        Me.lbl2Salir = New System.Windows.Forms.Label()
        Me.pbx2Salir = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTiempo = New System.Windows.Forms.ComboBox()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.chkTodosTipo = New System.Windows.Forms.CheckBox()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.lblGrid1 = New System.Windows.Forms.Label()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.rgbFiltro = New Telerik.WinControls.UI.RadGroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbProducto.SuspendLayout()
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvInformacion.SuspendLayout()
        Me.pgGeneral.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgNoComprados.SuspendLayout()
        CType(Me.grdProductos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Foto.SuspendLayout()
        CType(Me.pbx0Foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1DocSalida.SuspendLayout()
        CType(Me.pbx1DocSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Salir.SuspendLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltro.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(64, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(226, 29)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Productos Nuevos"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(27, 230)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(34, 34)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 153
        Me.PictureBox5.TabStop = False
        '
        'rgbProducto
        '
        Me.rgbProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbProducto.Controls.Add(Me.btnBuscar)
        Me.rgbProducto.Controls.Add(Me.rpvInformacion)
        Me.rgbProducto.Controls.Add(Me.rgbObservacion)
        Me.rgbProducto.FooterImageIndex = -1
        Me.rgbProducto.FooterImageKey = ""
        Me.rgbProducto.HeaderImageIndex = -1
        Me.rgbProducto.HeaderImageKey = ""
        Me.rgbProducto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbProducto.HeaderText = ""
        Me.rgbProducto.Location = New System.Drawing.Point(8, 252)
        Me.rgbProducto.Name = "rgbProducto"
        Me.rgbProducto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbProducto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbProducto.Size = New System.Drawing.Size(1052, 358)
        Me.rgbProducto.TabIndex = 151
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(931, 270)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(94, 70)
        Me.btnBuscar.TabIndex = 184
        Me.btnBuscar.Text = "Agregar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'rpvInformacion
        '
        Me.rpvInformacion.Controls.Add(Me.pgGeneral)
        Me.rpvInformacion.Controls.Add(Me.pgNoComprados)
        Me.rpvInformacion.Location = New System.Drawing.Point(5, 10)
        Me.rpvInformacion.Name = "rpvInformacion"
        Me.rpvInformacion.SelectedPage = Me.pgNoComprados
        Me.rpvInformacion.Size = New System.Drawing.Size(1039, 244)
        Me.rpvInformacion.TabIndex = 196
        Me.rpvInformacion.Text = "RadPageView1"
        CType(Me.rpvInformacion.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'pgGeneral
        '
        Me.pgGeneral.Controls.Add(Me.grdProductos)
        Me.pgGeneral.Location = New System.Drawing.Point(10, 37)
        Me.pgGeneral.Name = "pgGeneral"
        Me.pgGeneral.Size = New System.Drawing.Size(1018, 196)
        Me.pgGeneral.Text = "Nuevos General"
        '
        'grdProductos
        '
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(0, 0)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowColumnReorder = False
        Me.grdProductos.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn1.HeaderText = "Agregar"
        GridViewCheckBoxColumn1.IsVisible = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1})
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1018, 196)
        Me.grdProductos.TabIndex = 134
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'pgNoComprados
        '
        Me.pgNoComprados.Controls.Add(Me.grdProductos2)
        Me.pgNoComprados.Location = New System.Drawing.Point(10, 37)
        Me.pgNoComprados.Name = "pgNoComprados"
        Me.pgNoComprados.Size = New System.Drawing.Size(1018, 196)
        Me.pgNoComprados.Text = "Nuevos No Comprados"
        '
        'grdProductos2
        '
        Me.grdProductos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdProductos2.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos2.Location = New System.Drawing.Point(0, 0)
        '
        'grdProductos2
        '
        Me.grdProductos2.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos2.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn2.HeaderText = "column1"
        GridViewCheckBoxColumn2.IsVisible = False
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "chmAgregar"
        Me.grdProductos2.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2})
        Me.grdProductos2.MasterTemplate.EnableGrouping = False
        Me.grdProductos2.Name = "grdProductos2"
        Me.grdProductos2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos2.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos2.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos2.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos2.Size = New System.Drawing.Size(1018, 196)
        Me.grdProductos2.TabIndex = 5
        Me.grdProductos2.Text = "RadGridView1"
        Me.grdProductos2.ThemeName = "Office2007Black"
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblUbicacion)
        Me.rgbObservacion.Controls.Add(Me.Label3)
        Me.rgbObservacion.Controls.Add(Me.lblCompatibilidad)
        Me.rgbObservacion.Controls.Add(Me.Label8)
        Me.rgbObservacion.Controls.Add(Me.lblMarca)
        Me.rgbObservacion.Controls.Add(Me.Label7)
        Me.rgbObservacion.Controls.Add(Me.lblObservacion)
        Me.rgbObservacion.Controls.Add(Me.lblEmpaque)
        Me.rgbObservacion.Controls.Add(Me.Label6)
        Me.rgbObservacion.Controls.Add(Me.Label5)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(13, 261)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(890, 84)
        Me.rgbObservacion.TabIndex = 185
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicacion.ForeColor = System.Drawing.Color.Black
        Me.lblUbicacion.Location = New System.Drawing.Point(554, 47)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(111, 24)
        Me.lblUbicacion.TabIndex = 177
        Me.lblUbicacion.Text = "Ubicacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(488, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 25)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Ubic :"
        '
        'lblCompatibilidad
        '
        Me.lblCompatibilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompatibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompatibilidad.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompatibilidad.ForeColor = System.Drawing.Color.Black
        Me.lblCompatibilidad.Location = New System.Drawing.Point(167, 47)
        Me.lblCompatibilidad.Name = "lblCompatibilidad"
        Me.lblCompatibilidad.Size = New System.Drawing.Size(255, 24)
        Me.lblCompatibilidad.TabIndex = 175
        Me.lblCompatibilidad.Text = "Compatibilidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(8, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 25)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "Compatibilidad :"
        '
        'lblMarca
        '
        Me.lblMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMarca.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(771, 6)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(106, 30)
        Me.lblMarca.TabIndex = 173
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(699, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 25)
        Me.Label7.TabIndex = 172
        Me.Label7.Text = "Marca :"
        '
        'lblObservacion
        '
        Me.lblObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblObservacion.ForeColor = System.Drawing.Color.Black
        Me.lblObservacion.Location = New System.Drawing.Point(167, 13)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(498, 30)
        Me.lblObservacion.TabIndex = 169
        Me.lblObservacion.Text = "Codigo"
        '
        'lblEmpaque
        '
        Me.lblEmpaque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpaque.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpaque.ForeColor = System.Drawing.Color.Black
        Me.lblEmpaque.Location = New System.Drawing.Point(771, 40)
        Me.lblEmpaque.Name = "lblEmpaque"
        Me.lblEmpaque.Size = New System.Drawing.Size(106, 32)
        Me.lblEmpaque.TabIndex = 171
        Me.lblEmpaque.Text = "Empaque"
        Me.lblEmpaque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(33, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 25)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Observación :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(673, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 25)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Empaque :"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Foto)
        Me.pnlBarra.Controls.Add(Me.pnx1DocSalida)
        Me.pnlBarra.Controls.Add(Me.pnx2Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(604, 51)
        Me.pnlBarra.TabIndex = 175
        '
        'pnx0Foto
        '
        Me.pnx0Foto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Foto.BackColor = System.Drawing.Color.Navy
        Me.pnx0Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Foto.Controls.Add(Me.pbx0Foto)
        Me.pnx0Foto.Controls.Add(Me.lbl0Foto)
        Me.pnx0Foto.Location = New System.Drawing.Point(265, 6)
        Me.pnx0Foto.Name = "pnx0Foto"
        Me.pnx0Foto.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Foto.TabIndex = 201
        '
        'pbx0Foto
        '
        Me.pbx0Foto.Image = Global.laFuente.My.Resources.Resources.fotoBlanco
        Me.pbx0Foto.Location = New System.Drawing.Point(2, 4)
        Me.pbx0Foto.Name = "pbx0Foto"
        Me.pbx0Foto.Size = New System.Drawing.Size(32, 29)
        Me.pbx0Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Foto.TabIndex = 93
        Me.pbx0Foto.TabStop = False
        '
        'lbl0Foto
        '
        Me.lbl0Foto.AutoSize = True
        Me.lbl0Foto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Foto.ForeColor = System.Drawing.Color.White
        Me.lbl0Foto.Location = New System.Drawing.Point(32, 9)
        Me.lbl0Foto.Name = "lbl0Foto"
        Me.lbl0Foto.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Foto.TabIndex = 94
        Me.lbl0Foto.Text = "Foto"
        '
        'pnx1DocSalida
        '
        Me.pnx1DocSalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1DocSalida.BackColor = System.Drawing.Color.Navy
        Me.pnx1DocSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1DocSalida.Controls.Add(Me.pbx1DocSalida)
        Me.pnx1DocSalida.Controls.Add(Me.lbl1DocSalida)
        Me.pnx1DocSalida.Location = New System.Drawing.Point(378, 6)
        Me.pnx1DocSalida.Name = "pnx1DocSalida"
        Me.pnx1DocSalida.Size = New System.Drawing.Size(107, 40)
        Me.pnx1DocSalida.TabIndex = 200
        '
        'pbx1DocSalida
        '
        Me.pbx1DocSalida.Image = Global.laFuente.My.Resources.Resources.upload
        Me.pbx1DocSalida.Location = New System.Drawing.Point(2, 4)
        Me.pbx1DocSalida.Name = "pbx1DocSalida"
        Me.pbx1DocSalida.Size = New System.Drawing.Size(32, 29)
        Me.pbx1DocSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1DocSalida.TabIndex = 93
        Me.pbx1DocSalida.TabStop = False
        '
        'lbl1DocSalida
        '
        Me.lbl1DocSalida.AutoSize = True
        Me.lbl1DocSalida.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1DocSalida.ForeColor = System.Drawing.Color.White
        Me.lbl1DocSalida.Location = New System.Drawing.Point(32, 9)
        Me.lbl1DocSalida.Name = "lbl1DocSalida"
        Me.lbl1DocSalida.Size = New System.Drawing.Size(76, 19)
        Me.lbl1DocSalida.TabIndex = 94
        Me.lbl1DocSalida.Text = "DocSalida"
        '
        'pnx2Salir
        '
        Me.pnx2Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx2Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx2Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx2Salir.Controls.Add(Me.lbl2Salir)
        Me.pnx2Salir.Controls.Add(Me.pbx2Salir)
        Me.pnx2Salir.Location = New System.Drawing.Point(491, 6)
        Me.pnx2Salir.Name = "pnx2Salir"
        Me.pnx2Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx2Salir.TabIndex = 195
        '
        'lbl2Salir
        '
        Me.lbl2Salir.AutoSize = True
        Me.lbl2Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Salir.ForeColor = System.Drawing.Color.White
        Me.lbl2Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl2Salir.Name = "lbl2Salir"
        Me.lbl2Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl2Salir.TabIndex = 72
        Me.lbl2Salir.Text = "Salir"
        '
        'pbx2Salir
        '
        Me.pbx2Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx2Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx2Salir.Name = "pbx2Salir"
        Me.pbx2Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Salir.TabIndex = 71
        Me.pbx2Salir.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(188, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "Desde Hace"
        '
        'cmbTiempo
        '
        Me.cmbTiempo.FormattingEnabled = True
        Me.cmbTiempo.Location = New System.Drawing.Point(274, 23)
        Me.cmbTiempo.Name = "cmbTiempo"
        Me.cmbTiempo.Size = New System.Drawing.Size(164, 21)
        Me.cmbTiempo.TabIndex = 187
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblContador.ForeColor = System.Drawing.Color.DimGray
        Me.lblContador.Location = New System.Drawing.Point(663, 11)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(19, 21)
        Me.lblContador.TabIndex = 191
        Me.lblContador.Text = "0"
        '
        'chkTodosTipo
        '
        Me.chkTodosTipo.AutoSize = True
        Me.chkTodosTipo.Location = New System.Drawing.Point(688, 16)
        Me.chkTodosTipo.Name = "chkTodosTipo"
        Me.chkTodosTipo.Size = New System.Drawing.Size(57, 17)
        Me.chkTodosTipo.TabIndex = 190
        Me.chkTodosTipo.Text = "Todos"
        Me.chkTodosTipo.UseVisualStyleBackColor = True
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoVehiculo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoVehiculo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoVehiculo.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(486, 36)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn3.HeaderText = "Agregar"
        GridViewCheckBoxColumn3.MinWidth = 20
        GridViewCheckBoxColumn3.Name = "chmAgregar"
        GridViewCheckBoxColumn3.Width = 55
        GridViewTextBoxColumn1.HeaderText = "codigo"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "codigo"
        GridViewTextBoxColumn2.HeaderText = "Nombre"
        GridViewTextBoxColumn2.Name = "nombre"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 150
        Me.grdTipoVehiculo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn3, GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.grdTipoVehiculo.MasterTemplate.EnableGrouping = False
        Me.grdTipoVehiculo.MasterTemplate.EnableSorting = False
        Me.grdTipoVehiculo.Name = "grdTipoVehiculo"
        Me.grdTipoVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoVehiculo.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.Size = New System.Drawing.Size(272, 104)
        Me.grdTipoVehiculo.TabIndex = 189
        Me.grdTipoVehiculo.Text = "RadGridView1"
        Me.grdTipoVehiculo.ThemeName = "Office2007Black"
        '
        'lblGrid1
        '
        Me.lblGrid1.AutoSize = True
        Me.lblGrid1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid1.ForeColor = System.Drawing.Color.DimGray
        Me.lblGrid1.Location = New System.Drawing.Point(484, 14)
        Me.lblGrid1.Name = "lblGrid1"
        Me.lblGrid1.Size = New System.Drawing.Size(120, 19)
        Me.lblGrid1.TabIndex = 188
        Me.lblGrid1.Text = "Tipo de Vehículo"
        '
        'btnBusqueda
        '
        Me.btnBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBusqueda.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBusqueda.FlatAppearance.BorderSize = 0
        Me.btnBusqueda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBusqueda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusqueda.ForeColor = System.Drawing.Color.Transparent
        Me.btnBusqueda.Image = Global.laFuente.My.Resources.Resources.buscar_Blanco
        Me.btnBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBusqueda.Location = New System.Drawing.Point(793, 62)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(143, 59)
        Me.btnBusqueda.TabIndex = 192
        Me.btnBusqueda.Text = "   Buscar"
        Me.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBusqueda.UseVisualStyleBackColor = False
        '
        'rgbFiltro
        '
        Me.rgbFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbFiltro.Controls.Add(Me.cmbTiempo)
        Me.rgbFiltro.Controls.Add(Me.btnBusqueda)
        Me.rgbFiltro.Controls.Add(Me.Label2)
        Me.rgbFiltro.Controls.Add(Me.lblContador)
        Me.rgbFiltro.Controls.Add(Me.lblGrid1)
        Me.rgbFiltro.Controls.Add(Me.chkTodosTipo)
        Me.rgbFiltro.Controls.Add(Me.grdTipoVehiculo)
        Me.rgbFiltro.FooterImageIndex = -1
        Me.rgbFiltro.FooterImageKey = ""
        Me.rgbFiltro.HeaderImageIndex = -1
        Me.rgbFiltro.HeaderImageKey = ""
        Me.rgbFiltro.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFiltro.HeaderText = ""
        Me.rgbFiltro.Location = New System.Drawing.Point(8, 76)
        Me.rgbFiltro.Name = "rgbFiltro"
        Me.rgbFiltro.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltro.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltro.Size = New System.Drawing.Size(1052, 148)
        Me.rgbFiltro.TabIndex = 193
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox4.Location = New System.Drawing.Point(27, 54)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(34, 34)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 195
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(64, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 29)
        Me.Label9.TabIndex = 193
        Me.Label9.Text = "Filtro"
        '
        'frmBuscarArticuloProductosNuevos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1068, 622)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbFiltro)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.rgbProducto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarArticuloProductosNuevos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbProducto, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.rgbFiltro, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbProducto.ResumeLayout(False)
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvInformacion.ResumeLayout(False)
        Me.pgGeneral.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgNoComprados.ResumeLayout(False)
        CType(Me.grdProductos2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Foto.ResumeLayout(False)
        Me.pnx0Foto.PerformLayout()
        CType(Me.pbx0Foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1DocSalida.ResumeLayout(False)
        Me.pnx1DocSalida.PerformLayout()
        CType(Me.pbx1DocSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Salir.ResumeLayout(False)
        Me.pnx2Salir.PerformLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltro.ResumeLayout(False)
        Me.rgbFiltro.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbProducto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblCompatibilidad As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblEmpaque As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnx2Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl2Salir As System.Windows.Forms.Label
    Friend WithEvents pbx2Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1DocSalida As System.Windows.Forms.Panel
    Friend WithEvents pbx1DocSalida As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1DocSalida As System.Windows.Forms.Label
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTiempo As System.Windows.Forms.ComboBox
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents chkTodosTipo As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents rgbFiltro As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnx0Foto As System.Windows.Forms.Panel
    Friend WithEvents pbx0Foto As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Foto As System.Windows.Forms.Label
    Friend WithEvents rpvInformacion As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgGeneral As Telerik.WinControls.UI.RadPageViewPage
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pgNoComprados As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdProductos2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblGrid1 As System.Windows.Forms.Label

End Class
