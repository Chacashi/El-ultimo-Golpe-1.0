using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class ButtonController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 initialScale;
    [SerializeField] protected float timeScale;
    [SerializeField] protected Vector2 valueScale;
    protected Button myButton;


    protected virtual void Awake()
    {
        myButton = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        initialScale = transform.localScale;
        myButton.onClick.AddListener(Interactue);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(valueScale, timeScale);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(initialScale, timeScale);
    }

    protected abstract void Interactue();
}
