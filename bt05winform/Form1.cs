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

namespace bt05winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                toolStripComboBox2.Items.Add(size);
            }
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = 14;
            richTextBox1.Font = new Font("Tahoma", 14);
        }
        private void NewFile()
        {
            richTextBox1.Clear();
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = 14;
            richTextBox1.Font = new Font("Tahoma", 14);
        }
        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(openFileDialog.FileName);
                }
            }
        }
        private void SaveFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName);
                }
            }
        }

        private void ToggleBold()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle newStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, newStyle);
            }
        }

        private void ToggleItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle newStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, newStyle);
            }
        }

        private void ToggleUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle newStyle = richTextBox1.SelectionFont.Style ^ FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, newStyle);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ToggleBold();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ToggleItalic();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ToggleUnderline();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null && int.TryParse(toolStripComboBox2.SelectedItem.ToString(), out int newSize))
            {
                Font currentFont = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBox1.SelectedItem != null)
    {
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();

                if (richTextBox1.SelectionFont != null)
                {
                    // Thay đổi font cho phần văn bản được chọn
                    Font currentFont = richTextBox1.SelectionFont;
                    richTextBox1.SelectionFont = new Font(selectedFont, currentFont.Size, currentFont.Style);
                }
                else
                {
                    // Thay đổi font mặc định
                    richTextBox1.Font = new Font(selectedFont, richTextBox1.Font.Size);
                }
            }
        }
    }
    }

