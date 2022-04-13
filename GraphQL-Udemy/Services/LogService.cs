using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;

namespace GraphQL_Udemy.Services
{
    public class LogService : ILog
    {
        private GraphQLDbContext _dbContext;

        public LogService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Log CreateLog(Log log)
        {
            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();
            return log;
        }

        public List<Log> GetLogs()
        {
            return _dbContext.Logs.ToList();
        }

        public List<Log> GetLogs(DateTime timestamp)
        {
            return _dbContext.Logs.Where(x => x.DateTime == timestamp).ToList();
        }

        public Log GetLog(int id)
        {
            return _dbContext.Logs.First(x => x.Id == id);
        }
    }
}