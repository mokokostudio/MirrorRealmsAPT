using ET;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf(typeof(MrUIStorageComponent))]
    public class MrUIStorageItemComponent : Entity, IAwake<string, GameObject>, IDestroy
    {
        public string CompName;
        public GameObject CompObject;

        public Button ItemBtn;
        public Image ItemIcon;
        public TMP_Text ItemName;
        public TMP_Text ItemNumber;

        public int ItemId;
        public int ItemCount;
        public MrWindowStorageItemInfoDesc DescItem;
        public bool IsSelect;
    }
}