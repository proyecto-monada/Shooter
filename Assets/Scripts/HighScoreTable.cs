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
	public InputField NewNumber;
	
	
	private void Awake(){
		entryContainer = transform.Find("HighScoreEntryContainer");
		entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
		entryNewScore = transform.Find("NewScore");
		
		entryTemplate.gameObject.SetActive(false);
		
		//For save something when RESET
		
		/*
		highscoreEntryList = new List<HighScoreEntry> (){
			new HighScoreEntry{score = 0, name = "Marta", number = 15076},
			new HighScoreEntry{score = 0, name = "Lucía", number = 14000},
			new HighScoreEntry{score = 0, name = "Chechu", number = 14000},
			new HighScoreEntry{score = 0, name = "Montse", number = 14000},
			new HighScoreEntry{score = 0, name = "David", number = 15000},
			new HighScoreEntry{score = 0, name = "Porto", number = 15000},
			new HighScoreEntry{score = 0, name = "Diego", number = 14000},
			new HighScoreEntry{score = 0, name = "Pedro", number = 15000},
			new HighScoreEntry{score = 0, name = "Héctor", number = 15202},
			new HighScoreEntry{score = 0, name = "Campi", number = 14054},
		};
		
		highscoreEntryTransformList = new List<Transform>();
		
		foreach (HighScoreEntry highscoreEntry in highscoreEntryList){
			CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}
		
		Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
		ChangedHighscores = highscores;
		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highscoreTable", json);
		PlayerPrefs.Save();
		Debug.Log(PlayerPrefs.GetString("highscoreTable"));
		*/
		
		
		string jsonString = PlayerPrefs.GetString("highscoreTable");
		Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
		ChangedHighscores = highscores;
		
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
		int number = highscoreEntry.number;
		
		entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
		entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;
		entryTransform.Find("NumberText").GetComponent<Text>().text = number.ToString();
		entryTransform.Find("NamesText").GetComponent<Text>().text = name;
		
		entryTransform.Find("BackgroundTemplate").gameObject.SetActive(rank%2 == 1);
		
		transformList.Add(entryTransform);
		
	}
	
	private void UpdateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList, int k){
		
		Transform entryTransform = transformList[k];
		entryTransform.gameObject.SetActive(true);
		
		int score = highscoreEntry.score;
		string name = highscoreEntry.name;
		int number = highscoreEntry.number;
		
		entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
		entryTransform.Find("NumberText").GetComponent<Text>().text = number.ToString();
		entryTransform.Find("NamesText").GetComponent<Text>().text = name;	
	}
	
	private class Highscores {
		public List<HighScoreEntry> highscoreEntryList;
	}
	
	[System.Serializable]
	
	private class HighScoreEntry {
		public int score;
		public string name;
		public int number;
	}
	
	
	public void GetNew(){
		HighScoreEntry NewRanked = new HighScoreEntry{score = Puntuacion.score, name = NewName.text, number = int.Parse(NewNumber.text)};
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

