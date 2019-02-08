using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopper
{
    internal struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;


        public Time(byte hours, byte minutes, byte seconds)
        {

            _hours = Convert.ToByte(hours % 24);
            _minutes = Convert.ToByte(minutes % 60);
            _seconds = Convert.ToByte(seconds % 60);

            if (_hours >= 24 || _minutes >= 60 || _seconds >= 60)
            {
                throw new ArgumentOutOfRangeException("Out of defined range.");
            }
        }
        public static byte Clamp(byte value, byte min, byte max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
        public byte Seconds
        {
            get
            {
                return _seconds;
            }
        }
        public byte Minutes
        {
            get
            {
                return _seconds;
            }
        }
        public byte Hours
        {
            get
            {
                return _hours;
            }
        }

        public Int32 CompareTo(Time other)
        {
            int totalA = this._seconds + this._minutes * 60 + this._hours * 3600;
            int totalB = other._seconds + other._minutes * 60 + other._hours * 3600;
            if (totalA > totalB)
            {
                return 1;
            }
            if (totalA < totalB)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(Time time1, Time time2)
        {
            if (
                time1._hours == time2._hours ||
                time1._minutes == time2._minutes ||
                time1._seconds == time2._seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Equals(Time time1)
        {
            if (
                time1._hours == this._hours ||
                time1._minutes == this._minutes ||
                time1._seconds == this._seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Time Plus(TimePeriod other)
        {
            long _hours_ = other.Hours + this.Hours;
            long _minutes_ = other.Minutes + this.Minutes;
            long _seconds_ = other.Seconds + this.Seconds;
            TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);
            byte _H = Convert.ToByte(tp1.Hours);
            byte _M = Convert.ToByte(tp1.Minutes);
            byte _S = Convert.ToByte(tp1.Seconds);
            Time ti1 = new Time(_H, _M, _S);
            return ti1;
        }

        public TimePeriod PlusTP(TimePeriod other)
        {
            long _hours_ = other.Hours + this.Hours;
            long _minutes_ = other.Minutes + this.Minutes;
            long _seconds_ = other.Seconds + this.Seconds;
            TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);

            return tp1;
        }

        public override bool Equals(object o)
        {
            if (this.ToString() == o.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            string str = _hours.ToString() + _minutes.ToString();     //+ _seconds.ToString();
            long strint = Convert.ToInt32(str);
            int st = Convert.ToInt16(strint);
            return st;
        }
        public long GetHashCodeLong()
        {
            string str = _hours.ToString() + _minutes.ToString() + _seconds.ToString();
            long strint = Convert.ToInt32(str);
            return strint;
        }
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t1, t2);
        }
        public static bool operator !=(Time t1, Time t2)
        {

            return !(t1 == t2);
        }
        public static bool operator <(Time t1, Time t2)
        {
            int totalA = t1._seconds + t1._minutes * 60 + t1._hours * 3600;
            int totalB = t2._seconds + t2._minutes * 60 + t2._hours * 3600;
            if (totalA < totalB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Time t1, Time t2)
        {

            int totalA = t1._seconds + t1._minutes * 60 + t1._hours * 3600;
            int totalB = t2._seconds + t2._minutes * 60 + t2._hours * 3600;
            if (totalA > totalB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(Time t1, Time t2)
        {

            int totalA = t1._seconds + t1._minutes * 60 + t1._hours * 3600;
            int totalB = t2._seconds + t2._minutes * 60 + t2._hours * 3600;
            if (totalA <= totalB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Time t1, Time t2)
        {

            int totalA = t1._seconds + t1._minutes * 60 + t1._hours * 3600;
            int totalB = t2._seconds + t2._minutes * 60 + t2._hours * 3600;
            if (totalA >= totalB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static TimePeriod operator +(Time time, TimePeriod other)
        {
            long _hours_ = other.Hours + time.Hours;
            long _minutes_ = other.Minutes + time.Minutes;
            long _seconds_ = other.Seconds + time.Seconds;
            TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);

            return tp1;
        }
        public override String ToString()
        {
            string strbld = _hours + ":" + _minutes + ":" + _seconds;
            return $"{strbld}";
        }
    }
}
