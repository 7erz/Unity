using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 1f;
    public Camera camera;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis() : Ư���� key�� ���� �� -1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ�
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        //������ ����ȭ
        dir.Normalize();

        //Time.deltaTime : ���� �������� �Ϸ�Ǵ� �� ���� �ɸ� �ð� �ǹ�
        Debug.Log(Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        if(scene.buildIndex != 0)
        {
            camera.gameObject.SetActive(true);
        }
        else
        {
            camera.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
