using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFaucet : MonoBehaviour {

    public FaucetManager m;
    public List<string> neededNums;
    public Mop mop;
    public List<GameObject> nums;


    void Awake() {
        GenerateNumbers();
    }

    void Update() {
        if (neededNums.Contains(Input.inputString)) {
            neededNums.Remove(Input.inputString);
        }

        if (neededNums.Count < 1) {
            GenerateNumbers();
        }
        m.UpdateFaucets();

        if (m.openFaucets.Count > 0) {
            DisplayNumbers();
        } 
        else if(m.openFaucets.Count == 0) {
            for (int i = 0; i < nums.Count; i++) {
                SpriteRenderer sr = nums[i].GetComponent<SpriteRenderer>();
                sr.sprite = null;
            }
        }
    }
    
    void GenerateNumbers() {

        neededNums.Clear();
        //generate a few random nums
        int amount = Random.Range(3, 7);
        for (int i = 0; i < amount; i++) {
            int c = Random.Range (0,10);
            neededNums.Add(c.ToString());
        }
    }

    void DisplayNumbers() {
        
        for (int i = 0; i < nums.Count; i++) {
            SpriteRenderer sr = nums[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
        }

        for (int i = 0; i < neededNums.Count; i++) {

            SpriteRenderer sr = nums[i].GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load("Numbers/" + neededNums[i], typeof(Sprite)) as Sprite;

            nums[i].name = neededNums[i];
        }
    }
}
