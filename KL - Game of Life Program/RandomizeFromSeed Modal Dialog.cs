using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KL___Game_of_Life_Program
{
    public partial class RandomizeFromSeed_Modal_Dialog : Form
    {
        public RandomizeFromSeed_Modal_Dialog()
        {
            InitializeComponent();
        }

        public int SeedInteger
        {
            get
            { return (int)SeedNumericUpDown1.Value; }
            set
            { SeedNumericUpDown1.Value = value; }
        }
    }
}
