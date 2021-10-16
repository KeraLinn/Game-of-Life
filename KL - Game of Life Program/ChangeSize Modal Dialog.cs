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
    public partial class ChangeSize_Modal_Dialog : Form
    {
        public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);
        public event ApplyEventHandler Apply;
        public ChangeSize_Modal_Dialog()
        {
            InitializeComponent();
        }

/*        public int NewHeight
        {
            get { return NewHeight; }
            set { NewHeight = value; }
        }
        public int NewWidth
        {
            get { return NewWidth; }
            set { NewWidth = value; }
        }*/
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (Apply != null) Apply(this, new ApplyEventArgs(Height, Width));
        }
    }
}
