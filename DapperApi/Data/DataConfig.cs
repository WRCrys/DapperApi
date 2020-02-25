using Dapper;
using DapperApi.Interface;
using DapperApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace DapperApi.Data
{
    public static class DataConfig
    {

        public static string GetConnection(IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionStrings").GetSection("DapperConnection").Value;
            return connection;
        }

    }
       
}
