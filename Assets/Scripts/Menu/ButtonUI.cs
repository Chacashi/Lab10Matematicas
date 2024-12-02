
using DG.Tweening;
using UnityEngine;
using static UnityEngine.Timeline.TimelineAsset;
using UnityEngine.Windows;


public class ButtonUI : ButtonController, IFade
{
   // [SerializeField] private GameObject[] arrayObjectives;
    
    [SerializeField] private CanvasGroup canvasGroupObjective;
    [SerializeField] private CanvasGroup canvasGroupPrincipal;
    [SerializeField] private float durationFade;
    private Tween fadeTween;



    protected override void Interactue()
    {
        /*
        for(int i = 0; i < arrayObjectives.Length; i++)
        {
            if(arrayObjectives[i].activeSelf)
            {
                arrayObjectives[i].gameObject.SetActive(false);
            }
            else
            {
                arrayObjectives[i].gameObject.SetActive(true);
            }
         }   
        */

        if (canvasGroupObjective.alpha ==1)
        {
            FadeOut();
            canvasGroupPrincipal.interactable = true;
            canvasGroupPrincipal.blocksRaycasts = true;
        }
        else
        {
            FadeIn();
            canvasGroupPrincipal.interactable = false;
            canvasGroupPrincipal.blocksRaycasts = false;
        }
    }

    public void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        


        fadeTween = canvasGroupObjective.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }
    public void Fade(float endValue, float duration)
    {
        canvasGroupObjective.DOFade(endValue, duration);
    }
    public void FadeIn()
    {

        Fade(1f, durationFade, () =>
        {
            canvasGroupObjective.interactable = true;
            canvasGroupObjective.blocksRaycasts = true;
            
        });
    }

    public void FadeOut()
    {

        canvasGroupObjective.interactable = false;
        canvasGroupObjective.blocksRaycasts = false;


        Fade(0f, durationFade);
        /*
        Fade(0f, durationFade, () =>
        {
           


        });
        */

    }


}
