using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ActivityProM : IEnumerable      //迭代对象的容器
    {
        public System.Guid PROID { get; set; }
        public string TITLE { get; set; }
        public string CODE { get; set; }
        public System.Guid ACTIVITYID { get; set; }
        public string BUYTIME { get; set; }
        public Nullable<int> NUM { get; set; }
        public string IMAGEPATH { get; set; }
        public string SMALLTITLE { get; set; }
        public string DESIMGPATH { get; set; }
        public Nullable<int> PRICE { get; set; }
        public Nullable<int> POLL { get; set; }
        public Nullable<int> MEMBERPRICE { get; set; }

        private ActivityProM[] _activityprom;
        public ActivityProM(ActivityProM[] activityprom)
        {
            _activityprom = new ActivityProM[activityprom.Length];
            for (int i = 0; i < activityprom.Length; i++)
            {
                _activityprom[i] = activityprom[i];
            }
        }
        public ActivityProM()
        {
        
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ActivityProMEnum(_activityprom);
        }
    }
    class ActivityProMEnum : IEnumerator //迭代器
    {
        int position = -1;
        public ActivityProM[] _activityprom;
        public ActivityProMEnum(ActivityProM[] activityprom)
        {
            _activityprom = activityprom;
        }
        public bool MoveNext()
        {
            position++;
            return (position < _activityprom.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    return _activityprom[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }

        }
    }  
}

