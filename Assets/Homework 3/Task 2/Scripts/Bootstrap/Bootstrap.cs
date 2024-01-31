using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework3.Task2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ResourcePanel _resourcePanel;
        
        [Space]
        [SerializeField] private SceneType _sceneType;

        [ContextMenu("BuildIcons")]
        private void SetIcons()
        {
            IconFactory iconFactory;

            switch (_sceneType) 
            {
                case SceneType.Menu:
                    iconFactory = new MenuIconFactory();
                    break;
                case SceneType.Store:
                    iconFactory = new StoreIconFactory();
                    break;

                default:
                    throw new ArgumentException($"Unknown icon form type: {_sceneType}");   
            }

            Dictionary<IconType, Sprite> iconsMap = new Dictionary<IconType, Sprite>() 
            {
                { IconType.Coin, iconFactory.Get(IconType.Coin) },
                { IconType.Energy, iconFactory.Get(IconType.Energy) }
            };

            _resourcePanel.SetSprites(iconsMap);
        }
    }
}