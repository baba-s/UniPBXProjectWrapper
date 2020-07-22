# UniPBXProjectWrapper

PBXProject のラッパークラス

## 使用例

```cs
using Kogane;
using UnityEditor;

public static class Example
{
    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        using ( var project = new PBXProjectWrapper( "iOS" ) )
        {
            project.SetDebugInformationFormat( false );
            project.SetDebuggingSymbols( false );
            project.SetEnableBitcode( false );
            project.SetGccGenerateDebuggingSymbols( false );
            project.SetOnlyActiveArch( true );
            project.SetBuildProperty( "VALID_ARCHS", "arm64" );
        }
    }
}
```
