﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string BrandError = "The first letter must be uppercased";

        public const string SizesError = "The first letters must be uppercased and must be divided by a coma";
    }
}
