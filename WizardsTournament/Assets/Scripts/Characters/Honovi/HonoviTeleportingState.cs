using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    public class HonoviTeleportingState : FighterState
    {
        public override FighterState HandleInput(InputCommand inputCommand, SpellCaster leftSpellCaster, SpellCaster rightSpellCaster)
        {
            switch (inputCommand)
            {
                case InputCommand.RightTouchpadReleased:
                    Vector3 newPosition;
                    if (rightSpellCaster.TryToTeleport(out newPosition))
                    {
                        PlayerController.Instance.Teleport(newPosition);
                    }
                    return new HonoviNormalState();
                default:
                    return this;
            }
        }
    }

}
