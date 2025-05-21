using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osobne_Financije
{
    public partial class FrmReports: Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            cmbTimePeriod.Items.AddRange(new string[] { "Tjedan", "Mjesec", "6 mjeseci", "Godina", "Određeno razdoblje" });
            cmbTimePeriod.SelectedIndex = 0;

            cmbDataType.Items.AddRange(new string[] { "Prihodi", "Troškovi" });
            cmbDataType.SelectedIndex = 0;

            cmbTimePeriod.SelectedIndexChanged += cmbTimePeriod_SelectedIndexChanged;

        }

        private void cmbTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTimePeriod.SelectedItem.ToString() == "Određeno razdoblje")
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
                lblFrom.Visible = true;
                lblTo.Visible = true;
            }
            else
            {
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
                lblFrom.Visible = false;
                lblTo.Visible = false;
            }
        }
    }
}
