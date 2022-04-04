using UnityEngine;

namespace Universal.SceneManaging
{
	[System.Serializable] public enum Scenes { gameplay, menu, highscores, credits }
	public class SceneGetter : MonoBehaviour
	{
		public Scenes scene;
		public int level = -1;
	}
}