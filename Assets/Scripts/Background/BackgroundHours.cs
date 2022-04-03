using System;

namespace NAMESPACENAME.Background
{
    [Serializable]
    public struct BackgroundHours
    {
        [UnityEngine.SerializeField] int startHour;
        [UnityEngine.SerializeField] int endHour;
        public int publicStartHour 
        {
            get { return startHour; } 
        }
        public int publicEndHour 
        {
            //if start hour is bigger than end hour (like 22 & 3) add 24 hours to end hour
            get { if (startHour > endHour) { return endHour + 24; } return endHour; }
        }
    }
}