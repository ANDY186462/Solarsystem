using System;
using System.Timers;

namespace SpaceLib
{
    public class Simulation
    {
        public delegate void TickHandler(double time);

        public event TickHandler DoTick;

        private System.Timers.Timer timer;
        private double time = 0;
        private double speed = 1;

        public Simulation()
        {
            timer = new System.Timers.Timer(40); 
            timer = new System.Timers.Timer(16); // about 60 FPS
            timer.Elapsed += TimerTick;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void IncreaseSpeed()
        {
            speed *= 2;
        }

        public void DecreaseSpeed()
        {
            speed /= 2;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            time += speed;

            DoTick?.Invoke(time);
        }
    }
}