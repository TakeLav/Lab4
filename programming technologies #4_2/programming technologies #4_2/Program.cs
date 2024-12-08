// Responsibility chain

using System;

abstract class Handler
{
	protected Handler nextHandler;

	public void SetNext(Handler handler)
	{
		nextHandler = handler;
	}

	public abstract void HandleRequest(int request);
}

class ConcreteHandlerA : Handler
{
	public override void HandleRequest(int request)
	{
		if (request >= 0 && request < 10)
		{
			Console.WriteLine("Handler A обработал запрос " + request);
		}
		else if (nextHandler != null)
		{
			nextHandler.HandleRequest(request);
		}
	}
}

class ConcreteHandlerB : Handler
{
	public override void HandleRequest(int request)
	{
		if (request >= 10 && request < 20)
		{
			Console.WriteLine("Handler B обработал запрос " + request);
		}
		else if (nextHandler != null)
		{
			nextHandler.HandleRequest(request);
		}
	}
}

class ConcreteHandlerC : Handler
{
	public override void HandleRequest(int request)
	{
		if (request >= 20)
		{
			Console.WriteLine("Handler C обработал запрос " + request);
		}
		else if (nextHandler != null)
		{
			nextHandler.HandleRequest(request);
		}
	}
}

class Client
{
	static void Main()
	{
		Handler handlerA = new ConcreteHandlerA();
		Handler handlerB = new ConcreteHandlerB();
		Handler handlerC = new ConcreteHandlerC();

		handlerA.SetNext(handlerB);
		handlerB.SetNext(handlerC);

		handlerA.HandleRequest(5);
		handlerA.HandleRequest(15);
		handlerA.HandleRequest(25);
		handlerA.HandleRequest(30);
	}
}
