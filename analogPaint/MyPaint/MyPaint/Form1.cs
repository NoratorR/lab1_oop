using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{

    public partial class Form1 : Form
    {
        private Bitmap Bmp;
        private bool startSelect,startMove = false;
        private SaveData saveInfo;
        private List<SaveData> saveList = new List<SaveData>();
    
        private List<Shape> figureList = new List<Shape>()
        {
          new DrawRectangle(),
          new DrawPencil(),
          new DrawTriangle(),
          new DrawLine(),
          new DrawCiricle()
        };
        private bool press = false;
        private Point one;
        private Point two;
        private Color Current = Color.Black;
        private Shape temp;
        private int penWidth;
        private  Point CurPointForSelect;
        private SaveData curSelectFig;
        private bool startResize = false;

        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            for (int i = 1; i <= 15; i++)
            {
                comboBox1.Items.Add(i);
            }

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            DrawPencil temp = new DrawPencil();
            temp.getAtributs(Current, penWidth);
            this.temp = temp;
            startSelect = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawCiricle temp = new DrawCiricle();
            temp.getAtributs(Current, penWidth);
            this.temp = temp;
            startSelect = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawRectangle temp = new DrawRectangle();
            temp.getAtributs(Current,penWidth);
            this.temp = temp;
            startSelect = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawTriangle temp = new DrawTriangle();
            temp.getAtributs(Current, penWidth);
            this.temp = temp;
            startSelect = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawStar temp = new DrawStar();
            this.temp = temp;
            startSelect = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            DrawLine temp = new DrawLine();
            temp.getAtributs(Current, penWidth);
            this.temp = temp;
            startSelect = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetClear(true);
        }

        private void SetClear(bool check)
        {
            pictureBox1.Image = null;
            Bmp.Dispose();
            if (check)
               saveList.Clear();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dlg = colorDialog1.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                Current = colorDialog1.Color;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            two = e.Location;
            if (startMove)
                MoveFigure();
            if ((temp != null && press))
            {
              
                if (temp is DrawPencil)
                {

                    temp.Draw(Bmp, one, two);
                    pictureBox1.Image = Bmp;
                    one = two;

                }

                pictureBox1.Refresh();
            }
          

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
    
            if (temp != null && press)
            {
                if (!(temp is DrawPencil))
                    temp.DrawE( one, two, e);
 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            penWidth = Int32.Parse(comboBox1.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string fileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;

            }

            if (fileName != "")
            {
      
                Serialize srz = new Serialize(fileName);
                srz.getSave(saveList);
                SetClear(true);
            }
           

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp = null;
            saveList.Clear();
            SetClear(true);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            string filename = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }

            if (filename != "")
            {
                Serialize srz = new Serialize(filename);
                saveList = srz.getLoad(filename);
                if (saveList != null)
                    foreach (SaveData svd in saveList)
                        RedrawCanvas(svd);
            }

        }

        private void RedrawCanvas(SaveData svd)
        {
            try
            {

                temp = CountValue(svd);
               
                temp.getAtributs(Color.FromArgb(svd.clr),svd.pWidth);
                temp.Draw(Bmp, svd.one, svd.two);
                pictureBox1.Image = Bmp;
                temp = null;
               // pictureBox1.Refresh();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            press = false;
            if (curSelectFig != null)
                startMove = false;
            if (temp != null)
            {
               
                Bmp = temp.Draw(Bmp, one, two);
                pictureBox1.Image = Bmp;
               
                SaveData svd = new SaveData( one, two, temp, penWidth, Current.ToArgb(), Current.ToArgb());
                saveList.Add(svd);
             

            }

        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startMove = false;        //Select
            startSelect = true;
            temp = null;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CurPointForSelect = e.Location;
            if (startSelect)
                SelectFigure();
            if (startMove)
                press = true;
           
           

        }


        public void SelectFigure()
        {
            Shape mShape;
            temp = null;
            var select = new Selected();
            curSelectFig =  select.ChooseSelectFig(CurPointForSelect,ref saveList);
            if (curSelectFig != null)
            {
                SetClear(false);

                mShape = CountValue(curSelectFig);
                mShape.ChangeColor(Bmp, Current, curSelectFig);
                mShape.getAtributs(Color.Blue, 4);
                mShape.Draw(Bmp, curSelectFig.one, curSelectFig.two);
              
                if (curSelectFig != null)
                    foreach (SaveData svd in saveList)
                        RedrawCanvas(svd);
               
               
            }
          
            temp = null;
         

        }

        public void MoveFigure()
        {
            Shape mShape;
            var mov = new Move();
            mov.DelateFromList(saveList, curSelectFig);
        
            curSelectFig =  mov.MoveToNextPosition(two, curSelectFig);

            mShape = CountValue(curSelectFig);

            mShape.getAtributs(Color.FromArgb(curSelectFig.clr),curSelectFig.pWidth);
           Bmp = mShape.ChangeColor(Bmp,Current,curSelectFig);
            Bmp = mShape.Draw(Bmp,curSelectFig.one,curSelectFig.two);
           
            saveList.Add(curSelectFig);
            SetClear(false);
            foreach (SaveData svd in saveList)
                RedrawCanvas(svd);
            temp = null;
            pictureBox1.Image = Bmp;
              
        }

        public void ResizeFigure()
        {
            Shape  shp;
            SaveData temp;
            int i =0;
            if (curSelectFig != null)
            {
               
                shp = CountValue(curSelectFig);
                shp.getAtributs(Color.FromArgb(curSelectFig.clr),curSelectFig.pWidth);
                Bmp =  shp.ChangeColor(Bmp,Current,curSelectFig);
                Bmp = shp.Draw(Bmp,curSelectFig.one,curSelectFig.two);
                pictureBox1.Image = Bmp;
                SaveData fig = new SaveData(curSelectFig.one, curSelectFig.two, shp, curSelectFig.clr, curSelectFig.pWidth, Current.ToArgb());  
                foreach (SaveData svd in saveList)
                    if(svd == curSelectFig)
                    {

                        saveList[i] = fig;
                        break;
                       i++;
                    }
                temp = fig;

            }
            startResize = false;
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (temp != null)
            {
                press = true;
                one = e.Location;

            }

        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curSelectFig != null)
                startMove = true;       
            startSelect = false ;

            temp = null;
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startMove = false;
            startSelect = false;
            if (curSelectFig != null)
                ResizeFigure();
                
        }

        public Shape CountValue(SaveData svd)
        {

            foreach (Shape shp in figureList)
                if (shp.ToString() == svd.temp)
                    return shp;
            return null;
        }
    }
}
