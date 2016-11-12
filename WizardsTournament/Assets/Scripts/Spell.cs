using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the information needed to create a spell
    /// </summary>
    public class Spell 
    {
        #region Properties
        public float HitPower { get; private set; }

        public string PrefabPath { get; private set; }

        public float Speed { get; private set; }
        #endregion

        public Spell(float hitPower, string prefabPath, float speed)
        {
            HitPower = hitPower;
            PrefabPath = prefabPath;
            Speed = speed;
        }
       
    }

}
