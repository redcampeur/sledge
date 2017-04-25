﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Sledge.BspEditor.Primitives.MapData
{
    /// <summary>
    /// Collection of metadata for a map
    /// </summary>
    public class MapDataCollection : IEnumerable<IMapData>, ISerializable
    {
        public List<IMapData> Data { get; }

        public MapDataCollection()
        {
            Data = new List<IMapData>();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", Data.ToArray());
        }

        public void Add(IMapData data)
        {
            Data.Add(data);
        }

        public void AddRange(IEnumerable<IMapData> data)
        {
            Data.AddRange(data);
        }

        public void Remove(IMapData data)
        {
            Data.Remove(data);
        }

        public IEnumerable<T> Get<T>() where T : IMapData
        {
            return Data.OfType<T>();
        }

        public T GetOne<T>() where T : IMapData
        {
            return Data.OfType<T>().FirstOrDefault();
        }

        public MapDataCollection Clone()
        {
            var copy = new MapDataCollection();
            foreach (var d in Data)
            {
                copy.Add(d.Clone());
            }
            return copy;
        }

        public IEnumerator<IMapData> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}