using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using System;

namespace WizardsTournament
{
    /// <summary>
    /// Contains information about Honovi. 
    /// </summary>
    public class Honovi : Character
    {
        HandState _leftHandState; //Determines the behaviour of this fighter
        HandState _rightHandState;

        public Honovi()
        {
            // create the class from the json NOde
            //  Name = data[L_NAME];
          
            Name = CharacterName.Honovi.ToString();
            //_spells = new Dictionary<TypeOfAttack, SpellName>();
            //_spells.Add(TypeOfAttack.BasicAttack, SpellName.Skull);
            //_spells.Add(TypeOfAttack.SpecialAvility, SpellName.HologramTeleporter);
            //_spells.Add(TypeOfAttack.UnBreakable, SpellName.SoulSteeler);
            //_spells.Add(TypeOfAttack.SummonAttack, SpellName.DeathSummon);

            LeftArmPath = "Prefabs/Characters/Honovi/HonoviLeftHand";
            RightArmPath = "Prefabs/Characters/Honovi/HonoviRightHand";
            _leftHandState = new HonoviNormalState();
            _rightHandState = new HonoviNormalState();
        }

        #region Methods
        public override void ProcessInputCommand(InputCommand inputCommand, Hand hand)
        {
            if (hand.Equals(Hand.Left) )
            {
                if (!(_rightHandState is HonoviTeleportingState))
                {
                    _leftHandState = _leftHandState.HandleInput(inputCommand, leftSpellCaster, hand);
                }
            }
            else
            {
                _rightHandState = _rightHandState.HandleInput(inputCommand, rightSpellCaster,hand);
                if (_rightHandState is HonoviTeleportingState)
                {
                    _leftHandState = new HonoviNormalState();
                    ((HonoviSpellCaster)leftSpellCaster).DestroyCurrentSpell();
                }
            }
            
        }
        #endregion
    }

}
