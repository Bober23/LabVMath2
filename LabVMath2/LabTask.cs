using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVMath2
{
    class LabTask
    {
        public MyPoint[] points = new MyPoint[6];
        public double[] h;

        public LabTask(MyPoint[] points)
        {
            this.points = points;
            h = new double[] { points[1].x - points[0].x, points[2].x - points[1].x, points[3].x - points[2].x , points[4].x - points[3].x ,points[5].x - points[4].x };
        }
        public LabTask()
        {
            points[0] = new MyPoint(0,1); //поменять на нужный вариант
            points[1] = new MyPoint(0.2,1.26);
            points[2] = new MyPoint(0.4,1.4);
            points[3] = new MyPoint(0.6,1.38);
            points[4] = new MyPoint(0.8,1.23);
            points[5] = new MyPoint(1,0.94);
            h = new double[] { points[1].x - points[0].x, points[2].x - points[1].x, points[3].x - points[2].x, points[4].x - points[3].x, points[5].x - points[4].x };
        }
        public double[] GetACoefs()
        {
            double[] a = new double[4];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = points[i].y;
            }
            return a;
        }
        public double[] GetBCoefs()
        {
            double[] c = GetCCoefs();
            double[] b = new double[4];
            for (int i = 0;i < b.Length - 1; i++)
            {
                b[i] = ((points[i + 1].y - points[i].y) / h[i]) - 1.0 / 3.0 * h[i] * (c[i + 1] + 2 * c[i]);
                }
            b[b.Length - 1] = ((points[b.Length].y - points[b.Length - 1].y) / h[b.Length - 1]) - 2.0 / 3.0 * h[b.Length - 1] * c[b.Length - 1];
            return b;
        }
        public double[] GetCCoefs()
        {
            double[,] matrix = GetSplineMatrix();
            double[] p = new double[4];
            double[] q = new double[4];
            double[] x = new double[4];
            p[0] = -matrix[0, 2] / (matrix[0, 1] + matrix[0, 0]);
            for (int i = 1; i < p.Length; i++)
            {
                p[i] = -matrix[i, i + 2] / (matrix[i, i + 1] + matrix[i, i] * p[i - 1]);
            }
            q[0] = matrix[0, 6] / matrix[0, 1];
            for (int i = 1; i < q.Length; i++)
            {
                q[i] = (matrix[i, 6] - matrix[i, i] * q[i - 1]) / (matrix[i, i + 1] + matrix[i, i] * p[i - 1]);
            }
            x[x.Length - 1] = q[q.Length - 1];
            for (int i = x.Length - 2; i >= 0; i--)
            {
                x[i] = p[i] * x[i + 1] + q[i];
            }
            return x;

        }
        public double[] GetDCoefs()
        {
            double[] c = GetCCoefs();
            double[] d = new double[4];
            for (int i = 0; i < d.Length - 1; i++)
            {
                d[i] = (c[i + 1] - c[i]) / 3 * h[i];
            }
            d[d.Length - 1] = -c[d.Length - 1] / 3 * h[d.Length - 1];
            return d;
        }
        private double[,] GetSplineMatrix()
        {
            var matrix = new double[4, 7];
            for (int i = 0; i < 4; i++)
            {
                matrix[i, 0 + i] = h[i];
                matrix[i, 1 + i] = 2 * (h[i] + h[i + 1]);
                matrix[i, 2 + i] = h[i + 1];
                matrix[i, 6] = 3 * (((points[i + 2].y - points[i + 1].y) / h[i + 1]) - ((points[i + 1].y - points[i].y) / h[i]));
            }
            matrix[0, 0] = 0;
            matrix[3, 5] = 0;
            return matrix;
        }
    }
}
