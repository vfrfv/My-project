using Agava.YandexGames;
using System;
using UnityEngine;

public class LoggingServis
{
    public bool IsLogged => PlayerAccount.IsAuthorized;

    public event Action LogSuccess;
    public event Action<string> LogError;

    public void Log()
    {
        PlayerAccount.Authorize(LogSuccess, LogError);
        PlayerAccount.RequestPersonalProfileDataPermission();
    }
}
