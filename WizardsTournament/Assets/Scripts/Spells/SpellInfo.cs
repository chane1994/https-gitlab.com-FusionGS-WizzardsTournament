using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the information needed to create a spell
    /// </summary>
    public class SpellInfo 
    {
        #region Properties
        public float HitPower { get; protected set; }

        public string PrefabPath { get; protected set; }

        public float Speed { get; protected set; }
        #endregion

        public SpellInfo(float hitPower, string prefabPath, float speed)
        {
            HitPower = hitPower;
            PrefabPath = prefabPath;
            Speed = speed;
        }
       
    }

}
