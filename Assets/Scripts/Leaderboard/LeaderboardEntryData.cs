public struct LeaderboardEntryData
{
    public LeaderboardEntryData(int rank, string name, int score)
    {
        Rank = rank;
        Name = name;
        Score = score;
    }

    public int Rank { get; }
    public string Name { get; }
    public int Score { get; }

}
