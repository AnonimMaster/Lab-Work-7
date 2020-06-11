using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Work_7
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		IList<int> Array;

		private void button1_Click(object sender, EventArgs e)
		{
			textBox2.Clear(); // освобождаем textBox2
			int n = MyLib.CorrectInput(textBox1);// получаем числовое значение из textBox1
			if (n < 1) // проверка допустимости значения, введенного пользователем
			{
				n = 1;
				// замена значения, введенного пользователем в textBox1
				textBox1.Text = String.Format("{0}", n);
			}
			SaveFileDialog sfd = new SaveFileDialog();// Создаем диалоговое окно для открытия файла
			sfd.Title = "Выберите файл для записи массива";//задаем заголовок диалогового окна
			sfd.InitialDirectory = @"array/";// задаем начальный путь для сохранения файла
										  // Создаем фильтр для отображаемых типов файлов
			sfd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";
			Random r = new Random(); //создаем объект для работы с псевдослучайными числами

			// открываем окно для сохранения файла командой sfd.ShowDialog() 
			//и проверяем, нажата ли кнопка "Сохранить" в этом окне, т.е.достигнут ли результат "ОК"
			if (sfd.ShowDialog() == DialogResult.OK)
			{// открываем файл для записи (дозапись исключена)
				using (StreamWriter sw = new StreamWriter(sfd.FileName))
				{
					for (int i = 0; i < n - 1; i++) // цикл для записи n-1 числа
						sw.WriteLine(r.Next(-500, 500));  //запись чисел в файл построчно
														  //запись одного числа в файл без символа перехода на новую строку
					sw.Write(r.Next(-500, 500));
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox2.Clear();// освобождаем textBox2
			OpenFileDialog ofd = new OpenFileDialog(); // Создаем объект диалогового окна для открытия файла
			ofd.Title = "Выберите файл с числовым массивом";//назначаем заголовок диалогового окна открытия файла
			ofd.InitialDirectory = @"array/";// начальный путь для поиска файла						  
			ofd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";// Создаем фильтр для отображаемых типов файлов
																	  // открываем окно для сохранения файла командой ofd.ShowDialog() 
																	  //и проверяем, нажата ли кнопка "Открыть" в этом окне, т.е.достигнут ли результат "ОК"
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				using (StreamReader sr = new StreamReader(ofd.FileName)) //открываем файл для чтения
				{//считываем весь текст из файла и записываем его в textBox2
					textBox2.Text = sr.ReadToEnd();
				}
				textBox6.Text = ofd.FileName;// в textBox6 записываем имя файла\
				int x;
				Array = new List<int>((textBox2.Lines).Length);
				foreach (string line in textBox2.Lines)// цикл по всем строкам в textBox2
				{
					x = Int32.Parse(line); // перевод одной строки line из textBox2 в число х
					Array.Add(x);
				}
				button8.Enabled = true;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (textBox2.Text != "")
			{
				SaveFileDialog sfd = new SaveFileDialog();// Создаем диалоговое окно для открытия файла
				sfd.Title = "Выберите файл для записи массива";//задаем заголовок диалогового окна
				sfd.InitialDirectory = @"array/";// задаем начальный путь для сохранения файла
												 // Создаем фильтр для отображаемых типов файлов
				sfd.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*";
				Random r = new Random(); //создаем объект для работы с псевдослучайными числами

				// открываем окно для сохранения файла командой sfd.ShowDialog() 
				//и проверяем, нажата ли кнопка "Сохранить" в этом окне, т.е.достигнут ли результат "ОК"
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (StreamWriter sw = new StreamWriter(sfd.FileName))
					{
						for (int i = 0; i < Array.Count - 1; i++) // цикл для записи n-1 числа
							sw.WriteLine(Array[i].ToString());
						MessageBox.Show("Сохранение прошло успешно!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			switch (comboBox1.SelectedIndex)
			{
				case 0:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
				case 1:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
				case 2:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
				case 3:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
				case 4:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
				case 5:
					MyLib.OutPutListToTextBox(Sorting.BubbleSort(Array), textBox2);
					break;
			}
			if (radioButton2.Checked)
			{
				MyLib.OutPutListToTextBox(Sorting.Inversion(Array), textBox2);	//Хорошо знаю, что сложность алгоритма вырастает. Мне просто лень.
			}
			MessageBox.Show("Массив отсортирован!", "Сортировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(textBox2.Text != "")
				button9.Enabled = true;
		}
	}
}
