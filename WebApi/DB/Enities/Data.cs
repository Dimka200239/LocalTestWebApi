using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using System.Data.SqlTypes;

namespace Norbit.Sap.Georgiev.CSharpLastTask.Api.DB.Enities
{
    [Table(Name = "Data")]
    public class Data
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [PrimaryKey, Identity, NotNull]
        public SqlGuid Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Column, NotNull]
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Column, NotNull]
        public string Entity { get; set; }
    }
}
