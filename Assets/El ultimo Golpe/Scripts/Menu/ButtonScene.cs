
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : ButtonController
{
    [SerializeField] private string sceneName;


    protected override void Interactue()
    {
        SceneManager.LoadScene(sceneName);
    }
}
