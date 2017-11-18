using AnaliseMorfologicaLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnaliseMorfologica {
	public partial class FormMain : Form {
		private Imagem entrada;

		public FormMain() {
			InitializeComponent();
		}

		private void img_Click(object sender, EventArgs e) {
			PictureBox pic = (sender as PictureBox);
			if (pic.SizeMode == PictureBoxSizeMode.Zoom) {
				pic.SizeMode = PictureBoxSizeMode.CenterImage;
			} else {
				pic.SizeMode = PictureBoxSizeMode.Zoom;
			}
		}

		private void btnAbrir_Click(object sender, EventArgs e) {
			if (openFileDialog.ShowDialog(this) != DialogResult.OK) {
				return;
			}

			try {
				entrada = new Imagem(openFileDialog.FileName);

				imgEntrada.Image = entrada.CriarBitmap();
			} catch (Exception ex) {
				MessageBox.Show("Erro: " + ex.Message, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e) {
			if (imgSaida.Image == null) {
				MessageBox.Show("Nada para salvar na saída!", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK) {
				return;
			}

			try {
				imgSaida.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
			} catch (Exception ex) {
				MessageBox.Show("Erro: " + ex.Message, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnProcessar_Click(object sender, EventArgs e) {
			if (entrada == null) {
                
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
            Forma[] vetor = saida.CriarMapaDeFormas(list);


            // Exibir saída
            imgSaida.Image = saida.CriarBitmap();
            
		}
	}
}
