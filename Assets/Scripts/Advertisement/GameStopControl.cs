using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStopControl : MonoBehaviour
{
    private HashSet<PauseSource> _sources = new HashSet<PauseSource>();

    public IReadOnlyCollection<PauseSource> Sources => _sources;

    public void Play(PauseSource pauseSource)
    {
        _sources.Remove(_sources.FirstOrDefault(x => x.Key == pauseSource.Key));

        if (_sources.Count > 0)
        {
            return;
        }

        Time.timeScale = 1;
        AudioListener.volume = 1;
        AudioListener.pause = false;
    }

    public void Stop(PauseSource pauseSource)
    {
        _sources.Add(pauseSource);

        Time.timeScale = 0;
        AudioListener.volume = 0;
        AudioListener.pause = true;
    }
}