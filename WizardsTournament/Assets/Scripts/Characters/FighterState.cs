using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public abstract class FighterState 
    {
        bool _readyToSummon;

        public abstract FighterState HandleInput(InputCommand inputCommand, SpellCaster leftSpellCaster, SpellCaster rightSpellCaster);
    }
}

