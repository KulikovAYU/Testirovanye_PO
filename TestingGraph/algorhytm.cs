using System;
using System.Collections.Generic;

namespace TestingGraph
{
    public interface ICounter
    {
        int CountUnits(int[,] Arr, int j, ETypeControls buildingType, int vertexCnt);
    }

    //конкретный класс счетчика кол-ва единиц в определенной строке массива
    public class ConcreteCounterOfUnits : ICounter
    {
        /// <summary>
        /// Метод подсчитывает кол-во единиц в определенной строке массива
        /// </summary>
        /// <param name="Arr">Входной массив</param>
        /// <param name="j">номер строки</param>
        /// <param name="buildingType">тип построения матрицы</param>
        /// <param name="vertexCnt">кол-во вершин</param>
        /// <returns>кол-во единиц в j строке</returns>
        public int CountUnits(int[,] Arr, int j, ETypeControls buildingType, int vertexCnt)
        {
            int count = 0;                                                      //1
            if (buildingType != ETypeControls.eEdgeListInput) //2
            {

                for (int i = 0; i < vertexCnt; i++)                             //3
                {
                    if (Arr[j, i].ToString().Equals("1"))                       //4
                        count++;                                                //5
                }                                                               //6-к.ц.
            }
            return count;                                                       //7
        }
    }

    public class algorhytm
    {
        private ICounter m_Counter;
        public algorhytm(ICounter counter = null)
        {
            if (counter == null)
            {
                m_Counter = new ConcreteCounterOfUnits();
            }
            else
            {
                m_Counter = counter;
            }
            
        }
        public int[,] mas;
        // mas[i][j] - максимальная величина потока, способная течь по ребру (i,j) or матрица хранящая граф

        public int m_VertexCnt; //количество вершин графа
        public int m_ribsCnt; //количество ребер графа
        public string al = string.Empty;
        public int m_buildingType = (int) ETypeControls.eEdgeListInput; //вариант построения

       


        public virtual void create_mas(int n, int n1, int n3)
        {

             mas = (ETypeControls) n3 == ETypeControls.eEdgeListInput ? new int[n1, 2] : new int[n, n1];

            //Матрица смежности
            //var arr1 = new[,] {{0, 1, 0, 1}, {1, 0, 1, 1}, {1, 1, 1, 1}, {1, 1, 0, 0}};
            var arr2_true = new[,] {{0, 1, 1, 1}, {1, 0, 1, 0}, {1, 1, 0, 1}, {1, 0, 1, 0}};//правильный
         

            //Матрица инцедентности
            // var arr2_ints_true = new[,] {{1, 1, 1, 0, 0}, {1, 0, 0, 1, 0}, {0, 1, 0, 1, 1}, {0, 0, 1, 0, 1}};//правильный

           // mas = (ETypeControls)n3 == ETypeControls.eEdgeListInput ? new int[n1, 2] : arr2_ints_true;
            m_VertexCnt = n;
            m_ribsCnt = n1;
            m_buildingType = n3;
        }

       public virtual int[] RetRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
        {
            int[] mas1 = null; //1
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //2
            {
               mas1 = new int[2];  //3
                for (int i = 0; i < 2; i++) //4
                {
                    mas1[i] = Arr[j, i];//5
                }//6 -к.ц.
            }
            else
            {
               mas1 = new int[m_ribsCnt]; //7
                for (int i = 0; i < m_ribsCnt; i++) //8
                {
                    mas1[i] = Arr[j, i]; //9
                }   //10 - к.ц.
            }

            return mas1; //11
        }

        //заполняет массив нулями
        public virtual string[] FillTable(int[,] Arr, int j)
        {
            string[] mas1 = null; //1
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //2
            {
                mas1 = new string[2];  //3
                for (int i = 0; i < 2; i++) //4
                {
                    mas1[i] = Arr[j, i].ToString();//5
                }//6 -к.ц.
            }
            else
            {
                mas1 = new string[m_ribsCnt]; //7
                for (int i = 0; i < m_ribsCnt; i++) //8
                {
                    mas1[i] = Arr[j, i].ToString(); //9
                }   //10 - к.ц.
            }

            return mas1; //11
        }

