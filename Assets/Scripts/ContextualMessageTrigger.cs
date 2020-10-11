﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    public delegate void ContextualMessageTriggerAction();

    public static event ContextualMessageTriggerAction ContextualMessageTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if(ContextualMessageTriggered != null)
           {
                ContextualMessageTriggered.Invoke();
           }
        }
    }
}