﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasConcepto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComprasConcepto))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Imprimir = New System.Windows.Forms.Panel()
        Me.lbl0Imprimir = New System.Windows.Forms.Label()
        Me.pbx0Imprimir = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.rgbDetalle = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblgasto = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFlete = New System.Windows.Forms.Label()
        Me.lblCantFlete = New System.Windows.Forms.Label()
        Me.lblAnulada = New System.Windows.Forms.Label()
        Me.lblCompra = New System.Windows.Forms.Label()
        Me.lblPreforma = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblFechaRegistro = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDocumento = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Imprimir.SuspendLayout()
        CType(Me.pbx0Imprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDetalle.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Imprimir)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(465, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(593, 48)
        Me.pnlBarra.TabIndex = 183
        '
        'pnx0Imprimir
        '
        Me.pnx0Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Imprimir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Imprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Imprimir.Controls.Add(Me.lbl0Imprimir)
        Me.pnx0Imprimir.Controls.Add(Me.pbx0Imprimir)
        Me.pnx0Imprimir.Location = New System.Drawing.Point(361, 4)
        Me.pnx0Imprimir.Name = "pnx0Imprimir"
        Me.pnx0Imprimir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Imprimir.TabIndex = 196
        '
        'lbl0Imprimir
        '
        Me.lbl0Imprimir.AutoSize = True
        Me.lbl0Imprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Imprimir.ForeColor = System.Drawing.Color.White
        Me.lbl0Imprimir.Location = New System.Drawing.Point(43, 5)
        Me.lbl0Imprimir.Name = "lbl0Imprimir"
        Me.lbl0Imprimir.Size = New System.Drawing.Size(54, 30)
        Me.lbl0Imprimir.TabIndex = 72
        Me.lbl0Imprimir.Text = "Docs de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salida"
        Me.lbl0Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Imprimir
        '
        Me.pbx0Imprimir.Image = Global.laFuente.My.Resources.Resources.entrada_Blanco
        Me.pbx0Imprimir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Imprimir.Name = "pbx0Imprimir"
        Me.pbx0Imprimir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Imprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Imprimir.TabIndex = 71
        Me.pbx0Imprimir.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(473, 3)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 195
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 72
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 71
        Me.pbx1Salir.TabStop = False
        '
        'rgbDetalle
        '
        Me.rgbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDetalle.Controls.Add(Me.grdProductos)
        Me.rgbDetalle.FooterImageIndex = -1
        Me.rgbDetalle.FooterImageKey = ""
        Me.rgbDetalle.HeaderImageIndex = -1
        Me.rgbDetalle.HeaderImageKey = ""
        Me.rgbDetalle.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDetalle.HeaderText = ""
        Me.rgbDetalle.Location = New System.Drawing.Point(7, 245)
        Me.rgbDetalle.Name = "rgbDetalle"
        Me.rgbDetalle.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDetalle.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDetalle.Size = New System.Drawing.Size(1038, 350)
        Me.rgbDetalle.TabIndex = 192
        '
        'grdProductos
        '
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(10, 20)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowDeleteRow = False
        Me.grdProductos.MasterTemplate.AllowEditRow = False
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1018, 320)
        Me.grdProductos.TabIndex = 161
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(71, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 25)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "Información"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(28, 59)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 190
        Me.PictureBox4.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.lblgasto)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.lblFlete)
        Me.rgbInformacion.Controls.Add(Me.lblCantFlete)
        Me.rgbInformacion.Controls.Add(Me.lblAnulada)
        Me.rgbInformacion.Controls.Add(Me.lblCompra)
        Me.rgbInformacion.Controls.Add(Me.lblPreforma)
        Me.rgbInformacion.Controls.Add(Me.Label12)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.lblUsuario)
        Me.rgbInformacion.Controls.Add(Me.Label13)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblProveedor)
        Me.rgbInformacion.Controls.Add(Me.lblFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblTotal)
        Me.rgbInformacion.Controls.Add(Me.Label11)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.Controls.Add(Me.lblDocumento)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(7, 76)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(1038, 144)
        Me.rgbInformacion.TabIndex = 189
        '
        'lblgasto
        '
        Me.lblgasto.AutoSize = True
        Me.lblgasto.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblgasto.ForeColor = System.Drawing.Color.Black
        Me.lblgasto.Location = New System.Drawing.Point(757, 90)
        Me.lblgasto.Name = "lblgasto"
        Me.lblgasto.Size = New System.Drawing.Size(63, 25)
        Me.lblgasto.TabIndex = 183
        Me.lblgasto.Text = "Gasto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(570, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 25)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "Gastos Importación :"
        '
        'lblFlete
        '
        Me.lblFlete.AutoSize = True
        Me.lblFlete.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFlete.ForeColor = System.Drawing.Color.Black
        Me.lblFlete.Location = New System.Drawing.Point(757, 65)
        Me.lblFlete.Name = "lblFlete"
        Me.lblFlete.Size = New System.Drawing.Size(54, 25)
        Me.lblFlete.TabIndex = 181
        Me.lblFlete.Text = "Flete"
        '
        'lblCantFlete
        '
        Me.lblCantFlete.AutoSize = True
        Me.lblCantFlete.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantFlete.ForeColor = System.Drawing.Color.DimGray
        Me.lblCantFlete.Location = New System.Drawing.Point(695, 65)
        Me.lblCantFlete.Name = "lblCantFlete"
        Me.lblCantFlete.Size = New System.Drawing.Size(64, 25)
        Me.lblCantFlete.TabIndex = 180
        Me.lblCantFlete.Text = "Flete :"
        '
        'lblAnulada
        '
        Me.lblAnulada.AutoSize = True
        Me.lblAnulada.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblAnulada.ForeColor = System.Drawing.Color.Black
        Me.lblAnulada.Location = New System.Drawing.Point(757, 115)
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Size = New System.Drawing.Size(86, 25)
        Me.lblAnulada.TabIndex = 179
        Me.lblAnulada.Text = "Nombre"
        '
        'lblCompra
        '
        Me.lblCompra.AutoSize = True
        Me.lblCompra.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompra.ForeColor = System.Drawing.Color.Black
        Me.lblCompra.Location = New System.Drawing.Point(757, 40)
        Me.lblCompra.Name = "lblCompra"
        Me.lblCompra.Size = New System.Drawing.Size(86, 25)
        Me.lblCompra.TabIndex = 175
        Me.lblCompra.Text = "Nombre"
        '
        'lblPreforma
        '
        Me.lblPreforma.AutoSize = True
        Me.lblPreforma.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPreforma.ForeColor = System.Drawing.Color.Black
        Me.lblPreforma.Location = New System.Drawing.Point(757, 15)
        Me.lblPreforma.Name = "lblPreforma"
        Me.lblPreforma.Size = New System.Drawing.Size(86, 25)
        Me.lblPreforma.TabIndex = 174
        Me.lblPreforma.Text = "Nombre"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(666, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 25)
        Me.Label12.TabIndex = 173
        Me.Label12.Text = "Anulada :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(669, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 25)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Compra :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(658, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 25)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Preforma :"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblUsuario.Location = New System.Drawing.Point(217, 40)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(81, 25)
        Me.lblUsuario.TabIndex = 168
        Me.lblUsuario.Text = "Usuario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(124, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 25)
        Me.Label13.TabIndex = 167
        Me.Label13.Text = "Usuario :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(101, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 25)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Proveedor :"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblProveedor.ForeColor = System.Drawing.Color.Black
        Me.lblProveedor.Location = New System.Drawing.Point(217, 15)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(86, 25)
        Me.lblProveedor.TabIndex = 148
        Me.lblProveedor.Text = "Nombre"
        '
        'lblFechaRegistro
        '
        Me.lblFechaRegistro.AutoSize = True
        Me.lblFechaRegistro.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRegistro.Location = New System.Drawing.Point(217, 90)
        Me.lblFechaRegistro.Name = "lblFechaRegistro"
        Me.lblFechaRegistro.Size = New System.Drawing.Size(62, 25)
        Me.lblFechaRegistro.TabIndex = 160
        Me.lblFechaRegistro.Text = "Fecha"
        Me.lblFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(146, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 25)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Total :"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(217, 115)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 25)
        Me.lblTotal.TabIndex = 152
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(66, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 25)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Fecha Compra :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(88, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 25)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "Documento :"
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(217, 65)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(117, 25)
        Me.lblDocumento.TabIndex = 154
        Me.lblDocumento.Text = "Documento"
        Me.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmComprasConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1056, 607)
        Me.Controls.Add(Me.rgbDetalle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmComprasConcepto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.rgbDetalle, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Imprimir.ResumeLayout(False)
        Me.pnx0Imprimir.PerformLayout()
        CType(Me.pbx0Imprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDetalle.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Imprimir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Imprimir As System.Windows.Forms.Label
    Friend WithEvents pbx0Imprimir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbDetalle As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblAnulada As System.Windows.Forms.Label
    Friend WithEvents lblCompra As System.Windows.Forms.Label
    Friend WithEvents lblPreforma As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents lblFlete As System.Windows.Forms.Label
    Friend WithEvents lblCantFlete As System.Windows.Forms.Label
    Friend WithEvents lblgasto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
