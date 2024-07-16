using FrameworkDesign;
using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class UIController : MonoBehaviour, IController
    {
        private IStatSystem mStatSystem;
        private IPlayerModel mPlayerModel;
        private IGunSystem mGunSystem;

        private int mMaxBulletCount;

        private void Awake()
        {
            mPlayerModel = this.GetModel<IPlayerModel>();
            mStatSystem = this.GetSystem<IStatSystem>();
            mGunSystem = this.GetSystem<IGunSystem>();
            //查询
            mMaxBulletCount = new MaxBulletCountQuery(mGunSystem.CurrentGun.Name.Value).Do();
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
            GUI.Label(new Rect(10, 60, 300, 100), $"枪内子弹：{mGunSystem.CurrentGun.BulletCountInGun.Value}/{mMaxBulletCount}", mLableStyle.Value);
            GUI.Label(new Rect(10, 110, 300, 100), $"枪外子弹：{mGunSystem.CurrentGun.BulletCountOutGun.Value}", mLableStyle.Value);
            GUI.Label(new Rect(10, 160, 300, 100), $"枪械名字：{mGunSystem.CurrentGun.Name.Value}", mLableStyle.Value);
            GUI.Label(new Rect(10, 210, 300, 100), $"枪外状态：{mGunSystem.CurrentGun.GunState.Value}", mLableStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"击杀次数：{mStatSystem.KillCount.Value}", mLableStyle.Value);
        }

        private void OnDestroy()
        {
            mPlayerModel = null;
            mStatSystem = null;
            mGunSystem = null;
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}