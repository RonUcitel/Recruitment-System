﻿using System;
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
    public partial class Job_Form : Form
    {
        public Job_Form(Job selectedJob)
        {
            InitializeComponent();
            Text = selectedJob.Name;
            SelectedJob = selectedJob;
        }

        public Job SelectedJob;
    }
}
