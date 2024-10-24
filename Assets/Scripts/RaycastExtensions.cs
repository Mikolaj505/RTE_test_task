using System;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public static class RaycastExtensions
    {
        /// <summary>
        /// More reliable than OnCollisionEnter, as the other might miss colliisions. 
        /// Also, commonly used in gamedev for that reason. 
        /// It's raycasting from previous position to current and checking if it had any collisions since last position update.
        /// </summary>
        /// <param name="previousPosition"></param>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public static Collider CheckForCollisionsSorted(Vector3 previousPosition, Vector3 currentPosition, RaycastHit[] hitResults)
        {
            Vector3 direction = currentPosition - previousPosition;
            float distance = direction.magnitude;

            int hitCount = Physics.RaycastNonAlloc(previousPosition, direction, hitResults, distance);

            if (hitCount == 0)
            {
                return null;
            }

            RaycastHit[] notNullRaycastHits = new RaycastHit[hitCount];
            int notNullCollidersIdx = 0;
            for (int i = 0; i < hitResults.Length; i++)
            {
                if (hitResults[i].collider != null)
                {
                    notNullRaycastHits[notNullCollidersIdx] = hitResults[i];
                    notNullCollidersIdx++;
                }
            }

            // Sort the hits based on distance from previousPosition.
            Array.Sort(notNullRaycastHits, (a, b) => a.distance.CompareTo(b.distance));
            var firstHit = notNullRaycastHits[0];


            return firstHit.collider;
        }
    }
}
