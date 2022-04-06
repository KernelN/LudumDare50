using UnityEngine;

namespace Universal.CustomPhysics
{
    public abstract class CenterOfMassModifier : MonoBehaviour
    {
        //Unity Events
        internal void Start()
        {
            ModifyCenter();
        }
#if UNITY_EDITOR
        [ExecuteInEditMode]
        internal void OnDrawGizmos()
        {
            DrawCenter();
        }
#endif

        //Methods
        internal abstract void DrawCenter();
        internal abstract void ModifyCenter();
    }
}