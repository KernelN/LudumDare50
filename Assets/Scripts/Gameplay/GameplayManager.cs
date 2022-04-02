using UnityEngine;
using Universal.Singletons;

namespace NAMESPACENAME.Gameplay
{
    public class GameplayManager : MonoBehaviourSingletonInScene<GameplayManager>
    {
        [Header("Set Values")]
        [SerializeField] Transform pot;
        [SerializeField] float loseHeight;

        //Unity Events
        private void Start()
        {
            if(pot == null)
            {
                pot = GameObject.FindGameObjectWithTag("Pot").transform;
            }
        }
        private void Update()
        {
            CheckPotHeight();

#if UNITY_EDITOR
            DrawGameOverHeight(); 
#endif
        }

        //Methods
        const float lineRadius = 50;
        void DrawGameOverHeight()
        {
            Vector2 lineStart = new Vector2(-lineRadius, loseHeight);
            Vector2 lineEnd = new Vector2(lineRadius, loseHeight);
            Debug.DrawLine(lineStart, lineEnd);
        }
        void CheckPotHeight()
        {
            if (pot.position.y < loseHeight)
            {
                Debug.Log("You lost");
                Debug.Break();
            }
        }
    }
}