        /// <summary>
        /// Метод подсчитывает кол-во единиц в определенной строке массива
        /// </summary>
        /// <param name="Arr">Входной массив</param>
        /// <param name="j">номер строки</param>
        /// <param name="buildingType">тип построения матрицы</param>
        /// <param name="vertexCnt">кол-во вершин</param>
        /// <returns>кол-во единиц в j строке</returns>
        public int CountUnits(int[,] Arr, int j, ETypeControls buildingType,int vertexCnt)
        {
            return m_Counter.CountUnits(Arr, j, buildingType, vertexCnt);
        }



        /// <summary>
        /// Метод проверяет корректность введенных данных в матрицу инцедентности
        /// </summary>
        /// <param name="Arr">Массив</param>
        /// <param name="number">требуемое кол-во вершин</param>
        /// <returns>если данные верны = true</returns>
        public virtual bool Check(int[,] Arr, int number)
        {
            int result = 0;

            bool flag = false;

            int lim = Arr.GetLength(0);
            int lim2 = Arr.GetLength(1);

            for (int i = 0; i < lim2; i++)
            {
                int[,] mass = new int[1, lim];
                for (int j = 0; j < lim; j++)
                {
                    mass[0, j] = Arr[j, i];
                }
                
                // m_ribsCnt = mass.Length;
                m_VertexCnt = mass.Length;
                m_buildingType = (int)ETypeControls.eIncidenceMatrixInput;
                
                int temp = CountUnits(mass, 0, ETypeControls.eIncidenceMatrixInput, mass.Length);

                if (temp != number)
                {
                    return false;
                }

                //result += temp;
                //else return false;
            }
            //return result == number;

            return true;
        }

        public virtual void DoLinks(System.Windows.Forms.RichTextBox TextBox)
        {
            TextBox.Clear();
            TextBox.AppendText(" Список ребер графа:\n");
            TextBox.AppendText("\n");

            if ((ETypeControls)m_buildingType == ETypeControls.eAdjacencyMatrixInput) // если по матрице смежности
            {
                int[,] masCopy = new int[m_VertexCnt, m_VertexCnt];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_VertexCnt; j++)
                        masCopy[i, j] = mas[i, j];

                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_VertexCnt; j++)
                    {
                        if (masCopy[i, j] != 0)
                        {
                            TextBox.AppendText("Вершина " + (i + 1).ToString() + " - " + "Вершина " + (j + 1).ToString() + "\n");
                            masCopy[i, j] = 0;
                            masCopy[j, i] = 0;
                        }
                    }
            }
            if ((ETypeControls)m_buildingType == ETypeControls.eIncidenceMatrixInput) // если по матрице инцидентности 
            {
                int[,] masCopy = new int[m_VertexCnt, m_ribsCnt];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_ribsCnt; j++)
                        masCopy[i, j] = mas[i, j];

