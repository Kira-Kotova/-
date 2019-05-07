using static System.Console;

namespace NM_Task_3
{
    class Program
    {
        static void Main()
        {
            //начальные значения
            double x0;
            var j = new[] {1, 2, 3, 4};
            var x = new[] {1.0, 2.0, 3.0, 4.0};
            //Y(Xi)
            var y = new[] {3.395, 3.631, 3.872, 3.906};

            //Y(Xi, Xi+1)
            var k1 = (y[0] - y[1]) / (x[0] - x[1]); 
            var k2 = (y[1] - y[2]) / (x[1] - x[2]);
            var k3 = (y[2] - y[3]) / (x[2] - x[3]);
            //Y(Xi, Xi+1, Xi+2)
            var k4 = (k1 - k2) / (x[0] - x[2]);
            var k5 = (k2 - k3) / (x[1] - x[3]);
            //Y(Xi, Xi+1, Xi+2, Xi+3)
            var k6 = (k1 - k3) / (x[0] - x[3]);

            // матрица
            var matrix = new[,]
            {
                {x[0], y[0], k1, k4, k6},
                {x[1], y[1], k2, k5, 0 },
                {x[2], y[2], k3, 0,  0 },
                {x[3], y[3], 0,  0,  0 }
            };
            
            WriteLine("Начальные условия:");
            Write($"{nameof(x)} := "); Print(x);
            Write($"{nameof(y)} := "); Print(y);
            PrintM(matrix);
            WriteLine("Расчёт по четырём узлам");
            
            //Расчёт по четырём узлам значения функции
            x0 = 1.5;
            WriteLine($"При х0 = {x0}\n N = {N(y, x0, x, k1, k4, k6):0.000}\n L = {L(y,x0,x):0.000}");
            x0 = 2.5;
            WriteLine($"При х0 = {x0}\n N = {N(y, x0, x, k1, k4, k6):0.000}\n L = {L(y,x0,x):0.000}");
            x0 = 3.5;
            WriteLine($"При х0 = {x0}\n N = {N(y, x0, x, k1, k4, k6):0.000}\n L = {L(y,x0,x):0.000}");  
        }

        // Расчёт интерполяционным методом Ньютона
        private static double N(double[] y, double x0, double[] x, double k1, double k4, double k6) => 
            y[0] + (x0 - x[0]) * k1 + (x0 - x[0]) * (x[0] - x[1]) * k4 + (x0 - x[0]) * (x[0] - x[1]) * (x[1] - x[2]) * k6;

        // Расчёт интерполяционным многочленом Лагранджа 
        private static double L(double[] y, double x0, double[] x)
        {
            var a1 = y[0] * ((x0 - x[1]) * (x0 - x[2]) * (x0 - x[3])) / ((x[0] - x[1]) * (x[0] - x[2]) * (x[0] - x[3]));
            var a2 = y[1] * ((x0 - x[0]) * (x0 - x[2]) * (x0 - x[3])) / ((x[1] - x[0]) * (x[1] - x[2]) * (x[1] - x[3]));
            var a3 = y[2] * ((x0 - x[0]) * (x0 - x[1]) * (x0 - x[3])) / ((x[2] - x[0]) * (x[2] - x[1]) * (x[2] - x[3]));
            var a4 = y[3] * ((x0 - x[0]) * (x0 - x[1]) * (x0 - x[2])) / ((x[3] - x[0]) * (x[3] - x[1]) * (x[3] - x[2]));
            return a1 + a2 + a3 + a4;
        }

        // Метод для вывода массива на консоль
        private static void Print(double[] array)
        {
            foreach (var element in array)
                Write($"{element} ");
            WriteLine();
        }

        // Метод для вывода матрицы на консоль
        private static void PrintM(double[,] matrix)
        {
            WriteLine("--------Матрица--------");
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Write($"{matrix[i,j]:0.000} ");
                }
                WriteLine();
            }
            WriteLine("-----------------------");
        }
    }
}
