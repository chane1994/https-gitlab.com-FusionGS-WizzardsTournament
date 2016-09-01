using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class SpellsThrowerHandler : MonoBehaviour
    {

        public Transform spellsSpawningPosition;
        public Rigidbody spell;
        public float force;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Rigidbody currentSpell = Instantiate(spell,spellsSpawningPosition.position,spellsSpawningPosition.rotation) as Rigidbody;
                currentSpell.AddForce(currentSpell.transform.forward * force);
            }
        }
    }

}
