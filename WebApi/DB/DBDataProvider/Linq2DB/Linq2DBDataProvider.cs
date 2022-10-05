using System;
using System.Collections.Generic;
using System.Linq;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Enities;
using LinqToDB;
using LinqToDB.SqlQuery;
using System.Data.SqlTypes;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Converter;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.DBDataProvider.Linq2DB
{
	public class Linq2DBDataProvider
	{
		/// <summary>
		/// Подключение к БД
		/// </summary>
		private readonly Linq2DBMainBase _connection;

		/// <summary>
		/// Конструктор класса
		/// </summary>
		public Linq2DBDataProvider(Linq2DBMainBase connection)
		{
			_connection = connection;
		}

		/// <summary>
		/// Получение всех строк с сотрудниками из таблицы Employee
		/// </summary>
		/// <returns>Список со всеми сотрудниками</returns>
		public string GetLastDeal()
		{
			var admin = Environment.UserName;
			Console.WriteLine(admin);
			var query = from p in _connection.GetTable<User>()
						where p.UserDomainName == admin
						select p;

			var userId = (Guid)query.ToList()[0].Id;

			return GetAllDataByUserId(userId);
		}

		private string GetAllDataByUserId(Guid userId)
		{
			var query = from p in _connection.GetTable<Data>()
						where p.UserId == userId
						select p.Entity;

			var data = query.ToList();

			var jsonConverter = new JsonConverter();
			var entities = new List<Entity>();

			foreach (var item in data)
			{
				var newItem = jsonConverter.Deserialize(item);
				newItem.SetLocalTime();
				entities.Add(newItem);
			}

			var sortByData = from element in entities
							 orderby element.time
							 select element;

			var lastData = jsonConverter.Serialize(sortByData.ToList().Last());

			return lastData;

		}
	}
}
