using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.Web {
    public static class MapperConfiguration {
        public static void Configure() => Mapper.Initialize(cfg => Mapping(cfg));

        public static void Mapping(IMapperConfigurationExpression cfg) {
            cfg.CreateMissingTypeMaps = true;
            cfg.ValidateInlineMaps = false;
        }
    }
}
