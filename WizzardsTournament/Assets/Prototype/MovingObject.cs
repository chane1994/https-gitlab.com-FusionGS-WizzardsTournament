using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class MovingObject : MonoBehaviour
    {
        public int originalCount = 100;
         int count = 30;
        public Vector3 addition;
        int direction = 1;

        // Update is called once per frame
        void Update()
        {
            count--;
            transform.position = new Vector3(transform.position.x + addition.x, transform.position.y + addition.y, transform.position.z + addition.z);
            if (count < 0)
            {
                count = originalCount;
                direction *= -1;
                addition = addition *direction;
            }
        }
    }

}
