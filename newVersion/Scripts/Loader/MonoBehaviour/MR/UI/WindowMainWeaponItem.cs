using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowMainWeaponItem : MonoBehaviour
{
    public ulong WeaponId { get; set; }
    [SerializeField] private GameObject m_DisplayGO;
    [SerializeField] private GameObject m_ExhibitGO;

    [SerializeField] private Image m_WeaponIcon;
    [SerializeField] private TMP_Text m_WeaponName;
    [SerializeField] private GameObject m_NtfGO;

    private UIWindowMainBehaviour m_ParentView;
    private List<GameObject> m_Weapons = new List<GameObject>();
    private List<string> m_WeaponNames = new List<string>();
    private List<int> m_WeaponPoses = new List<int>();

    private int m_Index = 0;

    private void Awake()
    {
        if (m_DisplayGO != null)
        {
            m_DisplayGO.GetComponent<Button>().onClick.AddListener(OnDisplayBtnClicked);
        }
        if (m_ExhibitGO != null)
        {
            m_ExhibitGO.GetComponent<Button>().onClick.AddListener(OnExhibitBtnClicked);
        }
        if (m_WeaponIcon != null)
        {
            m_WeaponIcon.GetComponent<Button>().onClick.AddListener(OnWeaponIconClicked);
        }
    }

    public void InitWeaponItem(int idx, string name, Sprite icon, bool isNTF)
    {
        m_Index = idx;
        m_WeaponName.text = name;
        m_WeaponIcon.sprite = icon;
        SetWeaponItemBtnState(true);
        m_NtfGO.SetActive(isNTF);

        SetWeaponState(true);
    }

    public void SetWeaponState(bool show)
    {
        gameObject.SetActive(show);
    }

    public void SetWeaponItemBtnState(bool canShow)
    {
        m_DisplayGO.SetActive(!canShow);
        m_ExhibitGO.SetActive(canShow);
    }

    public void SetParentView(UIWindowMainBehaviour view)
    {
        m_ParentView = view;
        m_ParentView.Init(this);
    }

    public void SetWeapon(string name, GameObject weapon, int equipPos)
    {
        m_Weapons.Add(weapon);
        m_WeaponNames.Add(name);
        m_WeaponPoses.Add(equipPos);
    }

    private void OnDisplayBtnClicked()
    {
        Debug.LogWarning("=== OnDisplayBtnClicked ===");
        SetWeaponItemBtnState(true);
        // Play idle
        m_ParentView.HideWeapon();
    }

    private void OnExhibitBtnClicked()
    {
        Debug.LogWarning("=== OnExhibitBtnClicked ===");
        SetWeaponItemBtnState(false);
        // put weapon to player
        m_ParentView.ChangeWeapon(m_Index, WeaponId, m_Weapons.ToArray(), m_WeaponPoses.ToArray());
    }

    private void OnWeaponIconClicked()
    {
        Debug.LogWarning("=== OnWeaponIconClicked ===");
        // put weapon to player
        m_ParentView.ChangeWeapon(m_Index, WeaponId, m_Weapons.ToArray(), m_WeaponPoses.ToArray());
    }
}

// EOF