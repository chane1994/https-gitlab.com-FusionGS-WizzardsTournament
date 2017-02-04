using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the logic of spells who increase or decrease life, strength, or magic
    /// </summary>
    public class BoosterSummonSpell : Spell
    {
        public bool buffPlayer;
        public float destructionTime;
        Transform _targetTransform;
        Transform _playerHead;

        void Start()
        {
            //get the information from the referee to know where to position. You will get a transform
            _targetTransform = Referee.Instance.EnemyTransform;
            _playerHead = _targetTransform;
            if (buffPlayer)
            {
                _targetTransform = Referee.Instance.PlayerTransform;
                _playerHead = Referee.Instance.PlayerHead;
            }
            transform.position = new Vector3(_playerHead.position.x, _targetTransform.position.y, _playerHead.position.z);
            //todo it should buff the player or decrease the avility of the enemy
            DestroyObject(gameObject, destructionTime);
        }

        void Update() //todo I want the player to be able to look around a little bit without moving the spell. Just like the camera in Mario. 
        {
            transform.position = new Vector3(_playerHead.position.x, _targetTransform.position.y, _playerHead.position.z);
        }


    }

}
