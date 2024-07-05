using FrameworkDesign;
using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class UIController : MonoBehaviour, IController
    {
        private IStatSystem mStatSystem;
        private IPlayerModel mPlayerModel;

        private void Awake()
        {
            mPlayerModel = this.GetModel<IPlayerModel>();
            mStatSystem = this.GetSystem<IStatSystem>();
        }

        /// <summary>
        /// Lazy是当第一次调用mLableStyle时会执行右边的初始化操作
        /// </summary>
        private readonly Lazy<GUIStyle> mLableStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 40
        });

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 300, 100), $"生命：{mPlayerModel.HP.Value}/3", mLableStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"击杀次数：{mStatSystem.KillCount.Value}", mLableStyle.Value);
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}