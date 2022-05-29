using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FadeWHOOP : MonoBehaviour
{
    private bool mFaded = false;

    public float Duration = 0.4f;
    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        //Toggle the end value depending on the faded state ( from 0.5 to 1)
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 0.5f : 1));

        //Toggle the faded state
        mFaded = !mFaded;


    }
    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null; //Because we don't need a return value.
        }
    }
}
