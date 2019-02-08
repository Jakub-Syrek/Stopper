using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopper
{
       
        struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
        {
            private readonly long _totalSeconds;

            private readonly long _seconds;

            private readonly long _minutes;

            private readonly long _hours;

            //private long _days;
            public TimePeriod(long hours, long minutes, long seconds)
            {

                _hours = hours;
                _minutes = minutes;
                _seconds = seconds;
                if (_minutes > 60)
                {
                    _hours = _hours + (_minutes / 60);
                    _minutes = _minutes % 60;
                }
                if (_seconds > 60)
                {
                    _minutes = _minutes + (_seconds / 60);
                    _seconds = _seconds % 60;
                }
                _seconds = seconds;
                _totalSeconds = _seconds + _minutes * 60 + _hours * 3600;


                if (_minutes >= 61 || _seconds >= 61)
                {
                    throw new ArgumentException("Out of defined range.");
                }

            }
            public long Seconds
            {
                get
                {
                    return _seconds;
                }

            }
            public long Minutes
            {
                get
                {
                    return _minutes;
                }

            }
            public long Hours
            {
                get
                {
                    return _hours;
                }
            }
            public long TotalSeconds
            {
                get
                {
                    return _totalSeconds;
                }

            }
            public TimePeriod PlusTP(TimePeriod other)
            {
                long _hours_ = other.Hours + this.Hours;
                long _minutes_ = other.Minutes + this.Minutes;
                long _seconds_ = other.Seconds + this.Seconds;
                TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);
                byte _H = Convert.ToByte(tp1.Hours);
                byte _M = Convert.ToByte(tp1.Minutes);
                byte _S = Convert.ToByte(tp1.Seconds);
                Time ti1 = new Time(_H, _M, _S);
                return tp1;
            }
            public override String ToString()
            {
                string strbld = _hours + ":" + _minutes + ":" + _seconds;
                return $"{strbld}";
            }

            int IComparable<TimePeriod>.CompareTo(TimePeriod other)
            {
                if (this.TotalSeconds > other.TotalSeconds)
                {
                    return 1;
                }
                if (this.TotalSeconds < other.TotalSeconds)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            bool IEquatable<TimePeriod>.Equals(TimePeriod other)
            {
                if (
                    this.Hours == other.Hours ||
                    this.Hours == other.Minutes ||
                    this.Seconds == other.Seconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public TimePeriod Plus(Time other)
            {
                long _hours_ = other.Hours + this.Hours;
                long _minutes_ = other.Minutes + this.Minutes;
                long _seconds_ = other.Seconds + this.Seconds;
                TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);
                return tp1;
            }

            public TimePeriod Plus(TimePeriod other)
            {
                long _hours_ = other.Hours + this.Hours;
                long _minutes_ = other.Minutes + this.Minutes;
                long _seconds_ = other.Seconds + this.Seconds;
                TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);
                return tp1;
            }
            static TimePeriod Plus(TimePeriod t1, TimePeriod t2)
            {
                long _hours_ = t1.Hours + t2.Hours;
                long _minutes_ = t1.Minutes + t2.Minutes;
                long _seconds_ = t1.Seconds + t2.Seconds;
                TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);
                return tp1;
            }
            public static TimePeriod operator +(TimePeriod tpa, TimePeriod tpb)
            {
                long _hours_ = tpa.Hours + tpb.Hours;
                long _minutes_ = tpa.Minutes + tpb.Minutes;
                long _seconds_ = tpa.Seconds + tpb.Seconds;
                TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);

                return tp1;
            }
            public static TimePeriod operator -(TimePeriod tpa, TimePeriod tpb)
            {
                try
                {
                    long _hours_ = tpa.Hours - tpb.Hours;
                    long _minutes_ = tpa.Minutes - tpb.Minutes;
                    long _seconds_ = tpa.Seconds - tpb.Seconds;
                    TimePeriod tp1 = new TimePeriod(_hours_, _minutes_, _seconds_);

                    return tp1;
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("Out of defined range.");
                }
            }
            public static bool operator <(TimePeriod t1, TimePeriod t2)
            {
                if (t1.TotalSeconds < t2.TotalSeconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >(TimePeriod t1, TimePeriod t2)
            {
                if (t1.TotalSeconds > t2.TotalSeconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator <=(TimePeriod t1, TimePeriod t2)
            {
                if (t1.TotalSeconds <= t2.TotalSeconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >=(TimePeriod t1, TimePeriod t2)
            {
                if (t1.TotalSeconds >= t2.TotalSeconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        public static implicit operator TimeSpan(TimePeriod v)
        {
            return TimeSpan.Parse(v.ToString());
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
        }
    
}
