using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class Platform : MonoBehaviour
    {
        #region Variables
        public Transform spawningPosition; //todo modify this get it like you did with the teleportationIndicator
        GameObject _teleportationIndicator;
        const string TELEPORTATION_INDICATOR = "TeleportationIndicator";
        #endregion

        #region Methods
        void Start()
        {
            _teleportationIndicator = transform.FindChild(TELEPORTATION_INDICATOR).gameObject;
        }

        public void UpdateTeleportationIndicator(bool activate)
        {
            _teleportationIndicator.SetActive(activate);
        }
        #endregion

    }
}

