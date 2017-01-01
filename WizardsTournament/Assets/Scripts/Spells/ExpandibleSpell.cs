using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Spell that will increase in size overtime 
    /// </summary>
    public class ExpandibleSpell : Spell
    {
        public float highestScaleValue =  0.3f;
        public float increment = 0.01f;
        float frequency = 0.01f;
        Rigidbody rigidBody;

        void Start()
        {
            InvokeRepeating("UpdateScale",0,frequency);
            rigidBody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Increases the size of the spell and the hit power
        /// </summary>
        void UpdateScale()
        {
            if (transform.localScale.x < highestScaleValue && rigidBody.isKinematic)
            {
                transform.localScale = new Vector3(transform.localScale.x + increment, transform.localScale.x + increment, transform.localScale.x + increment);
                HitPower++;
            }
            else
            {
                CancelInvoke("UpdateScale");
            }
        }
    }

}
