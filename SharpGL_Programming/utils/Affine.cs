using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.utils
{
    class Affine
    {
        public Matrix<float> _matrixTransform;//ma trận 3x3 biểu diễn phép biến đổi affine

        public int MyAutoImplementedProperty { get; set; }

        public Affine()
        {
            this._matrixTransform = utils.Matrix<float>.create_unit_mat(3, 3);
        }    

        public void Clone(Affine other)
        {
            for(int i =0;i<3;i++)
            {
                for(int j = 0;j<3;j++)
                {
                    this._matrixTransform[i, j] = other._matrixTransform[i, j];
                }
            }
        }

        public void Move(float dx, float dy)
        {
            Matrix<float> temp = utils.Matrix<float>.create_unit_mat(3, 3);
            //Gán các giá trị dx, dy tại (0, 2), (1, 2)
            temp[0,2] = dx;
            temp[1, 2] = dy;
            //Nhân matrix gốc với ma trận tịnh tiến
            utils.Matrix<float>.Mul(ref _matrixTransform,temp);
        }

        public void Rotate(float angle)
        {
            angle = angle * (float)3.14;
            float sinAlpha = (float)Math.Sin(angle), cosAlpha = (float)Math.Cos(angle);
            Matrix<float> temp = utils.Matrix<float>.create_unit_mat(3, 3);
            //Gán các giá trị dx, dy tại (0, 2), (1, 2)
            temp[0, 0] = cosAlpha;
            temp[0, 1] = -sinAlpha;
            temp[1, 0] = sinAlpha;
            temp[1, 1] = cosAlpha;
            //Nhân matrix gốc với ma trận tịnh tiến
            utils.Matrix<float>.Mul(ref _matrixTransform, temp);
        }

        public void Scale(float sx, float sy)
        {
            Matrix<float> temp = utils.Matrix<float>.create_unit_mat(3, 3);
            //Gán các giá trị dx, dy tại (0, 2), (1, 2)
            temp[0, 0] = sx;
            temp[1, 1] = sy;
            //Nhân matrix gốc với ma trận tịnh tiến
            utils.Matrix<float>.Mul(ref _matrixTransform, temp);
        }

        public void Flip(int direction)
        {
            Matrix<float> temp = utils.Matrix<float>.create_unit_mat(3, 3);
            // horizontal flip
            if (direction == 0)
                temp[1, 1] = -1;

            // vertical flip
            else if (direction == 1)
                temp[0, 0] = -1;
            else
            {
                temp[0, 0] = -1;
                temp[1, 1] = -1;
            }
                //Nhân matrix gốc với ma trận tịnh tiến
                utils.Matrix<float>.Mul(ref _matrixTransform, temp);
        }

        public void Shift(int direction, float sh)
        {
            Matrix<float> temp = utils.Matrix<float>.create_unit_mat(3, 3);

            // Shift along on Ox
            if (direction == 0)
                temp[0, 1] = sh;
            //Else : shift along on Oy
            else if (direction == 1)
                temp[1, 0] = sh;

            //Nhân matrix gốc với ma trận tịnh tiến
            utils.Matrix<float>.Mul(ref _matrixTransform, temp);
        }

        public void TransformPoint(ref float x, ref float y)
        {
            float[] P = { x, y, 1 };
            float[] P1 = { 0, 0, 0 }; //Tạo 2 ma trận điểm ảnh nguồn và đích
                                                           //Nhân ma trận nguồn với ma trận chuyển đổi
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    float g = _matrixTransform[i, j];
                    //P1[i] = P[i] + P[j] * _matrixTransform.at<float>(i, j);
                    P1[i] = P1[i] + P[j] * g;
                }
            }
            //Gán lại giá trị mới cho điểm ảnh
            x = P1[0];
            y = P1[1];
        }
    }
}
