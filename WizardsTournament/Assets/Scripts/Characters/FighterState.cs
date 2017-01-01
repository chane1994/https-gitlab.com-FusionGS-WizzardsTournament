using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public abstract class HandState 
    {
        bool _readyToSummon;

        public abstract HandState HandleInput(InputCommand inputCommand, SpellCaster spellCaster, Hand hand);
    }
}

