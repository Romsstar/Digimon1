
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Digimon1.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Formatting = Newtonsoft.Json.Formatting;

namespace Digimon1
{
    public partial class Form1 : Form
    {
        IDictionary<short, Digimon1Entry> Digimon1Dict = new Dictionary<short, Digimon1Entry>();
        KCAP header;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Position", "Position");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open Binary File
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary File|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));

                header = new KCAP(br);
                Digimon1Entry[] Digimon1Data = new Digimon1Entry[header.fileCount];

                for (int i = 0; i < header.fileCount; i++)
                {
                    Digimon1Entry entry = new Digimon1Entry(br);
                    Digimon1Dict.Add(entry.id, entry);
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)1)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)2)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(this.dataGridView1.Columns["Name"], ListSortDirection.Ascending);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = i + 1;
                short key = (short)dataGridView1.Rows[i].Cells[0].Value;
                var val = (int)dataGridView1.Rows[i].Cells[2].Value;
                Digimon1Dict[key].evoListPos = (short)val;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open("Digimon1.bin", FileMode.OpenOrCreate)))
            {

                header.write(bw);

                foreach (var pair in Digimon1Dict)
                {
                    pair.Value.write(bw);

                }
            }
        }

       

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)3)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)4)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)5)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (var emp in Digimon1Dict)
            {
                if (emp.Value.level == (Level)6)
                {
                    dataGridView1.Rows.Add(emp.Key, emp.Value.digimonName.ToString(), emp.Value.evoListPos);
                }
            }
        }
    }
}


