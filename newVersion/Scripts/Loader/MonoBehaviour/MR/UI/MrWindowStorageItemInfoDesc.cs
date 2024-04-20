using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MrWindowStorageItemInfoDesc: MonoBehaviour
{
    [SerializeField] private Image m_ItemIcon;
    [SerializeField] private TMP_Text m_ItemName;
    [SerializeField] private TMP_Text m_ItemNumber;
    [SerializeField] private TMP_Text m_ItemDesc;

    public void SetItemInfoPanel(string name, Sprite icon, string number, string desc)
    {
        m_ItemName.text = name;
        m_ItemDesc.text = desc;
        m_ItemIcon.sprite = icon;
        m_ItemNumber.text = number;
    }
}

// EOF