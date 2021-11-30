﻿using MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Domain.AggregationModels.MerchPackRequest
{
    
    public class MerchPackRequestStatus : Enumeration
    {

        public static MerchPackRequestStatus New = new(1, "new");

        public static MerchPackRequestStatus Processing = new(2, "processing");

        public static MerchPackRequestStatus Done = new(3, "done");

        public static MerchPackRequestStatus Decline = new(4, "decline");


        public MerchPackRequestStatus(int id, string name) : base(id, name)
        {

        }

    }
}