using UnityEngine;

namespace Homework3.Task2
{
    public class EnergyStoreIcon : Icon
    {
        private readonly string IconPath = "Homework 3/Task 2/EnergyStore";

        public override Sprite GetSprite()
        {
            return Resources.Load<Sprite>(IconPath);
        }
    }
}