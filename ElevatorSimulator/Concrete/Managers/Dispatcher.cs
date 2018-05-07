﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElevatorSimulator.Abstract;
using ElevatorSimulator.Events;
using ElevatorSimulator.Models;
using Timer = System.Timers.Timer;

namespace ElevatorSimulator.Concrete.Managers
{
    class Dispatcher: IDispatcher
    {
        private static Dispatcher instance;
        public Manager QueueManager { get; set; }
        public Manager ElevatorManager { get; set; }
        public Manager PassengerManager { get; set; }
        
        private Timer floorChecker;

        private readonly object locker = new object();

        public static Dispatcher GetInstance()
        {
            if (instance == null)
            {
                instance = new Dispatcher();
            }
            return instance;
        }

        private Dispatcher()
        {

        }

        public void PassengerCalledElevatorEventHandler(object sender, PassengerEventArgs e)
        {
            Console.WriteLine("Passenger {0} called elevator!", e.PassengerWhoRisedAnEvent.passengerIndex);
            ThreadPool.QueueUserWorkItem(delegate { ((IQueue)QueueManager).WorkWithQueue(e.PassengerWhoRisedAnEvent); });
        }

        public void PassengerEnteredElevatorEventHandler(object sender, PassengerEventArgs e)
        {
            Console.WriteLine("Passenger {0} entered the elevator!", e.PassengerWhoRisedAnEvent.passengerIndex);
            ThreadPool.QueueUserWorkItem(delegate { ((IQueue)QueueManager).WorkWithQueue(e.PassengerWhoRisedAnEvent); });
        }

        public void PassengerReleasedElevatorEventHandler(object sender, PassengerEventArgs e)
        {
            e.PassengerWhoRisedAnEvent = null;
        }

        public void ElevatorArrivedEventHandler(object sender, ElevatorEventArgs e)
        {
        }
    }
}
