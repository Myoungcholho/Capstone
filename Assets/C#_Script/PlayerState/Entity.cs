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
 
설계를 어떻게 해야하는가?
배고픔과 피로도..
배고픔은 stage마다 줄꺼고
피로도는 맵마다 줄꺼다

피로도를 그럼.. 흠.. 방마다 피로도를 줘야되는데
3*3이면 설계하기가 좀 그런데?
방이름이랑 매칭되게 해야한다. 전부
Key를 방이름으로 하고 Value값을 피로도로
배고픔도 마찬가지로 해놓고


박스가 끝까지 밀린경우의 스크립트에서 피로도 -1
맵 이동하는 스크립트에, 맵을 넘어가는 경우 -1


[System.Serializable] 넣고
플레이어의 struct State에서..
int Hungry
int MaxHungry
int Fatigue
int MaxFatigue

그냥 전역으로 관리할까?

MapData가 있어야 하는데..
게임 매니저에서 Dictionary<string,float>로 관리하자 일단
한번만 할당해야한다. 어차피 맵 정보는 문자열로 가지고 있으니까



StartCoroutine("HitAnimation");

private IEnumerator HitAnimation(); 이거 되는건가?



 
 
 */
