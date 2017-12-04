using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteText : MonoBehaviour
    {
        void Start()
        {
            var parent = transform.parent;
            var parentRender = parent.GetComponent<Renderer>();
            var renderer = GetComponent<Renderer>();
            renderer.sortingLayerID = parentRender.sortingLayerID;
            renderer.sortingOrder = parentRender.sortingOrder;
        }
    }
}
