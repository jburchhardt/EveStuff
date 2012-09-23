using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EveStuff.Model;
using System.ComponentModel;

namespace EveStuff
{
    class EveTypeManager
    {
 

        public EveTypeManager(EveTypeDetails details, EveTypeList list, ModelLayer model)
        {
            _list = list;
            _list.EveTypeSelected += eveTypeDataGridView_CellContentClick;
            _details = details;
            _model = model;
       }


        private ModelLayer _model;
        private EveTypeList _list;
        private EveTypeDetails _details;
        private int _groupID = 18;

        private void eveTypeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _details.DataObject = _list.Selected;
        }


        internal void Update()
        {
            var typeList = _model.GetTypesFromGroup(_groupID);
            var infoList = new SortableBindingList<EveTypeInfo>();
            foreach (var type in typeList)
                infoList.Add(EveTypeInfoRepository.GetEveTypeInfo(type));
           _list.DataObject = infoList;
        }

        internal void setPrice(EveTypeInfo info, double price)
        {
             _details.DataObject = info;
            info.Price = price;
            var group = info.BaseType.GroupID;
            if (_groupID == group)
                _list.RefreshAll();
            else
            {
                _groupID = group;
                Update();
            }
        }
    }
}
