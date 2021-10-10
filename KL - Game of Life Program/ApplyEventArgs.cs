using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL___Game_of_Life_Program
{
    public class ApplyEventArgs : EventArgs
    {
        int seed;
        int height;
        int width;
        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }
        public ApplyEventArgs(int seed)
        {
            this.seed = seed;
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public ApplyEventArgs(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
    }
}
