using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    using System;

    abstract class ARobot
    {
        // Protected property for battery level
        protected int BatteryLevel { get; private set; }

        // Event for detecting danger
        public event Action DangerDetected;

        // Constructor to initialize the battery level
        public ARobot()
        {
            BatteryLevel = 100; // Assume robots start fully charged
        }

        // Method to trigger the DangerDetected event
        protected void OnDangerDetected()
        {
            DangerDetected?.Invoke();
        }

        // Public method to power on the robot
        public void PowerOn()
        {
            Console.WriteLine("The robot is powered on.");
            OnPoweredOn(); // Call the virtual method
        }

        // Public method to power off the robot
        public void PowerOff()
        {
            Console.WriteLine("The robot is powered off.");
            OnPoweredOff(); // Call the virtual method
        }

        // Public method to simulate danger detection
        public void DetectDanger()
        {
            Console.WriteLine("Danger detected! The robot is shutting down.");
            PowerOff();
        }

       

        // Abstract method to perform the specific task
        public abstract void PerformTask();

        // Protected virtual methods to allow derived classes to extend behavior
        protected virtual void OnPoweredOn()
        {
            DrainBattery(1);
        }

        protected virtual void OnPoweredOff()
        {
            DrainBattery(0);
        }

        // Protected method to drain battery
        protected void DrainBattery(int amount)
        {
            BatteryLevel = Math.Max(BatteryLevel - amount, 0);
            Console.WriteLine($"Battery drained by {amount}%. Current battery level: {BatteryLevel}%.");
        }

        // Method overloading for recharging the battery
        public void Recharge()
        {
            BatteryLevel = 100;
            Console.WriteLine("The robot is fully recharged.");
        }

        public void Recharge(int amount)
        {
            BatteryLevel = Math.Min(BatteryLevel + amount, 100);
            Console.WriteLine($"The robot is recharged by {amount}%. Current battery level: {BatteryLevel}%.");
        }
    }

}
