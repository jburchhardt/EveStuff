using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EveStuff.Model;
using System.IO;

namespace EveStuff
{
    public partial class MainForm : Form
    {
        private ModelLayer model;
        private EveTypeManager eveTypeManager;
        public MainForm()
        {
             InitializeComponent();
             model = new ModelLayer();
             eveTypeManager = new EveTypeManager(eveTypeDetails, eveTypeList, model);
             eveTypeManager.Update();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var fileSystemWatcher = new FileSystemWatcher
                {
                    Path = @"C:\Users\Jeppe\Documents\EVE\logs\Marketlogs",
                    Filter = "*.txt",
                    IncludeSubdirectories = false,
                    NotifyFilter = NotifyFilters.LastWrite,
                    EnableRaisingEvents = true
                };
                fileSystemWatcher.Changed += fileSystemWatcher_Changed;

            }
            catch (Exception exc)
            {
                var m = exc.Message;
                while (exc.InnerException != null)
                {
                    exc = exc.InnerException;
                    m += "\n" + exc.Message;
                }
                MessageBox.Show(m);
            }

        }

        private void updatePrice( int eveTypeid, double price)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { updatePrice( eveTypeid, price); }));
            }
            else
            {
                var type = model.GetEveType(eveTypeid);
                var info = EveTypeInfoRepository.GetEveTypeInfo(type);
                eveTypeManager.setPrice(info, price);
               
            }
        }


        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            var filelines = File.ReadAllLines(e.FullPath);
            var parser = new EveFileParser(filelines);
            updatePrice(parser.EveTypeID, parser.Price);
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            model.Commit();
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl.SelectedTab == rawMaterialsTab)
            {
                eveTypeManager.Update();
            }

        }
    }
}
