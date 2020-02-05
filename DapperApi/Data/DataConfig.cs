using Dapper;
using DapperApi.Interface;
using DapperApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace DapperApi.Data
{
    public class DataConfig
    {
        IConfiguration _configuration;

        public DataConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DapperConnection").Value;
            return connection;
        }

    }
       
}
