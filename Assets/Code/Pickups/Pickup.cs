using System;
using GameAudio;
using Patterns.Decoupling.ServiceLocator;
using Patterns.Optimization.ObjectPooling;
using Ships;
using Ships.Common;
using UnityEngine;

namespace Pickups
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Pickup : RecyclableObject
    {
        private const float OffscreenViewportY = -0.05f;

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Camera _camera;
        private Vector3 _baseScale;

        private PickupEffect _effect;
        private AudioIds _pickUpSound;
        private Action<Pickup> _onReleased;
        private bool _isActive;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            // The size is set in the prefab; the pulse only oscillates around it.
            _baseScale = transform.localScale;
        }

        public void Setup(PickupEffect effect, PickupsConfiguration.Entry entry, Action<Pickup> onReleased)
        {
            _effect = effect;
            _pickUpSound = entry.PickUpSound;
            _onReleased = onReleased;

            if (entry.Sprite != null)
            {
                _spriteRenderer.sprite = entry.Sprite;
            }

            _spriteRenderer.color = entry.Color;
            _rigidbody2D.velocity = Vector2.down * entry.FallSpeed;
        }

        internal override void Init()
        {
            _isActive = true;
            _camera = Camera.main;
        }

        internal override void Release()
        {
            _isActive = false;
            _rigidbody2D.velocity = Vector2.zero;
            _onReleased?.Invoke(this);
        }

        private void Update()
        {
            // Small pulse so it reads as something to grab.
            transform.localScale = _baseScale * (1f + 0.15f * Mathf.Sin(Time.time * 6f));

            if (_isActive && _camera.WorldToViewportPoint(transform.position).y < OffscreenViewportY)
            {
                Collect();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive || !other.TryGetComponent<ShipMediator>(out var ship) || ship.Team != Teams.Ally)
            {
                return;
            }

            _effect.Apply(ship);
            Collect();
            ServiceLocator.Instance.GetService<AudioService>().PlaySfx(_pickUpSound);
        }

        private void Collect()
        {
            if (!_isActive)
            {
                return;
            }

            _isActive = false;
            Recycle();
        }
    }
}
