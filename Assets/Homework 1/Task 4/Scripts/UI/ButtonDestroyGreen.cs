using UnityEngine;

namespace Homework1.Task4
{
    public class ButtonDestroyGreen : ButtonBase
    {
        private const ColorType TARGET_COLOR = ColorType.Green;

        protected override void ButtonCallback()
        {
            base.ButtonCallback();
                
            _example.SetGameModeDestroyConcreteColor(TARGET_COLOR);
            _ui.ChangeGameModeInfo("GAME MODE: DESTROY GREEN");

            Debug.Log("Game Mode is: Destroy Green!");
        }
    }
}