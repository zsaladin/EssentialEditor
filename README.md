# Advanced-MonoInspector

Unity Asset that exposes properties and methods of MonoBehaviour to inspector. You can expose them to inspector simply by using specific attribute.

It makes your test and debugging easy. Also it can enhance the encapsulation.

Read this in other languages: English, [한국어](README_koKR.md)

## How to use
#### [ExposeProperty] 

The properties using this attribute are exposed in inspector.

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

![alt tag](https://cloud.githubusercontent.com/assets/6466389/13378360/1fb31380-de47-11e5-8847-d9ae57c93676.png)


#### [ExposeMethod]

The methods using this attribute are exposed in inspector. It invokes the method if you click 'Invoke' button. If the return type is not 'void' then the result will be printed in console window.

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

## Author
- Kim Daehee, Game Programmer in Korea.
- zsaladinz@gmail.com

## License
- This asset is under MIT License.
