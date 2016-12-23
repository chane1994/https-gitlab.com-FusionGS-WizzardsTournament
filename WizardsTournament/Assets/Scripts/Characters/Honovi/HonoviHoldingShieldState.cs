using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class HonoviHoldingShieldState : HandState
    {
        public override HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand)
        {
            switch (inputCommand)
            {
                case InputCommand.TouchpadReleased:
                    if (hand.Equals(Hand.Left))
                    {
                        spellCaster.ShowShield(false);
                        return new HonoviNormalState();
                    }
                    else
                    {
                        return this;
                    }

                default:
                    return this;
            }
        }
    }

}
