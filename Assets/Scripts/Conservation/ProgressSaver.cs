using System;
using UnityEngine;

namespace Conservation
{
    [Serializable]
    public class ProgressSaver
    {
        private const string KeySavedLevel = "�urrentLevel";

        [SerializeField] private int _currentLevel = 1;

        public int CurrentLevel => _currentLevel;

        public void CompleteLevel()
        {
            _currentLevel++;

            PlayerPrefs.SetInt(KeySavedLevel, _currentLevel);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(KeySavedLevel))
            {
                int savetLevel = PlayerPrefs.GetInt(KeySavedLevel);

                if (savetLevel > _currentLevel)
                    _currentLevel = savetLevel;
            }
        }
    }
}