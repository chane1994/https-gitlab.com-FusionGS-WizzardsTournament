using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    public class HonoviTeleportingState : HandState
    {
        public override HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand )
        {
            switch (inputCommand)
            {
                case InputCommand.TouchpadReleased:
                    if (hand.Equals(Hand.Left))
                    {
                        return this;
                    }
                    else
                    {
                        Vector3 newPosition;
                        if (spellCaster.TryToTeleport(out newPosition))
                        {
                            PlayerController.Instance.Teleport(newPosition);
                        }

                        return new HonoviNormalState();
                    }
                    
                default:
                    return this;
            }
        }
    }

}
