using UnityEngine;

namespace Homework1.Task3 
{
    public class RaceChanger : MonoBehaviour
    {
        [SerializeField] private RaceType _typeToChange;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IRace race)) 
                race.SetNewRace(_typeToChange);
        }
    }
}