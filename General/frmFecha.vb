﻿Public Class frmFecha

    Dim b As New clsBase
    Public opcionRetorno
    Public bitgrid1 As Boolean = False

    Private Sub frmFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnNoModificarTam(Me)
    End Sub

    Private Sub fnAgregar()
        Try
            mdlPublicVars.superSearchFecha = mtcFecha.SelectionStart
            mdlPublicVars.superSearchId = 1
            Me.Close()
            If opcionRetorno = "pagoNuevo" Then
                frmPagoNuevo.fnAgregarFecha()

            ElseIf opcionRetorno = "precioInicio" Then
                frmProductoPrecio.fnAgregarFecha()

            ElseIf opcionRetorno = "precioFinal" Then
                mdlPublicVars.superSearchId = 2
                frmProductoPrecio.fnAgregarFecha()

            ElseIf opcionRetorno = "pagoLista" Then
                mdlPublicVars.superSearchFechaString = mtcFecha.SelectionStart & " " & fnHoraServidor()
            End If
        Catch ex As Exception
            mdlPublicVars.superSearchFecha = mtcFecha.SelectionStart
            mdlPublicVars.superSearchId = 0

        End Try

        Me.Close()
    End Sub

    Private Sub fnAgregarFechaSucursal()
        Try
            mdlPublicVars.superSearchFecha = mtcFecha.SelectionStart
            mdlPublicVars.superSearchId = 1
            Me.Close()
            If opcionRetorno = "pagoNuevo" Then
                frmPagoNuevo.fnAgregarFecha()

            ElseIf opcionRetorno = "precioInicio" Then
                frmProductoPrecio.fnAgregarFechaSucursal()
            ElseIf opcionRetorno = "precioFinal" Then
                mdlPublicVars.superSearchId = 2
                frmProductoPrecio.fnAgregarFechaSucursal()
            ElseIf opcionRetorno = "pagoLista" Then
                mdlPublicVars.superSearchFechaString = mtcFecha.SelectionStart & " " & fnHoraServidor()
            End If
        Catch ex As Exception
            mdlPublicVars.superSearchFecha = mtcFecha.SelectionStart
            mdlPublicVars.superSearchId = 0

        End Try

        Me.Close()
    End Sub

    Private Sub mtcFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtcFecha.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                fnAgregar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If bitgrid1 = True Then
            fnAgregar()
        Else
            fnAgregarFechaSucursal()

        End If
        bitgrid1 = False
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class