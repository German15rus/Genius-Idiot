using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius___Idiot
{
    public class DiagnosCalculator
    {
        public static string Make(int questionsCount, int correctCount)
        {
            List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Живчик", "Нормис", "Сигмантей", "Гений" };
            double correctPercent = (double)correctCount / questionsCount * 100;
            if (correctPercent == 0)
                return diagnosises[0];
            else if (correctPercent < 20)
                return diagnosises[1];
            else if (correctPercent < 40)
                return diagnosises[2];
            else if (correctPercent < 60)
                return diagnosises[3];
            else if (correctPercent < 80)
                return diagnosises[4];
            return diagnosises[5];
        }
    }
}
