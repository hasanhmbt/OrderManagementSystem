using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderManagementSystem.Tools
{
    public class ControlFiller
    {

        public void FillControlDataSource(DataGridView dataGridView, SqlDataReader reader)
        {
            BindingSource bindingSource = new();
            bindingSource.DataSource = reader;


            dataGridView.DataSource = null;

            if (reader.HasRows)
            {
                dataGridView.DataSource = bindingSource;
                dataGridView.Columns[0].Visible = false;
            }

        }


        public void FillControlDataSource(ComboBox comboBox, SqlDataReader reader, string valueMember, string displayMember)
        {
            BindingSource bindingSource = new();
            bindingSource.DataSource = reader;

            comboBox.DataSource = null;

            if (reader.HasRows)
            {
                comboBox.DataSource = bindingSource;
                comboBox.ValueMember = valueMember;
                comboBox.DisplayMember = displayMember;
            }


        }


        public void FillControlDataSource(ListBox listBox, SqlDataReader reader, string valueMember, string displayMember)
        {

            BindingSource bindingSource = new();
            bindingSource.DataSource = listBox;

            listBox.DataSource = null;

            if (reader.HasRows)
            {
                listBox.DataSource = bindingSource;
                listBox.ValueMember = valueMember;
                listBox.DisplayMember = displayMember;
            }


        }

    }
}
