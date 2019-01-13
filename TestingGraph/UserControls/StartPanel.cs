using System;
using System.Windows.Forms;

namespace TestingGraph.UserControls
{
    public partial class StartPanel : UserControl
    {
        public StartPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// матрица смежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmezButton_Click(object sender, EventArgs e)
        {
           var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.AddChild(ETypeControls.eAdjacencyMatrixInput);
                form.CurrentVar = ETypeControls.eAdjacencyMatrixInput;
            }
        }

        /// <summary>
        /// матрица инцедентности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntButton_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.AddChild(ETypeControls.eIncidenceMatrixInput);
                form.CurrentVar = ETypeControls.eIncidenceMatrixInput;
            }
        }

        private void LinksButton_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.AddChild(ETypeControls.eEdgeListInput);
                form.CurrentVar = ETypeControls.eEdgeListInput;
            }
        }
    }
}
