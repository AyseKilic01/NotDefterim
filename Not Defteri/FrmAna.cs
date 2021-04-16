using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Defteri
{
    public partial class FrmAna : Form
    {
        private int TabCount = 0;
        public FrmAna()
        {
            InitializeComponent();
        }
        #region methodlar
        #region tabs
        private void AddTabs()
        {
            RichTextBox Body = new RichTextBox();
            Body.Name = "Body";
            Body.Dock = DockStyle.Fill;
            Body.ContextMenuStrip = contextMenuStrip1;

            TabPage tab = new TabPage();
            TabCount += 1;
            string DocumentText = "Belge" + TabCount;
            tab.Name = DocumentText;
            tab.Text = DocumentText;
            tab.Controls.Add(Body);
            tabControl1.TabPages.Add(tab);
        }
        private void RemoveTabs()
        {
            if(tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AddTabs();
            }
        }
        private void RemoveAllTabs()
        {
            foreach(TabPage tab in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tab);
            }
            AddTabs();
        }
        private void RemoveAllTabsButThis()
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Name != tabControl1.SelectedTab.Name)
                {
                    tabControl1.TabPages.Remove(tab);
                }
            }
            
        }
        #endregion
        #region SaveClose
        private void Save()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf";
            saveFileDialog1.Title = "Save";
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }
        private void SaveAs()
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Text Files|*.txt|C# dosyası|*.cs|Tüm Dosyalar|*.*";
            saveFileDialog1.Title = "Farklı Kaydet";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }
        private void Open()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|C# dosyası|*.cs|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }
        #endregion
        #region Props
        private RichTextBox GetCurrentDocument
        {
            get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; }

        }
        #endregion

        #endregion

        private void tStrNew_Click(object sender, EventArgs e)
        {
            AddTabs();
        }

        private void tSil_Click(object sender, EventArgs e)
        {
            RemoveTabs();
        }

        private void tSOpenClose_Click(object sender, EventArgs e)
        {
            RemoveTabs();
        }

        private void tSAllOpenClose_Click(object sender, EventArgs e)
        {
            RemoveAllTabs();
        }

        private void tSOtherClose_Click(object sender, EventArgs e)
        {
            RemoveAllTabsButThis();
        }

        private void tSKaydet_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tStrSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tStrSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void tStrOpen_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}
