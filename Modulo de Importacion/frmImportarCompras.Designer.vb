﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarCompras))
        Me.pnlbarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbHojas = New System.Windows.Forms.ComboBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdCompras = New Telerik.WinControls.UI.RadGridView()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rgbCompras = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContadorCompras = New System.Windows.Forms.Label()
        Me.grdDetalle = New Telerik.WinControls.UI.RadGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.rgbArticulosCompras = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdDetalleArticulos = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblContadorArticulos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductosNoEncontrados = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlbarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.grdCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCompras.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbCompras.SuspendLayout()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalle.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbArticulosCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbArticulosCompras.SuspendLayout()
        CType(Me.grdDetalleArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleArticulos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.grdProductosNoEncontrados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductosNoEncontrados.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pnlbarra
        '
        Me.pnlbarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlbarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlbarra.Controls.Add(Me.pnx1Salir)
        Me.pnlbarra.Controls.Add(Me.pnx0Guardar)
        Me.pnlbarra.Location = New System.Drawing.Point(465, 0)
        Me.pnlbarra.Name = "pnlbarra"
        Me.pnlbarra.Size = New System.Drawing.Size(597, 48)
        Me.pnlbarra.TabIndex = 180
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(474, 3)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(111, 40)
        Me.pnx1Salir.TabIndex = 182
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = CType(resources.GetObject("pbx1Salir.Image"), System.Drawing.Image)
        Me.pbx1Salir.Location = New System.Drawing.Point(3, 4)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 95
        Me.pbx1Salir.TabStop = False
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(44, 11)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 96
        Me.lbl1Salir.Text = "Salir"
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(358, 3)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(111, 40)
        Me.pnx0Guardar.TabIndex = 181
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = CType(resources.GetObject("pbx0Guardar.Image"), System.Drawing.Image)
        Me.pbx0Guardar.Location = New System.Drawing.Point(3, 4)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 95
        Me.pbx0Guardar.TabStop = False
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(44, 11)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Guardar.TabIndex = 96
        Me.lbl0Guardar.Text = "Guardar"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(16, 49)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(52, 42)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 183
        Me.PictureBox5.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(69, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 29)
        Me.Label16.TabIndex = 182
        Me.Label16.Text = "Informacion"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.btnAgregar)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.txtUrl)
        Me.rgbInformacion.Controls.Add(Me.lblTitulo)
        Me.rgbInformacion.Controls.Add(Me.cmbHojas)
        Me.rgbInformacion.Controls.Add(Me.btnImportar)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 78)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(399, 214)
        Me.rgbInformacion.TabIndex = 181
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(236, 146)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(142, 55)
        Me.btnAgregar.TabIndex = 181
        Me.btnAgregar.Text = "  Agregar "
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(10, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "URL :"
        '
        'txtUrl
        '
        Me.txtUrl.Enabled = False
        Me.txtUrl.Location = New System.Drawing.Point(57, 57)
        Me.txtUrl.Multiline = True
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(324, 22)
        Me.txtUrl.TabIndex = 179
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTitulo.Location = New System.Drawing.Point(7, 90)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(44, 19)
        Me.lblTitulo.TabIndex = 178
        Me.lblTitulo.Text = "Hoja :"
        '
        'cmbHojas
        '
        Me.cmbHojas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbHojas.FormattingEnabled = True
        Me.cmbHojas.Location = New System.Drawing.Point(57, 90)
        Me.cmbHojas.Name = "cmbHojas"
        Me.cmbHojas.Size = New System.Drawing.Size(324, 21)
        Me.cmbHojas.TabIndex = 177
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnImportar.FlatAppearance.BorderSize = 0
        Me.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.ForeColor = System.Drawing.Color.Transparent
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.Location = New System.Drawing.Point(55, 18)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(124, 31)
        Me.btnImportar.TabIndex = 176
        Me.btnImportar.Text = "Abrir Doc."
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(483, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(270, 29)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Compras Encontradas"
        '
        'grdCompras
        '
        Me.grdCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCompras.Location = New System.Drawing.Point(9, 22)
        '
        'grdCompras
        '
        Me.grdCompras.MasterTemplate.AllowAddNewRow = False
        Me.grdCompras.Name = "grdCompras"
        Me.grdCompras.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdCompras.ReadOnly = True
        '
        '
        '
        Me.grdCompras.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdCompras.Size = New System.Drawing.Size(601, 179)
        Me.grdCompras.TabIndex = 1
        Me.grdCompras.Text = "RadGridView1"
        Me.grdCompras.ThemeName = "Office2007Black"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(442, 60)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 186
        Me.PictureBox3.TabStop = False
        '
        'rgbCompras
        '
        Me.rgbCompras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbCompras.Controls.Add(Me.grdCompras)
        Me.rgbCompras.FooterImageIndex = -1
        Me.rgbCompras.FooterImageKey = ""
        Me.rgbCompras.HeaderImageIndex = -1
        Me.rgbCompras.HeaderImageKey = ""
        Me.rgbCompras.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbCompras.HeaderText = ""
        Me.rgbCompras.Location = New System.Drawing.Point(422, 78)
        Me.rgbCompras.Name = "rgbCompras"
        Me.rgbCompras.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbCompras.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbCompras.Size = New System.Drawing.Size(623, 214)
        Me.rgbCompras.TabIndex = 184
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.Label4)
        Me.rgbObservacion.Controls.Add(Me.lblContadorCompras)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(889, 62)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(142, 32)
        Me.rgbObservacion.TabIndex = 190
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(21, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 25)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "#"
        '
        'lblContadorCompras
        '
        Me.lblContadorCompras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContadorCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContadorCompras.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContadorCompras.ForeColor = System.Drawing.Color.Black
        Me.lblContadorCompras.Location = New System.Drawing.Point(50, 4)
        Me.lblContadorCompras.Name = "lblContadorCompras"
        Me.lblContadorCompras.Size = New System.Drawing.Size(85, 25)
        Me.lblContadorCompras.TabIndex = 175
        Me.lblContadorCompras.Text = "0"
        Me.lblContadorCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDetalle
        '
        Me.grdDetalle.Location = New System.Drawing.Point(13, 23)
        '
        '
        '
        Me.grdDetalle.MasterTemplate.AllowAddNewRow = False
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDetalle.ReadOnly = True
        '
        '
        '
        Me.grdDetalle.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDetalle.Size = New System.Drawing.Size(571, 148)
        Me.grdDetalle.TabIndex = 3
        Me.grdDetalle.Text = "RadGridView1"
        Me.grdDetalle.ThemeName = "Office2007Black"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(475, 314)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(217, 29)
        Me.Label8.TabIndex = 194
        Me.Label8.Text = "Detalle Inventario"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(433, 308)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 192
        Me.PictureBox8.TabStop = False
        '
        'rgbArticulosCompras
        '
        Me.rgbArticulosCompras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbArticulosCompras.Controls.Add(Me.grdDetalleArticulos)
        Me.rgbArticulosCompras.FooterImageIndex = -1
        Me.rgbArticulosCompras.FooterImageKey = ""
        Me.rgbArticulosCompras.HeaderImageIndex = -1
        Me.rgbArticulosCompras.HeaderImageKey = ""
        Me.rgbArticulosCompras.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbArticulosCompras.HeaderText = ""
        Me.rgbArticulosCompras.Location = New System.Drawing.Point(422, 330)
        Me.rgbArticulosCompras.Name = "rgbArticulosCompras"
        Me.rgbArticulosCompras.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbArticulosCompras.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbArticulosCompras.Size = New System.Drawing.Size(623, 215)
        Me.rgbArticulosCompras.TabIndex = 193
        '
        'grdDetalleArticulos
        '
        Me.grdDetalleArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalleArticulos.Location = New System.Drawing.Point(13, 23)
        '
        'grdDetalleArticulos
        '
        Me.grdDetalleArticulos.MasterTemplate.AllowAddNewRow = False
        Me.grdDetalleArticulos.Name = "grdDetalleArticulos"
        Me.grdDetalleArticulos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDetalleArticulos.ReadOnly = True
        '
        '
        '
        Me.grdDetalleArticulos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDetalleArticulos.Size = New System.Drawing.Size(593, 179)
        Me.grdDetalleArticulos.TabIndex = 3
        Me.grdDetalleArticulos.Text = "RadGridView1"
        Me.grdDetalleArticulos.ThemeName = "Office2007Black"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.lblContadorArticulos)
        Me.RadGroupBox1.Controls.Add(Me.Label5)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(889, 314)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(142, 34)
        Me.RadGroupBox1.TabIndex = 195
        '
        'lblContadorArticulos
        '
        Me.lblContadorArticulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContadorArticulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContadorArticulos.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContadorArticulos.ForeColor = System.Drawing.Color.Black
        Me.lblContadorArticulos.Location = New System.Drawing.Point(52, 5)
        Me.lblContadorArticulos.Name = "lblContadorArticulos"
        Me.lblContadorArticulos.Size = New System.Drawing.Size(85, 25)
        Me.lblContadorArticulos.TabIndex = 175
        Me.lblContadorArticulos.Text = "0"
        Me.lblContadorArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(13, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 25)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = "#"
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox4.Controls.Add(Me.Label13)
        Me.RadGroupBox4.Controls.Add(Me.Label14)
        Me.RadGroupBox4.FooterImageIndex = -1
        Me.RadGroupBox4.FooterImageKey = ""
        Me.RadGroupBox4.HeaderImageIndex = -1
        Me.RadGroupBox4.HeaderImageKey = ""
        Me.RadGroupBox4.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox4.HeaderText = ""
        Me.RadGroupBox4.Location = New System.Drawing.Point(258, 305)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox4.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox4.Size = New System.Drawing.Size(147, 33)
        Me.RadGroupBox4.TabIndex = 196
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(55, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 21)
        Me.Label13.TabIndex = 175
        Me.Label13.Text = "0"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(32, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 21)
        Me.Label14.TabIndex = 174
        Me.Label14.Text = "#"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(69, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(200, 29)
        Me.Label12.TabIndex = 199
        Me.Label12.Text = "No Encontrados"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(16, 310)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(52, 33)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 197
        Me.PictureBox9.TabStop = False
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.Controls.Add(Me.grdProductosNoEncontrados)
        Me.RadGroupBox3.FooterImageIndex = -1
        Me.RadGroupBox3.FooterImageKey = ""
        Me.RadGroupBox3.HeaderImageIndex = -1
        Me.RadGroupBox3.HeaderImageKey = ""
        Me.RadGroupBox3.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox3.HeaderText = ""
        Me.RadGroupBox3.Location = New System.Drawing.Point(12, 330)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox3.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox3.Size = New System.Drawing.Size(399, 215)
        Me.RadGroupBox3.TabIndex = 198
        '
        'grdProductosNoEncontrados
        '
        Me.grdProductosNoEncontrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductosNoEncontrados.Location = New System.Drawing.Point(13, 15)
        '
        'grdProductosNoEncontrados
        '
        Me.grdProductosNoEncontrados.MasterTemplate.AllowAddNewRow = False
        Me.grdProductosNoEncontrados.Name = "grdProductosNoEncontrados"
        Me.grdProductosNoEncontrados.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductosNoEncontrados.ReadOnly = True
        '
        '
        '
        Me.grdProductosNoEncontrados.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductosNoEncontrados.Size = New System.Drawing.Size(373, 190)
        Me.grdProductosNoEncontrados.TabIndex = 3
        Me.grdProductosNoEncontrados.Text = "RadGridView1"
        Me.grdProductosNoEncontrados.ThemeName = "Office2007Black"
        '
        'frmImportarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1059, 557)
        Me.Controls.Add(Me.RadGroupBox4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.RadGroupBox3)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.rgbArticulosCompras)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbCompras)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlbarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportarCompras"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlbarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.rgbCompras, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.rgbObservacion, 0)
        Me.Controls.SetChildIndex(Me.rgbArticulosCompras, 0)
        Me.Controls.SetChildIndex(Me.PictureBox8, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox3, 0)
        Me.Controls.SetChildIndex(Me.PictureBox9, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlbarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.grdCompras.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbCompras.ResumeLayout(False)
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me.grdDetalle.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbArticulosCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbArticulosCompras.ResumeLayout(False)
        CType(Me.grdDetalleArticulos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        Me.RadGroupBox4.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.grdProductosNoEncontrados.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductosNoEncontrados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlbarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents cmbHojas As System.Windows.Forms.ComboBox
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdCompras As Telerik.WinControls.UI.RadGridView
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbCompras As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblContadorCompras As System.Windows.Forms.Label
    Friend WithEvents grdDetalle As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbArticulosCompras As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdDetalleArticulos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblContadorArticulos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdProductosNoEncontrados As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
