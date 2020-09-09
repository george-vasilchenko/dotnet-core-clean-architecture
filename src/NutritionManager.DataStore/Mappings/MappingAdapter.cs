using System;
using System.Collections.Generic;
using AutoMapper;

namespace NutritionManager.DataStore.Mappings
{
    public class MappingAdapter
    {
        private readonly Mapper mapper;

        public MappingAdapter(Dictionary<Type, Type> mappings)
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                foreach (var (sourceType, destinationType) in mappings)
                {
                    config.CreateMap(sourceType, destinationType);
                }
            });

            this.mapper = new Mapper(mappingConfig);
        }

        public TDestination Convert<TSource, TDestination>(TSource sourceObject)
        {
            return this.mapper.Map<TSource, TDestination>(sourceObject);
        }
    }
}