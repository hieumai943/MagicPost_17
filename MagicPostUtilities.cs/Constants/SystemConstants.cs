﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPostUtilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "eShopSolutionDb";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }
        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}

