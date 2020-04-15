using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Reusable.Extensions
{
    public static class CloningExtensions
    {
        public static TObject DeepCloneWithBinarySerialization<TObject>(this TObject obj)
        {
            var formatter = new BinaryFormatter();
            using var stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            stream.Position = 0;
            return (TObject)formatter.Deserialize(stream);
        }

        public static TObject DeepCloneWithJsonSerialization<TObject>(this TObject obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<TObject>(json);
        }
    }
}
