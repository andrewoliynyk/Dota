﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorSimulator.Abstract;
using ElevatorSimulator.Models;

namespace ElevatorSimulator.Concrete.Managers
{
    class QueueManager: Manager, IQueue
    {
        private readonly List<Floor> floors;

        public QueueManager(IDispatcher dispatcher, List<Floor> floors) : base(dispatcher) => this.floors = floors;

        private void AddToQueue(Passenger passenger)
        {
            if (passenger.Direction == States.Direction.Down)
            {
                floors[passenger.CurrentFloorIndex].GoingDownPassengerQueue.Add(passenger);
            }
            else
            {
                floors[passenger.CurrentFloorIndex].GoingUpPassengerQueue.Add(passenger);
            }
        }

        private void RemoveFromQueue(Passenger passenger)
        {
            if (passenger.Direction == States.Direction.Down)
            {
                floors[passenger.CurrentFloorIndex].GoingDownPassengerQueue.Remove(passenger);
            }
            else
            {
                floors[passenger.CurrentFloorIndex].GoingUpPassengerQueue.Remove(passenger);
            }
        }

        public void WorkWithQueue(Passenger passenger)
        {
            if (floors[passenger.CurrentFloorIndex].GoingUpPassengerQueue.Contains(passenger) ||
                floors[passenger.CurrentFloorIndex].GoingDownPassengerQueue.Contains(passenger))
            {
                RemoveFromQueue(passenger);
            }
            else
            {
                AddToQueue(passenger);
            }
        }

        public override object GetItem(States.Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
