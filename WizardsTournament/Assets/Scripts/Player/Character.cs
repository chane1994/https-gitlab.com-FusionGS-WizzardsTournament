using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Describes the basic elements that any character should have.
    /// </summary>
    public class Character //You will get the information for this class from a JSON file
    {
        #region Variables
        public SpellCaster[] spellcasters;
        #endregion
        //state 
        //power
        //moves

        #region DummyCode for easy setup
        public void ProcessInputCommand(InputCommand inputCommand)
        {

        }
        #endregion
    }

}
