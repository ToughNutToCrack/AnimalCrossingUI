using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public List<GameObject> toActivateOnSelect, toActivateOnDeselect;
    public void OnDeselect(BaseEventData eventData)
    {
        HandleState(false);
    }
    public void OnSelect(BaseEventData eventData)
    {
        HandleState(true);
    }
    public void HandleState(bool wantActive)
    {
        if (toActivateOnSelect != null)
            foreach (var go in toActivateOnSelect)
                go.SetActive(wantActive);
        if (toActivateOnDeselect != null)
            foreach (var go in toActivateOnDeselect)
                go.SetActive(!wantActive);
    }

    
}
