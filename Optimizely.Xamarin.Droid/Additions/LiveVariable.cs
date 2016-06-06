using Android.Runtime;
using Com.Optimizely.Variable;
using Java.Lang;

namespace Optimizely.Variable
{
    /// <summary>
    /// Generic Wrapper around LiveVariable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LiveVariable<T> where T: Object
    {
        private readonly LiveVariable _lv;

        public LiveVariable(LiveVariable lv)
        {
            _lv = lv;
        }

        public T Get()
        {
            var obj = _lv.Get();
            return obj.JavaCast<T>();
        }
    }
}