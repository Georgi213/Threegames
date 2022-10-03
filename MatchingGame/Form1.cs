using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        Button btn, btn2, btn3;
        CheckBox cb;
        TableLayoutPanel tlp;
        public Form1()
        {

            this.Size = new Size(790, 440);
            this.Name = "Pildi vaatamine";
            tlp = new TableLayoutPanel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoSize = true,
                Location = new System.Drawing.Point(0, 0),
                ColumnCount = 2,
                RowCount = 2,
                TabIndex = 0,
                BackColor = System.Drawing.Color.White
            };

            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 10F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 90F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 85F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Absolute, 15F));
            pb = new PictureBox()
            {
                Size = new Size(382, 300),
                Dock = System.Windows.Forms.DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                TabIndex = 0,
                TabStop = false,
                AutoSize = true
                // Location = new Point(100, 100),


            };

            btn = new Button()
            {
                Text = "Avatud",

            };
            btn2 = new Button()
            {
                Text = "Sulge",

            };
            btn3 = new Button()
            {
                Text = "Kustuta",

            };
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            btn.Click += Btn_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            pb.DoubleClick += Pb_DoubleClick;
            Button[] buttons = { btn, btn2, btn3 };

            tlp.Controls.Add(pb, 0, 0);
            tlp.SetCellPosition(pb, new TableLayoutPanelCellPosition(0, 0));
            tlp.SetColumnSpan(pb, 2);
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            flowLayoutPanel.Controls.AddRange(buttons);
            tlp.Controls.Add(flowLayoutPanel, 1, 1);


            this.Controls.Add(tlp);
        }
        private void Pb_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = pb.ForeColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                pb.BackColor = MyDialog.Color;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            pb.Image = null;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            pb.Image = Image.FromFile(filePath);
        }





    }
}
