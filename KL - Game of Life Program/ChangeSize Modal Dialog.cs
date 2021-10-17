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
        public int NewHeight
        {
            get
            { return (int)numericUpDownHeight.Value; }
            set
            {
                numericUpDownHeight.Value = value;
            }
        }
        public int NewWidth
        {
            get
            { return (int)numericUpDownWidth.Value; }
            set
            {
                numericUpDownWidth.Value = value;
            }
        }
        public int NewTime
        {
            get
            { return (int)numericUpDownTimerInterval.Value; }
            set
            {
                numericUpDownTimerInterval.Value = value;
            }
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (Apply != null) Apply(this, new ApplyEventArgs(this.NewHeight, this.NewWidth, this.NewTime));
        }
    }
}
