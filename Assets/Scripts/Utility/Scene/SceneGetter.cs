using UnityEngine;

namespace Universal.SceneManaging
{
	[System.Serializable] public enum Scenes { proto, menu, highscores, credits }
	public class SceneGetter : MonoBehaviour
	{
		public Scenes scene;
	}
}