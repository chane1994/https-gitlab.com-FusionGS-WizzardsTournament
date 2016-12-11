using UnityEngine;
using System.Collections;

namespace FusionGameStudios
{
    /// <summary>
    /// Util physics formulas
    /// </summary>
    public class Physics : MonoBehaviour
    {
        /// <summary>
        /// Calculates the average velocity of a displacement
        /// </summary>
        /// <param name="positions">All recorded positions of the displacement</param>
        /// <param name="samplefrequency">How frequently the positions are updated</param>
        /// <returns>The average velocity of a displacement</returns>
        public static float AverageVelocity(Vector3[] positions, float samplefrequency)
        {
            float averageVelocity = 0;
            for (int i = 0; i < positions.Length-1; i++)
            {
                averageVelocity+= Velocity(positions[i], positions[i + 1], samplefrequency);
            }
            return averageVelocity / (positions.Length - 1);
        }

        /// <summary>
        /// Calculates the velocity of a movement
        /// </summary>
        /// <param name="newPosition">Last position of the body in movement</param>
        /// <param name="oldPosition">Initial position of the body in movement</param>
        /// <param name="time">Time that took the body to go from oldPosition to newPosition</param>
        /// <returns>Velocity of a movement</returns>
        public static float Velocity(Vector3 newPosition, Vector3 oldPosition, float time)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(newPosition.x - oldPosition.x, 2) + Mathf.Pow(newPosition.y - oldPosition.y, 2) + Mathf.Pow(newPosition.z - oldPosition.z, 2));
            return distance / time;
        }
     
    }

}
