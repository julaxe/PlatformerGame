using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "AttackValues", menuName = "Global/AttackValues", order = 0)]
    public class AttackValues : ScriptableObject
    {
        public float range; //from which distance is gonna start attacking (for AI)
        public float cooldown;
        public float hitDistance; // how close the hit has to be to count.
    }
}