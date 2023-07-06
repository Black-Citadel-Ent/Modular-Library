using System;
using UnityEngine;

namespace Modular.Debug
{
    [AddComponentMenu("Modular/Debug/Print Float")]
    public class PrintFloat : Attachment
    {
        [SerializeField] private string valueName;
        [SerializeField] private FloatLink value;

        private void Update()
        {
            print($"{valueName}: {value.FloatValue}");
        }
    }
}
