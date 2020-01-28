using System;


namespace MonteCarloIntegral
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Integral(5, 15, 1000000));
            }
            Console.ReadKey();
        }
        static double Integral(double a, double b, double n)
        {
            Random rand = new Random();
            int i;
            double suma = 0;
            double x = 0;

            double y = 0;
            double c = 0;
            double yf = 0;

            double y1 = Math.Abs(Function(a));
            double y2 = Math.Abs(Function(b));

            if (y1 > y2)
            {
                c = 2 * y1;
            }
            else
            {
                c = 2 * y2;
            }
            i = 0;
            suma = 0;
            do
            {

                x = GetRandomNumber(a, b);
                y = rand.NextDouble() * c;
                yf = Math.Abs(Function(x));

                if (yf > c)
                {
                    c = 2 * yf;
                    i = 0;
                    suma = 0;
                    continue;
                }
                else
                {
                    if (yf <= y)
                    {
                        suma++; ;
                    }
                }
                i++;
            } while (i <= n);

            double Integral = (suma / n) * (b - a) * c;
            return Integral;
        }


        static double Function(double x)
        {
            return Math.Cos(x);
        }

        static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}

