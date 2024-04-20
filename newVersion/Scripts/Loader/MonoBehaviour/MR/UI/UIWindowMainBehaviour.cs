using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;


public enum MainAniState
{
    Idle = 0,
    Arm = 1,    //�粿
    Hair = 2,   //ͷ��
    Foot = 3,   //��
    Crotch = 4, //��
    Chest = 5,  //��
    Waist = 6,  //��
    Fight = 7,  //����ս��
    Abdomen = 8, //����

    Daggers = 10,//˫ذ
    SwordShield,//����
    GreatSword,//�޽�
    Bow,//����
}



public class UIWindowMainBehaviour : MonoBehaviour
{
    [SerializeField] private Camera m_UIPlayerCamera;
    [SerializeField] private GameObject m_Player;
    [SerializeField] private Animator m_PlayerAnim;
    //[SerializeField] private List<GameObject> m_WeaponObjs = new List<GameObject>();
 
    private ulong m_CurtClickWeaponId = 0;
    private List<GameObject> m_Weapons = new List<GameObject>();

    private int m_LastShowIdx = -1;
    private List<WindowMainWeaponItem> m_WeaponItems = new List<WindowMainWeaponItem>();

    private void Awake()
    {
        //Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        UniversalAdditionalCameraData data = Camera.main.GetUniversalAdditionalCameraData();
        List<Camera> overlayCams = new List<Camera>(data.cameraStack);
        while (data.cameraStack.Count > 0)
        {
            data.cameraStack.RemoveAt(0);
        }
        data.cameraStack.Add(m_UIPlayerCamera);
        foreach (Camera cam in overlayCams)
        {
            data.cameraStack.Add(cam);
        }

        ShowIdle();
    }

    public void Init(WindowMainWeaponItem item)
    {
        m_WeaponItems.Add(item);
    }

    /// <summary>
    /// Show player's animation with anim trigger state
    /// </summary>
    /// <param name="state"></param>
    public void ShowAnim(MainAniState state)
    {
        m_PlayerAnim.SetInteger("AniState", (int)state);
    }


    public void ShowIdle()
    {
        m_PlayerAnim.SetInteger("AniState", 0);
    }

    public void ChangeWeapon(int index, ulong weaponId, GameObject[] weapons, int[] equipPoses)
    {
        if (weaponId != m_CurtClickWeaponId) return;

        if (m_LastShowIdx != -1)
        {
            m_WeaponItems[m_LastShowIdx].SetWeaponItemBtnState(true);
        }
        m_LastShowIdx = index;

        m_CurtClickWeaponId = weaponId;
        int wType = (int)(weaponId % 1000000000 / 1000) + 10;

        for (int i = 0; i < m_Weapons.Count; i++)
        {
            GameObject.Destroy(m_Weapons[i]);
        }
        m_Weapons.Clear();
        ShowAnim((MainAniState)wType);

        for (int i = 0; i < weapons.Length; i++)
        {
            var wp = m_Player.transform.Find($"Weapons/{i + 1}");
            wp.localPosition = Vector3.zero;
            var pc = wp.GetComponent<ParentConstraint>();
            pc.weight = 0;
            var wGo = GameObject.Instantiate(weapons[i], wp, false);
            for (int j = 0; j < pc.sourceCount; j++)
            {
                var source = pc.GetSource(j);
                source.weight = equipPoses[i] == j ? 1 : 0;
                pc.SetSource(j, source);
            }
            pc.weight = 1;
            m_Weapons.Add(wGo);
        }
    }

    public void HideWeapon()
    {
        for (int i = 0; i < m_Weapons.Count; i++)
        {
            GameObject.Destroy(m_Weapons[i]);
        }
        m_Weapons.Clear();
        ShowIdle();
        m_LastShowIdx = -1;
    }
}

// EOS