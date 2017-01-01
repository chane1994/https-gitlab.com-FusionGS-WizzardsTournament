using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Spell that starts with an initial size, but increases over time. 
    /// </summary>
    public class ExpandibleSpellInfo : SpellInfo
    {
        #region Properties
        public float MaxHitPower { get; protected set; }

        public float Increment { get; protected set; }
        #endregion

        public ExpandibleSpellInfo(float hitPower, string prefabPath, float speed, float increment,  float maxHitPower, SpellName name):base(hitPower,prefabPath,speed,name)
        {
            MaxHitPower = maxHitPower;
            Increment = increment;
        }

        protected void IncreaseHitPower()
        {
            if (HitPower + Increment >= MaxHitPower)
            {
                HitPower = MaxHitPower;
            }
            else
            {
                HitPower += Increment;
            }
        }

    }

}
