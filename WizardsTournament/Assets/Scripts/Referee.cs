using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Determines the damage of attacks and decides who wins
    /// </summary>
    public class Referee : MonoBehaviour
    {
        #region Variables
        //Transform _playerTransform;
        //Transform _enemyTransform;
        const string PLAYER_TAG = "Player";
        const string ENEMY_TAG = "Enemy";
        #endregion

        #region Properties
        /// <summary>
        /// Returns the only instance of the referee
        /// </summary>
        public static Referee Instance { get; private set; }

        /// <summary>
        /// Returns the transform component of the player
        /// </summary>
        public Transform EnemyTransform
        {
            get
            {
                return GameObject.FindGameObjectWithTag(ENEMY_TAG).transform;
            }
            //private set
            //{
            //    _enemyTransform = value;
            //}
        }

        /// <summary>
        /// Returns the transform component of the player
        /// </summary>
        public Transform PlayerTransform
        {
            get
            {
                return GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
            }
            //private set
            //{
            //    _playerTransform = value;
            //}
        }

        public Transform PlayerHead
        {
            get
            {
                return PlayerController.Instance.GetHead;
            }
            //private set
            //{
            //    _playerTransform = value;
            //}
        }
        #endregion

        #region Methods
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //void Start()
        //{
        //    PlayerTransform = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
        //    EnemyTransform = GameObject.FindGameObjectWithTag(ENEMY_TAG).transform;
        //}

        /// <summary>
        /// Destroys the referee when the player goes back to the locker room
        /// </summary>
        public void DestroyReferee()
        {
            Instance = null;
            Destroy(gameObject);
        }


        #endregion
    }

}
