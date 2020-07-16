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
        List<CartaStruct> cartaStructsTmp = new List<CartaStruct>();

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

            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            btn1.Enabled = true;

            button6.Enabled = true;

           
            if (Convert.ToInt64(txtCredito.Text) <= 0)
            {
                txtCredito.Text = "0";
            }
            else
            { 
                if (iFase == 1)
                {
                    txtCredito.Text = (Convert.ToInt64(txtCredito.Text) - 25).ToString();
                   

                }
            }

            Random random = new Random();
            int iCarta = random.Next(1, 13);
            int iColoreCarta = random.Next(1, 5);


            if (iFase == 1)
            {
                textBox1.Text = "Avvio";

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

                            CartaStruct _cartaSTmp;
                            _cartaSTmp.Colore = CarteScelte[i].Colore;
                            _cartaSTmp.Numero = CarteScelte[i].Numero;
                            _cartaSTmp.iCartaScelta = CarteScelte[i].iCartaScelta;
                            cartaStructs[i] = _cartaSTmp;

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

            DisegnaCarteScelte();

            if (iFase == 1)
            {

                iFase = 2;
                textBox1.Text = "Cambio Carte.";

            }
            else if (iFase == 2)
            {

                button1.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
                btn1.Enabled = false;

                iFase = 1;
                textBox1.Text = "Avvio.";
                textBox1.Refresh();


                for (int i = 0; i < 5; i++)
                {
                    arrayscelta[i] = 0;
                }


                button3.BackColor = Color.White;
                button4.BackColor = Color.White; 
                button2.BackColor = Color.White;
                button5.BackColor = Color.White;
                btn1.BackColor = Color.White;

                button1.Enabled = true;

                if(iTotale > 0)
                {
                    button1.Enabled = false;
                    button6.Enabled = false;
                    txtPunti.Text = iTotale.ToString();
                    txtPunti.Invalidate();
                    txtPunti.Refresh();
                    Thread.Sleep(2000);
                    ritira_vincita();
                    button1.Enabled = true;
                }

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

            cartaStructsTmp.Clear();


            for (; iNumeriSingoli[z] != 0;)
            {
                CartaStruct temp;
                temp.Colore = 0;
                temp.Numero = 0;
                temp.iCartaScelta = 0;

                for (int j = 0; j < 5; j++)
                {

                    if (iNumeriSingoli[z] == cartaStructs[j].Numero)
                    {
                        temp.iCartaScelta++;
                        
                    }
                }
                if (temp.iCartaScelta > 0)
                {
                    cartaStructsTmp.Add(temp);
                }

                z++;
            }

            for (int j = 0; j < cartaStructsTmp.Count ; j++)
            {
                if(cartaStructsTmp[j].iCartaScelta == 2)
                {
                    ContaCarte++;

                    if (ContaCarte == 2)
                    {
                        iTotale = 20;
                    }
                }

                if (cartaStructsTmp[j].iCartaScelta == 3)
                {
                    iTotale = 30;
                 
                    if (ContaCarte == 1)
                    {
                        iTotale = 100;
                    }
                }

                if (cartaStructsTmp[j].iCartaScelta == 4)
                {
                    iTotale = 400;
                }

                if (cartaStructsTmp[j].iCartaScelta == 5)
                {
                    iTotale = 11000;
                }
            }

            if (iTotale > 0)
            {
                Beep(432, 700);
                txtPunti.Text = iTotale.ToString();
                txtPunti.Invalidate();

            }
            else
            {
                Beep(200, 700);
                txtPunti.Text = "0";
                txtPunti.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (arrayscelta[4] == 1)
            {
                arrayscelta[4] = 0;
                button3.FlatStyle = FlatStyle.Standard;
                button3.BackColor = Color.White;
            }
            else
            {
                arrayscelta[4] = 1;
                button3.FlatStyle = FlatStyle.Flat;
                button3.BackColor = Color.Red;
            }
            button1.Enabled = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iFase = 1;
            textBox1.Text = "Avvio";


            CarteScelte = new CartaStruct[5];
            arrayscelta = new int[5];

            for (int i = 0; i < 5; i++)
            {
                arrayscelta[i] = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                arrayscelta[i] = 0;
            }

            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button2.BackColor = Color.White;
            button5.BackColor = Color.White;
            btn1.BackColor = Color.White;

            for (int i = iTotale; i >= 0; i--)
            {
                txtPunti.Text = i.ToString();
                txtCredito.Text = (Convert.ToInt64(txtCredito.Text)+1).ToString();
                txtPunti.Invalidate();
                Thread.Sleep(50);
                Application.DoEvents();

            }

            txtCredito.Text = (Convert.ToInt64(txtCredito.Text) - 1).ToString();
            txtDoppiaCoppia.BackColor = Color.Black;

            iTotale = 0;

            iFase = 1;

            textBox1.Text = "Avvio";
        }


        private void ritira_vincita()
        {
            for (int i = iTotale; i >= 0; i--)
            {
                txtPunti.Text = i.ToString();
                txtCredito.Text = (Convert.ToInt64(txtCredito.Text) + 1).ToString();
                txtPunti.Invalidate();
                Thread.Sleep(50);
                Application.DoEvents();

            }

            txtCredito.Text = (Convert.ToInt64(txtCredito.Text) - 1).ToString();
            txtDoppiaCoppia.BackColor = Color.Black;

            textBox1.Text = "Avvio";

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
            }
            else
            {
                arrayscelta[0] = 1;
                btn1.FlatStyle = FlatStyle.Flat;
                btn1.BackColor = Color.Red;
            }

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (arrayscelta[1] == 1)
            {
                arrayscelta[1] = 0;
                button2.FlatStyle = FlatStyle.Standard;
                button2.BackColor = Color.White;

            }
            else
            {
                arrayscelta[1] = 1;
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
                button5.FlatStyle = FlatStyle.Standard;
                button5.BackColor = Color.White;
            }
            else
            {
                arrayscelta[3] = 1;
                button5.FlatStyle = FlatStyle.Flat;
                button5.BackColor = Color.Red;
            }
            button1.Enabled = true;
        }
    }
}
