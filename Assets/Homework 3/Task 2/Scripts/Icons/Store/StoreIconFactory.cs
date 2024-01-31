using System;
using UnityEngine;

namespace Homework3.Task2
{
    public class StoreIconFactory : IconFactory
    {
        public override Sprite Get(IconType formType)
        {
            switch (formType) 
            {
                case IconType.Coin:
                    return new CoinStoreIcon().GetSprite();
                case IconType.Energy:
                    return new EnergyStoreIcon().GetSprite();

                default:
                    throw new ArgumentException($"Unknown form type: {formType}");
            }
        }
    }
}