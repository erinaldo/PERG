﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmClienteTipoPago
    Private Sub frmTipoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmClientesBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try
        llenagrid()
    End Sub

    Private Sub chkCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCredito.CheckedChanged
        If chkCredito.Checked = True Then
            txtDias.Enabled = True
        Else
            txtDias.Enabled = False
        End If
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblClienteTipoPagoes Select Codigo = x.idtipoPago, x.nombre, chkCredito = x.credito, Dias = x.dias

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            grdDatos.Columns(0).Width = 150
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

        Dim m As New tblClienteTipoPago
        Try
            m.nombre = txtNombre.Text

            If chkCredito.Checked = True Then
                m.credito = True
                m.dias = CType(txtDias.Text, Integer)
            End If

            ctx.AddTotblClienteTipoPagoes(m)
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

            Dim m As tblClienteTipoPago = (From e1 In ctx.tblClienteTipoPagoes Where e1.idtipoPago = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text

            If chkCredito.Checked = True Then
                m.credito = True
                m.dias = CType(txtDias.Text, Integer)
            Else
                m.credito = False
                m.dias = 0
            End If


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
            Dim m As tblClienteTipoPago = (From e1 In ctx.tblClienteTipoPagoes Where e1.idtipoPago = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
End Class
