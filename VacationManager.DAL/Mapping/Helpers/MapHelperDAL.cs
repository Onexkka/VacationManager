using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VacationManager.DAL.Mapping.Helpers
{
    public class MapHelperDAL
    {
        public static IEnumerable<Type> GetTypesForMapping(string nameSpace)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == nameSpace);
        }
    }
}
