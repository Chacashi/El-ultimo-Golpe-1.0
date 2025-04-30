using UnityEngine;

public class ButtonExit : ButtonController
{

    protected override void Interactue()
    {
        Application.Quit();
    }
}
