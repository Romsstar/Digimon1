
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
        List<Digimon1Entry> Digimon1List = new List<Digimon1Entry>();
        IDictionary<short, short> Digimon1Dict = new Dictionary<short, short>();
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

                KCAP header = new KCAP(br);
                Digimon1Entry[] Digimon1Data = new Digimon1Entry[header.fileCount];

                for (int i = 0; i < header.fileCount; i++)
                {

                    Digimon1List.Add(new Digimon1Entry(br));

                }
                foreach (var emp in Digimon1List)
                {
                    Digimon1Dict.Add(emp.id, emp.evoListPos);
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (var emp in Digimon1List)
            {
                if (emp.level == (Level)1)
                {
                    dataGridView1.Rows.Add(emp.id, emp.digimonName.ToString(), emp.evoListPos);
                }

            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var emp in Digimon1List)
            {
                if (emp.level == (Level)2 && (int)emp.evoListPos != 999)
                {
                    dataGridView1.Rows.Add(emp.id, emp.digimonName.ToString());

                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Sort(this.dataGridView1.Columns["Name"], ListSortDirection.Ascending);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = i + 1;


                bool keyExists = Digimon1Dict.ContainsKey((short)dataGridView1.Rows[i].Cells[0].Value);

                if (keyExists)
                {
                    var key = (short)dataGridView1.Rows[i].Cells[0].Value;
                    var val = (short)dataGridView1.Rows[i].Cells[1].Value;
                    Digimon1Dict[key] = val;
                    File.WriteAllText("data.json", JsonConvert.SerializeObject(Digimon1Dict, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
             
                }
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            using (BinaryWriter bw = new BinaryWriter(File.Open("Digimon1.bin", FileMode.OpenOrCreate)))
            {


                //{

                //    emp.write(bw);

                //}

                foreach (var emp in Digimon1List)
                {
                    foreach (DataGridViewRow i in dataGridView1.Rows)
                    {
                        if (i.Cells[1].Value != null)
                        {
                            emp.evoListPos = (short)i.Cells[1].Value;

                        }
                        File.WriteAllText("data.json", JsonConvert.SerializeObject(Digimon1List, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
                    }
                }

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var emp in Digimon1List)
            {
                dataGridView1.Rows.Add(emp.id.ToString(), emp.evoListPos);
            }
        }
    }
}
//    myClass.Add(i.Cells[0].Value.ToString());
//      myClass.Add(i.Cells[1].Value.ToString());

