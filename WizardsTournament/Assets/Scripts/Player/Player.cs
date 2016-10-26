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

        public SpellCaster leftSpellCaster; //dummy this does not go here. It goes to the character script
        public SpellCaster rightSpellCaster; //dummy this does not go here. It goes to the character script
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

        /// <summary>
        /// Receives the information from the inputhandler and sends it to the statemachine to be processed
        /// </summary>
        /// <param name="inputCommand"></param>
        public void ProcessInput(InputCommand inputCommand)
        {
            #region Dummy code for fast setup
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    leftSpellCaster.CastSpell(new Spell(4,"Prefabs/Spells/Spell",1000));
                    break;
                case InputCommand.LeftTriggerReleased:
                    break;
                case InputCommand.RightTriggerPressed:
                    rightSpellCaster.CastSpell(new Spell(4, "Prefabs/Spells/Spell", 1000));
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
            #endregion
        }
        #endregion
    }
}

