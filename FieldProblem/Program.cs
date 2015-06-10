using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FieldProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(maxprofit("50","200","30","5","3","2","2","15","10"));
            Console.WriteLine(maxprofit("10", "10", "5", "2", "2", "3", "1", "14", "25"));
            Console.ReadLine();
        }
        public static string maxprofit(string L, string F, string P, string F1, string P1, string F2, string P2, string S1, string S2)
        {
            string max = "-1";
            double[] X = new double[5];
            double[] Y = new double[5];

            // when B is =0 fer
            Y[0] = 0;
            X[0] = (Convert.ToDouble( F)/Convert.ToDouble(F1));
            Y[1] = 0;
            X[1] = (Convert.ToDouble(P)/ Convert.ToDouble(P1));

            // when W is =0 fer
            X[2] = 0;
            Y[2] = (Convert.ToDouble(F )/ Convert.ToDouble(F2));
            X[3] = 0;
            Y[3] = (Convert.ToDouble(P) / Convert.ToDouble(P2));

            Double M = double.MinValue;
            int X1=-1;

            double lcm = LCM(Convert.ToDouble(F1), Convert.ToDouble(P1));
            double Q1 = lcm / Convert.ToDouble(F1),Q2 = lcm / Convert.ToDouble(P1);
            //Y[4] = Math.Abs((Math.Abs(Convert.ToDouble(F) * Q1) - Math.Abs(Convert.ToDouble(P) * Q2))/(Math.Abs(Convert.ToDouble(F2) * Q1) - Math.Abs(Convert.ToDouble(P2) * Q2)));
            //X[4] = Math.Abs((Math.Abs(Convert.ToDouble(F)) - Math.Abs(Convert.ToDouble(F2) * Y[4])) / Convert.ToDouble(F1) );
            Y[4] = ((Convert.ToDouble(F) * Q1) - (Convert.ToDouble(P) * Q2)) / ((Convert.ToDouble(F2) * Q1) - (Convert.ToDouble(P2) * Q2));
            X[4] = (((Convert.ToDouble(F)) - (Convert.ToDouble(F2) * Y[4])) / Convert.ToDouble(F1));
            if (X[4] < 0 || Y[4] < 0)
                return max;
            for (int i = 0; i < 5; i++)
            {
                if (((X[i] + Y[i]) < Convert.ToDouble(L)) && (((X[i] * Convert.ToDouble(F1)) + (Y[i] * Convert.ToDouble(F2))) <= Convert.ToDouble(F)) && (((X[i] * Convert.ToDouble(P1)) + (Y[i] * Convert.ToDouble(P2))) <= Convert.ToDouble(P)))
                {
                    double vvv = ((X[i] * Convert.ToDouble(S1)) + (Y[i] * Convert.ToDouble(S2)));
                    if (vvv > M)
                    {
                        M = vvv;
                        X1 = i;
                    }
                }
            }
            if (M != double.MinValue)
            {
                max = Math.Round(M, 2).ToString() + "," + ((X[X1]==0)?"0.00": Math.Round(X[X1], 2).ToString()) + "," +((Y[X1]==0)?"0.00": Math.Round(Y[X1], 2).ToString());
            }
                return max;
        }
        public static Double LCM(Double A, Double B)
        {
            Double L = (A > B) ? A : B, S = (A > B) ? B : A, LCM = L;
            while (LCM % S != 0)
                LCM += L;
            return LCM;
        }

    }
}
