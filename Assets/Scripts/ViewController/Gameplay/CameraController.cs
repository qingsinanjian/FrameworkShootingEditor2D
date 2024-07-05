using UnityEngine;

namespace ShootingEditor2D
{
    public class CameraController : MonoBehaviour
    {
        private Transform mPlayerTrans;

        private void Update()
        {
            if (!mPlayerTrans)
            {
                var playerGameObj = GameObject.FindWithTag("Player");
                if(playerGameObj != null)
                {
                    mPlayerTrans = playerGameObj.transform;
                }
                else
                {
                    return;
                }
                
            }

            var cameraPos = transform.position;
            var isRight = Mathf.Sign(mPlayerTrans.localScale.x);
            var playerPos = mPlayerTrans.position;
            cameraPos.x = playerPos.x + 3 * isRight;
            cameraPos.y = playerPos.y + 2;

            transform.position = cameraPos;
        }
    }
}

