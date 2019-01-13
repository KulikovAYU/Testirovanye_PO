using System;
using System.Data;
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
                    ds.Tables[0].Rows.Add(m_algo.RetRow(m_algo.mas, i));
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
                    ds.Tables[0].Rows.Add(m_algo.RetRow(m_algo.mas, i));
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

        /// <summary>
        /// Инцедентности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Boolean flaggy = Check();
            
            if (!flaggy)
            {
                m_algo.DoInt(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }

        /// <summary>
        /// Ребра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setkaOK_Click(object sender, EventArgs e)
        {
            var flaggy = Check();
            if (!flaggy)
            {
                m_algo.DoLinks(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
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
                        || ((m_algo.m_buildingType == 2) && (m_algo.mas[i, j] < 0)))
                    {
                        MessageBox.Show("Ошибка Ввода","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        flaggy = true;
                        break;
                    }
                }
                else //если не число - выводим сообщение
                {
                    MessageBox.Show("Ошибка Ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flaggy = true;
                    break;
                }
            }
            return flaggy;
        }

        /// <summary>
        /// Смежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var flaggy = Check();
            if (!flaggy)
            {
                m_algo.DoSmez(TextBox);
                TextBox.Show();
                setka.Hide();
                Reset.Show();
            }
        }
    }
}
