using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Core.Swagger {
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute {
    }
}
