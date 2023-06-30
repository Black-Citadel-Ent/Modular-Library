using System;
using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Object Control/Instantiate")]
    public class Instantiate : Attachment
    {
        [SerializeField] private GameObject objectToCreate;
        [SerializeField] private BoolLink trigger;
        [SerializeField] private Vector3Link createPosition;
        [SerializeField] private Vector3Link createRotation;

        private void Update()
        {
            if (trigger.BoolValue)
            {
                Instantiate(objectToCreate, createPosition.Vector3Value, Quaternion.Euler(createRotation.Vector3Value));
            }
        }
    }
}
