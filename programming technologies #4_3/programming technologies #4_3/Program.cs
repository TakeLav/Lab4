// Iterator

using System;
using System.Collections.Generic;

// Интерфейс итератора
public interface IIterator<T>
{
	T Next();
	bool HasNext();
}

// Интерфейс коллекции
public interface ICollection<T>
{
	IIterator<T> CreateIterator();
}

// Конкретная коллекция
public class ConcreteCollection<T> : ICollection<T>
{
	private List<T> items = new List<T>();

	public void Add(T item)
	{
		items.Add(item);
	}

	public IIterator<T> CreateIterator()
	{
		return new ConcreteIterator<T>(this);
	}

	public int Count => items.Count;

	public T GetItem(int index)
	{
		return items[index];
	}
}

// Конкретный итератор
public class ConcreteIterator<T> : IIterator<T>
{
	private ConcreteCollection<T> collection;
	private int current = 0;

	public ConcreteIterator(ConcreteCollection<T> collection)
	{
		this.collection = collection;
	}

	public T Next()
	{
		return collection.GetItem(current++);
	}

	public bool HasNext()
	{
		return current < collection.Count;
	}
}

// Клиент
class Program
{
	static void Main()
	{
		ConcreteCollection<string> collection = new ConcreteCollection<string>();
		collection.Add("Элемент 1");
		collection.Add("Элемент 2");
		collection.Add("Элемент 3");

		IIterator<string> iterator = collection.CreateIterator();

		while (iterator.HasNext())
		{
			string item = iterator.Next();
			Console.WriteLine(item);
		}
	}
}