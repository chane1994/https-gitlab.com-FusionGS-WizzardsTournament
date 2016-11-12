using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public class SpellHandler : MonoBehaviour
    {
        private Spell _spell;

        public void UpdateSpell(Spell spell)
        {
            _spell = spell;
        }
    }

}
