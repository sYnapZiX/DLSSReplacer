Imports System.IO
Imports System.IO.Compression
Imports DLSSReplacer.My

Public Class MainWindow
    Public Shared ReadOnly Language As String = Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName
    Private ReadOnly Temp As String = Path.GetTempPath

    Private ReadOnly IncludedVersionDLSS4 As String = "310.6.0.0"
    Private ReadOnly IncludedVersionDLSS4FG As String = "310.6.0.0"
    Private ReadOnly IncludedVersionDLSS4RR As String = "310.6.0.0"
    Private ReadOnly IncludedVersionDLSS1 As String = "1.2.14.0"

    Private ReadOnly BackupExtension As String = ".PRE-DLSS-REPLACER"

    Private ReadOnly CleanupDirectories As String() = {Temp & "dlss1",
                                                       Temp & "dlss4"}
    Private CurrentResource As Byte()
    Private CurrentResourceName As String = String.Empty

    Private ReadOnly URL_OnlineResource As String = "https://github.com/sYnapZiX/DLSSReplacer/blob/main/DLSSReplacer/Resources/"
    Private Function ProtectedGame(Path As String) As Boolean
        Return Path.Contains("Call of Duty") OrElse
               Path.Contains("Call Of Duty") OrElse
               Path.Contains("_retail_") OrElse
               Path.Contains("cod19") OrElse
               Path.Contains("cod20") OrElse
               Path.Contains("cod21") OrElse
               Path.Contains("cod22") OrElse
               Path.Contains("cod23") OrElse
               Path.Contains("cod24") OrElse
               Path.Contains("cod25") OrElse
               Path.Contains("cod26") OrElse
               Path.Contains("cod27") OrElse
               Path.Contains("cod28") OrElse
               Path.Contains("cod29")
    End Function
    Private Function ValidDirectory(Path As String) As Boolean
        Return Not Path.EndsWith(":\") AndAlso
               Not Path.Contains("\$RECYCLE.BIN") AndAlso
               Not Path.Contains("\AppData") AndAlso
               Not Path.Contains("\Config.Msi") AndAlso
               Not Path.Contains("\Documents") AndAlso
               Not Path.Contains("\ModifiableWindowsApps") AndAlso
               Not Path.Contains("\ProgramData") AndAlso
               Not Path.Contains("\Projects") AndAlso
               Not Path.Contains("\Recovery") AndAlso
               Not Path.Contains("\system32") AndAlso
               Not Path.Contains("\System Volume Information") AndAlso
               Not Path.Contains("\UE_") AndAlso
               Not Path.Contains("\Unreal Projects") AndAlso
               Not Path.Contains("\Users") AndAlso
               Not Path.Contains("\Windows") AndAlso
               Not Path.Contains("\WindowsApps") AndAlso
               Not Path.Contains("\WpSystem") AndAlso
               Not Path.Contains("\WUDownloadCache")
    End Function
    Private Sub ScanButton_Click(sender As Object, e As EventArgs) Handles ScanButton.Click
        Using PathBrowser As New FolderBrowserDialog
            PathBrowser.ShowNewFolderButton = False
            Dim PathBrowserResult As DialogResult = PathBrowser.ShowDialog()
            Dim FoundEntries As Integer = 0
            If PathBrowserResult = DialogResult.OK Then
                Enabled = False
                UseWaitCursor = True
                If Language = "de" Then
                    ScanButton.Text = "Scanne..."
                    ReplaceButton.Text = "Scanne..."
                Else
                    ScanButton.Text = "Scanning..."
                    ReplaceButton.Text = "Scanning..."
                End If
                ConsoleBox.ForeColor = Color.Black
                ConsoleBox.AppendText("Scanning for replaceable libraries..." & vbNewLine & vbNewLine)
                Dim FilteredDLLPaths As New List(Of String)
                Try
                    If ValidDirectory(PathBrowser.SelectedPath) Then FilteredDLLPaths.Add(PathBrowser.SelectedPath)
                    For Each DLLDirectory As String In Directory.EnumerateDirectories(PathBrowser.SelectedPath)
                        If ValidDirectory(DLLDirectory) Then FilteredDLLPaths.Add(DLLDirectory)
                    Next
                    For Each FilteredDLLPath As String In FilteredDLLPaths
                        For Each DLLFile As String In Directory.EnumerateFiles(FilteredDLLPath, "*.dll", SearchOption.AllDirectories)
                            If ValidDirectory(DLLFile) AndAlso FilePathList.FindItemWithText(DLLFile) Is Nothing Then
                                Application.DoEvents()
                                If DLLFile.EndsWith("nvngx_dlss.dll") Then
                                    ConsoleBox.AppendText("Found dlss library in: " & Path.GetDirectoryName(DLLFile) & vbNewLine)
                                    Dim DLLVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(DLLFile)
                                    Dim DLLVersionInfoString As String = String.Empty
                                    If DLLVersionInfo.FileVersion IsNot Nothing Then
                                        DLLVersionInfoString = DLLVersionInfo.FileVersion.Replace(",", ".")
                                    End If
                                    If DLLVersionInfoString.StartsWith("310") Then ' ############################################################################################################################################################################################### DLSS 3
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4, "DLSS 4 Library")
                                    ElseIf DLLVersionInfoString.StartsWith("3") Then ' ############################################################################################################################################################################################### DLSS 3
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4, "DLSS 3 Library")
                                    ElseIf DLLVersionInfoString.StartsWith("2") Then ' ########################################################################################################################################################################################### DLSS 2
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4, "DLSS 2 Library")
                                    ElseIf DLLVersionInfoString.StartsWith("1") Then ' ########################################################################################################################################################################################### DLSS 1
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS1, "DLSS 1 Library")
                                    End If
                                    FoundEntries += 1
                                ElseIf DLLFile.EndsWith("nvngx_dlssd.dll") Then
                                    ConsoleBox.AppendText("Found ray-reconstruction library in: " & Path.GetDirectoryName(DLLFile) & vbNewLine)
                                    Dim DLLVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(DLLFile)
                                    Dim DLLVersionInfoString As String = String.Empty
                                    If DLLVersionInfo.FileVersion IsNot Nothing Then
                                        DLLVersionInfoString = DLLVersionInfo.FileVersion.Replace(",", ".")
                                    End If
                                    If DLLVersionInfoString.StartsWith("310") Then ' ############################################################################################################################################################################################### DLSS 3 Ray-Reconstruction
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4RR, "DLSS 4 Ray-Reconstruction Library")
                                    ElseIf DLLVersionInfoString.StartsWith("3") Then ' ############################################################################################################################################################################################### DLSS 3 Ray-Reconstruction
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4RR, "DLSS 3 Ray-Reconstruction Library")
                                    End If
                                    FoundEntries += 1
                                ElseIf DLLFile.EndsWith("nvngx_dlssg.dll") Then
                                    ConsoleBox.AppendText("Found frame-generation library in: " & Path.GetDirectoryName(DLLFile) & vbNewLine)
                                    Dim DLLVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(DLLFile)
                                    Dim DLLVersionInfoString As String = String.Empty
                                    If DLLVersionInfo.FileVersion IsNot Nothing Then
                                        DLLVersionInfoString = DLLVersionInfo.FileVersion.Replace(",", ".")
                                    End If
                                    If DLLVersionInfoString.StartsWith("310") Then ' ############################################################################################################################################################################################### DLSS 3 Frame-Generation
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4FG, "DLSS 4 Frame-Generation Library")
                                    ElseIf DLLVersionInfoString.StartsWith("3") Then ' ############################################################################################################################################################################################### DLSS 3 Frame-Generation
                                        AddListItem(DLLFile, DLLVersionInfoString, IncludedVersionDLSS4FG, "DLSS 3 Frame-Generation Library")
                                    End If
                                    FoundEntries += 1
                                End If
                                Application.DoEvents()
                            End If
                        Next
                    Next
                Catch ex As Exception
