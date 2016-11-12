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

        public void CastSpell(Spell spell)
        {

            GameObject spellCreated = Instantiate(Resources.Load<GameObject>(spell.PrefabPath));
            spellCreated.transform.position = shotSpawnPositions.position;
            Vector3 forward = shotSpawnPositions.forward.normalized;
            spellCreated.GetComponent<Rigidbody>().AddForce(forward * spell.Speed);
        }
    }

}
