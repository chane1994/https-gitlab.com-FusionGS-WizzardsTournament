using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Spell that will be thrown based on the speed of the hand
    /// </summary>
    public class ThrowableSpell : Spell
    {
        Vector3[] _oldPositions;
        Rigidbody _rigidBody;
        int _positionIndex = 0;
        const float SAMPLING_FREQUENCY = 0.03F;
        //one method to indicate that the ball is free

        //one method to save the position and in the second one it will give the impulse



        // Use this for initialization
        void Start()
        {
            _oldPositions = new Vector3[2];
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Release()
        {
            InvokeRepeating("UpdatePosition", 0f, SAMPLING_FREQUENCY);
        }

        /// <summary>
        /// It will save the position of the spell
        /// </summary>
        private void UpdatePosition()
        {
            _oldPositions[_positionIndex] = transform.position;
            _positionIndex++;

            if (_positionIndex > 1)
            {
                Move();
            }
            
        }

        public void Move()
        {
            CancelInvoke("UpdatePosition");
            Vector3 direction = _oldPositions[0] - _oldPositions[1];
            float velocity = FusionGameStudios.Physics.AverageVelocity(_oldPositions, SAMPLING_FREQUENCY);
            Debug.Log(velocity);
            _rigidBody.AddForceAtPosition(direction.normalized * velocity * (-Speed), Vector3.zero, ForceMode.Impulse);
            Debug.Log(velocity);
        }

    }

}
