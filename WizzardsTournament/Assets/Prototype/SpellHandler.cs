using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class SpellHandler : MonoBehaviour
    {

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag.Equals("Target"))
            {
                collision.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
                SceneController.IncreaseCount();
            }
        }
    }

}
