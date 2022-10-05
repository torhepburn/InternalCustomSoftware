Imports Microsoft.VisualBasic
Imports ProjectTotalTableAdapters
<System.ComponentModel.DataObject()> _
Public Class Project
    Private _projectsAdapter As tabProjectMainSummaryTableAdapter = Nothing
    Private _projectsSumByPeriodAdapter As tabProjectFinTransSumByPeriodTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As tabProjectMainSummaryTableAdapter
        Get
            If _projectsAdapter Is Nothing Then
                _projectsAdapter = New tabProjectMainSummaryTableAdapter()
            End If

            Return _projectsAdapter
        End Get
    End Property
    Protected ReadOnly Property AdapterProjectSumByPeriod() As tabProjectFinTransSumByPeriodTableAdapter
        Get
            If _projectsSumByPeriodAdapter Is Nothing Then
                _projectsSumByPeriodAdapter = New tabProjectFinTransSumByPeriodTableAdapter()
            End If

            Return _projectsSumByPeriodAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectSummary(ByVal paramProject As String) As ProjectTotal.tabProjectMainSummaryDataTable
        Return Adapter.tabProjectMainSummary_By_Project_GetData(paramProject)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute _
        (System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectSumByPeriod(ByVal paramProject As String) As ProjectTotal.tabProjectFinTransSumByPeriodDataTable
        Return AdapterProjectSumByPeriod.tabProjectFinTransSumByPeriod_GetDataByProject(paramProject)
    End Function
End Class
