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
        public Transform fireballSpawnPoint;
        Spell _spellOnHold;
        const float POSITION_UPDATE_FREQUENCY = 0.05f;
        Vector3[] _oldPositions;
        #endregion

        #region Methods
        void Start()
        {
            _oldPositions = new Vector3[5];
        }

        /// <summary>
        /// Creates the spell but does not throw it.
        /// </summary>
        /// <param name="spellInfo">Information to create the spell</param>
        public override void CastBasicSpell(SpellInfo spellInfo)
        {
            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellInfo.PrefabPath));
            spellCreated.transform.parent = transform;
            if (spellInfo.Name.Equals(SpellName.Skull))
            {
                spellCreated.transform.position = shotSpawnPositions.position;
            }
            else
            {
                spellCreated.transform.position = fireballSpawnPoint.position;
            }
           
          
            
            Spell spell = spellCreated.GetComponent<Spell>();
            spell.UpdateSpell(spellInfo);
            _spellOnHold = spell;
        }

        /// <summary>
        /// Creates a spell that will be thrown later on.
        /// </summary>
        /// <param name="spellInfo">Information to create the spell</param>
        public virtual void CastThrowableSpell(SpellInfo spellInfo)
        {
            CastBasicSpell(spellInfo);
            _spellOnHold.GetComponent<Rigidbody>().isKinematic = true;
            InvokeRepeating("UpdatePosition", POSITION_UPDATE_FREQUENCY, POSITION_UPDATE_FREQUENCY);
        }


        /// <summary>
        /// Throws a spell that was already created
        /// </summary>
        public virtual void ImpulseSpell()
        {
            _spellOnHold.transform.parent = null;
            Rigidbody spellRigidBody = _spellOnHold.GetComponent<Rigidbody>();
            spellRigidBody.isKinematic = false;
            spellRigidBody.AddForce(shotSpawnPositions.forward.normalized * _spellOnHold.Speed);
            _spellOnHold = null;
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
                CancelInvoke("UpdatePosition");
            }

        }

        /// <summary>
        /// Throws a spell. The direction and speed will depend on the movement of your hand
        /// </summary>
        public virtual void ThrowSpell()
        {
            _spellOnHold.transform.parent = null;
             CancelInvoke("UpdatePosition");
            Rigidbody rigidBody = _spellOnHold.GetComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            Vector3 direction = _oldPositions[0] - _oldPositions[1];
            float velocity = FusionGameStudios.Physics.AverageVelocity(_oldPositions, POSITION_UPDATE_FREQUENCY);
            Debugger.Log(velocity.ToString());
            rigidBody.AddForceAtPosition(direction.normalized * velocity * _spellOnHold.Speed, Vector3.zero, ForceMode.Impulse);
            _spellOnHold = null;
        }

        /// <summary>
        /// Updates the _oldPositions array with the position values of the spell to calculate the velocity of a spell that will be thrown
        /// </summary>
        void UpdatePosition()
        {
           
                //shifting the values
                for (int i = _oldPositions.Length - 1; i >= 1; i--)
                {
                    _oldPositions[i] = _oldPositions[i - 1];
                }
                _oldPositions[0] = _spellOnHold.transform.position;
              //  Debugger.Log(_oldPositions[0].ToString());
           
           
        }
        #endregion
    }

}
