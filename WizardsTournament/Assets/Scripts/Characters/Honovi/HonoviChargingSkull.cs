using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    /// <summary>
    /// Controls what inputs are accepted when Honovi is holding the skull to throw it
    /// </summary>
    public class HonoviChargingSkullState : HandState
    {
        public override HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand)
        {
            switch (inputCommand)
            {
                case InputCommand.GripReleased:
                    if (hand.Equals(Hand.Left))
                    {
                        ((HonoviSpellCaster)spellCaster).ImpulseSpell();
                        spellCaster.GetComponent<Collider>().enabled = true;
                        return new HonoviNormalState();
                    }
                    else
                    {
                        return this;
                    }
                case InputCommand.TouchpadPressed:
                    if (hand.Equals(Hand.Left))
                    {
                        return this;
                    }
                    else
                    {
                        ((HonoviSpellCaster)spellCaster).DestroyCurrentSpell();
                        spellCaster.ShowSeal();
                        PlayerController.Instance.UpdateHandColliders(false);
                        return new HonoviTeleportingState();
                    }
                default:
                    return this;
            }
        }
    }

}
