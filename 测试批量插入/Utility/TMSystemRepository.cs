using Dapper;
using Sino.Dapper;
using Sino.Dapper.Repositories;
using Sino.Domain.Entities;
using Sino.Domain.Entities.Auditing;
using Sino.Domain.Repositories;
using Sino.ExpressionToSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
	public abstract class TMSystemRepository<TEntity, TPrimaryKey> : DapperRepositoryBase<TEntity, TPrimaryKey>, ITMSystemRepository<TEntity, TPrimaryKey>
		where TEntity : class, IEntity<TPrimaryKey>
	{
		protected IIdentifyProvider IdentifyProvider { get; set; }

		public TMSystemRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
			: base(configuration)
		{
			IdentifyProvider = identifyProvider;
		}

		
	}
}
