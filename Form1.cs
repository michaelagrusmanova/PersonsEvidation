using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace KolekceAListBoxy
{
    public partial class Form1 : Form
    {
        BindingList<Osoba> osoby = new BindingList<Osoba>();

        /*
         * Konstruktor
         */
        public Form1()
        {
            InitializeComponent();
            Text = "Evidence lidí";
            Informace.Refresh();
            Informace.DataSource = osoby;
        }

        /*
         * Metoda, která prochází zaregistrované členy směrem doleva, do labelu3 vypisuje konrétní označené členy.
         * Provedení - zmáčknutí tlačítka - button2.
         */
        private void button2_Click_1(object sender, EventArgs e)
        {
            label3.Visible = true;
            int index = Informace.SelectedIndex;
            if (index == 0)
            {
                index = osoby.Count - 1;
                label3.Text = Informace.Items[index].ToString();
                Informace.SelectedIndex = index;
            }
            else if(index < 0)
            {
                label3.Text = " ";
            } else { 
            
                index--;
                label3.Text = Informace.Items[index].ToString();
                Informace.SelectedIndex--;
            }
        }


        /*
         * Metoda, která prochází zaregistrované členy směrem doprava, do labelu3 vypisuje konrétní označené členy.
         * Provedení - zmáčknutí tlačítka - button3.
         */
        private void button3_Click_1(object sender, EventArgs e)
        {
            label3.Visible = true;
            int index = Informace.SelectedIndex;

            if (index < 0)
            {
                label3.Text = " ";
            }
            else
            {
                if (index == (osoby.Count-1))
                {
                    index = 0;
                    label3.Text = Informace.Items[index].ToString();
                    Informace.SelectedIndex = index;
                }
                else
                {
                    index++;
                    label3.Text = Informace.Items[index].ToString();
                    Informace.SelectedIndex++;
                }
            }
            
        }

        /*
         * Metoda, která vymaže konkrétního označeného člena. 
         * Provedení - zmáčknutí tlačítka - button4.
         */
        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            int index = Informace.SelectedIndex;
            Informace.ClearSelected();
            for(int i=0; i < osoby.Count; i++)
            {
                if (i == index)
                {
                    osoby.RemoveAt(index);
                }
            }
            Informace.Refresh();
            if (Informace.SelectedIndex == -1)
            {
                label3.Text = " ";
            }
            else
            {
                label3.Text = Informace.Items[Informace.SelectedIndex].ToString();
            }
        }

        /*
         * Metoda, která setřídí existující členy abecedně. 
         * Provedení - zmáčknutí tlačítka - button5.
         */
        private void button5_Click(object sender, EventArgs e)
        {
            ArrayList osobySetrizene = new ArrayList();
            for(int i = 0; i < osoby.Count; i++)
            {
                osobySetrizene.Add(osoby[i]);
            }
            osobySetrizene.Sort();
            Informace.DataSource = osobySetrizene;
            button4.Visible = false;
            button6.Visible = true;
        }

        /*
         * Metoda, která vrátí seznam členů zpět bez seřazení s možností jejich vymazání, 
         * která u seřazených členů nebyla možná. 
         * Provedení - zmáčknutí tlačítka - button6, který se zobrazí po zmáčknutí tlačítka - button5.
         */
        private void button6_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            Informace.DataSource = osoby;
            button6.Visible = false;
        }

        /*
         * Metoda, která otevře registrační formulář (Form2). 
         * Provedení - zmáčknutí tlačítka - button7.
         */
        private void button7_Click(object sender, EventArgs e)
        {
            bool osobaButton = radioButton1.Checked;
            bool zamestnanecButton = radioButton2.Checked;
            Form2 f = new Form2(osoby, osobaButton, zamestnanecButton);
            f.Text = "Registrační formulář";
            f.LocationChanged += Form2_LocationChanged;
            f.ShowDialog();
            Text = "Evidence lidí";


            
        }

        /*
         * Metoda, která počítá souřadnice okna registračního formuláře.
         * Provedení - otevřené okno s registrací uživatelů.
         */
        private void Form2_LocationChanged(object sender, EventArgs e)
        {
            if (sender is Form2)
            {
                Form2 temp = sender as Form2;
                Text = temp.Text + " - " + temp.Location.X + ":" + temp.Location.Y;
            } 
        }

        /*
         * Metoda, díky které je formulář ovládaný i klávesy - Enter a ESC.
         * Provedení - zmáčknutí klávesy Enter - otevření okna s registračním formulářem uživatelů.
         * Zmáčknutí klávesy ESC - zavření programu.
         */
        private void Informace_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiKlavesy(sender, e);
        }

        private void button7_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiKlavesy(sender, e);
        }

        private void zmacknutiKlavesy(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.button7_Click(sender, e);
            }
        }
        private void zmacknutiPouzeEscapu(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiKlavesy(sender, e);
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiKlavesy(sender, e);
        }

        private void button4_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiPouzeEscapu(sender, e);
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiPouzeEscapu(sender, e);
        }

        private void button6_KeyPress(object sender, KeyPressEventArgs e)
        {
            zmacknutiPouzeEscapu(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
