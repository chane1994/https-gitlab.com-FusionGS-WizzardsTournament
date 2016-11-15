using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

namespace WizardsTournament
{
    /// <summary>
    /// Describes the basic elements that any character should have.
    /// </summary>
    public abstract class Character //You will get the information for this class from a JSON file
    {
        #region Variables
        public SpellCaster leftSpellCaster; 
        public SpellCaster rightSpellCaster;
        protected Dictionary<TypeOfAttack, SpellName> _spells;
        #endregion

        #region Properties
        public string Name { get; protected set; }

        public string LeftArmPath { get; protected set; }

        public string RightArmPath { get; protected set; }

        #endregion

        public abstract void ProcessInputCommand(InputCommand inputCommand);
    }

}
