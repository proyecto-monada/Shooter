using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
	private Transform entryContainer;
	private Transform entryTemplate;
	private Transform entryNewScore;
	private List<HighScoreEntry> highscoreEntryList;
	private List<Transform> highscoreEntryTransformList;
	private Highscores ChangedHighscores;
	
	//public InputField NewScore;
	public InputField NewName;
	public InputField NewCenter;
	
	void Start()
	{
	Cursor.visible = true;
	}

	
	
	private void Awake(){
		
		entryContainer = transform.Find("HighScoreEntryContainer");
		entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
		entryNewScore = transform.Find("NewScore");
		
		entryTemplate.gameObject.SetActive(false);
		
		Highscores highscores;
		
		if (PlayerPrefs.GetString("highscoreTable") != null) {
			Debug.Log("Sí json");
			string jsonString = PlayerPrefs.GetString("highscoreTable");
			highscores = JsonUtility.FromJson<Highscores>(jsonString);
			ChangedHighscores = highscores;
		}
		else {
			Debug.Log("No json");
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
		
			highscores = new Highscores {highscoreEntryList = highscoreEntryList};
			ChangedHighscores = highscores;
		}
		
		
		//Show previous ranking
		
		highscoreEntryTransformList = new List<Transform>();
		
		foreach (HighScoreEntry highscoreEntry in highscores.highscoreEntryList){
			CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
		
	}
	
	private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList){
		float templateHeight = 50f;
		Transform entryTransform = Instantiate(entryTemplate, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2 (0, 200-templateHeight*transformList.Count);
		entryTransform.gameObject.SetActive(true);
		
		int rank = transformList.Count + 1;
		string rankString;
		switch(rank){
			case 1: rankString = "1ST"; break;
			case 2: rankString = "2ND"; break;
			case 3: rankString = "3RD"; break;
			
			default: 
				rankString = rank + "TH"; break;
		}
		
		int score = highscoreEntry.score;
		string name = highscoreEntry.name;
		string center = highscoreEntry.center;
		
		entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
		entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;
		entryTransform.Find("CenterText").GetComponent<Text>().text = center;
		entryTransform.Find("NamesText").GetComponent<Text>().text = name;
		
		entryTransform.Find("BackgroundTemplate").gameObject.SetActive(rank%2 == 1);
		
		transformList.Add(entryTransform);
		
	}
	
	private void UpdateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList, int k){
		
		Transform entryTransform = transformList[k];
		entryTransform.gameObject.SetActive(true);
		
		int score = highscoreEntry.score;
		string name = highscoreEntry.name;
		string center = highscoreEntry.center;
		
		entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
		entryTransform.Find("CenterText").GetComponent<Text>().text = center;
		entryTransform.Find("NamesText").GetComponent<Text>().text = name;	
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
	
	
	public void GetNew(){
		HighScoreEntry NewRanked = new HighScoreEntry{score = Puntuacion.score, name = NewName.text, center = NewCenter.text};
		string json = JsonUtility.ToJson(NewRanked);
		//Debug.Log(json);
		entryNewScore.gameObject.SetActive(false);
		string json0 = JsonUtility.ToJson(ChangedHighscores);
		//Debug.Log(json0);
		
		for(int i = 0; i < 10; i++){
			if(NewRanked.score >= ChangedHighscores.highscoreEntryList[i].score){
				HighScoreEntry tmp = ChangedHighscores.highscoreEntryList[i];
				ChangedHighscores.highscoreEntryList[i] = NewRanked;
				NewRanked = tmp;
				//Debug.Log("Más puntuación");
				string json4 = JsonUtility.ToJson(NewRanked);
				//Debug.Log(json4);
			}
		}
		
		entryTemplate.gameObject.SetActive(false);
		
		int j = 0;
		foreach (HighScoreEntry highscoreEntry in ChangedHighscores.highscoreEntryList){
			UpdateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList, j);
			j++;
		}
		
		string json2 = JsonUtility.ToJson(ChangedHighscores);
		PlayerPrefs.SetString("highscoreTable", json2);
		PlayerPrefs.Save();
	}
}

