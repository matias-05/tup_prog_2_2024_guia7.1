using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        DepartamentoVehicular nuevo = new DepartamentoVehicular();

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string patente = tbPatente.Text;
                int dni = Convert.ToInt32(tbDni.Text);
                string nombre = tbNombre.Text;
                Persona p = new Persona(dni, nombre);
                RegistroVehiculo rv = nuevo.RegistrarVehiculo(p, patente);
            }
            catch (RangoDniIncorrectoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatoPatenteNoValidaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            FormVer fVer = new FormVer();

            nuevo.OrdenarRegistros();

            for (int n = 0; n < nuevo.CantidadRegistros; n++)
            {
                fVer.textBox1.Text += nuevo.VerRegistro(n).ToString() + "\r\n";
            }

            fVer.ShowDialog();
        }
    }
}
