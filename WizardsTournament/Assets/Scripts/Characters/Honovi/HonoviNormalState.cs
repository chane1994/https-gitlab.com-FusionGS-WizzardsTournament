using UnityEngine;
using System.Collections;
using System;

namespace WizardsTournament
{
    public class HonoviNormalState : HandState
    {
        public override HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand)
        {
            switch (inputCommand)
            {
                case InputCommand.TriggerPressed:
                    ((HonoviSpellCaster)spellCaster).CastThrowableSpell("Prefabs/Characters/Honovi/Spells/FireBall");//new SpellInfo(3000, "Prefabs/Characters/Honovi/Spells/FireBall", 6.5f,SpellName.Fireball));  //todo remove this and get the information from HOnovi.  12/10/2016
                    return new HonoviHoldingFireBall();
                case InputCommand.GripPressed:
                    if (hand.Equals(Hand.Left))
                    {
                        spellCaster.CastBasicSpell("Prefabs/Characters/Honovi/Spells/Skull");//new ExpandibleSpellInfo(4, "Prefabs/Characters/Honovi/Spells/Skull", 2000, 1, 8,SpellName.Skull)); //todo remove this and get the information from HOnovi 12/10/2016
                        return new HonoviChargingSkullState();
                    }
                    else
                    {
                        return this;
                    }
                case InputCommand.TouchpadPressed:
                    if (hand.Equals(Hand.Left))
                    {
                        spellCaster.ShowShield(true);
                        return new HonoviHoldingShieldState();
                    }
                    else
                    {
                        spellCaster.ShowSeal();
                        return new HonoviTeleportingState();
                    }
                   
                
                default:
                    return this;
            }
        }
    }

}
