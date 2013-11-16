using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


public class LoadXmlData : MonoBehaviour // the Class
{
	static int actualLevel = 1;
	static int LevelMaxNumber;
	static int WaipointCounter = 0;
	static int Value = 0;
	
	static string Cube_Character = "";
	static string Cylinder_Character = "";
	static string Capsule_Character = "";
	static string Sphere_Character = "";
	
	private string finaltext = "";
	
	public GameObject LevelName;
	public GameObject Tutorial;
	public GameObject FinalText;
	
	public TextAsset GameAsset;
	
	List<Dictionary<string,string>> levels = new List<Dictionary<string,string>>();
	Dictionary<string,string> obj;
	
	
	void Start()
	{	//Timeline of the Level creator
		GetLevel();
		StartCoroutine(LevelStartInfo(1.0F));
		LevelMaxNumber = levels.Count;
	}
	
	public void GetLevel()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(GameAsset.text); // load the file.
		XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level"); // array of the level nodes.
	
		foreach (XmlNode levelInfo in levelsList)
		{
			XmlNodeList levelcontent = levelInfo.ChildNodes;
			obj = new Dictionary<string,string>(); // Create a object(Dictionary) to colect the both nodes inside the level node and then put into levels[] array.
			
			foreach (XmlNode levelsItens in levelcontent) // levels itens nodes.
			{
				if(levelsItens.Name == "name")
				{
					obj.Add("name",levelsItens.InnerText); // put this in the dictionary.
				}
				
				if(levelsItens.Name == "tutorial")
				{
					obj.Add("tutorial",levelsItens.InnerText); // put this in the dictionary.
				}
				
				if(levelsItens.Name == "object")
				{
					switch(levelsItens.Attributes["name"].Value)
					{
						case "Cube": obj.Add("Cube",levelsItens.InnerText);break; // put this in the dictionary.
						case "Cylinder":obj.Add("Cylinder",levelsItens.InnerText); break; // put this in the dictionary.
						case "Capsule":obj.Add("Capsule",levelsItens.InnerText); break; // put this in the dictionary.
						case "Sphere": obj.Add("Sphere",levelsItens.InnerText);break; // put this in the dictionary.
					}
				}
				
				if(levelsItens.Name == "finaltext")
				{
					obj.Add("finaltext",levelsItens.InnerText); // put this in the dictionary.
				}
			}
			levels.Add(obj); // add whole obj dictionary in the levels[].
		}
	}
	
	IEnumerator LevelStartInfo(float Wait)
	{
		string lvlName = "";
		levels[actualLevel-1].TryGetValue("name",out lvlName);
		
		string tutorial = "";
		levels[actualLevel-1].TryGetValue("tutorial",out tutorial);
		
		levels[actualLevel-1].TryGetValue("Cube",out Cube_Character);
		levels[actualLevel-1].TryGetValue("Cylinder",out Cylinder_Character);
		levels[actualLevel-1].TryGetValue("Capsule",out Capsule_Character);
		levels[actualLevel-1].TryGetValue("Sphere",out Sphere_Character);
		
		levels[actualLevel-1].TryGetValue("finaltext",out finaltext);
		yield return new WaitForSeconds(Wait);
		
		GameObject LevelName_GUI = Instantiate(LevelName) as GameObject;
		LevelName_GUI.guiText.text = lvlName;
		
		yield return new WaitForSeconds(1.0f);
		
		GameObject Tutorial_GUI = Instantiate(Tutorial) as GameObject;
		Tutorial_GUI.guiText.text = tutorial;
		
		yield return new WaitForSeconds(3.0f);
		DestroyObject(LevelName_GUI);
		
		yield return new WaitForSeconds(4.0f);
		DestroyObject(Tutorial_GUI);
	
	}
	
	void Update()
	{
		if(WaipointCounter == 4)
		{			
			if (Value!= 0)
			{
				actualLevel+=Value;
				WaipointCounter = 0;
				Value = 0;
				StartCoroutine(FinishLevel(1.0F));
			}			
					
			/*if(actualLevel<LevelMaxNumber)
			{
				actualLevel+=1;
				WaipointCounter = 0;
				StartCoroutine(FinishLevel(1.0F));
			}
			else
			{
				actualLevel=1;
				WaipointCounter = 0;
				StartCoroutine(FinishLevel(1.0F));
			}*/			
		}
		else
		{
				Value = 0;
		}
	
	}
	
	IEnumerator FinishLevel(float Wait)
	{
	
		yield return new WaitForSeconds(Wait);
		GameObject FinalText_GUI = Instantiate(FinalText) as GameObject;
		FinalText_GUI.guiText.text = finaltext;
		
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel(0);
	
	}

}