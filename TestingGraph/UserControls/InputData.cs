using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TestingGraph.UserControls;

namespace TestingGraph
{
    public partial class InputData : UserControl
    {
        public InputData()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.LoadStartPage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
          
            if (parent is Form2 form)
            {
                var ctrl = ControlsFactory.CreateControl(ETypeControls.eMatrix);
                if (ctrl == null)
                    throw new Exception("eStartPanel is null");
                var matrix = ctrl as eMatrix;
                Debug.Assert(matrix != null, nameof(matrix) + " != null");
                matrix.m_Val1 = Convert.ToInt32(numericUpDown1.Value);

                if (bFlagIsVisible)
                    matrix.m_Val2 = Convert.ToInt32(numericUpDown2.Value);

                matrix?.FillTable(form.CurrentVar);
                form.AddChild(ctrl);
            }
        }

        private bool bFlagIsVisible = false;
        public void DoVisibleField2()
        {
            label3.Show();
            numericUpDown2.Show();
            bFlagIsVisible = true;
        }

       public void DoHideField2()
        {
            label3.Hide();
            numericUpDown2.Hide();
            bFlagIsVisible = false;
        }
    }
}
