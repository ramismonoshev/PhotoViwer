using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_PhotoVacances
{
    public partial class frmWaitForm : Form
    {
        #region Property
        public Action Worker { get; set; }
        #endregion


        public frmWaitForm(Action worker)
        {
            InitializeComponent();
            this.CenterToScreen();

            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion



    }
}
