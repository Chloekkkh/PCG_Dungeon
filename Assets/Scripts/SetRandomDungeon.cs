using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public  class SetRandomDungeon : MonoBehaviour
{
    public static void GenerateCastleEntrance(int count, int size, GameObject castleEntrance, float radius, LayerMask landLayer, Transform parent)
    {
        for(int i = 0; i < count; i++)
        {
            Debug.Log("hh");
            Vector3 position = GetRandomPoint(size);
            GameObject castlePrefeb = InstantiateCastle(castleEntrance, position, radius, landLayer);

            if(castlePrefeb!=null)
            {
                castlePrefeb.transform.position = position;
                //setParent
                castlePrefeb.transform.SetParent(parent);
            }
                
        }
    }
    static Vector3 GetRandomPoint(int size)
    {
        int randomX = (int)RandomGaussian.Range(-size, +size);
        int randomY = (int)RandomGaussian.Range(-size, +size);
        return new Vector3(randomX, randomY, 0);
    }
    
    //if has point in circle
    static bool IsOverlap(Vector3 position, float radius, LayerMask landLayer)
    {
        Debug.Log(radius);

        if(Physics2D.OverlapCircle(position, radius, landLayer))
        {
            Debug.Log("attack");
            return true;
        }
            
        else
            return false;
    }
    //实例化castle入口
    static GameObject InstantiateCastle(GameObject castleEntrance, Vector3 position, float radius, LayerMask landLayer)
    {
        if(IsOverlap(position, radius, landLayer))
            return null;
        else
            return Instantiate(castleEntrance, position, new Quaternion());
    }
}
