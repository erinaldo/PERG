﻿Imports System.Linq
Imports Telerik.WinControls

Public Class frmEditaCosto

#Region "Variables"
    Private _articulo As Integer

    Public Property articulo As Integer
        Get
            articulo = _articulo
        End Get
        Set(ByVal value As Integer)
            _articulo = value
        End Set
    End Property
#End Region

#Region "LOAD"
    Private Sub frmEditaCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenaDatos()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para obtener el costo de un producto
    Private Sub fnLlenaDatos()
        Dim art As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable
                                       Where x.idArticulo = articulo Select x).FirstOrDefault

        If art IsNot Nothing Then
            lblCostoQuetzales.Text = Format(art.costoIVA, mdlPublicVars.formatoMoneda)
            lblCostoDolar.Text = Format(art.costodolar, mdlPublicVars.formatoMonedaDolar)
        End If
    End Sub

#End Region

#Region "Eventos"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Guardamos el nuevo costo, pero primero tiene que ser mayor a cero
        Dim costo As Decimal = nm2CostoQuetzalez.Value
        Dim costodolar As Decimal = nm2CostoDolar.Value
        If costo > 0 Or costodolar > 0 Then
            'Guardamos el nuevo costo

            'Seleccionamos el articulo
            Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = articulo
                                      Select x).FirstOrDefault

            'Realizamos los cambios
            art.costoIVA = costo
            art.costoSinIVA = art.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
            art.CostoDolar = costodolar

            'Guardamos los cambios  
            ctx.SaveChanges()
            alerta.fnGuardar()
            Me.Close()
        Else
            RadMessageBox.Show("El costo ingresado deber ser mayo a 0(cero)", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End If

    End Sub
#End Region

End Class