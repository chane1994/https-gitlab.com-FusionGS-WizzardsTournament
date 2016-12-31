using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the logic of a SpellSeal. It decides when to disappear the spell and has the valid states.
    /// </summary>
    public class SpellSeal : MonoBehaviour
    {
        SymbolHandler[] _symbolHandlers;
        int _firstSymbolindex = -1;

        protected float lifeTime = 8;

        void Start()
        {
            Invoke("DestroySpellSeal", lifeTime);
            //   
            _symbolHandlers = GetComponentsInChildren<SymbolHandler>();
            for (int i = 0; i < _symbolHandlers.Length; i++)
            {
                _symbolHandlers[i].symbolSummonerEventHandler = new SymbolHandler.SymbolSummoner(OnSymbolSelected);
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
        void OnSymbolSelected(Collider collider, Symbol symbol)
        {

            for (int i = 0; i < _symbolHandlers.Length; i++) //find the selected symbol and deactivate the trigger
            {
                if (_symbolHandlers[i].symbol.Equals(symbol))
                {

                    if (_firstSymbolindex < 0) //if it was the first one save the index because it will be activated later
                    {
                        _firstSymbolindex = i;
                    }
                    else
                    {
                        _symbolHandlers[_firstSymbolindex].GetComponent<MeshCollider>().enabled = true;
                    }

                    _symbolHandlers[i].GetComponent<MeshCollider>().enabled = false;
                    break;
                }
            }


            Debugger.Log(symbol.ToString());
        }
    }

}
