using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public int numObjects = 10;
	public GameObject numbers;
	public GameObject sum;
	public GameObject cardboardPos;
	// Use this for initialization
	void Start () {
		CreateSum ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void CreateSum()
	{
		Vector3 center = new Vector3 (0, 0, 0);

		Sum newSum = new Sum (10);
		sum.GetComponent<TextMesh> ().text = newSum.ToString ();
		Instantiate(sum, new Vector3(0,0,2), cardboardPos.transform.rotation);
		List<int> answers = GetRandomAnswers (newSum.GetAnswer (), numObjects);
		for (int i = 0; i < numObjects; i++)
		{
			int a = i * (360/numObjects);
			Vector3 pos = RandomCircle(center, 4.0f ,a);
			Quaternion rot = Quaternion.FromToRotation(Vector3.back, center-pos);



			numbers.GetComponent<TextMesh> ().text = answers [i].ToString ();;
			Instantiate(numbers, pos, rot);
		}
	}

	Vector3 RandomCircle(Vector3 center, float radius,int a)
	{
		float ang = a;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}

	List<int> GetRandomAnswers(int goodAnswer, int amountAnswers){
		int min = goodAnswer - amountAnswers;
		int max = goodAnswer + amountAnswers;
		List<int> randomAnswers = new List<int>();
		randomAnswers.Add (goodAnswer);
		while (randomAnswers.Count < (amountAnswers)) {
			int ranInt = Random.Range(min, max);
			if (!randomAnswers.Contains(ranInt)) {
				randomAnswers.Add (ranInt);
			}
		}
		randomAnswers.Sort((a, b)=> 1 - 2 * Random.Range(0, 1));
		return randomAnswers;
	}
}
