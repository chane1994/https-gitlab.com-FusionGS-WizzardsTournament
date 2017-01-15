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
        void Start()
        {
            //get the information from the referee to know where to position. You will get a transform
            Transform targetTransform = Referee.Instance.PlayerTransform;
            if (!buffPlayer)
            {
                targetTransform = Referee.Instance.EnemyTransform;
            }
            transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z);
            //todo it should buff the player or decrease the avility of the enemy

            DestroyObject(gameObject, destructionTime);
        }

    }

}
