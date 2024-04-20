using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MrWindowStorageWeaponInfoDesc : MonoBehaviour
{
    [SerializeField] private TMP_Text m_WeaponName;
    [SerializeField] private Image m_WeaponIcon;
    // $"Lv.{xxx}"
    [SerializeField] private TMP_Text m_WeaponInfoText;
    [SerializeField] private Image[] m_WeaponStars;
    [SerializeField] private TMP_Text m_WeaponDesc;

    //[SerializeField] private int m_WeaponStarsNumber;
    [SerializeField] private Button m_UpgradeBtn;

    public void SetWeaponInfoPanel(string name, Sprite icon, string info, string desc, int stars)
    {
        m_WeaponName.text = name;
        m_WeaponIcon.sprite = icon;
        m_WeaponInfoText.text = info;
        m_WeaponDesc.text = desc;

        for (int i = 0; i < 6; i++)
        {
            m_WeaponStars[i].gameObject.SetActive(i <= stars);
        }

        LayoutElement descLE = m_WeaponDesc.GetComponent<LayoutElement>();
        //descLE.preferredHeight = m_WeaponDesc.preferredHeight;
        RectTransform trans = m_WeaponDesc.rectTransform;
        Vector2 size = trans.sizeDelta;
        size.y = m_WeaponDesc.preferredHeight;
        trans.sizeDelta = size;
        descLE.preferredHeight = size.y;
    }
}

// EOF