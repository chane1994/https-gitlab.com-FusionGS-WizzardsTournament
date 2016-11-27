using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// It creates the spell game objects based on given data. It knows where to position the spell to make it look good.
    /// </summary>
    public class SpellCaster : MonoBehaviour
    {
        public Transform shotSpawnPositions;
        const string L_SEAL = "Seal";

        #region Methods
        public virtual void CastBasicSpell(SpellInfo spellInfo)
        {

            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spellInfo.PrefabPath));
            spellCreated.transform.position = shotSpawnPositions.position;
            Vector3 forward = shotSpawnPositions.forward.normalized;

            Spell spell = spellCreated.GetComponent<Spell>();
            spell.UpdateSpell(spellInfo);
            spellCreated.GetComponent<Rigidbody>().AddForce(forward * spell.Speed);

        }

        public bool TryToTeleport(out Vector3 newPosition)
        {

            return transform.Find(L_SEAL).gameObject.GetComponent<LaserPointer>().TryDeactivatePlatformLight(out newPosition);
        }

        public void ShowSeal()
        {
            transform.Find(L_SEAL).gameObject.SetActive(true); ;
        }
        #endregion
    }

}
