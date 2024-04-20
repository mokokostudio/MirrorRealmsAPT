using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class MrWindowMainModeSelectItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_CostTxt;
        [SerializeField] private TMP_Text m_PlayerNumTxt;
        [SerializeField] private GameObject m_SelectIcon;

        public void SetInfo(bool isMain, bool isSingle)
        {
            m_SelectIcon.SetActive(isMain);

            if (isSingle)
            {
                m_CostTxt.text = $"Free";
                m_PlayerNumTxt.text = "1";
            }
            else
            {
                m_CostTxt.text = $"Pay 100 coins";
                m_PlayerNumTxt.text = "1-3";
            }
        }
    }
}
