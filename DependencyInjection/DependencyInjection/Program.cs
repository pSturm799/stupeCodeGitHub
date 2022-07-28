using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //// anstatt den Objektbaum manuell zu erstellen...
            ////var parser = new Parser();
            ////var repository = new Repository(parser);
            ////var transformator = new Transformator();
            ////var manager = new Manager(repository, transformator);

            // ... erfolgt die Erstellung hier nur 1x für das gesamte Projekt. 
            IServiceCollection service = new ServiceCollection();
            service.AddSingleton<IParser, Parser>();
            service.AddSingleton<IRepository, Repository>();
            service.AddSingleton<ITransformator, Transformator>();
            service.AddSingleton<IManager, Manager>();

            var serviceProvider = service.BuildServiceProvider();
            var manager = (IManager)serviceProvider.GetService(typeof(IManager));


            var results = manager.Load();
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }


    public interface IManager
    {
        string[] Load();
    }

    public class Manager : IManager
    {
        private readonly IRepository _repository;
        private readonly ITransformator _transformator;

        public Manager(IRepository repository, ITransformator transformator)
        {
            _repository = repository;
            _transformator = transformator;
        }

        public string[] Load()
        {
            var inputData = _repository.Load();
            var results = new List<string>();
            foreach (var input in inputData)
            {
                var result = _transformator.Transform(input);
                results.Add(result);
            }

            return results.ToArray();
        }
    }

    public interface ITransformator
    {
        string Transform(string input);
    }

    public class Transformator : ITransformator
    {
        public string Transform(string input)
        {
            return input.ToUpper();
        }
    }


    public interface IRepository
    {
        string[] Load();
    }

    class Repository : IRepository
    {
        private readonly IParser _parser;

        public Repository(IParser parser)
        {
            _parser = parser;
        }

        public string[] Load()
        {
            string data = "Peter,Matilda,Toni";
            string[] result = _parser.Parse(data);
            return result;
        }
    }

    public interface IParser
    {
        string[] Parse(string input);
    }

    public class Parser : IParser
    {
        public string[] Parse(string input)
        {
            var parts = input.Split(",");
            return parts;
        }
    }
}