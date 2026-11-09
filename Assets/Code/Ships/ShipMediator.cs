using Common;
using GameAudio;
using Patterns.Decoupling.ServiceLocator;
using Patterns.Optimization.ObjectPooling;
using Pickups;
using Ships.Common;
using Ships.Weapons;
using UI;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : RecyclableObject, Ship ,EventObserver
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private ShipId _shipId;
        public string Id => _shipId.Value;

        private Input.Input _input;
        private Teams _team;
        private int _score;
        private CheckDestroyLimits _checkDestroyLimits;
        private PickupIds _drop;

        public Teams Team => _team;

        internal override void Init()
        {
            EventQueue eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.Restart, this);
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
        }
        internal override void Release()
        {
            UnsubscribeFromEvents();
        }

        private void OnDestroy()
        {
            // The EventQueue outlives the Game scene (DontDestroyOnLoad). Ships still active when the
            // scene is unloaded never go through Release(), so they must unsubscribe here.
            if (!ServiceLocator.Instance.Contains<EventQueue>())
            {
                return;
            }

            UnsubscribeFromEvents();
        }

        private void UnsubscribeFromEvents()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.Restart, this);
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
        }
        public void Configure(ShipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId,configuration.Team);
            _healthController.Configure(this, configuration.Health, configuration.Team);
            _team = configuration.Team;
            _score = configuration.Score;
            _checkDestroyLimits = configuration.CheckDestroyLimits;
            _drop = configuration.Drop;
        }

       private void FixedUpdate()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
        }

        private void Update()
        {
            TryShoot();
            CheckDestroyLimits();
        }

        public void CheckDestroyLimits()
        {
            if (_checkDestroyLimits.IsInsideTheLimits(transform.position))
            {
                return;
            }

            Recycle();

            var shipDestroyedEventData = new ShipDestroyedEventData(0, _team, GetInstanceID());
           ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(shipDestroyedEventData);
        }
        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<Damageable>(out var damageable))
            {
                return;
            }

            if (damageable.Team == _team)
            {
                return;
            }

            damageable.AddDamage(1);
        }
        
        public void MultiplyFireRate(float factor)
        {
            _weaponController.MultiplyFireRate(factor);
        }

        public void OnDamageReceived(bool isDeath)
        {
            if (isDeath)
            {
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                ServiceLocator.Instance.GetService<AudioService>().PlaySfx(AudioIds.Explosion);
                Recycle();

                var shipDestroyedEventData = new ShipDestroyedEventData(_score, _team, GetInstanceID(), transform.position, _drop);
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(shipDestroyedEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.GameOver 
             && eventData.EventId != EventIds.Victory
             && eventData.EventId != EventIds.Restart)
            {
                return;
            }

            _weaponController.Restart();

            Recycle();
        }
    }
}
