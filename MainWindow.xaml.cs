using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Расчитать:
        private void button_Click(object sender, RoutedEventArgs e)
        {
            calc();
        }

        private void calc()
        {
            SP sp = new SP()
            {
                Thickness_SP = 0,
                Thickness_ST = 0
            };

            sp.Article = textBox.Text;
            string[] words = sp.Article.Split(new char[] { '/' });

            int a1 = 0;
            int a2 = 0;

            try
            {
                // Однокамерный СП:
                sp.Cam = 1;

                try
                {
                    words[0] = words[0].Substring(0, 2);
                    a1 += int.Parse(words[0]);
                }
                catch
                {
                    words[0] = words[0].Substring(0, 1);
                    a1 += int.Parse(words[0]);
                }

                try
                {
                    words[1] = words[1].Substring(0, 2);
                    a2 += int.Parse(words[1]);
                }
                catch
                {
                    words[1] = words[1].Substring(0, 1);
                    a2 += int.Parse(words[1]);
                }

                try
                {
                    words[2] = words[2].Substring(0, 2);
                    a1 += int.Parse(words[2]);
                }
                catch
                {
                    words[2] = words[2].Substring(0, 1);
                    a1 += int.Parse(words[2]);
                }
                sp.Thickness_ST = a1;
                sp.Thickness_SP = a2 + a1;

                // Если двухкамерный СП:
                if (words.Length == 5)
                {
                    sp.Cam = 2;

                    try
                    {
                        words[3] = words[3].Substring(0, 2);
                        a2 += int.Parse(words[3]);
                    }
                    catch
                    {
                        words[3] = words[3].Substring(0, 1);
                        a2 += int.Parse(words[3]);
                    }

                    try
                    {
                        words[4] = words[4].Substring(0, 2);
                        a1 += int.Parse(words[4]);
                    }
                    catch
                    {
                        words[4] = words[4].Substring(0, 1);
                        a1 += int.Parse(words[4]);
                    }

                    sp.Thickness_ST = a1;
                    sp.Thickness_SP = a2 + a1;

                }
                dataGrid.Items.Add(sp);     // Добавление данных в таблицу
            }
            catch
            {
                MessageBox.Show("Некорректный артикул СП");
            }
        }

        private class SP
        {
            public string Article { get; set; }     // Артикул СП
            public int Cam { get; set; }            // Камерность
            public int Thickness_SP { get; set; }   // Толщина СП
            public int Thickness_ST { get; set; }   // Толщина стекла
        }

        // Очистить таблицу:
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Clear();
        }
    }
}
