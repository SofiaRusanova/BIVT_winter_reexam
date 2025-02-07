// Variant_10

using System;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            // Task_1:
            // Input: S = 4, A = 6, N = 22
            // Output: time = 18

            //Console.WriteLine(program.Task_1(4, 6, 22));


            // Task_2:
            // Input: GPU = 4, RAM = 6, CPU = 22
            // Output: fps = 13,200000000000003

            //Console.WriteLine(program.Task_2(4, 6, 22));

            // Task_3:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 -13, 13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 22,  21,  18,  19, -22,  -4, 
                  2,   0,   1, -16, -20, -17, 
                 23,   7,  13,  24, -21,  18 */

            //int[,] M = new int[,] {
            //    { 23, 7, -13, 24, -21, 18 },
            //    { 2, 0, 12, -16, -20, -17 },
            //    { 22, 21, -6, 19, -22, -4 },
            //    {-13, 13,  18, -15, -20,  -2 },
            //    {3,   7,   1, -20,  22,  -8 },
            //    {-22, -11,  13,  -2,   0, -14}
            //};
            //program.Task_3(M);
            //program.Print(M);

            // Task_4:
            // Input:
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*    2, -10, -20 */

            // Task_5:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2, -10,  -1, -20 */
            // Output 1:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*  -20, -10,  -1,   2,  17,  17, -15, -14,  -6,   0,  22,  23 */
            // Output 2:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            /*   17,  17,   2,  -1, -10, -20,  23,  22,   0,  -6, -14, -15 */

        }
        public double Task_1(double S, double A, double N)
        {
            double pok = 0, time = 1;
            for (double i = 0; pok < N; i++)
            {
                pok = pok + Math.Sqrt(i);
                if (time % 5 == 0)
                {
                    pok = pok - S;
                    if (pok < 0)
                    {
                        pok = pok + S;
                    }
                }

                if (time % A == 0 && pok < N)
                {
                    pok = pok / 1.5;
                }
                time++;
            }
            return time;
        }
        public double Task_2(double GPU, double RAM, double CPU)
        {
            double gpuLoad = 10, ramLoad = 1, cpuLoad = 1, fps = 200;
            while (fps > 20)
            {
                if (gpuLoad < GPU)
                {
                    gpuLoad *= 1.1;
                }
                if (ramLoad < RAM)
                {
                    ramLoad *= 2;
                }
                else
                {
                    ramLoad /= 1.5;
                    cpuLoad++;
                }
                if (cpuLoad > CPU)
                {
                    cpuLoad = CPU;
                    gpuLoad = GPU;
                }
                fps = (GPU / gpuLoad) * (RAM / ramLoad) * (CPU / cpuLoad);
            }
            return fps;
        }
        public void Task_3(int[,] M)
        {
            int jmin = 0, m = M.GetLength(0);
            if (M == null || M.GetLength(0) == 0 || M.GetLength(0) != M.GetLength(1)) return;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (M[i, j] < M[i, jmin] && M[i, j] > 0) //индекс мин положительного
                    {
                        jmin = j;
                    }
                }
            }

            int[,] B = new int[M.GetLength(0), M.GetLength(1)];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++) //записываем значения в новый массив
                {
                    B[i, j] = M[i, j];
                }
            }
            int k = -1; //индекс строки которую будем менять
            for (int j = 0; j < M.GetLength(1); j++)
            {
                if (B.GetLength(0) % 2 == 0) //четная матрица
                {
                    k = m / 2;
                    B[k, j] = M[k - 1, j];
                }
                if (B.GetLength(0) % 2 != 0) //нечетная матрица
                {
                    k = 1 + (m / 2);
                    B[k, j] = M[k - 2, j];
                }
                B[k, jmin] = M[k, jmin];
            }
            M = B;

        }
        public void Task_4(ref int[] A)
        {
            int min = 999, c = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < min && A[i] > 0) //минимальный положительный
                {
                    min = A[i];
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (min % 2 == 0)
                {
                    if (A[i] % 2 == 0) c++;
                }
                if (min % 2 != 0)
                {
                    if (A[i] % 2 != 0) c++;
                }
            }
        }
        public int[] GetArraySequence(int[] array, bool isEven)
        {
            return default(int[]); 
        }
        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public int[] Concat(int[] array1, int[] array2) { return default(int[]); }

        //public void Print(int[] A)
        //{
        //    foreach (var item in A)
        //    {
        //        Console.WriteLine(item + ", ");
        //    }
        //}
        public void Print(int[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write(M[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}