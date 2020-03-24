using System.Collections.Generic;
using UnityEngine;

public class ButtonSection : MonoBehaviour
{
    public List<MenuButton> pageButtons;
    public EquipmentType type;
    public bool secondaryBar;

    private void Start()
    {
        foreach (var button in pageButtons)
            button.InitVariables(type, this, secondaryBar);
    }
    public void Init()
    {
        ResetAllButtons();
        InitEquipment();
    }
    void InitEquipment()
    {
        var currentEquipId = EquipmentManager.Instance.GetCurrentEquipment(type);
        foreach (var button in pageButtons)
            if (button.id == currentEquipId)
                button.HandleState(true);
    }
    public void ResetAllButtons()
    {
        foreach (var button in pageButtons)
            button.HandleState(false);
    }
}
