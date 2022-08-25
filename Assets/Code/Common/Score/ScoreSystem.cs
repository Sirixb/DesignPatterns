namespace Common.Score
{
    public interface ScoreSystem
    {
        void Reset();
        int[] GetBestScores();
        int CurrentScore { get; }
    }
}
