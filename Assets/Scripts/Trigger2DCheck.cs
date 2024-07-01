using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Trigger2DCheck : MonoBehaviour
    {
        public LayerMask TargetLayers;
        public int EnterCount;

        public bool Triggered
        {
            get { return EnterCount > 0; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount--;
            }
        }

        public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
        {
            // ����Layer��ֵ������λ������������Maskֵ
            int objLayerMask = 1 << obj.layer;
            return (layerMask.value & objLayerMask) > 0;
        }
    }
}
