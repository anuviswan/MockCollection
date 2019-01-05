﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Randomize.Net
{
    public static partial class RandomExtensions
    {
        public static IEnumerable<T> GenerateCollection<T>(this Random source,int count = 1)
        {
            _random = source;
            return GenerateCollection<T>(count);
        }
        private static IEnumerable<T> GenerateCollection<T>(int count = 1)
        {
            for(int i = 0; i < count; i++)
            {
                var instance = GenerateInstance<T>();
                AssignProperties(instance);
                yield return instance;
            }
        }

        public static T GenerateInstance<T>(this Random source)
        {
            _random = source;
            return GenerateInstance<T>();
        }
        private static T GenerateInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
        private static void AssignProperties(object obj)
        {
            if (obj == null) return;
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                property.SetValue(obj, null, null);
                var attribute = property.GetCustomAttribute<NumericConstraintAttribute>(false);
                
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        AssignProperties(item);
                    }
                }
                else
                {
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        if (property.PropertyType.IsClass)
                        {
                            propValue = Activator.CreateInstance(property.PropertyType);
                            property.SetValue(obj, propValue);
                        }
                        AssignProperties(propValue);
                    }
                    else
                    {
                        if (attribute != null)
                        {
                            var maxValue = attribute.MaxValue;
                            var minValue = attribute.MinValue;
                            var randomValue = property.PropertyType.GetRandomValues(minValue, maxValue);
                            property.SetValue(obj, randomValue);
                        }
                        else
                        {
                            var randomValue = property.PropertyType.GetRandomValues();
                            property.SetValue(obj, randomValue);
                        }
                        
                        
                    }
                }
            }
        }

        

    }
}