using Dapper;
using Sino.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public class ETCCarRepository : TMSystemRepository<ETCCar, Guid>, IETCCarRepository
    {
        public ETCCarRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
            : base(configuration, identifyProvider)
        { }

        public async Task<ETCCar> GetCar(string carCode)
        {
            StringBuilder sql = new StringBuilder(" Select * from etccars where  CarCode =@CarCode");

            DynamicParameters param = new DynamicParameters();

            param.Add("@CarCode", carCode);
            var list = await ReadConnection.QueryAsync<ETCCar>(sql.ToString(), param);
            return list.FirstOrDefault();
        }
    }
}
