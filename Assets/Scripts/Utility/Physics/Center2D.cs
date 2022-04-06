using UnityEngine;

namespace Universal.CustomPhysics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Center2D : CenterOfMassModifier
    {
        [Header("Set Values")]
        [SerializeField] Rigidbody2D rBody;
        [SerializeField] Vector2 center;

        //Methods
        internal override void DrawCenter()
        {
            Gizmos.DrawSphere((Vector2)transform.position + center, transform.lossyScale.x);
        }
        internal override void ModifyCenter()
        {
            if (rBody == null)
            {
                rBody = GetComponent<Rigidbody2D>();
            }

            rBody.centerOfMass = center;
        }
    }
}