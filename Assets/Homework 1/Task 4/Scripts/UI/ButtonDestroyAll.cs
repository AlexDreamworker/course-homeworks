using UnityEngine;

namespace Homework1.Task4
{
    public class ButtonDestroyAll : ButtonBase
    {
        protected override void ButtonCallback()
        {
            base.ButtonCallback();

            _conditionSwitcher.SetDestroyAll();
            _ui.ChangeGameModeInfo("GAME MODE: DESTROY ALL");

            Debug.Log("Game Mode is: Destroy All!");
        }
    }
}