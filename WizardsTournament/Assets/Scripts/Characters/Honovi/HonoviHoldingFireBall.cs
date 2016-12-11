using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    /// <summary>
    /// Controls what inputs are accepted when Honovi is holding the fireball to throw it
    /// </summary>
    public class HonoviHoldingFireBall : HandState
    {
        public override HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand)
        {
            switch (inputCommand)
            {
                case InputCommand.TriggerReleased:
                   ((HonoviSpellCaster)spellCaster).ThrowSpell();
                    return new HonoviNormalState();
                case InputCommand.TouchpadPressed:
                    if (hand.Equals(Hand.Left))
                    {
                        return this;
                    }
                    else
                    {
                        ((HonoviSpellCaster)spellCaster).DestroyCurrentSpell();
                        spellCaster.ShowSeal();
                        return new HonoviTeleportingState();
                    }
                        
                default:
                    return this;
            }
        }
    }

}
