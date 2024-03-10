using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject tipPanel;
    bool isEnter = false;
    int count = 0;

    void Start()
    {
        count = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isEnter)
        {
            //Debug.Log("Enter");
            SceneManager.LoadScene(4);
        }

        Debug.Log(count);
        if(count == 6)
        SceneManager.LoadScene(Random.Range(1,5));

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item"))
        {

            Tilemap tilemap = other.GetComponent<Tilemap>();
            // 将碰撞到的位置转换为Tilemap的坐标
            // 碰撞到的位置
            Vector3 hitPosition = other.ClosestPoint(transform.position);
            
            // 将碰撞到的位置转换为Tilemap的坐标
            Vector3Int tilePosition = tilemap.WorldToCell(hitPosition);
            
            // 获取碰撞到的瓦片
            TileBase tile = tilemap.GetTile(tilePosition);
        
            if (tile != null)
            {
                // 销毁碰撞到的瓦片
                tilemap.SetTile(tilePosition, null);
            }
            AudioManager.Play("jump");
            count++;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Castle"))
        {
            isEnter = true;
            tipPanel.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.CompareTag("Castle"))
        {
            isEnter = false;
            tipPanel.SetActive(false);
        }
    }
}
