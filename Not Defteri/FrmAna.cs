using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            if (tabControl1.TabPages.Count > 0)
            {
                saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "RTF|*.rtf";
                saveFileDialog1.Title = "Save";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Length > 0)
                    {
                        GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }
        private void SaveAs()
        {
            if (tabControl1.TabPages.Count > 0)
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
        #region Textfunctions
        private void UnDo() {
            GetCurrentDocument.Undo();
        }
        private void ReDo()
        {
            GetCurrentDocument.Redo();
        }
        private void Cut()
        {
            GetCurrentDocument.Cut();
        }
        private void Copy()
        {
            GetCurrentDocument.Copy();
        }
        private void Paste()
        {
            GetCurrentDocument.Paste();
        }
        private void SelectAll()
        {
            GetCurrentDocument.SelectAll();
        }
        #endregion
        #region Genel
        private void GetFontCollection()
        {
            InstalledFontCollection fontCollection = new InstalledFontCollection();
            foreach(FontFamily item in fontCollection.Families)
            {
                tSFontType.Items.Add(item.Name);
            }
            tSFontType.SelectedIndex = 0;
        }
        private void PopulateFontSize()
        {
            for(int i = 1; i<=75; i++)
            {
                tSFontSize.Items.Add(i);
            }
            tSFontSize.SelectedIndex = 11;
        }
        #endregion
        #endregion
        #region events
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

        private void tStrUndo_Click(object sender, EventArgs e)
        {
            UnDo();
        }

        private void tStrRedo_Click(object sender, EventArgs e)
        {
            ReDo();
        }

        private void tStrCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void tStrCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void tStrPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void tStrSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void tSNew_Click(object sender, EventArgs e)
        {
            AddTabs();
        }

        private void tSOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tSSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tSCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void tSCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void tSPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void tSBold_Click(object sender, EventArgs e)
        {
            Font bold = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Bold);
            Font Regular = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Bold)
            {
                GetCurrentDocument.SelectionFont = Regular;
            }
            else
            {
                GetCurrentDocument.SelectionFont = bold;
            }
        }

        private void tSItalic_Click(object sender, EventArgs e)
        {
            Font italic = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Italic);
            Font Regular = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Italic)
            {
                GetCurrentDocument.SelectionFont = Regular;
            }
            else
            {
                GetCurrentDocument.SelectionFont = italic;
            }
        }

        private void tSUnline_Click(object sender, EventArgs e)
        {
            Font UnderLine = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Underline);
            Font Regular = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Underline)
            {
                GetCurrentDocument.SelectionFont = Regular;
            }
            else
            {
                GetCurrentDocument.SelectionFont = UnderLine;
            }
        }

        private void tSStrike_Click(object sender, EventArgs e)
        {
            Font Strike = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Strikeout);
            Font Regular = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.Size, FontStyle.Regular);
            if (GetCurrentDocument.SelectionFont.Strikeout)
            {
                GetCurrentDocument.SelectionFont = Regular;
            }
            else
            {
                GetCurrentDocument.SelectionFont = Strike;
            }
        }

        private void tSUpper_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToUpper();
        }

        private void tSLower_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToLower();
        }

        private void tSIncrease_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints + 2;
            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void tSDecrease_Click(object sender, EventArgs e)
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints - 2;
            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void tSColored_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetCurrentDocument.SelectionColor = colorDialog1.Color;
            }
        }

        private void tSLime_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.BackColor = Color.Lime;
        }

        private void tSRed_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.BackColor = Color.Red;
        }

        private void tSYellow_Click(object sender, EventArgs e)
        {
            GetCurrentDocument.BackColor = Color.Yellow;
        }

        private void tSFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font newFont = new Font(tSFontType.SelectedItem.ToString(),GetCurrentDocument.SelectionFont.Size, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = newFont;
        }

        private void tSFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float newSize;
            float.TryParse(tSFontSize.SelectedItem.ToString(), out newSize);
            Font newFont = new Font(tSFontType.SelectedItem.ToString(), newSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = newFont;
        }

        private void FrmAna_Load(object sender, EventArgs e)
        {
            AddTabs();
            GetFontCollection();
            PopulateFontSize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(GetCurrentDocument.Text.Length > 0) {
                tSLabel.Text = "Toplam Karakter Sayısı = "+ GetCurrentDocument.Text.Length.ToString();
            }
        }
    }
    #endregion


}
