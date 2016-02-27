# Advanced-MonoInspector

MonoBehaviour 스크립트에 Property, Method를 노출 시켜주는 Asset 입니다.
간단한 Attribute 설정으로 Inspector에 해당 스크립트의 Property, Method를 노출 시킬 수 있습니다.

이는 테스트 및 디버깅 시 매우 유용하게 사용될 수 있습니다.
또한 Inspector 노출을 위해 사용했던 Field들을 정리하지 않아 Encapsulation이 깨지는 것을 방지할 수 있습니다.

## 기능
####[ExposeProperty] 

해당 Attribute가 설정된 Property는 Inspector에 노출됩니다.

    [ExposeProperty]
    public float Foo
    {
        get { return foo; }
        set { foo = value; }
    }

    [ExposeProperty]
    public float Goo
    {
        get { return foo; }
    }

    [ExposeProperty]
    public Vector3 Hoo
    {
        get;
        set;
    }

![alt tag](https://cloud.githubusercontent.com/assets/6466389/13372864/8bc84a62-dd99-11e5-8db7-8188545ca608.png)


####[ExposeMethod]

해당 Attribute가 설정된 Method는 인스펙터에 노출됩니다. Invoke를 클릭하면 해당 Method를 실행하고, 만약 반환형이 void가 아니라면 결과를 Console 창에 출력해줍니다.

    [ExposeMethod]
    void Foo()
    {
        
    }

    [ExposeMethod]
    int Goo()
    {
        return 1;
    }

    [ExposeMethod]
    string Hoo(int x, float y, Vector3 z, string w)
    {
        return w;
    }
    
    ![alt tag](https://cloud.githubusercontent.com/assets/6466389/13372890/ddba00c6-dd9a-11e5-86a4-82a9302c0e07.png)
