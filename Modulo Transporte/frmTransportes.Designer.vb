﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransportes
    Inherits laFuente.frmBaseTelerik

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
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pageDatos = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtKmGalon = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoTransporte = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pageDatos.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgbDatos
        '
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(125, 32)
        Me.lbTituloFrm.Text = "FrmBaseT"
        '
        'rpv
        '
        Me.rpv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.BackColor = System.Drawing.Color.White
        Me.rpv.Controls.Add(Me.pageDatos)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(3, 56)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1136, 229)
        Me.rpv.TabIndex = 109
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.Label6)
        Me.pageDatos.Controls.Add(Me.txtKmGalon)
        Me.pageDatos.Controls.Add(Me.Label4)
        Me.pageDatos.Controls.Add(Me.txtCapacidad)
        Me.pageDatos.Controls.Add(Me.Label1)
        Me.pageDatos.Controls.Add(Me.txtPlacas)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.cmbTipoTransporte)
        Me.pageDatos.Controls.Add(Me.Label5)
        Me.pageDatos.Controls.Add(Me.txtDescripcion)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1115, 174)
        Me.pageDatos.Text = " Información "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(52, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Km Galon :"
        '
        'txtKmGalon
        '
        Me.txtKmGalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKmGalon.Location = New System.Drawing.Point(122, 146)
        Me.txtKmGalon.Name = "txtKmGalon"
        Me.txtKmGalon.Size = New System.Drawing.Size(315, 20)
        Me.txtKmGalon.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(49, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Capacidad :"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidad.Location = New System.Drawing.Point(122, 120)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(315, 20)
        Me.txtCapacidad.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(71, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Placas :"
        '
        'txtPlacas
        '
        Me.txtPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.Location = New System.Drawing.Point(122, 94)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(315, 20)
        Me.txtPlacas.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Tipo de Transporte :"
        '
        'cmbTipoTransporte
        '
        Me.cmbTipoTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTransporte.FormattingEnabled = True
        Me.cmbTipoTransporte.Location = New System.Drawing.Point(122, 41)
        Me.cmbTipoTransporte.Name = "cmbTipoTransporte"
        Me.cmbTipoTransporte.Size = New System.Drawing.Size(315, 21)
        Me.cmbTipoTransporte.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(43, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Descripcion :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(122, 68)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(315, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(65, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo :"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(122, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 6
        '
        'frmTransportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1143, 529)
        Me.Controls.Add(Me.rpv)
        Me.Name = "frmTransportes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.rpv, 0)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pageDatos.ResumeLayout(False)
        Me.pageDatos.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageDatos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtKmGalon As System.Windows.Forms.TextBox

End Class