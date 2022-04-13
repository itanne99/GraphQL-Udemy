﻿using System;
using System.Collections.Generic;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Interfaces
{
    public interface ILog
    {
        //Create
        Log CreateLog(string message);

        //Read
        List<Log> GetLogs();
        
        List<Log> GetLogs(DateTime timestamp);

        Log GetLog(int id);
    }
}