using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCtl.Domain.Entity;

namespace SmartCtl.Domain
{
    public static class Extensions
    {
        public static double CapacityToGB(this string capacity)
        {
            string _rawNum = capacity.Substring(0, capacity.Length - 1);
            switch (capacity.Last())
            {
                case 'T':
                    return double.Parse(_rawNum) * 1000;
                    break;
                case 'G':
                    return double.Parse(_rawNum);

            }

            return -1;
        }
        public static async Task PooledInvokeAsync(this IEnumerable<Func<Task>> taskFactories, int maxDegreeOfParallelism)
        {
            if (taskFactories == null) throw new ArgumentNullException(nameof(taskFactories));
            if (maxDegreeOfParallelism <= 0) throw new ArgumentException(nameof(maxDegreeOfParallelism));

            Func<Task>[] queue = taskFactories.ToArray();

            if (queue.Length == 0)
            {
                return;
            }

            List<Task> tasksInFlight = new List<Task>(maxDegreeOfParallelism);
            int index = 0;

            do
            {
                while (tasksInFlight.Count < maxDegreeOfParallelism && index < queue.Length)
                {
                    Func<Task> taskFactory = queue[index++];

                    tasksInFlight.Add(Task.Run(() => taskFactory()));
                }

                Task completedTask = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
                await completedTask.ConfigureAwait(false);
                tasksInFlight.Remove(completedTask);
            }
            while (index < queue.Length || tasksInFlight.Count != 0);
        }
    }
}
