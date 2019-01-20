using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Patients.Core.Swagger {
    public class SwaggerExcludeFilter : ISchemaFilter {
        public void Apply(Schema schema, SchemaFilterContext context) {
            var propsToExclude = context.SystemType.GetProperties()
                                .Where(t =>
                                    t.GetCustomAttribute<SwaggerExcludeAttribute>() != null
                                );

            foreach (var prop in propsToExclude) {
                var p = schema.Properties.FirstOrDefault(kvp => kvp.Key.Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase));
                schema.Properties.Remove(p.Key);
            }
        }
    }
}
