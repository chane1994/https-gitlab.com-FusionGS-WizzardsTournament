using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class ExpandibleSpell : Spell
    {
        ExpandibleSpellInfo _spellInfo;

        public override float Speed { get { return _spellInfo.Speed; } }

        public override void UpdateSpell(SpellInfo spellInfo)
        {
            _spellInfo = (ExpandibleSpellInfo)spellInfo;
            GetComponent<Rigidbody>().isKinematic = true; 
        }

        /// <summary>
        /// Makes the spell move in a specific direction
        /// </summary>
        /// <param name="direction">Direction in which the spell will move</param>
        public void Move(Vector3 direction) 
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(direction * Speed);
        }

    }

}
