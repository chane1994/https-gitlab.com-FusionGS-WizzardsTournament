using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class Spell : MonoBehaviour
    {
        #region Variables
        //  SpellInfo _spellInfo;
        #endregion

        #region Properties
        //public virtual float Speed { get { return _spellInfo.Speed; } }

        public SpellName Name;// { get; protected set; }

        public float HitPower;

       // public string PrefabPath { get; protected set; }

        public float Speed;
        #endregion

        #region Methods
        //public virtual void UpdateSpell(SpellInfo spellInfo)
        //{
        //    _spellInfo = spellInfo;
        //}

       
        #endregion
    }

}
