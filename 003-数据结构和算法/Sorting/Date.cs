using System;

namespace Sorting
{
    class Date : IComparable<Date>
    {
        private int year;
        private int month;
        private int day;
        private string happen;

        public Date(int year, int month, int day, string happen)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.happen = happen;
        }

        public int CompareTo(Date other)
        {
            if (this.year > other.year) return 1;
            if (this.year < other.year) return -1;
            if (this.month > other.month) return 1;
            if (this.month < other.month) return -1;
            if (this.day > other.day) return 1;
            if (this.day < other.day) return -1;
            return 0;
        }

        public override string ToString()
        {
            return year + "/" + month + "/" + day + ": " + happen;
        }
    }
}
