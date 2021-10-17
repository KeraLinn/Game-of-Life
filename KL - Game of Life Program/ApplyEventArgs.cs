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
        int newHeight;
        int newWidth;
        int newTime;
        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }
        public ApplyEventArgs(int seed)
        {
            this.seed = seed;
        }
        public int NewTime
        {
            get
            { return newTime; }
            set
            { newTime = value; }
        }
        public int NewHeight
        {
            get
            { return newHeight; }
            set
            { newHeight = value; }
        }
        public int NewWidth
        {
            get
            { return newWidth; }
            set
            { newWidth = value; }
        }
        public ApplyEventArgs(int newHeight, int newWidth, int newTime)
        {
            this.newHeight = newHeight;
            this.newWidth = newWidth;
            this.newTime = newTime;
        }
        //public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);
    }
}
