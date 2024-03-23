using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.utils
{
    class Transformer
    {
        public void Bilinear_Interpolate(float tx, float ty, Matrix<int> pSrc, int srcWidthStep, int nChannels, int i)
        {
            int x = (int)tx;
            int y = (int)ty;

            // get an uchar address of data array
            //uchar* pA11 = pSrc + (y * srcWidthStep * nChannels + x * nChannels) + i;
            //uchar* pA12 = pSrc + (y * srcWidthStep * nChannels + x * nChannels + 3) + i;
            //uchar* pA21 = pSrc + ((y + 1) * srcWidthStep * nChannels + x * nChannels) + i;
            //uchar* pA22 = pSrc + ((y + 1) * srcWidthStep * nChannels + x * nChannels + 3) + i;

            //// get value at index
            //uchar val1 = *pA11;
            //uchar val2 = *pA12;
            //uchar val3 = *pA21;
            //uchar val4 = *pA22;

            //// calculate value
            //uchar U1 = ((tx - x) * val1 + ((x + 1) - tx) * val2) / (1);
            //uchar U2 = ((tx - x) * val3 + ((x + 1) - tx) * val4) / (1);
            //uchar U = ((ty - y) * U1 + ((ty + 1) - ty) * U2) / (1);

            //return U;
        }
    }
}
