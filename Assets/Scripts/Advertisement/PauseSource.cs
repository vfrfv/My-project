namespace Advertisement
{
    public class PauseSource
    {
        private string _key;
        public string Key => _key;

        public PauseSource(string key)
        {
            _key = key;
        }
    }
}