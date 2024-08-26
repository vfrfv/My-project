using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace Assets.Scripts
{
    public class Localization : MonoBehaviour
    {
        private const string EnglishCode = "English";
        private const string RussianCode = "Russian";
        private const string TurkishCode = "Turkish";
        private const string Turkish = "tr";
        private const string Russian = "ru";
        private const string English = "en";

        [SerializeField] private LeanLocalization _leanLocalization;

        private string _languageCode;

        private Map _map;
        private string _mapName;

        public string MapName => _mapName;

        private void Awake()
        {
#if (UNITU_WEBGL && !UNITY_EDITOR)
         ChengeLanguage();
#endif

            _languageCode = YandexGamesSdk.Environment.i18n.lang;
        }

        private void ChangeLanguage()
        {
            switch (_languageCode)
            {
                case English:
                    _leanLocalization.SetCurrentLanguage(EnglishCode);
                    
                    break;

                case Turkish:
                    _leanLocalization.SetCurrentLanguage(TurkishCode);
                    
                    break;

                case Russian:
                    _leanLocalization.SetCurrentLanguage(RussianCode);
                    
                    break;
            }
        }

        //private void TranslateText()
        //{
        //    Debug.Log("Получил нужный текст");

        //    switch (_languageCode)
        //    {
        //        case English:
        //            _mapName.text = _map.MapNameEU;
        //            break;

        //        case Turkish:
        //            _mapName.text = _map.MapNameTR;
        //            break;

        //        case Russian:
        //            _mapName.text = _map.MapNameRU;
        //            break;
        //    }
        //}
    }
}


