using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
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
        canvasGroup.alpha = 0;
    }

    private void OnContextualMessageTriggered()
    {
        StartCoroutine(ShowMessage("Testing", 2));
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
