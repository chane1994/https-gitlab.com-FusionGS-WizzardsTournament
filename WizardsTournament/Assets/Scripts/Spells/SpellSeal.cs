using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the logic of a SpellSeal. It decides when to disappear the spell and has the valid states.
    /// </summary>
    public class SpellSeal : MonoBehaviour
    {
        protected float lifeTime = 8;

        void Start()
        {
            Invoke("DestroySpellSeal", lifeTime);
        }

        protected void DestroySpellSeal()
        {
            //It would play an animation
            Destroy(gameObject);
        }
    }

}
