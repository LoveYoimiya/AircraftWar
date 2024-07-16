using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private Button _btn;
    private TMP_Dropdown _dropDown;
    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponentInChildren<Button>();
        _btn.onClick.AddListener(() => OnButtonClick());
        _dropDown = GetComponentInChildren<TMP_Dropdown>();
        _dropDown.onValueChanged.AddListener(OnDropdownValueChanged);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonClick()
    {
        GameObject.Find("Canvas").GetComponent<PanelManager>().ShowPanel("GamePanel");
    }
    private void OnDropdownValueChanged(int index)
    {
        string selectedOption = _dropDown.options[index].text;
        GameManager.Instance.selectPrefab = index;
    }
}
