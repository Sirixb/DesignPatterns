using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacadeImpl : MonoBehaviour, GameFacade
    {
       
        public void StopBattle()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopAndReset(); 
        }
    }
}
