﻿namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}

