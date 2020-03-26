using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class Position_Form : Form
    {
        public Position_Form(Position selectedPosition)
        {
            InitializeComponent();
            Text = selectedPosition.Name;
            SelectedPosition = selectedPosition;
        }

        public Position SelectedPosition;
    }
}
