using System;
using UnityEngine;

namespace Anemos.Background
{
    [Serializable]
    public struct TimedBackground
    {
        public GameObject prefab;
        [Tooltip("Add the hour ranges of the background in 24hs format")]
        public BackgroundHours[] hours;
    }
}