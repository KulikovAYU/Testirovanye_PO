using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TestingGraph
{
    public partial class eMatrix : UserControl
    {
        DataSet ds = new DataSet();
        private readonly algorhytm m_algo;

        public eMatrix()
        {
            InitializeComponent();
            m_algo =new algorhytm();
        }

        public int m_Val1 { get; set; }

        public int m_Val2 { get; set; }

        
        public  void FillTable(ETypeControls currentVar)
        {
            int n = 0;
            int n1 = 0;
            //Заполнение размерности массива
            switch (currentVar)
            {
                case ETypeControls.eAdjacencyMatrixInput:
                    n = m_Val1;
                    n1 = m_Val1;
                    label1.Text = "матрицу смежности";
                    break;
                case ETypeControls.eEdgeListInput:
                    label1.Text = "список ребер";
                    n = m_Val1;
                    n1 = m_Val2;
                    break;
                case ETypeControls.eIncidenceMatrixInput:
                    label1.Text = "матрицу инцедентности";
                    n = m_Val1;
                    n1 = m_Val2;
                    break;
            }
            //текущий вариант
            int var = (int)currentVar;
            m_algo.create_mas(n, n1, var);

            ds.Tables.Clear();
            ds.Tables.Add("matriza");

            //Здесь просто заполняем созданную сетку нулями
            if (currentVar == ETypeControls.eEdgeListInput)
            {
                for (int i = 0; i < 2; i++)
                {
                    ds.Tables[0].Columns.Add(String.Format("Вершина {0}", (i + 1)));
                  
                }
                for (int i = 0; i < n1; i++)
                {
                    ds.Tables[0].Rows.Add(m_algo.FillTable(m_algo.mas, i));
                }
            }
            else
            {
                for (int i = 0; i < n1; i++)
                {
                    ds.Tables[0].Columns.Add((i + 1).ToString());
                }
                for (int i = 0; i < n; i++)
                {
                    ds.Tables[0].Rows.Add(m_algo.FillTable(m_algo.mas, i));
                }
            }
           
            setka.DataSource = ds.Tables[0];
            setka.Show();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.LoadStartPage();
            }
        }

        enum CurrentVarToView 
        {
            eAdjacencyMatrixBtn,//матрица смежности
            eIncidenceMatrixBtn,//матрица инцедентности
            eEdgeListInputBtn//список ребер
        }


        private CurrentVarToView m_CheckedVar; //выбранный вариант для отображения

        /// <summary>
        /// Метод проверяет все условия по классам эквивалентности и
        /// в случае ошибки выводит её пользователю
        /// </summary>
        void ValidateAllAndRun()
        {
            Boolean flaggy = Check() || CheckIntsedentMatrix();


            if (!flaggy)
            {
                switch (m_CheckedVar)
                {
                    case CurrentVarToView.eAdjacencyMatrixBtn: //матрица смежности
                        m_algo.DoSmez(TextBox);
                        break;
                    case CurrentVarToView.eIncidenceMatrixBtn://матрица инцедентности
                        m_algo.DoInt(TextBox);
                        break;
                    case CurrentVarToView.eEdgeListInputBtn: //список ребер
                        m_algo.DoLinks(TextBox);
                        break;
                }

             
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }

        /// <summary>
        /// матрица инцедентности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            m_CheckedVar = CurrentVarToView.eIncidenceMatrixBtn;
            ValidateAllAndRun();
        }

        private bool CheckIntsedentMatrix()
        {
            if ((m_algo.m_buildingType == (int)ETypeControls.eIncidenceMatrixInput) && !m_algo.Check(m_algo.mas, 2)) ///Check //!CheckRibbons()
            {
                MessageBox.Show("Ошибка Ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false; 
        }

        /// <summary>
        /// список ребер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setkaOK_Click(object sender, EventArgs e)
        {
            m_CheckedVar = CurrentVarToView.eEdgeListInputBtn;
            ValidateAllAndRun();
        }

        //Проверка правильности введенных данных
        private bool Check()
        {
           Boolean flaggy = false;

            TextBox.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                int nnn = 0;
                var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);
                if (isNumeric) //если число
                {
                    m_algo.mas[i, j] = Convert.ToInt32(ds.Tables[0].Rows[i][j]);

                    if (((m_algo.m_buildingType == 3) && (m_algo.mas[i, j] > m_algo.m_VertexCnt))
                        || ((m_algo.m_buildingType == 3) && (m_algo.mas[i, j] < 1))
                        || ((m_algo.m_buildingType == 1) && (m_algo.mas[i, j] > 1))
                        || ((m_algo.m_buildingType == 1) && (m_algo.mas[i, j] < 0))
                        || ((m_algo.m_buildingType == 2) && (m_algo.mas[i, j] > 1))
                        || ((m_algo.m_buildingType == 2) && (m_algo.mas[i, j] < 0)
                        || (m_algo.m_buildingType == 1) && !CheckAndValidate())
                        )
                        {
                        MessageBox.Show("Ошибка Ввода","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                       // flaggy = true;
                            return true;
                       // break;
                    }
                }
                else //если не число - выводим сообщение
                {
                    MessageBox.Show("Ошибка Ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // flaggy = true;
                    return true;
                   // break;
                }
            }
            return flaggy;
        }

        private bool CheckAndValidate()
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                int nnn = 0;
                var isNumeric = int.TryParse(Convert.ToString(ds.Tables[0].Rows[i][j]), out nnn);

                int nnn1 = 0;
                var isNumeric1 = int.TryParse(Convert.ToString(ds.Tables[0].Rows[j][i]), out nnn1);

               
                if (nnn != nnn1 || (i == j && nnn != 0))
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// матрица смежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
           m_CheckedVar = CurrentVarToView.eAdjacencyMatrixBtn;
           ValidateAllAndRun();
        }

        private void setka_KeyDown(object sender, EventArgs e)
        {
            //if (sender is DataGridView dataGrid)
            //{
            //    if (m_algo.m_buildingType != 3)
            //    {
            //         Check();
            //    }
               
            //}
           
           
        }
    }
}
