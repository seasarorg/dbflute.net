using System;

namespace DBFluteRuntime.JavaLike.Util
{
    /// <summary>
    /// [Java]Mapインターフェース
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public interface Map<KEY, VALUE>
    {
        VALUE get(KEY key);
        VALUE put(KEY key, VALUE value);
        VALUE remove(KEY obj);
        int size();
        bool isEmpty();
        void clear();
        bool containsKey(KEY key);
        Set<KEY> keySet();
        Collection<VALUE> values();
        Set<Entry<KEY, VALUE>> entrySet();
    }

    /// <summary>
    /// [Java]Mapインターフェース（非ジェネリック）
    /// </summary>
    public interface NgMap
    {
        Object getAsNg(Object key);
        Object putAsNg(Object key, Object value);
        Object removeAsNg(Object key);
        bool containsKeyAsNg(Object key);
    }
}
