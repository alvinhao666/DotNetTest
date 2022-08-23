using System;

namespace SinoData
{
    public class Order
    {
        public Guid? Id { get; set; }


        public Guid? ClientId { get; set; }


        public Guid? LogisticsId { get; set; }


        public string RealClientCode { get; set; }
    }
}
