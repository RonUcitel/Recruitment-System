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
    public partial class City_Form : Form
    {
        public City_Form(City selectedCity)
        {
            InitializeComponent();
            Text = selectedCity.Name;
            SelectedCity = selectedCity;
        }

        public City SelectedCity;
    }
}