#If DEBUG Then
                    Console.WriteLine(ex.ToString)
#End If
                End Try
                FilteredDLLPaths.Clear()
                ConsoleBox.AppendText(vbNewLine & "Finished!" & vbNewLine & "Found: " & FoundEntries.ToString & " replaceable libraries." & vbNewLine & vbNewLine)
                ConsoleBox.ForeColor = Color.Chartreuse
                If Language = "de" Then
                    ScanButton.Text = "Laufwerk/Ordner scannen..."
                    ReplaceButton.Text = "Ersetzen"
                Else
                    ScanButton.Text = "Scan Drive/Folder..."
                    ReplaceButton.Text = "Replace"
                End If
                UseWaitCursor = False
                Enabled = True
                ReplaceButton.Enabled = True
            End If
        End Using
    End Sub
    Private Sub ReplaceButton_Click(sender As Object, e As EventArgs) Handles ReplaceButton.Click
        Enabled = False
        UseWaitCursor = True
        If Language = "de" Then
            ScanButton.Text = "Ersetze..."
            ReplaceButton.Text = "Ersetze..."
        Else
            ScanButton.Text = "Replacing..."
            ReplaceButton.Text = "Replacing..."
        End If
        ConsoleBox.ForeColor = Color.Black
        ConsoleBox.AppendText("Replacing libraries..." & vbNewLine & vbNewLine)
        Dim ReplacedDLLsDirectStorage As Integer = 0
        Dim ReplacedDLLsDLSS4 As Integer = 0
        Dim ReplacedDLLsDLSS3 As Integer = 0
        Dim ReplacedDLLsDLSS2 As Integer = 0
        Dim ReplacedDLLsDLSS1 As Integer = 0
        CleanUp()
        Try
            For i = 0 To FilePathList.Items.Count - 1
                Dim DLLFile As String = FilePathList.Items.Item(i).SubItems(0).Text
                Dim CurrentVersion As String = FilePathList.Items.Item(i).SubItems(1).Text
                Dim IncludedVersion As String = FilePathList.Items.Item(i).SubItems(2).Text
                If ForceReplaceToolStripMenuItem.Checked OrElse (CurrentVersion <> IncludedVersion AndAlso Not IncludedVersion = "None" AndAlso Not IncludedVersion = "Keiner") Then
                    If DLLFile.EndsWith("nvngx_dlss.dll") Then
                        If CurrentVersion.StartsWith("4") Then ' ################################################################################################################################################################################################################# DLSS 4
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlss.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS4 += 1
                        ElseIf CurrentVersion.StartsWith("3") Then '############################################################################################################################################################################################################## DLSS 3
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlss.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS3 += 1
                        ElseIf CurrentVersion.StartsWith("2") Then '############################################################################################################################################################################################################## DLSS 2
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlss.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS2 += 1
                        ElseIf CurrentVersion.StartsWith("1") Then '############################################################################################################################################################################################################## DLSS 1
                            ReplaceDLL(My.Resources.dlss1, "dlss1", "nvngx_dlss.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS1 += 1
                        End If
                    ElseIf DLLFile.EndsWith("nvngx_dlssd.dll") Then
                        If CurrentVersion.StartsWith("4") Then ' ################################################################################################################################################################################################################# DLSS 4 Ray-Reconstruction
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlssd.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS4 += 1
                        ElseIf CurrentVersion.StartsWith("3") Then ' ############################################################################################################################################################################################################# DLSS 3 Ray-Reconstruction
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlssd.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS3 += 1
                        End If
                    ElseIf DLLFile.EndsWith("nvngx_dlssg.dll") Then
                        If CurrentVersion.StartsWith("4") Then ' ################################################################################################################################################################################################################# DLSS 4 Frame-Generation
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlssg.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS4 += 1
                        ElseIf CurrentVersion.StartsWith("3") Then ' ############################################################################################################################################################################################################# DLSS 3 Frame-Generation
                            ReplaceDLL(My.Resources.dlss4, "dlss4", "nvngx_dlssg.dll", DLLFile, FilePathList.Items.Item(i).SubItems(1), FilePathList.Items.Item(i).SubItems(2), FilePathList.Items.Item(i).SubItems(3))
                            ReplacedDLLsDLSS3 += 1
                        End If
                    End If
                Else
                    ConsoleBox.AppendText("Skipping: " & DLLFile & vbNewLine)
                End If
            Next
            CleanUp()
            UseWaitCursor = False
            ConsoleBox.AppendText(vbNewLine & "Finished!" & vbNewLine & "Replaced: " & (ReplacedDLLsDLSS3 + ReplacedDLLsDLSS2 + ReplacedDLLsDLSS1 + ReplacedDLLsDirectStorage).ToString & " libraries." & vbNewLine & vbNewLine)
            If Language = "de" Then
                ScanButton.Text = "Laufwerk/Ordner scannen..."
                ReplaceButton.Text = "Ersetzen"
                MessageBox.Show("Abgeschlossen!" & vbNewLine &
                            "DLSS 4 Libraries: " & ReplacedDLLsDLSS4.ToString & " ersetzt." & vbNewLine &
                            "DLSS 3 Libraries: " & ReplacedDLLsDLSS3.ToString & " ersetzt." & vbNewLine &
                            "DLSS 2 Libraries: " & ReplacedDLLsDLSS2.ToString & " ersetzt." & vbNewLine &
                            "DLSS 1 Libraries: " & ReplacedDLLsDLSS1.ToString & " ersetzt." & vbNewLine &
                            "Direct-Storage Libraries: " & ReplacedDLLsDirectStorage.ToString & " ersetzt.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ScanButton.Text = "Scan Drive/Folder..."
                ReplaceButton.Text = "Replace"
                MessageBox.Show("Done!" & vbNewLine &
                            "DLSS 4 Libraries: " & ReplacedDLLsDLSS4.ToString & " replaced." & vbNewLine &
                            "DLSS 3 Libraries: " & ReplacedDLLsDLSS3.ToString & " replaced." & vbNewLine &
                            "DLSS 2 Libraries: " & ReplacedDLLsDLSS2.ToString & " replaced." & vbNewLine &
                            "DLSS 1 Libraries: " & ReplacedDLLsDLSS1.ToString & " replaced." & vbNewLine &
                            "Direct-Storage Libraries: " & ReplacedDLLsDirectStorage.ToString & " replaced.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch
            UseWaitCursor = False
            ConsoleBox.AppendText(vbNewLine & "Failed!" & vbNewLine & vbNewLine)
            ConsoleBox.ForeColor = Color.Chartreuse
            If Language = "de" Then
                ScanButton.Text = "Laufwerk/Ordner scannen..."
                ReplaceButton.Text = "Ersetzen"
                MessageBox.Show("Fehler!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ScanButton.Text = "Scan Drive/Folder..."
                ReplaceButton.Text = "Replace"
                MessageBox.Show("Error!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
        Enabled = True
    End Sub

    ' #######################################################################################################################################################################################################################################################################################################################################
    ' ################################################################################################ ░▒▓███████▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓███████▓▒░ ░▒▓██████▓▒░░▒▓███████▓▒░▒▓████████▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' ############################################################################################### ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░     ░▒▓█▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' ############################################################################################### ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░   ░▒▓██▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' ################################################################################################ ░▒▓██████▓▒░ ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓███████▓▒░  ░▒▓██▓▒░  ░▒▓█▓▒░░▒▓██████▓▒░  #####################################################################################################################################
    ' ###################################################################################################### ░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓██▓▒░    ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' ###################################################################################################### ░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░     ░▒▓█▓▒░      ░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' ############################################################################################### ░▒▓███████▓▒░   ░▒▓█▓▒░   ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░     ░▒▓████████▓▒░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░ #####################################################################################################################################
    ' #######################################################################################################################################################################################################################################################################################################################################
    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ConsoleBox.AppendText("Ready for work! - " & Text & " - by sYnapZiX" & vbNewLine & vbNewLine)
        If GitHubUpdater.Check() Then GitHubUpdater.Download()
    End Sub
    Private Sub CleanUp()
        For Each CleanupDirectory As String In CleanupDirectories
            Try
                If Directory.Exists(CleanupDirectory) Then Directory.Delete(CleanupDirectory, True)
            Catch
            End Try
        Next
        For Each CleanupFile As String In CleanupDirectories
            Try
                If File.Exists(CleanupFile & ".zip") Then File.Delete(CleanupFile & ".zip")
            Catch
            End Try
        Next
    End Sub
    Private Sub AddListItem(DLLFile As String, CurrentVersion As String, IncludedVersion As String, Type As String)
        Try
            If File.Exists(DLLFile & BackupExtension) Then
                Dim DLLBackupVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(DLLFile & BackupExtension)
                Dim DLLBackupVersionInfoString As String = DLLBackupVersionInfo.FileVersion.Replace(",", ".")
                If Language = "de" Then
                    If ProtectedGame(DLLFile) Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Geschützt", DLLBackupVersionInfoString, Type})
                    ElseIf CurrentVersion = IncludedVersion Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Keiner", DLLBackupVersionInfoString, Type})
                    Else
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, IncludedVersion, DLLBackupVersionInfoString, Type})
                    End If
                Else
                    If ProtectedGame(DLLFile) Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Protected", DLLBackupVersionInfoString, Type})
                    ElseIf CurrentVersion = IncludedVersion Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "None", DLLBackupVersionInfoString, Type})
                    Else
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, IncludedVersion, DLLBackupVersionInfoString, Type})
                    End If
                End If
            Else
                If Language = "de" Then
                    If ProtectedGame(DLLFile) Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Geschützt", "Keines", Type})
                    ElseIf CurrentVersion = IncludedVersion Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Keiner", "Keines", Type})
                    Else
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, IncludedVersion, "Keines", Type})
                    End If
                Else
                    If ProtectedGame(DLLFile) Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "Protected", "None", Type})
                    ElseIf CurrentVersion = IncludedVersion Then
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, "None", "None", Type})
                    Else
                        FilePathList.Items.Add(DLLFile).SubItems.AddRange({CurrentVersion, IncludedVersion, "None", Type})
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub ReplaceDLL(Resource As Byte(), ResourceName As String, ResourceDLL As String, DLLName As String, CurrentColumn As ListViewItem.ListViewSubItem, IncludedColumn As ListViewItem.ListViewSubItem, BackupColumn As ListViewItem.ListViewSubItem)
        If IncludedColumn.Text = "Geschützt" OrElse
           IncludedColumn.Text = "Protected" Then Exit Sub
        CurrentResource = Resource
        CurrentResourceName = ResourceName
        If Not Directory.Exists(Temp & "\" & ResourceName) Then
            File.WriteAllBytes(Temp & ResourceName & ".zip", Resource)
            ZipFile.ExtractToDirectory(Temp & ResourceName & ".zip", Temp)
            File.Delete(Temp & ResourceName & ".zip")
        End If
        If AutoBackupToolStripMenuItem.Checked Then
            If File.Exists(DLLName & BackupExtension) Then
                File.Delete(DLLName)
            Else
                File.Move(DLLName, DLLName & BackupExtension)
                BackupColumn.Text = CurrentColumn.Text
            End If
        Else
            File.Delete(DLLName)
        End If
        ConsoleBox.AppendText("Replacing: " & DLLName & vbNewLine)
        File.Copy(Temp & "\" & ResourceName & "\" & ResourceDLL, DLLName)
        CurrentColumn.Text = IncludedColumn.Text
        IncludedColumn.Text = "None"
    End Sub
    Private Sub FileListMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileListMenu.Opening
        RemoveAllToolStripMenuItem.Enabled = FilePathList.Items.Count > 0
        If FilePathList.SelectedItems.Count > 0 Then
            RemoveToolStripMenuItem.Enabled = True
            RestoreBackupToolStripMenuItem.Enabled = True
            CreateBackupToolStripMenuItem.Enabled = True
            DeleteBackupToolStripMenuItem.Enabled = True
        Else
            RemoveToolStripMenuItem.Enabled = False
            RestoreBackupToolStripMenuItem.Enabled = False
            CreateBackupToolStripMenuItem.Enabled = False
            DeleteBackupToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        For Each SelectedItem As ListViewItem In FilePathList.SelectedItems
            ConsoleBox.AppendText("Removed: " & SelectedItem.Text & " from list." & vbNewLine)
            SelectedItem.Remove()
        Next
        If FilePathList.Items.Count = 0 Then ReplaceButton.Enabled = False
        ConsoleBox.AppendText(vbNewLine)
    End Sub
    Private Sub RemoveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllToolStripMenuItem.Click
        ConsoleBox.AppendText("Cleared list." & vbNewLine)
        FilePathList.Items.Clear()
        ReplaceButton.Enabled = False
    End Sub
    Private Sub RestoreBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreBackupToolStripMenuItem.Click
        Dim RestoredDLLs As Integer = 0
        For Each SelectedItem As ListViewItem In FilePathList.SelectedItems
            If Not SelectedItem.SubItems.Item(3).Text = "None" AndAlso Not SelectedItem.SubItems.Item(1).Text = SelectedItem.SubItems.Item(3).Text Then
                Try
                    File.Delete(SelectedItem.Text)
                    File.Move(SelectedItem.Text & BackupExtension, SelectedItem.Text)
                    ConsoleBox.AppendText("Restored: " & SelectedItem.Text & vbNewLine)
                    SelectedItem.SubItems.Item(1).Text = SelectedItem.SubItems.Item(3).Text
                    RestoredDLLs += 1
                Catch
                End Try
            End If
        Next
        ConsoleBox.AppendText(vbNewLine)
        MessageBox.Show("Done!" & vbNewLine &
                        "Restored: " & RestoredDLLs.ToString & " Libraries.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub CreateBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateBackupToolStripMenuItem.Click
        Dim CreatedBackups As Integer = 0
        For Each SelectedItem As ListViewItem In FilePathList.SelectedItems
            If SelectedItem.SubItems.Item(3).Text = "None" OrElse Not SelectedItem.SubItems.Item(1).Text = SelectedItem.SubItems.Item(3).Text Then
                Try
                    File.Copy(SelectedItem.Text, SelectedItem.Text & BackupExtension)
                    ConsoleBox.AppendText("Backup: " & SelectedItem.Text & vbNewLine)
                    SelectedItem.SubItems.Item(3).Text = SelectedItem.SubItems.Item(1).Text
                    CreatedBackups += 1
                Catch
                End Try
            End If
        Next
        ConsoleBox.AppendText(vbNewLine)
        MessageBox.Show("Done!" & vbNewLine &
                        "Created: " & CreatedBackups.ToString & " Backups.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub DeleteBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteBackupToolStripMenuItem.Click
        Dim DeletedBackups As Integer = 0
        For Each SelectedItem As ListViewItem In FilePathList.SelectedItems
            If Not SelectedItem.SubItems.Item(3).Text = "None" Then
                File.Delete(SelectedItem.Text & BackupExtension)
                ConsoleBox.AppendText("Backup: " & SelectedItem.Text & " deleted." & vbNewLine)
                SelectedItem.SubItems.Item(3).Text = "None"
                DeletedBackups += 1
            End If
        Next
        ConsoleBox.AppendText(vbNewLine)
        MessageBox.Show("Done!" & vbNewLine &
                        "Deleted: " & DeletedBackups.ToString & " Backups.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub ConsoleBox_Click(sender As Object, e As EventArgs) Handles ConsoleBox.Click
        ConsoleBox.Visible = False
        ConsoleBox.SendToBack()
        ShowConsoleToolStripMenuItem.Checked = False
        ConsoleBox.Visible = ShowConsoleToolStripMenuItem.Checked
        ShowConsoleToolStripMenuItem1.Checked = ShowConsoleToolStripMenuItem.Checked
        ShowConsoleToolStripMenuItem2.Checked = ShowConsoleToolStripMenuItem.Checked
    End Sub
    Private Sub ShowConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowConsoleToolStripMenuItem.Click, ShowConsoleToolStripMenuItem1.Click, ShowConsoleToolStripMenuItem2.Click
        If ShowConsoleToolStripMenuItem.Checked Then
            ShowConsoleToolStripMenuItem.Checked = False
            ConsoleBox.SendToBack()
        Else
            ShowConsoleToolStripMenuItem.Checked = True
            ConsoleBox.BringToFront()
        End If
        ConsoleBox.Visible = ShowConsoleToolStripMenuItem.Checked
        ShowConsoleToolStripMenuItem1.Checked = ShowConsoleToolStripMenuItem.Checked
        ShowConsoleToolStripMenuItem2.Checked = ShowConsoleToolStripMenuItem.Checked
    End Sub
    Private Sub SaveLogFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveLogFileToolStripMenuItem.Click
        Using SaveFile As New FolderBrowserDialog
            Dim SaveFileResult As DialogResult = SaveFile.ShowDialog
            If SaveFileResult = DialogResult.OK Then
                Try
                    Using LogWriter As New StreamWriter(SaveFile.SelectedPath & "\" & Now.Day.ToString("00") & Now.Month.ToString("00") & Now.Year.ToString() & Now.Hour.ToString("00") & Now.Minute.ToString("00") & Now.Second.ToString("00") & ".log", False)
                        LogWriter.Write(ConsoleBox.Text)
                        LogWriter.Flush()
                        LogWriter.Close()
                    End Using
                Catch
                    MessageBox.Show("Error!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub
    Private Sub ClearConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearConsoleToolStripMenuItem.Click
        ConsoleBox.Clear()
        ConsoleBox.AppendText("Ready for work! - " & Text & " - by sYnapZiX" & vbNewLine & vbNewLine)
    End Sub
    Private Sub ConsoleBox_TextChanged(sender As Object, e As EventArgs) Handles ConsoleBox.TextChanged
        ConsoleBox.ScrollToCaret()
    End Sub
    Private Sub AutoBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoBackupToolStripMenuItem.Click, AutoBackupToolStripMenuItem1.Click
        If AutoBackupToolStripMenuItem.Checked Then
            AutoBackupToolStripMenuItem.Checked = False
        Else
            AutoBackupToolStripMenuItem.Checked = True
        End If
        AutoBackupToolStripMenuItem1.Checked = AutoBackupToolStripMenuItem.Checked
    End Sub
    Private Sub ForceReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForceReplaceToolStripMenuItem.Click, ForceReplaceToolStripMenuItem1.Click
        If ForceReplaceToolStripMenuItem.Checked Then
            ForceReplaceToolStripMenuItem.Checked = False
        Else
            ForceReplaceToolStripMenuItem.Checked = True
        End If
        ForceReplaceToolStripMenuItem1.Checked = ForceReplaceToolStripMenuItem.Checked
    End Sub
    Private Sub NVIDIADLSS1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NVIDIADLSS1ToolStripMenuItem.Click, DLSS1ToolStripMenuItem.Click, DLSS1ToolStripMenuItem1.Click
        Using ExtractFile As New FolderBrowserDialog
            Dim ExtractFileResult As DialogResult = ExtractFile.ShowDialog
            If ExtractFileResult = DialogResult.OK Then
                Dim ReplacedFiles As Integer = 0
                CurrentResource = My.Resources.dlss1
                CurrentResourceName = "dlss1"
                Try
                    If Not Directory.Exists(Temp & "\dlss1") Then
                        File.WriteAllBytes(Temp & "dlss1.zip", CurrentResource)
                        ZipFile.ExtractToDirectory(Temp & "dlss1.zip", Temp)
                        File.Delete(Temp & "dlss1.zip")
                    End If
                    If File.Exists(ExtractFile.SelectedPath & "\nvngx_dlss.dll") Then
                        If Not File.Exists(ExtractFile.SelectedPath & "\nvngx_dlss.bak") Then File.Move(ExtractFile.SelectedPath & "\nvngx_dlss.dll", ExtractFile.SelectedPath & "\nvngx_dlss.bak")
                        File.Copy(Temp & "dlss1\nvngx_dlss.dll", ExtractFile.SelectedPath & "\nvngx_dlss.dll")
                        ReplacedFiles += 1
                    End If
                    If Language = "de" Then
                        ScanButton.Text = "Laufwerk/Ordner scannen..."
                        ReplaceButton.Text = "Ersetzen"
                        MessageBox.Show("Abgeschlossen!" & vbNewLine &
                                        "Datei(en): " & ReplacedFiles.ToString & " ersetzt.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ScanButton.Text = "Scan Drive/Folder..."
                        ReplaceButton.Text = "Replace"
                        MessageBox.Show("Done!" & vbNewLine &
                                        "Files: " & ReplacedFiles.ToString & " replaced.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch
                    If Language = "de" Then
                        ScanButton.Text = "Laufwerk/Ordner scannen..."
                        ReplaceButton.Text = "Ersetzen"
                        MessageBox.Show("Fehler!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        ScanButton.Text = "Scan Drive/Folder..."
                        ReplaceButton.Text = "Replace"
                        MessageBox.Show("Error!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
            End If
        End Using
    End Sub
    Private Sub NVIDIADLSS4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NVIDIADLSS4ToolStripMenuItem.Click, DLSS4ToolStripMenuItem.Click, DLSS4ToolStripMenuItem1.Click
        Using ExtractFile As New FolderBrowserDialog
            Dim ExtractFileResult As DialogResult = ExtractFile.ShowDialog
            If ExtractFileResult = DialogResult.OK Then
                Dim ReplacedFiles As Integer = 0
                CurrentResource = My.Resources.dlss4
                CurrentResourceName = "dlss4"
                Try
                    If Not Directory.Exists(Temp & "dlss4") Then
                        File.WriteAllBytes(Temp & "dlss4.zip", CurrentResource)
                        ZipFile.ExtractToDirectory(Temp & "dlss4.zip", Temp)
                        File.Delete(Temp & "dlss4.zip")
                    End If
                    If File.Exists(ExtractFile.SelectedPath & "\nvngx_dlss.dll") Then
                        If Not File.Exists(ExtractFile.SelectedPath & "\nvngx_dlss.bak") Then File.Move(ExtractFile.SelectedPath & "\nvngx_dlss.dll", ExtractFile.SelectedPath & "\nvngx_dlss.bak")
                        File.Copy(Temp & "dlss4\nvngx_dlss.dll", ExtractFile.SelectedPath & "\nvngx_dlss.dll")
                        ReplacedFiles += 1
                    End If
                    If File.Exists(ExtractFile.SelectedPath & "\nvngx_dlssd.dll") Then
                        If Not File.Exists(ExtractFile.SelectedPath & "\nvngx_dlssd.bak") Then File.Move(ExtractFile.SelectedPath & "\nvngx_dlssd.dll", ExtractFile.SelectedPath & "\nvngx_dlssd.bak")
                        File.Copy(Temp & "dlss4\nvngx_dlssd.dll", ExtractFile.SelectedPath & "\nvngx_dlssd.dll")
                        ReplacedFiles += 1
                    End If
                    If File.Exists(ExtractFile.SelectedPath & "\nvngx_dlssg.dll") Then
                        If Not File.Exists(ExtractFile.SelectedPath & "\nvngx_dlssg.bak") Then File.Move(ExtractFile.SelectedPath & "\nvngx_dlssg.dll", ExtractFile.SelectedPath & "\nvngx_dlssg.bak")
                        File.Copy(Temp & "dlss4\nvngx_dlssg.dll", ExtractFile.SelectedPath & "\nvngx_dlssg.dll")
                        ReplacedFiles += 1
                    End If
                    If Language = "de" Then
                        ScanButton.Text = "Laufwerk/Ordner scannen..."
                        ReplaceButton.Text = "Ersetzen"
                        MessageBox.Show("Abgeschlossen!" & vbNewLine &
                                        "Datei(en): " & ReplacedFiles.ToString & " ersetzt.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ScanButton.Text = "Scan Drive/Folder..."
                        ReplaceButton.Text = "Replace"
                        MessageBox.Show("Done!" & vbNewLine &
                                        "Files: " & ReplacedFiles.ToString & " replaced.", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch
                    If Language = "de" Then
                        ScanButton.Text = "Laufwerk/Ordner scannen..."
                        ReplaceButton.Text = "Ersetzen"
                        MessageBox.Show("Fehler!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        ScanButton.Text = "Scan Drive/Folder..."
                        ReplaceButton.Text = "Replace"
                        MessageBox.Show("Error!", "DLSS Replacer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
            End If
        End Using
    End Sub
    Private Function PingGitHub() As Boolean
        If OfflineModeToolStripMenuItem.Checked Then
            Return False
        Else
            Return My.Computer.Network.Ping("www.github.com")
        End If
    End Function
    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each CleanupDirectory As String In CleanupDirectories
            Try
                Directory.Delete(CleanupDirectory, True)
            Catch
            End Try
        Next
    End Sub
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = My.Application.Info.ProductName & " " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        If Not My.Computer.Network.Ping("www.github.com", 250) Then
            OfflineModeToolStripMenuItem.Checked = True
            OfflineModeToolStripMenuItem1.Checked = True
            OfflineModeToolStripMenuItem2.Checked = True
        End If
    End Sub
    Private Sub OfflineModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfflineModeToolStripMenuItem.Click, OfflineModeToolStripMenuItem2.Click, OfflineModeToolStripMenuItem1.Click
        OfflineModeToolStripMenuItem.Checked = Not OfflineModeToolStripMenuItem.Checked
        OfflineModeToolStripMenuItem1.Checked = OfflineModeToolStripMenuItem.Checked
        OfflineModeToolStripMenuItem2.Checked = OfflineModeToolStripMenuItem.Checked
    End Sub
End Class
