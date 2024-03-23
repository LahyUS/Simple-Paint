using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Programming.objects
{
    class EB    // Class Edge Bugcket : Contain the information of an edge
    {
        private int y_upper;
        private int y_lower;
        private float x_int;
        private float reci_slope;

        public int Y_Upper
        {
            get => this.y_upper;
            set => this.y_upper = value;
        }

        public int Y_Lower
        {
            get => this.y_lower;
            set => this.y_lower = value;
        }

        public float X_Int
        {
            get => this.x_int;
            set => this.x_int = value;
        }

        public float Reci_Slope
        {
            get => this.reci_slope;
            set => this.reci_slope = value;
        }

        public EB(int Y_Upper, int Y_Lower, float X_Int, float Reci_Slope)
        {
            this.y_upper = Y_Upper;
            this.y_lower = Y_Lower;
            this.x_int = X_Int;
            this.reci_slope = Reci_Slope;
        }
    }
}
