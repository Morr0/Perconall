using System;

namespace Perconall.Core.Utilities.MappingProfiles
{
    public static class MappingProfilesUtility
    {
        public static Type[] GetProfiles() => new[]
        {
            typeof(EntryModelDtosMappingsProfile)
        };
    }
}