using System;

namespace CodeRadio.Services;

public class TimerService
{
	public TimerService()
	{
	}

	public static async void AddTimer(TimeSpan interval, Action action, CancellationToken? ct = null)
	{
        long stage1Delay = 20;
        long stage2Delay = 5 * TimeSpan.TicksPerMillisecond;
        bool USE_SLEEP0 = false;

        DateTime target = DateTime.Now + new TimeSpan(0, 0, 0, 0, (int)stage1Delay + 2);
        bool warmup = true;
        while (true)
        {
            // Getting closer to 'target' - Lets do the less precise but least cpu intesive wait
            var timeLeft = target - DateTime.Now;
            if (timeLeft.TotalMilliseconds >= stage1Delay)
            {
                try
                {
                    await Task.Delay((int)(timeLeft.TotalMilliseconds - stage1Delay), ct ?? CancellationToken.None);
                }
                catch (TaskCanceledException) when (ct != null)
                {
                    return;
                }
            }

            // Getting closer to 'target' - Lets do the semi-precise but mild cpu intesive wait - Task.Yield()
            while (DateTime.Now < target - new TimeSpan(stage2Delay))
            {
                await Task.Yield();
            }

            // Getting closer to 'target' - Lets do the semi-precise but mild cpu intensive wait - Thread.Sleep(0)
            // Note: Thread.Sleep(0) is removed below because it is sometimes looked down on and also said not good to mix 'Thread.Sleep(0)' with Tasks.
            //       However, Thread.Sleep(0) does have a quicker and more reliable turn around time then Task.Yield() so to 
            //       make up for this a longer (and more expensive) Thread.SpinWait(1) would be needed.
            if (USE_SLEEP0)
            {
                while (DateTime.Now < target - new TimeSpan(stage2Delay / 8))
                {
                    Thread.Sleep(0);
                }
            }

            // Extreamlly close to 'target' - Lets do the most precise but very cpu/battery intesive 
            while (DateTime.Now < target)
            {
                Thread.SpinWait(64);
            }

            if (!warmup)
            {
                await Task.Run(action); // or your code here
                target += interval;
            }
            else
            {
                long start1 = DateTime.Now.Ticks + ((long)interval.TotalMilliseconds * TimeSpan.TicksPerMillisecond);
                long alignVal = start1 - (start1 % ((long)interval.TotalMilliseconds * TimeSpan.TicksPerMillisecond));
                target = new DateTime(alignVal);
                warmup = false;
            }
        }
    }
}

