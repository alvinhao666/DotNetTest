using Sino.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCRecordRepository : TMSystemRepository<ETCRecord, Guid>, IETCRecordRepository
    {
        public ETCRecordRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
            : base(configuration, identifyProvider)
        { }

    }
}
