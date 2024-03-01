
Logging logging = new();
Exception exception = new(logging.Calistir);

Authorization authorization = new(exception.Calistir);

authorization.Calistir();

Deneme deneme = DelegateDeneme.DelegatedMethod;
deneme.Invoke();


class Authorization
{
    public delegate void Run();
    private Run runDelegate;

    public Authorization(Run runDelegate)
    {
        this.runDelegate = runDelegate;
    }

    public void Calistir()
    {
        Console.WriteLine("Authorization başladı");
        //Burda ki invoke methodu delegate referansını yani fonsiyonu çalıştırır.
        runDelegate.Invoke();
        Console.WriteLine("Authorization dönüşü");

    }
}

class Exception
{
    public delegate void Run();
    private Run runDelegate;

    public Exception(Run runDelegate)
    {
        this.runDelegate = runDelegate;
    }

    public void Calistir()
    {
        Console.WriteLine("Exception  başladı");
        runDelegate.Invoke();
        Console.WriteLine("Exception  dönüşü");

    }

}

class Logging
{
    public delegate void Run();

    public void Calistir()
    {
        Console.WriteLine("Logging başladı");
        Console.WriteLine("Son");
        Console.WriteLine("Logging dönüşü");
    }

}

public static class DelegateDeneme
{
    public static void DelegatedMethod()
    {

    }
}

delegate void Deneme();