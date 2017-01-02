using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Represents all spells, creatures, or avilities that can be summoned using the spell seal 
    /// </summary>
    public interface ISummonable
    {
         void Activate();
    }

}
