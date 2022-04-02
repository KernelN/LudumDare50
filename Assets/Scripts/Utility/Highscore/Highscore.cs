namespace Universal.Highscore
{
	[System.Serializable]
	public struct Highscore
	{
		public int score;
		public string name;

		public Highscore(string newName, int newScore)
		{
			score = newScore;
			name = newName;
		}
	}
	public static class HighscoreSorter
	{
		public static int Compare(Highscore x, Highscore y)
		{
			return y.score.CompareTo(x.score);
		}
	}
}