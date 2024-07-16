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
            //��ѯ
            mMaxBulletCount = new MaxBulletCountQuery(mGunSystem.CurrentGun.Name.Value).Do();
        }

        /// <summary>
        /// Lazy�ǵ���һ�ε���mLableStyleʱ��ִ���ұߵĳ�ʼ������
        /// </summary>
        private readonly Lazy<GUIStyle> mLableStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 40
        });

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 300, 100), $"������{mPlayerModel.HP.Value}/3", mLableStyle.Value);
            GUI.Label(new Rect(10, 60, 300, 100), $"ǹ���ӵ���{mGunSystem.CurrentGun.BulletCountInGun.Value}/{mMaxBulletCount}", mLableStyle.Value);
            GUI.Label(new Rect(10, 110, 300, 100), $"ǹ���ӵ���{mGunSystem.CurrentGun.BulletCountOutGun.Value}", mLableStyle.Value);
            GUI.Label(new Rect(10, 160, 300, 100), $"ǹе���֣�{mGunSystem.CurrentGun.Name.Value}", mLableStyle.Value);
            GUI.Label(new Rect(10, 210, 300, 100), $"ǹ��״̬��{mGunSystem.CurrentGun.GunState.Value}", mLableStyle.Value);
            GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"��ɱ������{mStatSystem.KillCount.Value}", mLableStyle.Value);
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