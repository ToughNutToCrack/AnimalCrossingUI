using System.Collections.Generic;
using UnityEngine;

public class TopBarManager : MonoBehaviour
{
    public List<Section> sections;
    public CameraManager cam;
    int index = 0;

    public void Start()
    {
        sections[index].HandleState(true);
    }

    public void MoveOnTopBar(bool isLeft)
    {
        if (isLeft)
            if (index == 0)
                index = sections.Count - 1;
            else
                index--;
        else
        {
            if (index == sections.Count - 1)
                index = 0;
            else
                index++;
        }

        ResetAllSections();

        if (index == 0 || index == 1)
            cam.MoveToPosition(index);
        else
            cam.MoveToPosition(2);

        sections[index].HandleState(true);
    }

    void ResetAllSections()
    {
        foreach (var section in sections)
            section.HandleState(false);
    }
}
