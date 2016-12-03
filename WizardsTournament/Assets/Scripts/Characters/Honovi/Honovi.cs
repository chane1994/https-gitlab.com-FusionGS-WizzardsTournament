﻿using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using System;

namespace WizardsTournament
{
    /// <summary>
    /// Contains logic and characteristics of Honovi
    /// </summary>
    public class Honovi : Character
    {
        FighterState _fighterState;

        public Honovi()
        {
            // create the class from the json NOde
            //  Name = data[L_NAME];
          
            Name = CharacterName.Honovi.ToString();
            _spells = new Dictionary<TypeOfAttack, SpellName>();
            _spells.Add(TypeOfAttack.BasicAttack, SpellName.Skull);
            _spells.Add(TypeOfAttack.SpecialAvility, SpellName.HologramTeleporter);
            _spells.Add(TypeOfAttack.UnBreakable, SpellName.SoulSteeler);
            _spells.Add(TypeOfAttack.SummonAttack, SpellName.DeathSummon);

            LeftArmPath = "Prefabs/Characters/Honovi/HonoviLeftHand";
            RightArmPath = "Prefabs/Characters/Honovi/HonoviRightHand";
            _fighterState = new HonoviNormalState();
        }

        #region Methods
        public override void ProcessInputCommand(InputCommand inputCommand)
        {
            _fighterState = _fighterState.HandleInput(inputCommand, leftSpellCaster, rightSpellCaster);
            /*
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    leftSpellCaster.CastBasicSpell(new ExpandibleSpellInfo(4, "Prefabs/Characters/Honovi/Spells/Skull", 1000,1,8)); //todo remove this by a real spell
                    break;
                case InputCommand.LeftTriggerReleased:
                    ((HonoviSpellCaster)leftSpellCaster).ThrowSpell();
                    break;
                case InputCommand.RightTriggerPressed:
                    rightSpellCaster.CastBasicSpell(new ExpandibleSpellInfo(4, "Prefabs/Characters/Honovi/Spells/Skull", 1000, 1, 8)); //todo remove this by a real spell
                    break;
                case InputCommand.RightTriggerReleased:
                    ((HonoviSpellCaster)rightSpellCaster).ThrowSpell();
                    break;
                case InputCommand.LeftTouchpadPressed:
                    break;
                case InputCommand.LeftTouchpadReleased:
                    break;
                case InputCommand.RightTouchpadPressed:
                    rightSpellCaster.ShowSeal();
                   
                    break;
                case InputCommand.RightTouchpadReleased:
                    Vector3 newPosition;
                    if (rightSpellCaster.TryToTeleport(out newPosition))
                    {
                        PlayerController.Instance.Teleport(newPosition);
                    }
                    break;
                case InputCommand.LeftGripPressed:
                    //todo activate the seal
                    break;
                case InputCommand.LeftGripReleased:
                    break;
                case InputCommand.RightGripReleased:
                
                    //tell the platforms that they have to hide the particle systems
                    //todo teleport
                    break;
                case InputCommand.RightGripPressed:
                    
                    break;
                default:
                    break;
            }
          */
        }
        #endregion
    }

}