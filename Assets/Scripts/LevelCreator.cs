using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SO_Counters[] counters;
    [SerializeField] float cellSizeLength;
    [SerializeField] float gridLength;
    [SerializeField] float gridWidth;
    [SerializeField] float cellSizeWidth;
    [SerializeField] GameObject clearCounter;
    private Dictionary<GameObject, int> dict;
    private KeyValuePair<GameObject, int>[] holder; 
    private float currentGridWidth;
    private float currentGridLength;
    private int totalLengthCells;
    private int totalWidthCells;
    void Start()
    {
        dict = new Dictionary<GameObject, int>();

        foreach(var x in counters)
        {
            dict.Add(x.prefab, x.number);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(dict.Count);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            CreateGrid();
        }
    }
    void CreateGrid()
    {
        totalLengthCells = Mathf.FloorToInt(gridLength/cellSizeLength);
        totalWidthCells = Mathf.FloorToInt(gridWidth/cellSizeWidth);

        Vector3 startPosition = new Vector3(0,0,0);
        //startPosition = new Vector3(startPosition.x+cellSizeWidth/2, 0, startPosition.z+cellSizeLength/2);

        for(int i=0; i<totalLengthCells ; i++)
        {
            startPosition = new Vector3(startPosition.x+cellSizeWidth/2, 0, startPosition.z+cellSizeLength/2);

            for(int j=0; j<totalWidthCells; j++)
            {
                if(i==0 || i == totalLengthCells-1 ||j ==0 || j == totalWidthCells-1)
                {
                    if(CheckCorners(i,j))
                    {
                        Instantiate(clearCounter, startPosition, Quaternion.identity);
                         startPosition = new Vector3(startPosition.x+cellSizeWidth, 0, startPosition.z);
                        continue;
                    }

                    List<KeyValuePair<GameObject, int>> dict_list =  dict.ToList();

                    KeyValuePair<GameObject, int> item = dict_list[UnityEngine.Random.Range(0, dict_list.Count)];
                    GameObject counter = item.Key;
                    //Debug.Log(counter);
                    int counterNumbers = item.Value;
                    
                    if(counterNumbers>0)
                    {
                        Instantiate(counter, startPosition, Quaternion.identity);
                        dict[counter]--;
                        
                    }else{
                        Instantiate(clearCounter, startPosition, Quaternion.identity);
                    }    
                }
                startPosition = new Vector3(startPosition.x+cellSizeWidth, 0, startPosition.z);
            }
            startPosition.x = 0;
            startPosition.z += cellSizeLength/2; 
        }
    }
   
    bool CheckCorners(int i, int j)
    {
        if((i ==0 && j == 0) || (i==0 && j == totalWidthCells-1) || (i == totalLengthCells-1 && j ==totalWidthCells-1)|| (i == totalLengthCells-1 && j == 0))
        {
            Debug.Log(i+" "+j);
            return true;
        }
        return false;
    }
}
