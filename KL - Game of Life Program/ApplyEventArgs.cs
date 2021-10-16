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
        int NewHeight;
        int NewWidth;
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
            get { return NewHeight; }
            set { NewHeight = value; }
        }
        public int Width
        {
            get { return NewWidth; }
            set { NewWidth = value; }
        }
       public ApplyEventArgs(int NewHeight, int NewWidth)
        {
            Height = NewHeight;
            Width = NewWidth;
        }
    }
}
