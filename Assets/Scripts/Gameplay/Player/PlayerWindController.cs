using UnityEngine;

namespace Anemos.Gameplay
{
    public class PlayerWindController : MonoBehaviour
    {
        [Header("Set Values")]
        [SerializeField] float windDuration = 3;

        [Header("Runtime Values")]
        [SerializeField] float windTimer;

        public System.Action<Transform> WindStopped;

        public float publicDuration { get { return windDuration; } }
        public float publicTimer { get { return windTimer; } }

        //Unity Events
        private void Update()
        {
            AdvanceTimer();
        }

        //Methods
        void AdvanceTimer()
        {
            windTimer += Time.deltaTime;

            if (windTimer > windDuration)
            {
                WindStopped?.Invoke(transform);
                Destroy(gameObject);
            }
        }
    }
}