﻿using ElevatorSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Abstract
{
    public interface IQueueManager
    {
        void AddToQueue(Passenger passenger);
        void RemoveFromQueue(Passenger passenger);
    }
}
