using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Enities;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Converter
{
    public class JsonConverter
    {
        /// <summary>
        /// Функция для сериализации.
        /// </summary>
        /// <param name="heros">Список с героями.</param>
        /// <param name="pathFile">Путь к JSON файлу</param>
        public string Serialize(Entity en)
        {
            return JsonConvert.SerializeObject(en);
        }

        /// <summary>
        /// Функция для дисериализации.
        /// </summary>
        /// <param name="pathFile">Путь к JSON файлу.</param>
        /// <returns>Список объектов класса Hero.</returns>
        public Entity Deserialize(string item)
        {
            return JsonConvert.DeserializeObject<Entity>(item);
        }
    }
}
