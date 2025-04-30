using UnityEngine;
using DG.Tweening;
using System;
using Unity.Cinemachine;
using System.Collections;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup introCanvas;
    [SerializeField] private CinemachineCamera camIntro;
    [SerializeField] private float durationFadeIntroCanvas;
    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private float delayTransitionCameras;



    private void Start()
    {
        introCanvas.DOFade(1f,durationFadeIntroCanvas).OnComplete(() =>
        {
            introCanvas.interactable = true;
            introCanvas.blocksRaycasts = true;
        });
    }
    public void TransitionToMenu()
    {
        FadeObject(introCanvas, 0f,durationFadeIntroCanvas,() =>
        {
            camIntro.gameObject.SetActive(false);
            StartCoroutine(TransitionCamera(menuCanvas));
        } );
    }


    public void TransitionToIntro()
    {
        FadeObject(menuCanvas, 0f, durationFadeIntroCanvas, () =>
        {
            camIntro.gameObject.SetActive(true);
            StartCoroutine(TransitionCamera(introCanvas));
           
        });
    }


    private void FadeObject(CanvasGroup canvas, float endValue,float duration, Action action)
    {
        canvas.DOFade(endValue, duration).OnComplete(() => action?.Invoke());
        
    } 

    IEnumerator TransitionCamera(CanvasGroup canvas)
    {
        yield return new WaitForSeconds(delayTransitionCameras);
        FadeObject(canvas, 1f, durationFadeIntroCanvas, () =>
        {

            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        });
    }
}
