using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    //Struct array for keeping the winners
	struct Person {
		uint r_score;
		string r_name;
		uint r_num;
		
		
	};
	
	public static struct Person Rank[10];

	
	static void readRanking()
    {
        string path = "Assets/Resources/ranking.txt";
        TextReader reader = new TextReader(path);
		int i = 0;
		
		do{
		Rank[i].r_score = uint.TryParse(reader.ReadLine);
		Rank[i].r_name = reader.ReadLine();
		Rank[i].r_num = uint.TryParse(reader.ReadLine());
		i++;
		}
		while(Rank[i].r_score);
	}
	
}