using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolekceAListBoxy
{
    public partial class Form2 : Form
    {
        BindingList<Osoba> registraceUzivatelu;
        bool osobaB;
        bool zamestnanecB;

        /*
         * Konstruktor - jako parametr se předává seznam osob - z Form1
         */
        public Form2(BindingList<Osoba> osoby, bool osobaButton, bool zamestnanecButton)
        {
            InitializeComponent();
            registraceUzivatelu = osoby;
            osobaB = osobaButton;
            zamestnanecB = zamestnanecButton;
            skrytiPlatu();
        }

        /*
         * Zde by měla probíhat kontrola řetězce.
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*char delimiter = ' ';
            string[] retezec = textBox1.Text.Split(delimiter);*/
            if (textBox1.Text == "")
            {
                label1.Visible = true;
            } else
            {
                label1.Visible = false;
            }
        }

        /*
         * Zavolání metody vytvorUzivatele().
         * Provedení - kliknutí na Button1.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            vytvorUzivatele();
        }

        /*
         * Vytvoří uživatele v případě, že je správně vyplněný formulář.
         * Jinak vypíše chyby.
         */
        private void vytvorUzivatele()
        {

            label2.Visible = false;
            if (osobaB == true && (radioButton3.Checked == true || radioButton4.Checked == true))
            {
                Chyba.Visible = false;
                string jmeno = textBox1.Text;
                string[] retezec = textBox1.Text.Split(' ');
                if (retezec.Length > 1)
                {
                    label1.Visible = false;
                    string pohlavi;
                    Boolean kontrolaPohlavi = radioButton3.Checked;
                    if (kontrolaPohlavi == false)
                    {
                        pohlavi = "Žena";
                    }
                    else
                    {
                        pohlavi = "Muž";
                    }
                    Osoba o1 = new Osoba(jmeno, pohlavi);
                    registraceUzivatelu.Add(o1);
                    label2.Visible = true;
                    //Informace.Items.Add(o1.ToString());
                }
                else
                {
                    label1.Visible = true;
                }
            }
            else if (zamestnanecB == true && (radioButton3.Checked == true || radioButton4.Checked == true))
            {
                Chyba.Visible = false;
                string jmeno = textBox1.Text;
                int plat = (int)numericUpDown1.Value;
                string[] retezec = textBox1.Text.Split(' ');
                if (retezec.Length > 1)
                {
                    string pohlavi;
                    Boolean kontrolaPohlavi = radioButton3.Checked;
                    if (kontrolaPohlavi == false)
                    {
                        pohlavi = "Žena";
                    }
                    else
                    {
                        pohlavi = "Muž";
                    }
                    Zamestnanec z1 = new Zamestnanec(jmeno, pohlavi, plat);
                    registraceUzivatelu.Add(z1);
                    label2.Visible = true;
                    // Informace.Items.Add(z1.ToString());
                }
                else
                {
                    label1.Visible = true;
                }
            }
            else
            {
                Chyba.Visible = true;
            }
        }
        /*
         * Skrytí kontrolek pro vyplnění platu, pokud se jedná o Osobu nebo jejich odkrytí v případě Zaměstnance.
         * Provedení - skrytí - zaškrtnutí radioButton1 (Osoba), odkrytí - odškrtnutí radioButtonu1 (Zaměstnanec).
         */
        /* private void radioButton1_CheckedChanged(object sender, EventArgs e)
         {
             numericUpDown1.Visible = false;
             label5.Visible = false;
             Chyba.Visible = false;
             if (!osobaB)
             {
                 numericUpDown1.Visible = true;
                 label5.Visible = true;
             }
         }*/

        /*
         * Zakrytí chyby, pokud uživatel zmáčkne Button1 (odeslání požadavku na vytvoření uživatele), ale zapomene
         * zaškrtnout jeden z radiobuttonů - Osoba, Zaměstnanec. Pokud některý z nich zaškrtne - chyba zmizí.
         */
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Chyba.Visible = false;
        }


        /*
         * Objevení MessageBoxu s otázkou, jestli má formulář opravdu zavřít.
         * Provedení - kliknutí na button2 (Cancel), v některých případech i kliknutím na ESC.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Opravdu zavřít?";
            string caption = "Cancel";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        /*
         * Podmínkou pro uzavření formuláře je to, že musí být hodnota platu, která je větší nebo rovna 500.
         */
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zamestnanecB == true && numericUpDown1.Value < 500)
            {
                System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
                messageBoxCS.AppendFormat("Plat musí být větší nebo 500!");
                messageBoxCS.AppendLine();
                MessageBox.Show(messageBoxCS.ToString(), "ERROR!!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

        }

        /*
         * Práce s klávesy.
         * ESC - pokusí se zavřít registrační formulář.
         * ENTER - pokusí se vytvořit nového uživatele.
         */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void praceSKlavesy(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void radioButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void radioButton3_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void radioButton4_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            praceSKlavesy(sender, e);
        }

        private void skrytiPlatu()
        {
            numericUpDown1.Visible = false;
            label5.Visible = false;
            Chyba.Visible = false;
            if (!osobaB)
            {
                numericUpDown1.Visible = true;
                label5.Visible = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Chyba.Visible = false;
        }

        private void Chyba_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Chyba.Visible = false;
        }
    }
}
