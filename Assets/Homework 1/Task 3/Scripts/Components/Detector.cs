using System;
using UnityEngine;

namespace Homework1.Task3 
{
    [RequireComponent(typeof(Collider))]
    public class Detector : MonoBehaviour
    {
        public event Action<RaceType, IRace> TriggerDetected;

        [SerializeField] private RaceType _typeToChange;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IRace race)) 
                TriggerDetected?.Invoke(_typeToChange, race);
        }
    }
}