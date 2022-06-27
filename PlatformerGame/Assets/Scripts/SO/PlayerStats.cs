using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        [Header("Movement")]
        [Range(0,1f)] public float acceleration;
        public float maxSpeed;
        public float jumpYVelocity;
    }
}