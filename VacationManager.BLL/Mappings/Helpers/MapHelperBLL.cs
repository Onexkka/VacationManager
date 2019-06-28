using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VacationManager.BLL.Mappings.Helpers
{
    public class MapHelperBLL
    {
        public static IEnumerable<Type> GetTypesForMapping(string nameSpace)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == nameSpace);
        }
    }
}
