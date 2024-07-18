using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelEditor : MonoBehaviour
    {
        public enum OperateMode
        {
            Draw,
            Erase
        }

        private OperateMode mCurrentOperateMode;

        private Lazy<GUIStyle> mModeLableStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 30,
            alignment = TextAnchor.MiddleCenter,
        });

        private Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.button)
        {
            fontSize = 30,
            alignment = TextAnchor.MiddleCenter,
        });

        private void OnGUI()
        {
            var modeLableRect = RectHelper.RectForAnchorCenter(Screen.width * 0.5f, 35, 300, 100);
            GUI.Label(modeLableRect, mCurrentOperateMode.ToString(), mModeLableStyle.Value);

            var drawButtonRect = new Rect(10, 10, 150, 50);
            if(GUI.Button(drawButtonRect, "»æÖÆ", mButtonStyle.Value))
            {
                mCurrentOperateMode = OperateMode.Draw;
            }
            var eraseButtonRect = new Rect(10, 60, 150, 50);
            if (GUI.Button(eraseButtonRect, "ÏðÆ¤", mButtonStyle.Value))
            {
                mCurrentOperateMode = OperateMode.Erase;
            }
        }

        public SpriteRenderer EmptyHighlight;

        private bool mCanDraw;
        private GameObject mCurrentObjectMouseOn;

        private void Update()
        {
            var mousePosition = Input.mousePosition;
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseWorldPos.x = Mathf.Floor(mouseWorldPos.x + 0.5f);
            mouseWorldPos.y = Mathf.Floor(mouseWorldPos.y + 0.5f);
            mouseWorldPos.z = 0;

            if(GUIUtility.hotControl == 0)
            {
                EmptyHighlight.gameObject.SetActive(true);
            }
            else
            {
                EmptyHighlight.gameObject.SetActive(false);
            }

            if(Math.Abs(EmptyHighlight.transform.position.x - mouseWorldPos.x) < 0.1f && 
               Math.Abs(EmptyHighlight.transform.position.y - mouseWorldPos.y) < 0.1f)
            {

            }
            else
            {
                var highlightPos = mouseWorldPos;
                highlightPos.z = -9f;
                EmptyHighlight.transform.position = highlightPos;
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero, 20);
                if(hit.collider)
                {
                    if (mCurrentOperateMode == OperateMode.Draw)
                    {
                        EmptyHighlight.color = new Color(1, 0, 0, 0.5f);
                    }
                    else if(mCurrentOperateMode == OperateMode.Erase)
                    {
                        EmptyHighlight.color = new Color(1, 0.5f, 0, 0.5f);
                    }
                    mCanDraw= false;
                    mCurrentObjectMouseOn = hit.collider.gameObject;
                }
                else
                {
                    if(mCurrentOperateMode == OperateMode.Draw)
                    {
                        EmptyHighlight.color = new Color(1, 1, 1, 0.5f);
                    }
                    else if(mCurrentOperateMode == OperateMode.Erase)
                    {
                        EmptyHighlight.color = new Color(0, 0, 1, 0.5f);
                    }
                    mCanDraw = true;
                    mCurrentObjectMouseOn = null;
                }
            }

            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && GUIUtility.hotControl == 0)
            {
                if (mCanDraw && mCurrentOperateMode == OperateMode.Draw)
                {
                    var groundPrefab = Resources.Load<GameObject>("Ground");
                    var groundGameObj = Instantiate(groundPrefab, this.transform);
                    groundGameObj.transform.position = mouseWorldPos;
                    groundGameObj.name = "Ground";
                    mCanDraw = false;
                }
                else if(mCurrentObjectMouseOn && mCurrentOperateMode == OperateMode.Erase)
                {
                    Destroy(mCurrentObjectMouseOn);
                    mCurrentObjectMouseOn = null;
                }
            }
        }
    }
}