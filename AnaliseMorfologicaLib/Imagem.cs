using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AnaliseMorfologicaLib {
	public class Imagem {
		private class ElementoPilha {
			public readonly int X, Y, I;
			public ElementoPilha(int x, int y, int i) {
				X = x;
				Y = y;
				I = i;
			}
		}

		public readonly int Largura, Altura;

		public int[] RGB, Grayscale;

		public Imagem(int largura, int altura, bool colorida) {
			Largura = largura;
			Altura = altura;
			if (colorida) {
				RGB = new int[largura * altura];
				Grayscale = null;
			} else {
				RGB = null;
				Grayscale = new int[largura * altura];
			}
		}

		public Imagem(string caminho) {
			using (Bitmap bitmap = (Bitmap)Bitmap.FromFile(caminho)) {
				Largura = bitmap.Width;
				Altura = bitmap.Height;
				RGB = new int[Largura * Altura];
				Grayscale = null;
				System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new Rectangle(0, 0, Largura, Altura), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
				System.Runtime.InteropServices.Marshal.Copy(data.Scan0, RGB, 0, RGB.Length);
				bitmap.UnlockBits(data);
			}
		}

		public Imagem(string caminho, int tamanhoMaximo) {
			using (Bitmap bitmap = (Bitmap)Bitmap.FromFile(caminho)) {
				if (bitmap.Width > tamanhoMaximo || bitmap.Height > tamanhoMaximo) {
					int l, a;
					if (bitmap.Width > bitmap.Height) {
						l = tamanhoMaximo;
						a = (bitmap.Height * tamanhoMaximo) / bitmap.Width;
					} else {
						a = tamanhoMaximo;
						l = (bitmap.Width * tamanhoMaximo) / bitmap.Height;
					}
					Largura = l;
					Altura = a;
					RGB = new int[l * a];
					Grayscale = null;
					using (Bitmap redim = new Bitmap(l, a, System.Drawing.Imaging.PixelFormat.Format32bppRgb)) {
						using (Graphics g = Graphics.FromImage(redim)) {
							g.DrawImage(bitmap, 0, 0, l, a);
							System.Drawing.Imaging.BitmapData data = redim.LockBits(new Rectangle(0, 0, Largura, Altura), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
							System.Runtime.InteropServices.Marshal.Copy(data.Scan0, RGB, 0, RGB.Length);
							redim.UnlockBits(data);
						}
					}
				} else {
					Largura = bitmap.Width;
					Altura = bitmap.Height;
					RGB = new int[Largura * Altura];
					Grayscale = null;
					System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new Rectangle(0, 0, Largura, Altura), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
					System.Runtime.InteropServices.Marshal.Copy(data.Scan0, RGB, 0, RGB.Length);
					bitmap.UnlockBits(data);
				}
			}
		}

		public Bitmap CriarBitmap() {
			Bitmap bitmap = new Bitmap(Largura, Altura, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new Rectangle(0, 0, Largura, Altura), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			if (RGB != null) {
				System.Runtime.InteropServices.Marshal.Copy(RGB, 0, data.Scan0, RGB.Length);
			} else {
				int[] temp = new int[Grayscale.Length];
				for (int i = Grayscale.Length - 1; i >= 0; i--) {
					int color = Grayscale[i] & 0xFF;
					temp[i] = (color << 16) | (color << 8) | color;
				}
				System.Runtime.InteropServices.Marshal.Copy(temp, 0, data.Scan0, temp.Length);
			}
			bitmap.UnlockBits(data);
			return bitmap;
		}

		public Imagem Clonar() {
			Imagem nova = new Imagem(Largura, Altura, RGB != null);
			if (RGB != null) {
				Array.Copy(RGB, nova.RGB, RGB.Length);
			} else {
				Array.Copy(Grayscale, nova.Grayscale, Grayscale.Length);
			}
			return nova;
		}

		public void ConverterParaEscalaDeCinza() {
			if (RGB == null) {
				return;
			}

			for (int i = RGB.Length - 1; i >= 0; i--) {
				int color = RGB[i];
				int r = (color >> 16) & 0xFF;
				int g = (color >> 8) & 0xFF;
				int b = (color) & 0xFF;
				int gray = (int)((0.2126 * r) + (0.7152 * g) + (0.0722 * b));
				RGB[i] = ((gray >= 255) ? 255 : gray);
			}

			Grayscale = RGB;
			RGB = null;
		}

		public void ConverterParaEscalaDeCinzaMedia() {
			if (RGB == null) {
				return;
			}

			for (int i = RGB.Length - 1; i >= 0; i--) {
				int color = RGB[i];
				int r = (color >> 16) & 0xFF;
				int g = (color >> 8) & 0xFF;
				int b = (color) & 0xFF;
				RGB[i] = (r + g + b) / 3;
			}

			Grayscale = RGB;
			RGB = null;
		}

		public void Inverter() {
			if (RGB != null) {
				for (int i = RGB.Length - 1; i >= 0; i--) {
					int color = RGB[i];
					int r = 255 - ((color >> 16) & 0xFF);
					int g = 255 - ((color >> 8) & 0xFF);
					int b = 255 - ((color) & 0xFF);
					RGB[i] = (r << 16) | (g << 8) | b;
				}
			} else {
				for (int i = Grayscale.Length - 1; i >= 0; i--) {
					Grayscale[i] = 255 - Grayscale[i];
				}
			}
		}

		public void AjustarBrilhoContraste(float brilho, float contrastePerc) {
			if (RGB != null) {
				for (int i = RGB.Length - 1; i >= 0; i--) {
					int color = RGB[i];
					int r = (int)(((((color >> 16) & 0xFF) - 127) * contrastePerc) + 127.0f + brilho);
					int g = (int)(((((color >> 8) & 0xFF) - 127) * contrastePerc) + 127.0f + brilho);
					int b = (int)(((((color) & 0xFF) - 127) * contrastePerc) + 127.0f + brilho);
					if (r < 0) r = 0; else if (r > 255) r = 255;
					if (g < 0) g = 0; else if (g > 255) g = 255;
					if (b < 0) b = 0; else if (b > 255) b = 255;
					RGB[i] = (r << 16) | (g << 8) | b;
				}
			} else {
				for (int i = Grayscale.Length - 1; i >= 0; i--) {
					int gray = (int)(((Grayscale[i] - 127) * contrastePerc) + 127.0f + brilho);
					if (gray < 0) gray = 0; else if (gray > 255) gray = 255;
					Grayscale[i] = gray;
				}
			}
		}

		public void Limitar(int limiteMaximo) {
			if (Grayscale == null) {
				throw new Exception("A imagem deve estar em escala de cinza");
			}

			for (int i = Grayscale.Length - 1; i >= 0; i--) {
				Grayscale[i] = ((Grayscale[i] > limiteMaximo) ? 255 : 0);
			}
		}

		public void LimitarInvertido(int limiteMaximo) {
			if (Grayscale == null) {
				throw new Exception("A imagem deve estar em escala de cinza");
			}

			for (int i = Grayscale.Length - 1; i >= 0; i--) {
				Grayscale[i] = ((Grayscale[i] > limiteMaximo) ? 0 : 255);
			}
		}

		public int CalcularMedia() {
			if (Grayscale == null) {
				throw new Exception("A imagem deve estar em escala de cinza");
			}

			int m = 0;
			for (int i = Grayscale.Length - 1; i >= 0; i--) {
				m += Grayscale[i];
			}
			return m / Grayscale.Length;
		}

		public void Erodir(int tamanho) {
			if (Grayscale == null) {
				throw new Exception("A imagem deve estar em escala de cinza");
			}

			if ((tamanho & 1) == 0) {
				throw new Exception("O tamanho deve ser um valor ímpar");
			}

			if (tamanho < 3) {
				throw new Exception("O tamanho deve ser >= 3");
			}

			int metade = tamanho >> 1;

			int[] temp = new int[Grayscale.Length];

			// primeira passada (vertical)
			for (int y = 0; y < Altura; y++) {
				for (int x = 0; x < Largura; x++) {
					int valor = 255;

					int yInicial = y - metade;
					int tamanhoValido = tamanho;
					if (yInicial < 0) {
						tamanhoValido = tamanhoValido + yInicial;
						yInicial = 0;
					}
					if ((y + metade) > (Altura - 1)) {
						tamanhoValido = tamanhoValido - ((y + metade) - (Altura - 1));
					}

					int indice = (yInicial * Largura) + x;
					for (int i = 0; i < tamanhoValido; i++, indice += Largura) {
						if (valor > Grayscale[indice]) {
							valor = Grayscale[indice];
						}
					}

					temp[(y * Largura) + x] = valor;
				}
			}

			// segunda passada (horizontal)
			for (int y = 0; y < Altura; y++) {
				for (int x = 0; x < Largura; x++) {
					int valor = 255;

					int xInicial = x - metade;
					int tamanhoValido = tamanho;
					if (xInicial < 0) {
						tamanhoValido = tamanhoValido + xInicial;
						xInicial = 0;
					}
					if ((x + metade) > (Largura - 1)) {
						tamanhoValido = tamanhoValido - ((x + metade) - (Largura - 1));
					}

					int indice = (y * Largura) + xInicial;
					for (int i = 0; i < tamanhoValido; i++, indice++) {
						if (valor > temp[indice]) {
							valor = temp[indice];
						}
					}

					Grayscale[(y * Largura) + x] = valor;
				}
			}
		}

		private void ConsumirForma(Forma forma, Forma[] mapa, Stack<ElementoPilha> pilha) {
			while (pilha.Count != 0) {
				int x, y, i, oldI;
				ElementoPilha e = pilha.Pop();

				x = e.X;
				y = e.Y;

				// Verifica acima
				i = e.I - Largura;
				if (y > 0 && Grayscale[i] == 255) {
					forma.AdicionarPixel(x, y - 1);
					mapa[i] = forma;
					Grayscale[i] = 254;
					pilha.Push(new ElementoPilha(x, y - 1, i));
				}

				// Verifica abaixo
				i = e.I + Largura;
				if (y < (Altura - 1) && Grayscale[i] == 255) {
					forma.AdicionarPixel(x, y + 1);
					mapa[i] = forma;
					Grayscale[i] = 254;
					pilha.Push(new ElementoPilha(x, y + 1, i));
				}

				// Vai tudo até a esquerda, verificando acima e abaixo
				x--;
				i = e.I - 1;
				while (x > 0 && Grayscale[i] == 255) {
					forma.AdicionarPixel(x, y);
					mapa[i] = forma;
					Grayscale[i] = 254;

					oldI = i;

					// Verifica acima
					i = oldI - Largura;
					if (y > 0 && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y - 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y - 1, i));
					}

					// Verifica abaixo
					i = oldI + Largura;
					if (y < (Altura - 1) && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y + 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y + 1, i));
					}

					i = oldI - 1;
					x--;
				}

				// Última verificação (porque utilizamos os 8 vizinhos): as diagonais
				if (x >= 0) {
					oldI = i;

					// Verifica acima
					i = oldI - Largura;
					if (y > 0 && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y - 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y - 1, i));
					}

					// Verifica abaixo
					i = oldI + Largura;
					if (y < (Altura - 1) && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y + 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y + 1, i));
					}
				}

				// Agora, vai tudo até a direita, verificando acima e abaixo
				x = e.X + 1;
				i = e.I + 1;
				while (x < Largura && Grayscale[i] == 255) {
					forma.AdicionarPixel(x, y);
					mapa[i] = forma;
					Grayscale[i] = 254;

					oldI = i;

					// Verifica acima
					i = oldI - Largura;
					if (y > 0 && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y - 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y - 1, i));
					}

					// Verifica abaixo
					i = oldI + Largura;
					if (y < (Altura - 1) && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y + 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y + 1, i));
					}

					i = oldI + 1;
					x++;
				}

				// Última verificação (porque utilizamos os 8 vizinhos): as diagonais
				if (x < Largura) {
					oldI = i;

					// Verifica acima
					i = oldI - Largura;
					if (y > 0 && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y - 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y - 1, i));
					}

					// Verifica abaixo
					i = oldI + Largura;
					if (y < (Altura - 1) && Grayscale[i] == 255) {
						forma.AdicionarPixel(x, y + 1);
						mapa[i] = forma;
						Grayscale[i] = 254;
						pilha.Push(new ElementoPilha(x, y + 1, i));
					}
				}
			}
		}

		public Forma[] CriarMapaDeFormas(List<Forma> formasIndividuais) {
			if (Grayscale == null) {
				throw new Exception("A imagem deve estar em escala de cinza");
			}

			Forma[] mapa = new Forma[Grayscale.Length];
			Stack<ElementoPilha> pilha = new Stack<ElementoPilha>(2048);

			int i = 0;
			for (int y = 0; y < Altura; y++) {
				for (int x = 0; x < Largura; x++, i++) {
					if (Grayscale[i] == 255) {
						Forma f = new Forma(x, y);
						pilha.Push(new ElementoPilha(x, y, i));
						Grayscale[i] = 254;
						mapa[i] = f;
						ConsumirForma(f, mapa, pilha);
						f.AtualizarCentro();
						formasIndividuais.Add(f);
					}
				}
			}

			return mapa;
		}
	}
}
