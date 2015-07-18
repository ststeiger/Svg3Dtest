
namespace _3dDrawing
{


    // jagged array (array of arrays) int[][] 
    // jagged array initialization ==> MyClass[][] abc = new MyClass[10][]; for (int i = 0; i < abc.Length; i++) abc[i] = new MyClass[20];
    // uniform array: int[,] 
    // uniform array initialization ==>> MyClass[,] x = new MyClass[10, 20]

    // Jagged:
    // double[][] RotationMatrixX = new double[][] {
    //              new double[]{ 1, 0, 0 }
    //             ,new double[]{ 0, c, -s}
    //             ,new double[]{ 0, s, c }
    // };

    // Uniform:
    // double[,] RotationMatrixX = {
    //              { 1, 0, 0},
    //              { 0, c,-s},
    //              { 0, s, c}
    // };


    // https://msdn.microsoft.com/en-us/library/dd460713(v=vs.110).aspx
    public static class MatrixExtensions
    {


        // https://en.wikipedia.org/wiki/Rotation_matrix
        public static double[][] RotmX(double angle)
        {
            double s = sinus(angle);
            double c = cosinus(angle);


            double[][] array3d = new double[][] {
                 new double[]{ 1, 0, 0 }
                ,new double[]{ 0, c, -s}
                ,new double[]{ 0, s, c }
            };

            return array3d;
        }

        public static double[][] RotmY(double angle)
        {
            double s = sinus(angle);
            double c = cosinus(angle);


            double[][] array3d = new double[][] {
                 new double[]{ c, 0, s }
                ,new double[]{ 0, 1, 0 }
                ,new double[]{-s, 0, c }
            };

            return array3d;
        }


        public static double[][] RotmZ(double angle)
        {
            double s = sinus(angle);
            double c = cosinus(angle);


            double[][] array3d = new double[][] {
                 new double[]{ c,-s, 0 }
                ,new double[]{ s, c, 0 }
                ,new double[]{ 0, 0, 1 }
            };

            return array3d;
        }



        public static void test()
        {
            
            double[][] array3d = new double[][] {
                 new double[]{ 1,2,3}
                ,new double[]{ 4,5,6}
                ,new double[]{7,8,9 }
            };
            

            int[,] matrix3d = {
                { 1, 2,3 }
                , { 4, 5,6 }
                , { 7, 8, 9 }
            };

        }



        public static double sinus(double angle)
        {
            return System.Math.Sin(Degrees2Radian(angle));
        }

        public static double cosinus(double angle)
        {
            return System.Math.Cos(Degrees2Radian(angle));
        }


        public static double Degrees2Radian(double angle)
        {
            return System.Math.PI * angle / 180.0; 
        }


        public static double Radian2Degree(double angle)
        {
            return angle * 180.0 / System.Math.PI;
        }


        public static void TransposeSquareMatrixInPlace(int[,] matrix)
        {
            if (matrix == null) throw new System.ArgumentNullException("matrix");
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new System.ArgumentOutOfRangeException("matrix", "matrix is not square");

            int size = matrix.GetLength(0);

            for (int n = 0; n < (size - 1); ++n)
            {
                for (int m = n + 1; m < size; ++m)
                {
                    int temp = matrix[n, m];
                    matrix[n, m] = matrix[m, n];
                    matrix[m, n] = temp;
                }
            }
        }

        public static void InplaceTransposeSquare(double[][] matrix)
        {
            if (matrix == null)
                throw new System.ArgumentNullException("matrix");

            int size = matrix.Length;

            if (size != matrix[0].Length)
                throw new System.ArgumentOutOfRangeException("matrix", "matrix is not square");

            for (int n = 0; n < (size - 1); ++n)
            {
                for (int m = n + 1; m < size; ++m)
                {
                    double temp = matrix[n][m];
                    matrix[n][m] = matrix[m][n];
                    matrix[m][n] = temp;
                }
            }
        }


        public static double[][] CreateMatrix(int n)
        {
            return CreateMatrix(n, n);
        }


        public static double[][] CreateMatrix(int m, int n)
        {
            double[][] mtrx = new double[m][];
            for (int i = 0; i < m; ++i)
            {
                mtrx[i] = new double[n];
            }

            return mtrx;
        }


        public static void TransposeSquare(double[][] matrix)
        {
            if (matrix == null)
                throw new System.ArgumentNullException("matrix");

            int size = matrix.Length;

            if (size != matrix[0].Length)
                throw new System.ArgumentOutOfRangeException("matrix", "matrix is not square");

            double[][] mtrx = CreateMatrix(size);
            
            for (int n = 0; n < (size - 1); ++n)
            {
                for (int m = n + 1; m < size; ++m)
                {
                    mtrx[m][n] = matrix[n][m];
                }
            }
        }


        public static void PrintMatrix(double[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            System.Console.WriteLine("\nMatrix A : ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write(matrix[i][j] + "\t");
                }

                System.Console.WriteLine();
            }
        }

        public static void PrintMatrix2(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            System.Console.WriteLine("\nMatrix A : ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write(matrix[i, j] + "\t");
                }

                System.Console.WriteLine();
            }
        }


        // http://stackoverflow.com/questions/20181020/how-to-multiply-a-matrix-in-c
        //public static double[] MatrixProduct(this double[][] matrixA, double[] vectorB)
        public static double[] MatrixProduct(double[][] matrixA, double[] vectorB)
        {
            int aRows = matrixA.Length;
            int aCols = matrixA[0].Length;

            int bRows = vectorB.Length;
            if (aCols != bRows)
                throw new System.Exception("Non-conformable matrices in MatrixProduct");

            double[] result = new double[aRows];
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int k = 0; k < aCols; ++k)
                    result[i] += matrixA[i][k] * vectorB[k];

            return result;
        }


        // public static double[][] MatrixProduct(this double[][] matrixA, double[][] matrixB)
        public static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new System.Exception("Non-conformable matrices in MatrixProduct");

            double[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];

            return result;
        }


        public static double[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s  
            // do error checking here?  
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            // auto init to 0.0  
            return result;
        }


    }


}
