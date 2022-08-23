using System;
using UnityEngine;

namespace Core.DataStorage
{
    [Serializable]
    public class UserData
    {
        public int[] BestScores;
    }
    
    public class DataStorage
    {
        public UserData GetScores()
        {
            var json = PlayerPrefs.GetString("BestScores");
            return JsonUtility.FromJson<UserData>(json);
        }
        
        public void UpdateScore(UserData userData)
        {
            var json = JsonUtility.ToJson(userData);
            PlayerPrefs.SetString("BestScores", json);
            PlayerPrefs.Save();
        }
    }
}
