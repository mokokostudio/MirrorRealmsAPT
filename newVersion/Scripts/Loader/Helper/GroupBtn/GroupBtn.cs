using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public class GroupBtn : MonoBehaviour
    {
        [SerializeField] private int m_Index;
        [SerializeField] private GameObject m_Normal;
        [SerializeField] private GameObject m_Select;
        [SerializeField] private GameObject m_LinkedPanel;

        Action<int> m_ClickCallback = null;

        private void Awake()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(() => {
                m_ClickCallback?.Invoke(m_Index);
            });
        }

        public void SetClickCallback(Action<int> callback)
        {
            m_ClickCallback = callback;
        }

        public int GetBtnIndex()
        {
            return m_Index;
        }

        public void SetState(bool isSelect)
        {
            m_Select.SetActive(isSelect);
            m_Normal.SetActive(!isSelect);
            m_LinkedPanel.SetActive(isSelect);
        }
    }
}

// EOF