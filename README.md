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


