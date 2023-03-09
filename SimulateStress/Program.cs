
using System.Diagnostics;

ConsumeCPU(int.Parse(args.FirstOrDefault() ?? "60"));

static void ConsumeCPU(int percentage)
{
    if (percentage is < 0 or > 100)
        throw new ArgumentException("percentage");
    
    var watch = new Stopwatch();
    watch.Start();
    while (true)
    {
        // Make the loop go on for "percentage" milliseconds then sleep the 
        // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
        if (watch.ElapsedMilliseconds <= percentage) continue;
        
        Thread.Sleep(100 - percentage);
        watch.Reset();
        watch.Start();
    }
}
