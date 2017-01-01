using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Handles all the logic of a symbol
    /// </summary>
    public class SymbolHandler : MonoBehaviour
    {
        public delegate void SymbolSummoner(Collider collider, Symbol symbol);
        public SymbolSummoner symbolSummonerEventHandler;
        public Symbol symbol;

        void OnTriggerEnter(Collider collider)
        {
            
          //  Debugger.Log(collider.gameObject.name);
            symbolSummonerEventHandler(collider, symbol);
        }

      
        
    }
}


