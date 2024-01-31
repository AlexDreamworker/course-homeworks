using UnityEngine;

namespace Homework3.Task2
{
    public class CoinMenuIcon : Icon
    {
        private readonly string IconPath = "Homework 3/Task 2/CoinMenu";

        public override Sprite GetSprite()
        {
            return Resources.Load<Sprite>(IconPath);
        }
    }
}