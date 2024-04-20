using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public class GroupBtnController: MonoBehaviour
    {
        [SerializeField] private int m_DefaultSelectIndex = 0;

        private Dictionary<int, GroupBtn> m_GroupBtns = new Dictionary<int, GroupBtn>();
        private int m_SelectIndex = 0;

        private void Start()
        {
            GroupBtn[] btns = GetComponentsInChildren<GroupBtn>();
            foreach (GroupBtn btn in btns)
            {
                int index = btn.GetBtnIndex();
                btn.SetClickCallback(OnBtnClick);
                m_GroupBtns.Add(index, btn);
                SetBtnState(index, index == m_DefaultSelectIndex);
            }
        }

        private void OnBtnClick(int index)
        {
            if (m_SelectIndex == index) { return; }

            SetBtnState(m_SelectIndex, false);
            SetBtnState(index, true);
            m_SelectIndex = index;
        }

        private void SetBtnState(int index, bool isSelect)
        {
            if (m_GroupBtns.TryGetValue(index, out GroupBtn btn))
            {
                btn.SetState(isSelect);
            }
        }


    }
}

// EOF