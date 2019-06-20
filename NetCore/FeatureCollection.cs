using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    //我们接着从代码层面来看看具体的实现。如下面的代码片段所示，我们定义了一个IFeatureCollection接口来表示存放Feature对象的集合。
    //从定义可以看出这是一个以Type和Object作为Key和Value的字典，Key代表注册Feature所采用的类型，而Value自然就代表Feature对象本身，话句话说我们提供的Feature对象最终是以对应Feature类型（一般为接口类型）进行注册的。
    //为了编程上便利，我们定义了两个扩展方法Set<T>和Get<T>来设置和获取Feature对象。
    public interface IFeatureCollection : IDictionary<Type, object> { }
    public class FeatureCollection : Dictionary<Type, object>, IFeatureCollection { }
    public static partial class Extensions
    {
        public static T Get<T>(this IFeatureCollection features) => features.TryGetValue(typeof(T), out var value) ? (T)value : default(T);
        public static IFeatureCollection Set<T>(this IFeatureCollection features, T feature)
        {
            features[typeof(T)] = feature;
            return features;
        }
    }
}
