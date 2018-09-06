using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REDP
{
    public partial class Form1 : Form
    {
        private List<int> _col1 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col6 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col7 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col8 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        private int nNumber;
        private List<String> _type = new List<String> { "empty","aubergine","broadbeans","brocolli1","brocolli2","cabbage1","cabbage2","carrots","cauliflower1","cauliflower2","lettuce","peas","potatoes","spinach","swede","thyme","tomato","CUSTOMER","CUSTOMER","CUSTOMER","NullGate" };
        private List<String> _colours = new List<String> { "blue", "brown", "pink", "purple", "red", "yellow" };
        private List<String> _colourdescriptions = new List<String> { "colour of the sky", "potatoes", "peas", "eating", "brings introduction", "hat on" };
        private List<int> _colourindex = new List<int> { 0, 3, 5, 4, 1, 4, 1, 2, 4, 1, 5, 5, 2, 6, 6, 6, 5, 0,0,0,0 };
        private List<bool> _customer1 = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private List<bool> _customer2 = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private List<bool> _customer3 = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private int mnList,mnItem;

        private void fUpdateList()
        {
            if (lst1.Items.Count > 0)
            {
                do
                {
                    lst1.Items.RemoveAt(0);
                } while (lst1.Items.Count > 0);
            }

            switch (mnList)
            {
                case 1:
                    for (int i = 1; i <= 18; i++)
                    {
                        if (_customer1[i - 1] == true)
                        {
                            lst1.Items.Add(_type[i - 1]);
                        }
                    }
                    break;
                case 2:
                    for (int i = 1; i <= 18; i++)
                    {
                        if (_customer2[i - 1] == true)
                        {
                            lst1.Items.Add(_type[i - 1]);
                        }
                    }
                    break;
                default:
                    for (int i = 1; i <= 18; i++)
                    {
                        if (_customer3[i - 1] == true)
                        {
                            lst1.Items.Add(_type[i - 1]);
                        }
                    }
                    break;
            }
        }



        private int fType(int nCol,int nRow)
        {
            switch (nCol)
            {
                case 1:
                    return _col1[nRow - 1];
                 case 2:
                    return _col2[nRow - 1];
                case 3:
                    return _col3[nRow - 1];
                case 4:
                    return _col4[nRow - 1];
                 case 5:
                    return _col5[nRow - 1];
                case 6:
                    return _col6[nRow - 1];
                case 7:
                    return _col7[nRow - 1];
               default:
                    return _col8[nRow - 1];
             }
        }

        private bool fValid(int nCustomer,int nType)
        {
            switch (nCustomer)
            {
                case 1:
                         return _customer1[nType - 1];
                case 2:
                    return _customer2[nType - 1];
                default:
                    return _customer3[nType - 1];
            }
        }

        private void fPut(int nCol,int nRow,int nType)
        {
            switch (nCol)
            {
                case 1:
                    _col1[nRow - 1] = nType;
                    break;
                case 2:
                    _col2[nRow - 1] = nType;
                    break;
                case 3:
                    _col3[nRow - 1] = nType;
                    break;
                case 4:
                    _col4[nRow - 1] = nType;
                    break;
                case 5:
                    _col5[nRow - 1] = nType;
                    break;
                case 6:
                    _col6[nRow - 1] = nType;
                    break;
                case 7:
                    _col7[nRow - 1] = nType;
                    break;
               default:
                    _col8[nRow - 1] = nType;
                    break;
            }
            fUpdateDisplay();
        }
        private void fClick(int nCol,int nRow)
        {
            String sText;
            int nType = fType(nCol, nRow);
            String sColourDescription;

            if (mnItem == 0)
            {
                sText = "Selected = (" + Convert.ToString(nCol) + "," + Convert.ToString(nRow) + ")";
                lblSelected.Text = sText;
                sText = "Type = " + _type[nType - 1];
                lblType.Text = sText;
                if (_colourindex[nType - 1] == 0)
                {
                    sColourDescription = "0";
                }
                else
                {
                    sColourDescription = _colourdescriptions[_colourindex[nType - 1] - 1];
                }
                sText = "Description = " + sColourDescription;
                lblDescription.Text = sText;
            }
            else
            {
                if (fValid(mnItem, nType))
                {
                    fPut(nCol, nRow, 17 + mnItem);
                }
            }
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F empty.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F aubergine.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F broadbeans.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F broccoli1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F broccoli2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F cabbage1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F cabbage2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture8 = new PictureBox
            {
                Name = "pictureBox8",
                Image = Image.FromFile(@"F carrots.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture9 = new PictureBox
            {
                Name = "pictureBox9",
                Image = Image.FromFile(@"F cauliflower1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture10 = new PictureBox
            {
                Name = "pictureBox10",
                Image = Image.FromFile(@"F cauliflower2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture11 = new PictureBox
            {
                Name = "pictureBox11",
                Image = Image.FromFile(@"F lettuce.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture12 = new PictureBox
            {
                Name = "pictureBox12",
                Image = Image.FromFile(@"F peas.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture13 = new PictureBox
            {
                Name = "pictureBox13",
                Image = Image.FromFile(@"F potatoes.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture14 = new PictureBox
            {
                Name = "pictureBox14",
                Image = Image.FromFile(@"F spinach.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture15 = new PictureBox
            {
                Name = "pictureBox15",
                Image = Image.FromFile(@"F swede.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture16 = new PictureBox
            {
                Name = "pictureBox16",
                Image = Image.FromFile(@"F thyme.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture17 = new PictureBox
            {
                Name = "pictureBox17",
                Image = Image.FromFile(@"F tomato.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture18 = new PictureBox
            {
                Name = "pictureBox18",
                Image = Image.FromFile(@"F customer1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture19 = new PictureBox
            {
                Name = "pictureBox19",
                Image = Image.FromFile(@"F customer2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture20 = new PictureBox
            {
                Name = "pictureBox20",
                Image = Image.FromFile(@"F customer3.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture21 = new PictureBox
            {
                Name = "pictureBox21",
                Image = Image.FromFile(@"F NullGate.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            switch (nValue)
            {
                case 1:
                    _pic2 = picture1;
                    break;
                case 2:
                    _pic2 = picture2;
                    break;
                case 3:
                    _pic2 = picture3;
                    break;
                case 4:
                    _pic2 = picture4;
                    break;
                case 5:
                    _pic2 = picture5;
                    break;
                case 6:
                    _pic2 = picture6;
                    break;
                case 7:
                    _pic2 = picture7;
                    break;
                case 8:
                    _pic2 = picture8;
                    break;
                case 9:
                    _pic2 = picture9;
                    break;
                case 10:
                    _pic2 = picture10;
                    break;
                case 11:
                    _pic2 = picture11;
                    break;
                case 12:
                    _pic2 = picture12;
                    break;
                case 13:
                    _pic2 = picture13;
                    break;
                case 14:
                    _pic2 = picture14;
                    break;
                case 15:
                    _pic2 = picture15;
                    break;
                case 16:
                    _pic2 = picture16;
                    break;
                case 17:
                    _pic2 = picture17;
                    break;
                case 18:
                    _pic2 = picture18;
                    break;
                case 19:
                    _pic2 = picture19;
                    break;
                case 20:
                    _pic2 = picture20;
                    break;
                default:
                    _pic2 = picture21;
                    break;
            }
            for (int i = 1; i <= nRotate - 1; i++)
            {
                _pic2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }

        private void fReset()
        {
            Random rnd1 = new Random();

            mnList = 1;
            mnItem = 1;

            for (int i = 1; i <= 8; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col1[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col1[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col2[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col2[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col3[i- 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col3[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col4[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col4[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col5[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col5[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col6[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col6[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col7[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col7[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _col8[i - 1] = rnd1.Next(2, 18);
                }
                else
                {
                    _col8[i - 1] = 1;
                }
            }

            for (int i = 2; i <= 17; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _customer1[i - 1] = true;
                }
                else
                {
                    _customer1[i - 1] = false;
                }
            }

            for (int i = 2; i <= 17; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _customer2[i - 1] = true;
                }
                else
                {
                    _customer2[i - 1] = false;
                }
            }

            for (int i = 2; i <= 17; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 4)
                {
                    _customer3[i - 1] = true;
                }
                else
                {
                    _customer3[i - 1] = false;
                }
            }



            fUpdateDisplay();

        }

        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate=1;

            nType = _col1[0];
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = _col1[1];
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = _col1[2];
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = _col1[3];
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = _col1[4];
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = _col1[5];
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = _col1[6];
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = _col1[7];
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2

            nType = _col2[0];
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = _col2[1];
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = _col2[2];
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = _col2[3];
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = _col2[4];
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = _col2[5];
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = _col2[6];
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = _col2[7];
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;



            //3

            nType = _col3[0];
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = _col3[1];
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = _col3[2];
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = _col3[3];
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = _col3[4];
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = _col3[5];
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = _col3[6];
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = _col3[7];
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;


            //4

            nType = _col4[0];
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = _col4[1];
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = _col4[2];
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = _col4[3];
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = _col4[4];
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = _col4[5];
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = _col4[6];
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = _col4[7];
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;


            //5

            nType = _col5[0];
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = _col5[1];
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = _col5[2];
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = _col5[3];
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = _col5[4];
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = _col5[5];
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = _col5[6];
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = _col5[7];
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;


            //6

            nType = _col6[0];
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = _col6[1];
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = _col6[2];
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = _col6[3];
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = _col6[4];
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = _col6[5];
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = _col6[6];
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = _col6[7];
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;


            //7

            nType = _col7[0];
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = _col7[1];
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = _col7[2];
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = _col7[3];
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = _col7[4];
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = _col7[5];
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = _col7[6];
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = _col7[7];
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;


            //8

            nType = _col8[0];
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = _col8[1];
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = _col8[2];
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = _col8[3];
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = _col8[4];
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = _col8[5];
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = _col8[6];
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = _col8[7];
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;




        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            fClick(1, 1);
        }

        private void lblSelected_Click(object sender, EventArgs e)
        {

        }

        private void pic12_Click(object sender, EventArgs e)
        {
            fClick(1, 2);
        }

        private void pic13_Click(object sender, EventArgs e)
        {
            fClick(1, 3);
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            fClick(1, 4);
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            fClick(1, 5);
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            fClick(1, 6);
        }

        private void pic17_Click(object sender, EventArgs e)
        {
            fClick(1, 7);
        }

        private void pic18_Click(object sender, EventArgs e)
        {
            fClick(1, 8);
        }

        private void pic21_Click(object sender, EventArgs e)
        {
            fClick(2, 1);
        }

        private void pic22_Click(object sender, EventArgs e)
        {
            fClick(2, 2);
        }

        private void pic23_Click(object sender, EventArgs e)
        {
            fClick(2, 3);
        }

        private void pic24_Click(object sender, EventArgs e)
        {
            fClick(2, 4);
        }

        private void pic25_Click(object sender, EventArgs e)
        {
            fClick(2, 5);
        }

        private void pic26_Click(object sender, EventArgs e)
        {
            fClick(2, 6);
        }

        private void pic27_Click(object sender, EventArgs e)
        {
            fClick(2, 7);
        }

        private void pic28_Click(object sender, EventArgs e)
        {
            fClick(2, 8);
        }

        //3
        private void pic31_Click(object sender, EventArgs e)
        {
            fClick(3, 1);
        }

        private void pic32_Click(object sender, EventArgs e)
        {
            fClick(3, 2);
        }

        private void pic33_Click(object sender, EventArgs e)
        {
            fClick(3, 3);
        }

        private void pic34_Click(object sender, EventArgs e)
        {
            fClick(3, 4);
        }

        private void pic35_Click(object sender, EventArgs e)
        {
            fClick(3, 5);
        }

        private void pic36_Click(object sender, EventArgs e)
        {
            fClick(3, 6);
        }

        private void pic37_Click(object sender, EventArgs e)
        {
            fClick(3, 7);
        }

        private void pic38_Click(object sender, EventArgs e)
        {
            fClick(3, 8);
        }

        //4
        private void pic41_Click(object sender, EventArgs e)
        {
            fClick(4, 1);
        }

        private void pic42_Click(object sender, EventArgs e)
        {
            fClick(4, 2);
        }

        private void pic43_Click(object sender, EventArgs e)
        {
            fClick(4, 3);
        }

        private void pic44_Click(object sender, EventArgs e)
        {
            fClick(4, 4);
        }

        private void pic45_Click(object sender, EventArgs e)
        {
            fClick(4, 5);
        }

        private void pic46_Click(object sender, EventArgs e)
        {
            fClick(4, 6);
        }

        private void pic47_Click(object sender, EventArgs e)
        {
            fClick(4, 7);
        }

        private void pic48_Click(object sender, EventArgs e)
        {
            fClick(4, 8);
        }

        //5
        private void pic51_Click(object sender, EventArgs e)
        {
            fClick(5, 1);
        }

        private void pic52_Click(object sender, EventArgs e)
        {
            fClick(5, 2);
        }

        private void pic53_Click(object sender, EventArgs e)
        {
            fClick(5, 3);
        }

        private void pic54_Click(object sender, EventArgs e)
        {
            fClick(5, 4);
        }

        private void pic55_Click(object sender, EventArgs e)
        {
            fClick(5, 5);
        }

        private void pic56_Click(object sender, EventArgs e)
        {
            fClick(5, 6);
        }

        private void pic57_Click(object sender, EventArgs e)
        {
            fClick(5, 7);
        }

        private void pic58_Click(object sender, EventArgs e)
        {
            fClick(5, 8);
        }


        //6 
        private void pic61_Click(object sender, EventArgs e)
        {
            fClick(6, 1);
    }

    private void pic62_Click(object sender, EventArgs e)
    {
        fClick(6, 2);
    }

    private void pic63_Click(object sender, EventArgs e)
    {
        fClick(6, 3);
    }

    private void pic64_Click(object sender, EventArgs e)
    {
        fClick(6, 4);
    }

    private void pic65_Click(object sender, EventArgs e)
    {
        fClick(6, 5);
    }

    private void pic66_Click(object sender, EventArgs e)
    {
        fClick(6, 6);
    }

    private void pic67_Click(object sender, EventArgs e)
    {
        fClick(6, 7);
    }

    private void pic68_Click(object sender, EventArgs e)
    {
        fClick(6, 8);
    }


    //7
    private void pic71_Click(object sender, EventArgs e)
    {
        fClick(7, 1);
    }

    private void pic72_Click(object sender, EventArgs e)
    {
        fClick(7, 2);
    }

    private void pic73_Click(object sender, EventArgs e)
    {
        fClick(7, 3);
    }

    private void pic74_Click(object sender, EventArgs e)
    {
        fClick(7, 4);
    }

    private void pic75_Click(object sender, EventArgs e)
    {
        fClick(7, 5);
    }

    private void pic76_Click(object sender, EventArgs e)
    {
        fClick(7, 6);
    }

    private void pic77_Click(object sender, EventArgs e)
    {
        fClick(7, 7);
    }

    private void pic78_Click(object sender, EventArgs e)
    {
        fClick(7, 8);
    }


    //8
    private void pic81_Click(object sender, EventArgs e)
    {
        fClick(8, 1);
    }

    private void pic82_Click(object sender, EventArgs e)
    {
        fClick(8, 2);
    }

    private void pic83_Click(object sender, EventArgs e)
    {
        fClick(8, 3);
    }

    private void pic84_Click(object sender, EventArgs e)
    {
        fClick(8, 4);
    }

    private void pic85_Click(object sender, EventArgs e)
    {
        fClick(8, 5);
    }

    private void pic86_Click(object sender, EventArgs e)
    {
        fClick(8, 6);
    }

    private void pic87_Click(object sender, EventArgs e)
    {
        fClick(8, 7);
    }

    private void pic88_Click(object sender, EventArgs e)
    {
        fClick(8, 8);
    }

    private void btnCustomer1_Click(object sender, EventArgs e)
    {
         mnList = 1;
         fUpdateList();
    }

        private void btnCustomer2_Click(object sender, EventArgs e)
        {
            mnList = 2;
            fUpdateList();

        }

        private void picCustomer1_Click(object sender, EventArgs e)
        {
            mnItem = 1;
        }

        private void picCustomer2_Click(object sender, EventArgs e)
        {
            mnItem = 2;
        }

        private void picCustomer3_Click(object sender, EventArgs e)
        {
            mnItem = 3;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            mnItem = 0;
        }

        private void btnCustomer3_Click(object sender, EventArgs e)
        {
            mnList = 3;
            fUpdateList();

        }
    }
}
