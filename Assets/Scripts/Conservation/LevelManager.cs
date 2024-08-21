using System;
using UnityEngine;

[Serializable]
public class LevelManager
{
    private const string KeySavedLevel = "ÑurrentLevel";

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

    public void SetDefolt()
    {
        PlayerPrefs.SetInt("ÑurrentLevel", 1);
        PlayerPrefs.Save();
    }
}
