using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class CleaningRobot : ARobot
    {
        public CleaningRobot()
        {
            // Subscribe to the DangerDetected event
            this.DangerDetected += DetectDanger;
        }

        public override void PerformTask()
        {
            if (BatteryLevel >= 10)
            {
                Console.WriteLine("The cleaning robot is vacuuming the floor.");
                DrainBattery(10);

                // Simulate a danger condition randomly
                Random rand = new Random();
                if (rand.Next(10) < 2) // 20% chance of detecting danger
                {
                    OnDangerDetected();
                }
            }
            else
            {
                Console.WriteLine("Battery too low to perform task.");
            }
        }

        protected override void OnPoweredOn()
        {
            Console.WriteLine("Cleaning robot is ready to clean.");
        }

        protected override void OnPoweredOff()
        {
            Console.WriteLine("Cleaning robot is shutting down.");
        }
    }

}
