using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public GameObject topLabel;
    public GameObject deselectedTopIcon;
    public GameObject selectedTopIcon;
    public List<ButtonSection> buttonSections;

    public void HandleState(bool activate)
    {
        topLabel.SetActive(activate);
        deselectedTopIcon.SetActive(!activate);
        selectedTopIcon.SetActive(activate);

        foreach (var sec in buttonSections)
        {
            sec.gameObject.SetActive(activate);
            sec.Init();
        }
    }
}
