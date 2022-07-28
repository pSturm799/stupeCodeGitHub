using System;

namespace DependencyInjection
{
    public class RunFunction : IRunFunction
    {
        private readonly IManager _manager;

        /// <summary>
        /// </summary>
        public RunFunction(IManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public void Run()
        {
            var results = _manager.Load();
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}