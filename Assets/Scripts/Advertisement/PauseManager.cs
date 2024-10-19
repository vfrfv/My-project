using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Advertisement
{
    public class PauseManager : MonoBehaviour
    {
        private readonly HashSet<PauseSource> _sources = new HashSet<PauseSource>();

        public void Play(PauseSource pauseSource)
        {
            _sources.Remove(_sources.FirstOrDefault(key => key.Key == pauseSource.Key));

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
}