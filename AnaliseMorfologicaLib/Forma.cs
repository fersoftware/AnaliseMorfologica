using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseMorfologicaLib {
	public class Forma {
		public int Area, X0, Y0, X1, Y1, CentroX, CentroY;

		public Forma(int x, int y) {
			Area = 1;
			X0 = x;
			Y0 = y;
			X1 = x;
			Y1 = y;
			CentroX = x;
			CentroY = y;
		}

		public override string ToString() {
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Area: ");
			stringBuilder.Append(Area);
			stringBuilder.Append(" / X0: ");
			stringBuilder.Append(X0);
			stringBuilder.Append(" / Y0: ");
			stringBuilder.Append(Y0);
			stringBuilder.Append(" / X1: ");
			stringBuilder.Append(X1);
			stringBuilder.Append(" / Y1: ");
			stringBuilder.Append(Y1);
			stringBuilder.Append(" / CentroX: ");
			stringBuilder.Append(CentroX);
			stringBuilder.Append(" / CentroY: ");
			stringBuilder.Append(CentroY);
			return stringBuilder.ToString();
		}

		public void AdicionarPixel(int x, int y) {
			Area++;
			if (X0 > x) {
				X0 = x;
			}
			if (Y0 > y) {
				Y0 = y;
			}
			if (X1 < x) {
				X1 = x;
			}
			if (Y1 < y) {
				Y1 = y;
			}
		}

		public void AtualizarCentro() {
			CentroX = (X1 + X0) / 2;
			CentroY = (Y1 + Y0) / 2;
		}

		public bool ContemPonto(int x, int y) {
			return (x >= X0 && x <= X1 && y >= Y0 && y <= Y1);
		}

		public bool FazInterseccao(int x0, int y0, int x1, int y1) {
			return (x0 <= X1 && x1 >= X0 && y0 <= Y1 && y1 >= Y0);
		}
	}
}
