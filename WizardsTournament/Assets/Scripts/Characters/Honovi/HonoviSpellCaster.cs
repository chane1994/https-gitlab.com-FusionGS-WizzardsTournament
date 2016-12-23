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
        FixedJoint _joint;
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
        public override void CastBasicSpell(string spellPath)
        {
            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellPath));
            spellCreated.transform.parent = transform;
            Spell spell = spellCreated.GetComponent<Spell>();
            if (spell.Name.Equals(SpellName.Skull))
            {
                spellCreated.transform.position = shotSpawnPositions.position;
            }
            else
            {
                spellCreated.transform.position = fireballSpawnPoint.position;
            }




            // spell.UpdateSpell(spellInfo);
            _spellOnHold = spell;
        }


        /// <summary>
        /// Creates a spell that will be thrown later on.
        /// </summary>
        /// <param name="spellInfo">Information to create the spell</param>
        public virtual void CastThrowableSpell(string spellPath)
        {
            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellPath));
            //  var go = GameObject.Instantiate(prefab);
            spellCreated.transform.position = fireballSpawnPoint.position;

            _joint = spellCreated.AddComponent<FixedJoint>();
            _joint.connectedBody = fireballSpawnPoint.GetComponent<Rigidbody>();
            _spellOnHold = spellCreated.GetComponent<Spell>();
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
            ShowShield(false);
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
        public virtual void ThrowSpell(PlayerInputHandler inputHandler)
        {
            var go = _joint.gameObject;
            var rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(_joint);
            _joint = null;
            Object.Destroy(go, 15.0f);

            ((ThrowableSpell)_spellOnHold).Release(); //todo modify the spell


            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.
            //SteamVR_TrackedObject trackedObj = PlayerController.Instance.leftController.GetComponent<SteamVR_TrackedObject>();
            var origin = inputHandler.TrackedObject.origin ? inputHandler.TrackedObject.origin : inputHandler.TrackedObject.transform.parent;
            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(inputHandler.Device.velocity);
                rigidbody.angularVelocity = origin.TransformVector(inputHandler.Device.angularVelocity);
            }
            else
            {
                rigidbody.velocity = inputHandler.Device.velocity;
                rigidbody.angularVelocity = inputHandler.Device.angularVelocity;
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
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


        }
        #endregion
    }

}
