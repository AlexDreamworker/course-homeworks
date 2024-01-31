using UnityEngine;

namespace Homework3.Task2
{
    public abstract class IconFactory
    {
        public abstract Sprite Get(IconType type);
    }
}