using UnityEngine;
using UnityEngine.UI;

public class ButtonExit : MonoBehaviour
{
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    private void Start()
    {
        myButton.onClick.AddListener(Interactue);
    }

    void Interactue()
    {
        Application.Quit();
    }
}
