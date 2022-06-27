using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "VectorSO", menuName = "Global/VectorSO", order = 0)]
    public class VectorSO : ScriptableObject
    {
        public Vector2 position;
    }
}