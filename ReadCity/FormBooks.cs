using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadCity
{
    public partial class FormBooks : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormBooks(User user, bool guest)
        {
            InitializeComponent();
        }
    }
}
