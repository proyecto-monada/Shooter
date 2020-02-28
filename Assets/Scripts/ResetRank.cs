using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetRank : MonoBehaviour
{
	private List<HighScoreEntry> highscoreEntryList;

	public void ButtonReset() {
		//For save something when RESET
		
		highscoreEntryList = new List<HighScoreEntry> (){
			new HighScoreEntry{score = 0, name = "Marta", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Lucía", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Chechu", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Montse", center = "RESET"},
			new HighScoreEntry{score = 0, name = "David", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Porto", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Diego", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Pedro", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Héctor", center = "RESET"},
			new HighScoreEntry{score = 0, name = "Campi", center = "RESET"},
		};
		
		Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highscoreTable", json);
		PlayerPrefs.Save();
		Debug.Log("Ranking reseted");
	}

	private class Highscores {
		public List<HighScoreEntry> highscoreEntryList;
	}
	
	[System.Serializable]
	
	private class HighScoreEntry {
		public int score;
		public string name;
		public string center;
	}
}
