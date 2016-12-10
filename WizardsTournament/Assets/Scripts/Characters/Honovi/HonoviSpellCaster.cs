using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It creates the spell game objects based on given data specific to Honovi. It knows where to position the spell to make it look good.
    /// </summary>
    public class HonoviSpellCaster : SpellCaster
    {
        #region Variables
        Spell _spellOnHold;
        #endregion

        #region Methods
        /// <summary>
        /// Creates the spell but does not throw it.
        /// </summary>
        /// <param name="spellInfo">Information to create the spell</param>
        public override void CastBasicSpell(SpellInfo spellInfo)
        {
            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellInfo.PrefabPath));
            spellCreated.transform.parent = transform;
            spellCreated.transform.position = shotSpawnPositions.position;
          
            
            Spell spell = spellCreated.GetComponent<Spell>();
            spell.UpdateSpell(spellInfo);
            _spellOnHold = spell;
        }

        /// <summary>
        /// Throws a spell that was already created
        /// </summary>
        public virtual void ThrowSpell()
        {
            _spellOnHold.transform.parent = null;
            Rigidbody spellRigidBody = _spellOnHold.GetComponent<Rigidbody>();
            spellRigidBody.isKinematic = false;
            spellRigidBody.AddForce(shotSpawnPositions.forward.normalized * _spellOnHold.Speed);
        }

        /// <summary>
        /// Destroys the skull if it is charging.
        /// </summary>
        public virtual void DestroyCurrentSpell()
        {
            if (_spellOnHold != null)
            {
                _spellOnHold.gameObject.SetActive(false);
                _spellOnHold = null;
            }
        }
        #endregion
    }

}
