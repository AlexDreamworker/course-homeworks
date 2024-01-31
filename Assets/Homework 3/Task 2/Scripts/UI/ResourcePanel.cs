using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Homework3.Task2
{
    public class ResourcePanel : MonoBehaviour
    {
        [SerializeField] private Image _coin;
        [SerializeField] private Image _energy;

        public void SetSprites(Dictionary<IconType, Sprite> iconsMap) 
        {
            _coin.sprite = iconsMap[IconType.Coin];
            _energy.sprite = iconsMap[IconType.Energy];
        }
    }
}