﻿Imports System
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Xpo

Namespace CustomizeReportDataExample.Win
    ' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/DevExpressExpressAppWinWinApplicationMembersTopicAll
    Partial Public Class CustomizeReportDataExampleWindowsFormsApplication
        Inherits WinApplication

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
        End Sub
        Private Sub CustomizeReportDataExampleWindowsFormsApplication_CustomizeLanguagesList(ByVal sender As Object, ByVal e As CustomizeLanguagesListEventArgs) Handles MyBase.CustomizeLanguagesList
            Dim userLanguageName As String = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
            If userLanguageName <> "en-US" AndAlso e.Languages.IndexOf(userLanguageName) = -1 Then
                e.Languages.Add(userLanguageName)
            End If
        End Sub
        Private Sub CustomizeReportDataExampleWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub
    End Class
End Namespace