                for (int i = 0; i < m_ribsCnt; i++)
                {
                    int flag = 0;
                    for (int j = 0; j < m_VertexCnt; j++)
                    {
                        if (masCopy[j, i] != 0 && flag == 0)
                        {
                            TextBox.AppendText("Вершина " + (j + 1).ToString() + " - ");
                            flag = 1;
                        }
                        else
                        {
                            if (masCopy[j, i] != 0 && flag == 1)
                            {
                                TextBox.AppendText("Вершина " + (j + 1).ToString() + "\n");
                            }
                        }
                    }
                }
            }
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //если по списку ребер 
            {
                for (int i = 0; i < m_ribsCnt; i++)
                    TextBox.AppendText("Вершина " + mas[i, 0] + " - " + "Вершина " + mas[i, 1] + "\n");
            }
        }

        public virtual void DoSmez(System.Windows.Forms.RichTextBox TextBox)
        {
            TextBox.Clear();
            TextBox.AppendText(" Матрица смежности графа:\n");

            if ((ETypeControls)m_buildingType == ETypeControls.eAdjacencyMatrixInput) // если по матрице смежности
            {
                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < m_VertexCnt; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < m_VertexCnt; j++)
                    {
                        TextBox.AppendText(" " + mas[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
            if ((ETypeControls)m_buildingType == ETypeControls.eIncidenceMatrixInput) // если по матрице инцидентности 
            {
                int[,] masCopy = new int[m_VertexCnt, m_VertexCnt];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_VertexCnt; j++)
                        masCopy[i, j] = 0;
                for (int i = 0; i < m_ribsCnt; i++)
                {
                    int flag = 0;
                    int f = -1;
                    int f1 = -1;
                    for (int j = 0; j < m_VertexCnt; j++)
                    {

                        if (mas[j, i] != 0 && flag == 0)
                        {
                            f = j;
                            flag = 1;
                        }
                        else
                        {
                            if (mas[j, i] != 0 && flag == 1)
                            {
                                f1 = j;
                            }
                        }

                    }
                    if (f != -1 && f1 != -1) masCopy[f, f1] = 1;
                }

                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < m_VertexCnt; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < m_VertexCnt; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }

            }

            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //если по списку ребер 
            {
                int[,] masCopy = new int[m_VertexCnt, m_VertexCnt];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_VertexCnt; j++)
                        masCopy[i, j] = 0;
                for (int i = 0; i < m_ribsCnt; i++)
                {
                    masCopy[mas[i, 0] - 1, mas[i, 1] - 1] = 1;
                    masCopy[mas[i, 1] - 1, mas[i, 0] - 1] = 1;
                }

                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < m_VertexCnt; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < m_VertexCnt; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
        }

        public virtual void DoInt(System.Windows.Forms.RichTextBox TextBox)
        {
            TextBox.Clear();
            TextBox.AppendText(" Матрица инцидентности графа:\n");
            if ((ETypeControls)m_buildingType == ETypeControls.eAdjacencyMatrixInput) // если по матрице смежности
            {
                int count = 0;

                //подсчитаем кол-во дуг
                int[,] _masCopy = new int[m_VertexCnt, m_VertexCnt];
                Array.Copy(mas, _masCopy, mas.Length);
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_VertexCnt; j++)
                        if (_masCopy[i, j] != 0 && i != j)
                        {
                            count++;//количество дуг
                            _masCopy[j, i] = 0; //дабы не попадать дважды в одну и ту же вершину (по внешнему циклу, зануляем)
                        }

                //создаем м-цу инцедентности [кол-во вершин, кол-во ребер]
                int[,] masIntsedent = new int[m_VertexCnt, count];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < count; j++)
                        masIntsedent[i, j] = 0;

                int flag = 0;
                //заполняем м-цу инцедентнотси
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    for (int j = 0; j < m_ribsCnt; j++)
                    {
                        if (mas[i, j] != 0 && i != j)
                        {
                            mas[i, j] = 0;
                            mas[j, i] = 0;
                            masIntsedent[i, flag] = 1;
                            masIntsedent[j, flag] = 1;
                            flag++;
                        }
                    }
                }
                //Далее вывод на экран
                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < count; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < count; j++)
                    {
                        TextBox.AppendText(" " + masIntsedent[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
            if ((ETypeControls)m_buildingType == ETypeControls.eIncidenceMatrixInput) // если по матрице инцидентности 
            {
                //т.к. был выбран вариант построения по матрице инцедентности и нажата кнопка по м-це инценентнотси, то просто
                //выводим м-цу на экран
                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < m_ribsCnt; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < m_ribsCnt; j++)
                    {
                        TextBox.AppendText(" " + mas[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //если список ребер 
            {
               
                int[,] masCopy = new int[m_VertexCnt, m_ribsCnt];
                for (int i = 0; i < m_VertexCnt; i++)
                    for (int j = 0; j < m_ribsCnt; j++)
                        masCopy[i, j] = 0;

                for (int i = 0; i < m_ribsCnt; i++)
                {
                    masCopy[mas[i, 0] - 1, i] = 1;
                    masCopy[mas[i, 1] - 1, i] = 1;
                }

                TextBox.AppendText("\n");
                TextBox.AppendText("     ");
                for (int i = 0; i < m_ribsCnt; i++) TextBox.AppendText((i + 1) + " ");
                TextBox.AppendText("\n");
                for (int i = 0; i < m_VertexCnt; i++)
                {
                    TextBox.AppendText(" " + (i + 1) + " ");
                    for (int j = 0; j < m_ribsCnt; j++)
                    {
                        TextBox.AppendText(" " + masCopy[i, j]);
                    }
                    TextBox.AppendText("\n");
                }
            }
        }
    }
}