using UnityEngine;

namespace Homework1.Task4
{
    public class ButtonDestroyRed : ButtonBase
    {
        private const ColorType TARGET_COLOR = ColorType.Red;

        protected override void ButtonCallback()
        {
            base.ButtonCallback();
                
            _conditionSwitcher.SetDestroyConcreteColor(TARGET_COLOR);
            _ui.ChangeGameModeInfo("GAME MODE: DESTROY RED");

            Debug.Log("Game Mode is: Destroy Red!");
        }
    }
}