﻿using BDFramework.UFlux;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//这里的命名空间必须为：BDFramework.Uflux
namespace  BDFramework.UFlux
{
    /// <summary>
    /// 这里是UnityEngine的UI Text适配器
    /// </summary>
    [ComponentBindAdaptor(typeof(TMP_Text))]
    public class CBA_Text : AComponentBindAdaptor
    {
        
        public override void Init()
        {
            base.Init();
            setPropComponentBindMap[nameof(TMP_Text.text)] = SetProp_Text;
            setPropComponentBindMap[nameof(TMP_Text.color)] = SetProp_Color;
        }
        /// <summary>
        /// 设置文字
        /// </summary>
        /// <param name="value"></param>
        private void SetProp_Text(UIBehaviour uiBehaviour,object value)
        {
            var text = uiBehaviour as TMP_Text;
            text.text = value.ToString();
        }
        
        
        /// <summary>
        /// 设置文字
        /// </summary>
        /// <param name="value"></param>
        private void SetProp_Color(UIBehaviour uiBehaviour,object value)
        {
            var text = uiBehaviour as TMP_Text;
            text.color = (Color) value;
        }
    }
}