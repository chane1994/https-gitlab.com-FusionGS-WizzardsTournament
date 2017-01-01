using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It creates the spell game objects based on given data. It knows where to position the spell to make it look good.
    /// </summary>
    public class SpellCaster : MonoBehaviour
    {
        #region Variables
        public Transform shotSpawnPositions;
        public GameObject shield;
        public GameObject teleportationSeal;
        public Transform spellSealSpawningPoint;
        const string L_SEAL = "Seal";
    
        #endregion

        #region Methods
        //public virtual void CastBasicSpell(SpellInfo spellInfo)
        //{

        //    GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellInfo.PrefabPath));
        //    spellCreated.transform.position = shotSpawnPositions.position;
        //    Vector3 forward = shotSpawnPositions.forward.normalized;

        //    Spell spell = spellCreated.GetComponent<Spell>();
        //    spell.UpdateSpell(spellInfo);
        //    spellCreated.GetComponent<Rigidbody>().AddForce(forward * spell.Speed);

        //}

        public virtual void CastBasicSpell(string spellPath)
        {

            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellPath));
            spellCreated.transform.position = shotSpawnPositions.position;
            Vector3 forward = shotSpawnPositions.forward.normalized;

            Spell spell = spellCreated.GetComponent<Spell>();
           // spell.UpdateSpell(spellInfo);
            spellCreated.GetComponent<Rigidbody>().AddForce(forward * spell.Speed);

        }

        public bool TryToTeleport(out Vector3 newPosition)
        {
          //  transform.Find(L_SEAL).gameObject.SetActive(false);
          return teleportationSeal.GetComponent<LaserPointer>().TryDeactivatePlatformLight(out newPosition);
            //return transform.Find(L_SEAL).gameObject.GetComponent<LaserPointer>().TryDeactivatePlatformLight(out newPosition);
        }

        /// <summary>
        /// Activates the game object that has the teleportation seal
        /// </summary>
        public void ShowSeal()
        {
            teleportationSeal.SetActive(true);
           // transform.Find(L_SEAL).gameObject.SetActive(true); 
        }

        /// <summary>
        /// Activate the shield game object
        /// </summary>
        public void ShowShield(bool activate)//todo this will probably change when you add the hit power to the shield and spells
        {
            shield.SetActive(activate);
        }

        public void ActivateSpellSeal(string spellSealPath)
        {
            GameObject spellSeal = Instantiate(Resources.Load<GameObject>(spellSealPath));
            spellSeal.transform.position = spellSealSpawningPoint.position;
            spellSeal.transform.rotation = spellSealSpawningPoint.rotation;
            spellSeal.GetComponent<SpellSeal>().validColliders = PlayerController.Instance.GetHandColliders();

        }
        #endregion
    }

}
