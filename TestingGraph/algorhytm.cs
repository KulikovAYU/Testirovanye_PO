using System;

namespace TestingGraph
{
    public class algorhytm
    {

        public int[,] mas;
        // mas[i][j] - максимальная величина потока, способная течь по ребру (i,j) or матрица хранящая граф

        public int m_VertexCnt; //количество вершин графа
        public int m_ribsCnt; //количество ребер графа
        public string al = string.Empty;
        public int m_buildingType = (int) ETypeControls.eEdgeListInput; //вариант построения


        public virtual void create_mas(int n, int n1, int n3)
        {
            mas = (ETypeControls) n3 == ETypeControls.eEdgeListInput ? new int[n1, 2] : new int[n, n1];

            m_VertexCnt = n;
            m_ribsCnt = n1;
            m_buildingType = n3;
        }

        public virtual string Bulid(int[,] massy, int leny)
        {

            string result = "";
            int[,] masCopy = new int[leny, leny];
            for (int i = 0; i < leny; i++)
            {
                for (int j = 0; j < leny; j++)
                {
                    masCopy[i, j] = massy[i, j];
                }
            }
            string[] a1 = RetRow(massy, 1);
            result = result + al;
            return result;

        }

        public virtual string[] RetRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
        {
            string[] mas1 = null; //1
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput && Arr != null && Arr.Length != 0) //2
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

        public virtual int CountUnits(int[,] Arr, int j) //подсчет единиц 
        {
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //1
            {
                int count = 0;                                                 //2
                for (int i = 0; i < 2; i++)                                    //3
                {
                    if (Arr[j, i].ToString().Equals("1"))                      //4
                        count++;                                               //5
                }                                                              //6-к.ц.
                return count;                                                  //7
            }
            else
            {
                int count = 0;                                                  //8
                for (int i = 0; i < m_ribsCnt; i++)                             //9
                {
                    if (Arr[j, i].ToString().Equals("1"))                       //10
                        count++;                                                //11
                }                                                               //12-к.ц.
                return count;                                                   //7
            }
        }


        public virtual bool Check(int[,] Arr, int number)
        {
            int result = 0;
            int lim = Arr.GetLength(0);
            int lim2 = Arr.GetLength(1);

            for (int i = 0; i < lim2; i++)
            {
                int[,] mass = new int[1, lim];
                for (int j = 0; j < lim; j++)
                {
                    mass[0, j] = Arr[j, i];
                }
                m_ribsCnt = mass.Length;
                m_buildingType = (int)ETypeControls.eIncidenceMatrixInput;
                int temp = CountUnits(mass, 0);
                if (temp == 2 || temp == 0)
                    result += temp;
                else return false;
            }
            return result == number;
        }

        public string Вulid(int[,] massy, int leny)
        {
            if (leny == 1) al = "1111"; if (leny == 2) al = "1010"; if (leny == 3) al = "";

            string result = string.Empty;
            int[,] masCopy = new int[leny, leny];
            for (int i = 0; i < leny; i++)
            {
                for (int j = 0; j < leny; j++)
                {
                    masCopy[i, j] = massy[i, j];
                }
            }
            string[] a1 = RetRow(massy, 1);
            result = result + al;
            return result;
        }

        //public virtual string[] RеtRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
        //{
        //    string[] mas1 = null;//1
        //    if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput) //2
        //    {
        //       mas1 = new string[2];//3
        //        for (int i = 0; i < 2; i++)//4
        //        {
        //            mas1[i] = Arr[j, i].ToString();//5
        //        }//6 -к.ц.
        //    }
        //    else
        //    {
        //        mas1 = new string[m_ribsCnt];//7
        //        for (int i = 0; i < m_ribsCnt; i++)//8
        //        {
        //            mas1[i] = Arr[j, i].ToString();//9
        //        }//10-к.ц.
        //    }
        //    return mas1;//11
        //}


        public virtual string[] RеtRow(int[,] Arr, int j) //возращает строку с индексом j из массива Arr
        {
            if ((ETypeControls)m_buildingType == ETypeControls.eEdgeListInput)
            {
                string[] mas1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }

                return mas1;
            }
            else
            {
                string[] mas1 = new string[m_ribsCnt];
                for (int i = 0; i < m_ribsCnt; i++)
                {
                    mas1[i] = Arr[j, i].ToString();
                }

                return mas1;
            }

        }

        public virtual void DoLinks(System.Windows.Forms.RichTextBox TextBox)
        {
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