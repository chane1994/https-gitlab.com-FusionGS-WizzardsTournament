using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    public class HonoviChargingSkullState : FighterState
    {
        public override FighterState HandleInput(InputCommand inputCommand, SpellCaster leftSpellCaster, SpellCaster rightSpellCaster)
        {
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerReleased:
                    ((HonoviSpellCaster)leftSpellCaster).ThrowSpell();
                    return new HonoviNormalState();
          
                case InputCommand.RightTriggerReleased:
                    ((HonoviSpellCaster)rightSpellCaster).ThrowSpell();
                    return new HonoviNormalState();
                default:
                    return this;
            }
        }
    }

}
