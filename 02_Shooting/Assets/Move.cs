using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.001f; // public �� �����ϸ� �÷��� ���� ���� ������ �����ϴ�

    // ����Ƽ �̺�Ʈ �Լ� : ����Ƽ�� Ư�� Ÿ�ֿ̹� ���� ��Ű�� �Լ�

    //Start �Լ� : ������ ���۵� ��(������ Update �Լ��� ȣ��Ǳ� ������)ȣ��Ǵ� �Լ�
    private void Start()
    {
        Debug.Log("Hello Unity");
    }

    private void Update()  // Update �Լ� : �� �����Ӹ��� ȣ��Ǵ� �Լ�
    {
        //Vector3 a = new Vector3();
        //a.x;
        //a.y;
        //a.z;
        //Vector 3 : ���͸� ǥ���ϱ� ���� ����ü, ��ġ�� ǥ���Ҷ��� ���� ����Ѵ�.
        //���� : ���� ����� ũ�⸦ ��Ÿ���� ����

        //transform.position += (Vector3.down * speed);
        // �Ʒ��� �������� ���ǵ� ��ŭ ��������...(�� ������ ����) 

        //transform.position += new Vector3(1, 0, 0);

        //new Vector3(1, 0, 0); // ������ Vector3.right;
        //new Vector3(-1, 0, 0); // ����  Vector3.left;
        //new Vector3(0, 1, 0); // ����   Vector3.up;
        //new Vector3(0, -1, 0);// �Ʒ��� Vector3.down;



        //transform.position += (Vector3.down * speed*Time.deltaTime); //�Ʒ��� �������� ���ǵ� ��ŭ ��������...(���� ����) 
        // Time.deltaTime : ���� �����ӿ��� ���� �����ӱ��� �ɸ� �ð� -> 1�����Ӵ� �ɸ��ð�
        //���ʸ��� �ɸ��� ����� ����ϴ� ������ �� ���������� �ϸ� ��ǻ�� ���ɺ��� �ٸ��� ǥ���ȴ�.
        //�׷��� ū ���� ���̸� ����� ������ �����ؾߵ�
        transform.position += (speed * Time.deltaTime * Vector3.down); // ������ �������� Ƚ���� �������� �� ���ʿ� �־�� ȿ����

    }
}
