// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using Console_DependencyInyection;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {

        var serviceProvider = new ServiceCollection()
            .AddTransient<ITransient, TransientOperation>()
            .AddScoped<IScoped, ScopedOperation>()
            .AddSingleton<ISingleton, SingletonOperation>()
            .BuildServiceProvider();


        Console.WriteLine("========== Request 1 ============");
        serviceProvider.GetService<ITransient>().Info();
        serviceProvider.GetService<IScoped>().Info();
        serviceProvider.GetService<ISingleton>().Info();
        Console.WriteLine("========== ========= ============");

        Console.WriteLine("========== Request 2 ============");
        serviceProvider.GetService<ITransient>().Info();
        serviceProvider.GetService<IScoped>().Info();
        serviceProvider.GetService<ISingleton>().Info();
        Console.WriteLine("========== ========= ============");


        using (var scope = serviceProvider.CreateScope())
        {
            Console.WriteLine("========== Request 3 ============");
            scope.ServiceProvider.GetService<IScoped>().Info();
            scope.ServiceProvider.GetService<ITransient>().Info();
            scope.ServiceProvider.GetService<ISingleton>().Info();
            Console.WriteLine("========== ========= ============");

            Console.WriteLine("========== Request 4 ============");
            scope.ServiceProvider.GetService<IScoped>().Info();
            scope.ServiceProvider.GetService<ISingleton>().Info();
            Console.WriteLine("========== ========= ============");
        }

        using (var scope = serviceProvider.CreateScope())
        {
            Console.WriteLine("========== Request 5 ============");
            scope.ServiceProvider.GetService<IScoped>().Info();
            scope.ServiceProvider.GetService<ISingleton>().Info();
            Console.WriteLine("========== ========= ============");
        }


        Console.WriteLine("========== Request 6 ============");
        serviceProvider.GetService<IScoped>().Info();
        Console.WriteLine("========== ========= ============");

        Console.ReadKey();
    }


}