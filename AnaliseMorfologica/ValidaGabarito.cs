using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnaliseMorfologicaLib;

namespace AnaliseMorfologica
{
    class ValidaGabarito
    {
        public static int ValidarGabarito(List<Forma> list, int x0, int y0, int x1, int y1)
        {
            int countForms = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    countForms++;
                }
            }
            return countForms;
        }
    }
}
