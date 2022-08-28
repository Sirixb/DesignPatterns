using System;
using UnityEngine;

namespace UI
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private Vector2 _scrollSpeed = new Vector2(0, 0.5f);
        private Renderer _renderer;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private Material _material;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _material = _renderer.material;
        }

        private void OnDestroy()
        {
            Destroy(_material);
        }

        private void Update()
        {
            var offset = Time.time * _scrollSpeed;
            _material.SetTextureOffset(MainTex, offset);
        }
    }
}
