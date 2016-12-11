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
        public SpellName Name { get; protected set; }

        public float HitPower { get; set; }

        public string PrefabPath { get; protected set; }

        public float Speed { get; set; }
        #endregion

        public SpellInfo(float hitPower, string prefabPath, float speed, SpellName name)
        {
            HitPower = hitPower;
            PrefabPath = prefabPath;
            Speed = speed;
            Name = name;
        }
       
    }

}
