using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Spell that will increase in size overtime 
    /// </summary>
    public class ExpandibleSpell : Spell
    {
        ExpandibleSpellInfo _spellInfo;

        public override float Speed { get { return _spellInfo.Speed; } }

        public override void UpdateSpell(SpellInfo spellInfo)
        {
            _spellInfo = (ExpandibleSpellInfo)spellInfo;
            GetComponent<Rigidbody>().isKinematic = true; 
        }

      

    }

}
