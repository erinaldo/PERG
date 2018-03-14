﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class frmImpresora
    Private Sub frmImpresora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbImpresora)
        fnImpresorasSistema(cmbImpresora)
        llenagrid()
    End Sub

    Private Sub fnImpresorasSistema(cmb As ComboBox)
        Dim pd As New PrintDocument
        Dim Impresoras As String

        ' Default printer      
        Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            cmb.Items.Add(Impresoras.ToString)
        Next
        ' selecciona la impresora predeterminada  
        cmb.Text = s_Default_Printer
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblImpresoras _
                       Select Codigo = x.codigo, Nombre = x.nombre, Impresora = x.impresora, chkDefault = x.bitDefault

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            'grdDatos.Columns(0).Width = 150
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblImpresora
        Try
            m.impresora = cmbImpresora.Text
            m.nombre = txtNombre.Text
            m.bitDefault = chkDefault.Checked
            ctx.AddTotblImpresoras(m)
            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try
            Dim m As tblImpresora = (From e1 In ctx.tblImpresoras Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            m.impresora = cmbImpresora.Text
            m.nombre = txtNombre.Text
            m.bitDefault = chkDefault.Checked
            ctx.SaveChanges()

            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro
        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblImpresora = (From e1 In ctx.tblImpresoras Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmImpresora_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Impresoras"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class