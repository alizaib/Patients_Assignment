using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Core.Extensions {
    public static class ReflectionExtension {
        public static bool InheritsGenericClass(this Type type, Type genericClassType) {
            
            while (type != null && type != typeof(object)) {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericClassType) {
                    return true;
                }

                type = type.BaseType;
            }
            return false;
        }
    }
}
