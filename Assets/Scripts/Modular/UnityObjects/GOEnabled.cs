using System;
using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Game Object Enabled")]
    public class GoEnabled : Attachment
    {
        [SerializeField] private GameObject target;
        [SerializeField] private BoolLink value;

        private void Update()
        {
            target.SetActive(value.BoolValue);
        }
    }
}