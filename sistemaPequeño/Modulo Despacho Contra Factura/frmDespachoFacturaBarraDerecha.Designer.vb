﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespachoFacturaBarraDerecha
    Inherits laFuente.FrmBarraLateral

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
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.pbx1 = New System.Windows.Forms.PictureBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnl2 = New System.Windows.Forms.Panel()
        Me.pbx2 = New System.Windows.Forms.PictureBox()
        Me.lbl2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl1.SuspendLayout()
        CType(Me.pbx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl2.SuspendLayout()
        CType(Me.pbx2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 84)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(50, 408)
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(12, 71)
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(14, 395)
        '
        'pnl1
        '
        Me.pnl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnl1.Controls.Add(Me.pbx1)
        Me.pnl1.Controls.Add(Me.lbl1)
        Me.pnl1.Location = New System.Drawing.Point(16, 112)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(105, 76)
        Me.pnl1.TabIndex = 67
        '
        'pbx1
        '
        Me.pbx1.Image = Global.laFuente.My.Resources.Resources.devolucion_Blanco
        Me.pbx1.Location = New System.Drawing.Point(0, 0)
        Me.pbx1.Name = "pbx1"
        Me.pbx1.Size = New System.Drawing.Size(105, 40)
        Me.pbx1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1.TabIndex = 66
        Me.pbx1.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.White
        Me.lbl1.Location = New System.Drawing.Point(14, 45)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(78, 17)
        Me.lbl1.TabIndex = 65
        Me.lbl1.Text = "Devolucion"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl2
        '
        Me.pnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnl2.Controls.Add(Me.pbx2)
        Me.pnl2.Controls.Add(Me.lbl2)
        Me.pnl2.Location = New System.Drawing.Point(16, 194)
        Me.pnl2.Name = "pnl2"
        Me.pnl2.Size = New System.Drawing.Size(105, 76)
        Me.pnl2.TabIndex = 68
        '
        'pbx2
        '
        Me.pbx2.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx2.Location = New System.Drawing.Point(0, 0)
        Me.pbx2.Name = "pbx2"
        Me.pbx2.Size = New System.Drawing.Size(105, 40)
        Me.pbx2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2.TabIndex = 66
        Me.pbx2.TabStop = False
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.White
        Me.lbl2.Location = New System.Drawing.Point(4, 45)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(96, 17)
        Me.lbl2.TabIndex = 65
        Me.lbl2.Text = "Detalles Envio"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDespachoFacturaBarraDerecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(140, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl2)
        Me.Controls.Add(Me.pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDespachoFacturaBarraDerecha"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnl1, 0)
        Me.Controls.SetChildIndex(Me.lbTituloFrm, 0)
        Me.Controls.SetChildIndex(Me.PictureBox2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.pnl2, 0)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        CType(Me.pbx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl2.ResumeLayout(False)
        Me.pnl2.PerformLayout()
        CType(Me.pbx2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents pbx1 As System.Windows.Forms.PictureBox
    Public WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents pnl2 As System.Windows.Forms.Panel
    Friend WithEvents pbx2 As System.Windows.Forms.PictureBox
    Public WithEvents lbl2 As System.Windows.Forms.Label

End Class
