using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    [SerializeField]
    private float fadeOutDuration = 1;

    private CanvasGroup canvasGroup;
    private TMP_Text messagetext;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messagetext = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;

       //StartCoroutine( ShowMessage("TESTING", 5));
    }

    private IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messagetext.text = message;
        //wait for duration
        yield return new WaitForSeconds(duration);
        //start fading
        float fadeelapsedtime = 0;
        float fadestarttime = Time.time;
        while (fadeelapsedtime < fadeOutDuration)
        {
            fadeelapsedtime = Time.time - fadestarttime;
            canvasGroup.alpha = 1 - fadeelapsedtime / fadeOutDuration;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }

    private void OnContextualMessageTriggered(string message, float messageduration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessage(message, messageduration));
    }

    private void OnEnable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered += OnContextualMessageTriggered;

    }

    private void OnDisable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered -= OnContextualMessageTriggered;
    }
}
