using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Interfase;

namespace MyPaint
{

    public partial class Form1 : Form
    {
        private Bitmap Bmp;
        private bool startSelect,startMove = false;
        private SaveData saveInfo;
        private List<SaveData> saveList = new List<SaveData>();

        private List<Shape> figureList = new List<Shape>();
        private List<string> figuresName = new List<string>();
        
        private bool press = false;
        private Point one;
        private Point two;
        private Color Current = Color.Black;
        private Shape temp;
        private int penWidth;
        private  Point CurPointForSelect;
        private SaveData curSelectFig;
        private bool startResize = false;

        private List<string> dllList = new List<string>();

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
            string[] dlls;
            dlls = Directory.GetFiles(Application.StartupPath + "\\Shapes", "*.dll");
            foreach(string dll in dlls)
            {
                CheckPlugin chk = new CheckPlugin(dll);
                if (chk.CheckIfCorrect())
                    dllList.Add(dll);
                else
                    MessageBox.Show("Incorrect hash sum in" + dll, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            ConnectPlugins(dllList);

        }

       

        private void MyClickHandler(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            foreach (Shape fig in figureList)
                if (fig.ToString().Contains(btn.Text))
                    temp = fig;
    
            temp.getAtributs(Current, penWidth);
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
              
              /*  if (temp is DrawPencil)
                {

                    temp.Draw(Bmp, one, two);
                    pictureBox1.Image = Bmp;
                    one = two;

                }*/

                pictureBox1.Refresh();
            }
          

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
    
            if (temp != null && press)
            {
              //  if (!(temp is DrawPencil))
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
            foreach(SaveData save in saveList)
            {
       
                 temp = CountValue(save);
                 ISelected itemp = temp;
                 if (itemp.isSelected(CurPointForSelect,save))
                {
                    curSelectFig = save;
                    SetClear(false);
                    mShape = CountValue(curSelectFig);
                   
                    mShape.getAtributs(Color.Blue, 4);
                    mShape.Draw(Bmp, curSelectFig.one, curSelectFig.two);

                    if (curSelectFig != null)
                        foreach (SaveData svd in saveList)
                            RedrawCanvas(svd);
                    break;
                }
               
            }
          
            temp = null;
         

        }

        public void MoveFigure()
        {
             Shape mShape;
            
            temp = CountValue(curSelectFig);
            IEditable iedit = temp;
        

             curSelectFig =  iedit.MoveToNextPosition(two, curSelectFig);

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

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ConnectPlugins(List<string> path)
        {
            Shape cur;
            int i = 0;
            foreach (string lib in path)
            {
                Assembly asm = Assembly.LoadFile(lib);
                Type[] typ = asm.GetTypes();
                cur = (MyPaint.Shape)Activator.CreateInstance(typ[0]);
                figureList.Add(cur);
                Button btn = new Button();
                btn.Text = cur.GetName();
                btn.Location = new Point(10, 25 * (i + 1));
                btn.Click += new EventHandler(MyClickHandler);
                Controls.Add(btn);
                i++;
            }
        }
    }
}
