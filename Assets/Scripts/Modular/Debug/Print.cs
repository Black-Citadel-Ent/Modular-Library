using System;
using UnityEngine;

namespace Modular.Debug
{
    [AddComponentMenu("Modular/Debug/Print")]
    public class Print : Attachment
    {
        [SerializeField] private string message;
        [SerializeField] private BoolLink trigger;

        private void Update()
        {
            if(trigger.BoolValue)
                print(message);
        }
    }
}
