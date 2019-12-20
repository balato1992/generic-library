using System.Windows.Forms;

namespace GenericWinForm.Model
{
    public static class DataGridViewHelper
    {
        public static T CreateColumn<T>(
            string strDataPropertyNameAndName,
            string strHeaderText,
            DataGridViewAutoSizeColumnMode AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
            bool readOnly = false,
            bool visible = true) where T : DataGridViewColumn, new()
        {
            T dgvc = new T();

            dgvc.Name = dgvc.DataPropertyName = strDataPropertyNameAndName;
            dgvc.HeaderText = strHeaderText;

            dgvc.AutoSizeMode = AutoSizeMode;
            dgvc.ReadOnly = readOnly;
            dgvc.Visible = visible;
            
            dgvc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            return dgvc;
        }
    }
}
