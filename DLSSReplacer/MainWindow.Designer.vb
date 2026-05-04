<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.ScanButton = New System.Windows.Forms.Button()
        Me.ReplaceButton = New System.Windows.Forms.Button()
        Me.FilePathList = New System.Windows.Forms.ListView()
        Me.PathHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CurrentVersionHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NewVersionHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BackupVersionHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TypeHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FileListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutoBackupToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceReplaceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RestoreBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExtractResourceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DirectStorageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DLSS1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DLSS4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleBox = New System.Windows.Forms.RichTextBox()
        Me.ConsoleMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowConsoleToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveLogFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExtractResourceToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DirectStorageToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DLSS1ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DLSS4ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutoBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExtractResourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DirectStorageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NVIDIADLSS1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NVIDIADLSS4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowConsoleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileListMenu.SuspendLayout()
        Me.ConsoleMenu.SuspendLayout()
        Me.MainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ScanButton
        '
        resources.ApplyResources(Me.ScanButton, "ScanButton")
        Me.ScanButton.Name = "ScanButton"
        Me.ScanButton.UseVisualStyleBackColor = True
        '
        'ReplaceButton
        '
        resources.ApplyResources(Me.ReplaceButton, "ReplaceButton")
        Me.ReplaceButton.Name = "ReplaceButton"
        Me.ReplaceButton.UseVisualStyleBackColor = True
        '
        'FilePathList
        '
        resources.ApplyResources(Me.FilePathList, "FilePathList")
        Me.FilePathList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PathHeader, Me.CurrentVersionHeader, Me.NewVersionHeader, Me.BackupVersionHeader, Me.TypeHeader})
        Me.FilePathList.ContextMenuStrip = Me.FileListMenu
        Me.FilePathList.GridLines = True
        Me.FilePathList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.FilePathList.HideSelection = False
        Me.FilePathList.Name = "FilePathList"
        Me.FilePathList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.FilePathList.UseCompatibleStateImageBehavior = False
        Me.FilePathList.View = System.Windows.Forms.View.Details
        '
        'PathHeader
        '
        resources.ApplyResources(Me.PathHeader, "PathHeader")
        '
        'CurrentVersionHeader
        '
        resources.ApplyResources(Me.CurrentVersionHeader, "CurrentVersionHeader")
        '
        'NewVersionHeader
        '
        resources.ApplyResources(Me.NewVersionHeader, "NewVersionHeader")
        '
        'BackupVersionHeader
        '
        resources.ApplyResources(Me.BackupVersionHeader, "BackupVersionHeader")
        '
        'TypeHeader
        '
        resources.ApplyResources(Me.TypeHeader, "TypeHeader")
        '
        'FileListMenu
        '
        resources.ApplyResources(Me.FileListMenu, "FileListMenu")
        Me.FileListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoBackupToolStripMenuItem1, Me.ForceReplaceToolStripMenuItem1, Me.ToolStripSeparator5, Me.RemoveToolStripMenuItem, Me.RemoveAllToolStripMenuItem, Me.ToolStripSeparator1, Me.RestoreBackupToolStripMenuItem, Me.CreateBackupToolStripMenuItem, Me.DeleteBackupToolStripMenuItem, Me.ToolStripSeparator7, Me.ExtractResourceToolStripMenuItem1, Me.ToolStripSeparator2, Me.ShowConsoleToolStripMenuItem})
        Me.FileListMenu.Name = "DLSSDLLLISTMENU"
        '
        'AutoBackupToolStripMenuItem1
        '
        resources.ApplyResources(Me.AutoBackupToolStripMenuItem1, "AutoBackupToolStripMenuItem1")
        Me.AutoBackupToolStripMenuItem1.Checked = True
        Me.AutoBackupToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoBackupToolStripMenuItem1.Name = "AutoBackupToolStripMenuItem1"
        '
        'ForceReplaceToolStripMenuItem1
        '
        resources.ApplyResources(Me.ForceReplaceToolStripMenuItem1, "ForceReplaceToolStripMenuItem1")
        Me.ForceReplaceToolStripMenuItem1.Name = "ForceReplaceToolStripMenuItem1"
        '
        'ToolStripSeparator5
        '
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        '
        'RemoveToolStripMenuItem
        '
        resources.ApplyResources(Me.RemoveToolStripMenuItem, "RemoveToolStripMenuItem")
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        '
        'RemoveAllToolStripMenuItem
        '
        resources.ApplyResources(Me.RemoveAllToolStripMenuItem, "RemoveAllToolStripMenuItem")
        Me.RemoveAllToolStripMenuItem.Name = "RemoveAllToolStripMenuItem"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'RestoreBackupToolStripMenuItem
        '
        resources.ApplyResources(Me.RestoreBackupToolStripMenuItem, "RestoreBackupToolStripMenuItem")
        Me.RestoreBackupToolStripMenuItem.Name = "RestoreBackupToolStripMenuItem"
        '
        'CreateBackupToolStripMenuItem
        '
        resources.ApplyResources(Me.CreateBackupToolStripMenuItem, "CreateBackupToolStripMenuItem")
        Me.CreateBackupToolStripMenuItem.Name = "CreateBackupToolStripMenuItem"
        '
        'DeleteBackupToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteBackupToolStripMenuItem, "DeleteBackupToolStripMenuItem")
        Me.DeleteBackupToolStripMenuItem.Name = "DeleteBackupToolStripMenuItem"
        '
        'ToolStripSeparator7
        '
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        '
        'ExtractResourceToolStripMenuItem1
        '
        resources.ApplyResources(Me.ExtractResourceToolStripMenuItem1, "ExtractResourceToolStripMenuItem1")
        Me.ExtractResourceToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DirectStorageToolStripMenuItem1, Me.DLSS1ToolStripMenuItem, Me.DLSS4ToolStripMenuItem})
        Me.ExtractResourceToolStripMenuItem1.Name = "ExtractResourceToolStripMenuItem1"
        '
        'DirectStorageToolStripMenuItem1
        '
        resources.ApplyResources(Me.DirectStorageToolStripMenuItem1, "DirectStorageToolStripMenuItem1")
        Me.DirectStorageToolStripMenuItem1.Name = "DirectStorageToolStripMenuItem1"
        '
        'DLSS1ToolStripMenuItem
        '
        resources.ApplyResources(Me.DLSS1ToolStripMenuItem, "DLSS1ToolStripMenuItem")
        Me.DLSS1ToolStripMenuItem.Name = "DLSS1ToolStripMenuItem"
        '
        'DLSS4ToolStripMenuItem
        '
        resources.ApplyResources(Me.DLSS4ToolStripMenuItem, "DLSS4ToolStripMenuItem")
        Me.DLSS4ToolStripMenuItem.Name = "DLSS4ToolStripMenuItem"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'ShowConsoleToolStripMenuItem
        '
        resources.ApplyResources(Me.ShowConsoleToolStripMenuItem, "ShowConsoleToolStripMenuItem")
        Me.ShowConsoleToolStripMenuItem.Name = "ShowConsoleToolStripMenuItem"
        '
        'ConsoleBox
        '
        resources.ApplyResources(Me.ConsoleBox, "ConsoleBox")
        Me.ConsoleBox.BackColor = System.Drawing.Color.Black
        Me.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ConsoleBox.ContextMenuStrip = Me.ConsoleMenu
        Me.ConsoleBox.DetectUrls = False
        Me.ConsoleBox.ForeColor = System.Drawing.Color.Chartreuse
        Me.ConsoleBox.Name = "ConsoleBox"
        Me.ConsoleBox.ReadOnly = True
        '
        'ConsoleMenu
        '
        resources.ApplyResources(Me.ConsoleMenu, "ConsoleMenu")
        Me.ConsoleMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowConsoleToolStripMenuItem2, Me.ToolStripSeparator3, Me.SaveLogFileToolStripMenuItem, Me.ClearConsoleToolStripMenuItem, Me.ToolStripSeparator8, Me.ExtractResourceToolStripMenuItem2})
        Me.ConsoleMenu.Name = "ContextMenuStrip1"
        '
        'ShowConsoleToolStripMenuItem2
        '
        resources.ApplyResources(Me.ShowConsoleToolStripMenuItem2, "ShowConsoleToolStripMenuItem2")
        Me.ShowConsoleToolStripMenuItem2.Name = "ShowConsoleToolStripMenuItem2"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'SaveLogFileToolStripMenuItem
        '
        resources.ApplyResources(Me.SaveLogFileToolStripMenuItem, "SaveLogFileToolStripMenuItem")
        Me.SaveLogFileToolStripMenuItem.Name = "SaveLogFileToolStripMenuItem"
        '
        'ClearConsoleToolStripMenuItem
        '
        resources.ApplyResources(Me.ClearConsoleToolStripMenuItem, "ClearConsoleToolStripMenuItem")
        Me.ClearConsoleToolStripMenuItem.Name = "ClearConsoleToolStripMenuItem"
        '
        'ToolStripSeparator8
        '
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        '
        'ExtractResourceToolStripMenuItem2
        '
        resources.ApplyResources(Me.ExtractResourceToolStripMenuItem2, "ExtractResourceToolStripMenuItem2")
        Me.ExtractResourceToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DirectStorageToolStripMenuItem2, Me.DLSS1ToolStripMenuItem1, Me.DLSS4ToolStripMenuItem1})
        Me.ExtractResourceToolStripMenuItem2.Name = "ExtractResourceToolStripMenuItem2"
        '
        'DirectStorageToolStripMenuItem2
        '
        resources.ApplyResources(Me.DirectStorageToolStripMenuItem2, "DirectStorageToolStripMenuItem2")
        Me.DirectStorageToolStripMenuItem2.Name = "DirectStorageToolStripMenuItem2"
        '
        'DLSS1ToolStripMenuItem1
        '
        resources.ApplyResources(Me.DLSS1ToolStripMenuItem1, "DLSS1ToolStripMenuItem1")
        Me.DLSS1ToolStripMenuItem1.Name = "DLSS1ToolStripMenuItem1"
        '
        'DLSS4ToolStripMenuItem1
        '
        resources.ApplyResources(Me.DLSS4ToolStripMenuItem1, "DLSS4ToolStripMenuItem1")
        Me.DLSS4ToolStripMenuItem1.Name = "DLSS4ToolStripMenuItem1"
        '
        'MainMenu
        '
        resources.ApplyResources(Me.MainMenu, "MainMenu")
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoBackupToolStripMenuItem, Me.ForceReplaceToolStripMenuItem, Me.ToolStripSeparator6, Me.ExtractResourceToolStripMenuItem, Me.ToolStripSeparator4, Me.ShowConsoleToolStripMenuItem1})
        Me.MainMenu.Name = "ContextMenuStrip1"
        '
        'AutoBackupToolStripMenuItem
        '
        resources.ApplyResources(Me.AutoBackupToolStripMenuItem, "AutoBackupToolStripMenuItem")
        Me.AutoBackupToolStripMenuItem.Checked = True
        Me.AutoBackupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoBackupToolStripMenuItem.Name = "AutoBackupToolStripMenuItem"
        '
        'ForceReplaceToolStripMenuItem
        '
        resources.ApplyResources(Me.ForceReplaceToolStripMenuItem, "ForceReplaceToolStripMenuItem")
        Me.ForceReplaceToolStripMenuItem.Name = "ForceReplaceToolStripMenuItem"
        '
        'ToolStripSeparator6
        '
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        '
        'ExtractResourceToolStripMenuItem
        '
        resources.ApplyResources(Me.ExtractResourceToolStripMenuItem, "ExtractResourceToolStripMenuItem")
        Me.ExtractResourceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DirectStorageToolStripMenuItem, Me.NVIDIADLSS1ToolStripMenuItem, Me.NVIDIADLSS4ToolStripMenuItem})
        Me.ExtractResourceToolStripMenuItem.Name = "ExtractResourceToolStripMenuItem"
        '
        'DirectStorageToolStripMenuItem
        '
        resources.ApplyResources(Me.DirectStorageToolStripMenuItem, "DirectStorageToolStripMenuItem")
        Me.DirectStorageToolStripMenuItem.Name = "DirectStorageToolStripMenuItem"
        '
        'NVIDIADLSS1ToolStripMenuItem
        '
        resources.ApplyResources(Me.NVIDIADLSS1ToolStripMenuItem, "NVIDIADLSS1ToolStripMenuItem")
        Me.NVIDIADLSS1ToolStripMenuItem.Name = "NVIDIADLSS1ToolStripMenuItem"
        '
        'NVIDIADLSS4ToolStripMenuItem
        '
        resources.ApplyResources(Me.NVIDIADLSS4ToolStripMenuItem, "NVIDIADLSS4ToolStripMenuItem")
        Me.NVIDIADLSS4ToolStripMenuItem.Name = "NVIDIADLSS4ToolStripMenuItem"
        '
        'ToolStripSeparator4
        '
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        '
        'ShowConsoleToolStripMenuItem1
        '
        resources.ApplyResources(Me.ShowConsoleToolStripMenuItem1, "ShowConsoleToolStripMenuItem1")
        Me.ShowConsoleToolStripMenuItem1.Name = "ShowConsoleToolStripMenuItem1"
        '
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.MainMenu
        Me.Controls.Add(Me.ReplaceButton)
        Me.Controls.Add(Me.ScanButton)
        Me.Controls.Add(Me.FilePathList)
        Me.Controls.Add(Me.ConsoleBox)
        Me.Name = "MainWindow"
        Me.FileListMenu.ResumeLayout(False)
        Me.ConsoleMenu.ResumeLayout(False)
        Me.MainMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ScanButton As Button
    Friend WithEvents ReplaceButton As Button
    Friend WithEvents FilePathList As ListView
    Friend WithEvents PathHeader As ColumnHeader
    Friend WithEvents CurrentVersionHeader As ColumnHeader
    Friend WithEvents BackupVersionHeader As ColumnHeader
    Friend WithEvents TypeHeader As ColumnHeader
    Friend WithEvents NewVersionHeader As ColumnHeader
    Friend WithEvents FileListMenu As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RestoreBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsoleBox As RichTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ShowConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainMenu As ContextMenuStrip
    Friend WithEvents ShowConsoleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConsoleMenu As ContextMenuStrip
    Friend WithEvents ShowConsoleToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ClearConsoleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveLogFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents AutoBackupToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ForceReplaceToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ForceReplaceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ExtractResourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DirectStorageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NVIDIADLSS1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NVIDIADLSS4ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ExtractResourceToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DirectStorageToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DLSS1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DLSS4ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ExtractResourceToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents DirectStorageToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents DLSS1ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DLSS4ToolStripMenuItem1 As ToolStripMenuItem
End Class
