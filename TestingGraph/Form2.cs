using System;
using System.Windows.Forms;
using TestingGraph.UserControls;

namespace TestingGraph
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AddChild(ETypeControls.eStartPanel);
        }

        public void LoadStartPage()
        {
            var ctrl = ControlsFactory.CreateControl(ETypeControls.eStartPanel);
            AddChild(ctrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">тип элемкента управления</param>
        public void AddChild(ETypeControls type)
        {
            var ctrl = ControlsFactory.CreateControl(type);
            if (ctrl == null)
                throw new Exception("ctrl is null");
            PresentPanel.Controls.Clear();
            if (ctrl is InputData matrix)
            {
                switch (type)
                {
                    case ETypeControls.eStartPanel:
                        matrix.DoHideField2();
                        break;
                    case ETypeControls.eAdjacencyMatrixInput:
                        matrix.DoHideField2();
                        break;
                    case ETypeControls.eEdgeListInput:
                    case ETypeControls.eIncidenceMatrixInput:
                        matrix.DoVisibleField2();
                        break;
                    case ETypeControls.eMatrix:
                        break;
                }
            }
            PresentPanel.Controls.Add(ctrl);
        }

        /// <summary>
        /// Добавляет елемент управления на форму
        /// </summary>
        /// <param name="ctrl">элемент управления</param>
        public void AddChild(Control ctrl)
        {
            if (ctrl == null)
                throw new Exception("ctrl is null");
            PresentPanel.Controls.Clear();
            PresentPanel.Controls.Add(ctrl);
           
        }

        public ETypeControls CurrentVar { get; set; }
    }


    /// <summary>
    /// тип элемента управления
    /// </summary>
    public enum ETypeControls
    {
        eStartPanel,
        eAdjacencyMatrixInput,//матрица смежности
        eIncidenceMatrixInput,//матрица инцедентности
        eEdgeListInput,//список ребер
        eMatrix//заполнение матрицы
    }

    
    /// <summary>
    ///Фабрика пользовательских элементов упоравления
    /// </summary>
    public class ControlsFactory
    {
        public static Control CreateControl(ETypeControls type)
        {
            switch (type)
            {
                case ETypeControls.eStartPanel:
                    return new StartPanel();
                case ETypeControls.eIncidenceMatrixInput:
                case ETypeControls.eAdjacencyMatrixInput:
                case ETypeControls.eEdgeListInput:
                    return new InputData();
                case ETypeControls.eMatrix:
                    return new eMatrix();

                default:
                    return null;
            }
        }
    }
}