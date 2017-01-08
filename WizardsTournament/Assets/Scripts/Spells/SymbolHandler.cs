using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Handles all the logic of a symbol
    /// </summary>
    public class SymbolHandler : MonoBehaviour
    {
        public delegate void SymbolSummoner(SymbolHandler symbolHandler, Collider collider);
        public SymbolSummoner symbolSummonerEventHandler;
        public Symbol symbol;

        /// <summary>
        /// Triggers all the events that are subscribed to symbolSummonerEventHandler and deactivates its MeshCollider
        /// </summary>
        /// <param name="collider">Collider component of the GameObject that hit the MeshCollider in this GameObject</param>
        void OnTriggerEnter(Collider collider)
        {
            symbolSummonerEventHandler(this, collider);
            GetComponent<MeshCollider>().enabled = false;
        }

      
        
    }
}


