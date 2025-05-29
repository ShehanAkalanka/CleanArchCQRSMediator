using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace CleanArchCQRSMediator.Application.Books.Common.Mappings
{
    /// <summary>
    /// 🚀 GENERIC AutoMapper Profile that automatically discovers and configures mappings
    /// This eliminates the need to manually register each mapping - just implement IMapFrom<T> on your DTOs/ViewModels
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ===================================================================
            // 🎯 FULLY GENERIC APPROACH - Zero Manual Configuration Required!
            // ===================================================================
            // This single line automatically discovers ALL mappings in the assembly
            // No need to manually add CreateMap<Source, Destination>() for each mapping
            // Just implement IMapFrom<T> interface on your DTOs/ViewModels
            
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 🔍 Generic method that automatically discovers and applies ALL mapping configurations
        /// Scans the assembly for classes implementing IMapFrom<T> and auto-configures their mappings
        /// This makes the mapping system completely self-configuring and scalable
        /// </summary>
        /// <param name="assembly">The assembly to scan for mapping configurations</param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // 1️⃣ Find the generic IMapFrom<> interface type
            var mapFromType = typeof(IMapFrom<>);
            
            // 2️⃣ Scan assembly for all types that implement IMapFrom<SomeEntity>
            var mappingTypes = assembly.GetExportedTypes()
                .Where(type => 
                    type.GetInterfaces().Any(i => 
                        i.IsGenericType && 
                        i.GetGenericTypeDefinition() == mapFromType))
                .ToList();

            // 3️⃣ For each discovered type, invoke its mapping configuration
            foreach (var type in mappingTypes)
            {
                // Create instance of the DTO/ViewModel class
                var instance = Activator.CreateInstance(type);
                
                // Find the Mapping method from the interface
                var methodInfo = type.GetMethod("Mapping") 
                              ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
                
                // Invoke the Mapping method to configure AutoMapper
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
    /// <summary>
    /// 🎯 ADVANCED: Generic interface for bi-directional mappings
    /// Implement this when you need to map both ways (Entity ↔ DTO)
    /// </summary>
    /// <typeparam name="T">The source type to map from/to</typeparam>
    // public interface IMapFromTo<T>
    // {
    //     /// <summary>
    //     /// Configure bi-directional mapping between T and this type
    //     /// </summary>
    //     /// <param name="profile">The AutoMapper profile to configure</param>
    //     void Mapping(Profile profile)
    //     {
    //         profile.CreateMap(typeof(T), GetType());
    //         profile.CreateMap(GetType(), typeof(T));
    //     }
    // }
}
