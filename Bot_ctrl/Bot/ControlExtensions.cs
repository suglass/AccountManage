using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public static class ControlExtensions
    {
        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }

    //This can help you control the scrollbar with scrolling up and down.
    //The position is a little special.
    //Position for scrolling up should be negative.
    //Position for scrolling down should be positive
    public static class PanelExtension
    {
        public static void ScrollDown(this Panel p, int pos)
        {
            //pos passed in should be positive
            using (Control c = new Control() { Parent = p, Height = 1, Top = p.ClientSize.Height + pos })
            {
                p.ScrollControlIntoView(c);
            }
        }
        public static void ScrollUp(this Panel p, int pos)
        {
            //pos passed in should be negative
            using (Control c = new Control() { Parent = p, Height = 1, Top = pos })
            {
                p.ScrollControlIntoView(c);
            }
        }
    }
    public static class DataTableExtensions
    {
        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            try
            {
                int columnIndex = 0;
                foreach (var columnName in columnNames)
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
