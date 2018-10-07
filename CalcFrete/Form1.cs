using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcFrete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas letras", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente números e virgula", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void CalcularFrete()
        {
            string nome = textNome.Text;
            double valor = double.Parse(textValor.Text);
            string estado = comboBox.SelectedItem.ToString();
            double frete = 0;
            double total = 0;

            if (valor > 1000)
            {
                frete = 0;
            }
            else
            {
                switch (estado)
                {
                    case "RJ": frete = 15.00; break;
                    case "SP": frete = 10.00; break;
                    case "MG": frete = 17.00; break;
                    case "ES": frete = 20.00; break;
                }
            }

            total = frete + valor;

            lblValorCompra.Visible = true;
            lblFrete.Visible = true;
            lblTotal.Visible = true;
            lblValorCompra.Text = valor.ToString("C");
            lblFrete.Text = frete.ToString("C");
            lblTotal.Text = total.ToString("C");
        }

        public void LimparCampos()
        {
            textNome.Text = string.Empty;
            textValor.Text = string.Empty;
            comboBox.SelectedValue = string.Empty;
            lblValorCompra.Text = string.Empty;
            lblFrete.Text = string.Empty;
            lblTotal.Text = string.Empty;
        }

        private void CalcularOK(object sender, EventArgs e)
        {
            CalcularFrete();
        }

        private void LimparOk(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
