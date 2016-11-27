using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It creates the spell game objects based on given data specific to Honovi. It knows where to position the spell to make it look good.
    /// </summary>
    public class HonoviSpellCaster : SpellCaster
    {
        ExpandibleSpell _spellOnHold;

        /// <summary>
        /// Creates the spell but does not throw it.
        /// </summary>
        /// <param name="spellInfo">Information to create the spell</param>
        public override void CastBasicSpell(SpellInfo spellInfo)
        {
            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellInfo.PrefabPath));
            spellCreated.transform.position = shotSpawnPositions.position;
          
            
            Spell spell = spellCreated.GetComponent<Spell>();
            spell.UpdateSpell(spellInfo);
            _spellOnHold = (ExpandibleSpell)spell;
        }

        /// <summary>
        /// Throws a spell that was already created
        /// </summary>
        public virtual void ThrowSpell()
        {
            _spellOnHold.Move(shotSpawnPositions.forward.normalized);
        }

    }

}
