using System.Collections.Generic;

namespace Patterns.Behaviour.Observer.Solution1
{
    public class Skill : Subject
    {
        private readonly List<Observer> _observers;
        
        public int Charges { get; private set; }
        public bool IsReady => Charges > 0;

        public Skill()
        {
            Charges = 3;
            _observers = new List<Observer>();
        }

        public void Subscribe(Observer observer)
        {
            _observers.Add(observer);
            observer.Updated(this);
        }

        public void Unsubscribe(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Updated(this);
            }
        }

        public void Use()
        {
            if (Charges <= 0)
            {
                return;
            }
            
            Charges -= 1;
            Notify();
        }
    }
}
