// <copyright file="Json.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Astonaige.Utility
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public static class Json
    {
        public static string SerializeJson<T>(T obj)
            where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T DeserializeJson<T>(string json)
            where T : class
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
