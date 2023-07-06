using System;
using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Set Scale")]
    public class SetScale : Attachment
    {
        [SerializeField] private Transform target;
        [SerializeField] private BoolLink trigger;
        [SerializeField] private Vector3Link value;

        private void Update()
        {
            if (trigger.BoolValue)
            {
                target.localScale = value.Vector3Value;
            }
        }
    }
}