﻿using UnityEngine;
using System.Collections;
using Fungus;

[EventHandlerInfo("Custom",
                      "Schedule Visit",
                      "Clicked schedule visit")]
[AddComponentMenu("")]
public class Eventhandler_VisitClick : EventHandler {

/*
Raising the event:
Fungus.FungusManager.Instance.EventDispatcher.Raise(new Custom_Fungus_EventHandler.Custom_EventHandlerEvent() { text = "whatever" });

 */

public ApartmentData target;
    public int activationTimes = 1;

    public class Custom_EventHandlerEvent {
        public ApartmentButton targetButton;
    }

    protected EventDispatcher eventDispatcher;

    protected virtual void OnEnable() {
        eventDispatcher = FungusManager.Instance.EventDispatcher;

        eventDispatcher.AddListener<Custom_EventHandlerEvent>(OnCustom_EventHandlerEvent);
    }

    protected virtual void OnDisable() {
        eventDispatcher.RemoveListener<Custom_EventHandlerEvent>(OnCustom_EventHandlerEvent);

        eventDispatcher = null;
    }

    void OnCustom_EventHandlerEvent(Custom_EventHandlerEvent evt) {

        Debug.Log("Event raised: " + evt);
        if (evt.targetButton.data == target && (activationTimes > 0 || activationTimes < 0)) {
            ExecuteBlock();
            activationTimes--;
            return;
            };
    }
}
