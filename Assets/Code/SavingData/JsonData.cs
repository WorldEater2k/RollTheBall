using System.IO;
using UnityEngine;

namespace RollTheBall
{
    internal sealed class JsonData<T> : IData<T>
    {
        public void Save(T data, string path)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str));
        }
        public T Load(string path)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
        }
    }
}
