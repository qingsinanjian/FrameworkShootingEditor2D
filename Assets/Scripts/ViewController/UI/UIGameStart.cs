using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class UIGameStart : MonoBehaviour
    {
        private readonly Lazy<GUIStyle> mLableStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 60,
            alignment = TextAnchor.MiddleCenter,
        });

        private readonly Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.button)
        {
            fontSize = 40,
            alignment = TextAnchor.MiddleCenter,
        });

        private void OnGUI()
        {
            //var lableWidth = 600;
            //var lableHeight = 100;
            //var lableSize = new Vector2(lableWidth, lableHeight);
            //var lablePosition = new Vector2(Screen.width, Screen.height) * 0.5f - lableSize * 0.5f;
            var lableRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, Screen.height * 0.5f, 600, 100);

            GUI.Label(lableRect, "ShootingEditor2D", mLableStyle.Value);

            //var buttonWidth = 300;
            //var buttonHeight = 100;
            //var buttonSize = new Vector2(buttonWidth, buttonHeight);
            //var buttonPosition = new Vector2(Screen.width, Screen.height) * 0.5f - buttonSize * 0.5f + Vector2.up * 150;
            //var buttonRect = new Rect(buttonPosition, buttonSize);
            var buttonRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, Screen.height * 0.5f + 150, 300, 100);

            if (GUI.Button(buttonRect, "¿ªÊ¼ÓÎÏ·", mButtonStyle.Value))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}