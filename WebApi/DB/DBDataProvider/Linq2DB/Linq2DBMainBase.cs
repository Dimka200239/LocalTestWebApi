using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.DBDataProvider.Linq2DB
{
    public class Linq2DBMainBase : DataConnection
    {
        /// <summary>
        /// Подключение для Linq2DB (путь к серверу)
        /// </summary>
        public Linq2DBMainBase(LinqToDbConnectionOptions<Linq2DBMainBase> options) : base(options)
        {
        }
    }
}
