using System;
using UnityEngine;

namespace Homework3.Task2
{
    public class MenuIconFactory : IconFactory
    {
        public override Sprite Get(IconType type)
        {
            switch (type) 
            {
                case IconType.Coin:
                    return new CoinMenuIcon().GetSprite();
                case IconType.Energy:
                    return new EnergyMenuIcon().GetSprite();

                default:
                    throw new ArgumentException($"Unknown form type: {type}");
            }
        }
    }
}