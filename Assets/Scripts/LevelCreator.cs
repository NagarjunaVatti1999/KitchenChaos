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

    private List<Transform> mygrid;
    private int totalLengthCells;
    private int totalWidthCells;
    void Start()
    {
        dict = new Dictionary<GameObject, int>();
        mygrid = new List<Transform>();

        foreach(var x in counters)
        {
            dict.Add(x.prefab, x.number);
        }

        CreateGrid();
        ReplaceGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    GameObject gridcell = Instantiate(clearCounter, startPosition, Quaternion.identity);
                    //KeyValuePair<Transform, Vector2> cell = new KeyValuePair<Transform, Vector2>(gridcell.transform, new Vector2(i,j));
                    if(!CheckCorners(i,j))mygrid.Add(gridcell.transform);
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
    void ReplaceGrid()
    {
        SortedSet<int> myset = new SortedSet<int>();
        if(mygrid.Count < counters.Length)
        {
            Debug.LogError("Not Enough Counters");
            return;
        }
        foreach(var x in counters)
        {
            int index = UnityEngine.Random.Range(0, mygrid.Count);
            while(myset.Contains(index))
            {
                index = UnityEngine.Random.Range(0, mygrid.Count);
            }
            myset.Add(index);
            Transform getCounter = mygrid[index];
            Instantiate(x.prefab, getCounter.transform.position, Quaternion.identity);
            Destroy(getCounter.gameObject); 
        }
    }
}
