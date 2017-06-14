Partial Class CSMR_ID_DataSet
    Partial Class CSMR_IDDataTable

        Private Sub CSMR_IDDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.H_ADDRColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace CSMR_ID_DataSetTableAdapters

    Partial Public Class CSMR_IDTableAdapter
    End Class
End Namespace
