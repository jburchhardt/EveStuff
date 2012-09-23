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
    public partial class EveTypeDetails : UserControl
    {
        public EveTypeDetails()
        {
            InitializeComponent();
        }

        public EveTypeInfo DataObject
        {
            set
            {
                eveTypeBindingSource.DataSource = value;
            }
        }
    }
}
