using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class NpcSpawn : MonoBehaviour
{
    public List<GameObject> npc = new List<GameObject>();

    public Vector2 areaXSize = new Vector2(-35,91);
    public Vector2 areaZSize = new Vector2(-90,51);
    public int numberOfNpc = 300;
    


    void Start()
    {
        

        for (int i = 0; i < numberOfNpc; i++)
        {
            float xCor = Random.Range(areaXSize.x, areaXSize.y);
            float zCor = Random.Range(areaZSize.x, areaZSize.y);

            GameObject objToSpawn = npc[Random.Range(0, npc.Count)];
            //Debug.Log(xCor + "" + zCor + "" + objToSpawn);
            float randomY = Random.Range(0f, 360f);
            Quaternion randomRotation = Quaternion.Euler(0f, randomY, 0f);

            Instantiate(objToSpawn, new Vector3(xCor, -1.5f, zCor), randomRotation);
        }

    }
}
