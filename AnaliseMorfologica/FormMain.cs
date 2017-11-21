using AnaliseMorfologicaLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AnaliseMorfologica;

namespace AnaliseMorfologica
{
    public partial class FormMain : Form
    {
        private Imagem entrada;

        public FormMain()
        {
            InitializeComponent();
        }

        private void img_Click(object sender, EventArgs e)
        {
            PictureBox pic = (sender as PictureBox);
            if (pic.SizeMode == PictureBoxSizeMode.Zoom)
            {
                pic.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                pic.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                entrada = new Imagem(openFileDialog.FileName);

                imgEntrada.Image = entrada.CriarBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (imgSaida.Image == null)
            {
                MessageBox.Show("Nada para salvar na saída!", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                imgSaida.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (entrada == null)
            {

                MessageBox.Show("Nada para processar na entrada!", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Imagem saida = entrada.Clonar();

            // Processar!!!
            saida.ConverterParaEscalaDeCinza();
            //saida.ConverterParaEscalaDeCinzaMedia();
            saida.LimitarInvertido(saida.CalcularMedia());
            saida.Erodir(3);
            List<Forma> list = new List<Forma>();
            saida.CriarMapaDeFormas(list);

            //Valida gabarito:
            bool formasGabarito = true;
            //verifica superior esquerdo:
            //x28, y28
            //x86, y86
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 28, 28, 86, 86) == 1);

            //verifica superior direito:
            //x635, y28
            //x693, y86
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 635, 28, 693, 86) == 1);

            //verifica centro esquerdo:
            //x28, y492
            //x86, y549
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 28, 492, 86, 549) == 1);

            //verifica centro direito:
            //x 635, y 492
            //x 693, y 549
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 635, 492, 693, 549) == 1);

            //verifica inferior esquerdo:
            //x 28, y 955
            //x 86, y 1013
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 28, 955, 86, 1013) == 1);

            //verifica inferior direito:
            //x 635, y 955
            //x 693, y 1013
            formasGabarito = formasGabarito && (ValidaGabarito.ValidarGabarito(list, 635, 955, 693, 1013) == 1);


            if (formasGabarito == false)
            {
                MessageBox.Show("Não é um gabarito!");                   
            }


            // Exibir saída
            imgSaida.Image = saida.CriarBitmap();


        }
    }
}


