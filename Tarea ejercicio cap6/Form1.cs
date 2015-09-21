using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_ejercicio_cap6
{
    public partial class Tarea6 : Form
    {
        double[][] calificaciones;
        int aulas = 0, estudiantes = 0;
        int n = 0,x=0,y=0;
        double resultado = 0;
        int contador = 0;
        public Tarea6()
        {
            InitializeComponent();
        }

        public double NotaMenor(double[][] calificaciones) {
            double menor = 999;
            for(int j = 0; j < aulas; j++) {
                for (int k = 0; k < calificaciones[j].GetLength(0);k++) {
                    if (calificaciones[j][k]< menor)
                    {
                        menor = calificaciones[j][k];
                    }

                }
            }

           
            return menor;
        }

        public double NotaMayor(double[][] calificaciones)
        {
            double mayor = -999;
            for (int j = 0; j < aulas; j++)
            {
                for (int k = 0; k < calificaciones[j].GetLength(0); k++)
                {
                    if (calificaciones[j][k] > mayor)
                    {
                        mayor = calificaciones[j][k];
                    }
                }
            }

            return mayor;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
             
            estudiantes = int.Parse(txtEstudiantes.Text);
            if (n <aulas)
            {
                calificaciones[n] = new double[estudiantes];
                n++;
                contador += estudiantes;
            }
            labelTexto.Text = "aula no#: " + n;
        }

        private void tpPromedio_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click_1(object sender, EventArgs e)
        {

            if (x <=aulas-1)
            {
                labelTexto2.Text = "estudiante no#" + y + "Del aula no#" + x;
                if (y < calificaciones[x].GetLength(0))
                {
                    calificaciones[x][y] = double.Parse(txtNotas.Text);
                    y++;
                    resultado += double.Parse(txtNotas.Text);
                    txtNotas.Clear();
                    txtNotas.Focus();
                }
                else
                {
                    x++;
                    if (x<2) {
                        
                        y = 0;
                        calificaciones[x][y] = double.Parse(txtNotas.Text);
                        y++;
                        resultado += double.Parse(txtNotas.Text);
                        txtNotas.Clear();
                        txtNotas.Focus();

                    }

                }
                
            }
            else
            {
                resultado /= contador;
                labelPromedio.Text = resultado.ToString();
                resultado = NotaMenor(calificaciones);
                labelMenor.Text = resultado.ToString();
                resultado = NotaMayor(calificaciones);
                labelMayor.Text = resultado.ToString();
                btnProcesar.Enabled=false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            aulas = int.Parse(txtAulas.Text);
            calificaciones = new double[aulas][];
        }
        
    }
}
