using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class UIGameOver : MonoBehaviour
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
            var lableWidth = 600;
            var lableHeight = 100;
            var lableSize = new Vector2(lableWidth, lableHeight);
            var lablePosition = new Vector2(Screen.width, Screen.height) * 0.5f - lableSize * 0.5f;
            var lableRect = new Rect(lablePosition, lableSize);

            GUI.Label(lableRect, "游戏结束", mLableStyle.Value);

            var buttonWidth = 300;
            var buttonHeight = 100;
            var buttonSize = new Vector2(buttonWidth, buttonHeight);
            var buttonPosition = new Vector2(Screen.width, Screen.height) * 0.5f - buttonSize * 0.5f + Vector2.up * 150;
            var buttonRect = new Rect(buttonPosition, buttonSize);

            if (GUI.Button(buttonRect, "回到首页", mButtonStyle.Value))
            {
                SceneManager.LoadScene("GameStart");
            }
        }
    }

}