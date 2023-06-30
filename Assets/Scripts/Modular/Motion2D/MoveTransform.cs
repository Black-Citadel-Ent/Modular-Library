using System;
using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Move Transform")]
    public class MoveTransform : Attachment
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector2Link distance;
        [SerializeField] private BoolLink trigger;

        private void Update()
        {
            if (trigger.BoolValue)
            {
                var orig = target.position;
                target.position = new Vector3(distance.Vector2Value.x + orig.x, distance.Vector2Value.y + orig.y, orig.z);
            }
        }
    }
}
