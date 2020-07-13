using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    struct CartaStruct
    {
        public int Numero;
        public int Colore;
        public int iCartaScelta;
    }

    public partial class Form1 : Form
    {

        public int[] arrayscelta = null;
        public int iTotale;
        public int iFase;
        CartaStruct[] CarteScelte = null;
        List<CartaStruct> cartaStructs = new List<CartaStruct>();
     
        int[] iNumeriSingoli = new int[6];

        [DllImport("Kernel32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean Beep(UInt32 frequency, UInt32 duration);

     
        public Form1()
        {
            InitializeComponent();

            iTotale = 0;
            txtCredito.Text = "500";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt64(txtCredito.Text) <= 0)
            {
                txtCredito.Text = "0";
            }
            else
            {
                txtCredito.Text = (Convert.ToInt64(txtCredito.Text) - 25).ToString();
            }

            Random random = new Random();
            int iCarta = random.Next(1, 13);
            int iColoreCarta = random.Next(1, 5);


            if (iFase == 1)
            {
                cartaStructs.Clear();
    
                for (int i = 0; i < 5; i++)
                {

                    CarteScelte[i].Colore = 0;
                    CarteScelte[i].Numero = 0;
                    CarteScelte[i].iCartaScelta = 0;
                }

            }

            for (int i = 0; i < 5; i++)
            {
                if (iFase == 2)
                {

                    if (arrayscelta[i] == 0)
                    {
                        Random _rd = new Random();
                        iCarta = _rd.Next(1, 13);
                        iColoreCarta = _rd.Next(1, 5);


                        CarteScelte[i].Colore = iColoreCarta;
                        CarteScelte[i].Numero = iCarta;
                        CarteScelte[i].iCartaScelta = 0;

                        if (!cartaStructs.Contains(CarteScelte[i]))
                        {
                            CartaStruct _cartaSTmp;

                            _cartaSTmp.Colore = CarteScelte[i].Colore;
                            _cartaSTmp.Numero = CarteScelte[i].Numero;
                            _cartaSTmp.iCartaScelta = CarteScelte[i].iCartaScelta;

                            cartaStructs[i] = _cartaSTmp;

                        }
                        else
                        {
                            i--;
                        }
                    }

                }
                else
                {
                    Random rd = new Random();
                    iCarta = rd.Next(1, 13);
                    iColoreCarta = rd.Next(1, 5);

                    CarteScelte[i].Colore = iColoreCarta;
                    CarteScelte[i].Numero = iCarta;
                    CarteScelte[i].iCartaScelta = 0;

                    if (!cartaStructs.Contains(CarteScelte[i]))
                    {
                        cartaStructs.Add(CarteScelte[i]);
                    }
                    else
                    {
                     
                     i--;

                    }
                }




                Thread.Sleep(100);
            }


            Thread.Sleep(500);

            DisegnaCarteScelte();

            if (iFase == 1)
            {
                iFase = 2;
                button1.Enabled = true;
            }else if (iFase == 2)
            {
                iFase = 1;
                for (int i = 0; i < 5; i++)
                {
                    arrayscelta[i] = 0;
                }

                button3.FlatStyle = FlatStyle.Popup;
                button4.FlatStyle = FlatStyle.Popup;
                button2.FlatStyle = FlatStyle.Popup;
                button5.FlatStyle = FlatStyle.Popup;
                btn1.FlatStyle = FlatStyle.Popup;

                button3.BackColor = Color.White;
                button4.BackColor = Color.White; 
                button2.BackColor = Color.White;
                button5.BackColor = Color.White;
                btn1.BackColor = Color.White;

                button1.Enabled = true;
            }

        }

        private void DisegnaCarteScelte()
        {

            string sCostruita = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                switch (cartaStructs[i].Colore)
                {
                    case 0:
                        sCostruita += " " + cartaStructs[i].Numero.ToString();
                        break;
                    case 1:
                        sCostruita += " " + cartaStructs[i].Numero.ToString();
                        break;
                    case 2:
                        sCostruita += " " + cartaStructs[i].Numero.ToString();
                        break;
                    case 3:
                        sCostruita += " " + cartaStructs[i].Numero.ToString();
                        break;
                    case 4:
                        sCostruita += " " + cartaStructs[i].Numero.ToString();
                        break;

                }
            }

             txtCarte.Text = sCostruita;


            DisegnaCerchio();


            
           
        }

        private void DisegnaCerchio()
        {

            System.Drawing.Graphics graphics = this.CreateGraphics();


            graphics.Clear(Color.Green);
            int y = 0;
            int z = 0;


            for (int i = 0; i < 5; i++)
            {

                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(50*(i+1)+y, 50 , 150 , 150 );

                // graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                System.Drawing.SolidBrush _myBrush = null;
                switch (cartaStructs[i].Colore)
                {
                    case 0:
                        _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                        graphics.FillEllipse(_myBrush, rectangle);
                        break;

                    case 1:
                        _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
                        graphics.FillEllipse(_myBrush, rectangle);
                        break;
                    case 2:
                        _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
                        graphics.FillEllipse(_myBrush, rectangle);
                        break;
                    case 3:
                        _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                        graphics.FillEllipse(_myBrush, rectangle);
                        break;
                    case 4:
                        _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                        graphics.FillEllipse(_myBrush, rectangle);
                        break;

                }

                System.Drawing.Rectangle _rectangle = new System.Drawing.Rectangle(100 + y+z, 100, 50, 50);
                _myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                graphics.FillEllipse(_myBrush, _rectangle);

                String drawString = cartaStructs[i].Numero.ToString();
                Font drawFont = new Font("Arial", 28);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                PointF drawPoint = new PointF(100.0F * (i + 1)+(y/2), 100.0F );

                Thread.Sleep(200);


                //Beep(840, 100);
                //PlaySound("C:\\Windows\\Media\\recycle.wav", IntPtr.Zero,
                //        SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC );

                graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
                y += 100;
                z += 50;
            }

            VericaVincita();
        }

        private bool IsContainer(int numero)
        {
            int z=0;
            bool bfind = false;
            while(iNumeriSingoli[z] != 0)
            {
                if(numero == iNumeriSingoli[z])
                {
                    bfind = true;
                }

                z++;

            }

            return bfind;
        }

        private void VericaVincita()
        {
            bool CartaVincente=false;
            
            int iUndici, iDodici, iTredici,CartaGenerale;
            int iPrimo, iSecondo, iTerzo, iQuattro, iQuinto;

            for (int i = 0; i < 6; i++)
            {
                iNumeriSingoli[i] = 0;
            }
            

            iUndici = iDodici = iTredici = iTotale = 0;
            iPrimo =  iSecondo =  iTerzo = iQuattro = iQuinto = 0;

            int iNumeroCarta1 = 0;
            int iNumeroCarta2 = 0;

            for (int i = 0; i < 5; i++)
            {
                switch(cartaStructs[i].Numero)
                {
                    case 1:
                        iPrimo++;
                        break;
                    case 11:
                        iUndici++;
                        break;
                    case 12:
                        iDodici++;
                        break;
                    case 13:
                        iTredici++;
                        break;
        
                 }            
            }

            int ContaCarte = 0;

            if (iUndici > 1 && iDodici >= 0 && iTredici >= 0 && iPrimo >=0)
            {
                iTotale = 10;
            }

            if (iUndici >= 0 && iDodici > 1 && iTredici >= 0 && iPrimo >= 0)
            {
                iTotale = 10;
            }

            if (iUndici >= 0 && iDodici >= 0 && iTredici > 1 && iPrimo >= 0)
            {
                iTotale = 10;
            }

            if (iUndici >= 0 && iDodici >= 0 && iTredici >= 0 && iPrimo > 1)
            {
                iTotale = 10;
            }


            int z = 0;

            iNumeriSingoli[z] = cartaStructs[z].Numero;

            for (int izy = 0; izy < 5; izy++)
            {
                if (!IsContainer(cartaStructs[izy].Numero))
                {
                    z++;
                    iNumeriSingoli[z] = cartaStructs[izy].Numero;
                }
            }


            z = 0;
            for (; iNumeriSingoli[z] != 0;)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (iNumeriSingoli[z] == cartaStructs[j].Numero)
                    {

                        CartaStruct temp;

                        temp.Colore = cartaStructs[z].Colore;
                        temp.Numero = cartaStructs[z].Numero;
                        temp.iCartaScelta = cartaStructs[z].iCartaScelta;
                        temp.iCartaScelta++;
                        cartaStructs[z] = temp;

                    }
                }
                z++;
            }

            for (int j = 0; j < 5; j++)
            {
                if(cartaStructs[j].iCartaScelta == 2)
                {
                    ContaCarte++;
                    if (ContaCarte == 2)
                    {
                        iTotale = 20;
                    }
                   
                }

                if (cartaStructs[j].iCartaScelta == 3)
                {
                    ContaCarte++;
                    if (ContaCarte == 1)
                    {
                        iTotale = 30;
                    }

                    if (ContaCarte == 2)
                    {
                        iTotale = 100;
                    }
                }

                if (cartaStructs[j].iCartaScelta == 4)
                {
                    ContaCarte++;
                    iTotale = 400;
                }

                if (cartaStructs[j].iCartaScelta == 5)
                {
                    ContaCarte++;
                    iTotale = 11000;
                }
            }

            if (iTotale > 0)
            {
                Beep(440, 1000);
                txtDoppiaCoppia.BackColor = Color.Red;
                txtPunti.Text = iTotale.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (arrayscelta[4] == 1)
            {
                arrayscelta[4] = 0;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pulsante));
                //button5.Invalidate();
                button3.FlatStyle = FlatStyle.Standard;
                button3.BackColor = Color.White;
            }
            else
            {
                arrayscelta[4] = 1;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button5.Invalidate();
                button3.FlatStyle = FlatStyle.Flat;
                button3.BackColor = Color.Red;
            }
            button1.Enabled = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iFase = 1;

            CarteScelte = new CartaStruct[5];

            arrayscelta = new int[5];


            for (int i = 0; i < 5; i++)
            {
                arrayscelta[i] = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            for (int i = 25; i >= 0; i--)
            {
                txtPunti.Text = i.ToString();
                txtCredito.Text = (Convert.ToInt64(txtCredito.Text)+1).ToString();
                txtPunti.Invalidate();
                Beep(940, 10);
                Application.DoEvents();
                 
            }

            txtCredito.Text = (Convert.ToInt64(txtCredito.Text) - 1).ToString();
            txtDoppiaCoppia.BackColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (arrayscelta[2] == 1)
            {

                arrayscelta[2] = 0;
                button4.FlatStyle = FlatStyle.Standard;
                button4.BackColor = Color.White;
            }
            else
            {
                arrayscelta[2] = 1;
                button4.FlatStyle = FlatStyle.Flat;
                button4.BackColor = Color.Red;
            }
            button1.Enabled = true;

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (arrayscelta[0] == 1)
            {
                arrayscelta[0] = 0;
                btn1.FlatStyle = FlatStyle.Standard;
                btn1.BackColor = Color.White;
                //btn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pulsante));
            }
            else
            {
                arrayscelta[0] = 1;
                btn1.FlatStyle = FlatStyle.Flat;

                btn1.BackColor = Color.Red;
                //btn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
            }


            

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (arrayscelta[1] == 1)
            {
                arrayscelta[1] = 0;
                //button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pulsante));
                //button2.Invalidate();
                button2.FlatStyle = FlatStyle.Standard;
                button2.BackColor = Color.White;

            }
            else
            {
                arrayscelta[1] = 1;
                //button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button2.Invalidate();
               
                button2.FlatStyle = FlatStyle.Flat;
                button2.BackColor = Color.Red;
            }

            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (arrayscelta[3] == 1)
            {
                arrayscelta[3] = 0;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pulsante));
                //button5.Invalidate();
                button5.FlatStyle = FlatStyle.Standard;
                button5.BackColor = Color.White;
            }
            else
            {
                arrayscelta[3] = 1;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button5.Invalidate();
                button5.FlatStyle = FlatStyle.Flat;
                button5.BackColor = Color.Red;
            }
            button1.Enabled = true;
        }
    }
}
