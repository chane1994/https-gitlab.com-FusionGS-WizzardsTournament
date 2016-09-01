using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class TargetHandler : MonoBehaviour
    {
        Collider myCollider;
        MeshRenderer meshRenderer;

        // Update is called once per frame
        void Start()
        {
            myCollider = GetComponent<Collider>();
            meshRenderer = GetComponent<MeshRenderer>();
            ActivateAndDeactivate();
        }

        private void ActivateAndDeactivate()
        {
            myCollider.isTrigger = !myCollider.isTrigger;
            meshRenderer.enabled = !meshRenderer.enabled;
            Invoke("ActivateAndDeactivate", Random.Range(1, 15));
        }
    }

}
