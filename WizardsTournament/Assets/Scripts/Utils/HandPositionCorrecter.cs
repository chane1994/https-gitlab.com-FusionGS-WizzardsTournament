using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WizardsTournament
{
    /// <summary>
    /// Adjusts the rotation and position of the model of the hands of a character
    /// </summary>
    public class HandPositionCorrecter : MonoBehaviour
    {
        #region Variables
        public Transform[] handCorrectPositions;
        public Hand hand;
        Dictionary<CharacterName, int> _handPositionIndexes;
        #endregion

        #region Methods
        void Awake()
        {
            _handPositionIndexes = new Dictionary<CharacterName, int>();
            _handPositionIndexes.Add(CharacterName.Honovi, 0);
            _handPositionIndexes.Add(CharacterName.Vulcan, 1);
            _handPositionIndexes.Add(CharacterName.Angel, 2);
        }

        public void UpdateHand(CharacterName characterName)
        {
            GameObject o = GameObject.FindGameObjectWithTag(hand.ToString());
            o.transform.position = handCorrectPositions[_handPositionIndexes[characterName]].position;
            o.transform.rotation = handCorrectPositions[_handPositionIndexes[characterName]].rotation;
        }
        #endregion

    }
}

