using UnityEngine;

namespace Homework1.Task4
{
    public class ButtonDestroyWhite : ButtonBase
    {
        private const ColorType TARGET_COLOR = ColorType.White;

        protected override void ButtonCallback()
        {
            base.ButtonCallback();
                
            _conditionSwitcher.SetDestroyConcreteColor(TARGET_COLOR);
            _ui.ChangeGameModeInfo("GAME MODE: DESTROY WHITE");

            Debug.Log("Game Mode is: Destroy White!");
        }
    }
}