// Strategy

using System.Globalization;

public interface SortingStrategy
{
	void Solution(int[] array);
}

public class BubbleSort: SortingStrategy
{
	public void Solution(int[] array)
	{
		Console.WriteLine("Отсортировано пузырьком");
		int temp = 0;
		for (int write = 0; write < array.Length; write++)
		{
			for (int sort = 0; sort < array.Length - 1; sort++)
			{
				if (array[sort] > array[sort + 1])
				{
					temp = array[sort + 1];
					array[sort + 1] = array[sort];
					array[sort] = temp;
				}
			}
		}
		for (int i = 0; i < array.Length; i++)
			Console.Write(array[i] + " ");
		Console.ReadKey();
	}
}
public class QuickSort: SortingStrategy
{
	public void Solution(int[] array)
	{
		Console.WriteLine("Отсортировано быстрой сортировкой");
		int n = array.Length;

		for (int i = 0; i < n - 1; i++)
		{
			int minIndex = i;

			for (int j = i + 1; j < n; j++)
			{
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}

			if (minIndex != i)
			{
				int temp = array[i];
				array[i] = array[minIndex];
				array[minIndex] = temp;
			}
		}
		for (int i = 0; i < array.Length; i++)
			Console.Write(array[i] + " ");
		Console.ReadKey();
	}
}

public class Solve
{
	private SortingStrategy sortingStrategy;
    public void setStrategy(SortingStrategy sortingStrategy)
	{
		this.sortingStrategy = sortingStrategy;
	}
    public void solveEquation(int[] array)
	{
		sortingStrategy.Solution(array);
	}
}

class Program
{
	static void Main(string[] args)
	{
		Solve solve = new Solve();

		solve.setStrategy(new BubbleSort());
		int[] array1 = { 3, 4, 20, 7, 10 };
		solve.solveEquation(array1);

		solve.setStrategy(new QuickSort());
		int[] array2 = { 3, 4, 20, 7, 10 };
		solve.solveEquation(array2);

	}
}