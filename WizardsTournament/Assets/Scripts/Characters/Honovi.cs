using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using System;

namespace WizardsTournament
{
    public class Honovi : Character
    {


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

            LeftArmPath = "Prefabs/Characters/Honovi/ModelLeft";
            RightArmPath = "Prefabs/Characters/Honovi/ModelRight";
        }

        #region Methods
        public override void ProcessInputCommand(InputCommand inputCommand)
        {
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    leftSpellCaster.CastSpell(new Spell(4, "Prefabs/Spells/Spell", 1000));
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
        }
        #endregion
    }

}
