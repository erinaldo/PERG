﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoInventariosConceptos
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
        Dim FilterDescriptor2 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoInventariosConceptos))
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTipoMovimiento = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblInveInicial = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInveFinal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFavor = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblContra = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rgbDetalle = New Telerik.WinControls.UI.RadGroupBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDetalle.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'grdDatos
        '
        Me.grdDatos.AutoScroll = True
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.Location = New System.Drawing.Point(10, 20)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos.MasterTemplate.AllowDeleteRow = False
        Me.grdDatos.MasterTemplate.AllowEditRow = False
        Me.grdDatos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        FilterDescriptor2.PropertyName = Nothing
        Me.grdDatos.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor2})
        Me.grdDatos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        '
        '
        '
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(881, 206)
        Me.grdDatos.TabIndex = 130
        Me.grdDatos.Text = "RadGridView1"
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(343, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(578, 48)
        Me.pnlBarra.TabIndex = 139
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(463, 2)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 195
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 72
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 71
        Me.pbx0Salir.TabStop = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(150, 12)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 30)
        Me.lblCodigo.TabIndex = 141
        Me.lblCodigo.Text = "Codigo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(61, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 25)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Código :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(150, 41)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(72, 30)
        Me.lblFecha.TabIndex = 143
        Me.lblFecha.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(72, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 25)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Fecha :"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblUsuario.Location = New System.Drawing.Point(150, 96)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(92, 30)
        Me.lblUsuario.TabIndex = 145
        Me.lblUsuario.Text = "Usuario"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(57, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 25)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "Usuario :"
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(150, 124)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(133, 30)
        Me.lblDocumento.TabIndex = 147
        Me.lblDocumento.Text = "Documento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(21, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 25)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "Documento :"
        '
        'lblObservacion
        '
        Me.lblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.ForeColor = System.Drawing.Color.Black
        Me.lblObservacion.Location = New System.Drawing.Point(155, 160)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(353, 62)
        Me.lblObservacion.TabIndex = 149
        Me.lblObservacion.Text = "Observacion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(14, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 25)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Observación :"
        '
        'lblTipoMovimiento
        '
        Me.lblTipoMovimiento.AutoSize = True
        Me.lblTipoMovimiento.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoMovimiento.ForeColor = System.Drawing.Color.Black
        Me.lblTipoMovimiento.Location = New System.Drawing.Point(677, 28)
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        Me.lblTipoMovimiento.Size = New System.Drawing.Size(138, 30)
        Me.lblTipoMovimiento.TabIndex = 151
        Me.lblTipoMovimiento.Text = "Movimiento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(476, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(195, 25)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Tipo de Movimiento :"
        '
        'lblInveInicial
        '
        Me.lblInveInicial.AutoSize = True
        Me.lblInveInicial.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblInveInicial.ForeColor = System.Drawing.Color.Black
        Me.lblInveInicial.Location = New System.Drawing.Point(677, 55)
        Me.lblInveInicial.Name = "lblInveInicial"
        Me.lblInveInicial.Size = New System.Drawing.Size(186, 30)
        Me.lblInveInicial.TabIndex = 153
        Me.lblInveInicial.Text = "Inventario Inicial"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(505, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 25)
        Me.Label10.TabIndex = 152
        Me.Label10.Text = "Inventario Inicial :"
        '
        'lblInveFinal
        '
        Me.lblInveFinal.AutoSize = True
        Me.lblInveFinal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblInveFinal.ForeColor = System.Drawing.Color.Black
        Me.lblInveFinal.Location = New System.Drawing.Point(677, 84)
        Me.lblInveFinal.Name = "lblInveFinal"
        Me.lblInveFinal.Size = New System.Drawing.Size(173, 30)
        Me.lblInveFinal.TabIndex = 155
        Me.lblInveFinal.Text = "Inventario Final"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(515, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 25)
        Me.Label12.TabIndex = 154
        Me.Label12.Text = "Inventario Final :"
        '
        'lblFavor
        '
        Me.lblFavor.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblFavor.ForeColor = System.Drawing.Color.Black
        Me.lblFavor.Location = New System.Drawing.Point(677, 127)
        Me.lblFavor.Name = "lblFavor"
        Me.lblFavor.Size = New System.Drawing.Size(173, 30)
        Me.lblFavor.TabIndex = 159
        Me.lblFavor.Text = "A favor"
        Me.lblFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(546, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 25)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "A favor ( + ) :"
        '
        'lblContra
        '
        Me.lblContra.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblContra.ForeColor = System.Drawing.Color.Black
        Me.lblContra.Location = New System.Drawing.Point(677, 155)
        Me.lblContra.Name = "lblContra"
        Me.lblContra.Size = New System.Drawing.Size(173, 30)
        Me.lblContra.TabIndex = 161
        Me.lblContra.Text = "En contra"
        Me.lblContra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DimGray
        Me.Label15.Location = New System.Drawing.Point(528, 160)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 25)
        Me.Label15.TabIndex = 160
        Me.Label15.Text = "En contra  ( - ) :"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(675, 185)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(173, 30)
        Me.lblTotal.TabIndex = 163
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(604, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 25)
        Me.Label6.TabIndex = 162
        Me.Label6.Text = "Total :"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(25, 57)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 166
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(63, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 32)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Información"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.BackColor = System.Drawing.Color.Transparent
        Me.rgbInformacion.Controls.Add(Me.Label14)
        Me.rgbInformacion.Controls.Add(Me.lblHora)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblCodigo)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.lblTotal)
        Me.rgbInformacion.Controls.Add(Me.lblFecha)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.lblContra)
        Me.rgbInformacion.Controls.Add(Me.lblUsuario)
        Me.rgbInformacion.Controls.Add(Me.Label15)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.lblFavor)
        Me.rgbInformacion.Controls.Add(Me.lblDocumento)
        Me.rgbInformacion.Controls.Add(Me.Label13)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblInveFinal)
        Me.rgbInformacion.Controls.Add(Me.lblObservacion)
        Me.rgbInformacion.Controls.Add(Me.Label12)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.lblInveInicial)
        Me.rgbInformacion.Controls.Add(Me.lblTipoMovimiento)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 79)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(901, 232)
        Me.rgbInformacion.TabIndex = 164
        Me.rgbInformacion.ThemeName = "radGroupBoxAzul"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(80, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 25)
        Me.Label14.TabIndex = 164
        Me.Label14.Text = "Hora :"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHora.ForeColor = System.Drawing.Color.Black
        Me.lblHora.Location = New System.Drawing.Point(150, 70)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(64, 30)
        Me.lblHora.TabIndex = 165
        Me.lblHora.Text = "Hora"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(25, 318)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 169
        Me.PictureBox5.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(63, 318)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 32)
        Me.Label11.TabIndex = 168
        Me.Label11.Text = "Detalle"
        '
        'rgbDetalle
        '
        Me.rgbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDetalle.BackColor = System.Drawing.Color.Transparent
        Me.rgbDetalle.Controls.Add(Me.grdDatos)
        Me.rgbDetalle.FooterImageIndex = -1
        Me.rgbDetalle.FooterImageKey = ""
        Me.rgbDetalle.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbDetalle.HeaderImageIndex = -1
        Me.rgbDetalle.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbDetalle.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDetalle.HeaderText = ""
        Me.rgbDetalle.Location = New System.Drawing.Point(12, 340)
        Me.rgbDetalle.Name = "rgbDetalle"
        Me.rgbDetalle.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDetalle.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDetalle.Size = New System.Drawing.Size(901, 236)
        Me.rgbDetalle.TabIndex = 167
        Me.rgbDetalle.ThemeName = "radGroupBoxAzul"
        '
        'frmMovimientoInventariosConceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(918, 588)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.rgbDetalle)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovimientoInventariosConceptos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.rgbDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDetalle.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTipoMovimiento As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblInveInicial As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblInveFinal As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFavor As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblContra As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rgbDetalle As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label

End Class