using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_7
{
	class Sorting
	{
		/// <summary>
		/// На первом шаге в массиве находится элемент с минимальным значением, затем он меняется местами с элементом, находящемся на нулевой позиции массива(если минимальный элемент и так находится на нулевой позиции, обмен, соответственно, не производится), и затем выбывает из процесса сортировки.
		/// В следующей итерации среди оставшихся чисел находится второй по минимальности элемент, и происходит обмен местами этого элемента с элементом на первой позиции массива и тоже выбывает.
		/// Затем ищется третий по минимальности элемент, меняется позициями с третьим элементом в массиве и выбывает из сортировки, и так далее.
		/// После всех итерации получится отсортированный от минимального к максимальному значению массив.
		/// </summary>
		/// <param name="list">объект который выполняет условия интерфейса IList</param>
		/// <returns>Возвращает отсортированный список</returns>
		public static IList<int> SelectionSort(IList<int> list)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[j] < list[min])
					{
						min = j;
					}
				}
				int dummy = list[i];
				list[i] = list[min];
				list[min] = dummy;
			}
			return list;
		}

		public static IList<int> SelectionMinSort(IList<int> list)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				int min = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[j] < list[min])
					{
						min = j;
					}
				}
				int dummy = list[i];
				list[i] = list[min];
				list[min] = dummy;
			}
			return list;
		}


		/// <summary>
		/// Идея данной сортировки заключается в попарном сравнении соседних элементов, начиная с нулевого в массиве.
		/// Больший элемент при этом в конце первой итерации оказывается на месте последнего элемента массива, и в следующих итерациях мы его уже не сравниваем его с остальными элементами (то есть у нас будет n-1 сравнений).
		/// Затем таким же образом мы находим второй по максимальности элемент и ставим его на предпоследнее место, и т. д. После всех итераций получится, что на месте нулевого элемента окажется элемент с наименьшим числовым значением, а на месте последнего – с наибольшим числовым значением.
		/// Таким образом у нас как бы “всплывают” элементы от большего к меньшему.
		/// </summary>
		/// <param name="list">объект который выполняет условия интерфейса IList</param>
		/// <returns>Возвращает отсортированный список</returns>
		public static IList<int> BubbleSort(IList<int> list)
		{
			int temp;
			for (int i = 0; i < list.Count-1; i++)
			{
				for (int j = i + 1; j < list.Count-1; j++)
				{
					if (list[i] > list[j])
					{
						temp = list[i];
						list[i] = list[j];
						list[j] = temp;
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Идея сортировки методом Шелла состоит в том, чтобы сортировать элементы отстоящие друг от друга на некотором расстоянии step.
		/// Затем сортировка повторяется при меньших значениях step, и в конце процесс сортировки Шелла завершается при step = 1 (а именно обычной сортировкой вставками).
		/// </summary>
		/// <param name="list">объект который выполняет условия интерфейса IList</param>
		/// <returns>Возвращает отсортированный список</returns>
		public static IList<int> ShellSort(IList<int> list)
		{
			int i, j, step;
			int tmp;
			for (step = (list.Count-1) / 2; step > 0; step /= 2)
				for (i = step; i < (list.Count - 1); i++)
				{
					tmp = list[i];
					for (j = i; j >= step; j -= step)
					{
						if (tmp < list[j - step])
							list[j] = list[j - step];
						else
							break;
					}
					list[j] = tmp;
				}
			return list;
		}

		/// <summary>
		/// Пирамидальная сортировка (или сортировка кучей, HeapSort) — это метод сортировки сравнением, основанный на такой структуре данных как двоичная куча.
		/// Она похожа на сортировку выбором, где мы сначала ищем максимальный элемент и помещаем его в конец.
		/// Далее мы повторяем ту же операцию для оставшихся элементов.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IList<int> HeapSort(IList<int> list)
		{
			int SizeList = list.Count-1;

			// Построение кучи (перегруппируем массив)
			for (int i = SizeList / 2 - 1; i >= 0; i--)
				Heapify(list, SizeList, i);

			// Один за другим извлекаем элементы из кучи
			for (int i = SizeList - 1; i >= 0; i--)
			{
				// Перемещаем текущий корень в конец
				int temp = list[0];
				list[0] = list[i];
				list[i] = temp;

				// вызываем процедуру heapify на уменьшенной куче
				Heapify(list, i, 0);
			}
			return list;
		}

		/// <summary>
		/// Процедура для преобразования в двоичную кучу поддерева с корневым узлом i
		/// </summary>
		static void Heapify(IList<int> list, int SizeList, int i)
		{
			int largest = i;
			// Инициализируем наибольший элемент как корень
			int l = 2 * i + 1; // left = 2*i + 1
			int r = 2 * i + 2; // right = 2*i + 2

			// Если левый дочерний элемент больше корня
			if (l < SizeList && list[l] > list[largest])
				largest = l;

			// Если правый дочерний элемент больше, чем самый большой элемент на данный момент
			if (r < SizeList && list[r] > list[largest])
				largest = r;

			// Если самый большой элемент не корень
			if (largest != i)
			{
				int swap = list[i];
				list[i] = list[largest];
				list[largest] = swap;

				// Рекурсивно преобразуем в двоичную кучу затронутое поддерево
				Heapify(list, SizeList, largest);
			}
		}

		/// <summary>
		/// Отличительной особенностью быстрой сортировки является операция разбиения массива на две части относительно опорного элемента. Например, если последовательность требуется упорядочить по возрастанию, то в левую часть будут помещены все элементы, значения которых меньше значения опорного элемента, а в правую элементы, чьи значения больше или равны опорному.
		/// Вне зависимости от того, какой элемент выбран в качестве опорного, массив будет отсортирован, но все же наиболее удачным считается ситуация, когда по обеим сторонам от опорного элемента оказывается примерно равное количество элементов.
		/// Если длина какой-то из получившихся в результате разбиения частей превышает один элемент, то для нее нужно рекурсивно выполнить упорядочивание, т. е. повторно запустить алгоритм на каждом из отрезков.
		/// </summary>
		public static IList<int> QuickSort(IList<int> list, int start, int end)
		{
			if (start >= end)
			{
				return list;
			}
			int pivot = Partition(list, start, end);
			QuickSort(list, start, pivot - 1);
			QuickSort(list, pivot + 1, end);
			return list;
		}

		static int Partition(IList<int> list, int start, int end)
		{
			int marker = start;
			for (int i = start; i <= end; i++)
			{
				if (list[i] <= list[end])
				{
					int temp = list[marker]; // swap
					list[marker] = list[i];
					list[i] = temp;
					marker += 1;
				}
			}
			return marker - 1;
		}

		public static IList<int> Inversion(IList<int> list)
		{
			int i, j;
			for (i = 0,j = list.Count - 1; i < j; i++, j--)
			{
				var temp = list[i];
				list[i] = list[j];
				list[j] = temp;
			}
			return list;
		}

	}
}
