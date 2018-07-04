using System;


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

using Newtonsoft.Json;

namespace WindowsFormsApp2
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private JToken CurrentDocument { get; set; }
        private Class CurrentClass { get; set; }
        private string CurrentFile { get; set; }

        private void ProcessSyllabus(string fileName)
        {
            string text = File.ReadAllText(fileName);

            JToken syllabus = JToken.Parse(text);

            CurrentDocument = syllabus;
            Class c = new Class(syllabus);
            RenderTree(c);
        }

        private void RenderTree(Class c)
        {
            TreeNode mod;
            foreach (Module m in c.Modules)
            {
                mod = new TreeNode(m.Name);
                mod.Tag = m;
                treeView1.Nodes.Add(mod);

                TreeNode lesson;
                foreach (Lesson l in m.Lessons)
                {
                    lesson = new TreeNode(l.Name);
                    lesson.Tag = l;
                    mod.Nodes.Add(lesson);

                    TreeNode resource;
                    foreach (Resource r in l.Resources)
                    {
                        resource = new TreeNode(r.Name);
                        resource.Tag = r;
                        lesson.Nodes.Add(resource);
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentFile = openFileDialog1.FileName;
                ProcessSyllabus(CurrentFile);

                toolStripStatusLabel1.Text = CurrentFile;
                toolStripStatusLabel2.Text = "(unchanged)";
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void MarkChanged()
        {
            toolStripStatusLabel2.Text = "(unsaved changes)";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = CurrentDocument.ToString();
            File.WriteAllText(CurrentFile, json);
            toolStripStatusLabel2.Text = "(saved)";
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            SyllabusItem item = e.Node.Tag as SyllabusItem;
            if (item != null)
            {
                item.ChangeName(e.Label);
                MarkChanged();
            }
        }

        
        private void Editor_Load(object sender, EventArgs e)
        {
            License about = new License();
            if (about.ShowDialog() != DialogResult.OK)
                Application.Exit();
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License f = new License();
            f.ShowDialog();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Overview()).ShowDialog();
        }
    }

}
