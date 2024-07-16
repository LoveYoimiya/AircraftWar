using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    private Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    void Start()
    {
        foreach (Transform panel in transform)
        {
            panels[panel.name] = panel.gameObject;
            panel.gameObject.SetActive(false);
        }
        ShowPanel("StartPanel");
    }
    public void ShowPanel(string panelName)
    {
        foreach (var panel in panels.Values)
        {
            panel.SetActive(false);
        }
        if (panels.ContainsKey(panelName))
        {
            panels[panelName].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Panel " + panelName + " does not exist.");
        }
    }
}
