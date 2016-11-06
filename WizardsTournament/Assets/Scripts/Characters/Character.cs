using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WizardsTournament
{
    /// <summary>
    /// Describes the basic elements that any character should have.
    /// </summary>
    public class Character //You will get the information for this class from a JSON file
    {
        #region Variables
        public SpellCaster[] spellcasters;
        //StateMachine
        string[] armsPrefabPath;
        Dictionary<TypeOfAttack, SpellName> _spells;
        #endregion

        #region Properties
        public string Name { get; private set; }
        #endregion

        #region DummyCode for easy setup
        public Character()
        {
            //these comes from a JSON FIle
            Name = "Honovi";
            _spells = new Dictionary<TypeOfAttack, SpellName>();
            _spells.Add(TypeOfAttack.BasicAttack,SpellName.Skull);
            _spells.Add(TypeOfAttack.SpecialAvility, SpellName.HologramTeleporter);
            _spells.Add(TypeOfAttack.UnBreakable, SpellName.SoulSteeler);
            _spells.Add(TypeOfAttack.SummonAttack, SpellName.DeathSummon);
        }

        public void ProcessInputCommand(InputCommand inputCommand)//this method will pass the input command to the state machine. For now this will have a switch
        {
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    break;
                case InputCommand.LeftTriggerReleased:
                    break;
                case InputCommand.RightTriggerPressed:
                    break;
                case InputCommand.RightTriggerReleased:
                    break;
                case InputCommand.LeftTouchpadPressed:
                    break;
                case InputCommand.LeftTouchpadReleased:
                    break;
                case InputCommand.RightTouchpadPressed:
                    break;
                case InputCommand.RightTouchpadReleased:
                    break;
                case InputCommand.LeftGripPressed:
                    break;
                case InputCommand.RightGripPressed:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}
