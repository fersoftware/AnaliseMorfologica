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

        public static string ValidarAlternativa(List<Forma> list, int x0, int y0, int x1, int y1)
        {
            Forma alternativa = null;
            int countForms = 0;
            string resposta = "";
            //Confere alternativa A:
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    alternativa = list[i];
                    countForms++;
                }
            }
            if (alternativa != null && countForms == 1)
            {
                if (alternativa.Area > 900)
                {
                    resposta += "A,";
                }
            }
            //acrescenta valores considerando coordenadas relativas:
            x0 += 50 + 15;
            x1 += 50 + 15;
            countForms = 0;
            //Confere alternativa B:
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    alternativa = list[i];
                    countForms++;
                }
            }
            if (alternativa != null && countForms == 1)
            {
                if (alternativa.Area > 900)
                {
                    resposta += "B,";
                }
            }
            //acrescenta valores considerando coordenadas relativas:
            x0 += 50 + 15;
            x1 += 50 + 15;
            countForms = 0;
            //Confere alternativa C:
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    alternativa = list[i];
                    countForms++;
                }
            }
            if (alternativa != null && countForms == 1)
            {
                if (alternativa.Area > 900)
                {
                    resposta += "C,";
                }
            }
            //acrescenta valores considerando coordenadas relativas:
            x0 += 50 + 15;
            x1 += 50 + 15;
            countForms = 0;
            //Confere alternativa D:
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    alternativa = list[i];
                    countForms++;
                }
            }
            if (alternativa != null && countForms == 1)
            {
                if (alternativa.Area > 900)
                {
                    resposta += "D,";
                }
            }
            //acrescenta valores considerando coordenadas relativas:
            x0 += 50 + 15;
            x1 += 50 + 15;
            countForms = 0;
            //Confere alternativa E:
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FazInterseccao(x0, y0, x1, y1))
                {
                    alternativa = list[i];
                    countForms++;
                }
            }
            if (alternativa != null && countForms == 1)
            {
                if (alternativa.Area > 900)
                {
                    resposta += "E,";
                }
            }
            return resposta;
        }
    }
}
