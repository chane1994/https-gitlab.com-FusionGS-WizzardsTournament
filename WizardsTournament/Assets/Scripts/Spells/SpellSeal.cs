using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the logic of a SpellSeal. It decides when to disappear the spell and has the valid states.
    /// </summary>
    public class SpellSeal : MonoBehaviour
    {
        #region Variables
        public Collider[] validColliders;
        SymbolHandler _firstSymbolHandler;
        protected float lifeTime = 8;
        StringBuilder _currentCombination;
        protected KeyValuePair<string, ISummonable>[] _validCombinations;
        bool _activateFirstSymbol = false;
        #endregion

        #region Methods
        void Start()
        {
            //TODO populate the validCombinations array
            _validCombinations = new KeyValuePair<string, ISummonable>[2] { new KeyValuePair<string, ISummonable>("LightFireLight",null), new KeyValuePair<string, ISummonable>("StrengthFireLightStrength", null) };

            Invoke("DestroySpellSeal", lifeTime);
            //   
            SymbolHandler[] symbolHandlers = GetComponentsInChildren<SymbolHandler>();
            for (int i = 0; i < symbolHandlers.Length; i++)
            {
                symbolHandlers[i].symbolSummonerEventHandler = new SymbolHandler.SymbolSummoner(OnSymbolSelected);
            }
        }

        protected void DestroySpellSeal()
        {
            //It would play an animation
            Destroy(gameObject);
        }

        /// <summary>
        /// Determines what to do when the player touches one of the symbols
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="symbol">Symbol of the trigger that was touched</param>
        void OnSymbolSelected(SymbolHandler symbolHandler, Collider collider) 
        {
            if(validColliders[0].Equals(collider) || validColliders[1].Equals(collider)) //avoids that the seal activates with something different than the summoner's hands
            {
                if (_firstSymbolHandler == null)
                {
                    _firstSymbolHandler = symbolHandler;
                    _currentCombination = new StringBuilder(symbolHandler.symbol.ToString());
                    _activateFirstSymbol = true;
                }
                else
                {
                    _currentCombination.Append(symbolHandler.symbol.ToString());
                    if (_activateFirstSymbol)
                    {
                        _firstSymbolHandler.GetComponent<MeshCollider>().enabled = true;
                        _activateFirstSymbol = false;
                    }
                    //check to see if it is the first symbol handler
                    if (symbolHandler.Equals(_firstSymbolHandler))
                    {
                        TrySummonSpell();
                    }
                }
                Debugger.Log(symbolHandler.symbol.ToString());
            }
        }

        /// <summary>
        /// Compares the current combination to all the valid ones and executes the ISummonable if it finds a match.
        /// </summary>
        void TrySummonSpell()
        {
            string currentCombination = _currentCombination.ToString();
            for (int i = 0; i < _validCombinations.Length; i++)
            {
                if (currentCombination.Equals(_validCombinations[i].Key))
                {
                    Debugger.Log("It is a valid combination");
                   // _validCombinations[i].Value.Activate();
                    break;
                }
            }

            DestroySpellSeal();
        }
        #endregion
    }

}
