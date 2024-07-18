using System;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelEditor : MonoBehaviour
    {
        public SpriteRenderer EmptyHighlight;

        private int mCurrentHighlightPosX;
        private int mCurrentHighlightPosY;

        private bool mCanDraw;

        private void Update()
        {
            var mousePosition = Input.mousePosition;
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseWorldPos.x = Mathf.Floor(mouseWorldPos.x + 0.5f);
            mouseWorldPos.y = Mathf.Floor(mouseWorldPos.y + 0.5f);
            mouseWorldPos.z = 0;

            if(Math.Abs(mCurrentHighlightPosX - mouseWorldPos.x) < 0.1f && 
               Math.Abs(mCurrentHighlightPosY - mouseWorldPos.y) < 0.1f)
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
                    EmptyHighlight.color = new Color(1, 0, 0, 0.5f);
                    mCanDraw= false;
                }
                else
                {
                    EmptyHighlight.color = new Color(1, 1, 1, 0.5f);
                    mCanDraw= true;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (mCanDraw)
                {
                    var groundPrefab = Resources.Load<GameObject>("Ground");
                    var groundGameObj = Instantiate(groundPrefab, this.transform);
                    groundGameObj.transform.position = mouseWorldPos;
                    groundGameObj.name = "Ground";
                }
            }
        }
    }
}