using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It is responsible for the actions of the player. It will distribute the orders to different classes depending on what needs to be done. This class will keep everything in order if the player changes avatars.
    /// </summary>
    public class Player : MonoBehaviour// This class is independent of the avatar. 
    {
        #region Variables
        //state
        #endregion

        #region Properties
        public static Player Instance { get; private set; }
        #endregion

        #region Methods
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

     
        #endregion
    }
}

