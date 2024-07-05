using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class UIGamePass : MonoBehaviour
    {
        private readonly Lazy<GUIStyle> mLableStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 80,
            alignment = TextAnchor.MiddleCenter,
        });

        private readonly Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.button)
        {
            fontSize = 40,
            alignment = TextAnchor.MiddleCenter,
        });

        private void OnGUI()
        {
            var lableWidth = 400;
            var lableHeight = 100;
            var lablePosition = new Vector2(Screen.width - lableWidth, Screen.height - lableHeight) * 0.5f;
            var lableSize = new Vector2(lableWidth, lableHeight);
            var lableRect = new Rect(lablePosition, lableSize);

            GUI.Label(lableRect, "游戏通关", mLableStyle.Value);

            var buttonWidth = 200;
            var buttonHeight = 100;
            var buttonPosition = new Vector2(Screen.width, Screen.height) * 0.5f -
                new Vector2(buttonWidth * 0.5f, buttonHeight * 0.5f) + new Vector2(0, 150);
            var buttonSize = new Vector2(buttonWidth, buttonHeight);
            var buttonRect = new Rect(buttonPosition, buttonSize);

            if(GUI.Button(buttonRect, "返回首页", mButtonStyle.Value))
            {
                SceneManager.LoadScene("GameStart");
            }
        }
    }
}
