using System;
using Shape.MO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Shape.GUI;
namespace Shape.GUI
{
    public partial class fNote : Form
    {
        int togMove;
        int MaxValX;
        int MaxValY;
        string[] g_tag;
        int oder;
        public fNote(int x)
        {
            InitializeComponent();
            oder = x;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                txt_note.Font = font.Font;                
            }
       }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                txt_note.ForeColor = color.Color;
            }
        }

        StreamWriter sw;
        StreamReader sr;
        FileStream note;
        private void Form_note_Load(object sender, EventArgs e)
        {

            System.DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy  hh:mm:ss tt");

            timer1.Start();
            if (oder == 1)
            {
                readNote();
            }
        }

        string filename = "";

        private void FileName()
        {
            string [] item = lbl_date.Text.Split('/',':',' ');
            foreach(string a in item)
            {
                if (a == "")
                    filename = string.Concat(filename, ".At");
                else
                    filename = string.Concat(filename,".", a);
            }
        }
        private void createFile(string name)
        {
            string path;
            string filepath;
            string currentDirectory = Environment.CurrentDirectory;
            Note mNote = new Note();
            mNote.TaoNote("TEST", txt_note.Text, lbTenTag.Text);

        }


        private void txt_writeNote_TextChanged(object sender, EventArgs e)
        {
          
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void readNote()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                double size;
                float size1;
                string text;
                FontStyle style;
                ofd.Filter = "TXT | *.txt";
                MessageBox.Show(ofd.FileName);
                sr = new StreamReader(ofd.FileName);
                text = sr.ReadToEnd();
                txt_note.Text = text;
                sr.Close();
            }
        }


        private void RemoveLetter()
        {

        }

        /*
         * when you click here panel2 will visible so you are able to write your note.
         */ 
        private void btn_add_Click(object sender, EventArgs e)
        {
            //panel2.Visible = true;
        }

        /*
         * After click on close button you are able to see your note.
         */ 
        private void btn_close_Click(object sender, EventArgs e)
        {
            //panel2.Visible = false;
            readNote();
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_date.Text =System.DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy  hh:mm:ss tt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void txt_note_TextChanged(object sender, EventArgs e)
        {
            //sr.Close();
            //sw = new StreamWriter(@"D:\Note\note.txt");
            //sw.Write(txt_note.Text);
            //sw.Close();
        }

        private void lbl_date_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            togMove = 1;
            MaxValX = e.X;
            MaxValY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MaxValX, MousePosition.Y - MaxValY);
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagNote(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

            string name = "aa";
            createFile(name);

            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnChonTag_Click(object sender, EventArgs e)
        {
            fTag f = new fTag(this);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        public void SetTenTag(string tenTag)
        {
            lbTenTag.Text = tenTag;
        }
    }
}
