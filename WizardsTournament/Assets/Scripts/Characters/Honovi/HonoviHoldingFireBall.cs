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
                    if (hand.Equals(Hand.Left))
                    {
                        ((HonoviSpellCaster)spellCaster).ThrowSpell(PlayerController.Instance.leftController.GetComponent<PlayerInputHandler>());
                    }
                    else
                    {
                        ((HonoviSpellCaster)spellCaster).ThrowSpell(PlayerController.Instance.rightController.GetComponent<PlayerInputHandler>());
                    }
                    spellCaster.GetComponent<Collider>().enabled = true;
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
                        PlayerController.Instance.UpdateHandColliders(false);
                        return new HonoviTeleportingState();
                    }
                        
                default:
                    return this;
            }
        }
    }

}
