using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NavigationManager : MonoBehaviour
{
    public InputMaster input;
    public TopBarManager topBarMng;
    public GameObject confirmPanel, confirmButton;
    public List<GenericButton> confirmPanelButtons;

    void Awake()
    {
        input = new InputMaster();
    }

    void OnSecondaryMovement(InputValue iv)
    {
        var actionValue = iv.Get<float>();
        if (actionValue == 1)
            topBarMng.MoveOnTopBar(false);
        else if (actionValue == -1)
            topBarMng.MoveOnTopBar(true);
    }

    public void Confirm(bool wantActive)
    {
        confirmPanel.SetActive(wantActive);
        
        if (wantActive)
            EventSystem.current.SetSelectedGameObject(confirmPanelButtons[0].gameObject);
        else
        {
            EventSystem.current.SetSelectedGameObject(confirmButton);
            foreach (var btn in confirmPanelButtons)
                btn.HandleState(false);
        }
    }
}
