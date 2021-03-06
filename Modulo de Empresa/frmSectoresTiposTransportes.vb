﻿Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmSectoresTiposTransportes

    Private Sub frmSector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim iz
            If mdlPublicVars.PuntoVentaPequeno_Activado Then
                iz = New frmClientePequenioBarraIzquierda
            Else
                iz = New frmClientesBarraIzquierda
            End If
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        llenagrid()
        fnLlenarCombo()
        mdlPublicVars.comboActivarFiltro(cmbMunicipio)
        mdlPublicVars.comboActivarFiltro(cmbDepartamento)
        mdlPublicVars.comboActivarFiltro(cmbPais)
        mdlPublicVars.comboActivarFiltro(cmbSector)
        mdlPublicVars.comboActivarFiltro(cmbTipoTransporte)
    End Sub

    'Llenar combo
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim pais = (From x In ctx.tblpais Select codigo = x.idpais, nombre = x.nombre Order By nombre Descending)
            With cmbPais
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = pais
            End With

            Dim tipostransportes = (From x In ctx.tblTiposTransportes Select codigo = x.idTipoTransporte, nombre = x.descripcion Order By nombre Descending)
            With cmbTipoTransporte
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = tipostransportes
            End With

            conn.Close()
        End Using
    End Sub

    'Llenar grid
    Private Sub llenagrid()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'CONSULTAR REGISTROS
            Dim data = From x In ctx.tblSectoresTiposTransportes Select Codigo = x.idSectoresTiposTransporte,
                       Pais = x.tblSectore.tblMunicipio.tbldepartamento.tblregion.tblpai.nombre,
                       Departamento = x.tblSectore.tblMunicipio.tbldepartamento.nombre, Municipio = x.tblSectore.tblMunicipio.nombre,
                       Sector = x.tblSectore.descripcion, TipoTransporte = x.tblTiposTransporte.descripcion,
                       Precio = x.precio, PrecioMinimo = x.preciominimo

            Me.grdDatos.DataSource = data

            conn.Close()
        End Using
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.cmbPais.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.cmbPais.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim m As New tblSectoresTiposTransporte
            Try
                m.idSector = CInt(cmbSector.SelectedValue)
                m.idTipoTransporte = CInt(cmbTipoTransporte.SelectedValue)
                m.precio = nm2Precio.Value
                m.preciominimo = nm2PrecioMinimo.Value

                ctx.AddTotblSectoresTiposTransportes(m)
                ctx.SaveChanges()
                alertas.fnGuardar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorGuardar()
            End Try
            conn.Close()
        End Using
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim m As tblSectoresTiposTransporte = (From e1 In ctx.tblSectoresTiposTransportes Where e1.idSectoresTiposTransporte = Me.txtCodigo.Text Select e1).First()
                m.idSector = CInt(cmbSector.SelectedValue)
                m.idTipoTransporte = CInt(cmbTipoTransporte.SelectedValue)
                m.precio = nm2Precio.Value
                m.preciominimo = nm2PrecioMinimo.Value

                ctx.SaveChanges()
                alertas.fnModificar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorModificar()
            End Try
            conn.Close()

        End Using
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro
        If RadMessageBox.Show("Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
                Dim m As tblSectoresTiposTransporte = (From e1 In ctx.tblSectoresTiposTransportes Where e1.idSectoresTiposTransporte = Me.txtCodigo.Text Select e1).First()

                ctx.DeleteObject(m)
                ctx.SaveChanges()
                alertas.fnEliminar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorEliminar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'CAMBIANDO PAIS
    Private Sub cmbPais_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedValueChanged
        Dim idPais As Integer = CInt(cmbPais.SelectedValue)

        If idPais > 0 Then
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim departamento = (From x In ctx.tbldepartamentoes Where x.tblregion.tblpai.idpais = idPais
                                        Select codigo = x.iddepartamento, nombre = x.nombre)

                With cmbDepartamento
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = departamento
                End With

                conn.Close()
            End Using
        End If
    End Sub

    'CAMBIANDO DEPARTAMENTO
    Private Sub cmbDepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Dim idDepartamento As Integer = CInt(cmbDepartamento.SelectedValue)

        If idDepartamento > 0 Then
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim municipios = (From x In ctx.tblMunicipios Where x.tbldepartamento.iddepartamento = idDepartamento
                                        Select codigo = x.idmunicipio, nombre = x.nombre)

                With cmbMunicipio
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = municipios
                End With

                conn.Close()
            End Using
        End If
    End Sub

    'CAMBIANDO MUNICIPIOS
    Private Sub cmbMunicipio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMunicipio.SelectedValueChanged
        Dim idMunicipio As Integer = CInt(cmbMunicipio.SelectedValue)

        If idMunicipio > 0 Then
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim sectores = (From x In ctx.tblSectores Where x.tblMunicipio.idmunicipio = idMunicipio
                                        Select codigo = x.idSector, nombre = x.descripcion)

                With cmbSector
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = sectores
                End With

                conn.Close()
            End Using
        End If
    End Sub
End Class