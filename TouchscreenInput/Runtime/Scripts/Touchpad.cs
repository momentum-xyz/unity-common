using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Momentum.UnityCommon.TouchscreenInput
{
    public class Touchpad : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData data)
        {
            // Pass-through click event to all EventTrigger components
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(data, results);
            foreach (RaycastResult res in results)
            {
                EventTrigger trig = res.gameObject.GetComponent<EventTrigger>();
                if (trig == null)
                {
                    continue;
                }
                trig.OnPointerClick(data);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Devices.touchpad = eventData.delta / 12f;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Devices.touchpad = Vector2.zero;
        }

        public void LateUpdate()
        {
            Devices.touchpad = Vector2.zero;
        }
    }
}