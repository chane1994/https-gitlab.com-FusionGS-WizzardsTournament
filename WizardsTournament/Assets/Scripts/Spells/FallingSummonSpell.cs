using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    /// <summary>
    /// Contains the logic of a spell that will be summon and will fall on the enemy's head
    /// </summary>
    public class FallingSummonSpell : Spell
    {
        #region Variables
        public float height;
        GameObject explotion;
        #endregion
        /*
        void Start()
        {
            //get the information from the referee to know where to position. You will get a transform
            Transform targetTransform = GameObject.Find("Enemy").transform; //todo replace for a call to the referee
            transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y + height, targetTransform.position.z);
            _spellBody = transform.GetChild(0).gameObject;
            _spellBody.SetActive(true);
            _spellBody.GetComponent<Rigidbody>().AddForce(transform.up * -Speed,ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision collision)
        {
            _spellBody.SetActive(false);
            Debugger.Log("THe falling skull hit " + collision.rigidbody.gameObject.name);
            //todo activate the particle system
           // collision.rigidbody.gameObject
            DestroyObject(gameObject);
        }
        */

        void Start()
        {
            //get the information from the referee to know where to position. You will get a transform
            Transform targetTransform = GameObject.Find("Enemy").transform; //todo replace for a call to the referee
            transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y + height, targetTransform.position.z);
            explotion = transform.GetChild(0).gameObject;
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
           // _spellBody.SetActive(true);
            GetComponent<Rigidbody>().AddForce(transform.up * -Speed, ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision collision)
        {
            //_spellBody.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Debugger.Log("THe falling skull hit " + collision.rigidbody.gameObject.name);
            //todo activate the particle system
            // collision.rigidbody.gameObject
            explotion.SetActive(true);
            DestroyObject(gameObject,0.6f);
        }
    }

}
