﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Randomize.Net
{
    public static partial class RandomExtensions
    {
        private static Random _random;
        public static IEnumerable<T> GenerateCollection<T>(this Random source,int count = 1)
        {
            _random = source;
            return GenerateCollectionInternal<T>(count);
        }
        private static IEnumerable<T> GenerateCollectionInternal<T>(int count = 1)
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
            var type = typeof(T);
            if (type.IsPrimitive || type == typeof(Decimal) || type == typeof(String))
            {
                return type.GetRandomValues();
            }
            else
            {
                var instance = GenerateInstance<T>();
                AssignProperties(instance);
                return instance;
            }
        }

        internal static dynamic GetRandomValues(this Type source, Attributes.BaseLimitAttribute limitAttribute = null)
        {
            IDictionary<Type, Func<dynamic>> _actionDictionary = new Dictionary<Type, Func<dynamic>>()
            {
                [typeof(string)] = () => RandomString(),
                [typeof(sbyte)] = () => RandomSByte(),
                [typeof(short)] = () => RandomInt16(limitAttribute),
                [typeof(int)] = () => RandomInt32(limitAttribute),
                [typeof(long)] = () => RandomInt64(limitAttribute),
                [typeof(bool)] = () => RandomBoolean(),
                [typeof(double)] = () => RandomDouble(limitAttribute),
                [typeof(byte)] = () => RandomByte(),
                [typeof(char)] = () => RandomChar(),
                [typeof(ushort)] = () => RandomUInt16(limitAttribute),
                [typeof(uint)] = () => RandomUInt32(limitAttribute),
                [typeof(ulong)] = () => RandomUInt64(limitAttribute),
                [typeof(decimal)] = () => RandomDecimal(),
                [typeof(float)] = () => RandomFloat(),
            };
            return _actionDictionary.ContainsKey(source) ? _actionDictionary[source]() : GetDefault(source);
        }

        private static T GenerateInstance<T>() => Activator.CreateInstance<T>();

        private static void AssignProperties(object obj)
        {
            if (obj == null) return;
            Type objType = obj.GetType();
            
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                property.SetValue(obj, null, null);
                var limitAttribute = property.GetCustomAttribute<Attributes.BaseLimitAttribute>(false);
                if (propValue is IList elems)
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
                        var randomValue = property.PropertyType.GetRandomValues(limitAttribute);
                        property.SetValue(obj, randomValue);
                    }
                }
            }
        }

        

    }
}
