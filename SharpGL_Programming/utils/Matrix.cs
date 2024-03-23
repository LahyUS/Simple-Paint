using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpGL_Programming.utils
{
    public class Matrix<T>
    {
        public int r;
        public int c;
        public T[,] mat;

        public int MyAutoImplementedProperty { get; set; }

        public int Rows
        {
            get { return r; }
            set { this.r = value; }
        }
        public int Cols
        {
            get { return c; }
            set { this.c = value; }
        }

        public Matrix()
        {
            mat = new T[r, c];
        }

        public Matrix(int Row, int Col)
        {
            this.Rows = Row;
            this.Cols = Col;
            this.mat = new T[Row, Col];
            //this.setMat();
        }

        public Matrix(Matrix<T> other)
        {
            this.mat = other.mat;
        }

        public static Matrix<float> create_unit_mat(int Rows, int Cols)
        {
            Matrix<float> res = new Matrix<float>(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (i == j)
                    { res[i, j] = 1; }
                    else
                    { res[i, j] = 0; }
                }
            }
            res.Rows = Rows;
            res.Cols = Cols;
            return res;
        }

        public static Matrix<int> init_matrix(int Rows, int Cols)
        {
            Matrix<int> res = new Matrix<int>(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    res[i, j] = 0;
                }
            }
            res.Rows = Rows;
            res.Cols = Cols;
            return res;
        }

        // indexer
        public T this[int i, int j]
        {
            get => mat[i, j];
            set => mat[i, j] = value;
        }

        public void printMat()
        {
            for(int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    System.Console.Write(this.mat[i, j]);
                    System.Console.Write(" ");
                }
                System.Console.WriteLine("");
            }
        }

        public void Clone(Matrix<T> other)
        {
            for (int i = 0; i < other.Rows; i++)
            {
                for (int j = 0; j < other.Cols; j++)
                {
                    this.mat[i, j] = other[i, j];
                }
            }
        }

        public static void Mul(ref Matrix<float> a, Matrix<float> b)
        {
            Matrix<float> temp = new Matrix<float>(a.Cols, a.Rows);
            //temp.create_unit_mat(a.Rows, a.Cols);
            temp.Clone(a);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    a[i, j] = 0;
                    for (int k = 0; k < a.Cols; k++)
                        a[i, j] = a[i, j] + temp[i, k] * b[k, j];

                }
            }
        }
    }
}
