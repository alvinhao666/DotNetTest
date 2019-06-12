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
		where TEntity : class, IFullAudited, IEntity<TPrimaryKey>
	{
		protected IIdentifyProvider IdentifyProvider { get; set; }

		public TMSystemRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
			: base(configuration)
		{
			IdentifyProvider = identifyProvider;
		}

		public async override Task<Tuple<int, IList<TEntity>>> GetListAsync(IQueryObject<TEntity> query)
		{
			var parameters = new DynamicParameters();
			var select = ExpressionHelper.Select<TEntity>();
			var count = ExpressionHelper.Count<TEntity>();

			foreach (var where in query.QueryExpression)
			{
				select.Where(where);
			}
			foreach (var where in query.QueryExpression)
			{
				count.Where(where);
			}
			select.Where(x => x.IsDeleted == false);
			count.Where(x => x.IsDeleted == false);
			if (query.OrderSort == SortOrder.ASC)
			{
				select.OrderBy(query.OrderField);
			}
			else if (query.OrderSort == SortOrder.DESC)
			{
				select.OrderByDesc(query.OrderField);
			}
			select.OrderByDesc(x => x.CreationTime);
			if (query.Count >= 0)
			{
				select.Limit(query.Skip, query.Count);
			}

			foreach (KeyValuePair<string, object> item in select.DbParams)
			{
				parameters.Add(item.Key, item.Value);
			}

			using (Connection)
			{
				var customerRepresentativeList = await ReadConnection.QueryAsync<TEntity>(select.Sql, parameters);
				int totalCount = await ReadConnection.QuerySingleAsync<int>(count.Sql, parameters);

				return new Tuple<int, IList<TEntity>>(totalCount, customerRepresentativeList.ToList());
			}
		}

		public async override Task<int> CountAsync(IQueryObject<TEntity> query)
		{
			var parameters = new DynamicParameters();
			var count = ExpressionHelper.Count<TEntity>();
			foreach (var where in query.QueryExpression)
			{
				count.Where(where);
			}
			count.Where(x => x.IsDeleted == false);

			foreach (KeyValuePair<string, object> item in count.DbParams)
			{
				parameters.Add(item.Key, item.Value);
			}

			using (Connection)
			{
				var Count = await ReadConnection.QuerySingleAsync<int>(count.Sql, parameters);
				return Count;
			}
		}
	}
}
