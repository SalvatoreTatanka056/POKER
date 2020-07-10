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

        int[] iNumeriSingoli = new int[6];

        [DllImport("Kernel32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean Beep(UInt32 frequency, UInt32 duration);

        [DllImport("winmm.dll", SetLastError = true,
                                               CallingConvention =
        CallingConvention.Winapi)]
        static extern bool PlaySound(
                   string pszSound,
                   IntPtr hMod,
                   SoundFlags sf);

        // Flags for playing sounds.  For this example, we are reading
        // the sound from a filename, so we need only specify
        // SND_FILENAME | SND_ASYNC
        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default)
            SND_ASYNC = 0x0001,  // play asynchronously
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy
            SND_ALIAS = 0x00010000, // name is a registry alias
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name
            SND_RESOURCE = 0x00040004  // name is resource name or atom
        }

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
                        
                    }
                    CarteScelte[i].iCartaScelta = 0;

                }
                else
                {
                    Random rd = new Random();
                    iCarta = rd.Next(1, 13);
                    iColoreCarta = rd.Next(1, 5);

                    CarteScelte[i].Colore = iColoreCarta;
                    CarteScelte[i].Numero = iCarta;
                    CarteScelte[i].iCartaScelta = 0;
                }

                Thread.Sleep(200);
            }


            Thread.Sleep(1000);

            DisegnaCarteScelte(CarteScelte);

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

                button3.FlatStyle = FlatStyle.Standard;
                button4.FlatStyle = FlatStyle.Standard;
                button2.FlatStyle = FlatStyle.Standard;
                button5.FlatStyle = FlatStyle.Standard;
                btn1.FlatStyle = FlatStyle.Standard;

                button1.Enabled = true;
            }

        }

        private void DisegnaCarteScelte(CartaStruct[] carteScelte)
        {

            string sCostruita = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                switch (carteScelte[i].Colore)
                {
                    case 0:
                        sCostruita += " " + carteScelte[i].Numero.ToString();
                        break;
                    case 1:
                        sCostruita += " " + carteScelte[i].Numero.ToString();
                        break;
                    case 2:
                        sCostruita += " " + carteScelte[i].Numero.ToString();
                        break;
                    case 3:
                        sCostruita += " " + carteScelte[i].Numero.ToString();
                        break;
                    case 4:
                        sCostruita += " " + carteScelte[i].Numero.ToString();
                        break;

                }
            }

             txtCarte.Text = sCostruita;


            DisegnaCerchio(carteScelte);
           
        }

        private void DisegnaCerchio(CartaStruct[] carteScelte)
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
                switch (carteScelte[i].Colore)
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

                String drawString = carteScelte[i].Numero.ToString();
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

            VericaVincita(carteScelte);
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

        private void VericaVincita(CartaStruct[] carteScelte)
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
                switch(carteScelte[i].Numero)
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

            iNumeriSingoli[z] = carteScelte[z].Numero;

            for (int izy = 0; izy < 5; izy++)
            {
                if (!IsContainer(carteScelte[izy].Numero))
                {
                    z++;
                    iNumeriSingoli[z] = carteScelte[izy].Numero;
                }
            }


            z = 0;
            for (; iNumeriSingoli[z] != 0;)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (iNumeriSingoli[z] == carteScelte[j].Numero)
                        carteScelte[z].iCartaScelta++;
                }
                z++;
            }

            for (int j = 0; j < 5; j++)
            {
                if(carteScelte[j].iCartaScelta == 2)
                {
                    ContaCarte++;
                    if (ContaCarte == 2)
                    {
                        iTotale = 20;
                    }
                   
                }

                if (carteScelte[j].iCartaScelta == 3)
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

                if (carteScelte[j].iCartaScelta == 4)
                {
                    ContaCarte++;
                    iTotale = 400;
                }

                if (carteScelte[j].iCartaScelta == 5)
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
            }
            else
            {
                arrayscelta[4] = 1;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button5.Invalidate();
                button3.FlatStyle = FlatStyle.Flat;
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
                Thread.Sleep(10);
                Beep(940, 100);
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
            }
            else
            {
                arrayscelta[2] = 1;
                button4.FlatStyle = FlatStyle.Flat;
            }
            button1.Enabled = true;

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (arrayscelta[0] == 1)
            {
                arrayscelta[0] = 0;
                btn1.FlatStyle = FlatStyle.Standard;
                //btn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pulsante));
            }
            else
            {
                arrayscelta[0] = 1;
                btn1.FlatStyle = FlatStyle.Flat;
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

            }
            else
            {
                arrayscelta[1] = 1;
                //button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button2.Invalidate();
                button2.FlatStyle = FlatStyle.Flat;
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
            }
            else
            {
                arrayscelta[3] = 1;
                //button5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PulsanteScelta));
                //button5.Invalidate();
                button5.FlatStyle = FlatStyle.Flat;
            }
            button1.Enabled = true;
        }
    }
}
