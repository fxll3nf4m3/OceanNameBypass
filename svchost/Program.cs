using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // ааа злые программы
        string[] partialNames = { "Ocean", "cmd", "Terminal" }; // чюваки суда крч засовываете названия злых прог

        // весь код ниже в словах: ищет, убивает/не находит, повторяет
        while (true)
        {
            var processes = Process.GetProcesses()
                                   .Where(p => partialNames.Any(name => p.ProcessName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0))
                                   .ToList();

            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                }
            }

            // задержка перед новой проверкой на программы с названиями выше (1000=1 сек)
            Thread.Sleep(100);
        }
    }
}
