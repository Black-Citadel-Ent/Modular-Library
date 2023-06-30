using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Object Control/Destroy")]
    public class Destroy : Attachment
    {
        [SerializeField] private GameObject target;
        [SerializeField] private BoolLink trigger;

        private void LateUpdate()
        {
            if(trigger.BoolValue)
                Destroy(target);
        }
    }
}
