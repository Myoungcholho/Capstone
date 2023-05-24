using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private States stats;
    public Entity target;

    public float HP
    {
        set => stats.HP = Mathf.Clamp(value, 0, MaxHP);
        get => stats.HP;
    }

    public float MP
    {
        set => stats.MP = Mathf.Clamp(value, 0, MaxMP);
        get => stats.MP;
    }

    public abstract float MaxHP { get; }
    public abstract float HPRecovery { get; }
    public abstract float MaxMP { get; }
    public abstract float MPRecovery { get; }

    protected void Setup()
    {
        HP = MaxHP;
        MP = MaxMP;

        StartCoroutine("Recovery");
    }

    protected IEnumerator Recovery()
    {
        while (true)
        {
            if (HP < MaxHP) HP += HPRecovery;
            if (MP < MaxMP) MP += MPRecovery;

            yield return new WaitForSeconds(1);
        }
    }

    public abstract void TakeDamage(float damage);
}

[System.Serializable]
public struct States
{
    [HideInInspector]
    public float HP;
    [HideInInspector]
    public float MP;
}

/* 
 
���踦 ��� �ؾ��ϴ°�?
����İ� �Ƿε�..
������� stage���� �ٲ���
�Ƿε��� �ʸ��� �ٲ���

�Ƿε��� �׷�.. ��.. �渶�� �Ƿε��� ��ߵǴµ�
3*3�̸� �����ϱⰡ �� �׷���?
���̸��̶� ��Ī�ǰ� �ؾ��Ѵ�. ����
Key�� ���̸����� �ϰ� Value���� �Ƿε���
����ĵ� ���������� �س���


�ڽ��� ������ �и������ ��ũ��Ʈ���� �Ƿε� -1
�� �̵��ϴ� ��ũ��Ʈ��, ���� �Ѿ�� ��� -1


[System.Serializable] �ְ�
�÷��̾��� struct State����..
int Hungry
int MaxHungry
int Fatigue
int MaxFatigue

�׳� �������� �����ұ�?

MapData�� �־�� �ϴµ�..
���� �Ŵ������� Dictionary<string,float>�� �������� �ϴ�
�ѹ��� �Ҵ��ؾ��Ѵ�. ������ �� ������ ���ڿ��� ������ �����ϱ�



StartCoroutine("HitAnimation");

private IEnumerator HitAnimation(); �̰� �Ǵ°ǰ�?



 
 
 */
