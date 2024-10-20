namespace LeaderboardPlayer
{
    public readonly struct LeaderboardEntryData
    {
        public LeaderboardEntryData(Agava.YandexGames.LeaderboardEntryResponse entry)
        {
            Rank = entry.rank;
            Name = entry.player.publicName;
            Score = entry.score;

            if (string.IsNullOrEmpty(Name))
                Name = Constants.ANONYMOUS_NAME;
        }

        public int Rank { get; }
        public string Name { get; }
        public int Score { get; }
    }
}