using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EveStuff.Model;

namespace EveStuff
{
    public partial class EveTypeList : UserControl
    {
        public EveTypeList()
        {
            InitializeComponent();
        }

        private IList<EveTypeInfo> _list;
        public IList<EveTypeInfo> DataObject
        {
            set
            {
                _list = value;
                eveTypeInfoBindingSource.DataSource = value;        
            }
            get
            {
                return _list;
            }
        }

        public void RefreshAll()
        {
            eveTypeInfoDataGridView.Refresh();
        }

        public DataGridViewCellEventHandler EveTypeSelected;

        public EveTypeInfo Selected { get; set; }

        private void eveTypeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            Selected = _list[e.RowIndex];
            var h = EveTypeSelected;
            if (h != null)
                EveTypeSelected(sender, e);

        }
    }
}
