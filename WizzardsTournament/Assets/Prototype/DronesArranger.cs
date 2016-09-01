using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class DronesArranger : MonoBehaviour
    {
        public GameObject drone;
        public int numberOfDrones;
        private GameObject[] currentDrones;
        public Transform positions;

        // Use this for initialization
        void Start()
        {
            //create drones
            for (int i = 0; i < numberOfDrones; i++)
            {
              //  currentDrones[i] = 
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
