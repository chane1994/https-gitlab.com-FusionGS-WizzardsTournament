using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    public class HonoviNormalState : FighterState
    {
        public override FighterState HandleInput(InputCommand inputCommand, SpellCaster leftSpellCaster, SpellCaster rightSpellCaster)
        {
            switch (inputCommand)
            {
                case InputCommand.LeftTriggerPressed:
                    leftSpellCaster.CastBasicSpell(new ExpandibleSpellInfo(4, "Prefabs/Characters/Honovi/Spells/Skull", 1000, 1, 8)); //todo remove this by a real spell
                    return new HonoviChargingSkullState();
                case InputCommand.RightTriggerPressed:
                    rightSpellCaster.CastBasicSpell(new ExpandibleSpellInfo(4, "Prefabs/Characters/Honovi/Spells/Skull", 1000, 1, 8)); //todo remove this by a real spell
                    return new HonoviChargingSkullState();
                case InputCommand.RightTouchpadPressed:
                    rightSpellCaster.ShowSeal();
                    return new HonoviTeleportingState();
                default:
                    return this;
            }
        }
    }

}
