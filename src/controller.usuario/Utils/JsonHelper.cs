using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Usuarios.Utils
{
    public static class JsonHelper
    {

        public static String toJSON(dynamic input)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ContractResolver = CustomResolver.Instance;

            string jsonResult = JsonConvert.SerializeObject(input, settings);
            return jsonResult;
        }
        public static dynamic toObject<T>(Object data)
        {
            try
            {
                String json = JsonHelper.toJSON(data);
                Object obj = JsonConvert.DeserializeObject(json, typeof(T));
                return obj;
            }
            catch (JsonReaderException)
            {
                return data;
            }
        }

        public static dynamic toObject<T>(String json)
        {
            try
            {
                Object obj = JsonConvert.DeserializeObject(json, typeof(T));
                return obj;
            }
            catch (JsonReaderException)
            {
                return json;
            }
        }

        public static dynamic toObject<T>(JObject json)
        {
            Object obj = JsonConvert.DeserializeObject(json.ToString(), typeof(T));
            return obj;
        }


        public static dynamic toObject<T>(JArray json)
        {
            Object obj = json.ToObject<T>();
            return obj;
        }
    }


    class CustomResolver : DefaultContractResolver
    {
        static CustomResolver instance;

        static CustomResolver() { instance = new CustomResolver(); }

        public static CustomResolver Instance { get { return instance; } }


        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);

            try
            {
                if (((System.Reflection.PropertyInfo)member).GetMethod.IsVirtual)
                {
                    prop.ShouldSerialize = obj => false;
                }

            }
            catch { }

            return prop;
        }
    }
}
