using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Chinar���ӽű����������
/// </summary>
public class ChinarDemo : MonoBehaviour
{
    void Start()
    {
        //���ĵ� Chinar Ϊ�����ṩ�� ���붯̬�󶨵ķ��������ͨ��������Ӽ����¼����ⲿ�������������
        GameObject.Find("Dropdown").GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
    }


    /// <summary>
    /// ������ ���� ��Ӽ����¼�ʱҪע�⣬��Ҫ�󶨶�̬����
    /// </summary>
    public void ConsoleResult(int value)
    {
        //������ if else ifҲ�ɣ����Լ�ϲ��
        //�ֱ��Ӧ����һ��ڶ���....�Դ�����
        switch (value)
        {
            case 0:
                print("��1ҳ");
                break;
            case 1:
                print("��2ҳ");
                break;
            case 2:
                print("��3ҳ");
                break;
            case 3:
                print("��4ҳ");
                break;
            //���ֻ���õ���4����������е�������ǵ��ò�����
            //��Ҫ��Ӧ�� Dropdown����е� Options���� ������ѡ�����
            case 4:
                print("��5ҳ");
                break;
        }
    }
}