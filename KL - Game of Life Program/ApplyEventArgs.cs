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

        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }
        public ApplyEventArgs(int seed)
        {
            this.seed = seed;
        }
    }
}
