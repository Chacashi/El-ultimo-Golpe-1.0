using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class ButtonController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    protected Button myButton;


    protected virtual void Awake()
    {
        myButton = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        myButton.onClick.AddListener(Interactue);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {

    }

    protected abstract void Interactue();
}
